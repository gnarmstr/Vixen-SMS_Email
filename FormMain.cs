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
using Microsoft.VisualBasic;

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
            GlobalVar.CustomMessageCount = 0;
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

			ColourVisible();

            //Changes Position and Size of Groupboxs in the Sequence Tab
            groupBoxSeqControl.Location = new Point(6, 35);
            tabControlSequence.Size = new Size(555, 185);
            groupBoxSeqControl.Size = new Size(560, 210);
            label26.Location = new Point(60, 255);
			groupBoxLog.Location = new Point(4, 280);
			groupBoxLog.Size = new Size(585, 290);
            richTextBoxLog2.Location = new Point(6, 20);
            richTextBoxLog2.Size = new Size(575, 265);
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
            buttonAddMessage.Image = Tools.GetIcon(Resources.add, 16);
            buttonAddMessage.Text = "";
            buttonRemoveMessage.Image = Tools.GetIcon(Resources.delete, 16);
            buttonAddMessage.Text = "";
            buttonPlay.Image = Tools.GetIcon(Resources.Play, 16);
            buttonPlay.Text = "";
			SaveAll.Image = Tools.ResizeImage(Resources.Save, 130, 30);
			buttonAddNodeID.Image = Tools.GetIcon(Resources.add, 16);
			buttonAddNodeID.Text = "";
			buttonRemoveNodeID.Image = Tools.GetIcon(Resources.delete, 16);
			buttonRemoveNodeID.Text = "";
			buttonPlaySnowFlake.Image = Tools.GetIcon(Resources.Play, 16);
            buttonPlaySnowFlake.Text = "";
			buttonAddSnowFlake.Image = Tools.GetIcon(Resources.add, 16);
			buttonAddSnowFlake.Text = "";
			buttonRemoveSnowFlake.Image = Tools.GetIcon(Resources.delete, 16);
			buttonRemoveSnowFlake.Text = "";
			buttonPlayMeteor.Image = Tools.GetIcon(Resources.Play, 16);
			buttonPlayMeteor.Text = "";
			buttonAddMeteor.Image = Tools.GetIcon(Resources.add, 16);
			buttonAddMeteor.Text = "";
			buttonRemoveMeteor.Image = Tools.GetIcon(Resources.delete, 16);
			buttonRemoveMeteor.Text = "";
			buttonPlayTwinkle.Image = Tools.GetIcon(Resources.Play, 16);
			buttonPlayTwinkle.Text = "";
			buttonAddTwinkle.Image = Tools.GetIcon(Resources.add, 16);
			buttonAddTwinkle.Text = "";
			buttonRemoveTwinkle.Image = Tools.GetIcon(Resources.delete, 16);
			buttonRemoveTwinkle.Text = "";
			buttonPlayFire.Image = Tools.GetIcon(Resources.Play, 16);
			buttonPlayFire.Text = "";
			buttonPlayMovie.Image = Tools.GetIcon(Resources.Play, 16);
			buttonPlayMovie.Text = "";
			buttonPlayGled.Image = Tools.GetIcon(Resources.Play, 16);
			buttonPlayGled.Text = "";
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

		#region General Settings
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
            comboBoxString.Text = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "StringOrienation", "Horizontal");
            textBoxLogFileName.Text = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "LogMessageFile", Path.Combine(Environment.ExpandEnvironmentVariables("%userprofile%"), "Documents\\Vixen 3 Messaging\\Logs\\Message.log"));
            textBoxBlacklistEmailLog.Text = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "LogBlacklistFile", Path.Combine(Environment.ExpandEnvironmentVariables("%userprofile%"), "Documents\\Vixen 3 Messaging\\Logs\\Blacklist.log"));
            textBoxSubjectHeader.Text = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "SMSSubjectHeader", "SMS from");
            checkBoxEnableSqnctrl.Checked = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxSqnEnable", false);
            checkBoxAutoStart.Checked = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxAutoStart", false);
            checkBoxBlacklist.Checked = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxBlack_list", true);
            checkBoxDisableSeq.Checked = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxDisableSeq", false);
			incomingMessageColourOption.Text = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "incomingMessageColourOption", "Random");
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
			tabControlMain.SelectedIndex = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "tabControlMain", 0);
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
			var dateCountDownString = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "dateCountDownString", "25/12/15");
            dateCountDown.Value = Convert.ToDateTime(dateCountDownString);
            checkBoxVixenControl.Checked = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxVixenControl", false);
			messageColourOption.Text = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "messageColourOption", "Single");
		#endregion

		#region Group ID Settings
			var groupIDNumberSel = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "GroupIDNumberSel", 0);
			GlobalVar.GroupIDNumber = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "GroupIDNumber", 0);
			var i = 0;
			var line = "GroupNameID";
			if (GlobalVar.GroupIDNumber > 0)
			{
				do
				{
					comboBoxNodeID.Items.Add(profile.GetSetting(XmlProfileSettings.SettingType.Message, line + i, ""));
					GlobalVar.GroupNameID.Add(profile.GetSetting(XmlProfileSettings.SettingType.Message, line + i, ""));
					customMessageNodeSel.Items.Add(profile.GetSetting(XmlProfileSettings.SettingType.Message, line + i, ""));
					line = "GroupNodeID";
					GlobalVar.GroupNodeID.Add(profile.GetSetting(XmlProfileSettings.SettingType.Message, line + i, ""));
					line = "GroupNameID";
					i++;
				} while (i < GlobalVar.GroupIDNumber);
				comboBoxNodeID.SelectedIndex = groupIDNumberSel;
			}
#endregion

		#region Custom Message Settings
			GlobalVar.MessageNumber = profile.GetSetting(XmlProfileSettings.SettingType.Message, "MessageNumber", 0);
			comboBoxName.Items.Clear();
            i = 0;
            line = "ListLine1-";
            if (GlobalVar.MessageNumber > 0)
            {
                do
                {
					GlobalVar.ListLine1.Add(profile.GetSetting(XmlProfileSettings.SettingType.Message, line + i, ""));
                    line = "ListLine2-";
					GlobalVar.ListLine2.Add(profile.GetSetting(XmlProfileSettings.SettingType.Message, line + i, ""));
                    line = "ListLine3-";
					GlobalVar.ListLine3.Add(profile.GetSetting(XmlProfileSettings.SettingType.Message, line + i, ""));
                    line = "ListLine4-";
					GlobalVar.ListLine4.Add(profile.GetSetting(XmlProfileSettings.SettingType.Message, line + i, ""));
					line = "Line1Colour";
					GlobalVar.Line1Colour.Add(profile.GetSetting(XmlProfileSettings.SettingType.Message, line + i, -16776961));
					line = "Line2Colour";
					GlobalVar.Line2Colour.Add(profile.GetSetting(XmlProfileSettings.SettingType.Message, line + i, -65536));
					line = "Line3Colour";
					GlobalVar.Line3Colour.Add(profile.GetSetting(XmlProfileSettings.SettingType.Message, line + i, -16711936));
					line = "Line4Colour";
					GlobalVar.Line4Colour.Add(profile.GetSetting(XmlProfileSettings.SettingType.Message, line + i, -32640));
					line = "MessageDirection";
					GlobalVar.CountDirection.Add(profile.GetSetting(XmlProfileSettings.SettingType.Message, line + i, ""));
                    line = "MessagePosition";
					GlobalVar.Position.Add(profile.GetSetting(XmlProfileSettings.SettingType.Message, line + i, 65));
                    line = "MessageEnabled";
					GlobalVar.MessageEnabled.Add(profile.GetSetting(XmlProfileSettings.SettingType.Message, line + i, false));
                    line = "CustomFont";
					GlobalVar.CustomFont.Add(profile.GetSetting(XmlProfileSettings.SettingType.Message, line + i, "Arial Narrow"));
                    line = "CustomFontSize";
					GlobalVar.CustomFontSize.Add(profile.GetSetting(XmlProfileSettings.SettingType.Message, line + i, "10"));
					line = "MessageColourOption";
					GlobalVar.MessageColourOption.Add(profile.GetSetting(XmlProfileSettings.SettingType.Message, line + i, "Multi"));
					line = "MessageSeqSel";
					GlobalVar.CustomMessageSeqSel.Add(profile.GetSetting(XmlProfileSettings.SettingType.Message, line + i, "Automatically Assigned"));
					line = "MessageNodeSel";
					GlobalVar.CustomMessageNodeSel.Add(profile.GetSetting(XmlProfileSettings.SettingType.Message, line + i, ""));
					line = "MessageName";
					comboBoxName.Items.Add(profile.GetSetting(XmlProfileSettings.SettingType.Message, line + i, ""));
					line = "CenterStop";
					GlobalVar.CheckBoxCentreStop.Add(profile.GetSetting(XmlProfileSettings.SettingType.Message, line + i, false));
					line = "CustomSpeed";
					GlobalVar.TrackBarCustomSpeed.Add(profile.GetSetting(XmlProfileSettings.SettingType.Message, line + i, 5));
                    line = "CustomMsgLength";
					GlobalVar.CustomMsgLength.Add(profile.GetSetting(XmlProfileSettings.SettingType.Message, line + i, 10));
                    line = "ListLine1-";
                    i++;
                } while (i < GlobalVar.MessageNumber);
                comboBoxName.SelectedIndex = 1;
			}
			#endregion

		#region SnowFlake Settings

			GlobalVar.SnowFlakeNumber = profile.GetSetting(XmlProfileSettings.SettingType.SnowFlakes, "SnowFlakeNumber", 0);
			comboBoxSnowFlakeName.Items.Clear();
            i = 0;
			line = "SnowFlakeName";
			if (GlobalVar.SnowFlakeNumber > 0)
	        {
		        do
		        {
					customMessageSeqSel.Items.Add(profile.GetSetting(XmlProfileSettings.SettingType.SnowFlakes, line + i, ""));
					comboBoxSnowFlakeName.Items.Add(profile.GetSetting(XmlProfileSettings.SettingType.SnowFlakes, line + i, "")); 
					line = "SnowFlakeEffectType";
					GlobalVar.SnowFlakeEffectType.Add(profile.GetSetting(XmlProfileSettings.SettingType.SnowFlakes, line + i, 2));
					line = "SnowFlakeMax";
					GlobalVar.SnowFlakeMax.Add(profile.GetSetting(XmlProfileSettings.SettingType.SnowFlakes, line + i, 3));
					line = "SnowFlakeSpeed";
					GlobalVar.SnowFlakeSpeed.Add(profile.GetSetting(XmlProfileSettings.SettingType.SnowFlakes, line + i, 5));
					line = "SnowFlakeRandomEnable";
					GlobalVar.SnowFlakeRandomEnable.Add(profile.GetSetting(XmlProfileSettings.SettingType.SnowFlakes, line + i, true));
					line = "SnowFlakeColourEnable1";
					GlobalVar.SnowFlakeColourEnable1.Add(profile.GetSetting(XmlProfileSettings.SettingType.SnowFlakes, line + i, true));
					line = "SnowFlakeColourEnable2";
					GlobalVar.SnowFlakeColourEnable2.Add(profile.GetSetting(XmlProfileSettings.SettingType.SnowFlakes, line + i, false));
					line = "SnowFlakeColourEnable3";
					GlobalVar.SnowFlakeColourEnable3.Add(profile.GetSetting(XmlProfileSettings.SettingType.SnowFlakes, line + i, false));
					line = "SnowFlakeColourEnable4";
					GlobalVar.SnowFlakeColourEnable4.Add(profile.GetSetting(XmlProfileSettings.SettingType.SnowFlakes, line + i, false));
					line = "SnowFlakeColourEnable5";
					GlobalVar.SnowFlakeColourEnable5.Add(profile.GetSetting(XmlProfileSettings.SettingType.SnowFlakes, line + i, false));
					line = "SnowFlakeColourEnable6";
					GlobalVar.SnowFlakeColourEnable6.Add(profile.GetSetting(XmlProfileSettings.SettingType.SnowFlakes, line + i, false));
					line = "SnowFlakeColour1";
					GlobalVar.SnowFlakeColour1.Add(profile.GetSetting(XmlProfileSettings.SettingType.SnowFlakes, line + i, -16776961));
					profile.PutSetting(XmlProfileSettings.SettingType.SnowFlakes, line + i, GlobalVar.SnowFlakeColour1[i]);
					line = "SnowFlakeColour2";
					GlobalVar.SnowFlakeColour2.Add(profile.GetSetting(XmlProfileSettings.SettingType.SnowFlakes, line + i, -65536));
					profile.PutSetting(XmlProfileSettings.SettingType.SnowFlakes, line + i, GlobalVar.SnowFlakeColour2[i]);
					line = "SnowFlakeColour3";
					GlobalVar.SnowFlakeColour3.Add(profile.GetSetting(XmlProfileSettings.SettingType.SnowFlakes, line + i, -16711936));
					profile.PutSetting(XmlProfileSettings.SettingType.SnowFlakes, line + i, GlobalVar.SnowFlakeColour3[i]);
					line = "SnowFlakeColour4";
					GlobalVar.SnowFlakeColour4.Add(profile.GetSetting(XmlProfileSettings.SettingType.SnowFlakes, line + i, -32640));
					profile.PutSetting(XmlProfileSettings.SettingType.SnowFlakes, line + i, GlobalVar.SnowFlakeColour4[i]);
					line = "SnowFlakeColour5";
					GlobalVar.SnowFlakeColour5.Add(profile.GetSetting(XmlProfileSettings.SettingType.SnowFlakes, line + i, -16776961));
					profile.PutSetting(XmlProfileSettings.SettingType.SnowFlakes, line + i, GlobalVar.SnowFlakeColour5[i]);
					line = "SnowFlakeColour6";
					GlobalVar.SnowFlakeColour6.Add(profile.GetSetting(XmlProfileSettings.SettingType.SnowFlakes, line + i, -65536));
					line = "SnowFlakeName";
			        i++;
				} while (i < GlobalVar.SnowFlakeNumber);
				comboBoxSnowFlakeName.SelectedIndex = 0;
			}
			#endregion

		#region Meteor Settings

			GlobalVar.MeteorNumber = profile.GetSetting(XmlProfileSettings.SettingType.Meteor, "MeteorNumber", 0);
			comboBoxMeteorName.Items.Clear();
			i = 0;
			line = "MeteorName";
			if (GlobalVar.MeteorNumber > 0)
			{
				do
				{
					customMessageSeqSel.Items.Add(profile.GetSetting(XmlProfileSettings.SettingType.Meteor, line + i, ""));
					comboBoxMeteorName.Items.Add(profile.GetSetting(XmlProfileSettings.SettingType.Meteor, line + i, ""));
					line = "MeteorColourType";
					GlobalVar.MeteorColourType.Add(profile.GetSetting(XmlProfileSettings.SettingType.Meteor, line + i, "Range"));
					line = "MeteorCount";
					GlobalVar.MeteorCount.Add(profile.GetSetting(XmlProfileSettings.SettingType.Meteor, line + i, 11));
					line = "MeteorTrailLength";
					GlobalVar.MeteorTrailLength.Add(profile.GetSetting(XmlProfileSettings.SettingType.Meteor, line + i, 12));
					line = "MeteorSpeed";
					GlobalVar.MeteorSpeed.Add(profile.GetSetting(XmlProfileSettings.SettingType.Meteor, line + i, 5));
					line = "MeteorRandomEnable";
					GlobalVar.MeteorRandomEnable.Add(profile.GetSetting(XmlProfileSettings.SettingType.Meteor, line + i, true));
					line = "MeteorColourEnable1";
					GlobalVar.MeteorColourEnable1.Add(profile.GetSetting(XmlProfileSettings.SettingType.Meteor, line + i, true));
					line = "MeteorColourEnable2";
					GlobalVar.MeteorColourEnable2.Add(profile.GetSetting(XmlProfileSettings.SettingType.Meteor, line + i, false));
					line = "MeteorColourEnable3";
					GlobalVar.MeteorColourEnable3.Add(profile.GetSetting(XmlProfileSettings.SettingType.Meteor, line + i, false));
					line = "MeteorColourEnable4";
					GlobalVar.MeteorColourEnable4.Add(profile.GetSetting(XmlProfileSettings.SettingType.Meteor, line + i, false));
					line = "MeteorColourEnable5";
					GlobalVar.MeteorColourEnable5.Add(profile.GetSetting(XmlProfileSettings.SettingType.Meteor, line + i, false));
					line = "MeteorColourEnable6";
					GlobalVar.MeteorColourEnable6.Add(profile.GetSetting(XmlProfileSettings.SettingType.Meteor, line + i, false));
					line = "MeteorColour1";
					GlobalVar.MeteorColour1.Add(profile.GetSetting(XmlProfileSettings.SettingType.Meteor, line + i, -16776961));
					profile.PutSetting(XmlProfileSettings.SettingType.Meteor, line + i, GlobalVar.MeteorColour1[i]);
					line = "MeteorColour2";
					GlobalVar.MeteorColour2.Add(profile.GetSetting(XmlProfileSettings.SettingType.Meteor, line + i, -65536));
					profile.PutSetting(XmlProfileSettings.SettingType.Meteor, line + i, GlobalVar.MeteorColour2[i]);
					line = "MeteorColour3";
					GlobalVar.MeteorColour3.Add(profile.GetSetting(XmlProfileSettings.SettingType.Meteor, line + i, -16711936));
					profile.PutSetting(XmlProfileSettings.SettingType.Meteor, line + i, GlobalVar.MeteorColour3[i]);
					line = "MeteorColour4";
					GlobalVar.MeteorColour4.Add(profile.GetSetting(XmlProfileSettings.SettingType.Meteor, line + i, -32640));
					profile.PutSetting(XmlProfileSettings.SettingType.Meteor, line + i, GlobalVar.MeteorColour4[i]);
					line = "MeteorColour5";
					GlobalVar.MeteorColour5.Add(profile.GetSetting(XmlProfileSettings.SettingType.Meteor, line + i, -16776961));
					profile.PutSetting(XmlProfileSettings.SettingType.Meteor, line + i, GlobalVar.MeteorColour5[i]);
					line = "MeteorColour6";
					GlobalVar.MeteorColour6.Add(profile.GetSetting(XmlProfileSettings.SettingType.Meteor, line + i, -65536));
					line = "MeteorName";
					i++;
				} while (i < GlobalVar.MeteorNumber);
				comboBoxMeteorName.SelectedIndex = 0;
			}
			#endregion

		#region Twinkle Settings

			GlobalVar.TwinkleNumber = profile.GetSetting(XmlProfileSettings.SettingType.Twinkle, "TwinkleNumber", 0);
			comboBoxTwinkleName.Items.Clear();
			i = 0;
			line = "TwinkleName";
			if (GlobalVar.TwinkleNumber > 0)
			{
				do
				{
					customMessageSeqSel.Items.Add(profile.GetSetting(XmlProfileSettings.SettingType.Twinkle, line + i, ""));
					comboBoxTwinkleName.Items.Add(profile.GetSetting(XmlProfileSettings.SettingType.Twinkle, line + i, ""));
					line = "TwinkleLights";
					GlobalVar.TwinkleLights.Add(profile.GetSetting(XmlProfileSettings.SettingType.Twinkle, line + i, 25));
					line = "TwinkleSteps";
					GlobalVar.TwinkleSteps.Add(profile.GetSetting(XmlProfileSettings.SettingType.Twinkle, line + i, 20));
					line = "TwinkleSpeed";
					GlobalVar.TwinkleSpeed.Add(profile.GetSetting(XmlProfileSettings.SettingType.Twinkle, line + i, 1));
					line = "TwinkleRandomEnable";
					GlobalVar.TwinkleRandomEnable.Add(profile.GetSetting(XmlProfileSettings.SettingType.Twinkle, line + i, true));
					line = "TwinkleColourEnable1";
					GlobalVar.TwinkleColourEnable1.Add(profile.GetSetting(XmlProfileSettings.SettingType.Twinkle, line + i, true));
					line = "TwinkleColourEnable2";
					GlobalVar.TwinkleColourEnable2.Add(profile.GetSetting(XmlProfileSettings.SettingType.Twinkle, line + i, false));
					line = "TwinkleColourEnable3";
					GlobalVar.TwinkleColourEnable3.Add(profile.GetSetting(XmlProfileSettings.SettingType.Twinkle, line + i, false));
					line = "TwinkleColourEnable4";
					GlobalVar.TwinkleColourEnable4.Add(profile.GetSetting(XmlProfileSettings.SettingType.Twinkle, line + i, false));
					line = "TwinkleColourEnable5";
					GlobalVar.TwinkleColourEnable5.Add(profile.GetSetting(XmlProfileSettings.SettingType.Twinkle, line + i, false));
					line = "TwinkleColourEnable6";
					GlobalVar.TwinkleColourEnable6.Add(profile.GetSetting(XmlProfileSettings.SettingType.Twinkle, line + i, false));
					line = "TwinkleColour1";
					GlobalVar.TwinkleColour1.Add(profile.GetSetting(XmlProfileSettings.SettingType.Twinkle, line + i, -16776961));
					profile.PutSetting(XmlProfileSettings.SettingType.Twinkle, line + i, GlobalVar.TwinkleColour1[i]);
					line = "TwinkleColour2";
					GlobalVar.TwinkleColour2.Add(profile.GetSetting(XmlProfileSettings.SettingType.Twinkle, line + i, -65536));
					profile.PutSetting(XmlProfileSettings.SettingType.Twinkle, line + i, GlobalVar.TwinkleColour2[i]);
					line = "TwinkleColour3";
					GlobalVar.TwinkleColour3.Add(profile.GetSetting(XmlProfileSettings.SettingType.Twinkle, line + i, -16711936));
					profile.PutSetting(XmlProfileSettings.SettingType.Twinkle, line + i, GlobalVar.TwinkleColour3[i]);
					line = "TwinkleColour4";
					GlobalVar.TwinkleColour4.Add(profile.GetSetting(XmlProfileSettings.SettingType.Twinkle, line + i, -32640));
					profile.PutSetting(XmlProfileSettings.SettingType.Twinkle, line + i, GlobalVar.TwinkleColour4[i]);
					line = "TwinkleColour5";
					GlobalVar.TwinkleColour5.Add(profile.GetSetting(XmlProfileSettings.SettingType.Twinkle, line + i, -16776961));
					profile.PutSetting(XmlProfileSettings.SettingType.Twinkle, line + i, GlobalVar.TwinkleColour5[i]);
					line = "TwinkleColour6";
					GlobalVar.TwinkleColour6.Add(profile.GetSetting(XmlProfileSettings.SettingType.Twinkle, line + i, -65536));
					line = "TwinkleName";
					i++;
				} while (i < GlobalVar.TwinkleNumber);
				comboBoxTwinkleName.SelectedIndex = 0;
			}
			#endregion

			comboBoxName.SelectedIndex = 0;
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
                if (checkBoxLocalRandom.Checked) //Play Random
                {

                    var rndLineNumber = new Random();
                    var rndLineNumberResult = rndLineNumber.Next(0, msgcount + comboBoxName.Items.Count);
                    if (rndLineNumberResult >= msgcount | richTextBoxMessage.Text == "")
                    {
                        var i = 0;
                        do
                        {
                            var rndCustomMsg = new Random();
                            var rndCustomMsgResult = rndCustomMsg.Next(0, comboBoxName.Items.Count -1);
                            if (GlobalVar.MessageEnabled[rndCustomMsgResult])
                            {
                                comboBoxName.SelectedIndex = rndCustomMsgResult;
                            }
                        } while (!checkBoxMessageEnabled.Checked & i++ < 200 & checkBoxCountDownEnable.Checked);
                        if (checkBoxMessageEnabled.Checked)
                        {
                            msg = "play counter"; //Play counter is used as its in the Whitelist
                        }
                        else
                        {
                            ShortTimer();
                            return;
                        }
                    }
                    else
                    {
                        msg = phrases[rndLineNumberResult];
                    }
                }
                else //Play Sequential
                {
                    if (GlobalVar.Msgindex < msgcount & richTextBoxMessage.Text != "")
                    {
                        msg = phrases[GlobalVar.Msgindex];
                        GlobalVar.Msgindex++;
                    }
                    else
                    {
                        if (((GlobalVar.Msgindex >= msgcount | richTextBoxMessage.Text == "") & GlobalVar.CustomMessageCount < comboBoxName.Items.Count) & checkBoxCountDownEnable.Checked)
                        {
                            do
                            {
                                comboBoxName.SelectedIndex = GlobalVar.CustomMessageCount;
                                GlobalVar.CustomMessageCount ++;
                            } while (!checkBoxMessageEnabled.Checked & GlobalVar.CustomMessageCount != comboBoxName.Items.Count);
                            if (checkBoxMessageEnabled.Checked)
                            {
                                msg = "play counter"; //Play counter is used as its in the Whitelist
                                GlobalVar.Msgindex++;
                            }
                            else
                            {
                                GlobalVar.Msgindex = 1;
                                ShortTimer();
                                return;
                            }
                        }
                        else
                        {
                            GlobalVar.CustomMessageCount = 0;
                            if (richTextBoxMessage.Text == "")
                            {
                                do
                                {
                                    comboBoxName.SelectedIndex = GlobalVar.CustomMessageCount;
                                    GlobalVar.CustomMessageCount++;
                                } while (!checkBoxMessageEnabled.Checked & GlobalVar.CustomMessageCount != comboBoxName.Items.Count);
                                if (checkBoxMessageEnabled.Checked)
                                {
                                    msg = "play counter"; //Play counter is used as its in the Whitelist
                                    GlobalVar.Msgindex++;
                                }
                                else
                                {
                                    GlobalVar.Msgindex = 1;
                                    ShortTimer();
                                    return;
                                }
                            }
                            else
                            {
                                msg = phrases[0];
                            }
                            GlobalVar.Msgindex = 1;
                        }
                    }
                }
                SendMessageToVixen(msg, out blacklist, out notWhitemsg, out maxWordCount);
            }
        }
        #endregion

    #region Play Custom Message Immediately

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            StopSequence();
			if (!GlobalVar.PlayCustomMessage)
            {
				Stop_Vixen();
                PlayCustomMessage();
                Start_Vixen();
            }
            else
            {
                PlayCustomMessage();
            }
        }

        private void PlayCustomMessage()
        {
            bool blacklist;
            bool notWhitemsg;
            bool maxWordCount;
            string msg = "play counter"; 
            SendMessageToVixen(msg, out blacklist, out notWhitemsg, out maxWordCount);
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
	            incomingMessageColourOption.Text = "Random";
				messageBody = messageBody + "Random Text colour is enabled = " + incomingMessageColourOption.Text + "\n";
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

#region Custom Local Message settings
        private void checkBoxCountDownEnable_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxCountDown.Enabled = !groupBoxCountDown.Enabled;
        }

        private void buttonAddMessage_Click(object sender, EventArgs e)
        {
			var	addCustomMsg = Interaction.InputBox("Enter a Name for your Custom Message", "Custom Message");
			if (addCustomMsg != "")
			{
				GlobalVar.CustomMessageSeqSel.Add("Automatically Assigned");
				GlobalVar.CustomMessageNodeSel.Add(customMessageNodeSel.Items[0].ToString());
				GlobalVar.MessageColourOption.Add("Multi");
				GlobalVar.ListLine1.Add("");
				GlobalVar.ListLine2.Add("");
				GlobalVar.ListLine3.Add("");
				GlobalVar.ListLine4.Add("");
				GlobalVar.Line1Colour.Add(Convert.ToInt32(-16776961));
				GlobalVar.Line2Colour.Add(Convert.ToInt32(-65536));
				GlobalVar.Line3Colour.Add(Convert.ToInt32(-16711936));
				GlobalVar.Line4Colour.Add(Convert.ToInt32(-32640));
				GlobalVar.CountDirection.Add("Left");
				GlobalVar.Position.Add(65);
				GlobalVar.MessageEnabled.Add(true);
				GlobalVar.CustomFont.Add("Arial Narrow");
				GlobalVar.CustomFontSize.Add("10");
				GlobalVar.TrackBarCustomSpeed.Add(5);
				GlobalVar.CheckBoxCentreStop.Add(false);
				GlobalVar.CustomMsgLength.Add(10);
				comboBoxName.Items.Add(addCustomMsg);
                comboBoxName.SelectedIndex = comboBoxName.Items.Count - 1;
            }
        }

        private void comboBoxName_SelectedIndexChanged(object sender, EventArgs e)
        {
            CustomMessage();
        }

        private void CustomMessage()
        {
            var selectedItem = comboBoxName.SelectedIndex;
            textBoxLine1.Text = GlobalVar.ListLine1[selectedItem];
            textBoxLine2.Text = GlobalVar.ListLine2[selectedItem];
            textBoxLine3.Text = GlobalVar.ListLine3[selectedItem];
            textBoxLine4.Text = GlobalVar.ListLine4[selectedItem];
			line1Colour.BackColor = Color.FromArgb(Convert.ToInt32(GlobalVar.Line1Colour[selectedItem]));
			line2Colour.BackColor = Color.FromArgb(Convert.ToInt32(GlobalVar.Line2Colour[selectedItem]));
			line3Colour.BackColor = Color.FromArgb(Convert.ToInt32(GlobalVar.Line3Colour[selectedItem]));
			line4Colour.BackColor = Color.FromArgb(Convert.ToInt32(GlobalVar.Line4Colour[selectedItem]));
            comboBoxCountDownDirection.Text = GlobalVar.CountDirection[selectedItem];
            trackBarCountDownPosition.Value = GlobalVar.Position[selectedItem];
            checkBoxMessageEnabled.Checked = GlobalVar.MessageEnabled[selectedItem];
            textBoxCustomFont.Text = GlobalVar.CustomFont[selectedItem];
            textBoxCustomFontSize.Text = GlobalVar.CustomFontSize[selectedItem];
            trackBarCustomSpeed.Value = GlobalVar.TrackBarCustomSpeed[selectedItem];
            CustomMsgLength.Value = GlobalVar.CustomMsgLength[selectedItem];
			checkBoxCentreStop.Checked = GlobalVar.CheckBoxCentreStop[selectedItem];
			messageColourOption.Text = GlobalVar.MessageColourOption[selectedItem];
			customMessageSeqSel.Text = GlobalVar.CustomMessageSeqSel[selectedItem];
			customMessageNodeSel.Text = GlobalVar.CustomMessageNodeSel[selectedItem];
        }

        private void buttonRemoveMessage_Click(object sender, EventArgs e)
        {
            if (comboBoxName.Items.Count > 0)
            {
                GlobalVar.ListLine1.RemoveAt(comboBoxName.SelectedIndex);
                GlobalVar.ListLine2.RemoveAt(comboBoxName.SelectedIndex);
                GlobalVar.ListLine3.RemoveAt(comboBoxName.SelectedIndex);
                GlobalVar.ListLine4.RemoveAt(comboBoxName.SelectedIndex);
				GlobalVar.Line1Colour.RemoveAt(comboBoxName.SelectedIndex);
				GlobalVar.Line2Colour.RemoveAt(comboBoxName.SelectedIndex);
				GlobalVar.Line3Colour.RemoveAt(comboBoxName.SelectedIndex);
				GlobalVar.Line4Colour.RemoveAt(comboBoxName.SelectedIndex);
                GlobalVar.CountDirection.RemoveAt(comboBoxName.SelectedIndex);
                GlobalVar.Position.RemoveAt(comboBoxName.SelectedIndex);
                GlobalVar.MessageEnabled.RemoveAt(comboBoxName.SelectedIndex);
                GlobalVar.CustomFont.RemoveAt(comboBoxName.SelectedIndex);
                GlobalVar.CustomFontSize.RemoveAt(comboBoxName.SelectedIndex);
                GlobalVar.CustomMsgLength.RemoveAt(comboBoxName.SelectedIndex);
                GlobalVar.TrackBarCustomSpeed.RemoveAt(comboBoxName.SelectedIndex);
				GlobalVar.CheckBoxCentreStop.RemoveAt(comboBoxName.SelectedIndex);
				GlobalVar.MessageColourOption.RemoveAt(comboBoxName.SelectedIndex);
				GlobalVar.CustomMessageSeqSel.RemoveAt(comboBoxName.SelectedIndex);
				GlobalVar.CustomMessageNodeSel.RemoveAt(comboBoxName.SelectedIndex);
                comboBoxName.Items.RemoveAt(comboBoxName.SelectedIndex);
                if (comboBoxName.Items.Count > 0)
                {
                    comboBoxName.SelectedIndex = 0;
                    textBoxLine1.Text = GlobalVar.ListLine1[0];
                    textBoxLine2.Text = GlobalVar.ListLine2[0];
                    textBoxLine3.Text = GlobalVar.ListLine3[0];
                    textBoxLine4.Text = GlobalVar.ListLine4[0];
					line1Colour.BackColor = Color.FromArgb(Convert.ToInt32(GlobalVar.Line1Colour[0]));
					line2Colour.BackColor = Color.FromArgb(Convert.ToInt32(GlobalVar.Line2Colour[0]));
					line3Colour.BackColor = Color.FromArgb(Convert.ToInt32(GlobalVar.Line3Colour[0]));
					line4Colour.BackColor = Color.FromArgb(Convert.ToInt32(GlobalVar.Line4Colour[0]));
                    comboBoxCountDownDirection.Text = GlobalVar.CountDirection[0];
                    trackBarCountDownPosition.Value = GlobalVar.Position[0];
                    checkBoxMessageEnabled.Checked = GlobalVar.MessageEnabled[0];
                    textBoxCustomFont.Text = GlobalVar.CustomFont[0];
                    textBoxCustomFontSize.Text = GlobalVar.CustomFontSize[0];
                    CustomMsgLength.Value = GlobalVar.CustomMsgLength[0];
                    trackBarCustomSpeed.Value = GlobalVar.TrackBarCustomSpeed[0];
	                checkBoxCentreStop.Checked = GlobalVar.CheckBoxCentreStop[0];
					messageColourOption.Text = GlobalVar.MessageColourOption[0];
					customMessageSeqSel.Text = GlobalVar.CustomMessageSeqSel[0];
					customMessageNodeSel.Text = GlobalVar.CustomMessageNodeSel[0];
                }
                else
                {
                    comboBoxName.Items.Clear();
                    textBoxLine1.Text = "";
                    textBoxLine2.Text = "";
                    textBoxLine3.Text = "";
                    textBoxLine4.Text = "";
                    comboBoxCountDownDirection.Text = @"None";
                    trackBarCountDownPosition.Value = 10;
                    checkBoxMessageEnabled.Checked = false;
                    textBoxCustomFont.Text = "";
                    textBoxCustomFontSize.Text = "";
                    CustomMsgLength.Value = 10;
                    trackBarCustomSpeed.Value = 5;
	                checkBoxCentreStop.Checked = false;
					line1Colour.BackColor = Color.FromArgb(-16776961);
					line2Colour.BackColor = Color.FromArgb(-65536);
					line3Colour.BackColor = Color.FromArgb(-16711936);
					line4Colour.BackColor = Color.FromArgb(-32640);
	                messageColourOption.SelectedIndex = 1;
					customMessageSeqSel.SelectedIndex = 1;
					customMessageNodeSel.SelectedIndex = 1;
                }
            }
        }

        private void textBoxLine1_MouseLeave(object sender, EventArgs e)
        {
            CustomMessageUpdate();
        }

        private void textBoxLine2_MouseLeave(object sender, EventArgs e)
        {
            CustomMessageUpdate();
        }

        private void textBoxLine3_MouseLeave(object sender, EventArgs e)
        {
            CustomMessageUpdate();
        }

        private void textBoxLine4_MouseLeave(object sender, EventArgs e)
        {
            CustomMessageUpdate();
        }

        private void checkBoxMessageEnabled_MouseLeave(object sender, EventArgs e)
        {
            CustomMessageUpdate();
        }

        private void trackBarCountDownPosition_MouseLeave(object sender, EventArgs e)
        {
            CustomMessageUpdate();
        }

        private void CustomMessageUpdate()
        {
            if (comboBoxName.Items.Count != 0)
            {
                GlobalVar.ListLine1[comboBoxName.SelectedIndex] = textBoxLine1.Text;
				GlobalVar.ListLine2[comboBoxName.SelectedIndex] = textBoxLine2.Text;
				GlobalVar.ListLine3[comboBoxName.SelectedIndex] = textBoxLine3.Text;
				GlobalVar.ListLine4[comboBoxName.SelectedIndex] = textBoxLine4.Text;
				GlobalVar.Line1Colour[comboBoxName.SelectedIndex] = line1Colour.BackColor.ToArgb();
				GlobalVar.Line2Colour[comboBoxName.SelectedIndex] = line2Colour.BackColor.ToArgb();
				GlobalVar.Line3Colour[comboBoxName.SelectedIndex] = line3Colour.BackColor.ToArgb();
				GlobalVar.Line4Colour[comboBoxName.SelectedIndex] = line4Colour.BackColor.ToArgb();
                GlobalVar.CountDirection[comboBoxName.SelectedIndex] = comboBoxCountDownDirection.Text;
                GlobalVar.Position[comboBoxName.SelectedIndex] = trackBarCountDownPosition.Value;
                GlobalVar.MessageEnabled[comboBoxName.SelectedIndex] = checkBoxMessageEnabled.Checked;
                GlobalVar.CustomFont[comboBoxName.SelectedIndex] = textBoxCustomFont.Text;
                GlobalVar.CustomFontSize[comboBoxName.SelectedIndex] = textBoxCustomFontSize.Text;
                GlobalVar.CustomMsgLength[comboBoxName.SelectedIndex] = CustomMsgLength.Value;
                GlobalVar.TrackBarCustomSpeed[comboBoxName.SelectedIndex] = trackBarCustomSpeed.Value;
				GlobalVar.CheckBoxCentreStop[comboBoxName.SelectedIndex] = checkBoxCentreStop.Checked;
				GlobalVar.MessageColourOption[comboBoxName.SelectedIndex] = messageColourOption.Text;
				GlobalVar.CustomMessageSeqSel[comboBoxName.SelectedIndex] = customMessageSeqSel.Text;
				GlobalVar.CustomMessageNodeSel[comboBoxName.SelectedIndex] = customMessageNodeSel.Text;
			}
        }

        private void checkBoxEmail_CheckedChanged(object sender, EventArgs e)
        {
            textBoxFromEmailAddress.Enabled = !textBoxFromEmailAddress.Enabled;
            textBoxUID.Enabled = !textBoxUID.Enabled;
            textBoxPWD.Enabled = !textBoxPWD.Enabled;
            comboBoxEmailSettings.Enabled = !comboBoxEmailSettings.Enabled;
        }

        private void buttonCustomFont_Click(object sender, EventArgs e)
        {
			fontDialog1.Font = new Font(textBoxCustomFont.Text, (int)Math.Round(double.Parse(textBoxCustomFontSize.Text)));
            if (fontDialog1.ShowDialog() != DialogResult.Cancel)
            {
                textBoxCustomFont.Text = string.Format(fontDialog1.Font.Name);
                textBoxCustomFontSize.Text = string.Format(fontDialog1.Font.Size.ToString());
                CustomMessageUpdate();
            }
        }

        private void textBoxCustomFont_MouseLeave(object sender, EventArgs e)
        {
            CustomMessageUpdate();
        }

        private void textBoxCustomFontSize_MouseLeave(object sender, EventArgs e)
        {
            CustomMessageUpdate();
        }

        private void CustomMsgLength_MouseClick(object sender, MouseEventArgs e)
        {
            CustomMessageUpdate();
        }

        private void CustomMsgLength_MouseDown(object sender, MouseEventArgs e)
        {
            CustomMessageUpdate();
        }
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

                        if (msg != "play counter" & msg != "play sequence")
                        {
                            if (checkBoxVariableLength.Checked)
                            {
                                timerCheckMail.Enabled = false;
                                var msgcount = msg.Length;
                                string selectedSeqTime =
                                    (Convert.ToDecimal(msgcount)*Convert.ToDecimal(0.8)*
                                     (Convert.ToDecimal((double) 5/(double) trackBarTextSpeed.Value))).ToString();
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
                                GlobalVar.SeqIntervalTime = Convert.ToDecimal(EffectTime.Value) + 1;
                            }
                        }
                        else
                        {
                            GlobalVar.SeqIntervalTime = Convert.ToDecimal(CustomMsgLength.Value) + 1;
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
                        fileText = fileText.Replace("PT20S", "PT" + GlobalVar.SeqIntervalTime + "S"); //Sequence time
                        fileText = fileText.Replace("TextTime_Change", GlobalVar.SeqIntervalTime.ToString()); //Text Sequence time
						if (checkBoxRandomSeqSelection.Checked)
	                    {
							int selectedSnowFlake;
		                    var randomSnowFlake = new Random();
							selectedSnowFlake = randomSnowFlake.Next(0, comboBoxSnowFlakeName.Items.Count);
							int selectedMeteor;
							var randomMeteor = new Random();
							selectedMeteor = randomMeteor.Next(0, comboBoxMeteorName.Items.Count);
							int selectedTwinkle;
							var randomTwinkle = new Random();
							selectedTwinkle = randomTwinkle.Next(0, comboBoxTwinkleName.Items.Count);
		                    try
		                    {
								comboBoxSnowFlakeName.SelectedIndex = selectedSnowFlake;
								CustomSnowFlakes();
								comboBoxMeteorName.SelectedIndex = selectedMeteor;
								CustomMeteor();
								comboBoxTwinkleName.SelectedIndex = selectedTwinkle;
								CustomTwinkle();
		                    }
		                    catch
		                    {
		                    }
	                    }
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
                        
                        //Random or selected Selection
	                    string selectedSeq = "";
						if (msg == "play sequence")
						{
							var selectedTab = tabControlEffects.SelectedTab.Text;
							switch (selectedTab)
							{
								case "SnowFlakes":
									selectedSeq = comboBoxSnowFlakeName.Text;
									break;
								case "Meteors":
									selectedSeq = comboBoxMeteorName.Text;
									break;
								case "Twinkles":
									selectedSeq = comboBoxTwinkleName.Text;
									break;
								case "Movie":
									selectedSeq = "Movie";
									break;
								case "Fire":
									selectedSeq = "Fire";
									break;
								case "Glediator/Jinx":
									selectedSeq = "Glediator/Jinx";
									break;
							}
							fileText = fileText.Replace("EffectTime_Change", GlobalVar.SeqIntervalTime.ToString());
						}
						else
						{
							if (msg == "play counter" & customMessageSeqSel.Text != @"Automatically Assigned")
							{
								selectedSeq = customMessageSeqSel.Text;
								if (customMessageSeqSel.Text == "None")
								{
									fileText = fileText.Replace("EffectTime_Change", "0"); //Sequence time
								}
								fileText = fileText.Replace("EffectTime_Change", GlobalVar.SeqIntervalTime.ToString());
							}


							else
							{

								if (checkBoxDisableSeq.Checked)
								{
									selectedSeq = "None";
									fileText = fileText.Replace("EffectTime_Change", "0"); //Sequence time
								}
								else
								{
									fileText = fileText.Replace("EffectTime_Change", GlobalVar.SeqIntervalTime.ToString());
									//Sequence time
									if (checkBoxRandomSeqSelection.Checked)
									{
										var index = 0;
										var empty = 0;
										var randomString = new string[6];
										var seqRandom = new CheckBox[]
										{
											checkBoxRandom1, checkBoxRandom2, checkBoxRandom3, checkBoxRandom4, checkBoxRandom5,
											checkBoxRandom6
										};
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
												fileText = fileText.Replace("EffectTime_Change", "0"); //Sequence time
											}
										} while (selectedSeq == "");
									}
									else
									{
										selectedSeq = tabControlEffects.SelectedTab.Text;
									}
								}
							}
						}
	                    var i = 1;
                        //Select an Effect
	                    if (selectedSeq.Contains("SnowFlake - "))
	                    {
		                    comboBoxSnowFlakeName.SelectedItem = customMessageSeqSel.Text;
							fileText = fileText.Replace("Selected_Effect", "Snowflakes");
							fileText = fileText.Replace("Speed_1Change", trackBarSpeedSnowFlakes.Value.ToString());
							//Colour selection
							do
							{
								var btn = new Button[]
					                    {
						                    null, SnowFlakeColour1, SnowFlakeColour2, SnowFlakeColour3, SnowFlakeColour4, SnowFlakeColour5,
						                    SnowFlakeColour6
					                    };
								var ckb = new CheckBox[]
					                    {
						                    null, checkBoxSnowFlakeColour1, checkBoxSnowFlakeColour2, checkBoxSnowFlakeColour3,
						                    checkBoxSnowFlakeColour4, checkBoxSnowFlakeColour5, checkBoxSnowFlakeColour6
					                    };
								FileSettingsColour(btn, ckb, i, fileText, out fileText1);
								fileText = fileText1;
								i++;
							} while (i < 7);
	                    }
						if (selectedSeq.Contains("Meteor - "))
	                    {
							comboBoxMeteorName.SelectedItem = customMessageSeqSel.Text;
							fileText = fileText.Replace("Selected_Effect", "Meteors");
							fileText = fileText.Replace("Speed_1Change", trackBarSpeedMeteors.Value.ToString());
							//Colour selection
							do
							{
								var btn = new Button[]
					                    {
						                    null, MeteorColour1, MeteorColour2, MeteorColour3, MeteorColour4, MeteorColour5, MeteorColour6
					                    };
								var ckb = new CheckBox[]
					                    {
						                    null, checkBoxMeteorColour1, checkBoxMeteorColour2, checkBoxMeteorColour3,
						                    checkBoxMeteorColour4, checkBoxMeteorColour5, checkBoxMeteorColour6
					                    };
								FileSettingsColour(btn, ckb, i, fileText, out fileText1);
								fileText = fileText1;
								i++;
							} while (i < 7);
	                    }
	                    if (selectedSeq.Contains("Twinkle - "))
	                    {
							comboBoxTwinkleName.SelectedItem = customMessageSeqSel.Text;
							fileText = fileText.Replace("Selected_Effect", "Twinkles");
							fileText = fileText.Replace("Speed_1Change", trackBarSpeedTwinkles.Value.ToString());
							//Colour selection
							do
							{
								var btn = new Button[]
					                    {
						                    null, TwinkleColour1, TwinkleColour2, TwinkleColour3, TwinkleColour4, TwinkleColour5,
						                    TwinkleColour6
					                    };
								var ckb = new CheckBox[]
					                    {
						                    null, checkBoxTwinkleColour1, checkBoxTwinkleColour2, checkBoxTwinkleColour3,
						                    checkBoxTwinkleColour4, checkBoxTwinkleColour5, checkBoxTwinkleColour6
					                    };
								FileSettingsColour(btn, ckb, i, fileText, out fileText1);
								fileText = fileText1;
								i++;
							} while (i < 7);
	                    }
	                    else
	                    {
		                    switch (selectedSeq)
		                    {
			                    case "SnowFlakes":
				                    fileText = fileText.Replace("Selected_Effect", "Snowflakes");
				                    fileText = fileText.Replace("Speed_1Change", trackBarSpeedSnowFlakes.Value.ToString());
				                    //Colour selection
				                    do
				                    {
					                    var btn = new Button[]
					                    {
						                    null, SnowFlakeColour1, SnowFlakeColour2, SnowFlakeColour3, SnowFlakeColour4, SnowFlakeColour5,
						                    SnowFlakeColour6
					                    };
					                    var ckb = new CheckBox[]
					                    {
						                    null, checkBoxSnowFlakeColour1, checkBoxSnowFlakeColour2, checkBoxSnowFlakeColour3,
						                    checkBoxSnowFlakeColour4, checkBoxSnowFlakeColour5, checkBoxSnowFlakeColour6
					                    };
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
					                    var btn = new Button[]
					                    {
						                    null, MeteorColour1, MeteorColour2, MeteorColour3, MeteorColour4, MeteorColour5, MeteorColour6
					                    };
					                    var ckb = new CheckBox[]
					                    {
						                    null, checkBoxMeteorColour1, checkBoxMeteorColour2, checkBoxMeteorColour3,
						                    checkBoxMeteorColour4, checkBoxMeteorColour5, checkBoxMeteorColour6
					                    };
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
					                    var btn = new Button[]
					                    {
						                    null, TwinkleColour1, TwinkleColour2, TwinkleColour3, TwinkleColour4, TwinkleColour5,
						                    TwinkleColour6
					                    };
					                    var ckb = new CheckBox[]
					                    {
						                    null, checkBoxTwinkleColour1, checkBoxTwinkleColour2, checkBoxTwinkleColour3,
						                    checkBoxTwinkleColour4, checkBoxTwinkleColour5, checkBoxTwinkleColour6
					                    };
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
			                    default:
				                    fileText = fileText.Replace("Selected_Effect", "Fire");
				                    fileText = fileText.Replace("Speed_1Change", "0");
				                    //Colour selection
				                    FileSettings(fileText, out fileText1);
				                    fileText = fileText1;
				                    break;
		                    }
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

                        if (checkBoxVariableLength.Checked & !GlobalVar.PlayCustomMessage)
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
			var colourOption = new ComboBox[] {messageColourOption, incomingMessageColourOption};
			var colourOption1 = new Button[] { line1Colour, TextColor1 };
			var colourOption2 = new Button[] { line2Colour, TextColor2 };
			var colourOption3 = new Button[] { line3Colour, TextColor3 };
			var colourOption4 = new Button[] { line4Colour, TextColor4 };
            var i = 0;
            var textDirection = 0;
	        int messageSelection;
	        string hexMultiValue;
	        UInt32 multilineColour;
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
                fileText1 = fileText1.Replace("TextPosition_Change", trackBarCountDownPosition.Value.ToString());
                fileText1 = fileText1.Replace("FontName_Change", textBoxCustomFont.Text);
                fileText1 = fileText1.Replace("FontSize_Change", textBoxCustomFontSize.Text);
                fileText1 = fileText1.Replace("Speed_Change", trackBarCustomSpeed.Value.ToString());
				fileText1 = fileText1.Replace("CenterStop_Change", checkBoxCentreStop.Checked.ToString().ToLower());
				fileText1 = fileText1.Replace("NodeId_Change", GlobalVar.GroupNodeID[customMessageNodeSel.SelectedIndex]);//adds NodeId
				messageSelection = 0;
            }
            else
			{
				if (msg == "play sequence")
				{
					fileText1 = fileText1.Replace("NamePlaceholder1", "");
					fileText1 = fileText1.Replace("NamePlaceholder2", "");
					fileText1 = fileText1.Replace("NamePlaceholder3", "");
					fileText1 = fileText1.Replace("NamePlaceholder4", "");
					fileText1 = fileText1.Replace("TextPosition_Change", trackBarCountDownPosition.Value.ToString());
					fileText1 = fileText1.Replace("FontName_Change", textBoxCustomFont.Text);
					fileText1 = fileText1.Replace("FontSize_Change", textBoxCustomFontSize.Text);
					fileText1 = fileText1.Replace("Speed_Change", trackBarCustomSpeed.Value.ToString());
					fileText1 = fileText1.Replace("CenterStop_Change", checkBoxCentreStop.Checked.ToString().ToLower());
					fileText1 = fileText1.Replace("NodeId_Change", textBoxNodeId.Text);
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
                fileText1 = fileText1.Replace("TextPosition_Change", trackBarTextPosition.Value.ToString());
				messageSelection = 1;
            }
            
            fileText1 = fileText1.Replace("TextDirection_Change", textDirection.ToString());
            fileText1 = fileText1.Replace("NodeId_Change", textBoxNodeId.Text);//adds NodeId
            fileText1 = fileText1.Replace("StringOrienation_Change", comboBoxString.Text);
            fileText1 = fileText1.Replace("Speed_Change", trackBarTextSpeed.Value.ToString());
            fileText1 = fileText1.Replace("FontName_Change", textBoxFont.Text);
            fileText1 = fileText1.Replace("FontSize_Change", textBoxFontSize.Text);
            
            switch (colourOption[messageSelection].Text)
	            {
		            case "Single":
						hexMultiValue = colourOption1[messageSelection].BackColor.A.ToString("x2") + colourOption1[messageSelection].BackColor.R.ToString("x2") + colourOption1[messageSelection].BackColor.G.ToString("x2") + colourOption1[messageSelection].BackColor.B.ToString("x2");
						multilineColour = Convert.ToUInt32(hexMultiValue, 16);
						fileText1 = fileText1.Replace("Colour_Change1", multilineColour.ToString());
						fileText1 = fileText1.Replace("Colour_Change2", multilineColour.ToString());
						fileText1 = fileText1.Replace("Colour_Change3", multilineColour.ToString());
						fileText1 = fileText1.Replace("Colour_Change4", multilineColour.ToString());
						break;
					case "Multi":
						hexMultiValue = colourOption1[messageSelection].BackColor.A.ToString("x2") + colourOption1[messageSelection].BackColor.R.ToString("x2") + colourOption1[messageSelection].BackColor.G.ToString("x2") + colourOption1[messageSelection].BackColor.B.ToString("x2");
						multilineColour = Convert.ToUInt32(hexMultiValue, 16);
						fileText1 = fileText1.Replace("Colour_Change1", multilineColour.ToString());
						hexMultiValue = colourOption2[messageSelection].BackColor.A.ToString("x2") + colourOption2[messageSelection].BackColor.R.ToString("x2") + colourOption2[messageSelection].BackColor.G.ToString("x2") + colourOption2[messageSelection].BackColor.B.ToString("x2");
						multilineColour = Convert.ToUInt32(hexMultiValue, 16);
						fileText1 = fileText1.Replace("Colour_Change2", multilineColour.ToString());
						hexMultiValue = colourOption3[messageSelection].BackColor.A.ToString("x2") + colourOption3[messageSelection].BackColor.R.ToString("x2") + colourOption3[messageSelection].BackColor.G.ToString("x2") + colourOption3[messageSelection].BackColor.B.ToString("x2");
						multilineColour = Convert.ToUInt32(hexMultiValue, 16);
						fileText1 = fileText1.Replace("Colour_Change3", multilineColour.ToString());
						hexMultiValue = colourOption4[messageSelection].BackColor.A.ToString("x2") + colourOption4[messageSelection].BackColor.R.ToString("x2") + colourOption4[messageSelection].BackColor.G.ToString("x2") + colourOption4[messageSelection].BackColor.B.ToString("x2");
						multilineColour = Convert.ToUInt32(hexMultiValue, 16);
						fileText1 = fileText1.Replace("Colour_Change4", multilineColour.ToString());
			            break;
					case "Random":
						RandomColourSelect(out hexMultiValue);
						multilineColour = Convert.ToUInt32(hexMultiValue, 16);
						fileText1 = fileText1.Replace("Colour_Change1", multilineColour.ToString());
						Thread.Sleep(300);
						RandomColourSelect(out hexMultiValue);
						multilineColour = Convert.ToUInt32(hexMultiValue, 16);
						fileText1 = fileText1.Replace("Colour_Change2", multilineColour.ToString());
						Thread.Sleep(300);
						RandomColourSelect(out hexMultiValue);
						multilineColour = Convert.ToUInt32(hexMultiValue, 16);
						fileText1 = fileText1.Replace("Colour_Change3", multilineColour.ToString());
						Thread.Sleep(300);
						RandomColourSelect(out hexMultiValue);
						multilineColour = Convert.ToUInt32(hexMultiValue, 16);
						fileText1 = fileText1.Replace("Colour_Change4", multilineColour.ToString());
						Thread.Sleep(300);
			            break;
	            }
			fileText1 = fileText1.Replace("CenterStop_Change", "false");
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
			ColPal(colNum, TextColor1.BackColor);
        }

        private void TextColor2_Click(object sender, EventArgs e)
        {
            int colNum = 2;
			ColPal(colNum, TextColor2.BackColor);
        }

        private void TextColor3_Click(object sender, EventArgs e)
        {
            int colNum = 3;
			ColPal(colNum, TextColor3.BackColor);
        }

        private void TextColor4_Click(object sender, EventArgs e)
        {
            int colNum = 4;
			ColPal(colNum, TextColor4.BackColor);
        }

        private void TextColor5_Click(object sender, EventArgs e)
        {
            int colNum = 5;
			ColPal(colNum, TextColor5.BackColor);
        }

        private void TextColor6_Click(object sender, EventArgs e)
        {
            int colNum = 6;
			ColPal(colNum, TextColor6.BackColor);
        }

        private void TextColor7_Click(object sender, EventArgs e)
        {
            int colNum = 7;
			ColPal(colNum, TextColor7.BackColor);
        }

        private void TextColor8_Click(object sender, EventArgs e)
        {
            int colNum = 8;
			ColPal(colNum, TextColor8.BackColor);
        }

        private void TextColor9_Click(object sender, EventArgs e)
        {
            int colNum = 9;
			ColPal(colNum, TextColor9.BackColor);
        }

        private void TextColor10_Click(object sender, EventArgs e)
        {
            int colNum = 10;
			ColPal(colNum, TextColor10.BackColor);
        }

        private void SnowFlakeColour1_Click(object sender, EventArgs e)
        {
            int colNum = 11;
			ColPal(colNum, SnowFlakeColour1.BackColor);
        }

        private void SnowFlakeColour2_Click(object sender, EventArgs e)
        {
            int colNum = 12;
			ColPal(colNum, SnowFlakeColour2.BackColor);
        }

        private void SnowFlakeColour3_Click(object sender, EventArgs e)
        {
            int colNum = 13;
			ColPal(colNum, SnowFlakeColour3.BackColor);
        }

        private void SnowFlakeColour4_Click(object sender, EventArgs e)
        {
            int colNum = 14;
			ColPal(colNum, SnowFlakeColour4.BackColor);
        }

        private void SnowFlakeColour5_Click(object sender, EventArgs e)
        {
            int colNum = 15;
			ColPal(colNum, SnowFlakeColour5.BackColor);
        }

        private void SnowFlakeColour6_Click(object sender, EventArgs e)
        {
            int colNum = 16;
			ColPal(colNum, SnowFlakeColour6.BackColor);
        }

        private void MeteorColour1_Click(object sender, EventArgs e)
        {
            int colNum = 17;
			ColPal(colNum, MeteorColour1.BackColor);
        }

        private void MeteorColour2_Click(object sender, EventArgs e)
        {
            int colNum = 18;
			ColPal(colNum, MeteorColour2.BackColor);
        }

        private void MeteorColour3_Click(object sender, EventArgs e)
        {
            int colNum = 19;
			ColPal(colNum, MeteorColour3.BackColor);
        }

        private void MeteorColour4_Click(object sender, EventArgs e)
        {
            int colNum = 20;
			ColPal(colNum, MeteorColour4.BackColor);
        }

        private void MeteorColour5_Click(object sender, EventArgs e)
        {
            int colNum = 21;
			ColPal(colNum, MeteorColour5.BackColor);
        }

        private void MeteorColour6_Click(object sender, EventArgs e)
        {
            int colNum = 22;
			ColPal(colNum, MeteorColour6.BackColor);
        }

        private void TwinkleColour1_Click(object sender, EventArgs e)
        {
            int colNum = 23;
			ColPal(colNum, TwinkleColour1.BackColor);
        }

        private void TwinkleColour2_Click(object sender, EventArgs e)
        {
            int colNum = 24;
			ColPal(colNum, TwinkleColour2.BackColor);
        }

        private void TwinkleColour3_Click(object sender, EventArgs e)
        {
            int colNum = 25;
			ColPal(colNum, TwinkleColour3.BackColor);
        }

        private void TwinkleColour4_Click(object sender, EventArgs e)
        {
            int colNum = 26;
			ColPal(colNum, TwinkleColour4.BackColor);
        }

        private void TwinkleColour5_Click(object sender, EventArgs e)
        {
            int colNum = 27;
			ColPal(colNum, TwinkleColour5.BackColor);
        }

        private void TwinkleColour6_Click(object sender, EventArgs e)
        {
            int colNum = 28;
			ColPal(colNum, TwinkleColour6.BackColor);
        }

		private void line1Colour_Click(object sender, EventArgs e)
		{
			int colNum = 29;
			ColPal(colNum, line1Colour.BackColor);
		}

		private void line2Colour_Click(object sender, EventArgs e)
		{
			int colNum = 30;
			ColPal(colNum, line2Colour.BackColor);
		}

		private void line3Colour_Click(object sender, EventArgs e)
		{
			int colNum = 31;
			ColPal(colNum, line3Colour.BackColor);
		}

		private void line4Colour_Click(object sender, EventArgs e)
		{
			int colNum = 32;
			ColPal(colNum, line4Colour.BackColor);
		}

	    private void ColourVisible()
	    {
			var colourVisible = new Label[]
			{
				labelColour1, labelColour2, labelColour3, labelColour4, labelColour5, labelColour6, labelColour7, labelColour8,
				labelColour9, labelColour10
			};
			var i = 0;
			switch (incomingMessageColourOption.Text)
			{
				case "Single":
					RandomColourSelection.Text = @"Single Colour Selection";
					colourVisible[i].Visible = true;
					do
					{
						i++;
						colourVisible[i].Visible = false;
					} while (i < 9);
					break;
				case "Multi":
					RandomColourSelection.Text = @"Multiple Colour Selection";
					do
					{
						colourVisible[i].Visible = true;
						i++;
					} while (i < 4);
					do
					{
						colourVisible[i].Visible = false;
						i++;
					} while (i < 10);
					break;
				case "Random":
					RandomColourSelection.Text = @"Random Colour Selection";
					do
					{
						colourVisible[i].Visible = true;
						i++;
					} while (i < 10);
					break;
			}
	    }

	    private void ColPal(int colNum, Color current)
	    {
		    colorDialog1.Color = current;
			colorDialog1.ShowDialog();

			var btn = new Button[] { TextColor1, TextColor1, TextColor2, TextColor3, TextColor4, TextColor5, TextColor6, TextColor7, TextColor8, TextColor9, TextColor10, SnowFlakeColour1, SnowFlakeColour2, SnowFlakeColour3, SnowFlakeColour4, SnowFlakeColour5, SnowFlakeColour6, MeteorColour1, MeteorColour2, MeteorColour3, MeteorColour4, MeteorColour5, MeteorColour6, TwinkleColour1, TwinkleColour2, TwinkleColour3, TwinkleColour4, TwinkleColour5, TwinkleColour6, line1Colour, line2Colour, line3Colour, line4Colour };
            btn[colNum].BackColor = colorDialog1.Color;
            SeqSave();
        }
        #endregion

        #region Colour Selection

		private void RandomColourSelect(out string hexValue)
	    {
			do
			{
				var random = new Random();
				var randomCol = random.Next(0, 10);
				var btn = new Button[] { TextColor1, TextColor2, TextColor3, TextColor4, TextColor5, TextColor6, TextColor7, TextColor8, TextColor9, TextColor10 };
				hexValue = btn[randomCol].BackColor.A.ToString("x2") + btn[randomCol].BackColor.R.ToString("x2") + btn[randomCol].BackColor.G.ToString("x2") + btn[randomCol].BackColor.B.ToString("x2");
			} while (hexValue == "ff000000");
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
				comboBoxNodeID.Items.Add(retrieveVixenSettings.textBoxVixenGroupName.Text);
            }

            if (retrieveVixenSettings.checkBoxNodeID.Checked)
            {
				GetNodeId(retrieveVixenSettings.textBoxVixenGroupName.Text);
				textBoxNodeId.Text = GlobalVar.GroupNodeID[0];
				comboBoxNodeID.SelectedIndex = comboBoxNodeID.Items.Count - 1;
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
        private void GetNodeId(string addGroupName)
        {
            var nodeResult = "";

            try
            {
                //Used to find the NodeId of the Nutcracker effect.
                var reading = File.OpenText((textBoxVixenFolder.Text + "\\SystemData\\SystemConfig.xml"));
                string str;
                while ((str = reading.ReadLine()) != null)
                {
					if (str.Contains("<Node name=\"" + addGroupName + "\" id=\""))
                    {
                        nodeResult = str;
                    }
                }

				nodeResult = nodeResult.Replace("<Node name=\"" + addGroupName + "\" id=\"", "");
                nodeResult = nodeResult.Trim(new Char[] { '\"', '>', ' ' });
                reading.Close();

                if (nodeResult == "")
                {
	                MessageBox.Show(@"Unable to find NodeId for your Group, please ensure you have entered the correct Group Name above and it is case sensitive", @"WARNING");
	                GlobalVar.NoNodeID = true;
                }
                else
                {
	                GlobalVar.GroupNodeID.Add(nodeResult);
					GlobalVar.NoNodeID = false;
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
			GlobalVar.PlayCustomMessage = false;
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
			 GlobalVar.PlayCustomMessage = true;
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
            e.Cancel = false;
            var save = MessageBox.Show(@"Would you like to save all Settings and Lists on exit?", @"Save", MessageBoxButtons.YesNoCancel);
            switch (save)
            {
                case DialogResult.Yes:
                    Save();
                    StopSequence();
                    break;
                case DialogResult.No:
                    StopSequence();
                    break;
                case DialogResult.Cancel:
                    e.Cancel = true;
                    break;
            }
        }
#endregion

#region Save Data

			#region General Settings
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
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "StringOrienation", comboBoxString.Text);
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "LogMessageFile", textBoxLogFileName.Text);
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "LogBlacklistFile", textBoxBlacklistEmailLog.Text);
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "SMSSubjectHeader", textBoxSubjectHeader.Text);
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxSqnEnable", checkBoxEnableSqnctrl.Checked);
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxAutoStart", checkBoxAutoStart.Checked);
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxBlack_list", checkBoxBlacklist.Checked);
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxDisableSeq", checkBoxDisableSeq.Checked);
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "incomingMessageColourOption", incomingMessageColourOption.Text);
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
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "tabControlMain", tabControlMain.SelectedIndex);
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
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxVixenControl", checkBoxVixenControl.Checked.ToString());
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "messageColourOption", messageColourOption.Text);
#endregion

			#region Group ID Settings

			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "GroupIDNumberSel", comboBoxNodeID.SelectedIndex);
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "GroupIDNumber", comboBoxNodeID.Items.Count);
			var i = 0;
            var line = "GroupNameID";
            do
            {
				profile.PutSetting(XmlProfileSettings.SettingType.Message, line + i, Convert.ToString(comboBoxNodeID.Items[i]));
				line = "GroupNodeID";
				profile.PutSetting(XmlProfileSettings.SettingType.Message, line + i, GlobalVar.GroupNodeID[i]);
				line = "GroupNameID";
				i++;
			} while (i < GlobalVar.GroupNodeID.Count());
			#endregion

			#region Custom Message Settings

			GlobalVar.MessageNumber = GlobalVar.ListLine1.Count();
			profile.PutSetting(XmlProfileSettings.SettingType.Message, "MessageNumber", GlobalVar.MessageNumber.ToString());
			i = 0;
            line = "ListLine1-";
            do
            {
				profile.PutSetting(XmlProfileSettings.SettingType.Message, line + i, GlobalVar.ListLine1[i]);
                line = "ListLine2-";
				profile.PutSetting(XmlProfileSettings.SettingType.Message, line + i, GlobalVar.ListLine2[i]);
                line = "ListLine3-";
				profile.PutSetting(XmlProfileSettings.SettingType.Message, line + i, GlobalVar.ListLine3[i]);
                line = "ListLine4-";
				profile.PutSetting(XmlProfileSettings.SettingType.Message, line + i, GlobalVar.ListLine4[i]);
				line = "Line1Colour";
				profile.PutSetting(XmlProfileSettings.SettingType.Message, line + i, GlobalVar.Line1Colour[i]);
				line = "Line2Colour";
				profile.PutSetting(XmlProfileSettings.SettingType.Message, line + i, GlobalVar.Line2Colour[i]);
				line = "Line3Colour";
				profile.PutSetting(XmlProfileSettings.SettingType.Message, line + i, GlobalVar.Line3Colour[i]);
				line = "Line4Colour";
				profile.PutSetting(XmlProfileSettings.SettingType.Message, line + i, GlobalVar.Line4Colour[i]);
				line = "MessageDirection";
				profile.PutSetting(XmlProfileSettings.SettingType.Message, line + i, GlobalVar.CountDirection[i]);
                line = "MessagePosition";
				profile.PutSetting(XmlProfileSettings.SettingType.Message, line + i, GlobalVar.Position[i]);
                line = "MessageEnabled";
				profile.PutSetting(XmlProfileSettings.SettingType.Message, line + i, GlobalVar.MessageEnabled[i]);
				line = "MessageColourOption";
				profile.PutSetting(XmlProfileSettings.SettingType.Message, line + i, GlobalVar.MessageColourOption[i]);
				line = "MessageSeqSel";
				profile.PutSetting(XmlProfileSettings.SettingType.Message, line + i, GlobalVar.CustomMessageSeqSel[i]);
				line = "MessageNodeSel";
				profile.PutSetting(XmlProfileSettings.SettingType.Message, line + i, GlobalVar.CustomMessageNodeSel[i]);
				line = "MessageName";
				profile.PutSetting(XmlProfileSettings.SettingType.Message, line + i, Convert.ToString(comboBoxName.Items[i]));
                line = "CustomFont";
				profile.PutSetting(XmlProfileSettings.SettingType.Message, line + i, GlobalVar.CustomFont[i]);
                line = "CustomSpeed";
				profile.PutSetting(XmlProfileSettings.SettingType.Message, line + i, GlobalVar.TrackBarCustomSpeed[i]);
				line = "CenterStop";
				profile.PutSetting(XmlProfileSettings.SettingType.Message, line + i, GlobalVar.CheckBoxCentreStop[i]);
				line = "CustomFontSize";
				profile.PutSetting(XmlProfileSettings.SettingType.Message, line + i, GlobalVar.CustomFontSize[i]);
                line = "CustomMsgLength";
				profile.PutSetting(XmlProfileSettings.SettingType.Message, line + i, Convert.ToString(GlobalVar.CustomMsgLength[i]));
                line = "ListLine1-";
                i++;
            } while (i < GlobalVar.ListLine1.Count());
			#endregion

			#region SnowFlake Settings

			GlobalVar.SnowFlakeNumber = GlobalVar.SnowFlakeEffectType.Count();
			profile.PutSetting(XmlProfileSettings.SettingType.SnowFlakes, "SnowFlakeNumber", GlobalVar.SnowFlakeNumber.ToString());
			i = 0;
			line = "SnowFlakeName";
			do
			{
				profile.PutSetting(XmlProfileSettings.SettingType.SnowFlakes, line + i, Convert.ToString(comboBoxSnowFlakeName.Items[i]));
				line = "SnowFlakeEffectType";
				profile.PutSetting(XmlProfileSettings.SettingType.SnowFlakes, line + i, GlobalVar.SnowFlakeEffectType[i]);
				line = "SnowFlakeMax";
				profile.PutSetting(XmlProfileSettings.SettingType.SnowFlakes, line + i, GlobalVar.SnowFlakeMax[i]);
				line = "SnowFlakeSpeed";
				profile.PutSetting(XmlProfileSettings.SettingType.SnowFlakes, line + i, GlobalVar.SnowFlakeSpeed[i]);
				line = "SnowFlakeRandomEnable";
				profile.PutSetting(XmlProfileSettings.SettingType.SnowFlakes, line + i, GlobalVar.SnowFlakeRandomEnable[i]);
				line = "SnowFlakeColourEnable1";
				profile.PutSetting(XmlProfileSettings.SettingType.SnowFlakes, line + i, GlobalVar.SnowFlakeColourEnable1[i]);
				line = "SnowFlakeColourEnable2";
				profile.PutSetting(XmlProfileSettings.SettingType.SnowFlakes, line + i, GlobalVar.SnowFlakeColourEnable2[i]);
				line = "SnowFlakeColourEnable3";
				profile.PutSetting(XmlProfileSettings.SettingType.SnowFlakes, line + i, GlobalVar.SnowFlakeColourEnable3[i]);
				line = "SnowFlakeColourEnable4";
				profile.PutSetting(XmlProfileSettings.SettingType.SnowFlakes, line + i, GlobalVar.SnowFlakeColourEnable4[i]);
				line = "SnowFlakeColourEnable5";
				profile.PutSetting(XmlProfileSettings.SettingType.SnowFlakes, line + i, GlobalVar.SnowFlakeColourEnable5[i]);
				line = "SnowFlakeColourEnable6";
				profile.PutSetting(XmlProfileSettings.SettingType.SnowFlakes, line + i, GlobalVar.SnowFlakeColourEnable6[i]);
				line = "SnowFlakeColour1";
				profile.PutSetting(XmlProfileSettings.SettingType.SnowFlakes, line + i, GlobalVar.SnowFlakeColour1[i]);
				line = "SnowFlakeColour2";
				profile.PutSetting(XmlProfileSettings.SettingType.SnowFlakes, line + i, GlobalVar.SnowFlakeColour2[i]);
				line = "SnowFlakeColour3";
				profile.PutSetting(XmlProfileSettings.SettingType.SnowFlakes, line + i, GlobalVar.SnowFlakeColour3[i]);
				line = "SnowFlakeColour4";
				profile.PutSetting(XmlProfileSettings.SettingType.SnowFlakes, line + i, GlobalVar.SnowFlakeColour4[i]);
				line = "SnowFlakeColour5";
				profile.PutSetting(XmlProfileSettings.SettingType.SnowFlakes, line + i, GlobalVar.SnowFlakeColour5[i]);
				line = "SnowFlakeColour6";
				profile.PutSetting(XmlProfileSettings.SettingType.SnowFlakes, line + i, GlobalVar.SnowFlakeColour6[i]);
				line = "SnowFlakeName";
				i++;
			} while (i < GlobalVar.SnowFlakeEffectType.Count());
			#endregion

			#region Meteor Settings

			GlobalVar.MeteorNumber = GlobalVar.MeteorColourType.Count();
			profile.PutSetting(XmlProfileSettings.SettingType.Meteor, "MeteorNumber", GlobalVar.MeteorNumber.ToString());
			i = 0;
			line = "MeteorName";
			do
			{
				profile.PutSetting(XmlProfileSettings.SettingType.Meteor, line + i, Convert.ToString(comboBoxMeteorName.Items[i]));
				line = "MeteorColourType";
				profile.PutSetting(XmlProfileSettings.SettingType.Meteor, line + i, GlobalVar.MeteorColourType[i]);
				line = "MeteorCount";
				profile.PutSetting(XmlProfileSettings.SettingType.Meteor, line + i, GlobalVar.MeteorCount[i]);
				line = "MeteorTrailLength";
				profile.PutSetting(XmlProfileSettings.SettingType.Meteor, line + i, GlobalVar.MeteorTrailLength[i]);
				line = "MeteorSpeed";
				profile.PutSetting(XmlProfileSettings.SettingType.Meteor, line + i, GlobalVar.MeteorSpeed[i]);
				line = "MeteorRandomEnable";
				profile.PutSetting(XmlProfileSettings.SettingType.Meteor, line + i, GlobalVar.MeteorRandomEnable[i]);
				line = "MeteorColourEnable1";
				profile.PutSetting(XmlProfileSettings.SettingType.Meteor, line + i, GlobalVar.MeteorColourEnable1[i]);
				line = "MeteorColourEnable2";
				profile.PutSetting(XmlProfileSettings.SettingType.Meteor, line + i, GlobalVar.MeteorColourEnable2[i]);
				line = "MeteorColourEnable3";
				profile.PutSetting(XmlProfileSettings.SettingType.Meteor, line + i, GlobalVar.MeteorColourEnable3[i]);
				line = "MeteorColourEnable4";
				profile.PutSetting(XmlProfileSettings.SettingType.Meteor, line + i, GlobalVar.MeteorColourEnable4[i]);
				line = "MeteorColourEnable5";
				profile.PutSetting(XmlProfileSettings.SettingType.Meteor, line + i, GlobalVar.MeteorColourEnable5[i]);
				line = "MeteorColourEnable6";
				profile.PutSetting(XmlProfileSettings.SettingType.Meteor, line + i, GlobalVar.MeteorColourEnable6[i]);
				line = "MeteorColour1";
				profile.PutSetting(XmlProfileSettings.SettingType.Meteor, line + i, GlobalVar.MeteorColour1[i]);
				line = "MeteorColour2";
				profile.PutSetting(XmlProfileSettings.SettingType.Meteor, line + i, GlobalVar.MeteorColour2[i]);
				line = "MeteorColour3";
				profile.PutSetting(XmlProfileSettings.SettingType.Meteor, line + i, GlobalVar.MeteorColour3[i]);
				line = "MeteorColour4";
				profile.PutSetting(XmlProfileSettings.SettingType.Meteor, line + i, GlobalVar.MeteorColour4[i]);
				line = "MeteorColour5";
				profile.PutSetting(XmlProfileSettings.SettingType.Meteor, line + i, GlobalVar.MeteorColour5[i]);
				line = "MeteorColour6";
				profile.PutSetting(XmlProfileSettings.SettingType.Meteor, line + i, GlobalVar.MeteorColour6[i]);
				line = "MeteorName";
				i++;
			} while (i < GlobalVar.MeteorColourType.Count());
			#endregion

			#region Twinkle Settings

			GlobalVar.TwinkleNumber = GlobalVar.TwinkleLights.Count();
			profile.PutSetting(XmlProfileSettings.SettingType.Twinkle, "TwinkleNumber", GlobalVar.TwinkleNumber.ToString());
			i = 0;
			line = "TwinkleName";
			do
			{
				profile.PutSetting(XmlProfileSettings.SettingType.Twinkle, line + i, Convert.ToString(comboBoxTwinkleName.Items[i]));
				line = "TwinkleLights";
				profile.PutSetting(XmlProfileSettings.SettingType.Twinkle, line + i, GlobalVar.TwinkleLights[i]);
				line = "TwinkleSteps";
				profile.PutSetting(XmlProfileSettings.SettingType.Twinkle, line + i, GlobalVar.TwinkleSteps[i]);
				line = "TwinkleSpeed";
				profile.PutSetting(XmlProfileSettings.SettingType.Twinkle, line + i, GlobalVar.TwinkleSpeed[i]);
				line = "TwinkleRandomEnable";
				profile.PutSetting(XmlProfileSettings.SettingType.Twinkle, line + i, GlobalVar.TwinkleRandomEnable[i]);
				line = "TwinkleColourEnable1";
				profile.PutSetting(XmlProfileSettings.SettingType.Twinkle, line + i, GlobalVar.TwinkleColourEnable1[i]);
				line = "TwinkleColourEnable2";
				profile.PutSetting(XmlProfileSettings.SettingType.Twinkle, line + i, GlobalVar.TwinkleColourEnable2[i]);
				line = "TwinkleColourEnable3";
				profile.PutSetting(XmlProfileSettings.SettingType.Twinkle, line + i, GlobalVar.TwinkleColourEnable3[i]);
				line = "TwinkleColourEnable4";
				profile.PutSetting(XmlProfileSettings.SettingType.Twinkle, line + i, GlobalVar.TwinkleColourEnable4[i]);
				line = "TwinkleColourEnable5";
				profile.PutSetting(XmlProfileSettings.SettingType.Twinkle, line + i, GlobalVar.TwinkleColourEnable5[i]);
				line = "TwinkleColourEnable6";
				profile.PutSetting(XmlProfileSettings.SettingType.Twinkle, line + i, GlobalVar.TwinkleColourEnable6[i]);
				line = "TwinkleColour1";
				profile.PutSetting(XmlProfileSettings.SettingType.Twinkle, line + i, GlobalVar.TwinkleColour1[i]);
				line = "TwinkleColour2";
				profile.PutSetting(XmlProfileSettings.SettingType.Twinkle, line + i, GlobalVar.TwinkleColour2[i]);
				line = "TwinkleColour3";
				profile.PutSetting(XmlProfileSettings.SettingType.Twinkle, line + i, GlobalVar.TwinkleColour3[i]);
				line = "TwinkleColour4";
				profile.PutSetting(XmlProfileSettings.SettingType.Twinkle, line + i, GlobalVar.TwinkleColour4[i]);
				line = "TwinkleColour5";
				profile.PutSetting(XmlProfileSettings.SettingType.Twinkle, line + i, GlobalVar.TwinkleColour5[i]);
				line = "TwinkleColour6";
				profile.PutSetting(XmlProfileSettings.SettingType.Twinkle, line + i, GlobalVar.TwinkleColour6[i]);
				line = "TwinkleName";
				i++;
			} while (i < GlobalVar.TwinkleLights.Count());
			#endregion
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

        private void trackBarCustomSpeed_Scroll(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(trackBarCustomSpeed, trackBarCustomSpeed.Value.ToString());
        }

        private void trackBarCustomSpeed_MouseDown(object sender, MouseEventArgs e)
        {
            toolTip1.SetToolTip(trackBarCustomSpeed, trackBarCustomSpeed.Value.ToString());
        }

        private void trackBarCustomSpeed_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(trackBarCustomSpeed, trackBarCustomSpeed.Value.ToString());
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
			fontDialog1.Font = new Font(textBoxFont.Text, (int)Math.Round(double.Parse(textBoxFontSize.Text)));
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
            SaveBlackList();
            MessageBox.Show(@"Blacklist saved!");
        }

        private void SaveBlackList()
        {
            richTextBoxBlacklist.SaveFile(GlobalVar.Blacklistlocation, RichTextBoxStreamType.PlainText);
            richTextBoxBlacklist.SaveFile(GlobalVar.Blacklistlocation + ".bkp", RichTextBoxStreamType.PlainText);
        }

        private void pictureBoxSaveWhitelist_Click(object sender, EventArgs e)
        {
            SaveWhiteList();
            MessageBox.Show(@"Whitelist saved!");
        }

        private void SaveWhiteList()
        {
            richTextBoxWhitelist.SaveFile(GlobalVar.Whitelistlocation, RichTextBoxStreamType.PlainText);
            richTextBoxWhitelist.SaveFile(GlobalVar.Whitelistlocation + ".bkp", RichTextBoxStreamType.PlainText);
        }

        private void SaveMessageList()
        {
            richTextBoxMessage.SaveFile(GlobalVar.LocalMessages, RichTextBoxStreamType.PlainText);
            richTextBoxMessage.SaveFile(GlobalVar.LocalMessages + ".bkp", RichTextBoxStreamType.PlainText);
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

        private void checkBoxMultiLine_CheckedChanged(object sender, EventArgs e)
        {
            TextLineNumber.Enabled = !TextLineNumber.Enabled;
            numericUpDownMultiLine.Enabled = !numericUpDownMultiLine.Enabled;
			ColourVisible();
        }

        private void SaveAll_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {
            SaveBlackList();
            SaveWhiteList();
            SaveMessageList();
            SeqSave();
            MessageBox.Show(@"All Settings, Whitelist, Blacklist and Messagelists have been saved.");
        }

        private void trackBarCustomSpeed_MouseLeave(object sender, EventArgs e)
        {
            CustomMessageUpdate();
		}

		private void checkBoxCentreStop_Leave(object sender, EventArgs e)
		{
			CustomMessageUpdate();
		}

		private void incomingMessageColourOption_SelectedIndexChanged(object sender, EventArgs e)
		{
			ColourVisible();
		}

		private void buttonAddNodeID_Click(object sender, EventArgs e)
		{
			string addGroupName;
			addGroupName = Interaction.InputBox("Enter a Group Name of your Matrix/Megatree/Grid. Ensure it matches your Vixen Group Name exactly.", "Group Node ID");
			if (addGroupName != "")
			{
				comboBoxNodeID.Items.Add(addGroupName);
				
				GetNodeId(addGroupName);
				if (!GlobalVar.NoNodeID)
				{
					GlobalVar.GroupNameID.Add(addGroupName);
					textBoxNodeId.Text = GlobalVar.GroupNodeID[comboBoxNodeID.Items.Count - 1];
					comboBoxNodeID.SelectedIndex = comboBoxNodeID.Items.Count - 1;
					customMessageNodeSel.Items.Add(addGroupName);
				}
				else
				{
					comboBoxNodeID.Items.RemoveAt(comboBoxNodeID.Items.Count -1);
				}
			}
		}

		private void comboBoxNodeID_SelectedIndexChanged(object sender, EventArgs e)
		{
			var selectedItem = comboBoxNodeID.SelectedIndex;
			textBoxNodeId.Text = GlobalVar.GroupNodeID[selectedItem];
		}

	    private void buttonRemoveNodeID_Click(object sender, EventArgs e)
	    {
		    if (comboBoxNodeID.Items.Count > 0)
		    {
				GlobalVar.GroupNodeID.RemoveAt(comboBoxNodeID.SelectedIndex);
				GlobalVar.GroupNameID.RemoveAt(comboBoxNodeID.SelectedIndex);
				customMessageNodeSel.Items.RemoveAt(comboBoxNodeID.SelectedIndex);
				comboBoxNodeID.Items.RemoveAt(comboBoxNodeID.SelectedIndex);
				if (comboBoxNodeID.Items.Count > 0)
			    {
					comboBoxNodeID.SelectedIndex = 0;
					textBoxNodeId.Text = GlobalVar.GroupNodeID[0];
				    customMessageNodeSel.SelectedIndex = 0;
			    }
			    else
			    {
					comboBoxNodeID.Items.Clear();
				    comboBoxNodeID.Text = "";
					textBoxNodeId.Text = "";
					customMessageNodeSel.Items.Clear();
				    customMessageNodeSel.Text = "";
			    }
		    }
	    }

		private void customMessageNodeSel_SelectionChangeCommitted(object sender, EventArgs e)
		{
			CustomMessageUpdate();
		}

		private void customMessageSeqSel_SelectionChangeCommitted(object sender, EventArgs e)
		{
			CustomMessageUpdate();
		}

		private void messageColourOption_SelectionChangeCommitted(object sender, EventArgs e)
		{
			switch (messageColourOption.Text)
			{
				case "Single":
					line1Colour.Visible = true;
					line2Colour.Visible = false;
					line3Colour.Visible = false;
					line4Colour.Visible = false;
					break;
				case "Multi":
					line1Colour.Visible = true;
					line2Colour.Visible = true;
					line3Colour.Visible = true;
					line4Colour.Visible = true;
					break;
				case "Random":
					line1Colour.Visible = false;
					line2Colour.Visible = false;
					line3Colour.Visible = false;
					line4Colour.Visible = false;
					break;
			}
			CustomMessageUpdate();
		}

		private void comboBoxCountDownDirection_SelectionChangeCommitted(object sender, EventArgs e)
		{
			CustomMessageUpdate();
		}
#endregion

#region Multiple Meteors
		private void comboBoxMeteorName_SelectedIndexChanged(object sender, EventArgs e)
		{
			CustomMeteor();
		}

		private void CustomMeteor()
		{
			var selectedItem = comboBoxMeteorName.SelectedIndex;
			EffectType.Text = GlobalVar.MeteorColourType[selectedItem];
			MeteorCount.Value = GlobalVar.MeteorCount[selectedItem];
			MeteorTrailLength.Value = GlobalVar.MeteorTrailLength[selectedItem];
			trackBarSpeedMeteors.Value = GlobalVar.MeteorSpeed[selectedItem];
			checkBoxRandom3.Checked = GlobalVar.MeteorRandomEnable[selectedItem];
			checkBoxMeteorColour1.Checked = GlobalVar.MeteorColourEnable1[selectedItem];
			checkBoxMeteorColour2.Checked = GlobalVar.MeteorColourEnable2[selectedItem];
			checkBoxMeteorColour3.Checked = GlobalVar.MeteorColourEnable3[selectedItem];
			checkBoxMeteorColour4.Checked = GlobalVar.MeteorColourEnable4[selectedItem];
			checkBoxMeteorColour5.Checked = GlobalVar.MeteorColourEnable5[selectedItem];
			checkBoxMeteorColour6.Checked = GlobalVar.MeteorColourEnable6[selectedItem];
			MeteorColour1.BackColor = Color.FromArgb(Convert.ToInt32(GlobalVar.MeteorColour1[selectedItem]));
			MeteorColour2.BackColor = Color.FromArgb(Convert.ToInt32(GlobalVar.MeteorColour2[selectedItem]));
			MeteorColour3.BackColor = Color.FromArgb(Convert.ToInt32(GlobalVar.MeteorColour3[selectedItem]));
			MeteorColour4.BackColor = Color.FromArgb(Convert.ToInt32(GlobalVar.MeteorColour4[selectedItem]));
			MeteorColour5.BackColor = Color.FromArgb(Convert.ToInt32(GlobalVar.MeteorColour5[selectedItem]));
			MeteorColour6.BackColor = Color.FromArgb(Convert.ToInt32(GlobalVar.MeteorColour6[selectedItem]));
		}

		private void buttonAddMeteor_Click(object sender, EventArgs e)
		{
			var addCustomMsg = "Meteor - " + Interaction.InputBox("Enter a Name for your Custom Meteor", "Custom Meteor");
			if (addCustomMsg != "")
			{
				GlobalVar.MeteorColourType.Add("Range");
				GlobalVar.MeteorCount.Add(11);
				GlobalVar.MeteorTrailLength.Add(12);
				GlobalVar.MeteorSpeed.Add(5);
				GlobalVar.MeteorRandomEnable.Add(true);
				GlobalVar.MeteorColourEnable1.Add(true);
				GlobalVar.MeteorColourEnable2.Add(false);
				GlobalVar.MeteorColourEnable3.Add(false);
				GlobalVar.MeteorColourEnable4.Add(false);
				GlobalVar.MeteorColourEnable5.Add(false);
				GlobalVar.MeteorColourEnable6.Add(false);
				GlobalVar.MeteorColour1.Add(Convert.ToInt32(-16776961));
				GlobalVar.MeteorColour2.Add(Convert.ToInt32(-65536));
				GlobalVar.MeteorColour3.Add(Convert.ToInt32(-16711936));
				GlobalVar.MeteorColour4.Add(Convert.ToInt32(-32640));
				GlobalVar.MeteorColour5.Add(Convert.ToInt32(-16711936));
				GlobalVar.MeteorColour6.Add(Convert.ToInt32(-32640));
				comboBoxMeteorName.Items.Add(addCustomMsg);
				comboBoxMeteorName.SelectedIndex = comboBoxMeteorName.Items.Count - 1;
				customMessageSeqSel.Items.Add(addCustomMsg);
			}
		}

		private void buttonRemoveMeteor_Click(object sender, EventArgs e)
		{
			if (comboBoxMeteorName.Items.Count > 0)
			{
				customMessageSeqSel.Items.Remove(comboBoxMeteorName.SelectedItem);
				GlobalVar.MeteorColourType.RemoveAt(comboBoxMeteorName.SelectedIndex);
				GlobalVar.MeteorCount.RemoveAt(comboBoxMeteorName.SelectedIndex);
				GlobalVar.MeteorTrailLength.RemoveAt(comboBoxMeteorName.SelectedIndex);
				GlobalVar.MeteorSpeed.RemoveAt(comboBoxMeteorName.SelectedIndex);
				GlobalVar.MeteorRandomEnable.RemoveAt(comboBoxMeteorName.SelectedIndex);
				GlobalVar.MeteorColourEnable1.RemoveAt(comboBoxMeteorName.SelectedIndex);
				GlobalVar.MeteorColourEnable2.RemoveAt(comboBoxMeteorName.SelectedIndex);
				GlobalVar.MeteorColourEnable3.RemoveAt(comboBoxMeteorName.SelectedIndex);
				GlobalVar.MeteorColourEnable4.RemoveAt(comboBoxMeteorName.SelectedIndex);
				GlobalVar.MeteorColourEnable5.RemoveAt(comboBoxMeteorName.SelectedIndex);
				GlobalVar.MeteorColourEnable6.RemoveAt(comboBoxMeteorName.SelectedIndex);
				GlobalVar.MeteorColour1.RemoveAt(comboBoxMeteorName.SelectedIndex);
				GlobalVar.MeteorColour2.RemoveAt(comboBoxMeteorName.SelectedIndex);
				GlobalVar.MeteorColour3.RemoveAt(comboBoxMeteorName.SelectedIndex);
				GlobalVar.MeteorColour4.RemoveAt(comboBoxMeteorName.SelectedIndex);
				GlobalVar.MeteorColour5.RemoveAt(comboBoxMeteorName.SelectedIndex);
				GlobalVar.MeteorColour6.RemoveAt(comboBoxMeteorName.SelectedIndex);
				comboBoxMeteorName.Items.RemoveAt(comboBoxMeteorName.SelectedIndex);
				customMessageSeqSel.SelectedIndex = 0;
				if (comboBoxMeteorName.Items.Count > 0)
                {
					comboBoxMeteorName.SelectedIndex = 0;
					MeteorColour.Text = GlobalVar.MeteorColourType[0];
					MeteorCount.Value = GlobalVar.SnowFlakeMax[0];
					MeteorTrailLength.Value = GlobalVar.MeteorTrailLength[0];
					trackBarSpeedSnowFlakes.Value = GlobalVar.MeteorSpeed[0];
					checkBoxRandom3.Checked = GlobalVar.MeteorRandomEnable[0];
					checkBoxMeteorColour1.Checked = GlobalVar.MeteorColourEnable1[0];
					checkBoxMeteorColour2.Checked = GlobalVar.MeteorColourEnable2[0];
					checkBoxMeteorColour3.Checked = GlobalVar.MeteorColourEnable3[0];
					checkBoxMeteorColour4.Checked = GlobalVar.MeteorColourEnable4[0];
					checkBoxMeteorColour5.Checked = GlobalVar.MeteorColourEnable5[0];
					checkBoxMeteorColour6.Checked = GlobalVar.MeteorColourEnable6[0];
					MeteorColour1.BackColor = Color.FromArgb(Convert.ToInt32(GlobalVar.MeteorColour1[0]));
					MeteorColour2.BackColor = Color.FromArgb(Convert.ToInt32(GlobalVar.MeteorColour2[0]));
					MeteorColour3.BackColor = Color.FromArgb(Convert.ToInt32(GlobalVar.MeteorColour3[0]));
					MeteorColour4.BackColor = Color.FromArgb(Convert.ToInt32(GlobalVar.MeteorColour4[0]));
					MeteorColour5.BackColor = Color.FromArgb(Convert.ToInt32(GlobalVar.MeteorColour5[0]));
					MeteorColour6.BackColor = Color.FromArgb(Convert.ToInt32(GlobalVar.MeteorColour6[0]));
				}
                else
                {
					comboBoxMeteorName.Items.Clear();
					MeteorColour.Text = "Range";
					MeteorCount.Value = 11;
	                MeteorTrailLength.Value = 5;
					trackBarSpeedMeteors.Value = 5;
					checkBoxRandom3.Checked = true;
					checkBoxMeteorColour1.Checked = true;
					checkBoxMeteorColour2.Checked = false;
					checkBoxMeteorColour3.Checked = false;
					checkBoxMeteorColour4.Checked = false;
					checkBoxMeteorColour5.Checked = false;
					checkBoxMeteorColour6.Checked = false;
					MeteorColour1.BackColor = Color.FromArgb(-16776961);
					MeteorColour2.BackColor = Color.FromArgb(-65536);
					MeteorColour3.BackColor = Color.FromArgb(-16711936);
					MeteorColour4.BackColor = Color.FromArgb(-32640);
					MeteorColour5.BackColor = Color.FromArgb(-16776961);
					MeteorColour6.BackColor = Color.FromArgb(-65536);
                }
			}
			else
			{
				comboBoxMeteorName.Items.Clear();
				MeteorColour.Text = "Range";
				MeteorCount.Value = 11;
				MeteorTrailLength.Value = 12;
				trackBarSpeedMeteors.Value = 5;
				checkBoxRandom3.Checked = true;
				checkBoxMeteorColour1.Checked = true;
				checkBoxMeteorColour2.Checked = false;
				checkBoxMeteorColour3.Checked = false;
				checkBoxMeteorColour4.Checked = false;
				checkBoxMeteorColour5.Checked = false;
				checkBoxMeteorColour6.Checked = false;
				MeteorColour1.BackColor = Color.FromArgb(-16776961);
				MeteorColour2.BackColor = Color.FromArgb(-65536);
				MeteorColour3.BackColor = Color.FromArgb(-16711936);
				MeteorColour4.BackColor = Color.FromArgb(-32640);
				MeteorColour5.BackColor = Color.FromArgb(-16776961);
				MeteorColour6.BackColor = Color.FromArgb(-65536);
			}
        }

		private void CustomMeteorUpdate()
	    {
			if (comboBoxMeteorName.Items.Count != 0)
			{
				GlobalVar.MeteorColourType[comboBoxMeteorName.SelectedIndex] = MeteorColour.Text;
				GlobalVar.MeteorCount[comboBoxMeteorName.SelectedIndex] = Convert.ToInt16(MeteorCount.Value);
				GlobalVar.MeteorTrailLength[comboBoxMeteorName.SelectedIndex] = Convert.ToInt16(MeteorTrailLength.Value);
				GlobalVar.MeteorSpeed[comboBoxMeteorName.SelectedIndex] = trackBarSpeedMeteors.Value;
				GlobalVar.MeteorRandomEnable[comboBoxMeteorName.SelectedIndex] = checkBoxRandom3.Checked;
				GlobalVar.MeteorColourEnable1[comboBoxMeteorName.SelectedIndex] = checkBoxMeteorColour1.Checked;
				GlobalVar.MeteorColourEnable2[comboBoxMeteorName.SelectedIndex] = checkBoxMeteorColour2.Checked;
				GlobalVar.MeteorColourEnable3[comboBoxMeteorName.SelectedIndex] = checkBoxMeteorColour3.Checked;
				GlobalVar.MeteorColourEnable4[comboBoxMeteorName.SelectedIndex] = checkBoxMeteorColour4.Checked;
				GlobalVar.MeteorColourEnable5[comboBoxMeteorName.SelectedIndex] = checkBoxMeteorColour5.Checked;
				GlobalVar.MeteorColourEnable6[comboBoxMeteorName.SelectedIndex] = checkBoxMeteorColour6.Checked;
				GlobalVar.MeteorColour1[comboBoxMeteorName.SelectedIndex] = MeteorColour1.BackColor.ToArgb();
				GlobalVar.MeteorColour2[comboBoxMeteorName.SelectedIndex] = MeteorColour2.BackColor.ToArgb();
				GlobalVar.MeteorColour3[comboBoxMeteorName.SelectedIndex] = MeteorColour3.BackColor.ToArgb();
				GlobalVar.MeteorColour4[comboBoxMeteorName.SelectedIndex] = MeteorColour4.BackColor.ToArgb();
				GlobalVar.MeteorColour5[comboBoxMeteorName.SelectedIndex] = MeteorColour5.BackColor.ToArgb();
				GlobalVar.MeteorColour6[comboBoxMeteorName.SelectedIndex] = MeteorColour6.BackColor.ToArgb();
			}
	    }
		private void MeteorColour_SelectionChangeCommitted(object sender, EventArgs e)
		{
			CustomMeteorUpdate();
		}

		private void MeteorCount_MouseDown(object sender, MouseEventArgs e)
		{
			CustomMeteorUpdate();
		}

		private void MeteorCount_MouseClick(object sender, MouseEventArgs e)
		{
			CustomMeteorUpdate();
		}

		private void checkBoxMeteorColour1_Leave(object sender, EventArgs e)
		{
			CustomMeteorUpdate();
		}

		private void checkBoxMeteorColour2_Leave(object sender, EventArgs e)
		{
			CustomMeteorUpdate();
		}

		private void checkBoxMeteorColour3_Leave(object sender, EventArgs e)
		{
			CustomMeteorUpdate();
		}

		private void checkBoxMeteorColour4_Leave(object sender, EventArgs e)
		{
			CustomMeteorUpdate();
		}

		private void checkBoxMeteorColour5_Leave(object sender, EventArgs e)
		{
			CustomMeteorUpdate();
		}

		private void checkBoxMeteorColour6_Leave(object sender, EventArgs e)
		{
			CustomMeteorUpdate();
		}

		private void checkBoxRandom3_Leave(object sender, EventArgs e)
		{
			CustomMeteorUpdate();
		}

		private void trackBarSpeedMeteors_MouseLeave(object sender, EventArgs e)
		{
			CustomMeteorUpdate();
		}

		private void buttonPlayMeteor_Click(object sender, EventArgs e)
		{
			StopSequence();
			if (!GlobalVar.PlayCustomMessage)
			{
				Stop_Vixen();
				PlayCustomSeq();
				Start_Vixen();
			}
			else
			{
				PlayCustomSeq();
			}
		}

#endregion

#region Multiple SnowFlakes
		private void comboBoxSnowFlakeName_SelectedIndexChanged(object sender, EventArgs e)
		{
			CustomSnowFlakes();
		}

		private void CustomSnowFlakes()
		{
			var selectedItem = comboBoxSnowFlakeName.SelectedIndex;
			EffectType.Value = GlobalVar.SnowFlakeEffectType[selectedItem];
			MaxSnowFlake.Value = GlobalVar.SnowFlakeMax[selectedItem];
			trackBarSpeedSnowFlakes.Value = GlobalVar.SnowFlakeSpeed[selectedItem];
			checkBoxRandom1.Checked = GlobalVar.SnowFlakeRandomEnable[selectedItem];
			checkBoxSnowFlakeColour1.Checked = GlobalVar.SnowFlakeColourEnable1[selectedItem];
			checkBoxSnowFlakeColour2.Checked = GlobalVar.SnowFlakeColourEnable2[selectedItem];
			checkBoxSnowFlakeColour3.Checked = GlobalVar.SnowFlakeColourEnable3[selectedItem];
			checkBoxSnowFlakeColour4.Checked = GlobalVar.SnowFlakeColourEnable4[selectedItem];
			checkBoxSnowFlakeColour5.Checked = GlobalVar.SnowFlakeColourEnable5[selectedItem];
			checkBoxSnowFlakeColour6.Checked = GlobalVar.SnowFlakeColourEnable6[selectedItem];
			SnowFlakeColour1.BackColor = Color.FromArgb(Convert.ToInt32(GlobalVar.SnowFlakeColour1[selectedItem]));
			SnowFlakeColour2.BackColor = Color.FromArgb(Convert.ToInt32(GlobalVar.SnowFlakeColour2[selectedItem]));
			SnowFlakeColour3.BackColor = Color.FromArgb(Convert.ToInt32(GlobalVar.SnowFlakeColour3[selectedItem]));
			SnowFlakeColour4.BackColor = Color.FromArgb(Convert.ToInt32(GlobalVar.SnowFlakeColour4[selectedItem]));
			SnowFlakeColour5.BackColor = Color.FromArgb(Convert.ToInt32(GlobalVar.SnowFlakeColour5[selectedItem]));
			SnowFlakeColour6.BackColor = Color.FromArgb(Convert.ToInt32(GlobalVar.SnowFlakeColour6[selectedItem]));
		}

		private void buttonAddSnowFlake_Click(object sender, EventArgs e)
		{
			var addCustomMsg = "SnowFlake - " + Interaction.InputBox("Enter a Name for your Custom SnowFlakes", "Custom SnowFlake");
			if (addCustomMsg != "")
			{
				GlobalVar.SnowFlakeEffectType.Add(2);
				GlobalVar.SnowFlakeMax.Add(3);
				GlobalVar.SnowFlakeSpeed.Add(5);
				GlobalVar.SnowFlakeRandomEnable.Add(true);
				GlobalVar.SnowFlakeColourEnable1.Add(true);
				GlobalVar.SnowFlakeColourEnable2.Add(false);
				GlobalVar.SnowFlakeColourEnable3.Add(false);
				GlobalVar.SnowFlakeColourEnable4.Add(false);
				GlobalVar.SnowFlakeColourEnable5.Add(false);
				GlobalVar.SnowFlakeColourEnable6.Add(false);
				GlobalVar.SnowFlakeColour1.Add(Convert.ToInt32(-16776961));
				GlobalVar.SnowFlakeColour2.Add(Convert.ToInt32(-65536));
				GlobalVar.SnowFlakeColour3.Add(Convert.ToInt32(-16711936));
				GlobalVar.SnowFlakeColour4.Add(Convert.ToInt32(-32640));
				GlobalVar.SnowFlakeColour5.Add(Convert.ToInt32(-16711936));
				GlobalVar.SnowFlakeColour6.Add(Convert.ToInt32(-32640));
				comboBoxSnowFlakeName.Items.Add(addCustomMsg);
				comboBoxSnowFlakeName.SelectedIndex = comboBoxSnowFlakeName.Items.Count - 1;
				customMessageSeqSel.Items.Add(addCustomMsg);
			}
		}

		private void buttonRemoveSnowFlake_Click(object sender, EventArgs e)
		{
			if (comboBoxSnowFlakeName.Items.Count > 0)
			{
				customMessageSeqSel.Items.Remove(comboBoxSnowFlakeName.SelectedItem);
				GlobalVar.SnowFlakeEffectType.RemoveAt(comboBoxSnowFlakeName.SelectedIndex);
				GlobalVar.SnowFlakeMax.RemoveAt(comboBoxSnowFlakeName.SelectedIndex);
				GlobalVar.SnowFlakeSpeed.RemoveAt(comboBoxSnowFlakeName.SelectedIndex);
				GlobalVar.SnowFlakeRandomEnable.RemoveAt(comboBoxSnowFlakeName.SelectedIndex);
				GlobalVar.SnowFlakeColourEnable1.RemoveAt(comboBoxSnowFlakeName.SelectedIndex);
				GlobalVar.SnowFlakeColourEnable2.RemoveAt(comboBoxSnowFlakeName.SelectedIndex);
				GlobalVar.SnowFlakeColourEnable3.RemoveAt(comboBoxSnowFlakeName.SelectedIndex);
				GlobalVar.SnowFlakeColourEnable4.RemoveAt(comboBoxSnowFlakeName.SelectedIndex);
				GlobalVar.SnowFlakeColourEnable5.RemoveAt(comboBoxSnowFlakeName.SelectedIndex);
				GlobalVar.SnowFlakeColourEnable6.RemoveAt(comboBoxSnowFlakeName.SelectedIndex);
				GlobalVar.SnowFlakeColour1.RemoveAt(comboBoxSnowFlakeName.SelectedIndex);
				GlobalVar.SnowFlakeColour2.RemoveAt(comboBoxSnowFlakeName.SelectedIndex);
				GlobalVar.SnowFlakeColour3.RemoveAt(comboBoxSnowFlakeName.SelectedIndex);
				GlobalVar.SnowFlakeColour4.RemoveAt(comboBoxSnowFlakeName.SelectedIndex);
				GlobalVar.SnowFlakeColour5.RemoveAt(comboBoxSnowFlakeName.SelectedIndex);
				GlobalVar.SnowFlakeColour6.RemoveAt(comboBoxSnowFlakeName.SelectedIndex);
				comboBoxSnowFlakeName.Items.RemoveAt(comboBoxSnowFlakeName.SelectedIndex);
				customMessageSeqSel.SelectedIndex = 0;
				if (comboBoxSnowFlakeName.Items.Count > 0)
				{
					comboBoxSnowFlakeName.SelectedIndex = 0;
					EffectType.Value = GlobalVar.SnowFlakeEffectType[0];
					MaxSnowFlake.Value = GlobalVar.SnowFlakeMax[0];
					trackBarSpeedSnowFlakes.Value = GlobalVar.SnowFlakeSpeed[0];
					checkBoxRandom1.Checked = GlobalVar.SnowFlakeRandomEnable[0];
					checkBoxSnowFlakeColour1.Checked = GlobalVar.SnowFlakeColourEnable1[0];
					checkBoxSnowFlakeColour2.Checked = GlobalVar.SnowFlakeColourEnable2[0];
					checkBoxSnowFlakeColour3.Checked = GlobalVar.SnowFlakeColourEnable3[0];
					checkBoxSnowFlakeColour4.Checked = GlobalVar.SnowFlakeColourEnable4[0];
					checkBoxSnowFlakeColour5.Checked = GlobalVar.SnowFlakeColourEnable5[0];
					checkBoxSnowFlakeColour6.Checked = GlobalVar.SnowFlakeColourEnable6[0];
					SnowFlakeColour1.BackColor = Color.FromArgb(Convert.ToInt32(GlobalVar.SnowFlakeColour1[0]));
					SnowFlakeColour2.BackColor = Color.FromArgb(Convert.ToInt32(GlobalVar.SnowFlakeColour2[0]));
					SnowFlakeColour3.BackColor = Color.FromArgb(Convert.ToInt32(GlobalVar.SnowFlakeColour3[0]));
					SnowFlakeColour4.BackColor = Color.FromArgb(Convert.ToInt32(GlobalVar.SnowFlakeColour4[0]));
					SnowFlakeColour5.BackColor = Color.FromArgb(Convert.ToInt32(GlobalVar.SnowFlakeColour5[0]));
					SnowFlakeColour6.BackColor = Color.FromArgb(Convert.ToInt32(GlobalVar.SnowFlakeColour6[0]));
				}
				else
				{
					comboBoxSnowFlakeName.Items.Clear();
					EffectType.Value = 2;
					MaxSnowFlake.Value = 3;
					trackBarSpeedSnowFlakes.Value = 5;
					checkBoxRandom1.Checked = true;
					checkBoxSnowFlakeColour1.Checked = true;
					checkBoxSnowFlakeColour2.Checked = false;
					checkBoxSnowFlakeColour3.Checked = false;
					checkBoxSnowFlakeColour4.Checked = false;
					checkBoxSnowFlakeColour5.Checked = false;
					checkBoxSnowFlakeColour6.Checked = false;
					SnowFlakeColour1.BackColor = Color.FromArgb(-16776961);
					SnowFlakeColour2.BackColor = Color.FromArgb(-65536);
					SnowFlakeColour3.BackColor = Color.FromArgb(-16711936);
					SnowFlakeColour4.BackColor = Color.FromArgb(-32640);
					SnowFlakeColour5.BackColor = Color.FromArgb(-16776961);
					SnowFlakeColour6.BackColor = Color.FromArgb(-65536);
				}
			}
			else
			{
				comboBoxSnowFlakeName.Items.Clear();
				EffectType.Value = 2;
				MaxSnowFlake.Value = 3;
				trackBarSpeedSnowFlakes.Value = 5;
				checkBoxRandom1.Checked = true;
				checkBoxSnowFlakeColour1.Checked = true;
				checkBoxSnowFlakeColour2.Checked = false;
				checkBoxSnowFlakeColour3.Checked = false;
				checkBoxSnowFlakeColour4.Checked = false;
				checkBoxSnowFlakeColour5.Checked = false;
				checkBoxSnowFlakeColour6.Checked = false;
				SnowFlakeColour1.BackColor = Color.FromArgb(-16776961);
				SnowFlakeColour2.BackColor = Color.FromArgb(-65536);
				SnowFlakeColour3.BackColor = Color.FromArgb(-16711936);
				SnowFlakeColour4.BackColor = Color.FromArgb(-32640);
				SnowFlakeColour5.BackColor = Color.FromArgb(-16776961);
				SnowFlakeColour6.BackColor = Color.FromArgb(-65536);
			}
		}

		private void EffectType_MouseDown(object sender, MouseEventArgs e)
		{
			CustomSnowFlakeUpdate();
		}

		private void CustomSnowFlakeUpdate()
		{
			if (comboBoxSnowFlakeName.Items.Count != 0)
			{
				GlobalVar.SnowFlakeEffectType[comboBoxSnowFlakeName.SelectedIndex] = Convert.ToInt16(EffectType.Value);
				GlobalVar.SnowFlakeMax[comboBoxSnowFlakeName.SelectedIndex] = Convert.ToInt16(MaxSnowFlake.Value);
				GlobalVar.SnowFlakeSpeed[comboBoxSnowFlakeName.SelectedIndex] = trackBarSpeedSnowFlakes.Value;
				GlobalVar.SnowFlakeRandomEnable[comboBoxSnowFlakeName.SelectedIndex] = checkBoxRandom1.Checked;
				GlobalVar.SnowFlakeColourEnable1[comboBoxSnowFlakeName.SelectedIndex] = checkBoxSnowFlakeColour1.Checked;
				GlobalVar.SnowFlakeColourEnable2[comboBoxSnowFlakeName.SelectedIndex] = checkBoxSnowFlakeColour2.Checked;
				GlobalVar.SnowFlakeColourEnable3[comboBoxSnowFlakeName.SelectedIndex] = checkBoxSnowFlakeColour3.Checked;
				GlobalVar.SnowFlakeColourEnable4[comboBoxSnowFlakeName.SelectedIndex] = checkBoxSnowFlakeColour4.Checked;
				GlobalVar.SnowFlakeColourEnable5[comboBoxSnowFlakeName.SelectedIndex] = checkBoxSnowFlakeColour5.Checked;
				GlobalVar.SnowFlakeColourEnable6[comboBoxSnowFlakeName.SelectedIndex] = checkBoxSnowFlakeColour6.Checked;
				GlobalVar.SnowFlakeColour1[comboBoxSnowFlakeName.SelectedIndex] = SnowFlakeColour1.BackColor.ToArgb();
				GlobalVar.SnowFlakeColour2[comboBoxSnowFlakeName.SelectedIndex] = SnowFlakeColour2.BackColor.ToArgb();
				GlobalVar.SnowFlakeColour3[comboBoxSnowFlakeName.SelectedIndex] = SnowFlakeColour3.BackColor.ToArgb();
				GlobalVar.SnowFlakeColour4[comboBoxSnowFlakeName.SelectedIndex] = SnowFlakeColour4.BackColor.ToArgb();
				GlobalVar.SnowFlakeColour5[comboBoxSnowFlakeName.SelectedIndex] = SnowFlakeColour5.BackColor.ToArgb();
				GlobalVar.SnowFlakeColour6[comboBoxSnowFlakeName.SelectedIndex] = SnowFlakeColour6.BackColor.ToArgb();
			}
		}

		private void EffectType_MouseClick(object sender, MouseEventArgs e)
		{
			CustomSnowFlakeUpdate();
		}

		private void MaxSnowFlake_MouseDown(object sender, MouseEventArgs e)
		{
			CustomSnowFlakeUpdate();
		}

		private void MaxSnowFlake_MouseClick(object sender, MouseEventArgs e)
		{
			CustomSnowFlakeUpdate();
		}

		private void checkBoxSnowFlakeColour1_Leave(object sender, EventArgs e)
		{
			CustomSnowFlakeUpdate();
		}

		private void checkBoxSnowFlakeColour2_Leave(object sender, EventArgs e)
		{
			CustomSnowFlakeUpdate();
		}

		private void checkBoxSnowFlakeColour3_Leave(object sender, EventArgs e)
		{
			CustomSnowFlakeUpdate();
		}

		private void checkBoxSnowFlakeColour4_Leave(object sender, EventArgs e)
		{
			CustomSnowFlakeUpdate();
		}

		private void checkBoxSnowFlakeColour5_Leave(object sender, EventArgs e)
		{
			CustomSnowFlakeUpdate();
		}

		private void checkBoxSnowFlakeColour6_Leave(object sender, EventArgs e)
		{
			CustomSnowFlakeUpdate();
		}

		private void checkBoxRandom1_Leave(object sender, EventArgs e)
		{
			CustomSnowFlakeUpdate();
		}

		private void trackBarSpeedSnowFlakes_MouseLeave(object sender, EventArgs e)
		{
			CustomSnowFlakeUpdate();
		}
		private void buttonPlaySnowFlake_Click(object sender, EventArgs e)
		{
			StopSequence();
			if (!GlobalVar.PlayCustomMessage)
			{
				Stop_Vixen();
				PlayCustomSeq();
				Start_Vixen();
			}
			else
			{
				PlayCustomSeq();
			}
		}

	    #endregion

#region Multiple Twinkles
		private void comboBoxTwinkleName_SelectedIndexChanged(object sender, EventArgs e)
		{
			CustomTwinkle();
		}

		private void CustomTwinkle()
		{
			var selectedItem = comboBoxTwinkleName.SelectedIndex;
			trackBarTwinkleLights.Value = GlobalVar.TwinkleLights[selectedItem];
			trackBarTwinkleSteps.Value = GlobalVar.TwinkleSteps[selectedItem];
			trackBarSpeedTwinkles.Value = GlobalVar.TwinkleSpeed[selectedItem];
			checkBoxRandom4.Checked = GlobalVar.TwinkleRandomEnable[selectedItem];
			checkBoxTwinkleColour1.Checked = GlobalVar.TwinkleColourEnable1[selectedItem];
			checkBoxTwinkleColour2.Checked = GlobalVar.TwinkleColourEnable2[selectedItem];
			checkBoxTwinkleColour3.Checked = GlobalVar.TwinkleColourEnable3[selectedItem];
			checkBoxTwinkleColour4.Checked = GlobalVar.TwinkleColourEnable4[selectedItem];
			checkBoxTwinkleColour5.Checked = GlobalVar.TwinkleColourEnable5[selectedItem];
			checkBoxTwinkleColour6.Checked = GlobalVar.TwinkleColourEnable6[selectedItem];
			TwinkleColour1.BackColor = Color.FromArgb(Convert.ToInt32(GlobalVar.TwinkleColour1[selectedItem]));
			TwinkleColour2.BackColor = Color.FromArgb(Convert.ToInt32(GlobalVar.TwinkleColour2[selectedItem]));
			TwinkleColour3.BackColor = Color.FromArgb(Convert.ToInt32(GlobalVar.TwinkleColour3[selectedItem]));
			TwinkleColour4.BackColor = Color.FromArgb(Convert.ToInt32(GlobalVar.TwinkleColour4[selectedItem]));
			TwinkleColour5.BackColor = Color.FromArgb(Convert.ToInt32(GlobalVar.TwinkleColour5[selectedItem]));
			TwinkleColour6.BackColor = Color.FromArgb(Convert.ToInt32(GlobalVar.TwinkleColour6[selectedItem]));
		}

		private void buttonAddTwinkle_Click(object sender, EventArgs e)
		{
			var addCustomMsg = "Twinkle - " + Interaction.InputBox("Enter a Name for your Custom Twinkle", "Custom Twinkle");
			if (addCustomMsg != "")
			{
				GlobalVar.TwinkleLights.Add(25);
				GlobalVar.TwinkleSteps.Add(20);
				GlobalVar.TwinkleSpeed.Add(1);
				GlobalVar.TwinkleRandomEnable.Add(true);
				GlobalVar.TwinkleColourEnable1.Add(true);
				GlobalVar.TwinkleColourEnable2.Add(false);
				GlobalVar.TwinkleColourEnable3.Add(false);
				GlobalVar.TwinkleColourEnable4.Add(false);
				GlobalVar.TwinkleColourEnable5.Add(false);
				GlobalVar.TwinkleColourEnable6.Add(false);
				GlobalVar.TwinkleColour1.Add(Convert.ToInt32(-16776961));
				GlobalVar.TwinkleColour2.Add(Convert.ToInt32(-65536));
				GlobalVar.TwinkleColour3.Add(Convert.ToInt32(-16711936));
				GlobalVar.TwinkleColour4.Add(Convert.ToInt32(-32640));
				GlobalVar.TwinkleColour5.Add(Convert.ToInt32(-16711936));
				GlobalVar.TwinkleColour6.Add(Convert.ToInt32(-32640));
				comboBoxTwinkleName.Items.Add(addCustomMsg);
				comboBoxTwinkleName.SelectedIndex = comboBoxTwinkleName.Items.Count - 1;
				customMessageSeqSel.Items.Add(addCustomMsg);
			}
		}

		private void buttonRemoveTwinkle_Click(object sender, EventArgs e)
		{
			if (comboBoxTwinkleName.Items.Count > 0)
			{
				customMessageSeqSel.Items.Remove(comboBoxTwinkleName.SelectedItem);
				GlobalVar.TwinkleLights.RemoveAt(comboBoxTwinkleName.SelectedIndex);
				GlobalVar.TwinkleSteps.RemoveAt(comboBoxTwinkleName.SelectedIndex);
				GlobalVar.TwinkleSpeed.RemoveAt(comboBoxTwinkleName.SelectedIndex);
				GlobalVar.TwinkleRandomEnable.RemoveAt(comboBoxTwinkleName.SelectedIndex);
				GlobalVar.TwinkleColourEnable1.RemoveAt(comboBoxTwinkleName.SelectedIndex);
				GlobalVar.TwinkleColourEnable2.RemoveAt(comboBoxTwinkleName.SelectedIndex);
				GlobalVar.TwinkleColourEnable3.RemoveAt(comboBoxTwinkleName.SelectedIndex);
				GlobalVar.TwinkleColourEnable4.RemoveAt(comboBoxTwinkleName.SelectedIndex);
				GlobalVar.TwinkleColourEnable5.RemoveAt(comboBoxTwinkleName.SelectedIndex);
				GlobalVar.TwinkleColourEnable6.RemoveAt(comboBoxTwinkleName.SelectedIndex);
				GlobalVar.TwinkleColour1.RemoveAt(comboBoxTwinkleName.SelectedIndex);
				GlobalVar.TwinkleColour2.RemoveAt(comboBoxTwinkleName.SelectedIndex);
				GlobalVar.TwinkleColour3.RemoveAt(comboBoxTwinkleName.SelectedIndex);
				GlobalVar.TwinkleColour4.RemoveAt(comboBoxTwinkleName.SelectedIndex);
				GlobalVar.TwinkleColour5.RemoveAt(comboBoxTwinkleName.SelectedIndex);
				GlobalVar.TwinkleColour6.RemoveAt(comboBoxTwinkleName.SelectedIndex);
				comboBoxTwinkleName.Items.RemoveAt(comboBoxTwinkleName.SelectedIndex);
				customMessageSeqSel.SelectedIndex = 0;
				if (comboBoxTwinkleName.Items.Count > 0)
				{
					comboBoxTwinkleName.SelectedIndex = 0;
					trackBarTwinkleLights.Value = GlobalVar.SnowFlakeMax[0];
					trackBarTwinkleSteps.Value = GlobalVar.TwinkleSteps[0];
					trackBarSpeedSnowFlakes.Value = GlobalVar.TwinkleSpeed[0];
					checkBoxRandom4.Checked = GlobalVar.TwinkleRandomEnable[0];
					checkBoxTwinkleColour1.Checked = GlobalVar.TwinkleColourEnable1[0];
					checkBoxTwinkleColour2.Checked = GlobalVar.TwinkleColourEnable2[0];
					checkBoxTwinkleColour3.Checked = GlobalVar.TwinkleColourEnable3[0];
					checkBoxTwinkleColour4.Checked = GlobalVar.TwinkleColourEnable4[0];
					checkBoxTwinkleColour5.Checked = GlobalVar.TwinkleColourEnable5[0];
					checkBoxTwinkleColour6.Checked = GlobalVar.TwinkleColourEnable6[0];
					TwinkleColour1.BackColor = Color.FromArgb(Convert.ToInt32(GlobalVar.TwinkleColour1[0]));
					TwinkleColour2.BackColor = Color.FromArgb(Convert.ToInt32(GlobalVar.TwinkleColour2[0]));
					TwinkleColour3.BackColor = Color.FromArgb(Convert.ToInt32(GlobalVar.TwinkleColour3[0]));
					TwinkleColour4.BackColor = Color.FromArgb(Convert.ToInt32(GlobalVar.TwinkleColour4[0]));
					TwinkleColour5.BackColor = Color.FromArgb(Convert.ToInt32(GlobalVar.TwinkleColour5[0]));
					TwinkleColour6.BackColor = Color.FromArgb(Convert.ToInt32(GlobalVar.TwinkleColour6[0]));
				}
				else
				{
					comboBoxTwinkleName.Items.Clear();
					trackBarTwinkleLights.Value = 25;
					trackBarTwinkleSteps.Value = 20;
					trackBarSpeedTwinkles.Value = 1;
					checkBoxRandom4.Checked = true;
					checkBoxTwinkleColour1.Checked = true;
					checkBoxTwinkleColour2.Checked = false;
					checkBoxTwinkleColour3.Checked = false;
					checkBoxTwinkleColour4.Checked = false;
					checkBoxTwinkleColour5.Checked = false;
					checkBoxTwinkleColour6.Checked = false;
					TwinkleColour1.BackColor = Color.FromArgb(-16776961);
					TwinkleColour2.BackColor = Color.FromArgb(-65536);
					TwinkleColour3.BackColor = Color.FromArgb(-16711936);
					TwinkleColour4.BackColor = Color.FromArgb(-32640);
					TwinkleColour5.BackColor = Color.FromArgb(-16776961);
					TwinkleColour6.BackColor = Color.FromArgb(-65536);
				}
			}
			else
			{
				comboBoxTwinkleName.Items.Clear();
				trackBarTwinkleLights.Value = 25;
				trackBarTwinkleSteps.Value = 20;
				trackBarSpeedTwinkles.Value = 1;
				checkBoxRandom4.Checked = true;
				checkBoxTwinkleColour1.Checked = true;
				checkBoxTwinkleColour2.Checked = false;
				checkBoxTwinkleColour3.Checked = false;
				checkBoxTwinkleColour4.Checked = false;
				checkBoxTwinkleColour5.Checked = false;
				checkBoxTwinkleColour6.Checked = false;
				TwinkleColour1.BackColor = Color.FromArgb(-16776961);
				TwinkleColour2.BackColor = Color.FromArgb(-65536);
				TwinkleColour3.BackColor = Color.FromArgb(-16711936);
				TwinkleColour4.BackColor = Color.FromArgb(-32640);
				TwinkleColour5.BackColor = Color.FromArgb(-16776961);
				TwinkleColour6.BackColor = Color.FromArgb(-65536);
			}
		}

		private void CustomTwinkleUpdate()
		{
			if (comboBoxTwinkleName.Items.Count != 0)
			{
				GlobalVar.TwinkleLights[comboBoxTwinkleName.SelectedIndex] = Convert.ToInt16(trackBarTwinkleLights.Value);
				GlobalVar.TwinkleSteps[comboBoxTwinkleName.SelectedIndex] = Convert.ToInt16(trackBarTwinkleSteps.Value);
				GlobalVar.TwinkleSpeed[comboBoxTwinkleName.SelectedIndex] = trackBarSpeedTwinkles.Value;
				GlobalVar.TwinkleRandomEnable[comboBoxTwinkleName.SelectedIndex] = checkBoxRandom4.Checked;
				GlobalVar.TwinkleColourEnable1[comboBoxTwinkleName.SelectedIndex] = checkBoxTwinkleColour1.Checked;
				GlobalVar.TwinkleColourEnable2[comboBoxTwinkleName.SelectedIndex] = checkBoxTwinkleColour2.Checked;
				GlobalVar.TwinkleColourEnable3[comboBoxTwinkleName.SelectedIndex] = checkBoxTwinkleColour3.Checked;
				GlobalVar.TwinkleColourEnable4[comboBoxTwinkleName.SelectedIndex] = checkBoxTwinkleColour4.Checked;
				GlobalVar.TwinkleColourEnable5[comboBoxTwinkleName.SelectedIndex] = checkBoxTwinkleColour5.Checked;
				GlobalVar.TwinkleColourEnable6[comboBoxTwinkleName.SelectedIndex] = checkBoxTwinkleColour6.Checked;
				GlobalVar.TwinkleColour1[comboBoxTwinkleName.SelectedIndex] = TwinkleColour1.BackColor.ToArgb();
				GlobalVar.TwinkleColour2[comboBoxTwinkleName.SelectedIndex] = TwinkleColour2.BackColor.ToArgb();
				GlobalVar.TwinkleColour3[comboBoxTwinkleName.SelectedIndex] = TwinkleColour3.BackColor.ToArgb();
				GlobalVar.TwinkleColour4[comboBoxTwinkleName.SelectedIndex] = TwinkleColour4.BackColor.ToArgb();
				GlobalVar.TwinkleColour5[comboBoxTwinkleName.SelectedIndex] = TwinkleColour5.BackColor.ToArgb();
				GlobalVar.TwinkleColour6[comboBoxTwinkleName.SelectedIndex] = TwinkleColour6.BackColor.ToArgb();
			}
		}

		private void checkBoxTwinkleColour1_Leave(object sender, EventArgs e)
		{
			CustomTwinkleUpdate();
		}

		private void checkBoxTwinkleColour2_Leave(object sender, EventArgs e)
		{
			CustomTwinkleUpdate();
		}

		private void checkBoxTwinkleColour3_Leave(object sender, EventArgs e)
		{
			CustomTwinkleUpdate();
		}

		private void checkBoxTwinkleColour4_Leave(object sender, EventArgs e)
		{
			CustomTwinkleUpdate();
		}

		private void checkBoxTwinkleColour5_Leave(object sender, EventArgs e)
		{
			CustomTwinkleUpdate();
		}

		private void checkBoxTwinkleColour6_Leave(object sender, EventArgs e)
		{
			CustomTwinkleUpdate();
		}

		private void checkBoxRandom4_Leave(object sender, EventArgs e)
		{
			CustomTwinkleUpdate();
		}

		private void trackBarLightsTwinkles_MouseLeave(object sender, EventArgs e)
		{
			CustomTwinkleUpdate();
		}

		private void trackBarStepsTwinkles_MouseLeave(object sender, EventArgs e)
		{
			CustomTwinkleUpdate();
		}

		private void trackBarSpeedTwinkles_MouseLeave(object sender, EventArgs e)
		{
			CustomTwinkleUpdate();
		}

		private void buttonPlayTwinkle_Click(object sender, EventArgs e)
		{
			StopSequence();
			if (!GlobalVar.PlayCustomMessage)
			{
				Stop_Vixen();
				PlayCustomSeq();
				Start_Vixen();
			}
			else
			{
				PlayCustomSeq();
			}
		}

		#endregion

#region Play Custom Sequence
		private void buttonPlayFire_Click(object sender, EventArgs e)
		{
			StopSequence();
			if (!GlobalVar.PlayCustomMessage)
			{
				Stop_Vixen();
				PlayCustomSeq();
				Start_Vixen();
			}
			else
			{
				PlayCustomSeq();
			}
		}

		private void buttonPlayMovie_Click(object sender, EventArgs e)
		{
			StopSequence();
			if (!GlobalVar.PlayCustomMessage)
			{
				Stop_Vixen();
				PlayCustomSeq();
				Start_Vixen();
			}
			else
			{
				PlayCustomSeq();
			}
		}

		private void buttonPlayGled_Click(object sender, EventArgs e)
		{
			StopSequence();
			if (!GlobalVar.PlayCustomMessage)
			{
				Stop_Vixen();
				PlayCustomSeq();
				Start_Vixen();
			}
			else
			{
				PlayCustomSeq();
			}
		}

		private void PlayCustomSeq()
		{
			bool blacklist;
			bool notWhitemsg;
			bool maxWordCount;
			string msg = "play sequence";
			SendMessageToVixen(msg, out blacklist, out notWhitemsg, out maxWordCount);
		}
		#endregion

	}
}
