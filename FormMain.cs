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

            bool vixenRunning = Process.GetProcesses().Any(clsProcess => clsProcess.ProcessName.Contains("VixenApplication"));
            if (!vixenRunning)
            {
                MessageBox.Show(@"Vixen 3 is Not currently running and must be open when Messages are being retrieved.");
            }
        }

        void StartChecking()
        { 
            //change to 2 when using VS
            int applicationInstance = Process.GetProcesses().Count(clsProcess => clsProcess.ProcessName.Contains("Vixen Messaging"));
            if (applicationInstance > 1)
            {
                MessageBox.Show(@"Vixen Messaging is already running. This instance will close");
                Application.Exit();
            }

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

#region Main Form
        private void timerCheckMail_Tick(object sender, EventArgs e)
        {
            
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

			timerCheckMail.Interval = Convert.ToInt16(GlobalVar.SeqIntervalTime + 5) * 1000;
            var headerphone = "";

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

            try
            {
                if (Pop3Login())
                {
                    int messageCount = _pop.GetMessageCount();
                    LogDisplay(GlobalVar.LogMsg = ("Message Count: " + messageCount));
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
                            if (header.Subject.Contains(textBoxSubjectHeader.Text)) //grabs the SMS header details from the form
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
                                    LogDisplay(GlobalVar.LogMsg = ("Retrieved Header # " + messageNum + ": " + header.Subject));
                                    try
                                        {
                                            smsMessage = msgLines[0];
                                            LogDisplay(GlobalVar.LogMsg = ("SMS Message: " + smsMessage));
                                            _pop.DeleteMessage(messageNum);
                                            // We only want one message at a time so, disconnect and wait for next time.
                                            _pop.Disconnect();
                                            SendMessageToVixen(smsMessage, out blacklist, out notWhitemsg);
                                            if (blacklist)
                                            {
                                                rtnmsg = "Please reframe from using inappropiate words. If this happens again your phone number will be banned for the night.";
                                                using (var file = new StreamWriter(@textBoxBlacklistEmailLog.Text, true))
                                                {
                                                    file.WriteLine(phoneNumber);
                                                }
                                                SendReturnText(phoneNumber, header.From.ToString(), rtnmsg, messageNum);
                                                return;
                                            }
                                            else
                                            {
                                                if (!notWhitemsg)
                                                {
                                                    rtnmsg = "Your message will appear soon in lights.";
                                                    SendReturnText(phoneNumber, header.From.ToString(), rtnmsg, messageNum);
                                                    return;
                                                }
                                                else
                                                {
                                                    rtnmsg = "Sorry one or more of the names you sent is not in the approved list!";
                                                    SendReturnText(phoneNumber, header.From.ToString(), rtnmsg, messageNum);
                                                }
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            LogDisplay(GlobalVar.LogMsg = ("Error Parsing Message Body: " + ex.Message));
                                        }
                                }
                                else
                                {
                                    _pop.DeleteMessage(messageNum);
                                    _pop.Disconnect();
                                    rtnmsg = "The body of your SMS is blank, please ensure the message you want to say in the body and not the subject line.";
                                    SendReturnText("", header.From.ToString(), rtnmsg, messageNum);
                                }
                            }
                            #endregion
                            else
    #region Email
                            {
                                if (!CheckBlacklistMessage(header.From.Address, header.Subject, headerphone))
                                {
                                    LogDisplay(GlobalVar.LogMsg = ("Retrieved Header # " + messageNum + ": " + header.Subject));
                                    try
                                    {
                                        string emailMessage = header.Subject;
                                        LogDisplay(GlobalVar.LogMsg = ("SMS Message: " + emailMessage));
                                        _pop.DeleteMessage(messageNum);
                                            // We only want one message at a time so, disconnect and wait for next time.
                                        _pop.Disconnect();
                                        SendMessageToVixen(emailMessage, out blacklist, out notWhitemsg);
                                        if (blacklist && !notWhitemsg)
                                        {
                                            rtnmsg = "Please reframe from using inappropiate words. If this happens again your email address will be banned for the night.";
                                            using (var file = new StreamWriter(@textBoxBlacklistEmailLog.Text, true))
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
                                                rtnmsg = "Sorry one or more of the names you sent is not in the approved list!";
                                                SendReturnText("", header.From.ToString(), rtnmsg, messageNum);
                                            }
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                    LogDisplay(GlobalVar.LogMsg = ("Error Parsing Message Body: " + ex.Message));
                                    }
                                }
                            }
                            #endregion
                        }
                        else
                        {
                            //Banned from App
                            _pop.DeleteMessage(messageNum);
                            _pop.Disconnect();
                            rtnmsg = "You have been banned for the night for sending inappropiate words. Thank you for watching the lights on Northridge Rd.";
                            SendReturnText("", header.From.ToString(), rtnmsg, messageNum);
                        }
                    }
                        Application.DoEvents();
                    }
                }
            }
            catch (Exception ex)
            {
                LogDisplay(GlobalVar.LogMsg = (ex.Message));
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

#region Load Form
        private void FormMain_Load(object sender, EventArgs e)
        {
            LoadData();
            EmailSettings();

            File.Create(textBoxBlacklistEmailLog.Text).Close();
            var content = File.ReadAllText(GlobalVar.Blacklistlocation);
            richTextBoxBlacklist.Text = content;
            var content1 = File.ReadAllText(GlobalVar.Whitelistlocation);
            richTextBoxWhitelist.Text = content1;

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

            //Changes Position and Size of Group boxs in the Sequence Tab
            groupBoxSeqControl.Location = new Point(6, 35);
            tabControlSequence.Size = new Size(505, 170);
            groupBoxSeqControl.Size = new Size(510, 195);
            label26.Location = new Point(60, 240);
            listBoxLog1.Location = new Point(6, 280);
            listBoxLog1.Size = new Size(505, 240);

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

            StartChecking();
            if (checkBoxAutoStart.Checked == false)
            {
                Stop_Vixen();
            }
        }
#endregion
    
#region Load Data
        private void LoadData()
        {
            var profile = new XmlProfileSettings();
            textBoxServer.Text = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "POP3Server", "pop.gmail.com");
            textBoxUID.Text = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "UID", "");
            textBoxPWD.Text = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "Password", "");
            textBoxVixenFolder.Text = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "textBoxVixenFolder", Path.Combine(Environment.ExpandEnvironmentVariables("%userprofile%"), "Documents\\Vixen 3"));
            textBoxVixenServer.Text = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "VixenServer", "http://localhost:8888/api/play/playSequence");
            GlobalVar.Blacklistlocation = Path.Combine(Environment.ExpandEnvironmentVariables("%userprofile%") + "\\Documents\\Vixen 3 Messaging\\Blacklist.txt");
            GlobalVar.Whitelistlocation = Path.Combine(Environment.ExpandEnvironmentVariables("%userprofile%") + "\\Documents\\Vixen 3 Messaging\\Whitelist.txt"); 
            textBoxSequenceTemplate.Text = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "SequenceTemplate", Path.Combine(Environment.ExpandEnvironmentVariables("%userprofile%"), "Documents\\Vixen 3 Messaging"));
            textBoxOutputSequence.Text = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "OutputSequence", Path.Combine(Environment.ExpandEnvironmentVariables("%userprofile%"), "Documents\\Vixen 3\\Sequence\\VixenOut.tim"));
            textBoxGroupName.Text = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "GroupName", "Front Matrix");
            comboBoxString.Text = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "StringOrienation", "Horizontal");
            textBoxLogFileName.Text = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "LogMessageFile", Path.Combine(Environment.ExpandEnvironmentVariables("%userprofile%"), "Documents\\Vixen 3 Messaging\\Logs\\Message.log"));
            textBoxBlacklistEmailLog.Text = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "LogBlacklistFile", Path.Combine(Environment.ExpandEnvironmentVariables("%userprofile%"), "Documents\\Vixen 3 Messaging\\Logs\\Blacklist.log"));
            textBoxSubjectHeader.Text = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "SMSSubjectHeader", "SMS from");
            checkBoxEnableSqnctrl.Checked = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxSqnEnable", false);
            checkBoxAutoStart.Checked = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxAutoStart", true);
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
        }
        #endregion

#region Message to Vixen

        private void SendMessageToVixen(string msg, out bool blacklist, out bool notWhitemsg)
        {
            var notWhite = false;
            blacklist = false;
            try
            {
                var inputFolderName = textBoxSequenceTemplate.Text;
                var inputFileName = inputFolderName + "\\SequenceTemplate.tim";
                var fileText = File.ReadAllText(inputFileName);
                if (!HasBadWords(msg, out notWhite) && !notWhite)
                {
                    //Write message to Vixen
                    msg = msg.Replace("&", "&amp;");

                    switch (TextLineNumber.Value.ToString())
                    {
                        case "1":
                            fileText = fileText.Replace("NamePlaceholder1", msg);//replaces the text
                            fileText = fileText.Replace("NamePlaceholder2", "");//replaces the text
                            fileText = fileText.Replace("NamePlaceholder3", "");//replaces the text
                            fileText = fileText.Replace("NamePlaceholder4", "");//replaces the text
                            break;
                        case "2":
                            fileText = fileText.Replace("NamePlaceholder1", "");//replaces the text
                            fileText = fileText.Replace("NamePlaceholder2", msg);//replaces the text
                            fileText = fileText.Replace("NamePlaceholder3", "");//replaces the text
                            fileText = fileText.Replace("NamePlaceholder4", "");//replaces the text
                            break;
                        case "3":
                            fileText = fileText.Replace("NamePlaceholder1", "");//replaces the text
                            fileText = fileText.Replace("NamePlaceholder2", "");//replaces the text
                            fileText = fileText.Replace("NamePlaceholder3", msg);//replaces the text
                            fileText = fileText.Replace("NamePlaceholder4", "");//replaces the text
                            break;
                        case "4":
                            fileText = fileText.Replace("NamePlaceholder1", "");//replaces the text
                            fileText = fileText.Replace("NamePlaceholder2", "");//replaces the text
                            fileText = fileText.Replace("NamePlaceholder3", "");//replaces the text
                            fileText = fileText.Replace("NamePlaceholder4", msg);//replaces the text
                            break;
                    }
                    
                    fileText = fileText.Replace("Speed_Change", trackBarTextSpeed.Value.ToString());
                    fileText = fileText.Replace("TextPosition_Change", trackBarTextPosition.Value.ToString());

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
                            GlobalVar.SeqIntervalTime = newSeqTime + 1;
                        }
                        else
                        {
                            GlobalVar.SeqIntervalTime = Convert.ToDecimal(EffectTime.Value);
                        }

                        outputFileName = textBoxOutputSequence.Text;
                        fileText = fileText.Replace("NodeId_Change", textBoxNodeId.Text);//adds NodeId
                        fileText = fileText.Replace("StringOrienation_Change", comboBoxString.Text);
                        fileText = fileText.Replace("TextTime_Change", GlobalVar.SeqIntervalTime.ToString()); //Text Sequence time
                        fileText = fileText.Replace("SnowFlake_Change", EffectType.Value.ToString()); //Type
                        fileText = fileText.Replace("SnowFlakeMax_Change", MaxSnowFlake.Value.ToString()); //Max number
                        fileText = fileText.Replace("FireHeight_Change", FireHeight.Value.ToString()); //Fire height
                        fileText = fileText.Replace("MeteorType_Change", MeteorCount.Value.ToString()); //Type
                        fileText = fileText.Replace("MeteorTrailLength_Change", MeteorTrailLength.Value.ToString()); //Max number
                        fileText = fileText.Replace("FontName_Change", textBoxFont.Text);
                        fileText = fileText.Replace("FontSize_Change", textBoxFontSize.Text);
                        fileText = fileText.Replace("TwinkleLights_Change", trackBarTwinkleLights.Value.ToString());
                        fileText = fileText.Replace("TwinkleSteps_Change", trackBarTwinkleSteps.Value.ToString());

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

                        var textDirection = 0;
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
                        fileText = fileText.Replace("TextDirection_Change", textDirection.ToString());

                        String hexValue;
                        ColourSelect(out hexValue); //Colour Selection for Text. Random or Single
                            
                        var textColorNum = Convert.ToUInt32(hexValue, 16);
                        fileText = fileText.Replace("Colour1_Change", textColorNum.ToString());
                        fileText = fileText.Replace("PT20S", "PT" + GlobalVar.SeqIntervalTime.ToString() + "S"); //Sequence time

                        string selectedSeq;
                        //Random or selected Selection
                        if (checkBoxDisableSeq.Checked)
                        {
                            selectedSeq = "None";
                        }
                        else
                        {
                            if (checkBoxRandomSeqSelection.Checked)
                            {

                                var randomseq = new Random();
                                string[] mystrings =
                                {
                                    tabPageSnowFlake.Text, tabPageFire.Text, tabPageMeteors.Text,
                                    tabPageTwinkles.Text
                                };
                                selectedSeq = mystrings[randomseq.Next(mystrings.Length)];
                            }
                            else
                            {
                                selectedSeq = tabControlEffects.SelectedTab.Text;
                            }
                        }
                    
                        //Select an Effect
                        switch (selectedSeq)
                        {
                            case "SnowFlakes":
                                fileText = fileText.Replace("Speed_1Change", trackBarSpeedSnowFlakes.Value.ToString());
                                fileText = fileText.Replace("SnowFlakeTime_Change", GlobalVar.SeqIntervalTime.ToString()); //Sequence time
                                fileText = fileText.Replace("FireHeightTime_Change", "0"); //Sequence time
                                fileText = fileText.Replace("MeteorTime_Change", "0"); //Sequence time
                                fileText = fileText.Replace("TwinkleTime_Change", "0"); //Sequence time

                                hexValue = SnowFlakeColour1.BackColor.A.ToString("x2") + SnowFlakeColour1.BackColor.R.ToString("x2") + SnowFlakeColour1.BackColor.G.ToString("x2") + SnowFlakeColour1.BackColor.B.ToString("x2");
                                textColorNum = Convert.ToUInt32(hexValue, 16);
                                fileText = fileText.Replace("Colour_Change1", textColorNum.ToString()); //Colour
                                hexValue = SnowFlakeColour2.BackColor.A.ToString("x2") + SnowFlakeColour2.BackColor.R.ToString("x2") + SnowFlakeColour2.BackColor.G.ToString("x2") + SnowFlakeColour2.BackColor.B.ToString("x2");
                                textColorNum = Convert.ToUInt32(hexValue, 16);
                                fileText = fileText.Replace("Colour2_Change", textColorNum.ToString()); //Colour
                                hexValue = SnowFlakeColour3.BackColor.A.ToString("x2") + SnowFlakeColour3.BackColor.R.ToString("x2") + SnowFlakeColour3.BackColor.G.ToString("x2") + SnowFlakeColour3.BackColor.B.ToString("x2");
                                textColorNum = Convert.ToUInt32(hexValue, 16);
                                fileText = fileText.Replace("Colour3_Change", textColorNum.ToString()); //Colour
                                hexValue = SnowFlakeColour4.BackColor.A.ToString("x2") + SnowFlakeColour4.BackColor.R.ToString("x2") + SnowFlakeColour4.BackColor.G.ToString("x2") + SnowFlakeColour4.BackColor.B.ToString("x2");
                                textColorNum = Convert.ToUInt32(hexValue, 16);
                                fileText = fileText.Replace("Colour4_Change", textColorNum.ToString()); //Colour
                                hexValue = SnowFlakeColour5.BackColor.A.ToString("x2") + SnowFlakeColour5.BackColor.R.ToString("x2") + SnowFlakeColour5.BackColor.G.ToString("x2") + SnowFlakeColour5.BackColor.B.ToString("x2");
                                textColorNum = Convert.ToUInt32(hexValue, 16);
                                fileText = fileText.Replace("Colour5_Change", textColorNum.ToString()); //Colour
                                hexValue = SnowFlakeColour6.BackColor.A.ToString("x2") + SnowFlakeColour6.BackColor.R.ToString("x2") + SnowFlakeColour6.BackColor.G.ToString("x2") + SnowFlakeColour6.BackColor.B.ToString("x2");
                                textColorNum = Convert.ToUInt32(hexValue, 16);
                                fileText = fileText.Replace("Colour6_Change", textColorNum.ToString()); //Colour

                                fileText = fileText.Replace("CheckBox1_Change", checkBoxSnowFlakeColour1.Checked.ToString().ToLower()); //Colour Enabled true or False
                                fileText = fileText.Replace("CheckBox2_Change", checkBoxSnowFlakeColour2.Checked.ToString().ToLower()); //Colour Enabled true or False
                                fileText = fileText.Replace("CheckBox3_Change", checkBoxSnowFlakeColour3.Checked.ToString().ToLower()); //Colour Enabled true or False
                                fileText = fileText.Replace("CheckBox4_Change", checkBoxSnowFlakeColour4.Checked.ToString().ToLower()); //Colour Enabled true or False
                                fileText = fileText.Replace("CheckBox5_Change", checkBoxSnowFlakeColour5.Checked.ToString().ToLower()); //Colour Enabled true or False
                                fileText = fileText.Replace("CheckBox6_Change", checkBoxSnowFlakeColour6.Checked.ToString().ToLower()); //Colour Enabled true or False
                                break;

                            case "Fire":
                                fileText = fileText.Replace("Speed_1Change", "0");
                                fileText = fileText.Replace("FireHeightTime_Change", GlobalVar.SeqIntervalTime.ToString()); //Sequence time
                                fileText = fileText.Replace("MeteorTime_Change", "0"); //Sequence time
                                fileText = fileText.Replace("SnowFlakeTime_Change", "0"); //Sequence time
                                fileText = fileText.Replace("TwinkleTime_Change", "0"); //Sequence time

                                fileText = fileText.Replace("Colour_Change1", "0"); //Colour
                                fileText = fileText.Replace("Colour2_Change", "0"); //Colour
                                fileText = fileText.Replace("Colour3_Change", "0"); //Colour
                                fileText = fileText.Replace("Colour4_Change", "0"); //Colour
                                fileText = fileText.Replace("Colour5_Change", "0"); //Colour
                                fileText = fileText.Replace("Colour6_Change", "0"); //Colour
                                fileText = fileText.Replace("CheckBox1_Change", "true"); //Colour Enabled true or False
                                fileText = fileText.Replace("CheckBox2_Change", "false"); //Colour Enabled true or False
                                fileText = fileText.Replace("CheckBox3_Change", "false"); //Colour Enabled true or False
                                fileText = fileText.Replace("CheckBox4_Change", "false"); //Colour Enabled true or False
                                fileText = fileText.Replace("CheckBox5_Change", "false"); //Colour Enabled true or False
                                fileText = fileText.Replace("CheckBox6_Change", "false"); //Colour Enabled true or False
                                break;
                            case "Meteors":
                                fileText = fileText.Replace("Speed_1Change", trackBarSpeedMeteors.Value.ToString());
                                fileText = fileText.Replace("MeteorTime_Change", GlobalVar.SeqIntervalTime.ToString()); //Sequence time
                                fileText = fileText.Replace("SnowFlakeTime_Change", "0"); //Sequence time
                                fileText = fileText.Replace("FireHeightTime_Change", "0"); //Sequence time
                                fileText = fileText.Replace("TwinkleTime_Change", "0"); //Sequence time

                                hexValue = MeteorColour1.BackColor.A.ToString("x2") + MeteorColour1.BackColor.R.ToString("x2") + MeteorColour1.BackColor.G.ToString("x2") + MeteorColour1.BackColor.B.ToString("x2");
                                textColorNum = Convert.ToUInt32(hexValue, 16);
                                fileText = fileText.Replace("Colour_Change1", textColorNum.ToString()); //Colour
                                hexValue = MeteorColour2.BackColor.A.ToString("x2") + MeteorColour2.BackColor.R.ToString("x2") + MeteorColour2.BackColor.G.ToString("x2") + MeteorColour2.BackColor.B.ToString("x2");
                                textColorNum = Convert.ToUInt32(hexValue, 16);
                                fileText = fileText.Replace("Colour2_Change", textColorNum.ToString()); //Colour
                                hexValue = MeteorColour3.BackColor.A.ToString("x2") + MeteorColour3.BackColor.R.ToString("x2") + MeteorColour3.BackColor.G.ToString("x2") + MeteorColour3.BackColor.B.ToString("x2");
                                textColorNum = Convert.ToUInt32(hexValue, 16);
                                fileText = fileText.Replace("Colour3_Change", textColorNum.ToString()); //Colour
                                hexValue = MeteorColour4.BackColor.A.ToString("x2") + MeteorColour4.BackColor.R.ToString("x2") + MeteorColour4.BackColor.G.ToString("x2") + MeteorColour4.BackColor.B.ToString("x2");
                                textColorNum = Convert.ToUInt32(hexValue, 16);
                                fileText = fileText.Replace("Colour4_Change", textColorNum.ToString()); //Colour
                                hexValue = MeteorColour5.BackColor.A.ToString("x2") + MeteorColour5.BackColor.R.ToString("x2") + MeteorColour5.BackColor.G.ToString("x2") + MeteorColour5.BackColor.B.ToString("x2");
                                textColorNum = Convert.ToUInt32(hexValue, 16);
                                fileText = fileText.Replace("Colour5_Change", textColorNum.ToString()); //Colour
                                hexValue = MeteorColour6.BackColor.A.ToString("x2") + MeteorColour6.BackColor.R.ToString("x2") + MeteorColour6.BackColor.G.ToString("x2") + MeteorColour6.BackColor.B.ToString("x2");
                                textColorNum = Convert.ToUInt32(hexValue, 16);
                                fileText = fileText.Replace("Colour6_Change", textColorNum.ToString()); //Colour

                                fileText = fileText.Replace("CheckBox1_Change", checkBoxMeteorColour1.Checked.ToString().ToLower()); //Colour Enabled true or False
                                fileText = fileText.Replace("CheckBox2_Change", checkBoxMeteorColour2.Checked.ToString().ToLower()); //Colour Enabled true or False
                                fileText = fileText.Replace("CheckBox3_Change", checkBoxMeteorColour3.Checked.ToString().ToLower()); //Colour Enabled true or False
                                fileText = fileText.Replace("CheckBox4_Change", checkBoxMeteorColour4.Checked.ToString().ToLower()); //Colour Enabled true or False
                                fileText = fileText.Replace("CheckBox5_Change", checkBoxMeteorColour5.Checked.ToString().ToLower()); //Colour Enabled true or False
                                fileText = fileText.Replace("CheckBox6_Change", checkBoxMeteorColour6.Checked.ToString().ToLower()); //Colour Enabled true or False
                                break;
                            case "Twinkles":
                                fileText = fileText.Replace("Speed_1Change", trackBarSpeedTwinkles.Value.ToString());
                                fileText = fileText.Replace("TwinkleTime_Change", GlobalVar.SeqIntervalTime.ToString()); //Sequence time
                                fileText = fileText.Replace("SnowFlakeTime_Change", "0"); //Sequence time
                                fileText = fileText.Replace("FireHeightTime_Change", "0"); //Sequence time
                                fileText = fileText.Replace("MeteorTime_Change", "0"); //Sequence time

                                hexValue = TwinkleColour1.BackColor.A.ToString("x2") + TwinkleColour1.BackColor.R.ToString("x2") + TwinkleColour1.BackColor.G.ToString("x2") + TwinkleColour1.BackColor.B.ToString("x2");
                                textColorNum = Convert.ToUInt32(hexValue, 16);
                                fileText = fileText.Replace("Colour_Change1", textColorNum.ToString()); //Colour
                                hexValue = TwinkleColour2.BackColor.A.ToString("x2") + TwinkleColour2.BackColor.R.ToString("x2") + TwinkleColour2.BackColor.G.ToString("x2") + TwinkleColour2.BackColor.B.ToString("x2");
                                textColorNum = Convert.ToUInt32(hexValue, 16);
                                fileText = fileText.Replace("Colour2_Change", textColorNum.ToString()); //Colour
                                hexValue = TwinkleColour3.BackColor.A.ToString("x2") + TwinkleColour3.BackColor.R.ToString("x2") + TwinkleColour3.BackColor.G.ToString("x2") + TwinkleColour3.BackColor.B.ToString("x2");
                                textColorNum = Convert.ToUInt32(hexValue, 16);
                                fileText = fileText.Replace("Colour3_Change", textColorNum.ToString()); //Colour
                                hexValue = TwinkleColour4.BackColor.A.ToString("x2") + TwinkleColour4.BackColor.R.ToString("x2") + TwinkleColour4.BackColor.G.ToString("x2") + TwinkleColour4.BackColor.B.ToString("x2");
                                textColorNum = Convert.ToUInt32(hexValue, 16);
                                fileText = fileText.Replace("Colour4_Change", textColorNum.ToString()); //Colour
                                hexValue = TwinkleColour5.BackColor.A.ToString("x2") + TwinkleColour5.BackColor.R.ToString("x2") + TwinkleColour5.BackColor.G.ToString("x2") + TwinkleColour5.BackColor.B.ToString("x2");
                                textColorNum = Convert.ToUInt32(hexValue, 16);
                                fileText = fileText.Replace("Colour5_Change", textColorNum.ToString()); //Colour
                                hexValue = TwinkleColour6.BackColor.A.ToString("x2") + TwinkleColour6.BackColor.R.ToString("x2") + TwinkleColour6.BackColor.G.ToString("x2") + TwinkleColour6.BackColor.B.ToString("x2");
                                textColorNum = Convert.ToUInt32(hexValue, 16);
                                fileText = fileText.Replace("Colour6_Change", textColorNum.ToString()); //Colour

                                fileText = fileText.Replace("CheckBox1_Change", checkBoxTwinkleColour1.Checked.ToString().ToLower()); //Colour Enabled true or False
                                fileText = fileText.Replace("CheckBox2_Change", checkBoxTwinkleColour2.Checked.ToString().ToLower()); //Colour Enabled true or False
                                fileText = fileText.Replace("CheckBox3_Change", checkBoxTwinkleColour3.Checked.ToString().ToLower()); //Colour Enabled true or False
                                fileText = fileText.Replace("CheckBox4_Change", checkBoxTwinkleColour4.Checked.ToString().ToLower()); //Colour Enabled true or False
                                fileText = fileText.Replace("CheckBox5_Change", checkBoxTwinkleColour5.Checked.ToString().ToLower()); //Colour Enabled true or False
                                fileText = fileText.Replace("CheckBox6_Change", checkBoxTwinkleColour6.Checked.ToString().ToLower()); //Colour Enabled true or False
                                break;
                            case "None":
                                fileText = fileText.Replace("Speed_1Change", "0");
                                fileText = fileText.Replace("TwinkleTime_Change", "0"); //Sequence time
                                fileText = fileText.Replace("SnowFlakeTime_Change", "0"); //Sequence time
                                fileText = fileText.Replace("FireHeightTime_Change", "0"); //Sequence time
                                fileText = fileText.Replace("MeteorTime_Change", "0"); //Sequence time

                                fileText = fileText.Replace("Colour_Change1", "0"); //Colour
                                fileText = fileText.Replace("Colour2_Change", "0"); //Colour
                                fileText = fileText.Replace("Colour3_Change", "0"); //Colour
                                fileText = fileText.Replace("Colour4_Change", "0"); //Colour
                                fileText = fileText.Replace("Colour5_Change", "0"); //Colour
                                fileText = fileText.Replace("Colour6_Change", "0"); //Colour

                                fileText = fileText.Replace("CheckBox1_Change", "false"); //Colour Enabled true or False
                                fileText = fileText.Replace("CheckBox2_Change", "false"); //Colour Enabled true or False
                                fileText = fileText.Replace("CheckBox3_Change", "false"); //Colour Enabled true or False
                                fileText = fileText.Replace("CheckBox4_Change", "false"); //Colour Enabled true or False
                                fileText = fileText.Replace("CheckBox5_Change", "false"); //Colour Enabled true or False
                                fileText = fileText.Replace("CheckBox6_Change", "false"); //Colour Enabled true or False
                                break;
                        }
                        File.Delete(outputFileName);
                        File.WriteAllText(outputFileName, fileText);
                        if (checkBoxVariableLength.Checked)
                        {
                            timerCheckMail.Interval = Convert.ToInt16(GlobalVar.SeqIntervalTime)*1000;
                            timerCheckMail.Enabled = true;
                        }
                    }
              #endregion
                    else
                    {
                        //For Vixen Sequences
                        Mod_Vixen_Seq(msg);
                        outputFileName = textBoxOutputSequence.Text;
                    }
                    
                    var url = textBoxVixenServer.Text + "?name=" + WebUtility.UrlEncode(outputFileName);
                    var result = new WebClient().DownloadString(url); //Used to output to Vixen WebClient
                    LogDisplay(GlobalVar.LogMsg = ("Vixen Started: + " + result));
                    Log(msg);
                }
                else
                {
                    blacklist = true;
                }
            }
            catch (Exception ex)
            {
                LogDisplay(GlobalVar.LogMsg = (ex.Message));
                Log("Error: " + ex.Message);
                if (ex.Message.Contains("server"))
                {
                    MessageBox.Show(@"Warning - Check that Vixen Web Server is enabled and that Vixen 3 is running.", @"Warning");
                }
            }
            notWhitemsg = notWhite;
        }
#endregion

#region Send Return Text
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

#region Word Lists
        private bool HasBadWords(string msg, out bool notWhite)
        {
            string textLine;

            var rgx = new Regex("[^a-zA-Z0-9]");
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
                            Log((DateTime.Now.ToString("h:mm tt ")) + msg + ". Bad Words Detected!");
                            notWhite = false;
                            return true;
                        }
                    } while (file.Peek() != -1);
                    file.Close();
                    notWhite = false;
                    return false;
                }
            }
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
            LogDisplay(GlobalVar.LogMsg = ("One or more Names are not in Whitelist."));
            Log((DateTime.Now.ToString("h:mm tt ")) + msg + ". One or more Names are not in Whitelist.");
            notWhite = true;
            return true;
        }
#endregion

#region Check List Message
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

        #region Colour Dialog Box and colour settings

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
            int colNum = 21;
            ColPal(colNum);
        }

        private void SnowFlakeColour2_Click(object sender, EventArgs e)
        {
            int colNum = 22;
            ColPal(colNum);
        }

        private void SnowFlakeColour3_Click(object sender, EventArgs e)
        {
            int colNum = 23;
            ColPal(colNum);
        }

        private void SnowFlakeColour4_Click(object sender, EventArgs e)
        {
            int colNum = 24;
            ColPal(colNum);
        }

        private void SnowFlakeColour5_Click(object sender, EventArgs e)
        {
            int colNum = 25;
            ColPal(colNum);
        }

        private void SnowFlakeColour6_Click(object sender, EventArgs e)
        {
            int colNum = 26;
            ColPal(colNum);
        }

        private void MeteorColour1_Click(object sender, EventArgs e)
        {
            int colNum = 31;
            ColPal(colNum);
        }

        private void MeteorColour2_Click(object sender, EventArgs e)
        {
            int colNum = 32;
            ColPal(colNum);
        }

        private void MeteorColour3_Click(object sender, EventArgs e)
        {
            int colNum = 33;
            ColPal(colNum);
        }

        private void MeteorColour4_Click(object sender, EventArgs e)
        {
            int colNum = 34;
            ColPal(colNum);
        }

        private void MeteorColour5_Click(object sender, EventArgs e)
        {
            int colNum = 35;
            ColPal(colNum);
        }

        private void MeteorColour6_Click(object sender, EventArgs e)
        {
            int colNum = 36;
            ColPal(colNum);
        }

        private void TwinkleColour1_Click(object sender, EventArgs e)
        {
            int colNum = 41;
            ColPal(colNum);
        }

        private void TwinkleColour2_Click(object sender, EventArgs e)
        {
            int colNum = 42;
            ColPal(colNum);
        }

        private void TwinkleColour3_Click(object sender, EventArgs e)
        {
            int colNum = 43;
            ColPal(colNum);
        }

        private void TwinkleColour4_Click(object sender, EventArgs e)
        {
            int colNum = 44;
            ColPal(colNum);
        }

        private void TwinkleColour5_Click(object sender, EventArgs e)
        {
            int colNum = 45;
            ColPal(colNum);
        }

        private void TwinkleColour6_Click(object sender, EventArgs e)
        {
            int colNum = 46;
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
            switch (colNum)
            {
                case 1: TextColor1.BackColor = colorDialog1.Color;
                    break;
                case 2: TextColor2.BackColor = colorDialog1.Color;
                    break;
                case 3: TextColor3.BackColor = colorDialog1.Color;
                    break;
                case 4: TextColor4.BackColor = colorDialog1.Color;
                    break;
                case 5: TextColor5.BackColor = colorDialog1.Color;
                    break;
                case 6: TextColor6.BackColor = colorDialog1.Color;
                    break;
                case 7: TextColor7.BackColor = colorDialog1.Color;
                    break;
                case 8: TextColor8.BackColor = colorDialog1.Color;
                    break;
                case 9: TextColor9.BackColor = colorDialog1.Color;
                    break;
                case 10: TextColor10.BackColor = colorDialog1.Color;
                    break;
                case 11: SingleCol1.BackColor = colorDialog1.Color;
                    break;
                case 21: SnowFlakeColour1.BackColor = colorDialog1.Color;
                    break;
                case 22: SnowFlakeColour2.BackColor = colorDialog1.Color;
                    break;
                case 23: SnowFlakeColour3.BackColor = colorDialog1.Color;
                    break;
                case 24: SnowFlakeColour4.BackColor = colorDialog1.Color;
                    break;
                case 25: SnowFlakeColour5.BackColor = colorDialog1.Color;
                    break;
                case 26: SnowFlakeColour6.BackColor = colorDialog1.Color;
                    break;
                case 31: MeteorColour1.BackColor = colorDialog1.Color;
                    break;
                case 32: MeteorColour2.BackColor = colorDialog1.Color;
                    break;
                case 33: MeteorColour3.BackColor = colorDialog1.Color;
                    break;
                case 34: MeteorColour4.BackColor = colorDialog1.Color;
                    break;
                case 35: MeteorColour5.BackColor = colorDialog1.Color;
                    break;
                case 36: MeteorColour6.BackColor = colorDialog1.Color;
                    break;
                case 41: TwinkleColour1.BackColor = colorDialog1.Color;
                    break;
                case 42: TwinkleColour2.BackColor = colorDialog1.Color;
                    break;
                case 43: TwinkleColour3.BackColor = colorDialog1.Color;
                    break;
                case 44: TwinkleColour4.BackColor = colorDialog1.Color;
                    break;
                case 45: TwinkleColour5.BackColor = colorDialog1.Color;
                    break;
                case 46: TwinkleColour6.BackColor = colorDialog1.Color;
                    break;
            }
            SeqSave();
        }
        #endregion

        #region Colour Selection
        public void ColourSelect(out string hexValue)
        {
            var random = new Random(); 
        //    var RandomCol = random.Next(1, 10);
            if (checkBoxRandomCol.Checked)
            {
                do
                {
                    var randomCol = random.Next(1, 10);
                    switch (randomCol)
                    {
                        case 1: hexValue = TextColor1.BackColor.A.ToString("x2") + TextColor1.BackColor.R.ToString("x2") + TextColor1.BackColor.G.ToString("x2") + TextColor1.BackColor.B.ToString("x2");
                            break;
                        case 2: hexValue = TextColor2.BackColor.A.ToString("x2") + TextColor2.BackColor.R.ToString("x2") + TextColor2.BackColor.G.ToString("x2") + TextColor2.BackColor.B.ToString("x2");
                            break;
                        case 3: hexValue = TextColor3.BackColor.A.ToString("x2") + TextColor3.BackColor.R.ToString("x2") + TextColor3.BackColor.G.ToString("x2") + TextColor3.BackColor.B.ToString("x2");
                            break;
                        case 4: hexValue = TextColor4.BackColor.A.ToString("x2") + TextColor4.BackColor.R.ToString("x2") + TextColor4.BackColor.G.ToString("x2") + TextColor4.BackColor.B.ToString("x2");
                            break;
                        case 5: hexValue = TextColor5.BackColor.A.ToString("x2") + TextColor5.BackColor.R.ToString("x2") + TextColor5.BackColor.G.ToString("x2") + TextColor5.BackColor.B.ToString("x2");
                            break;
                        case 6: hexValue = TextColor6.BackColor.A.ToString("x2") + TextColor6.BackColor.R.ToString("x2") + TextColor6.BackColor.G.ToString("x2") + TextColor6.BackColor.B.ToString("x2");
                            break;
                        case 7: hexValue = TextColor7.BackColor.A.ToString("x2") + TextColor7.BackColor.R.ToString("x2") + TextColor7.BackColor.G.ToString("x2") + TextColor7.BackColor.B.ToString("x2");
                            break;
                        case 8: hexValue = TextColor8.BackColor.A.ToString("x2") + TextColor8.BackColor.R.ToString("x2") + TextColor8.BackColor.G.ToString("x2") + TextColor8.BackColor.B.ToString("x2");
                            break;
                        case 9: hexValue = TextColor9.BackColor.A.ToString("x2") + TextColor9.BackColor.R.ToString("x2") + TextColor9.BackColor.G.ToString("x2") + TextColor9.BackColor.B.ToString("x2");
                            break;
                        case 10: hexValue = TextColor2.BackColor.A.ToString("x2") + TextColor2.BackColor.R.ToString("x2") + TextColor2.BackColor.G.ToString("x2") + TextColor2.BackColor.B.ToString("x2");
                            break;
                        default: hexValue = TextColor10.BackColor.A.ToString("x2") + TextColor10.BackColor.R.ToString("x2") + TextColor10.BackColor.G.ToString("x2") + TextColor10.BackColor.B.ToString("x2");
                            break;
                    }
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

            switch (tabControlSequence.SelectedIndex)
            {
                case 0:
                    selection = textBoxSequenceLength1.Text;
                    break;
                case 1:
                    selection = textBoxSequenceLength2.Text;
                    break;
                case 2:
                    selection = textBoxSequenceLength3.Text;
                    break;
                case 3:
                    selection = textBoxSequenceLength4.Text;
                    break;
                case 4:
                    selection = textBoxSequenceLength5.Text;
                    break;
                case 5:
                    selection = textBoxSequenceLength6.Text;
                    break;
            }
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
            string seqNumber;
            string seqTime;
            LoadSeq(out seqNumber, out seqTime);
            if (seqNumber != "")
            {
                textBoxVixenSeq1.Text = seqNumber;
            }
            if (seqTime != "")
            {
                textBoxSequenceLength1.Text = seqTime;
            }
            SelectSeqTime();
        }

        private void buttonVixenSeq2_Click(object sender, EventArgs e)
        {
            string seqNumber;
            string seqTime;
            LoadSeq(out seqNumber, out seqTime);
            if (seqNumber != "")
            {
                textBoxVixenSeq2.Text = seqNumber;
            }
            if (seqTime != "")
            {
                textBoxSequenceLength2.Text = seqTime;
            }
            SelectSeqTime();
        }

        private void buttonVixenSeq3_Click(object sender, EventArgs e)
        {
            string seqNumber;
            string seqTime;
            LoadSeq(out seqNumber, out seqTime);
            if (seqNumber != "")
            {
                textBoxVixenSeq3.Text = seqNumber;
            }
            if (seqTime != "")
            {
                textBoxSequenceLength3.Text = seqTime;
            }
            SelectSeqTime();
        }
        private void buttonVixenSeq4_Click(object sender, EventArgs e)
        {
            string seqNumber;
            string seqTime;
            LoadSeq(out seqNumber, out seqTime);
            if (seqNumber != "")
            {
                textBoxVixenSeq4.Text = seqNumber;
            }
            if (seqTime != "")
            {
                textBoxSequenceLength4.Text = seqTime;
            }
            SelectSeqTime();
        }

        private void buttonVixenSeq5_Click(object sender, EventArgs e)
        {
            string seqNumber;
            string seqTime;
            LoadSeq(out seqNumber, out seqTime);
            if (seqNumber != "")
            {
                textBoxVixenSeq5.Text = seqNumber;
            }
            if (seqTime != "")
            {
                textBoxSequenceLength5.Text = seqTime;
            }
            SelectSeqTime();
        }
        private void buttonVixenSeq6_Click(object sender, EventArgs e)
        {
            string seqNumber;
            string seqTime;
            LoadSeq(out seqNumber, out seqTime);
            if (seqNumber != "")
            {
                textBoxVixenSeq6.Text = seqNumber;
            }
            if (seqTime != "")
            {
                textBoxSequenceLength6.Text = seqTime;
            }
            SelectSeqTime();
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
            String hexValue;
            string selectedSeq;
            var selectedSeqTime = "";
            var iii = 0;
            var randomseq = new Random();
            if (checkBoxRandomSeqSelection.Checked)
            {
                do
                {
                    string[] mystrings = { textBoxVixenSeq1.Text, textBoxVixenSeq2.Text, textBoxVixenSeq3.Text, textBoxVixenSeq4.Text, textBoxVixenSeq5.Text, textBoxVixenSeq6.Text };
                    selectedSeq = mystrings[randomseq.Next(mystrings.Length)];
                } while (selectedSeq == "" | iii++ < 200);

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
                selectedSeq = tabControlSequence.SelectedIndex.ToString();
                switch (selectedSeq)
                {
                    case "0":
                        selectedSeq = textBoxVixenSeq1.Text;
                        selectedSeqTime = textBoxSequenceLength1.Text;
                        break;
                    case "1": 
                        selectedSeq = textBoxVixenSeq2.Text;
                        selectedSeqTime = textBoxSequenceLength2.Text;
                        break;
                    case "2": 
                        selectedSeq = textBoxVixenSeq3.Text;
                        selectedSeqTime = textBoxSequenceLength3.Text;
                        break;
                    case "3": 
                        selectedSeq = textBoxVixenSeq4.Text;
                        selectedSeqTime = textBoxSequenceLength4.Text;
                        break;
                    case "4":
                        selectedSeq = textBoxVixenSeq5.Text;
                        selectedSeqTime = textBoxSequenceLength5.Text;
                        break;
                    case "5":
                        selectedSeq = textBoxVixenSeq6.Text;
                        selectedSeqTime = textBoxSequenceLength6.Text;
                        break;
                }
            }

			string seqTimeString;
			var selectedSeqTime1 = "";
			if (selectedSeqTime.Contains("M"))
			{
				//get time string of 1M23.345S for example and convert to seconds then add to Time Interval box.
				var index = selectedSeqTime.IndexOf(".");
				
				if (index > 0)
					selectedSeqTime1 = selectedSeqTime.Substring(0, index);
				seqTimeString = selectedSeqTime1.TrimEnd('.');
				seqTimeString = selectedSeqTime1.Replace("M", "");
				var length = seqTimeString.Length;
				var seqTimeString1 = seqTimeString.Remove(1, length - 1);
				int seqTimeString2 = Convert.ToInt16(seqTimeString1);
				seqTimeString2 = seqTimeString2 * 60;
				seqTimeString = seqTimeString.Remove(0, 1);
				seqTimeString = seqTimeString.Replace("S", "");
				int seqTimeString3 = Convert.ToInt16(seqTimeString);
				var newSeqTime = Convert.ToDecimal(seqTimeString2 + seqTimeString3);
				GlobalVar.SeqIntervalTime = newSeqTime + 15; // add 20 seconds to allow for the Sequence to finish before another check for messages is performed.
			}
			else
			{
				var index = selectedSeqTime.IndexOf(".");
				if (index > 0)
					selectedSeqTime1 = selectedSeqTime.Substring(0, index);
				seqTimeString = selectedSeqTime1.TrimEnd('.');
				seqTimeString = seqTimeString.Replace("S", "");
				var newSeqTime = Convert.ToDecimal(seqTimeString);
				GlobalVar.SeqIntervalTime = newSeqTime + 5; // add 10 seconds to allow for the Sequence to finish before another check for messages is performed.
			}

			timerCheckMail.Enabled = false;
			

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
            var fileText = File.ReadAllText(textBoxOutputSequence.Text);
            switch (TextLineNumber.Value.ToString()) //need to check
            {
                case "1":
                    fileText = fileText.Replace("NamePlaceholder1", msg);//replaces the text
                    fileText = fileText.Replace("NamePlaceholder2", "");//replaces the text
                    fileText = fileText.Replace("NamePlaceholder3", "");//replaces the text
                    fileText = fileText.Replace("NamePlaceholder4", "");//replaces the text
                    break;
                case "2":
                    fileText = fileText.Replace("NamePlaceholder1", "");//replaces the text
                    fileText = fileText.Replace("NamePlaceholder2", msg);//replaces the text
                    fileText = fileText.Replace("NamePlaceholder3", "");//replaces the text
                    fileText = fileText.Replace("NamePlaceholder4", "");//replaces the text
                    break;
                case "3":
                    fileText = fileText.Replace("NamePlaceholder1", "");//replaces the text
                    fileText = fileText.Replace("NamePlaceholder2", "");//replaces the text
                    fileText = fileText.Replace("NamePlaceholder3", msg);//replaces the text
                    fileText = fileText.Replace("NamePlaceholder4", "");//replaces the text
                    break;
                case "4":
                    fileText = fileText.Replace("NamePlaceholder1", "");//replaces the text
                    fileText = fileText.Replace("NamePlaceholder2", "");//replaces the text
                    fileText = fileText.Replace("NamePlaceholder3", "");//replaces the text
                    fileText = fileText.Replace("NamePlaceholder4", msg);//replaces the text
                    break;
            }
            ColourSelect(out hexValue); //Colour Selection for Text. Random or Single
            var textColorNum = Convert.ToUInt32(hexValue, 16);
            fileText = fileText.Replace("FontName_Change", textBoxFont.Text);
            fileText = fileText.Replace("FontSize_Change", textBoxFontSize.Text);
            fileText = fileText.Replace("Colour1_Change", textColorNum.ToString());
            fileText = fileText.Replace("Speed_Change", trackBarTextSpeed.Value.ToString());
            fileText = fileText.Replace("StringOrienation_Change", comboBoxString.Text);
            fileText = fileText.Replace("TextPosition_Change", trackBarTextPosition.Value.ToString());
            fileText = fileText.Replace("NodeId_Change", textBoxNodeId.Text);//adds NodeId
            fileText = fileText.Replace("TimeSpan_Change", selectedSeqTime); //Adjust Text effect to match Sequence length
            var textDirection = 0;
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
            fileText = fileText.Replace("TextDirection_Change", textDirection.ToString());
            File.Delete(textBoxOutputSequence.Text);
            File.WriteAllText(textBoxOutputSequence.Text, fileText);
			timerCheckMail.Interval = Convert.ToInt16(GlobalVar.SeqIntervalTime) * 1000; 
			timerCheckMail.Enabled = true;
        }
#endregion

#region Get Vixen Settings

    #region Get Vixen Server Settings
        private void GetServerSettings()
        {
         //   string str;
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
        //    RetrieveVixenSettings.SetDesktopLocation(this.Location.X + this.Size.Width, this.Location.Y);

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
            buttonStart.Image = Tools.GetIcon(Resources.StartB_W, 40);
            buttonStart.Text = "";
            buttonStop.Image = Tools.GetIcon(Resources.Stop, 40);
            buttonStop.Text = "";
            StartChecking();
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            Stop_Vixen();
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
            listBoxLog.Items.Insert(0, (DateTime.Now.ToString("h:mm tt ")) + logMsg);
            listBoxLog1.Items.Insert(0, (DateTime.Now.ToString("h:mm tt ")) + logMsg);
            listBoxLog2.Items.Insert(0, (DateTime.Now.ToString("h:mm tt ")) + logMsg);
        }
        #endregion
#endregion

#region Help Form
        private void buttonHelp_Click(object sender, EventArgs e)
        {
            HelpForm.Instance.Show();
            HelpForm.Instance.SetDesktopLocation(Location.X + Size.Width, Location.Y);
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
        }
#endregion

#region Save Data
        private void SeqSave()
        {
            int seqIntervalTime = decimal.ToInt16(GlobalVar.SeqIntervalTime);
            var profile = new XmlProfileSettings();
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "POP3Server", textBoxServer.Text);
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "UID", textBoxUID.Text);
            profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "Password", textBoxPWD.Text);
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
            MessageBox.Show(@"Blacklist saved!");
        }

        private void pictureBoxSaveWhitelist_Click(object sender, EventArgs e)
        {
            richTextBoxWhitelist.SaveFile(GlobalVar.Whitelistlocation, RichTextBoxStreamType.PlainText);
            MessageBox.Show(@"Whitelist saved!");
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
            GlobalVar.SeqIntervalTime = EffectTime.Value + 5;
        }
        
    }
}
#endregion