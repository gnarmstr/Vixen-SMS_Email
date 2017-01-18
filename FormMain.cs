using Vixen_Messaging.Theme;

#region System modules

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;
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
		
		private Form _msgTextSettings;

		private bool playCountDown;

		private static Random _random = new Random();

		public FormMain()
		{
			InitializeComponent();
			ClientSize = new Size(784, 1091);
			Location = new Point(100, 200);
			ForeColor = ThemeColorTable.ForeColor;
			BackColor = ThemeColorTable.BackgroundColor;
			ThemeUpdateControls.UpdateControls(this, new List<Control>(new[] { WebServerStatus}));
			menuStrip1.Renderer = new ThemeToolStripRenderer();
			saveToolStripMenuItem.Image = Resources.Save;
			closeToolStripMenuItem.Image = Resources.Close;
			twilioToolStripMenuItem.Image = Resources.Twilio;
			messagingToolStripMenuItem.Image = Resources.Message;
			textToolStripMenuItem.Image = Resources.Text;
			exportLogToolStripMenuItem.Image = Resources.Log;
			whiteBlackListsToolStripMenuItem.Image = Resources.Lists;
			WebServerStatus.ForeColor = Color.Black;
		}

		private void StartChecking()
		{
			buttonStart.Enabled = false;
			buttonStop.Enabled = true;
			timerCheckTwilio.Interval = 200;
			timerCheckTwilio.Enabled = true;
		}

		#endregion

#region Load Form

		private void FormMain_Load(object sender, EventArgs e)
		{
			GlobalVar.Sequential = 1;
			GlobalVar.SettingsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
				"Vixen Messaging");
			LoadData();

			//Ensures a backup of Whitelist, Blacklist and LocalMessages are made in the Appdata folder so a new installation does not remove them and users loose there changes.
			File.Create(GlobalVar.Blacklistlocation).Close();
			if (File.Exists(GlobalVar.Blacklistlocation + ".bkp"))
			{
				var copyfile = File.ReadAllText(GlobalVar.Blacklistlocation + ".bkp");
				if (copyfile != "")
					File.WriteAllText(GlobalVar.Blacklistlocation, copyfile);
				else
				{
					File.WriteAllText(GlobalVar.Blacklistlocation + ".bkp", Resources.Blacklist);
					File.WriteAllText(GlobalVar.Blacklistlocation, Resources.Blacklist);
				}
			}
			else
			{
				File.Create(GlobalVar.Blacklistlocation + ".bkp").Close();
				File.WriteAllText(GlobalVar.Blacklistlocation + ".bkp", Resources.Blacklist);
				File.WriteAllText(GlobalVar.Blacklistlocation, Resources.Blacklist);
			}
			if (File.Exists(GlobalVar.Whitelistlocation + ".bkp"))
			{
				var copyfile = File.ReadAllText(GlobalVar.Whitelistlocation + ".bkp");
				if (copyfile != "")
					File.WriteAllText(GlobalVar.Whitelistlocation, copyfile);
				else
				{
					File.WriteAllText(GlobalVar.Whitelistlocation + ".bkp", Resources.Whitelist);
					File.WriteAllText(GlobalVar.Whitelistlocation, Resources.Whitelist);
				}
			}
			else
			{
				File.Create(GlobalVar.Whitelistlocation + ".bkp").Close();
				File.WriteAllText(GlobalVar.Whitelistlocation + ".bkp", Resources.Whitelist);
				File.WriteAllText(GlobalVar.Whitelistlocation, Resources.Whitelist);
			}
			if (File.Exists(GlobalVar.LocalMessages + ".bkp"))
			{
				var copyfile = File.ReadAllText(GlobalVar.LocalMessages + ".bkp");
				File.WriteAllText(GlobalVar.LocalMessages, copyfile);
			}

			//if (comboBoxPlayMode.Text != "Random" && comboBoxPlayMode.Text != "Sequential")
			//{
			//	comboBoxPlayMode.Text = "Sequential";
			//}

			GlobalVar.Blacklist = File.ReadAllText(GlobalVar.Blacklistlocation);
			GlobalVar.Whitelist = File.ReadAllText(GlobalVar.Whitelistlocation);
		//	var content2 = File.ReadAllText(GlobalVar.LocalMessages);
		//	richTextBoxMessage.Text = content2;

			GlobalVar.Msgindex = 0;
			GlobalVar.PlayMessage = false;

			#region Initial Groups, Tab and Checkboxs are Visable/Enabled/Setup

			//Ensures correct groups are enabled or visable on first load.
			buttonStop.Enabled = false;

			#endregion

			#region Setup Button images and Icons

			//Setup Button images
			buttonStop.Image = Tools.GetIcon(Resources.Stop, 40);
			buttonStart.Image = Tools.GetIcon(Resources.StartB_W, 40);
			buttonStop.Image = Tools.GetIcon(Resources.Stop, 40);

			#endregion

			#region Check Vixen Port settings on startup

			try
			{
				//checks Vixen for port setting and compare to Vixen messaging
				string[] fullFile = File.ReadAllLines(GlobalVar.Vixen3Folder + "\\SystemData\\ModuleStore.xml");
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
				var messageBox = new MessageBoxForm(@"Vixen 3 User files do not appear to be in the default Documents folder or Vixen 3 is not Installed, Ensure you add the correct folder first or Install Vixen 3.", @"Vixen Files", MessageBoxButtons.OK, SystemIcons.Error);
				messageBox.ShowDialog();
			}

			#endregion

			StartChecking();
			if (GlobalVar.AutoStartMsgRetrieval == false)
			{
				Stop_Vixen();
			}
			//Will only display after first run from install.
			var profile = new XmlProfileSettings();
			string checkfirstload = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "checkfirstload", "True");
			if (checkfirstload == "True")
			{
				var messageBox = new MessageBoxForm(@"Welcome to Vixen Messaging, as this is the first time you have run Vixen Messaging you are required to setup the messaging system by going through the Settings.",
				"Welcome", MessageBoxButtons.OK, SystemIcons.Information);
				messageBox.ShowDialog();
				Stop_Vixen();
			}
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "checkfirstload", "False");
		}

		#endregion

#region Load Data

		private void LoadData()
		{
			var profile = new XmlProfileSettings();
			GlobalVar.Vixen3Folder = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "textBoxVixenFolder",
				Path.Combine(Environment.ExpandEnvironmentVariables("%userprofile%"), "Documents\\Vixen 3"));
			GlobalVar.VixenServer = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "VixenServer",
				"http://localhost:8888/api/play/playSequence");
			GlobalVar.Blacklistlocation = Path.Combine(GlobalVar.SettingsPath + "\\Blacklist.txt");
			GlobalVar.Whitelistlocation = Path.Combine(GlobalVar.SettingsPath + "\\Whitelist.txt");
			GlobalVar.LocalMessages = Path.Combine(GlobalVar.SettingsPath + "\\LocalMessages.txt");
			GlobalVar.SequenceTemplate = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "SequenceTemplate",
				Path.Combine(Environment.ExpandEnvironmentVariables("%userprofile%"), "Documents\\Vixen 3 Messaging"));
			GlobalVar.OutputSequenceFolder = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "OutputSequence",
				Path.Combine(Environment.ExpandEnvironmentVariables("%userprofile%"), "Documents\\Vixen 3\\Sequence\\VixenOut.tim"));
			GlobalVar.MessageLog = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "LogMessageFile",
				Path.Combine(Environment.ExpandEnvironmentVariables("%userprofile%"),
					"Documents\\Vixen 3 Messaging\\Logs\\Message.log"));
			GlobalVar.BlacklistLog = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "LogBlacklistFile",
				Path.Combine(Environment.ExpandEnvironmentVariables("%userprofile%"),
					"Documents\\Vixen 3 Messaging\\Logs\\Blacklist.log"));
			GlobalVar.AutoStartMsgRetrieval = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxAutoStart", false);
			GlobalVar.CenterStop = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxCenterStop", false);
			GlobalVar.CenterStop = GlobalVar.CenterStop;
			GlobalVar.CenterText = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxCenterText", false);
			GlobalVar.CenterText = GlobalVar.CenterText;
			GlobalVar.Black_WhiteSelection = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxBlack_list", "Blacklist");
			GlobalVar.IncomingMessageColourOption = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "IncomingMessageColourOption", 0);
			List<Color> defaultColor = new List<Color>() { Color.White, Color.Red, Color.LawnGreen, Color.Blue, Color.Orange, Color.Aqua, Color.BlueViolet, Color.DarkOliveGreen, Color.Yellow, Color.DodgerBlue };
			for (int i = 0; i < 10; i++)
			{
				GlobalVar.TextColor.Add(Color.FromArgb(profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "TextColor" + i, Convert.ToInt32(defaultColor[i].ToArgb()))));
			}
			GlobalVar.TextSpeed = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "trackBarTextSpeed", 1);
			GlobalVar.TextPosition = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "trackBarTextPosition", 0);
			GlobalVar.Intensity = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "trackBarIntensity", 100);
			GlobalVar.Font = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "textBoxFont", "Arial");
			GlobalVar.FontSize = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "textBoxFontSize", "10");
			GlobalVar.SeqIntervalTime = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "SeqIntervalTime", 10);
			GlobalVar.TextDirection = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "TextDirection", "Left");
			GlobalVar.StringOrientation = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "StringOrientation", "Horizontal");
			GlobalVar.GradientMode = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "GradientMode",
				"Across Text");
			GlobalVar.ReturnBannedMSG = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "ReturnBannedMSG",
				"Your mobile number has been recorded and has been banned for sending inappropiate words.");
			GlobalVar.ReturnWarningMSG = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "ReturnWarningMSG",
				"Please reframe from using inappropiate words. If this happens again your phone number will be banned.");
			GlobalVar.ReturnSuccessMSG = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "ReturnSuccessMSG",
				"Your message will appear soon in lights.");
			GlobalVar.IntervalMsgs = profile.GetSetting(XmlProfileSettings.SettingType.Profiles,
				"IntervalMsgs", 2);
			GlobalVar.TwilioSID = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "TwilioSID", "");
			GlobalVar.TwilioToken = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "TwilioToken", "");
			GlobalVar.TwilioPhoneNumber = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "TwilioPhoneNumber", "");
			GlobalVar.MaxWords = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "numericUpDownMaxWords", 0);
			GlobalVar.CountDownDate = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "dateCountDownString",
				"25/12/15");
			GlobalVar.CountDownMSG = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "CountDownMSG", "COUNTDOWN days to Christmas");
			checkBoxCountDown.Checked = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxCountDown", false);
			checkBoxVixenControl.Checked = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxVixenControl",
				false);
			GlobalVar.GroupName = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "GroupName", "");
			GlobalVar.GroupID = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "GroupID", "");

			//	GlobalVar.OutputSequenceFolder = textBoxVixenFolder.Text + "\\Sequence\\VixenOut.tim"; 

		}
		#endregion

#region Main Form

		private void timerCheckTwilio_Tick(object sender, EventArgs e)
		{
			timerCheckVixenEnabled.Enabled = true;
			//checks Vixen for port setting and compare to Vixen messaging
			try
			{
				string[] fullFile = File.ReadAllLines(GlobalVar.Vixen3Folder + "\\SystemData\\ModuleStore.xml");
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

			Cursor.Current = Cursors.WaitCursor;

			PlayModes();
		}

		#endregion

#region Play Mode

		#region Play Modes

		private void PlayModes()
		{
			if (checkBoxCountDown.Checked && !string.IsNullOrEmpty(GlobalVar.CountDownMSG))
			{
				var randomPlay = _random.Next(0, 15);
				if (randomPlay < 2)
				{
					PlayCountDown();
					timerCheckTwilio.Stop();
					timerCheckTwilio.Interval = Convert.ToInt16(GlobalVar.SeqIntervalTime + GlobalVar.IntervalMsgs)*1000;
					timerCheckTwilio.Start();
				}
			}
			
			PlayTwilio();
			timerCheckTwilio.Stop();
			timerCheckTwilio.Interval = Convert.ToInt16(GlobalVar.SeqIntervalTime + GlobalVar.IntervalMsgs) * 1000;
			timerCheckTwilio.Start();
		}

		#endregion

		#region Play with Twilio

		private void PlayCountDown()
		{
			bool blacklist, notWhitemsg, maxWordCount;

			playCountDown = true;
			SendMessageToVixen(GlobalVar.CountDownMSG, out blacklist, out notWhitemsg, out maxWordCount);
			playCountDown = false;
			LogDisplay(GlobalVar.LogMsg = ("Count down message has been displayed in lights."));
		}

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

				LogDisplay(GlobalVar.LogMsg = ("Checking Twilio Messages"));
				if (!CheckBlacklistMessage(messageFrom, messageBody, ""))
				{

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
								using (var file = new StreamWriter(GlobalVar.Blacklistlocation, true))
								{
									file.WriteLine(messageFrom);
								}
								SendReturnTextTwilio(messageFrom, "Auto Reply: " + GlobalVar.ReturnWarningMSG); //Banned message
								twilio.DeleteMessage(messageSid);
								ShortTimer();
								return;
							}
							if (!notWhitemsg)
							{
								if (!string.IsNullOrEmpty(GlobalVar.ReturnSuccessMSG))
									SendReturnTextTwilio(messageFrom, "Auto Reply: " + GlobalVar.ReturnSuccessMSG); //Success message.
								twilio.DeleteMessage(messageSid);
								return;
							}
						}
						else
						{
							SendReturnTextTwilio(messageFrom,
								"Auto Reply: Sorry, your message is too long and will not be display. Please reduce the number of words in your message to below " +
								(GlobalVar.MaxWords + 1) + " and resend. Thank you.");
							twilio.DeleteMessage(messageSid);
						}
						SendReturnTextTwilio(messageFrom,
							"Auto Reply: Sorry one or more of the names you sent is not in the approved list or you are using unapproved abbriviations! Your words have been recoreded and if found to be non offensive then they will be added to the list. Please try again on another day.");
						twilio.DeleteMessage(messageSid);
						ShortTimer();
						return;
					}
					twilio.DeleteMessage(messageSid);
					ShortTimer();
				}
				SendReturnTextTwilio(messageFrom, "Auto Reply: " + GlobalVar.ReturnBannedMSG);
				LogDisplay(GlobalVar.LogMsg = (messageFrom + " has been banned for sending inappropiate messages."));
				Log(" " + messageFrom + " has been banned for sending inappropiate messages.");
				twilio.DeleteMessage(messageSid);
			}
			catch
			{
				LogDisplay(GlobalVar.LogMsg = ("Unable to connect to the Twilio server or there are no messages on the server."));
				GlobalVar.SeqIntervalTime = 2;
				ShortTimer();
			}
		}

		#endregion

		#region Set Short Timer

		private void ShortTimer()
		{
			timerCheckTwilio.Interval = 200;
		}
		#endregion

	#region Count Down time
		private void CountDown(string msg, out string rtnmsg)
		{
			if (msg.Contains("COUNTDOWN") || checkBoxCountDown.Checked)
			{
				Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-AU");
				var daysLeft = DateTime.Parse(Convert.ToDateTime(GlobalVar.CountDownDate).ToShortDateString());
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


#endregion

#region Send Message to Vixen

		private void SendMessageToVixen(string msg, out bool blacklist, out bool notWhitemsg, out bool maxWordCount)
		{
			var notWhite = false;
			blacklist = false;
			try
			{
				var inputFolderName = GlobalVar.SequenceTemplate;
				var inputFileName = inputFolderName + "\\SequenceTemplate.tim";
				GlobalVar.FileText = File.ReadAllText(inputFileName);
				var msgWordCount = msg.Split(' ').Length;
				if ((GlobalVar.MaxWords != 0 & msgWordCount > GlobalVar.MaxWords) & !playCountDown)
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

					#region Custom Effects

					int totalCharacters = 0;
					foreach (char c in msg)
					{
						totalCharacters++;
					}

					if (msg != "play counter" & msg != "play sequence")
					{
						GlobalVar.SeqIntervalTime = Convert.ToDecimal(4 + (totalCharacters*0.25))*GlobalVar.TextSpeed;
							//Convert.ToDecimal(EffectTime.Value) + 1;
					}
					else
					{
						GlobalVar.SeqIntervalTime = Convert.ToDecimal(4 + (totalCharacters*0.25))*GlobalVar.TextSpeed;
							// Convert.ToDecimal(CustomMsgLength.Value) + 1;
					}

					outputFileName = GlobalVar.OutputSequenceFolder;

					TextSettings(msg);

					if (Convert.ToInt16(GlobalVar.SeqIntervalTime) == GlobalVar.SeqIntervalTime)
					{
						GlobalVar.FileText = GlobalVar.FileText.Replace("TextTime_Change",
							"PT" + GlobalVar.SeqIntervalTime.ToString() + ".00S");
						//Text Sequence time
						GlobalVar.FileText = GlobalVar.FileText.Replace("TextLength_Change",
							"PT" + GlobalVar.SeqIntervalTime.ToString() + ".00S");
						//Text Sequence time
					}
					else
					{
						GlobalVar.FileText = GlobalVar.FileText.Replace("TextTime_Change",
							"PT" + GlobalVar.SeqIntervalTime.ToString() + "S");
						//Text Sequence time
						GlobalVar.FileText = GlobalVar.FileText.Replace("TextLength_Change",
							"PT" + GlobalVar.SeqIntervalTime.ToString() + "S");
						//Text Sequence time
					}

					File.Delete(outputFileName);
					File.WriteAllText(outputFileName, GlobalVar.FileText);

					#endregion


					#region Send Play command to Vixen Web API

					var url = GlobalVar.VixenServer;
					try
					{

						var result = new WebClient().DownloadString(url + "?name=" + WebUtility.UrlEncode(outputFileName));
							//Used to output to Vixen WebClient
						LogDisplay(GlobalVar.LogMsg = ("Vixen Playing: + " + result));
					}
					catch
					{
					}
					//VIX-356
					try
					{
						var startSequence = "Name=VixenOut&FileName=VixenOut.tim";
						using (var wc = new WebClient())
						{
							wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
							wc.UploadString(url, startSequence);
							LogDisplay(GlobalVar.LogMsg = ("Vixen Playing:"));
						}

					}
					catch
					{
					}
					//				$.post('http://localhost/api/playplaySequence', sequence, null, 'JSON');


					Cursor.Current = Cursors.Default;

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
				if (ex.Message.Contains("server"))
				{
					var messageBox =
						new MessageBoxForm(@"Warning - Check that Vixen Web Server is enabled and that Vixen 3 is running.", @"Warning",
							MessageBoxButtons.OK, SystemIcons.Warning);
					messageBox.ShowDialog();
				}
				ShortTimer();
			}

			#endregion

			notWhitemsg = notWhite;
			maxWordCount = false;
		}

		#region Write to Sequence File Text Settings

		private void TextSettings(string msg)
		{
			string hexMultiValue;
			string hexMultiValue1;

			CountDown(msg, out msg);

			//Text Line Number
			GlobalVar.FileText = GlobalVar.FileText.Replace("NamePlaceholder1", msg);

			GlobalVar.FileText = GlobalVar.FileText.Replace("TextPosition_Change", GlobalVar.TextPosition.ToString());
			List<string> textDirection1 = new List<string>() { "Left", "Right", "Up", "Down" , "None"};
			if (GlobalVar.TextDirection == "Random")
			{
				var textDirection = _random.Next(0, 5);

				GlobalVar.FileText = GlobalVar.FileText.Replace("TextDirection_Change", textDirection1[textDirection]);
			}
			else
			{
				GlobalVar.FileText = GlobalVar.FileText.Replace("TextDirection_Change", GlobalVar.TextDirection);
			}
			GlobalVar.FileText = GlobalVar.FileText.Replace("NodeId_Change", GlobalVar.GroupID); //adds NodeId
			GlobalVar.FileText = GlobalVar.FileText.Replace("StringOrienation_Change", GlobalVar.StringOrientation);
			GlobalVar.FileText = GlobalVar.FileText.Replace("Speed_Change", GlobalVar.TextSpeed.ToString());
			GlobalVar.FileText = GlobalVar.FileText.Replace("Intensity_Change", GlobalVar.Intensity.ToString());
			GlobalVar.FileText = GlobalVar.FileText.Replace("FontName_Change", GlobalVar.Font);
			GlobalVar.FileText = GlobalVar.FileText.Replace("FontSize_Change", GlobalVar.FontSize);
			GlobalVar.FileText = GlobalVar.FileText.Replace("CenterStop_Change", (GlobalVar.CenterStop.ToString()).ToLower());
			GlobalVar.FileText = GlobalVar.FileText.Replace("CenterText_Change", (GlobalVar.CenterText.ToString()).ToLower());

			double X = 1, Y = 1, Z = 1;
			double X1 = 1, Y1 = 1, Z1 = 1;
			switch (GlobalVar.IncomingMessageColourOption)
			{
				case 0:
					hexMultiValue = GlobalVar.TextColor[1].A.ToString("x2") + GlobalVar.TextColor[1].R.ToString("x2") + GlobalVar.TextColor[1].G.ToString("x2") + GlobalVar.TextColor[1].B.ToString("x2");
					HEXToXYZ(hexMultiValue, out X, out Y, out Z);
					X1 = X;
					Y1 = Y;
					Z1 = Z;
					break;
				case 1:
					hexMultiValue = GlobalVar.TextColor[1].A.ToString("x2") + GlobalVar.TextColor[1].R.ToString("x2") + GlobalVar.TextColor[1].G.ToString("x2") + GlobalVar.TextColor[1].B.ToString("x2");
					hexMultiValue1 = GlobalVar.TextColor[2].A.ToString("x2") + GlobalVar.TextColor[2].R.ToString("x2") + GlobalVar.TextColor[2].G.ToString("x2") + GlobalVar.TextColor[2].B.ToString("x2");
					HEXToXYZ(hexMultiValue, out X, out Y, out Z);
					HEXToXYZ(hexMultiValue1, out X1, out Y1, out Z1);
					break;
				case 2:
					RandomColourSelect(out hexMultiValue);
					HEXToXYZ(hexMultiValue, out X, out Y, out Z);
					X1 = X;
					Y1 = Y;
					Z1 = Z;
					break;
			}

			GlobalVar.FileText = GlobalVar.FileText.Replace("GradientMode_Change", GlobalVar.GradientMode.Replace(" ", ""));
			GlobalVar.FileText = GlobalVar.FileText.Replace("Color_ChangeX1", X1.ToString());
			GlobalVar.FileText = GlobalVar.FileText.Replace("Color_ChangeY1", Y1.ToString());
			GlobalVar.FileText = GlobalVar.FileText.Replace("Color_ChangeZ1", Z1.ToString());
			GlobalVar.FileText = GlobalVar.FileText.Replace("Color_ChangeX", X.ToString());
			GlobalVar.FileText = GlobalVar.FileText.Replace("Color_ChangeY", Y.ToString());
			GlobalVar.FileText = GlobalVar.FileText.Replace("Color_ChangeZ", Z.ToString());
			Thread.Sleep(300);
		}

		#endregion

#endregion

		#region Convert Color to XYZ
		public void HEXToXYZ(string hexMultiValue, out double X, out double Y, out double Z)
		{
			Color color = ColorTranslator.FromHtml("#" + hexMultiValue);

			float r = ((float)color.R / 255); //R from 0 to 255
			float g = ((float)color.G / 255); //G from 0 to 255
			float b = ((float)color.B / 255); //B from 0 to 255

			if (r > 0.04045f) r = (float)Math.Pow((r + 0.055) / 1.055, 2.4);
			else r = r / 12.92f;
			if (g > 0.04045) g = (float)Math.Pow((g + 0.055f) / 1.055f, 2.4f);
			else g = g / 12.92f;
			if (b > 0.04045f) b = (float)Math.Pow((b + 0.055f) / 1.055f, 2.4f);
			else b = b / 12.92f;

			r = r * 100;
			g = g * 100;
			b = b * 100;

			//Observer. = 2°, Illuminant = D65
			X = r * 0.4124 + g * 0.3576 + b * 0.1805;
			Y = r * 0.2126 + g * 0.7152 + b * 0.0722;
			Z = r * 0.0193 + g * 0.1192 + b * 0.9505;
		}
		#endregion

		#region Send Return Text to Twilio

		private void SendReturnTextTwilio(string from, string msgBody)
		{
			string accountSid = GlobalVar.TwilioSID;  // "AC29390b0fe3f4cb763862eefedb8afc41";
			string authToken = GlobalVar.TwilioToken;  // "d68a401090af00f63bbecb4a3e502a7f";
			var twilio = new TwilioRestClient(accountSid, authToken);
			twilio.SendMessage(GlobalVar.TwilioPhoneNumber, from, msgBody);
			LogDisplay(GlobalVar.LogMsg = ("Return Message sent to " + from));
		}

		#endregion

#region Word List check for Blacklist and Whitelist
		private bool HasBadWords(string msg, out bool notWhite)
		{
			string textLine;
			var rgx = new Regex("[^a-zA-Z0-9]");

			#region Checks against Blacklist

			if (GlobalVar.Black_WhiteSelection == "Blacklist")
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
							LogDisplay(GlobalVar.LogMsg = ("Bad Word/s Detected in " + msg + " - " + textLine));
							file.Close();
							Log(" " + msg + ". Bad Word/s Detected! - " + textLine);
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
			var checkheader = headerfrom;

			using (var file = new StreamReader(GlobalVar.Blacklistlocation))
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

#region Colour Selection

		private void RandomColourSelect(out string hexValue)
		{
			do
			{
				var randomCol = _random.Next(0, 10);
				hexValue = GlobalVar.TextColor[randomCol].A.ToString("x2") + GlobalVar.TextColor[randomCol].R.ToString("x2") + GlobalVar.TextColor[randomCol].G.ToString("x2") + GlobalVar.TextColor[randomCol].B.ToString("x2");
			} while (hexValue == "ff000000");
		}
#endregion

#region Button Start and Stop checking for Messages
		private void buttonStart_Click(object sender, EventArgs e)
		{
			if (checkBoxVixenControl.Checked)
			{
				var messageBox = new MessageBoxForm(@"You must have the Vixen Control disable to use this button", @"Vixen Control", MessageBoxButtons.OK, SystemIcons.Information);
				messageBox.ShowDialog();
			}
			else
			{
				Start_Vixen();
			}
		}

		private void Start_Vixen()
		{
			if (!string.IsNullOrEmpty(GlobalVar.GroupID))
			{
				buttonStart.Image = Tools.GetIcon(Resources.StartB_W, 40);
				buttonStart.Text = "";
				buttonStop.Image = Tools.GetIcon(Resources.Stop, 40);
				buttonStop.Text = "";
				GlobalVar.PlayCustomMessage = false;
				StartChecking();
			}
			else
			{
				var messageBox = new MessageBoxForm(@"Vixen Messaging is unable to start as there are no Group Node ID's. Add a node ID on the Messaging Settings page", @"Error", MessageBoxButtons.OK, SystemIcons.Error);
				messageBox.ShowDialog();
			}
		}

		private void buttonStop_Click(object sender, EventArgs e)
		{
			if (checkBoxVixenControl.Checked)
			{
				var messageBox = new MessageBoxForm(@"You must have the Vixen Control disable to use this button", @"Vixen Control", MessageBoxButtons.OK, SystemIcons.Information);
				messageBox.ShowDialog();
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
			 timerCheckTwilio.Enabled = false;
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
				{
					var uri = GlobalVar.VixenServer.Replace("playSequence", "stopSequence");
					try
					{
						using (var wc = new WebClient())
						{
							wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
							wc.UploadString(GlobalVar.VixenServer.Replace("playSequence", "stopSequence"), "");
						}
					}
					catch
					{}
					try
					{
						var stopSequence = "Name=VixenOut&FileName=VixenOut.tim";
						using (var wc = new WebClient())
						{
							wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
							wc.UploadString(uri, stopSequence);
						}
					}
					catch
					{}
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
			var logFileName = GlobalVar.MessageLog;
			File.AppendAllText(logFileName, DateTime.Now.ToString("g") + " " + st + "\r\n");
		}
		#endregion

		#region Log Display
		private void LogDisplay(string logMsg)
		{
			richTextBoxLog.Text = richTextBoxLog.Text.Insert(0, (DateTime.Now.ToString("h:mm tt ")) + logMsg + "\n");
		}
		#endregion

#endregion

#region Close Vixen Messaging
		private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (!GlobalVar.closeMessagingApp)
			{
				e.Cancel = false;
				var messageBox = new MessageBoxForm(@"Would you like to save all Settings and Lists on exit?", @"Save",
					MessageBoxButtons.YesNoCancel, SystemIcons.Information);
				var save = messageBox.ShowDialog();
				switch (save)
				{
					case DialogResult.OK:
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
		}
#endregion

#region Save Data

			#region General Settings

		private void SeqSave()
		{
			var profile = new XmlProfileSettings();
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "textBoxVixenFolder", GlobalVar.Vixen3Folder);
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "VixenServer", GlobalVar.VixenServer);
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "SequenceTemplate", GlobalVar.SequenceTemplate);
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "OutputSequence", GlobalVar.OutputSequenceFolder);
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "StringOrientation", GlobalVar.StringOrientation);
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "LogMessageFile", GlobalVar.MessageLog);
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "LogBlacklistFile", GlobalVar.Blacklistlocation);
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxAutoStart", GlobalVar.AutoStartMsgRetrieval);
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxCenterStop", (GlobalVar.CenterStop.ToString()).ToLower());
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxCenterText", (GlobalVar.CenterText.ToString()).ToLower());
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxBlack_list", GlobalVar.Black_WhiteSelection);
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "IncomingMessageColourOption",
				GlobalVar.IncomingMessageColourOption);
			for (int i = 0; i < 10; i++)
			{
				profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "TextColor" + i, Convert.ToInt32(GlobalVar.TextColor[i].ToArgb()).ToString());
			}
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "trackBarTextPosition",
				GlobalVar.TextPosition.ToString());
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "trackBarTextSpeed", GlobalVar.TextSpeed.ToString());
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "trackBarIntensity", GlobalVar.Intensity.ToString());
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "SeqIntervalTime", Convert.ToInt32(GlobalVar.SeqIntervalTime).ToString());
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "textBoxFont", GlobalVar.Font);
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "textBoxFontSize", GlobalVar.FontSize);
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "TextDirection", GlobalVar.TextDirection);
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "GradientMode", GlobalVar.GradientMode);
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "ReturnBannedMSG", GlobalVar.ReturnBannedMSG);
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "ReturnWarningMSG", GlobalVar.ReturnWarningMSG);
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "ReturnSuccessMSG", GlobalVar.ReturnSuccessMSG);
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "IntervalMsgs", GlobalVar.IntervalMsgs);
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "TwilioSID", GlobalVar.TwilioSID);
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "TwilioToken", GlobalVar.TwilioToken);
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "TwilioPhoneNumber", GlobalVar.TwilioPhoneNumber);
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "dateCountDownString", GlobalVar.CountDownDate);
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxCountDown", checkBoxCountDown.Checked.ToString());
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "CountDownMSG", GlobalVar.CountDownMSG);
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "numericUpDownMaxWords",
				GlobalVar.MaxWords.ToString());
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxVixenControl",
				checkBoxVixenControl.Checked.ToString());
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "GroupName", GlobalVar.GroupName);
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "GroupID", GlobalVar.GroupID);
			#endregion
		}
			
#endregion

		#region Timer to Check Vixen
		private void timerCheckVixenEnabled_Tick(object sender, EventArgs e)
		{
			if (checkBoxVixenControl.Checked)
			{
				if (File.Exists(GlobalVar.SequenceTemplate + "\\MessagingEnabled.txt"))
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

		private void Save()
		{
			SeqSave();
		}

#endregion

		private void buttonInstantMSG_Click(object sender, EventArgs e)
		{
			var instantMSG = new InstantMSG();
			instantMSG.ShowDialog();

			if (GlobalVar.CloseInstantMSGForm == false)
			{
				if (!string.IsNullOrEmpty(GlobalVar.InstantMSG))
				{
					bool blacklist, notWhitemsg, maxWordCount;
					SendMessageToVixen(GlobalVar.InstantMSG, out blacklist, out notWhitemsg, out maxWordCount);


					if (!maxWordCount)
					{
						if (blacklist && !notWhitemsg)
						{
							LogDisplay(
								GlobalVar.LogMsg =
									("Auto Reply: You should know better not to use inappropiate words. Your message has not been displayed."));
							return;
						}
						if (!notWhitemsg)
						{
							LogDisplay(GlobalVar.LogMsg = ("Your message has been displayed."));
							GlobalVar.InstantMSG = "";
							return;
						}
					}
					else
					{
						LogDisplay(
							GlobalVar.LogMsg =
								("Auto Reply: Sorry, your message is too long and will not be display. Please reduce the number of words in your message to below " +
								 (GlobalVar.MaxWords + 1) + " and resend or adjust the Maximum word limit. Thank you."));
					}

				}
				else
				{
					var messageBox = new MessageBoxForm(@"Instant Message box is empty. Add message and try again", @"Information",
						MessageBoxButtons.OK, SystemIcons.Information);
					messageBox.ShowDialog();
				}
			}
		}

		private void buttonBackground_MouseHover(object sender, EventArgs e)
		{
			var btn = (Button)sender;
			btn.BackgroundImage = Resources.ButtonBackgroundImageHover;
		}

		private void buttonBackground_MouseLeave(object sender, EventArgs e)
		{
			var btn = (Button)sender;
			btn.BackgroundImage = Resources.ButtonBackgroundImage;
		}

		private bool CheckedOpened(string name)
		{
			FormCollection fc = Application.OpenForms;
			foreach (Form frm in fc)
			{
				if (frm.Text == name)
				{
					return true;
				}
				
			}
			return false;
		}

		private void saveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Save();
			var messageBox = new MessageBoxForm(@"All Settings, Whitelist and Blacklist have been saved.", @"Saved", MessageBoxButtons.OK, SystemIcons.Information);
			messageBox.ShowDialog();
		}

		private void helpToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var helpform = new HelpForm();
			helpform.ShowDialog();
		}

		private void exportLogToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(richTextBoxLog.Text))
			{
				string[] sfd = richTextBoxLog.Text.Split('\n');
				File.WriteAllLines(GlobalVar.SequenceTemplate + "\\Log.txt", sfd);
				var messageBox = new MessageBoxForm(@"Log.txt has been saved in " + GlobalVar.SequenceTemplate, @"Saved", MessageBoxButtons.OK, SystemIcons.Information);
				messageBox.ShowDialog();
			}
			else
			{
				var messageBox = new MessageBoxForm(@"Log is empty and will not be saved", @"Empty Log", MessageBoxButtons.OK, SystemIcons.Information);
				messageBox.ShowDialog();
			}
		}

		private void twilioToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var twilio = new Twilio();
			twilio.ShowDialog();
		}

		private void messagingToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var msgSettings = new MessagingSettings();
			msgSettings.ShowDialog();
		}

		private void textToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (_msgTextSettings == null || string.IsNullOrEmpty(_msgTextSettings.Text))
			
			{
				_msgTextSettings = new MSGTextSettings();
				_msgTextSettings.Show();
			}
			else if (CheckedOpened(_msgTextSettings.Text))
			{
				_msgTextSettings.WindowState = FormWindowState.Normal;
				_msgTextSettings.Focus();
			}
		}

		private void whiteBlackListsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var white_Black_Lists = new White_Black_Lists();
			white_Black_Lists.ShowDialog();
		}

		private void closeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var messageBox = new MessageBoxForm(@"Would you like to save all Settings and Lists on exit?", @"Save", MessageBoxButtons.YesNoCancel, SystemIcons.Information);
			var save = messageBox.ShowDialog();
			switch (save)
			{
				case DialogResult.OK:
					Save();
					StopSequence();
					GlobalVar.closeMessagingApp = true;
					Close();
					break;
				case DialogResult.No:
					StopSequence();
					GlobalVar.closeMessagingApp = true;
					Close();
					break;
				case DialogResult.Cancel:
					GlobalVar.closeMessagingApp = false;
					break;
			}
		}

		private void checkBoxCountDown_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBoxCountDown.Checked & string.IsNullOrEmpty(GlobalVar.CountDownMSG))
			{
				var messageBox = new MessageBoxForm(@"There is no message in the Messaging settings form for the Count down message.", @"Information", MessageBoxButtons.OK, SystemIcons.Information);
				messageBox.ShowDialog();
			}
		}

	}
}
