#region System modules

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;
using OpenPop.Pop3;
using System.Text.RegularExpressions;
using Common.Resources;
using Common.Resources.Properties;
using System.Diagnostics;
using Twilio;
using Application = System.Windows.Forms.Application;
using System.Globalization;
using System.Threading;

#endregion

#region Initial Settings

namespace Vixen_Messaging
{
    
    public partial class FormMain : Form
    {
        readonly Pop3Client _pop = new Pop3Client();

        public FormMain()
        {
            InitializeComponent();
            ClientSize = new Size(784, 1091);
        }

        void StartChecking()
        { 
            buttonStart.Enabled = false;
            buttonStop.Enabled = true;
            timerCheckMail.Interval = 200;
            timerCheckMail.Enabled = true;
        }

        private bool Pop3Login()
        {
            try
            {
                var server = textBoxServer.Text;
                var uid = textBoxUID.Text;
                var pwd = textBoxPWD.Text;
                LogDisplay(GlobalVar.LogMsg = ("Connecting to: " + server));
                Application.DoEvents();
                _pop.Connect(server, 995, true);
                LogDisplay(GlobalVar.LogMsg = ("Authenticating: " + uid));
                Application.DoEvents();
                _pop.Authenticate(uid, pwd, AuthenticationMethod.UsernameAndPassword);
                LogDisplay(GlobalVar.LogMsg = ("Connecting to: " + server));
                Application.DoEvents();
                return true;
            }
            catch (Exception ex)
            {
                LogDisplay(GlobalVar.LogMsg = ("Connecting to: " + "Pop Error: " + ex.Message));
                return false;
            }
        }
#endregion

#region Load Form
        private void FormMain_Load(object sender, EventArgs e)
        {
            GlobalVar.Sequential = 1; 
            GlobalVar.SettingsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Vixen Messaging");
            LoadData();
            EmailSettings();
            

            //Ensures a backup of Whitelist, Blacklist and LocalMessages are made in the Appdata folder so a new installation does not remove them and users loose there changes.
            File.Create(textBoxBlacklistEmailLog.Text).Close();
            if (File.Exists(GlobalVar.Blacklistlocation + ".bkp"))
            {
                var copyfile = File.ReadAllText(GlobalVar.Blacklistlocation + ".bkp");
                File.WriteAllText(GlobalVar.Blacklistlocation, copyfile);
            }
            if (File.Exists(GlobalVar.Whitelistlocation + ".bkp"))
            {
                var copyfile = File.ReadAllText(GlobalVar.Whitelistlocation + ".bkp");
                File.WriteAllText(GlobalVar.Whitelistlocation, copyfile);
            }
            if (File.Exists(GlobalVar.LocalMessages + ".bkp"))
            {
                var copyfile = File.ReadAllText(GlobalVar.LocalMessages + ".bkp");
                File.WriteAllText(GlobalVar.LocalMessages, copyfile);
            }

            var vixenMovieFolder = textBoxVixenFolder.Text + "\\Module Data Files\\Nutcracker\\EEEEEEEE-EEEE-EEEE-EEEE-EEEEEEEEEEEE";
            if (!Directory.Exists(vixenMovieFolder))
            {
                Directory.CreateDirectory(vixenMovieFolder);
            }
            GlobalVar.MovieFolder = vixenMovieFolder;
            if (!File.Exists(GlobalVar.MovieFolder + "\\" + "0000000001.png"))
            {
                pictureBoxMovie.Image = Tools.ResizeImage(Resources.ClicktoOpen, 210, 200);
            }
            else
            {
                trackBarThumbnail.Maximum = Directory.GetFiles(GlobalVar.MovieFolder, "*.*", SearchOption.TopDirectoryOnly).Length;
                pictureBoxMovie.ImageLocation = GlobalVar.MovieFolder + "\\" + (trackBarThumbnail.Value.ToString("D10")) + ".png";
            }

            if (comboBoxPlayMode.Text != "Random" && comboBoxPlayMode.Text != "Sequential")
            {
                comboBoxPlayMode.Text = "Sequential";
            }

            extraTime.Enabled = checkBoxVariableLength.Checked;

            var content = File.ReadAllText(GlobalVar.Blacklistlocation);
            richTextBoxBlacklist.Text = content;
            var content1 = File.ReadAllText(GlobalVar.Whitelistlocation);
            richTextBoxWhitelist.Text = content1;
            var content2 = File.ReadAllText(GlobalVar.LocalMessages);
            richTextBoxMessage.Text = content2;

            GlobalVar.Msgindex = 0;
            GlobalVar.PlayMessage = false;

            #region Initial Groups, Tab and Checkboxs are Visable/Enabled/Setup
            //Ensures correct groups are enabled or visable on first load.
            buttonStop.Enabled = false;
            if (checkBoxEnableSqnctrl.Checked)
            {
                groupBoxEffects.Visible = false;
                groupBoxSeqControl.Visible = true;
            }
            else
            {
                groupBoxEffects.Visible = true;
                groupBoxSeqControl.Visible = false;
            }

            if (checkBoxDisableSeq.Checked)
            {
                tabControlEffects.Enabled = false;
                tabControlSequence.Enabled = false;
                checkBoxEnableSqnctrl.Enabled = false;
                checkBoxRandomSeqSelection.Enabled = false;
                checkBoxEnableSqnctrl.Checked = false;
            }

            if (checkBoxMultiLine.Checked)
            {
                TextLineNumber.Enabled = false;
                numericUpDownMultiLine.Enabled = true;
            }

            //Changes Position and Size of Groupboxs in the Sequence Tab
            groupBoxSeqControl.Location = new Point(6, 35);
            tabControlSequence.Size = new Size(555, 185);
            groupBoxSeqControl.Size = new Size(560, 210);
            label26.Location = new Point(60, 255);
            richTextBoxLog2.Location = new Point(6, 295);
            richTextBoxLog2.Size = new Size(560, 270);
            #endregion

            #region Setup Button images and Icons
            //Setup Button images
            buttonRemoveSeq1.Image = Tools.GetIcon(Resources.delete, 16);
            buttonRemoveSeq1.Text = "";
            buttonRemoveSeq2.Image = Tools.GetIcon(Resources.delete, 16);
            buttonRemoveSeq2.Text = "";
            buttonRemoveSeq3.Image = Tools.GetIcon(Resources.delete, 16);
            buttonRemoveSeq3.Text = "";
            buttonRemoveSeq4.Image = Tools.GetIcon(Resources.delete, 16);
            buttonRemoveSeq4.Text = "";
            buttonRemoveSeq5.Image = Tools.GetIcon(Resources.delete, 16);
            buttonRemoveSeq5.Text = "";
            buttonRemoveSeq6.Image = Tools.GetIcon(Resources.delete, 16);
            buttonRemoveSeq6.Text = "";
            buttonStop.Image = Tools.GetIcon(Resources.Stop, 40);
            buttonStart.Image = Tools.GetIcon(Resources.StartB_W, 40);
            buttonStop.Image = Tools.GetIcon(Resources.Stop, 40);
            buttonHelp.Image = Tools.GetIcon(Resources.Help2, 30);
            pictureBoxSaveWhitelist.Image = Tools.ResizeImage(Resources.SaveWhitelist, 100, 60);
            pictureBoxSaveBlacklist.Image = Tools.ResizeImage(Resources.SaveBlacklist, 100, 60);
            pictureBoxMovie.Image = Tools.ResizeImage(Resources.ClicktoOpen, 210, 200);
            buttonMovieDelete.Image = Tools.GetIcon(Resources.delete, 16);
            #endregion

            #region Check Vixen Port settings on startup
            try
            {
                //checks Vixen for port setting and compare to Vixen messaging
                string[] fullFile = File.ReadAllLines(textBoxVixenFolder.Text + "\\SystemData\\ModuleStore.xml");
                var l = new List<string>();
                l.AddRange(fullFile);
                int i = 0;
                do
                {
                    if (fullFile[i].Contains("<HttpPort>"))
                    {
                        if (fullFile[i + 1].Contains("true"))
                        {
                            WebServerStatus.Text = @"Vixen Web Server is ENABLED";
                            WebServerStatus.BackColor = Color.LightGreen;
                        }
                        else
                        {
                            WebServerStatus.Text = @"Vixen Web Server is DISABLED";
                            WebServerStatus.BackColor = Color.OrangeRed;
                        }
                    }
                    i++;
                } while (i != l.Count);
            }
            catch
            {
                MessageBox.Show(@"Vixen 3 User files do not appear to be in the default Documents folder or Vixen 3 is not Installed, Ensure you add the correct folder first or Install Vixen 3.");
            }
            #endregion

            StartChecking();
            if (checkBoxAutoStart.Checked == false)
            {
                Stop_Vixen();
            }
            //Will only display after first run from install.
            var profile = new XmlProfileSettings();
            string checkfirstload = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "checkfirstload", "True");
            if (checkfirstload == "True")
            {
                MessageBox.Show(@"Welcome to Vixen Messaging, as this is the first time you have run Vixen Messaging you are required to enter in some information on the following Data form. Also it is recommended that you create a new Email account for use with Vixen Messaging as it will process every incoming email.");
                Stop_Vixen();
                GetVixenSettings();
            }
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "checkfirstload", "False");
        }
#endregion
    
#region Load Data
        private void LoadData()
        {
            var profile = new XmlProfileSettings();
            textBoxServer.Text = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "POP3Server", "pop.gmail.com");
            textBoxUID.Text = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "UID", "");
            textBoxPWD.Text = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "Password", "");
            textBoxAccessPWD.Text = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "textBoxAccessPWD", "Your Keyword");
            textBoxVixenFolder.Text = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "textBoxVixenFolder", Path.Combine(Environment.ExpandEnvironmentVariables("%userprofile%"), "Documents\\Vixen 3"));
            textBoxVixenServer.Text = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "VixenServer", "http://localhost:8888/api/play/playSequence");
            GlobalVar.Blacklistlocation = Path.Combine(GlobalVar.SettingsPath + "\\Blacklist.txt");
            GlobalVar.Whitelistlocation = Path.Combine(GlobalVar.SettingsPath + "\\Whitelist.txt");
            GlobalVar.LocalMessages = Path.Combine(GlobalVar.SettingsPath + "\\LocalMessages.txt");
            textBoxSequenceTemplate.Text = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "SequenceTemplate", Path.Combine(Environment.ExpandEnvironmentVariables("%userprofile%"), "Documents\\Vixen 3 Messaging"));
            textBoxOutputSequence.Text = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "OutputSequence", Path.Combine(Environment.ExpandEnvironmentVariables("%userprofile%"), "Documents\\Vixen 3\\Sequence\\VixenOut.tim"));
            textBoxGroupName.Text = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "GroupName", "Front Matrix");
            comboBoxString.Text = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "StringOrienation", "Horizontal");
            textBoxLogFileName.Text = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "LogMessageFile", Path.Combine(Environment.ExpandEnvironmentVariables("%userprofile%"), "Documents\\Vixen 3 Messaging\\Logs\\Message.log"));
            textBoxBlacklistEmailLog.Text = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "LogBlacklistFile", Path.Combine(Environment.ExpandEnvironmentVariables("%userprofile%"), "Documents\\Vixen 3 Messaging\\Logs\\Blacklist.log"));
            textBoxSubjectHeader.Text = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "SMSSubjectHeader", "SMS from");
            checkBoxEnableSqnctrl.Checked = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxSqnEnable", false);
            checkBoxAutoStart.Checked = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxAutoStart", false);
            checkBoxBlacklist.Checked = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxBlack_list", true);
            textBoxNodeId.Text = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "textBoxNodeId", "");
            checkBoxDisableSeq.Checked = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxDisableSeq", false);
            checkBoxRandomCol.Checked = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxRandomCol", true);
            EffectType.Value = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "EffectType", 2);
            MaxSnowFlake.Value = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "MaxSnowFlake", 5);
            EffectTime.Value = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "EffectTime", 15);
            FireHeight.Value = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "FireHeight", 40);
            MeteorColour.Text = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "MeteorColour", "Range");
            MeteorCount.Value = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "MeteorCount", 11);
            MeteorTrailLength.Value = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "MeteorTrailLength", 12);
            textBoxVixenSeq1.Text = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "textBoxVixenSeq1", "");
            textBoxVixenSeq2.Text = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "textBoxVixenSeq2", "");
            textBoxVixenSeq3.Text = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "textBoxVixenSeq3", "");
            textBoxVixenSeq4.Text = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "textBoxVixenSeq4", "");
            textBoxVixenSeq5.Text = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "textBoxVixenSeq5", "");
            textBoxVixenSeq6.Text = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "textBoxVixenSeq6", "");
            checkBoxRandomSeqSelection.Checked = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxRandomSeqSelection", true);
            TextColor1.BackColor = Color.FromArgb(Convert.ToInt32(profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "TextColor1", -16776961)));
            TextColor2.BackColor = Color.FromArgb(Convert.ToInt32(profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "TextColor2", -65536)));
            TextColor3.BackColor = Color.FromArgb(Convert.ToInt32(profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "TextColor3", -16711936)));
            TextColor4.BackColor = Color.FromArgb(Convert.ToInt32(profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "TextColor4", -16776961)));
            TextColor5.BackColor = Color.FromArgb(Convert.ToInt32(profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "TextColor5", -32640)));
            TextColor6.BackColor = Color.FromArgb(Convert.ToInt32(profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "TextColor6", -32513)));
            TextColor7.BackColor = Color.FromArgb(Convert.ToInt32(profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "TextColor7", -16711681)));
            TextColor8.BackColor = Color.FromArgb(Convert.ToInt32(profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "TextColor8", -8372160)));
            TextColor9.BackColor = Color.FromArgb(Convert.ToInt32(profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "TextColor9", -65536)));
            TextColor10.BackColor = Color.FromArgb(Convert.ToInt32(profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "TextColor10", -8388353)));
            SingleCol1.BackColor = Color.FromArgb(Convert.ToInt32(profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "SingleCol1", -16776961)));
            SnowFlakeColour1.BackColor = Color.FromArgb(Convert.ToInt32(profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "SnowFlakeColour1", -16776961)));
            SnowFlakeColour2.BackColor = Color.FromArgb(Convert.ToInt32(profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "SnowFlakeColour2", -65536)));
            SnowFlakeColour3.BackColor = Color.FromArgb(Convert.ToInt32(profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "SnowFlakeColour3", -16711936)));
            SnowFlakeColour4.BackColor = Color.FromArgb(Convert.ToInt32(profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "SnowFlakeColour4", -32640)));
            SnowFlakeColour5.BackColor = Color.FromArgb(Convert.ToInt32(profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "SnowFlakeColour5", -32513)));
            SnowFlakeColour6.BackColor = Color.FromArgb(Convert.ToInt32(profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "SnowFlakeColour6", -16711681)));
            checkBoxSnowFlakeColour1.Checked = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxSnowFlakeColour1", true);
            checkBoxSnowFlakeColour2.Checked = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxSnowFlakeColour2", false);
            checkBoxSnowFlakeColour3.Checked = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxSnowFlakeColour3", false);
            checkBoxSnowFlakeColour4.Checked = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxSnowFlakeColour4", false);
            checkBoxSnowFlakeColour5.Checked = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxSnowFlakeColour5", false);
            checkBoxSnowFlakeColour6.Checked = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxSnowFlakeColour6", false);
            MeteorColour1.BackColor = Color.FromArgb(Convert.ToInt32(profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "MeteorColour1", -16776961)));
            MeteorColour2.BackColor = Color.FromArgb(Convert.ToInt32(profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "MeteorColour2", -65536)));
            MeteorColour3.BackColor = Color.FromArgb(Convert.ToInt32(profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "MeteorColour3", -16711936)));
            MeteorColour4.BackColor = Color.FromArgb(Convert.ToInt32(profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "MeteorColour4", -32640)));
            MeteorColour5.BackColor = Color.FromArgb(Convert.ToInt32(profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "MeteorColour5", -32513)));
            MeteorColour6.BackColor = Color.FromArgb(Convert.ToInt32(profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "MeteorColour6", -16711681)));
            checkBoxMeteorColour1.Checked = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxMeteorColour1", true);
            checkBoxMeteorColour2.Checked = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxMeteorColour2", false);
            checkBoxMeteorColour3.Checked = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxMeteorColour3", false);
            checkBoxMeteorColour4.Checked = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxMeteorColour4", false);
            checkBoxMeteorColour5.Checked = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxMeteorColour5", false);
            checkBoxMeteorColour6.Checked = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxMeteorColour6", false);
            TwinkleColour1.BackColor = Color.FromArgb(Convert.ToInt32(profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "TwinkleColour1", -16776961)));
            TwinkleColour2.BackColor = Color.FromArgb(Convert.ToInt32(profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "TwinkleColour2", -65536)));
            TwinkleColour3.BackColor = Color.FromArgb(Convert.ToInt32(profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "TwinkleColour3", -16711936)));
            TwinkleColour4.BackColor = Color.FromArgb(Convert.ToInt32(profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "TwinkleColour4", -32640)));
            TwinkleColour5.BackColor = Color.FromArgb(Convert.ToInt32(profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "TwinkleColour5", -32513)));
            TwinkleColour6.BackColor = Color.FromArgb(Convert.ToInt32(profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "TwinkleColour6", -16711681)));
            checkBoxTwinkleColour1.Checked = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxTwinkleColour1", true);
            checkBoxTwinkleColour2.Checked = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxTwinkleColour2", false);
            checkBoxTwinkleColour3.Checked = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxTwinkleColour3", false);
            checkBoxTwinkleColour4.Checked = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxTwinkleColour4", false);
            checkBoxTwinkleColour5.Checked = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxTwinkleColour5", false);
            checkBoxTwinkleColour6.Checked = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxTwinkleColour6", false);
            trackBarTextSpeed.Value = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "trackBarTextSpeed", 5);
            trackBarTextPosition.Value = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "trackBarTextPosition", 5);
            trackBarSpeedSnowFlakes.Value = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "trackBarSpeedSnowFlakes", 5);
            trackBarSpeedMeteors.Value = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "trackBarSpeedMeteors", 5);
            textBoxSequenceLength1.Text = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "textBoxSequenceLength1", "");
            textBoxSequenceLength2.Text = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "textBoxSequenceLength2", "");
            textBoxSequenceLength3.Text = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "textBoxSequenceLength3", "");
            textBoxSequenceLength4.Text = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "textBoxSequenceLength4", "");
            textBoxSequenceLength5.Text = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "textBoxSequenceLength5", "");
            textBoxSequenceLength6.Text = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "textBoxSequenceLength6", "");
            tabControlSequence.SelectedIndex = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "tabControlSequence", 0);
            tabControlEffects.SelectedIndex = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "tabControlEffects", 0);
            textBoxFont.Text = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "textBoxFont", "Arial");
            textBoxFontSize.Text = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "textBoxFontSize", "10");
            GlobalVar.SeqIntervalTime = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "SeqIntervalTime", 15);
            comboBoxTextDirection.Text = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "comboBoxTextDirection", "Left");
            TextLineNumber.Value = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "TextLineNumber", 1);
            trackBarTwinkleLights.Value = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "trackBarTwinkleLights", 10);
            trackBarTwinkleSteps.Value = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "trackBarTwinkleSteps", 10);
            trackBarSpeedTwinkles.Value = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "trackBarSpeedTwinkles", 1);
            textBoxFromEmailAddress.Text = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "textBoxFromEmailAddress", "anything@gmail.com");
            textBoxReturnSubjectHeading.Text = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "textBoxReturnSubjectHeading", "Lights on Northridge Rd");
            textBoxSMTP.Text = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "textBoxSMTP", "smtp.gmail.com");
            comboBoxEmailSettings.Text = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "comboBoxEmailSettings", "GMail");
            checkBoxVariableLength.Checked = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxVariableLength", true);
            textBoxReturnBannedMSG.Text = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "textBoxReturnBannedMSG", "You have been banned for the night for sending inappropiate words.");
            comboBoxPlayMode.Text = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "comboBoxPlayMode", "Play Only Incoming Msgs");
            checkBoxLocalRandom.Checked = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxLocalRandom", true);
            checkBoxRandom1.Checked = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxRandom1", true);
            checkBoxRandom2.Checked = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxRandom2", true);
            checkBoxRandom3.Checked = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxRandom3", true);
            checkBoxRandom4.Checked = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxRandom4", true);
            checkBoxRandom5.Checked = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxRandom5", false);
            checkBoxRandom6.Checked = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxRandom6", false); 
            extraTime.Value = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "extraTime", 0);
            extraTime.Enabled = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "extraTimeEnabled", false);
            numericUpDownIntervalMsgs.Value = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "numericUpDownIntervalMsgs", 0);
            trackBarMovieSpeed.Value = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "trackBarMovieSpeed", 0);
            trackBarThumbnail.Value = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "trackBarThumbnail", 1);
            numericUpDownMatrixW.Value = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "numericUpDownMatrixW", 50);
            numericUpDownMatrixH.Value = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "numericUpDownMatrixH", 50);
            textBoxGlediator.Text = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "textBoxGlediator", "");
            trackBarGlediator.Value = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "trackBarGlediator", 5);
            GlobalVar.TwilioSID = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "TwilioSID", "");
            GlobalVar.TwilioToken = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "TwilioToken", "");
            checkBoxEmail.Checked = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxEmail", true);
            checkBoxLocal.Checked = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxLocal", true);
            checkBoxTwilio.Checked = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxTwilio", false);
            GlobalVar.TwilioPhoneNumber = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "TwilioPhoneNumber", "");
            checkBoxMultiLine.Checked = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxMultiLine", false);
            numericUpDownMultiLine.Value = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "numericUpDownMultiLine", 1);
            numericUpDownMaxWords.Value = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "numericUpDownMaxWords", 0);
            checkBoxCountDownEnable.Checked = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxCountDownEnable", false);
            comboBoxCountDownDirection.Text = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "comboBoxCountDownDirection", "None");
            trackBarCountDownPosition.Value = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "trackBarCountDownPosition", 20);
            textBoxLine1.Text = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "textBoxLine1", "  COUNTDOWN");
            textBoxLine2.Text = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "textBoxLine2", "days til");
            textBoxLine3.Text = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "textBoxLine3", "   Xmas");
            textBoxLine4.Text = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "textBoxLine4", "");
            var dateCountDownString = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "dateCountDownString", "25/12/15");
            dateCountDown.Value = Convert.ToDateTime(dateCountDownString);
            checkBoxVixenControl.Checked = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxVixenControl", false);
        }
        #endregion

#region Main Form
        private void timerCheckMail_Tick(object sender, EventArgs e)
        {
            timerCheckVixenEnabled.Enabled = true;
            //checks Vixen for port setting and compare to Vixen messaging
            try
            {
                string[] fullFile = File.ReadAllLines(textBoxVixenFolder.Text + "\\SystemData\\ModuleStore.xml");
                var l = new List<string>();
                l.AddRange(fullFile);
                int i = 0;
                do
                {
                    if (fullFile[i].Contains("<HttpPort>"))
                    {
                        if (fullFile[i + 1].Contains("true"))
                        {
                            WebServerStatus.Text = @"Vixen Web Server is ENABLED";
                            WebServerStatus.BackColor = Color.LightGreen;
                        }
                        else
                        {
                            WebServerStatus.Text = @"Vixen Web Server is DISABLED";
                            WebServerStatus.BackColor = Color.OrangeRed;
                        }
                    }
                    i++;
                } while (i != l.Count);
            }
            // ReSharper disable once EmptyGeneralCatchClause
            catch (Exception)
            {
            }

            timerCheckMail.Interval = Convert.ToInt16(GlobalVar.SeqIntervalTime + 5 + numericUpDownIntervalMsgs.Value) * 1000;
            Cursor.Current = Cursors.WaitCursor;

            PlayModes();
        }
#endregion

#region Play Mode

    #region Play Modes
        private void PlayModes()
        {
            if (comboBoxPlayMode.Text == @"Random")
            {
                var rnd = new Random();
                GlobalVar.Sequential = rnd.Next(1, 4);
            }
            switch (GlobalVar.Sequential)
            {
                case 1:
                    if (checkBoxEmail.Checked)
                    {
                        PlayIncomingMsgs(); 
                    }
                    else
                    {
                        ShortTimer(); ;
                    }
                    GlobalVar.Sequential++;
                    break;
                case 2:
                    if (checkBoxLocal.Checked)
                    {
                        PlayLocalMsgs();
                    }
                    else
                    {
                        ShortTimer();
                    }
                    GlobalVar.Sequential++;
                    break;
                case 3:
                    if (checkBoxTwilio.Checked)
                    {
                        PlayTwilio();
                    }
                    else
                    {
                        ShortTimer();
                    }
                    GlobalVar.Sequential++;
                    break;

            }
            if (GlobalVar.Sequential == 4)
            {
                GlobalVar.Sequential = 1;                
            }
        }
        #endregion

    #region Play Incoming Messages
        private void PlayIncomingMsgs()
        {
            try
            {
                var headerphone = "";
                if (Pop3Login())
                {
                    int messageCount = _pop.GetMessageCount();
                    LogDisplay(GlobalVar.LogMsg = ("Message Count: " + messageCount));
                    if (messageCount == 0)
                    {
                        ShortTimer();
                        return;
                    }
                    
                    //GlobalVar.PlayMessage = false;
                    
                    for (int messageNum = 1; messageNum <= messageCount; messageNum++)
                    {
                        var header = _pop.GetMessageHeaders(messageNum);
                        string rtnmsg;
                        if (string.IsNullOrEmpty(header.Subject))
                        {
                            _pop.DeleteMessage(messageNum);
                            _pop.Disconnect();
                            rtnmsg = "Please ensure you enter the message in the subject line.";
                            SendReturnText("", header.From.ToString(), rtnmsg, messageNum);
                        }
                        else
                        {
                        if (header.Subject.Contains(textBoxSubjectHeader.Text))
                        {
                            headerphone = header.Subject.Substring(textBoxSubjectHeader.Text.Length).Trim();
                        }


                            if (!CheckBlacklistMessage(header.From.Address, header.Subject, headerphone))
                            {
                                #region SMS

                                bool blacklist;
                                bool notWhitemsg;
                                bool maxWordCount;
                                if (header.Subject.Contains(textBoxSubjectHeader.Text))
                                    //grabs the SMS header details from the form
                                {

                                    var phoneNumber = header.Subject.Substring(textBoxSubjectHeader.Text.Length).Trim();
                                    var msg = _pop.GetMessage(messageNum);

                                    //To check if text is in the main body or subpart of body for example from an Hotmail account
                                    string smsMessage;
                                    if (msg.MessagePart.Body == null)
                                    {
                                        smsMessage = msg.MessagePart.MessageParts[0].GetBodyAsText();
                                        smsMessage = Regex.Replace(smsMessage, @"\t", "");
                                        smsMessage = smsMessage.TrimEnd(' ');
                                    }
                                    else
                                    {
                                        smsMessage = msg.MessagePart.GetBodyAsText();
                                    }
                                    var msgLines = smsMessage.Split('\r');
                                    if (msgLines[0] != "")
                                    {
                                        LogDisplay(
                                            GlobalVar.LogMsg =
                                                ("Retrieved Header # " + messageNum + ": " + header.Subject));
                                        try
                                        {
                                            smsMessage = msgLines[0];
                                            LogDisplay(GlobalVar.LogMsg = ("SMS Message: " + smsMessage));
                                            _pop.DeleteMessage(messageNum);
                                            // We only want one message at a time so, disconnect and wait for next time.
                                            _pop.Disconnect();
                                            SendMessageToVixen(smsMessage, out blacklist, out notWhitemsg, out maxWordCount);
                                            if (!maxWordCount)
                                            {
                                                if (blacklist && !notWhitemsg)
                                                {
                                                    rtnmsg =
                                                        "Please reframe from using inappropiate words. If this happens again your phone number will be banned for the night.";
                                                    using (
                                                        var file = new StreamWriter(@textBoxBlacklistEmailLog.Text,
                                                            true))
                                                    {
                                                        file.WriteLine(phoneNumber);
                                                    }
                                                    SendReturnText(phoneNumber, header.From.ToString(), rtnmsg,
                                                        messageNum);
                                                    return;
                                                }
                                                else
                                                {
                                                    if (!notWhitemsg)
                                                    {
                                                        rtnmsg = "Your message will appear soon in lights.";
                                                        SendReturnText(phoneNumber, header.From.ToString(), rtnmsg,
                                                            messageNum);
                                                        return;
                                                    }
                                                    else
                                                    {
                                                        rtnmsg =
                                                            "Sorry, one or more of the names you sent is not in the approved list or you are using unapproved abbriviations! You words have been recoreded and if found to be non offensive then they will be added to the list. Please try again on another day.";
                                                        SendReturnText(phoneNumber, header.From.ToString(), rtnmsg,
                                                            messageNum);
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                rtnmsg = "Sorry, your message is too long and will not be display. Please reduce the number of words in your message to below " + (numericUpDownMaxWords.Value + 1) + " and resend. Thank you.";
                                                SendReturnText(phoneNumber, header.From.ToString(), rtnmsg,
                                                    messageNum);
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            LogDisplay(
                                                GlobalVar.LogMsg = ("Error Parsing Message Body: " + ex.Message));
                                        }
                                    }
                                    else
                                    {
                                        _pop.DeleteMessage(messageNum);
                                        _pop.Disconnect();
                                        rtnmsg =
                                            "The body of your SMS is blank, please ensure the message you want to say in the body and not the subject line.";
                                        SendReturnText("", header.From.ToString(), rtnmsg, messageNum);
                                    }
                                }
                                    #endregion

                                else
                                    
                        
                                    // Capture incoming email change in requesting Messaging Settings. 
                                    if (header.Subject.ToLower()
                                        .Contains("messaging " + textBoxAccessPWD.Text.ToLower()))
                                    {
                                        timerCheckMail.Enabled = false;
                                        timerCheckMail.Interval = 12000;
                                        timerCheckMail.Enabled = true;
                                        VixenSettings(messageNum);
                                        break;

                                    }

                                #region Email

                                
                                    if (!CheckBlacklistMessage(header.From.Address, header.Subject, headerphone))
                                    {
                                        LogDisplay(
                                            GlobalVar.LogMsg =
                                                ("Retrieved Header # " + messageNum + ": " + header.Subject));
                                        try
                                        {
                                            string emailMessage = header.Subject;
                                            LogDisplay(GlobalVar.LogMsg = ("Message: " + emailMessage));
                                            _pop.DeleteMessage(messageNum);
                                            // We only want one message at a time so, disconnect and wait for next time.
                                            _pop.Disconnect();
                                            SendMessageToVixen(emailMessage, out blacklist, out notWhitemsg, out maxWordCount);
                                            if (!maxWordCount)
                                            {
                                                if (blacklist && !notWhitemsg)
                                                {
                                                    rtnmsg =
                                                        "Please reframe from using inappropiate words. If this happens again your email address will be banned for the night.";
                                                    using (
                                                        var file = new StreamWriter(@textBoxBlacklistEmailLog.Text,
                                                            true))
                                                    {
                                                        file.WriteLine(header.From.Address);
                                                    }
                                                    SendReturnText("", header.From.ToString(), rtnmsg, messageNum);
                                                    return;
                                                }
                                                else
                                                {
                                                    if (!notWhitemsg)
                                                    {
                                                        rtnmsg = "Your message will appear soon in lights.";
                                                        SendReturnText("", header.From.ToString(), rtnmsg, messageNum);
                                                        return;
                                                    }
                                                    else
                                                    {
                                                        rtnmsg =
                                                            "Sorry one or more of the names you sent is not in the approved list or you are using unapproved abbriviations! You words have been recoreded and if found to be non offensive then they will be added to the list. Please try again on another day.";
                                                        SendReturnText("", header.From.ToString(), rtnmsg, messageNum);
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                rtnmsg = "Sorry, your message is too long and will not be display. Please reduce the number of words in your message to below " + (numericUpDownMaxWords.Value + 1) + " and resend. Thank you.";
                                                SendReturnText("", header.From.ToString(), rtnmsg, messageNum);
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            LogDisplay(GlobalVar.LogMsg = ("Error Parsing Message Body: " + ex.Message));
                                        }
                                    }
                                

                                #endregion
                            }
                            else
                            {
                                //Banned from App
                                _pop.DeleteMessage(messageNum);
                                _pop.Disconnect();
                                rtnmsg = textBoxReturnBannedMSG.Text;
                                SendReturnText("", header.From.ToString(), rtnmsg, messageNum);
                            }
                        
                    }
                        Application.DoEvents();
                    }
                }
            }
            catch
            {
                
            }
            finally
            {
                if (_pop.Connected)
                {
                    try
                    {
                        _pop.Disconnect();
                    }
                    // ReSharper disable once EmptyGeneralCatchClause
                    catch
                    {

                    }
                }
                LogDisplay(GlobalVar.LogMsg = ("Disconnected"));
            }
        }
        #endregion

    #region Play Local Msgs
        private void PlayLocalMsgs()
        {
            if (richTextBoxMessage.Text != "" | checkBoxCountDownEnable.Checked)
            {
                bool blacklist;
                bool notWhitemsg;
                bool maxWordCount;
                string msg;

                var phrases = richTextBoxMessage.Text.Split('\n');
                var msgcount = phrases.Length;
                if (checkBoxLocalRandom.Checked)
                {

                    var rndLineNumber = new Random();
                    var rndLineNumberResult = rndLineNumber.Next(0, msgcount+1);
                    if (rndLineNumberResult == msgcount | richTextBoxMessage.Text == "")
                    {
                        msg = "play counter"; //Play counter is used as its in the Whitelist
                    }
                    else
                    {
                        msg = phrases[rndLineNumberResult];
                    }
                }
                else
                {
                    if (GlobalVar.Msgindex < msgcount & richTextBoxMessage.Text != "")
                    {
                        msg = phrases[GlobalVar.Msgindex];
                        GlobalVar.Msgindex++;
                    }
                    else
                    {
                        if ((GlobalVar.Msgindex == msgcount | richTextBoxMessage.Text == "") & checkBoxCountDownEnable.Checked)
                        {
                            msg = "play counter"; //Play counter is used as its in the Whitelist
                            GlobalVar.Msgindex++;
                        }
                        else
                        {
                            msg = phrases[0];
                            GlobalVar.Msgindex = 1;
                        }
                    }
                }
                SendMessageToVixen(msg, out blacklist, out notWhitemsg, out maxWordCount);
            }
        }
        #endregion

    #region Play with Twilio
        private void PlayTwilio()
        {
            // Find your Account Sid and Auth Token at twilio.com/user/account 
            string AccountSid = GlobalVar.TwilioSID; // "AC29390b0fe3f4cb763862eefedb8afc41";
            string AuthToken = GlobalVar.TwilioToken; // "d68a401090af00f63bbecb4a3e502a7f";
            var twilio = new TwilioRestClient(AccountSid, AuthToken);

            // Build the parameters 
            var options = new MessageListRequest();
            //options.DateSent = DateTime.Today;

            var messages = twilio.ListMessages(options);
            try
            {
                var messageDirection = messages.Messages[messages.Messages.Count - 1].Direction;
                var messageSid = messages.Messages[messages.Messages.Count - 1].Sid;
                while (!messageDirection.Contains("inbound"))
                {
                    twilio.DeleteMessage(messageSid);
                    twilio = new TwilioRestClient(AccountSid, AuthToken);
                    options = new MessageListRequest();
                    messages = twilio.ListMessages(options);
                    messageDirection = messages.Messages[messages.Messages.Count - 1].Direction;
                    messageSid = messages.Messages[messages.Messages.Count - 1].Sid;
                }
                var messageBody = messages.Messages[messages.Messages.Count - 1].Body;
                var messageFrom = messages.Messages[messages.Messages.Count - 1].From;

                //var objBmpImage = new Bitmap(1, 1);

                //// Create the Font object for the image text drawing.
                //var objFont = new Font("Arial", 20, FontStyle.Bold, GraphicsUnit.Pixel);

                //// Create a graphics object to measure the text's width and height.
                //var objGraphics = Graphics.FromImage(objBmpImage);

                //// This is where the bitmap size is determined.
                //int intWidth = (int)objGraphics.MeasureString(messageBody, objFont).Width;
                //int intHeight = (int)objGraphics.MeasureString(messageBody, objFont).Height;

                //// Create the bmpImage again with the correct size for the text and font.
                //objBmpImage = new Bitmap(objBmpImage, new Size(intWidth, intHeight));

                ////Add the colors to the new bitmap.
                //objGraphics = Graphics.FromImage(objBmpImage);

                ////Set Background color
                //objGraphics.Clear(Color.White);
                //objGraphics.SmoothingMode = SmoothingMode.AntiAlias;
                //objGraphics.TextRenderingHint = TextRenderingHint.AntiAlias;
                //objGraphics.DrawString(messageBody, objFont, new SolidBrush(Color.FromArgb(102, 102, 102)), 0, 0);
                //objGraphics.Flush();
                //pictureBoxMovie.Image = objBmpImage;

                LogDisplay(GlobalVar.LogMsg = ("Checking Twilio Messages"));
       //         foreach (var message in messages.Messages)
                if (!CheckBlacklistMessage(messageFrom, messageBody, ""))
                {
                     //Console.WriteLine(message.From + " : " + message.Direction);

                    if (messageDirection.Contains("inbound"))
                    {
                        LogDisplay(GlobalVar.LogMsg = ("Found " + messages.Messages.Count() + " Messages"));
                        if (!messages.Messages.Any())
                        {
                            ShortTimer();
                            return;
                        }
                        LogDisplay(GlobalVar.LogMsg = ("Received: " + messageFrom + " -> " + messageBody));
                        var smsMessage = messageBody;

                        bool blacklist;
                        bool notWhitemsg;
                        bool maxWordCount;
                        SendMessageToVixen(smsMessage, out blacklist, out notWhitemsg, out maxWordCount);
                        if (!maxWordCount)
                        {
                            if (blacklist && !notWhitemsg)
                            {
                                using (var file = new StreamWriter(@textBoxBlacklistEmailLog.Text, true))
                                {
                                    file.WriteLine(messageFrom);
                                }
                                SendReturnTextTwilio(messageFrom,
                                    "Please reframe from using inappropiate words. If this happens again your phone number will be banned for the night.");
                                twilio.DeleteMessage(messageSid);
                                ShortTimer();
                                return;
                            }
                            if (!notWhitemsg)
                            {
                                SendReturnTextTwilio(messageFrom, "Your message will appear soon in lights.");
                                twilio.DeleteMessage(messageSid);
                                return;
                            }
                        }
                        else
                        {
                            SendReturnTextTwilio(messageFrom, "Sorry, your message is too long and will not be display. Please reduce the number of words in your message to below " + (numericUpDownMaxWords.Value + 1) + " and resend. Thank you.");
                            twilio.DeleteMessage(messageSid);
                        }
                        SendReturnTextTwilio(messageFrom, "Sorry one or more of the names you sent is not in the approved list or you are using unapproved abbriviations! You words have been recoreded and if found to be non offensive then they will be added to the list. Please try again on another day.");
                        twilio.DeleteMessage(messageSid);
                        ShortTimer();
                        return;
                    }
                    twilio.DeleteMessage(messageSid);
                    ShortTimer();
                }
                SendReturnTextTwilio(messageFrom, textBoxReturnBannedMSG.Text);
                LogDisplay(GlobalVar.LogMsg = (messageFrom + " has been banned for sending inappropiate messages."));
                Log(" " + messageFrom + " has been banned for sending inappropiate messages.");
                }
                catch
                {
                    LogDisplay(GlobalVar.LogMsg = ("Unable to connect to the Twilio server or there are no messages on the server."));
                    ShortTimer();
                }
        }
        #endregion

    #region Set Short Timer

        private void ShortTimer()
        {
            timerCheckMail.Interval = 200;
        }
        #endregion

    #region Count Down time
        private void CountDown(string msg, out string rtnmsg)
        {
            if (msg.Contains("COUNTDOWN"))
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-AU");
                var daysLeft = DateTime.Parse(dateCountDown.Value.ToShortDateString());
                var now = DateTime.Now;
                //Calculate countdown timer.
                TimeSpan t = daysLeft - now;
                string countDown = string.Format("{0}", t.Days);
                rtnmsg = msg.Replace("COUNTDOWN", countDown);
            }
            else
            {
                rtnmsg = msg;
            }
        }
#endregion

    #region Input message to Change Vixen Settings
        private void VixenSettings(int messageNum)
        {
            #region Get Message details and Body to process
            var messageBody = "";
            var msg = _pop.GetMessage(messageNum);
            string smsMessage = msg.MessagePart.MessageParts[0].GetBodyAsText();
            smsMessage = Regex.Replace(smsMessage, @"\t", "");
            smsMessage = smsMessage.TrimEnd(' ');
            #endregion

            #region Get settings and action
            if (smsMessage.ToLower().Contains("stop"))
            {
                Stop_Vixen();
            }
            if (smsMessage.ToLower().Contains("blacklist"))
            {
                checkBoxBlacklist.Checked = true;
                messageBody = messageBody + "Blacklist is enabled\n";
            }
            else
            {
                if (smsMessage.ToLower().Contains("whitelist"))
                {
                    checkBoxWhitelist.Checked = true;
                    messageBody = messageBody + "Whitelist is enabled\n";
                }
            }
            if (smsMessage.ToLower().Contains("interval"))
            {
                string result = smsMessage.Substring(smsMessage.LastIndexOf("interval=") + 9);
                result = result.Substring(0, 2);
                numericUpDownIntervalMsgs.Value = Convert.ToInt16(result);
                messageBody = messageBody + "Message interval has be changed to " + numericUpDownIntervalMsgs.Value + "\n";
            }
            if (smsMessage.ToLower().Contains("randomcolour"))
            {
                checkBoxRandomCol.Checked = !checkBoxRandomCol.Checked;
                messageBody = messageBody + "Random Text colour is enabled = " + checkBoxRandomCol.Checked + "\n";
            }
            if (smsMessage.ToLower().Contains("randomsequence"))
            {
                checkBoxRandomSeqSelection.Checked = !checkBoxRandomSeqSelection.Checked;
                messageBody = messageBody + "Random Sequence is enabled = " + checkBoxRandomSeqSelection.Checked + "\n";
            }
            if (smsMessage.ToLower().Contains("disable"))
            {
                checkBoxDisableSeq.Checked = true;
                messageBody = messageBody + "All Sequences have been disabled\n";
            }
            if (smsMessage.ToLower().Contains("enable"))
            {
                checkBoxDisableSeq.Checked = false;
                messageBody = messageBody + "All Sequences have been enabled\n";
            }

            if (smsMessage.ToLower().Contains("snowflakeselect"))
            {
                checkBoxDisableSeq.Checked = false;
                checkBoxEnableSqnctrl.Checked = false;
                tabPageSnowFlake.Select();
                checkBoxRandomSeqSelection.Checked = false;
                messageBody = messageBody + "Snowflakes effect has been enabled\n";
            }
            else
            {
                if (smsMessage.ToLower().Contains("fireselect"))
                {
                    checkBoxDisableSeq.Checked = false;
                    checkBoxEnableSqnctrl.Checked = false;
                    tabPageFire.Select();
                    checkBoxRandomSeqSelection.Checked = false;
                    messageBody = messageBody + "Fire effect has been enabled\n";
                }
                else
                {
                    if (smsMessage.ToLower().Contains("meteorselect"))
                    {
                        checkBoxDisableSeq.Checked = false;
                        checkBoxEnableSqnctrl.Checked = false;
                        tabPageMeteors.Select();
                        checkBoxRandomSeqSelection.Checked = false;
                        messageBody = messageBody + "Metoer effect has been enabled\n";
                    }
                    else
                    {
                        if (smsMessage.ToLower().Contains("twinkleselect"))
                        {
                            checkBoxDisableSeq.Checked = false;
                            checkBoxEnableSqnctrl.Checked = false;
                            tabPageTwinkles.Select();
                            checkBoxRandomSeqSelection.Checked = false;
                            messageBody = messageBody + "Twinkle effect has been enabled\n";
                        }
                        else
                        {
                            if (smsMessage.ToLower().Contains("movieselect"))
                            {
                                checkBoxDisableSeq.Checked = false;
                                checkBoxEnableSqnctrl.Checked = false;
                                tabPageMovie.Select();
                                checkBoxRandomSeqSelection.Checked = false;
                                messageBody = messageBody + "Movie effect has been enabled\n";
                            }
                        }
                    }
                }
            }
 
            if (smsMessage.ToLower().Contains("snowflakerandom"))
            {
                checkBoxRandom1.Checked = !checkBoxRandom1.Checked;
                messageBody = messageBody + "SnowFlake included in Random = " + checkBoxRandom1.Checked + "\n";
            }
            if (smsMessage.ToLower().Contains("firerandom"))
            {
                checkBoxRandom2.Checked = !checkBoxRandom2.Checked;
                messageBody = messageBody + "Fire included in Random = " + checkBoxRandom2.Checked + "\n";
            }
            if (smsMessage.ToLower().Contains("meteorrandom"))
            {
                checkBoxRandom3.Checked = !checkBoxRandom3.Checked;
                messageBody = messageBody + "Meteor included in Random = " + checkBoxRandom3.Checked + "\n";
            }
            if (smsMessage.ToLower().Contains("twinklerandom"))
            {
                checkBoxRandom4.Checked = !checkBoxRandom4.Checked;
                messageBody = messageBody + "Twinkle included in Random = " + checkBoxRandom4.Checked + "\n";
            }
            if (smsMessage.ToLower().Contains("movierandom"))
            {
                checkBoxRandom5.Checked = !checkBoxRandom5.Checked;
                messageBody = messageBody + "Movie included in Random = " + checkBoxRandom5.Checked + "\n";
            }
            if (smsMessage.ToLower().Contains("glediatorrandom"))
            {
                checkBoxRandom6.Checked = !checkBoxRandom6.Checked;
                messageBody = messageBody + "Glediator included in Random = " + checkBoxRandom6.Checked + "\n";
            }
            if (smsMessage.ToLower().Contains("localrandom"))
            {
                checkBoxLocalRandom.Checked = !checkBoxLocalRandom.Checked;
                messageBody = messageBody + "Local messages have been enabled = " + checkBoxLocalRandom.Checked + "\n";
            }
            if (smsMessage.ToLower().Contains("vixensequence"))
            {
                checkBoxEnableSqnctrl.Checked = !checkBoxEnableSqnctrl.Checked;
                StopSequence();
                messageBody = messageBody + "Vixen sequences are enabled " + checkBoxEnableSqnctrl.Checked + "\n";
            }
            #endregion

            #region Return Email setting confirmation
            string rtnmsg;
            if (messageBody == "")
            {
                rtnmsg = "You have either not sent any commands or they are spelt incorrectly.";
            }
            else
            {
                rtnmsg = ("The following Settings have been changed:\n\n" + messageBody);
            }
            LogDisplay(GlobalVar.LogMsg = ("SMS Message: " + "Settings have been changed."));
            var header = _pop.GetMessageHeaders(messageNum);
            _pop.DeleteMessage(messageNum);
            _pop.Disconnect();
            SendReturnText("", header.From.ToString(), rtnmsg, messageNum);
            #endregion
        }

#endregion

#endregion

#region Message to Vixen

        private void SendMessageToVixen(string msg, out bool blacklist, out bool notWhitemsg, out bool maxWordCount)
        {
            var notWhite = false;
            blacklist = false;
            try
            {
                var inputFolderName = textBoxSequenceTemplate.Text;
                var inputFileName = inputFolderName + "\\SequenceTemplate.tim";
                var fileText = File.ReadAllText(inputFileName);
                var msgWordCount = msg.Split(' ').Length;
                if (numericUpDownMaxWords.Value != 0 & msgWordCount > numericUpDownMaxWords.Value)
                {
                    notWhitemsg = false;
                    maxWordCount = true;
                    ShortTimer();
                    return;
                }
                if (!HasBadWords(msg, out notWhite) && !notWhite)
                {
                    //Write message to Vixen
                    msg = msg.Replace("&", "&amp;");

                    string outputFileName;
                    if (!checkBoxEnableSqnctrl.Checked)
                    {
            #region Custom Effects

                        if (checkBoxVariableLength.Checked)
                        {
                            timerCheckMail.Enabled = false;
                            var msgcount = msg.Length;
                            string selectedSeqTime = (Convert.ToDecimal(msgcount) * Convert.ToDecimal(0.8) * (Convert.ToDecimal((double)5 / (double)trackBarTextSpeed.Value))).ToString();
                            var index = selectedSeqTime.IndexOf(".");
                            if (index > 0)
                                selectedSeqTime = selectedSeqTime.Substring(0, index);
                            selectedSeqTime = selectedSeqTime.TrimEnd('.');
                            selectedSeqTime = selectedSeqTime.Replace("S", "");
                            var newSeqTime = Convert.ToDecimal(selectedSeqTime);
                            if (checkBoxMultiLine.Checked)
                            {
                                int number = (int) ((newSeqTime + extraTime.Value)/numericUpDownMultiLine.Value + 2);
                                GlobalVar.SeqIntervalTime = Convert.ToDecimal(number);
                            }
                            else
                            {
                                GlobalVar.SeqIntervalTime = newSeqTime + extraTime.Value + 1;
                            }
                            
                        }
                        else
                        {
                            GlobalVar.SeqIntervalTime = Convert.ToDecimal(EffectTime.Value);
                        }

                        outputFileName = textBoxOutputSequence.Text;
                        

                        string fileText1;
                        TextSettings(fileText, msg, out fileText1);

                        fileText = fileText1;

                        var meteorColourType = 0;
                        switch (MeteorColour.Text)
                        {
                            case "Range":
                                meteorColourType = 1;
                                break;
                            case "Palette":
                                meteorColourType = 2;
                                break;
                        }
                        fileText = fileText.Replace("MeteorColour_Change", meteorColourType.ToString()); //Range or Rainbow
                        fileText = fileText.Replace("PT20S", "PT" + GlobalVar.SeqIntervalTime.ToString() + "S"); //Sequence time
                        fileText = fileText.Replace("TextTime_Change", GlobalVar.SeqIntervalTime.ToString()); //Text Sequence time
                        fileText = fileText.Replace("SnowFlake_Change", EffectType.Value.ToString()); //Type
                        fileText = fileText.Replace("SnowFlakeMax_Change", MaxSnowFlake.Value.ToString()); //Max number
                        fileText = fileText.Replace("FireHeight_Change", FireHeight.Value.ToString()); //Fire height
                        fileText = fileText.Replace("MeteorType_Change", MeteorCount.Value.ToString()); //Type
                        fileText = fileText.Replace("MeteorTrailLength_Change", MeteorTrailLength.Value.ToString()); //Max number
                        fileText = fileText.Replace("TwinkleLights_Change", trackBarTwinkleLights.Value.ToString());
                        fileText = fileText.Replace("TwinkleSteps_Change", trackBarTwinkleSteps.Value.ToString());
                        fileText = fileText.Replace("Movie_Change", trackBarMovieSpeed.Value.ToString()); 
                        fileText = fileText.Replace("GlediatorFolder_Change", textBoxGlediator.Text);
                        fileText = fileText.Replace("Glediator_Change", trackBarGlediator.Value.ToString());

                        string selectedSeq;
                        //Random or selected Selection
                        if (checkBoxDisableSeq.Checked)
                        {
                            selectedSeq = "None";
                            fileText = fileText.Replace("EffectTime_Change", "0"); //Sequence time
                        }
                        else
                        {
                            fileText = fileText.Replace("EffectTime_Change", GlobalVar.SeqIntervalTime.ToString()); //Sequence time
                            if (checkBoxRandomSeqSelection.Checked)
                            {
                                var index = 0;
                                var empty = 0;
                                var randomString = new string[6];
                                var seqRandom = new CheckBox[]
                                {checkBoxRandom1, checkBoxRandom2, checkBoxRandom3, checkBoxRandom4, checkBoxRandom5, checkBoxRandom6};
                                string[] mystrings =
                                {
                                    tabPageSnowFlake.Text, tabPageFire.Text, tabPageMeteors.Text,
                                    tabPageTwinkles.Text, tabPageMovie.Text, tabPageGlediator.Text
                                };
                                do
                                {
                                    if (seqRandom[index].Checked)
                                    {
                                        randomString[index] = mystrings[index];
                                    }
                                    else
                                    {
                                        randomString[index] = "";
                                        empty++;
                                    }
                                } while (index++ < 5);

                                do
                                {
                                    var randomseq = new Random();
                                    selectedSeq = randomString[randomseq.Next(randomString.Length)];
                                    if (empty == 6)
                                    {
                                        selectedSeq = "None";
                                    }
                                } while (selectedSeq == "");
                            }
                            else
                            {
                                selectedSeq = tabControlEffects.SelectedTab.Text;
                            }
                        }

                        var i = 1;
                        //Select an Effect
                        switch (selectedSeq)
                        {
                            case "SnowFlakes":
                                fileText = fileText.Replace("Selected_Effect", "Snowflakes");
                                fileText = fileText.Replace("Speed_1Change", trackBarSpeedSnowFlakes.Value.ToString());
                                //Colour selection
                                do
                                {
                                    var btn = new Button[] { null, SnowFlakeColour1, SnowFlakeColour2, SnowFlakeColour3, SnowFlakeColour4, SnowFlakeColour5, SnowFlakeColour6 };
                                    var ckb = new CheckBox[] { null, checkBoxSnowFlakeColour1, checkBoxSnowFlakeColour2, checkBoxSnowFlakeColour3, checkBoxSnowFlakeColour4, checkBoxSnowFlakeColour5, checkBoxSnowFlakeColour6 };
                                    FileSettingsColour(btn, ckb, i, fileText, out fileText1);
                                    fileText = fileText1;
                                    i++;
                                } while (i < 7);
                                break;

                            case "Fire":
                                fileText = fileText.Replace("Selected_Effect", "Fire");
                                fileText = fileText.Replace("Speed_1Change", "0");
                                //Colour selection
                                FileSettings(fileText, out fileText1);
                                fileText = fileText1;
                                break;

                            case "Meteors":
                                fileText = fileText.Replace("Selected_Effect", "Meteors");
                                fileText = fileText.Replace("Speed_1Change", trackBarSpeedMeteors.Value.ToString());
                                //Colour selection
                                do
                                {
                                    var btn = new Button[] { null, MeteorColour1, MeteorColour2, MeteorColour3, MeteorColour4, MeteorColour5, MeteorColour6 };
                                    var ckb = new CheckBox[] { null, checkBoxMeteorColour1, checkBoxMeteorColour2, checkBoxMeteorColour3, checkBoxMeteorColour4, checkBoxMeteorColour5, checkBoxMeteorColour6 };
                                    FileSettingsColour(btn, ckb, i, fileText, out fileText1);
                                    fileText = fileText1;
                                    i++;
                                } while (i < 7);
                                break;

                            case "Twinkles":
                                fileText = fileText.Replace("Selected_Effect", "Twinkles");
                                fileText = fileText.Replace("Speed_1Change", trackBarSpeedTwinkles.Value.ToString());
                                //Colour selection
                                do
                                {
                                    var btn = new Button[] { null, TwinkleColour1, TwinkleColour2, TwinkleColour3, TwinkleColour4, TwinkleColour5, TwinkleColour6 };
                                    var ckb = new CheckBox[] { null, checkBoxTwinkleColour1, checkBoxTwinkleColour2, checkBoxTwinkleColour3, checkBoxTwinkleColour4, checkBoxTwinkleColour5, checkBoxTwinkleColour6 };
                                    FileSettingsColour(btn, ckb, i, fileText, out fileText1);
                                    fileText = fileText1;
                                    i++;
                                } while (i < 7);
                                break;

                            case "Movie":
                                fileText = fileText.Replace("Selected_Effect", "Movie");
                                fileText = fileText.Replace("Speed_1Change", "0");
                                //Colour selection
                                FileSettings(fileText, out fileText1);
                                fileText = fileText1;
                                break;

                            case "Glediator/Jinx":
                                fileText = fileText.Replace("Selected_Effect", "Glediator");
                                fileText = fileText.Replace("Speed_1Change", trackBarGlediator.Value.ToString());
                                //Colour selection
                                FileSettings(fileText, out fileText1);
                                fileText = fileText1;
                                break;

                            case "None":
                                fileText = fileText.Replace("Selected_Effect", "Fire");
                                fileText = fileText.Replace("Speed_1Change", "0");
                                //Colour selection
                                FileSettings(fileText, out fileText1);
                                fileText = fileText1;
                                break;
                        }
                        File.Delete(outputFileName);
                        File.WriteAllText(outputFileName, fileText);
   
                        //Bitmap objBmpImage = new Bitmap(1, 1);

                        //int intWidth = 0;
                        //int intHeight = 0;

                        // // Create the Font object for the image text drawing.
                        //  Font objFont = new Font("Arial", 20, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);

                        // // Create a graphics object to measure the text's width and height.
                        // Graphics objGraphics = Graphics.FromImage(objBmpImage);

                        //// This is where the bitmap size is determined.
                        //intWidth = (int)objGraphics.MeasureString(msg, objFont).Width;
                        // intHeight = (int)objGraphics.MeasureString(msg, objFont).Height;

                        //// Create the bmpImage again with the correct size for the text and font.
                        //objBmpImage = new Bitmap(objBmpImage, new Size(intWidth, intHeight));

                        ////Add the colors to the new bitmap.
                        //objGraphics = Graphics.FromImage(objBmpImage);

                        ////Set Background color
                        //objGraphics.Clear(Color.White);
                        //objGraphics.SmoothingMode = SmoothingMode.AntiAlias;
                        //objGraphics.TextRenderingHint = TextRenderingHint.AntiAlias;
                        //objGraphics.DrawString(msg, objFont, new SolidBrush(Color.FromArgb(102, 102, 102)), 0, 0);
                        //objGraphics.Flush();
                        //pictureBoxMovie.Image = objBmpImage;

                        if (checkBoxVariableLength.Checked)
                        {
                            timerCheckMail.Interval = Convert.ToInt16(GlobalVar.SeqIntervalTime + numericUpDownIntervalMsgs.Value)*1000;
                            timerCheckMail.Enabled = true;
                        }
                    }
              #endregion
                    else
            #region Vixen Sequences
                    {
                        //For Vixen Sequences
                        Mod_Vixen_Seq(msg);
                        outputFileName = textBoxOutputSequence.Text;
                    }
              #endregion

            #region Send Play command to Vixen Web API
                    var url = textBoxVixenServer.Text + "?name=" + WebUtility.UrlEncode(outputFileName);
                    var result = new WebClient().DownloadString(url); //Used to output to Vixen WebClient
                    Cursor.Current = Cursors.Default; 
                    LogDisplay(GlobalVar.LogMsg = ("Vixen Started: + " + result));
                    Log(msg + " has been been displayed in lights");
            #endregion
                }
                else
                {
                    blacklist = true;
                }
            }
            #region Main Exception
            catch (Exception ex)
            {

                if (checkBoxEnableSqnctrl.Checked & textBoxVixenSeq1.Text == "" & textBoxVixenSeq2.Text == "" & textBoxVixenSeq3.Text == "" & textBoxVixenSeq4.Text == "" & textBoxVixenSeq5.Text == "" & textBoxVixenSeq6.Text == "")
                {
                    LogDisplay(GlobalVar.LogMsg = "Error: You do not have any Vixen Sequences loaded or the selected one is empty.");
                    Log("Error: You do not have any Vixen Sequences loaded or the selected one is empty.");
                }
                else
                {
                    Log("Error: " + ex.Message);
                    LogDisplay(GlobalVar.LogMsg = (ex.Message));
                }
                
                if (ex.Message.Contains("server"))
                {
                    MessageBox.Show(@"Warning - Check that Vixen Web Server is enabled and that Vixen 3 is running.", @"Warning");
                }
                ShortTimer();
            }
            #endregion

            notWhitemsg = notWhite;
            maxWordCount = false;
        }

    #region Write to Sequence File Colour and Checkbox settings
        private void FileSettingsColour(Button[] btn, CheckBox[] ckb, int i, string fileText1, out string fileText)
        {
            string hexValue = btn[i].BackColor.A.ToString("x2") + btn[i].BackColor.R.ToString("x2") + btn[i].BackColor.G.ToString("x2") + btn[i].BackColor.B.ToString("x2");
            uint textColorNum = Convert.ToUInt32(hexValue, 16);
            fileText1 = fileText1.Replace("Colour" + i + "_Change", textColorNum.ToString()); //Colour
            fileText1 = fileText1.Replace("CheckBox" + i + "_Change", ckb[i].Checked.ToString().ToLower()); //Colour Enabled true or False
            fileText = fileText1;
        }
        private void FileSettings(string fileText1, out string fileText)
        {
            var i = 1;
            
            do
            {
                fileText1 = fileText1.Replace("Colour" + i + "_Change", "0"); //Colour
                fileText1 = fileText1.Replace("CheckBox" + i + "_Change", "false"); //Colour Enabled true or False
                i++;
            } while (i < 7);
            fileText = fileText1;
        }
        #endregion

    #region Write to Sequence File Text Settings
        private void TextSettings(string fileText1, string msg, out string fileText)
        {
            //Text Colour Selection
            String hexValue;
            ColourSelect(out hexValue); //Colour Selection for Text. Random or Single
            var textColorNum = Convert.ToUInt32(hexValue, 16);
            var i = 0;
            var textDirection = 0;
            if (msg == "play counter" & checkBoxCountDownEnable.Checked)
            {
                var line1 = textBoxLine1.Text;
                var line2 = textBoxLine2.Text;
                var line3 = textBoxLine3.Text;
                var line4 = textBoxLine4.Text;
                CountDown(line1, out msg);
                fileText1 = fileText1.Replace("NamePlaceholder1", msg);
                CountDown(line2, out msg);
                fileText1 = fileText1.Replace("NamePlaceholder2", msg);
                CountDown(line3, out msg);
                fileText1 = fileText1.Replace("NamePlaceholder3", msg);
                CountDown(line4, out msg);
                fileText1 = fileText1.Replace("NamePlaceholder4", msg);
                //Text Direction
                switch (comboBoxCountDownDirection.Text)
                {
                    case "Left": textDirection = 0;
                        break;
                    case "Right": textDirection = 1;
                        break;
                    case "Up": textDirection = 2;
                        break;
                    case "Down": textDirection = 3;
                        break;
                    case "None": textDirection = 4;
                        break;
                }
            }
            else
            {
                CountDown(msg, out msg);
                if (checkBoxMultiLine.Checked)
                {
                    var splitmsg = msg.Split(' ');
                    var splitmsgcount = splitmsg.Length;
                    var lineNumber = new[] {"", "", "", ""};
                    var lineWords = new[] {"", "", "", ""};
                    var ii = 0;
                    var wordsPerLine = (int) Math.Ceiling(splitmsgcount/numericUpDownMultiLine.Value);
                    do
                    {
                        var iii = 0;
                        try
                        {
                            do
                            {
                                lineWords[i] = lineWords[i] + splitmsg[ii] + " ";
                                ii++;
                            } while (iii++ < wordsPerLine - 1);
                        }
                        catch
                        {
                        }
                        lineNumber[i] = lineWords[i];
                    } while (i++ < numericUpDownMultiLine.Value - 1);
                    fileText1 =
                        fileText1.Replace("NamePlaceholder1", lineNumber[0])
                            .Replace("NamePlaceholder2", lineNumber[1])
                            .Replace("NamePlaceholder3", lineNumber[2])
                            .Replace("NamePlaceholder4", lineNumber[3]);
                }
                else
                {
                    //Text Line Number
                    switch (TextLineNumber.Value.ToString())
                    {
                        case "1":
                            fileText1 =
                                fileText1.Replace("NamePlaceholder1", msg)
                                    .Replace("NamePlaceholder2", "")
                                    .Replace("NamePlaceholder3", "")
                                    .Replace("NamePlaceholder4", ""); //replaces the text
                            break;
                        case "2":
                            fileText1 =
                                fileText1.Replace("NamePlaceholder1", "")
                                    .Replace("NamePlaceholder2", msg)
                                    .Replace("NamePlaceholder3", "")
                                    .Replace("NamePlaceholder4", ""); //replaces the text
                            break;
                        case "3":
                            fileText1 =
                                fileText1.Replace("NamePlaceholder1", "")
                                    .Replace("NamePlaceholder2", "")
                                    .Replace("NamePlaceholder3", msg)
                                    .Replace("NamePlaceholder4", ""); //replaces the text
                            break;
                        case "4":
                            fileText1 =
                                fileText1.Replace("NamePlaceholder1", "")
                                    .Replace("NamePlaceholder2", "")
                                    .Replace("NamePlaceholder3", "")
                                    .Replace("NamePlaceholder4", msg); //replaces the text
                            break;
                    }
                }
                //Text Direction
                switch (comboBoxTextDirection.Text)
                {
                    case "Left": textDirection = 0;
                        break;
                    case "Right": textDirection = 1;
                        break;
                    case "Up": textDirection = 2;
                        break;
                    case "Down": textDirection = 3;
                        break;
                    case "None": textDirection = 4;
                        break;
                }
            }
            
            fileText1 = fileText1.Replace("TextDirection_Change", textDirection.ToString());
            fileText1 = fileText1.Replace("NodeId_Change", textBoxNodeId.Text);//adds NodeId
            fileText1 = fileText1.Replace("StringOrienation_Change", comboBoxString.Text);
            fileText1 = fileText1.Replace("Speed_Change", trackBarTextSpeed.Value.ToString());
            fileText1 = fileText1.Replace("FontName_Change", textBoxFont.Text);
            fileText1 = fileText1.Replace("FontSize_Change", textBoxFontSize.Text);
            fileText1 = fileText1.Replace("TextPosition_Change", trackBarTextPosition.Value.ToString());
            fileText1 = fileText1.Replace("Colour_Change1", textColorNum.ToString());
            fileText = fileText1;
        }
#endregion

#endregion

#region Send Return Text to Email
        private void SendReturnText(string phoneNumber, string msgTo, string rtnmsg, int messageNum)
        {
            //Only setup form Email at the moment
            try
            {
                var message = new MailMessage();
                LogDisplay(GlobalVar.LogMsg = ("To: " + msgTo));
                message.To.Add(msgTo);
                message.Subject = textBoxReturnSubjectHeading.Text;
                message.From = new MailAddress(textBoxFromEmailAddress.Text);
                message.Body = rtnmsg;
                var smtp = new SmtpClient(textBoxSMTP.Text, 587)
                {
                    EnableSsl = true,
                    UseDefaultCredentials = false,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new NetworkCredential(textBoxUID.Text, textBoxPWD.Text)
                };
                smtp.Send(message);
            }
            catch (Exception ex)
            {
                LogDisplay(GlobalVar.LogMsg = ("SMTP Error: " + ex.Message));
            }
        }
        #endregion

#region Send Return Text to Twilio

        private void SendReturnTextTwilio(string from, string msgBody)
        {
            string accountSid = GlobalVar.TwilioSID;  // "AC29390b0fe3f4cb763862eefedb8afc41";
            string authToken = GlobalVar.TwilioToken;  // "d68a401090af00f63bbecb4a3e502a7f";
            var twilio = new TwilioRestClient(accountSid, authToken);
            var message = twilio.SendMessage(GlobalVar.TwilioPhoneNumber, from, msgBody);
            LogDisplay(GlobalVar.LogMsg = ("Return Message sent to " + from));
        }

        #endregion

#region Word List check for Blacklist and Whitelist
        private bool HasBadWords(string msg, out bool notWhite)
        {
            string textLine;
            var rgx = new Regex("[^a-zA-Z0-9]");

            #region Checks against Blacklist
            if (checkBoxBlacklist.Checked)
            {
                //Check against your Blacklist
                using (var file = new StreamReader(GlobalVar.Blacklistlocation))
                {
                    do
                    {
                        textLine = file.ReadLine();

                        msg = rgx.Replace(msg, "");

                        if (textLine != null && msg.ToLower().Contains(textLine))
                        {
                            LogDisplay(GlobalVar.LogMsg = ("Bad Words Detected!"));
                            file.Close();
                            Log(" " + msg + ". Bad Words Detected!");
                            notWhite = false;
                            return true;
                        }
                    } while (file.Peek() != -1);
                    file.Close();
                    notWhite = false;
                    return false;
                }
            }
            #endregion

            #region Checks against Whitelist
            //Checks against your Whitelist
            rgx = new Regex("[^a-zA-Z0-9 ]");
            msg = rgx.Replace(msg, ""); //creates an array of all the individual names.
            var splitmsg = msg.Split(' ');
            var i = 0;
            var splitmsgcount = splitmsg.Length; //to determine how many words are in the message.
            bool notWhiteCheck;
            do
            {
                using (var file = new StreamReader(GlobalVar.Whitelistlocation))
                {
                    do
                    {
                        textLine = file.ReadLine();
                        if (splitmsg[i].ToLower() == textLine)
                        {
                            notWhiteCheck = false;
                            break;
                        }
                        if (splitmsg[i].ToLower() == "countdown")
                        {
                            notWhiteCheck = false;
                            break;
                        }
                        notWhiteCheck = true;
                    } while (file.Peek() != -1);
                    file.Close();
                        
                    if (notWhiteCheck)
                    {
                        break;
                    }
                }
                i++;
            } while (i < splitmsgcount);
            if (!notWhiteCheck)
            {
                notWhite = false;
                return false;
            }
            #endregion

            LogDisplay(GlobalVar.LogMsg = ("One or more Names are not in Whitelist."));
            Log(" " + msg + ". One or more Names are not in Whitelist.");
            notWhite = true;
            return true;
        }
#endregion

#region Check Banned List
        private bool CheckBlacklistMessage(string headerfrom, string headersms, string headerphone)
        {
            var maxaddress = 0;
            var checkheader = headersms.Contains(textBoxSubjectHeader.Text) ? headerphone : headerfrom;

            using (var file = new StreamReader(textBoxBlacklistEmailLog.Text))
            {
                do
                {
                    var checkBlacklist = file.ReadLine();

                    if (checkheader != checkBlacklist) continue;
                    maxaddress = maxaddress + 1;
                    if (maxaddress != 2) continue;
                    file.Close();
                    return true;
                } while (file.Peek() != -1);
                file.Close();
                return false;
            }
        }
#endregion

#region Colour

        #region Colour Dialog Box and button colour settings

        private void TextColor1_Click(object sender, EventArgs e)
        {
            int colNum = 1;
            ColPal(colNum);
        }

        private void TextColor2_Click(object sender, EventArgs e)
        {
            int colNum = 2;
            ColPal(colNum);
        }

        private void TextColor3_Click(object sender, EventArgs e)
        {
            int colNum = 3;
            ColPal(colNum);
        }

        private void TextColor4_Click(object sender, EventArgs e)
        {
            int colNum = 4;
            ColPal(colNum);
        }

        private void TextColor5_Click(object sender, EventArgs e)
        {
            int colNum = 5;
            ColPal(colNum);
        }

        private void TextColor6_Click(object sender, EventArgs e)
        {
            int colNum = 6;
            ColPal(colNum);
        }

        private void TextColor7_Click(object sender, EventArgs e)
        {
            int colNum = 7;
            ColPal(colNum);
        }

        private void TextColor8_Click(object sender, EventArgs e)
        {
            int colNum = 8;
            ColPal(colNum);
        }

        private void TextColor9_Click(object sender, EventArgs e)
        {
            int colNum = 9;
            ColPal(colNum);
        }

        private void TextColor10_Click(object sender, EventArgs e)
        {
            int colNum = 10;
            ColPal(colNum);
        }
        private void SingleCol1_Click(object sender, EventArgs e)
        {
            int colNum = 11;
            ColPal(colNum);
        }

        private void SnowFlakeColour1_Click(object sender, EventArgs e)
        {
            int colNum = 12;
            ColPal(colNum);
        }

        private void SnowFlakeColour2_Click(object sender, EventArgs e)
        {
            int colNum = 13;
            ColPal(colNum);
        }

        private void SnowFlakeColour3_Click(object sender, EventArgs e)
        {
            int colNum = 14;
            ColPal(colNum);
        }

        private void SnowFlakeColour4_Click(object sender, EventArgs e)
        {
            int colNum = 15;
            ColPal(colNum);
        }

        private void SnowFlakeColour5_Click(object sender, EventArgs e)
        {
            int colNum = 16;
            ColPal(colNum);
        }

        private void SnowFlakeColour6_Click(object sender, EventArgs e)
        {
            int colNum = 17;
            ColPal(colNum);
        }

        private void MeteorColour1_Click(object sender, EventArgs e)
        {
            int colNum = 18;
            ColPal(colNum);
        }

        private void MeteorColour2_Click(object sender, EventArgs e)
        {
            int colNum = 19;
            ColPal(colNum);
        }

        private void MeteorColour3_Click(object sender, EventArgs e)
        {
            int colNum = 20;
            ColPal(colNum);
        }

        private void MeteorColour4_Click(object sender, EventArgs e)
        {
            int colNum = 21;
            ColPal(colNum);
        }

        private void MeteorColour5_Click(object sender, EventArgs e)
        {
            int colNum = 22;
            ColPal(colNum);
        }

        private void MeteorColour6_Click(object sender, EventArgs e)
        {
            int colNum = 23;
            ColPal(colNum);
        }

        private void TwinkleColour1_Click(object sender, EventArgs e)
        {
            int colNum = 24;
            ColPal(colNum);
        }

        private void TwinkleColour2_Click(object sender, EventArgs e)
        {
            int colNum = 25;
            ColPal(colNum);
        }

        private void TwinkleColour3_Click(object sender, EventArgs e)
        {
            int colNum = 26;
            ColPal(colNum);
        }

        private void TwinkleColour4_Click(object sender, EventArgs e)
        {
            int colNum = 27;
            ColPal(colNum);
        }

        private void TwinkleColour5_Click(object sender, EventArgs e)
        {
            int colNum = 28;
            ColPal(colNum);
        }

        private void TwinkleColour6_Click(object sender, EventArgs e)
        {
            int colNum = 29;
            ColPal(colNum);
        }

        private void checkBoxRandomCol_CheckedChanged(object sender, EventArgs e)
        {
            SingleColourSelection.Enabled = !SingleColourSelection.Enabled;
            RandomColourSelection.Enabled = !RandomColourSelection.Enabled;
        }

        private void ColPal(int colNum)
        {
            colorDialog1.ShowDialog();

            var btn = new Button[] { TextColor1, TextColor1, TextColor2, TextColor3, TextColor4, TextColor5, TextColor6, TextColor7, TextColor8, TextColor9, TextColor10, SingleCol1, SnowFlakeColour1, SnowFlakeColour2, SnowFlakeColour3, SnowFlakeColour4, SnowFlakeColour5, SnowFlakeColour6, MeteorColour1, MeteorColour2, MeteorColour3, MeteorColour4, MeteorColour5, MeteorColour6, TwinkleColour1, TwinkleColour2, TwinkleColour3, TwinkleColour4, TwinkleColour5, TwinkleColour6 };
            btn[colNum].BackColor = colorDialog1.Color;
            SeqSave();
        }
        #endregion

        #region Colour Selection
        public void ColourSelect(out string hexValue)
        {
            
            if (checkBoxRandomCol.Checked)
            {
                do
                {
                    var random = new Random(); 
                    var randomCol = random.Next(1, 10);
                    var btn = new Button[] { TextColor1, TextColor2, TextColor3, TextColor4, TextColor5, TextColor6, TextColor7, TextColor8, TextColor9, TextColor10 };
                    hexValue = btn[randomCol].BackColor.A.ToString("x2") + btn[randomCol].BackColor.R.ToString("x2") + btn[randomCol].BackColor.G.ToString("x2") + btn[randomCol].BackColor.B.ToString("x2");
                } while (hexValue == "ff000000");
            }
            else
            {
                // Replace for Single Colour
                hexValue = SingleCol1.BackColor.A.ToString("x2") + SingleCol1.BackColor.R.ToString("x2") + SingleCol1.BackColor.G.ToString("x2") + SingleCol1.BackColor.B.ToString("x2");          
            }
        }
#endregion

#endregion

#region Vixen Sequences

        #region Get Sequence Time for Message Interval
        private void SelectSeqTime()
        {
            var selection = "";

            var txt = new TextBox[]
            {
                textBoxSequenceLength1, textBoxSequenceLength2, textBoxSequenceLength3, textBoxSequenceLength4,
                textBoxSequenceLength5, textBoxSequenceLength6 };
            selection = txt[tabControlSequence.SelectedIndex].Text;

            if (selection != "")
            {
                string seqTimeString;
                if (selection.Contains("M"))
                {
                    //get time string of 1M23.345S for example and convert to seconds then add to Time Interval box.
                    var index = selection.IndexOf(".");
                    if (index > 0)
                    selection = selection.Substring(0, index);
                    seqTimeString = selection.TrimEnd('.');
                    seqTimeString = selection.Replace("M", "");
                    var length = seqTimeString.Length;
                    var seqTimeString1 = seqTimeString.Remove(1, length - 1);
                    int seqTimeString2 = Convert.ToInt16(seqTimeString1);
                    seqTimeString2 = seqTimeString2 * 60;
                    seqTimeString = seqTimeString.Remove(0, 1);
					seqTimeString = seqTimeString.Replace("S", "");
                    int seqTimeString3 = Convert.ToInt16(seqTimeString);
                    var newSeqTime = Convert.ToDecimal(seqTimeString2 + seqTimeString3);
					GlobalVar.SeqIntervalTime = newSeqTime + 20; // add 20 seconds to allow for the Sequence to finish before another check for messages is performed.
                }
                else
                {
					var index = selection.IndexOf(".");
					if (index > 0)
						selection = selection.Substring(0, index);
					seqTimeString = selection.TrimEnd('.');
					seqTimeString = seqTimeString.Replace("S", "");
					var newSeqTime = Convert.ToDecimal(seqTimeString);
					GlobalVar.SeqIntervalTime = newSeqTime + 10; // add 10 seconds to allow for the Sequence to finish before another check for messages is performed.
                }
            }
        }
        #endregion

        #region Button Remove or Click
        private void buttonVixenSeq1_Click(object sender, EventArgs e)
        {
            var index = 0;
            LoadSeq(index);
        }

        private void buttonVixenSeq2_Click(object sender, EventArgs e)
        {
            var index = 2;
            LoadSeq(index);
        }

        private void buttonVixenSeq3_Click(object sender, EventArgs e)
        {
            var index = 4;
            LoadSeq(index);
        }
        private void buttonVixenSeq4_Click(object sender, EventArgs e)
        {
            var index = 6;
            LoadSeq(index);
        }

        private void buttonVixenSeq5_Click(object sender, EventArgs e)
        {
            var index = 8;
            LoadSeq(index);
        }
        private void buttonVixenSeq6_Click(object sender, EventArgs e)
        {
            var index = 10;
            LoadSeq(index);
        }

        private void buttonRemoveSeq1_Click(object sender, EventArgs e)
        {
            textBoxVixenSeq1.Text = "";
            textBoxSequenceLength1.Text = "";
        }

        private void buttonRemoveSeq2_Click(object sender, EventArgs e)
        {
            textBoxVixenSeq2.Text = "";
            textBoxSequenceLength2.Text = "";
        }

        private void buttonRemoveSeq3_Click(object sender, EventArgs e)
        {
            textBoxVixenSeq3.Text = "";
            textBoxSequenceLength3.Text = "";
        }
        private void buttonRemoveSeq4_Click_1(object sender, EventArgs e)
        {
            textBoxVixenSeq4.Text = "";
            textBoxSequenceLength4.Text = "";
        }

        private void buttonRemoveSeq5_Click(object sender, EventArgs e)
        {
            textBoxVixenSeq5.Text = "";
            textBoxSequenceLength5.Text = "";
        }

        private void buttonRemoveSeq6_Click(object sender, EventArgs e)
        {
            textBoxVixenSeq6.Text = "";
            textBoxSequenceLength6.Text = "";
        }
        #endregion

        #region Initial settings to Load Seq
        private void LoadSeq(int index)
        {
            string seqNumber;
            string seqTime;
            var loadSeq = new TextBox[] { textBoxVixenSeq1, textBoxSequenceLength1, textBoxVixenSeq2, textBoxSequenceLength2, textBoxVixenSeq3, textBoxSequenceLength3, textBoxVixenSeq4, textBoxSequenceLength4, textBoxVixenSeq5, textBoxSequenceLength5, textBoxVixenSeq6, textBoxSequenceLength6 };
            LoadSeq(out seqNumber, out seqTime);
            if (seqNumber != "")
            {
                loadSeq[index].Text = seqNumber;
            }
            if (seqTime != "")
            {
                loadSeq[index + 1].Text = seqTime;
            }
            SelectSeqTime();
        }
        #endregion

#endregion

#region Get Vixen Seq Name
        private void LoadSeq(out string seqNumber, out string seqTime)
        {
            //Used to find the NodeId of the Nutcracker effect.
            var openFileDialog1 = new OpenFileDialog
            {
                Filter = @"Vixen Sequence Files (.tim)|*.tim",
                InitialDirectory =
                    Path.Combine(Environment.ExpandEnvironmentVariables("%userprofile%"),
                        "Documents\\Vixen 3\\Sequence\\")
            };

            // Set filter options and filter index.

            // Process input if the user clicked OK.
            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                seqNumber = openFileDialog1.FileName;
                string str;
                var sequenceLength = "";

                //Used to find Web Server Port from the ModuleStore.xml file.
                var reading = File.OpenText(openFileDialog1.FileName);
                while ((str = reading.ReadLine()) != null)
                {
                    if (str.Contains("<Length xmlns="))
                    {
                        sequenceLength = str;
                    }
                }
                reading.Close();
                if (sequenceLength == "")
                {
                    MessageBox.Show(@"Unable to find Sequence Length, please ensure you have retrived the correct Vixen 3 Folder path", @"WARNING");
                    seqTime = "";
                }
                else
                {
                    sequenceLength = sequenceLength.Replace("<Length xmlns=\"\">PT", "");
                    sequenceLength = sequenceLength.Replace("</Length>", "");
                    sequenceLength = sequenceLength.Replace(" ", "");
                    seqTime = sequenceLength;
                }
            }
            else
            {
                seqNumber = "";
                seqTime = "";
            }
        }
#endregion

#region Mod Vixen Sequence
        private void Mod_Vixen_Seq (string msg)
        {
            var lineNumber = 1;
            var firstLineNumber = 0;
            var secondLineNumber = 0;
            string selectedSeq;
            string selectedSeqTime;
            var iii = 0;
            var randomseq = new Random();

            #region Gets sequence legnth and time 
            if (checkBoxRandomSeqSelection.Checked)
            {
                do
                {
                    string[] mystrings = { textBoxVixenSeq1.Text, textBoxVixenSeq2.Text, textBoxVixenSeq3.Text, textBoxVixenSeq4.Text, textBoxVixenSeq5.Text, textBoxVixenSeq6.Text };
                    selectedSeq = mystrings[randomseq.Next(mystrings.Length)];
                    if (iii == 400)
                    {
                        break;
                    }
                    iii++;
                } while (selectedSeq == "");

                string str;
                var sequenceLength = "";
                var reading = File.OpenText(selectedSeq);
                    while ((str = reading.ReadLine()) != null)
                    {
                        if (str.Contains("<Length xmlns="))
                        {
                            sequenceLength = str;
                        }
                    }
                    reading.Close();
                        sequenceLength = sequenceLength.Replace("<Length xmlns=\"\">PT", "");
                        sequenceLength = sequenceLength.Replace("</Length>", "");
                        sequenceLength = sequenceLength.Replace(" ", "");
                        selectedSeqTime = sequenceLength;
            }
            else
            {
                var selected = tabControlSequence.SelectedIndex;
                var txtSeq = new TextBox[] { textBoxVixenSeq1, textBoxVixenSeq2, textBoxVixenSeq3, textBoxVixenSeq4, textBoxVixenSeq5, textBoxVixenSeq6 };
                var txtLen = new TextBox[] { textBoxSequenceLength1, textBoxSequenceLength2, textBoxSequenceLength3, textBoxSequenceLength4, textBoxSequenceLength5, textBoxSequenceLength6 };
                selectedSeq = txtSeq[selected].Text;
                selectedSeqTime = txtLen[selected].Text;
            }

                string seqTimeString;
                var selectedSeqTime1 = "";
                if (selectedSeqTime.Contains("M"))
                {
                    //get time string of 1M23.345S for example and convert to seconds then add to Time Interval box.
                    var index = selectedSeqTime.IndexOf(".");

                    if (index > 0)
                    {
                        selectedSeqTime = selectedSeqTime.Substring(0, index);
                    }
                    seqTimeString = selectedSeqTime.Replace("M", "");
                    var length = seqTimeString.Length;
                    var seqTimeString1 = seqTimeString.Remove(1, length - 1);
                    int seqTimeString2 = Convert.ToInt16(seqTimeString1);
                    seqTimeString2 = seqTimeString2*60;
                    seqTimeString = seqTimeString.Remove(0, 1);
                    seqTimeString = seqTimeString.Replace("S", "");
                    selectedSeqTime = seqTimeString;
                    int seqTimeString3 = Convert.ToInt16(seqTimeString);
                    var newSeqTime = Convert.ToDecimal(seqTimeString2 + seqTimeString3);
                    GlobalVar.SeqIntervalTime = newSeqTime + 15;
                        // add 15 seconds to allow for the Sequence to finish before another check for messages is performed.
                }
                else
                {
                    var index = selectedSeqTime.IndexOf(".");
                    if (index > 0)
                    {
                        selectedSeqTime = selectedSeqTime.Substring(0, index);
                    }
                    seqTimeString = selectedSeqTime.Replace("S", "");
                    selectedSeqTime = seqTimeString;
                    var newSeqTime = Convert.ToDecimal(seqTimeString);
                    GlobalVar.SeqIntervalTime = newSeqTime + 5;
                        // add 5 seconds to allow for the Sequence to finish before another check for messages is performed.
                }

            #endregion

            timerCheckMail.Enabled = false;

            #region Open Sequence templates 1 and 2 to be used to copy into Vixen Sequence
            //Open Sequence and determine Line numbers for the insert of Nutcracker files 1 and 2
            using (var file = new StreamReader(selectedSeq))
            {
                do
                {
                    string textLine = file.ReadLine();
                    if (textLine != null && textLine.Contains("Serialization/Arrays\" xmlns=\"\">"))
                    {
                        firstLineNumber = lineNumber;
                    }
                    if (textLine != null && textLine.Contains("<EffectNodeSurrogate>"))
                    {
                        secondLineNumber = lineNumber;
                        break;
                    }
                    lineNumber++;
                } while (file.Peek() != -1);
                file.Close();
            }

            //Open Requested Sequence file to use
            var fullFile = File.ReadAllLines(Path.Combine(selectedSeq));
            var l = new List<string>();
            l.AddRange(fullFile);
            //Open Sequence Data file1 that needs to be inserted.
            var fullFile1 = File.ReadAllLines(Path.Combine(Environment.ExpandEnvironmentVariables("%userprofile%"), "Documents\\Vixen 3 Messaging\\Sequence Data.txt"));
            var l1 = new List<string>();
            l1.AddRange(fullFile1);
            l1.Reverse();
            var i = 0;
            do
            {
                l.Insert(firstLineNumber, l1[i]);
                i++;
            } while (i != l1.Count);
            //Open Sequence Data file2 that needs to be inserted.
            var fullFile2 = File.ReadAllLines(Path.Combine(Environment.ExpandEnvironmentVariables("%userprofile%"), "Documents\\Vixen 3 Messaging\\Sequence Data1.txt"));
            var l2 = new List<string>();
            l2.AddRange(fullFile2);
            l2.Reverse();
            var ii = 0;
            do
            {
                l.Insert(secondLineNumber + l1.Count, l2[ii]);
                ii++;
            } while (ii != l2.Count);
            //Save new file name as VixenOut.tim
            File.WriteAllLines(Path.Combine(textBoxOutputSequence.Text), l.ToArray());
            #endregion

            #region Modify Vixen Seqence and save new file to Vixen 3 Sequence folder. Filename called VixenOut.tim
            var fileText = File.ReadAllText(textBoxOutputSequence.Text);
            string fileText1;
            TextSettings(fileText, msg, out fileText1);
            fileText = fileText1;
            fileText = fileText.Replace("TimeSpan_Change", selectedSeqTime + "S"); //Adjust Text effect to match Sequence length
            File.Delete(textBoxOutputSequence.Text);
            File.WriteAllText(textBoxOutputSequence.Text, fileText);
            timerCheckMail.Interval = Convert.ToInt16(GlobalVar.SeqIntervalTime + numericUpDownIntervalMsgs.Value) * 1000; 
			timerCheckMail.Enabled = true;
            #endregion
        }
#endregion

#region Movie Effect

        private void pictureBoxMovie_Click(object sender, EventArgs e)
        {
            AddMovie();
        }

        private void buttonMovieDelete_Click(object sender, EventArgs e)
        {
            DeleteExistingMovieFiles(GlobalVar.MovieFolder);
            pictureBoxMovie.Image = Tools.ResizeImage(Resources.ClicktoOpen, 210, 200);
        }

        private void AddMovie()
        {
            fileDialog.Filter = @"All Files|*.*";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
      //          textBoxMovieLocation.Text = Guid.NewGuid().ToString();

                if (!Directory.Exists(GlobalVar.MovieFolder))
                {
                    Directory.CreateDirectory(GlobalVar.MovieFolder);
                }
                DeleteExistingMovieFiles(GlobalVar.MovieFolder);
                ProcessMovie(fileDialog.FileName);
            }
        }
        private void ProcessMovie(string movieFileName)
        {
            try
            {
                int matrixW = Convert.ToInt16(numericUpDownMatrixW.Value);
                int matrixH = Convert.ToInt16(numericUpDownMatrixH.Value);
                var f = new NutcrackerProcessingMovie();
                f.Show();
                var converter = new Ffmpeg(movieFileName);
                converter.MakeThumbnails(matrixW, matrixH, GlobalVar.MovieFolder);
                f.Close();
                trackBarThumbnail.Maximum = Directory.GetFiles(GlobalVar.MovieFolder, "*.*", SearchOption.TopDirectoryOnly).Length;
				if (trackBarThumbnail.Maximum == 0)
				{
					MessageBox.Show(@"There was a problem converting " + movieFileName + ".\nEnsure you have selected a movie format.");
				    trackBarThumbnail.Maximum = 2000;
				    trackBarThumbnail.Minimum = 1;
				}
				else
				{
                    pictureBoxMovie.ImageLocation = GlobalVar.MovieFolder + @"\0000000001.png";
				}
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"There was a problem converting " + movieFileName + ": " + ex.Message, @"Error Converting Movie",
                                MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private class Ffmpeg
        {
            private readonly string _movieFile = string.Empty;

            public Ffmpeg(string movieFile)
            {
                _movieFile = movieFile;
            }

            public void MakeThumbnails(int matrixW, int matrixH, string outputPath)
            {
					var width = matrixW;
					var height = matrixH;
					var framesPerSecond = 25;

					//make arguements string
					var args = " -i \"" + _movieFile + "\"" +
								  " -s " + width + "x" + height +
								  " -vf " +
								  " fps=" + framesPerSecond + " \"" + outputPath + "\\%10d.png\"";
					//create a process
					var myProcess = new Process();
					myProcess.StartInfo.UseShellExecute = false;
					myProcess.StartInfo.RedirectStandardOutput = true;
					//point ffmpeg location
					var ffmpegPath = AppDomain.CurrentDomain.BaseDirectory;
					ffmpegPath += "ffmpeg.exe";
					myProcess.StartInfo.FileName = ffmpegPath;
					//set arguements
					myProcess.StartInfo.Arguments = args;
					Console.WriteLine(ffmpegPath + " => " + args);
					myProcess.Start();

					myProcess.WaitForExit();
            }
        }
        
        private void DeleteExistingMovieFiles(string folder)
        {
            var folderInfo = new DirectoryInfo(folder);

            foreach (var file in folderInfo.GetFiles())
            {
                file.Delete();
            }
            foreach (var dir in folderInfo.GetDirectories())
            {
                dir.Delete(true);
            }
            trackBarThumbnail.Value = 1;
        }
        #endregion

#region Glediator/Jinx
        private void buttonGlediator_Click(object sender, EventArgs e)
        {
            fileDialog.Filter = @"Gled Files|*.gled";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxGlediator.Text = fileDialog.FileName;
            }
        }
        #endregion

#region Get Vixen Settings

    #region Get Vixen Server Settings
        private void GetServerSettings()
        {
            var portResult = "";
            try
            {
                var fullFile = File.ReadAllLines(textBoxVixenFolder.Text + "\\SystemData\\ModuleStore.xml");
                var l = new List<string>();
                l.AddRange(fullFile);
                var i = 0;
                do
                {

                    if (fullFile[i].Contains("<HttpPort>"))
                    {
                        portResult = fullFile[i];
                    }
                    i++;
                } while (i != l.Count);
            }
            // ReSharper disable once EmptyGeneralCatchClause
            catch
            {
            }

            if (portResult == "")
            {
                MessageBox.Show(@"Unable to find Web Server settings, please ensure you have retrived the correct Vixen 3 Folder path", @"WARNING");
            }
            else
            {
                portResult = portResult.Replace("<HttpPort>",  "");
                portResult = portResult.Replace("</HttpPort>", "");
                portResult = portResult.Replace(" ", "");
                textBoxVixenServer.Text = @"http://localhost:" + portResult + @"/api/play/playSequence";
            }
        }
#endregion

    #region Get Vixen Path and settings
        private void buttonGetVixenData_Click(object sender, EventArgs e)
        {
            GetVixenSettings();
        }
        private void GetVixenSettings()
        {
            var retrieveVixenSettings = new RetrieveVixenSettings();
            retrieveVixenSettings.ShowDialog();

            if (retrieveVixenSettings.checkBoxVixenPath.Checked)
            {
                //Gets Vixen Folder location, NodeId, output folder and Server settings.
                MessageBox.Show(@"Select your Vixen 3 folder. Normally located in your Documents Folder.");
                folderBrowserDialog1 = new FolderBrowserDialog
                {
                    SelectedPath =
                        Path.Combine(Environment.ExpandEnvironmentVariables("%userprofile%"), "Documents\\Vixen 3\\")
                };

                // Process input if the user clicked OK.
                if (folderBrowserDialog1.ShowDialog(this) == DialogResult.OK)
                {
                    textBoxVixenFolder.Text = folderBrowserDialog1.SelectedPath;
                }
            }
            
            if (retrieveVixenSettings.checkBoxWebServer.Checked)
            {
                GetServerSettings();
            }

            if (retrieveVixenSettings.textBoxVixenGroupName.Text != "")
            {
                textBoxGroupName.Text = retrieveVixenSettings.textBoxVixenGroupName.Text;
            }

            if (retrieveVixenSettings.checkBoxNodeID.Checked)
            {
                GetNodeId();
            }

            if (retrieveVixenSettings.textBoxServer.Text != "")
            {
                textBoxServer.Text = retrieveVixenSettings.textBoxServer.Text;
            }

            if (retrieveVixenSettings.textBoxUID.Text != "")
            {
                textBoxUID.Text = retrieveVixenSettings.textBoxUID.Text;
            }

            if (retrieveVixenSettings.textBoxPWD.Text != "")
            {
                textBoxPWD.Text = retrieveVixenSettings.textBoxPWD.Text;
            }
        }
#endregion

    #region Get Nod ID
        private void GetNodeId()
        {
            var nodeResult = "";

            try
            {
                //Used to find the NodeId of the Nutcracker effect.
                var reading = File.OpenText((textBoxVixenFolder.Text + "\\SystemData\\SystemConfig.xml"));
                string str;
                while ((str = reading.ReadLine()) != null)
                {
                    if (str.Contains("<Node name=\"" + textBoxGroupName.Text + "\" id=\""))
                    {
                        nodeResult = str;
                    }
                }

                nodeResult = nodeResult.Replace("<Node name=\"" + textBoxGroupName.Text + "\" id=\"", "");
                nodeResult = nodeResult.Trim(new Char[] { '\"', '>', ' ' });
                reading.Close();

                if (nodeResult == "")
                {
                    MessageBox.Show(@"Unable to find NodeId for your Group, please ensure you have entered the correct Group Name above and it is case sensitive", @"WARNING");
                }
                else
                {
                    textBoxNodeId.Text = nodeResult;
                }
            }
            // ReSharper disable once EmptyGeneralCatchClause
            catch
            {
            }
        }
#endregion

#endregion

#region Manually enter settings
        private void checkBoxManEnterSettings_CheckedChanged(object sender, EventArgs e)
        {
            textBoxVixenFolder.Enabled = !textBoxVixenFolder.Enabled;
            textBoxVixenServer.Enabled = !textBoxVixenServer.Enabled;
            textBoxSequenceTemplate.Enabled = !textBoxSequenceTemplate.Enabled;
            textBoxOutputSequence.Enabled = !textBoxOutputSequence.Enabled;
            textBoxNodeId.Enabled = !textBoxNodeId.Enabled;
        }
#endregion

#region Button Start and Stop checking for Messages
        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (checkBoxVixenControl.Checked)
            {
                MessageBox.Show(@"You must have the Vixen Control disable to use this button");
            }
            else
            {
                Start_Vixen();
            }
        }

        private void Start_Vixen()
        {
            buttonStart.Image = Tools.GetIcon(Resources.StartB_W, 40);
            buttonStart.Text = "";
            buttonStop.Image = Tools.GetIcon(Resources.Stop, 40);
            buttonStop.Text = "";
            StartChecking();
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            if (checkBoxVixenControl.Checked)
            {
                MessageBox.Show(@"You must have the Vixen Control disable to use this button");
            }
            else
            {
                Stop_Vixen();
            }
        }

        private void Stop_Vixen()
        {
             buttonStart.Image = Tools.GetIcon(Resources.Start, 40);
             buttonStart.Text = "";
             buttonStop.Image = Tools.GetIcon(Resources.StopB_W, 40);
             buttonStop.Text = "";
             timerCheckMail.Enabled = false;
             buttonStart.Enabled = true;
             buttonStop.Enabled = false;
        }
#endregion

#region Stop Currently Running Sequence
        private void buttonStopSequence_Click(object sender, EventArgs e)
        {
            StopSequence();
        }

        private void StopSequence()
        {
            try
            {
            bool vixenRunning = Process.GetProcesses().Any(clsProcess => clsProcess.ProcessName.Contains("VixenApplication"));
            if (vixenRunning)
                using (var wc = new WebClient())
                {
                    var stopSequence = textBoxVixenServer.Text.Replace("playSequence", "stopSequence");
                    wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                    wc.UploadString(stopSequence, "");
                }
            }
            catch (Exception)
            {
                

            }
        }
        #endregion

#region Logs

        #region Log File
        private void Log(string st)
        {
            var logFileName = textBoxLogFileName.Text;
            File.AppendAllText(logFileName, DateTime.Now.ToString("g") + " " + st + "\r\n");
        }
        #endregion

        #region Log Display
        private void LogDisplay(string logMsg)
        {
            richTextBoxLog.Text = richTextBoxLog.Text.Insert(0, (DateTime.Now.ToString("h:mm tt ")) + logMsg + "\n");
            richTextBoxLog1.Text = richTextBoxLog.Text.Insert(0, (DateTime.Now.ToString("h:mm tt ")) + logMsg + "\n");
            richTextBoxLog2.Text = richTextBoxLog.Text.Insert(0, (DateTime.Now.ToString("h:mm tt ")) + logMsg + "\n");
        }
        #endregion

#endregion

#region Help Form
        private void buttonHelp_Click(object sender, EventArgs e)
        {
            var helpform = new HelpForm();
            helpform.ShowDialog();
        }
#endregion

#region Reset Vixen Messaging Setting to Default
        private void buttonResetToDefault_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(@"Are you sure you would like to revert all settings back to the default, this will include all settings on the Sequencing Tab too.", @"Reset Vixen Messaging setting to Default", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                File.Delete(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Vixen Messaging", "Settings.xml"));
                LoadData();
            }
        }
#endregion

#region Close Vixen Messaging
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            SeqSave();
            StopSequence();
        }
#endregion

#region Save Data
        private void SeqSave()
        {
            var profile = new XmlProfileSettings();
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "POP3Server", textBoxServer.Text);
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "UID", textBoxUID.Text);
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "Password", textBoxPWD.Text);
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "textBoxAccessPWD", textBoxAccessPWD.Text);
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "textBoxVixenFolder", textBoxVixenFolder.Text);
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "VixenServer", textBoxVixenServer.Text);
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "SequenceTemplate", textBoxSequenceTemplate.Text);
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "OutputSequence", textBoxOutputSequence.Text);
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "GroupName", textBoxGroupName.Text);
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "StringOrienation", comboBoxString.Text);
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "LogMessageFile", textBoxLogFileName.Text);
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "LogBlacklistFile", textBoxBlacklistEmailLog.Text);
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "SMSSubjectHeader", textBoxSubjectHeader.Text);
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxSqnEnable", checkBoxEnableSqnctrl.Checked);
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxAutoStart", checkBoxAutoStart.Checked);
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxBlack_list", checkBoxBlacklist.Checked);
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "textBoxNodeId", textBoxNodeId.Text);
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxDisableSeq", checkBoxDisableSeq.Checked);
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxRandomCol", checkBoxRandomCol.Checked);
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "EffectType", EffectType.Value.ToString());
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "MaxSnowFlake", MaxSnowFlake.Value.ToString());
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "MeteorColour", MeteorColour.Text);
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "MeteorCount", MeteorCount.Value.ToString());
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "MeteorTrailLength", MeteorTrailLength.Value.ToString());
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "EffectTime", EffectTime.Value.ToString());
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "FireHeight", FireHeight.Value.ToString());
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "textBoxVixenSeq1", textBoxVixenSeq1.Text);
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "textBoxVixenSeq2", textBoxVixenSeq2.Text);
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "textBoxVixenSeq3", textBoxVixenSeq3.Text);
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "textBoxVixenSeq4", textBoxVixenSeq4.Text);
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "textBoxVixenSeq5", textBoxVixenSeq5.Text);
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "textBoxVixenSeq6", textBoxVixenSeq6.Text);
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxRandomSeqSelection", checkBoxRandomSeqSelection.Checked);
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "TextColor1", TextColor1.BackColor.ToArgb());
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "TextColor2", TextColor2.BackColor.ToArgb());
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "TextColor3", TextColor3.BackColor.ToArgb());
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "TextColor4", TextColor4.BackColor.ToArgb());
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "TextColor5", TextColor5.BackColor.ToArgb());
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "TextColor6", TextColor6.BackColor.ToArgb());
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "TextColor7", TextColor7.BackColor.ToArgb());
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "TextColor8", TextColor8.BackColor.ToArgb());
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "TextColor9", TextColor9.BackColor.ToArgb());
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "TextColor10", TextColor10.BackColor.ToArgb());
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "SingleCol1", SingleCol1.BackColor.ToArgb());
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "SnowFlakeColour1", SnowFlakeColour1.BackColor.ToArgb());
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "SnowFlakeColour2", SnowFlakeColour2.BackColor.ToArgb());
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "SnowFlakeColour3", SnowFlakeColour3.BackColor.ToArgb());
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "SnowFlakeColour4", SnowFlakeColour4.BackColor.ToArgb());
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "SnowFlakeColour5", SnowFlakeColour5.BackColor.ToArgb());
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "SnowFlakeColour6", SnowFlakeColour6.BackColor.ToArgb());
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxSnowFlakeColour1", checkBoxSnowFlakeColour1.Checked);
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxSnowFlakeColour2", checkBoxSnowFlakeColour2.Checked);
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxSnowFlakeColour3", checkBoxSnowFlakeColour3.Checked);
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxSnowFlakeColour4", checkBoxSnowFlakeColour4.Checked);
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxSnowFlakeColour5", checkBoxSnowFlakeColour5.Checked);
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxSnowFlakeColour6", checkBoxSnowFlakeColour6.Checked);
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "MeteorColour1", MeteorColour1.BackColor.ToArgb());
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "MeteorColour2", MeteorColour2.BackColor.ToArgb());
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "MeteorColour3", MeteorColour3.BackColor.ToArgb());
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "MeteorColour4", MeteorColour4.BackColor.ToArgb());
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "MeteorColour5", MeteorColour5.BackColor.ToArgb());
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "MeteorColour6", MeteorColour6.BackColor.ToArgb());
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxMeteorColour1", checkBoxMeteorColour1.Checked);
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxMeteorColour2", checkBoxMeteorColour2.Checked);
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxMeteorColour3", checkBoxMeteorColour3.Checked);
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxMeteorColour4", checkBoxMeteorColour4.Checked);
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxMeteorColour5", checkBoxMeteorColour5.Checked);
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxMeteorColour6", checkBoxMeteorColour6.Checked);
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "TwinkleColour1", TwinkleColour1.BackColor.ToArgb());
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "TwinkleColour2", TwinkleColour2.BackColor.ToArgb());
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "TwinkleColour3", TwinkleColour3.BackColor.ToArgb());
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "TwinkleColour4", TwinkleColour4.BackColor.ToArgb());
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "TwinkleColour5", TwinkleColour5.BackColor.ToArgb());
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "TwinkleColour6", TwinkleColour6.BackColor.ToArgb());
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxTwinkleColour1", checkBoxTwinkleColour1.Checked);
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxTwinkleColour2", checkBoxTwinkleColour2.Checked);
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxTwinkleColour3", checkBoxTwinkleColour3.Checked);
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxTwinkleColour4", checkBoxTwinkleColour4.Checked);
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxTwinkleColour5", checkBoxTwinkleColour5.Checked);
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxTwinkleColour6", checkBoxTwinkleColour6.Checked);
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "trackBarTextPosition", trackBarTextPosition.Value.ToString());
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "trackBarTextSpeed", trackBarTextSpeed.Value.ToString());
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "trackBarSpeedSnowFlakes", trackBarSpeedSnowFlakes.Value.ToString());
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "trackBarSpeedMeteors", trackBarSpeedMeteors.Value.ToString());
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "textBoxSequenceLength1", textBoxSequenceLength1.Text);
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "textBoxSequenceLength2", textBoxSequenceLength2.Text);
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "textBoxSequenceLength3", textBoxSequenceLength3.Text);
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "textBoxSequenceLength4", textBoxSequenceLength4.Text);
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "textBoxSequenceLength5", textBoxSequenceLength5.Text);
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "textBoxSequenceLength6", textBoxSequenceLength6.Text);
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "tabControlSequence", tabControlSequence.SelectedIndex);
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "tabControlEffects", tabControlEffects.SelectedIndex);
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "SeqIntervalTime", GlobalVar.SeqIntervalTime.ToString());
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "textBoxFont", textBoxFont.Text);
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "textBoxFontSize", textBoxFontSize.Text);
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "comboBoxTextDirection", comboBoxTextDirection.Text);
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "TextLineNumber", TextLineNumber.Value.ToString());
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "trackBarTwinkleSteps", trackBarTwinkleSteps.Value.ToString());
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "trackBarTwinkleLights", trackBarTwinkleLights.Value.ToString());
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "trackBarSpeedTwinkles", trackBarSpeedTwinkles.Value.ToString());
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "textBoxReturnSubjectHeading", textBoxReturnSubjectHeading.Text);
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "textBoxFromEmailAddress", textBoxFromEmailAddress.Text);
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "textBoxSMTP", textBoxSMTP.Text);
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "comboBoxEmailSettings", comboBoxEmailSettings.Text);
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxVariableLength", checkBoxVariableLength.Checked.ToString());
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "textBoxReturnBannedMSG", textBoxReturnBannedMSG.Text);
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "comboBoxPlayMode", comboBoxPlayMode.Text);
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxLocalRandom", checkBoxLocalRandom.Checked.ToString());
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxRandom1", checkBoxRandom1.Checked.ToString());
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxRandom2", checkBoxRandom2.Checked.ToString());
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxRandom3", checkBoxRandom3.Checked.ToString());
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxRandom4", checkBoxRandom4.Checked.ToString());
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxRandom5", checkBoxRandom5.Checked.ToString());
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxRandom6", checkBoxRandom6.Checked.ToString());
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "extraTime", extraTime.Value.ToString());
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "extraTimeEnabled", extraTime.Enabled.ToString());
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "numericUpDownIntervalMsgs", numericUpDownIntervalMsgs.Value.ToString());
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "trackBarMovieSpeed", trackBarMovieSpeed.Value.ToString());
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "trackBarThumbnail", trackBarThumbnail.Value.ToString());
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "numericUpDownMatrixW", numericUpDownMatrixW.Value.ToString());
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "numericUpDownMatrixH", numericUpDownMatrixH.Value.ToString());
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "textBoxGlediator", textBoxGlediator.Text);
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "trackBarGlediator", trackBarGlediator.Value.ToString());
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "TwilioSID", GlobalVar.TwilioSID);
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "TwilioToken", GlobalVar.TwilioToken);
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxEmail", checkBoxEmail.Checked.ToString());
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxLocal", checkBoxLocal.Checked.ToString());
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxTwilio", checkBoxTwilio.Checked.ToString());
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "TwilioPhoneNumber", GlobalVar.TwilioPhoneNumber);
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "dateCountDownString", dateCountDown.Value.ToString());
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxMultiLine", checkBoxMultiLine.Checked.ToString());
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "numericUpDownMultiLine", numericUpDownMultiLine.Value.ToString());
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "numericUpDownMaxWords", numericUpDownMaxWords.Value.ToString());
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxCountDownEnable", checkBoxCountDownEnable.Checked.ToString());
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "comboBoxCountDownDirection", comboBoxCountDownDirection.Text);
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "trackBarCountDownPosition", trackBarCountDownPosition.Value.ToString());
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "textBoxLine1", textBoxLine1.Text);
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "textBoxLine2", textBoxLine2.Text);
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "textBoxLine3", textBoxLine3.Text);
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "textBoxLine4", textBoxLine4.Text);
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxVixenControl", checkBoxVixenControl.Checked.ToString());
        }
#endregion

#region Misc Area

        #region TrackBar ToolTip displays value
        private void trackBarSpeedSnowFlakes_Scroll(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(trackBarSpeedSnowFlakes, trackBarSpeedSnowFlakes.Value.ToString());
        }

        private void trackBarSpeedSnowFlakes_MouseDown(object sender, MouseEventArgs e)
        {
            toolTip1.SetToolTip(trackBarSpeedSnowFlakes, trackBarSpeedSnowFlakes.Value.ToString());
        }

        private void trackBarSpeedSnowFlakes_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(trackBarSpeedSnowFlakes, trackBarSpeedSnowFlakes.Value.ToString());
        }

        private void trackBarSpeedMeteors_Scroll(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(trackBarSpeedMeteors, trackBarSpeedMeteors.Value.ToString());
        }

        private void trackBarSpeedMeteors_MouseDown(object sender, MouseEventArgs e)
        {
            toolTip1.SetToolTip(trackBarSpeedMeteors, trackBarSpeedMeteors.Value.ToString());
        }

        private void trackBarSpeedMeteors_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(trackBarSpeedMeteors, trackBarSpeedMeteors.Value.ToString());
        }

        private void trackBarTwinkleLights_Scroll(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(trackBarTwinkleLights, trackBarTwinkleLights.Value.ToString());
        }

        private void trackBarTwinkleLights_MouseDown(object sender, MouseEventArgs e)
        {
            toolTip1.SetToolTip(trackBarTwinkleLights, trackBarTwinkleLights.Value.ToString());
        }

        private void trackBarTwinkleLights_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(trackBarTwinkleLights, trackBarTwinkleLights.Value.ToString());
        }

        private void trackBarTwinkleSteps_Scroll(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(trackBarTwinkleSteps, trackBarTwinkleSteps.Value.ToString());
        }

        private void trackBarTwinkleSteps_MouseDown(object sender, MouseEventArgs e)
        {
            toolTip1.SetToolTip(trackBarTwinkleSteps, trackBarTwinkleSteps.Value.ToString());
        }

        private void trackBarTwinkleSteps_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(trackBarTwinkleSteps, trackBarTwinkleSteps.Value.ToString());
        }

        private void trackBarSpeedTwinkles_Scroll(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(trackBarSpeedTwinkles, trackBarSpeedTwinkles.Value.ToString());
        }

        private void trackBarSpeedTwinkles_MouseDown(object sender, MouseEventArgs e)
        {
            toolTip1.SetToolTip(trackBarSpeedTwinkles, trackBarSpeedTwinkles.Value.ToString());
        }

        private void trackBarSpeedTwinkles_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(trackBarSpeedTwinkles, trackBarSpeedTwinkles.Value.ToString());
        }

        private void trackBarTextPosition_Scroll(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(trackBarTextPosition, trackBarTextPosition.Value.ToString());
        }

        private void trackBarTextPosition_MouseDown(object sender, MouseEventArgs e)
        {
            toolTip1.SetToolTip(trackBarTextPosition, trackBarTextPosition.Value.ToString());
        }

        private void trackBarTextPosition_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(trackBarTextPosition, trackBarTextPosition.Value.ToString());
        }

        private void trackBarTextSpeed_Scroll(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(trackBarTextSpeed, trackBarTextSpeed.Value.ToString());
        }

        private void trackBarTextSpeed_MouseDown(object sender, MouseEventArgs e)
        {
            toolTip1.SetToolTip(trackBarTextSpeed, trackBarTextSpeed.Value.ToString());
        }

        private void trackBarTextSpeed_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(trackBarTextSpeed, trackBarTextSpeed.Value.ToString());
        }
        private void trackBarThumbnail_Scroll(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(trackBarThumbnail, trackBarThumbnail.Value.ToString());
            pictureBoxMovie.ImageLocation = GlobalVar.MovieFolder + "\\" + (trackBarThumbnail.Value.ToString("D10")) + ".png";
        }

        private void trackBarThumbnail_MouseDown(object sender, MouseEventArgs e)
        {
            toolTip1.SetToolTip(trackBarThumbnail, trackBarThumbnail.Value.ToString());
        }

        private void trackBarThumbnail_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(trackBarThumbnail, trackBarThumbnail.Value.ToString());
        }

        private void trackBarMovieSpeed_Scroll(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(trackBarMovieSpeed, trackBarMovieSpeed.Value.ToString());
        }

        private void trackBarMovieSpeed_MouseDown(object sender, MouseEventArgs e)
        {
            toolTip1.SetToolTip(trackBarMovieSpeed, trackBarMovieSpeed.Value.ToString());
        }

        private void trackBarMovieSpeed_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(trackBarMovieSpeed, trackBarMovieSpeed.Value.ToString());
        }

        private void trackBarGlediator_Scroll(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(trackBarGlediator, trackBarGlediator.Value.ToString());
        }

        private void trackBarGlediator_MouseDown(object sender, MouseEventArgs e)
        {
            toolTip1.SetToolTip(trackBarGlediator, trackBarGlediator.Value.ToString());
        }

        private void trackBarGlediator_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(trackBarGlediator, trackBarGlediator.Value.ToString());
        }
        private void trackBarCountDownPosition_Scroll(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(trackBarCountDownPosition, trackBarCountDownPosition.Value.ToString());
        }

        private void trackBarCountDownPosition_MouseDown(object sender, MouseEventArgs e)
        {
            toolTip1.SetToolTip(trackBarCountDownPosition, trackBarCountDownPosition.Value.ToString());
        }

        private void trackBarCountDownPosition_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(trackBarCountDownPosition, trackBarCountDownPosition.Value.ToString());
        }
        #endregion

        #region Email Settings
        private void comboBoxEmailSettings_SelectedIndexChanged(object sender, EventArgs e)
        {
            EmailSettings();
        }

        private void EmailSettings()
        {
        switch (comboBoxEmailSettings.Text)
            {
                case "Manual":
                    textBoxComments.Text = @"Ensure you use an email client that supports POP (port 995) and TLS (587). You may need to change your email settings to enable POP, also create a filter to ensure all messages are sent to the inbox and are not directed to the Spam folder. Outlook.com and Hotmail are not supported due to Microsoft limiting the number of retrievals per 15min.";
                    break;
                case "GMail":
                    textBoxServer.Text = @"pop.gmail.com";
                    textBoxSMTP.Text = @"smtp.gmail.com";
                    textBoxComments.Text = @"You will need to reduce the security settings in Gmail to allow 'access for less secure apps'. This can be done in your account settings. Also create a filter to ensure emails do not get sent to the spam folder.";
                    break;
                case "Yahoo.com":
                    textBoxServer.Text = @"pop.mail.yahoo.com";
                    textBoxSMTP.Text = @"smtp.mail.yahoo.com";
                    textBoxComments.Text = @"No email settings were required to be changed, however a filter to ensure all emails are sent to the inbox wouldn't hurt.";
                    break;
                case "Yahoo.com.au":
                    textBoxServer.Text = @"pop.mail.yahoo.com.au";
                    textBoxSMTP.Text = @"smtp.mail.yahoo.com.au";
                    textBoxComments.Text = @"No email settings were required to be changed, however a filter to ensure all emails are sent to the inbox wouldn't hurt."; 
                    break;
                case "Zoho":
                    textBoxServer.Text = @"pop.zoho.com";
                    textBoxSMTP.Text = @"smtp.zoho.com";
                    textBoxComments.Text = @"Ensure you enable POP in your Zoho mail settings and select Delete Emails from server on a Delete command. Create a filter to ensure emails do not get sent to the spam folder.";
                    break;
                case "Yandex":
                    textBoxServer.Text = @"pop.yandex.com";
                    textBoxSMTP.Text = @"smtp.yandex.com";
                    textBoxComments.Text = @"Ensure you enable POP in your Yandex mail settings and add a filter to ensure emails are not sent to the Spam folder.";
                    break;
            }
            if (comboBoxEmailSettings.Text == "Manual")
            {
                textBoxServer.Enabled = true;
                textBoxSMTP.Enabled = true;
            }
            else
            {
                textBoxServer.Enabled = false;
                textBoxSMTP.Enabled = false;
            }
        }
        #endregion        

        #region Timer to Check Vixen
        private void timerCheckVixenEnabled_Tick(object sender, EventArgs e)
        {
            if (checkBoxVixenControl.Checked)
            {
                if (File.Exists(textBoxSequenceTemplate.Text + "\\MessagingEnabled.txt"))
                {
                    if (buttonStart.Enabled)
                    {
                        Start_Vixen();
                    }
                }
                else
                {
                    Stop_Vixen();
                    StopSequence(); 
                }
            }
        }
        
        private void checkBoxVixenControl_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxVixenControl.Checked)
            {
                timerCheckVixenEnabled.Enabled = true;
            }
            else
            {
                timerCheckVixenEnabled.Enabled = false;
            } 
        }
        #endregion

        #region Other
        private void checkBoxWhitelist_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxBlacklist.Checked = !checkBoxWhitelist.Checked;
        }
        private void checkBoxBlacklist_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxWhitelist.Checked = !checkBoxBlacklist.Checked;
        }

        private void checkBoxEnableSqnctrl_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxEffects.Visible = !groupBoxEffects.Visible;
            groupBoxSeqControl.Visible = !groupBoxSeqControl.Visible;
			if (timerCheckMail.Enabled)
			{
				Stop_Vixen();
				if (checkBoxEnableSqnctrl.Checked)
				{
					SelectSeqTime();
				}
				else
				{
					GlobalVar.SeqIntervalTime = EffectTime.Value + 5;
				}
				buttonStart.Image = Tools.GetIcon(Resources.StartB_W, 40);
				buttonStart.Text = "";
				buttonStop.Image = Tools.GetIcon(Resources.Stop, 40);
				buttonStop.Text = "";
                GlobalVar.Msgindex = 0;
				StartChecking();
			}
			else
			{
				if (checkBoxEnableSqnctrl.Checked)
				{
					SelectSeqTime();
				}
				else
				{
					GlobalVar.SeqIntervalTime = EffectTime.Value + 5;
				}
			}
        }

        private void FontSelection ()
        {
            if (fontDialog1.ShowDialog() != DialogResult.Cancel)
            {
                textBoxFont.Text = string.Format(fontDialog1.Font.Name);
                textBoxFontSize.Text = string.Format(fontDialog1.Font.Size.ToString());
            }
        }

        private void buttonFont_Click(object sender, EventArgs e)
        {
            FontSelection();
        }

        private void pictureBoxSaveBlacklist_Click(object sender, EventArgs e)
        {
            richTextBoxBlacklist.SaveFile(GlobalVar.Blacklistlocation, RichTextBoxStreamType.PlainText);
            richTextBoxBlacklist.SaveFile(GlobalVar.Blacklistlocation + ".bkp", RichTextBoxStreamType.PlainText);
            MessageBox.Show(@"Blacklist saved!");
        }

        private void pictureBoxSaveWhitelist_Click(object sender, EventArgs e)
        {
            richTextBoxWhitelist.SaveFile(GlobalVar.Whitelistlocation, RichTextBoxStreamType.PlainText);
            richTextBoxWhitelist.SaveFile(GlobalVar.Whitelistlocation + ".bkp", RichTextBoxStreamType.PlainText);
            MessageBox.Show(@"Whitelist saved!");
        }
        private void buttonSaveMessageList_Click(object sender, EventArgs e)
        {
            richTextBoxMessage.SaveFile(GlobalVar.LocalMessages, RichTextBoxStreamType.PlainText);
            richTextBoxMessage.SaveFile(GlobalVar.LocalMessages + ".bkp", RichTextBoxStreamType.PlainText);
            MessageBox.Show(@"Messages saved!");
        }

        private void tabControlSequence_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            SelectSeqTime();
        }

        private void checkBoxDisableSeq_CheckedChanged(object sender, EventArgs e)
        {
            DisableSeq();
        }

        private void DisableSeq()
        {
            tabControlEffects.Enabled = !tabControlEffects.Enabled;
            tabControlSequence.Enabled = !tabControlSequence.Enabled;
            checkBoxEnableSqnctrl.Enabled = !checkBoxEnableSqnctrl.Enabled;
            checkBoxRandomSeqSelection.Enabled = !checkBoxRandomSeqSelection.Enabled;
            checkBoxEnableSqnctrl.Checked = false;
        }

		private void EffectTime_ValueChanged(object sender, EventArgs e)
		{
			GlobalVar.SeqIntervalTime = EffectTime.Value + 5;
		}

        private void checkBoxVariableLength_CheckedChanged(object sender, EventArgs e)
        {
            EffectTime.Enabled = !EffectTime.Enabled;
            extraTime.Enabled = !extraTime.Enabled;
            GlobalVar.SeqIntervalTime = EffectTime.Value + 5;
        }

        private void buttonSaveLog_Click(object sender, EventArgs e)
        {
            if (richTextBoxLog.Text != "")
            {
                string[] sfd = richTextBoxLog.Text.Split('\n');
                File.WriteAllLines(textBoxSequenceTemplate.Text + "\\Log.txt", sfd);
                MessageBox.Show(@"Log.txt has been saved in " + textBoxSequenceTemplate.Text);
            }
            else
            {
                MessageBox.Show(@"Log is empty and will not be saved");
            }
        }
        #endregion

        private void buttonTwilio_Click(object sender, EventArgs e)
        {
            var twilio = new Twilio();
            twilio.ShowDialog();
        }

        private void comboBoxPlayMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxPlayMode.Text == "Sequential")
            {
                GlobalVar.Sequential = 1;
            }
        }

        private void textBoxAccessPWD_TextChanged(object sender, EventArgs e)
        {
            if (textBoxAccessPWD.Text == "")
            {
                MessageBox.Show(@"Must contain a Remote Access Keyword");
                textBoxAccessPWD.Text = @"Your Keyword";
            }
        }

        private void checkBoxLocalRandom_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBoxLocalRandom.Checked)
            {
                GlobalVar.Msgindex = 0;
            }
        }

        private void checkBoxMultiLine_CheckedChanged(object sender, EventArgs e)
        {
            TextLineNumber.Enabled = !TextLineNumber.Enabled;
            numericUpDownMultiLine.Enabled = !numericUpDownMultiLine.Enabled;
        }

        private void checkBoxCountDownEnable_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxCountDown.Enabled = !groupBoxCountDown.Enabled;
        }

        
 
    }
}
#endregion