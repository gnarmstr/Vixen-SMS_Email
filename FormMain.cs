using System.Net.NetworkInformation;
using System.Windows.Forms.VisualStyles;
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
		public bool _envokeChanges;

		private Form _msgTextSettings;

		private bool playCountDown;

		public string messageFrom;

		private static Random _random = new Random();

		public FormMain()
		{
			_envokeChanges = true;
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
			messagesToolStripMenuItem.Image = Resources.Message;
			vixenToolStripMenuItem.Image = Resources.Vixen;
			vixenSequencesToolStripMenuItem.Image = Resources.Vixen;
			textToolStripMenuItem.Image = Resources.Text;
			viewLogFolderToolStripMenuItem.Image = Resources.Log;
			whiteBlackListsToolStripMenuItem.Image = Resources.Lists;
			WebServerStatus.ForeColor = Color.Black;
			GlobalVar.SaveFlag = false;
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

			//Ensures a backup of Whitelist and Blacklist are made in the Appdata folder so a new installation does not remove them and users loose there changes.
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

			if (!File.Exists(GlobalVar.PhoneNumberLog))
			{
				File.CreateText(GlobalVar.PhoneNumberLog);
			}
			else
			{
				File.Delete(GlobalVar.PhoneNumberLog);
				File.CreateText(GlobalVar.PhoneNumberLog);
			}

			if (!File.Exists(GlobalVar.BlacklistLog))
			{
				File.CreateText(GlobalVar.BlacklistLog);
			}
			else
			{
				File.Delete(GlobalVar.BlacklistLog);
				File.CreateText(GlobalVar.BlacklistLog);
			}

			GlobalVar.Blacklist = File.ReadAllText(GlobalVar.Blacklistlocation);
			GlobalVar.Whitelist = File.ReadAllText(GlobalVar.Whitelistlocation);

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
				var messageBox = new MessageBoxForm("\nVixen 3 User files do not appear to be in the default Documents folder or Vixen 3 is not Installed, Ensure you add the correct folder first or Install Vixen 3.", @"Vixen Files", MessageBoxButtons.OK, SystemIcons.Error);
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
				var messageBox = new MessageBoxForm("\nWelcome to Vixen Messaging, as this is the first time you have run Vixen Messaging you are required to setup the messaging system by going through the Settings.",
				"Welcome", MessageBoxButtons.OK, SystemIcons.Information);
				messageBox.ShowDialog();
				Stop_Vixen();
			}
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "checkfirstload", "False");
			_envokeChanges = false;
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
			GlobalVar.RandomCountDownSensitivity = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "trackBarRandomCountDownSensitivity", 15);
			GlobalVar.RandomAdvertisingSensitivity = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "trackBarRandomAdvertisingSensitivity", 20);
			GlobalVar.RandomMessagesSensitivity = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "trackBarRandomMessagesSensitivity", 15);
			GlobalVar.RandomSequenceSensitivity = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "trackBarRandomSequenceSensitivity", 50);
			GlobalVar.SequenceTemplate = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "SequenceTemplate",
				Path.Combine(Environment.ExpandEnvironmentVariables("%userprofile%"), "Documents\\Vixen 3 Messaging"));
			GlobalVar.OutputSequenceFolder = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "OutputSequence",
				Path.Combine(Environment.ExpandEnvironmentVariables("%userprofile%"), "Documents\\Vixen 3\\Sequence\\VixenOut.tim"));
			GlobalVar.AutoStartMsgRetrieval = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxAutoStart", false);
			GlobalVar.RepeatDisplayMessage = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxRepeatDisplayMessage", false);
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
			GlobalVar.TextIterations = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "trackBarTextIterations", 1);
			GlobalVar.TextSpeed = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "trackBarTextSpeed", 4);
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
				"Your mobile number has been recorded and has been banned for sending inappropriate words.");
			GlobalVar.ReturnWarningMSG = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "ReturnWarningMSG",
				"Please reframe from using inappropriate words. If this happens again your phone number will be banned.");
			GlobalVar.AdvertisingMSG = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "AdvertisingMSG", "Send SMS to xxxxxxxxx to display your message here.");
			GlobalVar.ReturnSuccessMSG = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "ReturnSuccessMSG",
				"Thanks for displaying your message.");
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
			checkBoxAdvertising.Checked = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxAdvertising", false);
			checkBoxMessages.Checked = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxMessages", false);
			checkBoxVixenControl.Checked = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxVixenControl",
				false);
			GlobalVar.GroupName = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "GroupName", "");
			GlobalVar.GroupID = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "GroupID", "");
			GlobalVar.MessageLog = Path.Combine(Environment.ExpandEnvironmentVariables("%userprofile%"),
					"Documents\\Vixen 3 Messaging\\Logs\\Message.log");
			GlobalVar.BlacklistLog = Path.Combine(Environment.ExpandEnvironmentVariables("%userprofile%"),
					"Documents\\Vixen 3 Messaging\\Logs\\Blacklist.log");
			GlobalVar.PhoneNumberLog = Path.Combine(Environment.ExpandEnvironmentVariables("%userprofile%"),
					"Documents\\Vixen 3 Messaging\\Logs\\PhoneNumber.log");

			int MessagesCount = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "MessagesCount", 1);
			GlobalVar.Messages = new string[MessagesCount];
			for (int i = 0; i < MessagesCount; i++)
			{
				GlobalVar.Messages[i] = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "Messages" + i, "");
			}

			int vixenSequenceCount = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "VixenSequenceCount", 0);
			GlobalVar.VixenSequencesList = new List<string>();
			bool deletedSequences = false;
			for (int i = 0; i < vixenSequenceCount; i++)
			{
				string currentSequence = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "VixenSequence" + i, "");

				if (File.Exists(GlobalVar.Vixen3Folder + "\\Sequence\\" + currentSequence))
				{
					GlobalVar.VixenSequencesList.Add(currentSequence);
				}
				else
				{
					deletedSequences = true;
				}
			}
			if (deletedSequences)
			{
				var messageBox = new MessageBoxForm(@"Information - Some Vixen Sequences in the list have been removed as they were unable to be located in the current Vixen profile folder.", @"Information",
							MessageBoxButtons.OK, SystemIcons.Information);
				messageBox.ShowDialog();
				update_Save_Flag();
			}
			GlobalVar.VixenSequences = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxVixenSequences",
				false);
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
			messageFrom = null;
			PlayModes();
		}

		#endregion

		#region Check for Network connection

		private bool CheckNetworkConnection()
		{
			var allNetworkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
			return allNetworkInterfaces.Any(networkConnection => (networkConnection.NetworkInterfaceType.ToString().Contains("Ethernet") || networkConnection.NetworkInterfaceType.ToString().Contains("Wireless")) && networkConnection.OperationalStatus.ToString().Contains("Up"));
		}

		#endregion

		#region Play Mode

		#region Play Modes

		private void PlayModes()
		{
			if (checkBoxCountDown.Checked && !string.IsNullOrEmpty(GlobalVar.CountDownMSG))
			{
				var randomPlay = _random.Next(0, 100);
				if (randomPlay < GlobalVar.RandomCountDownSensitivity)
				{
					PlayCountDown();
					timerCheckTwilio.Stop();
					timerCheckTwilio.Interval = Convert.ToInt16(GlobalVar.SeqIntervalTime + GlobalVar.IntervalMsgs)*1000;
					timerCheckTwilio.Start();
					return;
				}
			}

			if (checkBoxAdvertising.Checked && !string.IsNullOrEmpty(GlobalVar.AdvertisingMSG))
			{
				var randomPlay = _random.Next(0, 100);
				if (randomPlay < GlobalVar.RandomAdvertisingSensitivity)
				{
					PlayAdvertising();
					SequenceTimer();
					return;
				}
			}

			if (checkBoxMessages.Checked && GlobalVar.Messages != null && GlobalVar.Messages.Length > 0)
			{
				var randomPlay = _random.Next(0, 100);
				if (randomPlay < GlobalVar.RandomMessagesSensitivity)
				{
					PlayMessages();
					SequenceTimer();
					return;
				}
			}

			PlayTwilio();

			if (GlobalVar.VixenSequences && GlobalVar.LogMsg == "No messages on the Twilio server.")
			{
				Play_Vixen_Sequence();
			}
		}

		#endregion

		#region Play Count Down

		private void PlayCountDown()
		{
			bool blacklist, notWhitemsg, maxWordCount;

			playCountDown = true;
			SendMessageToVixen(GlobalVar.CountDownMSG, out blacklist, out notWhitemsg, out maxWordCount);
			playCountDown = false;
		}

		#endregion

		#region Play Advertising

		private void PlayAdvertising()
		{
			bool blacklist, notWhitemsg, maxWordCount;

			playCountDown = true;
			SendMessageToVixen(GlobalVar.AdvertisingMSG, out blacklist, out notWhitemsg, out maxWordCount);
			playCountDown = false;
		}

		#endregion

		#region Play Extra Messages

		private void PlayMessages()
		{
			bool blacklist, notWhitemsg, maxWordCount;

			playCountDown = true;
			int selectedMessage = _random.Next(0, (GlobalVar.Messages.Count()));
			SendMessageToVixen(GlobalVar.Messages[selectedMessage], out blacklist, out notWhitemsg, out maxWordCount);
			playCountDown = false;
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
				messageFrom = messages.Messages[messages.Messages.Count - 1].From;

				LogDisplay(GlobalVar.LogMsg = ("Checking Twilio Messages"));
				if (!CheckBlacklistMessage(messageFrom, messageBody, ""))
				{

					if (messageDirection.Contains("inbound"))
					{
						int inboundCount = messages.Messages.Count(inboundMessages => inboundMessages.Direction.Contains("inbound"));
						LogDisplay(GlobalVar.LogMsg = ("Found " + inboundCount + " Messages"));
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
								using (var file = new StreamWriter(GlobalVar.BlacklistLog, true))
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
								bool phoneNumberFound = false;
								using (var file = new StreamReader(GlobalVar.PhoneNumberLog))
								{
									do
									{
										var checkNumberlist = file.ReadLine();

										if (messageFrom == checkNumberlist && !GlobalVar.RepeatDisplayMessage)
										{
											file.Close();
											twilio.DeleteMessage(messageSid);
											SequenceTimer();
											return;
										}
										if (messageFrom == checkNumberlist)
										{
											phoneNumberFound = true;
										}
									} while (file.Peek() != -1);
									file.Close();
									if (!phoneNumberFound)
									{
										using (var fileW = new StreamWriter(GlobalVar.PhoneNumberLog, true))
										{
											fileW.WriteLine(messageFrom);
											fileW.Close();
										}
									}
									if (!string.IsNullOrEmpty(GlobalVar.ReturnSuccessMSG))
												SendReturnTextTwilio(messageFrom, "Auto Reply: " + GlobalVar.ReturnSuccessMSG); //Success message.
									twilio.DeleteMessage(messageSid);


								}
								SequenceTimer();
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
				twilio.DeleteMessage(messageSid);
			}
			catch
			{
				if (messages != null)
				{
					if (messages.RestException != null && messages.RestException.Code == "20003")
					{
						LogDisplay(GlobalVar.LogMsg = ("Authentication failed. Please check your Twilio Account settings"));
					}
					else
					{
						LogDisplay(GlobalVar.LogMsg = ("No messages on the Twilio server."));
					}
				}
				else
				{
					if (!CheckNetworkConnection())
					{
						LogDisplay(GlobalVar.LogMsg = ("Unable to retrive Twilio messages as there is no Network connection detected, connect to internet and try again."));
					}
					else
					{
						LogDisplay(GlobalVar.LogMsg = ("Unknown issue, please try again and if the issue continues contact the Development team"));
					}
				}
				ShortTimer();
				GlobalVar.SeqIntervalTime = 2;
			}
		}

		#endregion

		#endregion

		#region Play Vixen Sequence

		private void Play_Vixen_Sequence()
		{
			// Will play Vixen Sequences if no messages incoming from Twilio

			var randomSequenceNumber = _random.Next(0, 100); //Will only run Vixen Sequences at a Random time.
			if (randomSequenceNumber < GlobalVar.RandomSequenceSensitivity)//Adjust this value to increase or decrease the amount of times a Vixen Sequence is Displayed.
			{
				int randomSequence = _random.Next(0, GlobalVar.VixenSequencesList.Count);
				if (GlobalVar.VixenSequencesList.Count > randomSequence)
				{
					if (File.Exists(GlobalVar.Vixen3Folder + "\\Sequence\\" + GlobalVar.VixenSequencesList[randomSequence]))
					{

						try
						{
							//	"Name=VixenOut&FileName=VixenOut.tim";

							var url = GlobalVar.VixenServer;
							GlobalVar.CurrentSequence = GlobalVar.VixenSequencesList[randomSequence];
							using (var wc = new WebClient())
							{
								var sequenceName = GlobalVar.CurrentSequence.Remove(GlobalVar.CurrentSequence.LastIndexOf("."));
								wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
								wc.UploadString(url, "Name=" + sequenceName + "&FileName=" + GlobalVar.VixenSequencesList[randomSequence]);
								LogDisplay(GlobalVar.LogMsg = ("Vixen is Playing: " + GlobalVar.VixenSequencesList[randomSequence]));
							}

							//Get sequence time from file
							string selectedSeqTime;
							string str;
							var sequenceLength = "";
							var reading =
								File.OpenText(GlobalVar.Vixen3Folder + "\\Sequence\\" + GlobalVar.VixenSequencesList[randomSequence]);
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

							string seqTimeString;
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
								seqTimeString2 = seqTimeString2 * 60;
								seqTimeString = seqTimeString.Remove(0, 1);
								seqTimeString = seqTimeString.Replace("S", "");
								int seqTimeString3 = Convert.ToInt16(seqTimeString);
								GlobalVar.SeqIntervalTime = Convert.ToDecimal(seqTimeString2 + seqTimeString3);
							}
							else
							{
								var index = selectedSeqTime.IndexOf(".");
								if (index > 0)
								{
									selectedSeqTime = selectedSeqTime.Substring(0, index);
								}
								seqTimeString = selectedSeqTime.Replace("S", "");
								GlobalVar.SeqIntervalTime = Convert.ToDecimal(seqTimeString);
							}
							SequenceTimer();
						}
						catch
						{
						}
					}
					else
					{
						GlobalVar.VixenSequencesList.RemoveAt(randomSequence);
						LogDisplay(GlobalVar.LogMsg = ("Vixen Sequence could not be found in the Vixen Profile Folder and has been removed"));
						update_Save_Flag();
						ShortTimer();
					}
				}
				else
				{
					ShortTimer();
				}
			}
			else
			{
				ShortTimer();
				GlobalVar.SeqIntervalTime = 0;
				SequenceTimer();
			}
		}

		#region Set Timers

		private void ShortTimer()
		{
			timerCheckTwilio.Stop();
			timerCheckTwilio.Interval = 200;
			timerCheckTwilio.Start();
		}

		private void SequenceTimer()
		{
			if (!buttonStart.Enabled)
			{
				timerCheckTwilio.Stop();
				timerCheckTwilio.Interval = Convert.ToInt16(GlobalVar.SeqIntervalTime + GlobalVar.IntervalMsgs)*1000;
				timerCheckTwilio.Start();
			}
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
				string countDown = string.Format("{0}", t.Days + 1);
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

					#region Custom Effects

					int totalCharacters = 0;
					foreach (char c in msg)
					{
						totalCharacters++;
					}

					if (msg != "play counter" & msg != "play sequence")
					{
						GlobalVar.SeqIntervalTime = Convert.ToDecimal(GlobalVar.TextSpeed + (totalCharacters * 0.25)) * GlobalVar.TextIterations;
							//Convert.ToDecimal(EffectTime.Value) + 1;
					}
					else
					{
						GlobalVar.SeqIntervalTime = Convert.ToDecimal(GlobalVar.TextSpeed + (totalCharacters * 0.25)) * GlobalVar.TextIterations;
							// Convert.ToDecimal(CustomMsgLength.Value) + 1;
					}

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

					File.Delete(GlobalVar.OutputSequenceFolder);
					File.WriteAllText(GlobalVar.OutputSequenceFolder, GlobalVar.FileText);

					#endregion


					#region Send Play command to Vixen Web API

					var url = GlobalVar.VixenServer;
					try
					{
						var startSequence = "Name=VixenOut&FileName=VixenOut.tim";
						GlobalVar.CurrentSequence = "VixenOut.tim";
						using (var wc = new WebClient())
						{
							wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
							wc.UploadString(url, startSequence);
							LogDisplay(GlobalVar.LogMsg = "Vixen is Playing: " + msg);//("Vixen is Playing: VixenOut.tim (Custom Messaging Template)"));
						}
					}
					catch
					{
					}
					//				$.post('http://localhost/api/playplaySequence', sequence, null, 'JSON');

					Cursor.Current = Cursors.Default;

					if (messageFrom != null)
					{
						LogDisplay(msg + " from" + messageFrom + " has been displayed in lights");
					}
					else
					{
						LogDisplay(msg + " has been displayed in lights");
					}

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
			GlobalVar.FileText = GlobalVar.FileText.Replace("Speed_Change", GlobalVar.TextIterations.ToString());
			GlobalVar.FileText = GlobalVar.FileText.Replace("Intensity_Change", GlobalVar.Intensity.ToString());
			GlobalVar.FileText = GlobalVar.FileText.Replace("FontName_Change", GlobalVar.Font);
			GlobalVar.FileText = GlobalVar.FileText.Replace("FontSize_Change", GlobalVar.FontSize);
			GlobalVar.FileText = GlobalVar.FileText.Replace("CenterStop_Change", (GlobalVar.CenterStop.ToString()).ToLower());
			GlobalVar.FileText = GlobalVar.FileText.Replace("CenterText_Change", (GlobalVar.CenterText.ToString()).ToLower());

			double X = 1, Y = 1, Z = 1;
			double X1 = 1, Y1 = 1, Z1 = 1;
			int colorOption = GlobalVar.IncomingMessageColourOption == 4 ? _random.Next(2, 4) : GlobalVar.IncomingMessageColourOption;
			switch (colorOption)
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
				case 3:
					int textColor1 = _random.Next(0, 10);
					int textColor2;
					do
					{
						textColor2 = _random.Next(0, 10);
					} while (textColor2 == textColor1);
					
					hexMultiValue = GlobalVar.TextColor[textColor1].A.ToString("x2") + GlobalVar.TextColor[textColor1].R.ToString("x2") + GlobalVar.TextColor[textColor1].G.ToString("x2") + GlobalVar.TextColor[textColor1].B.ToString("x2");
					hexMultiValue1 = GlobalVar.TextColor[textColor2].A.ToString("x2") + GlobalVar.TextColor[textColor2].R.ToString("x2") + GlobalVar.TextColor[textColor2].G.ToString("x2") + GlobalVar.TextColor[textColor2].B.ToString("x2");
					HEXToXYZ(hexMultiValue, out X, out Y, out Z);
					HEXToXYZ(hexMultiValue1, out X1, out Y1, out Z1);
					break;
			}
			if (GlobalVar.GradientMode == "Random Gradient Mode" || GlobalVar.IncomingMessageColourOption == 4)
			{
				string[] gradientMode = new string[] { "AcrossElement", "AcrossElement", "VerticalAcrossText", "VerticalAcrossElement", "DiagonalAcrossText", "DiagonalAcrossElement", "BackwardDiagonalAcrossText", "BackwardDiagonalAcrossElement" };
				GlobalVar.FileText = GlobalVar.FileText.Replace("GradientMode_Change", gradientMode[_random.Next(0, 8)]);
			}
			else
			{
				GlobalVar.FileText = GlobalVar.FileText.Replace("GradientMode_Change", GlobalVar.GradientMode.Replace(" ", ""));
			}
			
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
							if (messageFrom != null)
							{
								LogDisplay(GlobalVar.LogMsg = ("Bad Word/s Detected in " + msg + " from " + messageFrom + " - " + textLine));
							}
							else
							{
								LogDisplay(GlobalVar.LogMsg = ("Bad Word/s Detected in " + msg + " - " + textLine));
							}
							file.Close();
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

			if (messageFrom != null)
			{
				LogDisplay(GlobalVar.LogMsg = ("One or more Names are not in Whitelist. From " + messageFrom));
			}
			else
			{
				LogDisplay(GlobalVar.LogMsg = ("One or more Names are not in Whitelist."));
			}
			notWhite = true;
			return true;
		}
#endregion

#region Check Banned List
		private bool CheckBlacklistMessage(string headerfrom, string headersms, string headerphone)
		{
			var maxaddress = 0;
			var checkheader = headerfrom;

			using (var file = new StreamReader(GlobalVar.BlacklistLog))
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
			bool vixenRunning = Process.GetProcesses().Any(clsProcess => clsProcess.ProcessName.Contains("VixenApplication"));
			if (vixenRunning)
			{
				if (checkBoxVixenControl.Checked)
				{
					var messageBox = new MessageBoxForm("\n\nYou must have the Vixen Control disable to use this button",
						@"Vixen Control", MessageBoxButtons.OK, SystemIcons.Information);
					messageBox.ShowDialog();
				}
				else
				{
					Start_Vixen();
				}
			}
			else
			{
				var messageBox = new MessageBoxForm("\n\nVixen 3 is Not currently running and must be open to be able to Start message retrieval.", @"Vixen 3 Issue", MessageBoxButtons.OK, SystemIcons.Error);
				messageBox.ShowDialog();
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
				StopSequence();
				StartChecking();
			}
			else
			{
				var messageBox = new MessageBoxForm("\n\nVixen Messaging is unable to start as there are no Group Node ID's. Add a node ID on the Messaging Settings page", @"Error", MessageBoxButtons.OK, SystemIcons.Error);
				messageBox.ShowDialog();
			}
		}

		private void buttonStop_Click(object sender, EventArgs e)
		{
			if (checkBoxVixenControl.Checked)
			{
				var messageBox = new MessageBoxForm("\n\nYou must have the Vixen Control disable to use this button", @"Vixen Control", MessageBoxButtons.OK, SystemIcons.Information);
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
					//try
					//{
					//	var stopSequence = "Name=VixenOut&FileName=VixenOut.tim";
					//	using (var wc = new WebClient())
					//	{
					//		wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
					//		var test = wc.DownloadString(GlobalVar.VixenServer.Replace("playSequence", "status"));
					//		var test1 = test;
					//		var test2 = test1;
					//	}
					//}
					//catch
					//{ }

					try
					{
						var sequenceName = GlobalVar.CurrentSequence.Remove(GlobalVar.CurrentSequence.LastIndexOf("."));
						var stopSequence = "Name=" + sequenceName + "&FileName=" + GlobalVar.CurrentSequence;
						using (var wc = new WebClient())
						{
							wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
							wc.UploadString(uri, stopSequence);
						}
						if (!buttonStart.Enabled)
							ShortTimer();
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

		private void LogDisplay(string logMsg)
		{
			//Update Display Log
			richTextBoxLog.Text = richTextBoxLog.Text.Insert(0, (DateTime.Now.ToString("h:mm tt ")) + logMsg + "\n");

			//Update log
			if (!File.Exists(GlobalVar.MessageLog))
			{
				File.CreateText(GlobalVar.MessageLog);
			}

			File.AppendAllText(GlobalVar.MessageLog, DateTime.Now.ToString("g") + " " + logMsg + "\r\n");
		}

#endregion

#region Close Vixen Messaging
		private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (!GlobalVar.closeMessagingApp && GlobalVar.SaveFlag)
			{
				e.Cancel = false;
				var messageBox = new MessageBoxForm("\n\nSettings have been change, select yes to save on exit?", @"Save",
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
			e.Cancel = false;
			StopSequence();
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
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "trackBarRandomCountDownSensitivity", GlobalVar.RandomCountDownSensitivity.ToString());
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "trackBarRandomAdvertisingSensitivity", GlobalVar.RandomAdvertisingSensitivity.ToString());
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "trackBarRandomMessagesSensitivity", GlobalVar.RandomMessagesSensitivity.ToString());
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "trackBarRandomSequenceSensitivity", GlobalVar.RandomSequenceSensitivity.ToString());
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxAutoStart", GlobalVar.AutoStartMsgRetrieval);
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxRepeatDisplayMessage", GlobalVar.RepeatDisplayMessage);
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
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "trackBarTextIterations", GlobalVar.TextIterations.ToString());
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "trackBarTextSpeed", GlobalVar.TextSpeed.ToString());
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "trackBarIntensity", GlobalVar.Intensity.ToString());
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "SeqIntervalTime", Convert.ToInt32(GlobalVar.SeqIntervalTime).ToString());
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "textBoxFont", GlobalVar.Font);
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "textBoxFontSize", GlobalVar.FontSize);
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "TextDirection", GlobalVar.TextDirection);
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "GradientMode", GlobalVar.GradientMode);
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "ReturnBannedMSG", GlobalVar.ReturnBannedMSG);
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "ReturnWarningMSG", GlobalVar.ReturnWarningMSG);
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "AdvertisingMSG", GlobalVar.AdvertisingMSG);
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "ReturnSuccessMSG", GlobalVar.ReturnSuccessMSG);
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "IntervalMsgs", GlobalVar.IntervalMsgs);
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "TwilioSID", GlobalVar.TwilioSID);
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "TwilioToken", GlobalVar.TwilioToken);
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "TwilioPhoneNumber", GlobalVar.TwilioPhoneNumber);
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "dateCountDownString", GlobalVar.CountDownDate);
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxCountDown", checkBoxCountDown.Checked.ToString());
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "CountDownMSG", GlobalVar.CountDownMSG);
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxAdvertising", checkBoxAdvertising.Checked.ToString());
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxMessages", checkBoxMessages.Checked.ToString());
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "numericUpDownMaxWords",
				GlobalVar.MaxWords.ToString());
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxVixenControl",
				checkBoxVixenControl.Checked.ToString());
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "GroupName", GlobalVar.GroupName);
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "GroupID", GlobalVar.GroupID);
			if (GlobalVar.Messages != null)
			{
				for (int i = 0; i < GlobalVar.Messages.Count(); i++)
				{
					profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "Messages" + i, GlobalVar.Messages[i]);
				}
				profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "MessagesCount", GlobalVar.Messages.Count());
			}
			if (GlobalVar.VixenSequencesList!= null)
			{
				int ii = 0;
				foreach (var vixenSequence in GlobalVar.VixenSequencesList)
				{
					profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "VixenSequence" + ii, vixenSequence);
					ii++;
				}
				profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "VixenSequenceCount", GlobalVar.VixenSequencesList.Count);
			}

			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxVixenSequences", GlobalVar.VixenSequences);

			#endregion

			GlobalVar.SaveFlag = false;
			Text = @"Vixen Messaging";
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
			if (!_envokeChanges)
			{
				GlobalVar.SaveFlag = true;
				Text = @"Vixen Messaging - Unsaved Changes";
			}
			timerCheckVixenEnabled.Enabled = checkBoxVixenControl.Checked;
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
					StopSequence();
					SendMessageToVixen(GlobalVar.InstantMSG, out blacklist, out notWhitemsg, out maxWordCount);
					SequenceTimer();

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
					//		LogDisplay(GlobalVar.LogMsg = ("Your message has been displayed."));
							GlobalVar.InstantMSG = "";
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
					var messageBox = new MessageBoxForm("\n\nInstant Message box is empty. Add message and try again", @"Information",
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
			var messageBox = new MessageBoxForm("\n\nAll Settings have been saved.", @"Saved", MessageBoxButtons.OK, SystemIcons.Information);
			messageBox.ShowDialog();
		}

		private void helpToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var helpform = new HelpForm();
			helpform.ShowDialog();
		}

		private void twilioToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var twilio = new Twilio();
			twilio.ShowDialog();
			if (GlobalVar.SaveFlag)
				Text = @"Vixen Messaging - Unsaved Changes";
		}

		private void vixenToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var vixenSettings = new VixenSettings();
			vixenSettings.ShowDialog();
			if (GlobalVar.SaveFlag)
				Text = @"Vixen Messaging - Unsaved Changes";
		}

		private void messagingToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var msgSettings = new MessagingSettings();
			msgSettings.ShowDialog();
			if (GlobalVar.SaveFlag)
				Text = @"Vixen Messaging - Unsaved Changes";
		}

		private void messagesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var msgsSettings = new Messages();
			msgsSettings.ShowDialog();
			if (GlobalVar.SaveFlag)
				Text = @"Vixen Messaging - Unsaved Changes";
		}

		private void textToolStripMenuItem_Click(object sender, EventArgs e)
		{
			_msgTextSettings = new MSGTextSettings();
			_msgTextSettings.ShowDialog();
			if (GlobalVar.SaveFlag)
				Text = @"Vixen Messaging - Unsaved Changes";
		}

		private void whiteBlackListsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var white_Black_Lists = new White_Black_Lists();
			white_Black_Lists.ShowDialog();
			if (GlobalVar.SaveFlag)
				Text = @"Vixen Messaging - Unsaved Changes";
		}

		private void vixenSequencesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var vixenSequenceSettings = new VixenSequenceSettings();
			vixenSequenceSettings.ShowDialog();
			if (GlobalVar.SaveFlag)
				Text = @"Vixen Messaging - Unsaved Changes";
		}

		private void closeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (GlobalVar.SaveFlag)
			{
				var messageBox = new MessageBoxForm("\n\nSettings have been change, select yes to save on exit?", @"Save",
					MessageBoxButtons.YesNoCancel, SystemIcons.Information);

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
			else
			{
				Close();
			}
			
		}

		private void checkBoxCountDown_CheckedChanged(object sender, EventArgs e)
		{
			update_Save_Flag();
				
			if (checkBoxCountDown.Checked & string.IsNullOrEmpty(GlobalVar.CountDownMSG))
			{
				var messageBox = new MessageBoxForm("\nThere is no message in the Messaging settings form for the Count down message.", @"Information", MessageBoxButtons.OK, SystemIcons.Information);
				messageBox.ShowDialog();
			}
		}

		private void checkBoxAdvertising_CheckedChanged(object sender, EventArgs e)
		{
			update_Save_Flag();

			if (checkBoxAdvertising.Checked & string.IsNullOrEmpty(GlobalVar.AdvertisingMSG))
			{
				var messageBox = new MessageBoxForm("\nThere is no message in the Messaging settings form for the Advertising message.", @"Information", MessageBoxButtons.OK, SystemIcons.Information);
				messageBox.ShowDialog();
			}
		}

		private void viewLogFolderToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ProcessStartInfo startInfo = new ProcessStartInfo
			{
				Arguments = Path.Combine(Environment.ExpandEnvironmentVariables("%userprofile%"),
					"Documents\\Vixen 3 Messaging\\Logs"),
				FileName = "explorer.exe"
			};

			Process.Start(startInfo);
		}

		private void update_Save_Flag()
		{
			if (!_envokeChanges)
			{
				GlobalVar.SaveFlag = true;
				Text = @"Vixen Messaging - Unsaved Changes";
			}
		}

	}
}
