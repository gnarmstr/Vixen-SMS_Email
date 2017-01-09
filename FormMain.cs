using CodeProject;
using Vixen_Messaging.Theme;

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

		public FormMain()
		{
			InitializeComponent();
			ClientSize = new Size(784, 1091);
			ForeColor = ThemeColorTable.ForeColor;
			BackColor = ThemeColorTable.BackgroundColor;
			ThemeUpdateControls.UpdateControls(this, new List<Control>(new[] { WebServerStatus, TextColor1, TextColor2, TextColor3, TextColor4, TextColor5, TextColor6, TextColor7, TextColor8, TextColor9, TextColor10 }));
			WebServerStatus.ForeColor = Color.Black;
		}

		private void StartChecking()
		{
			buttonStart.Enabled = false;
			buttonStop.Enabled = true;
			timerCheckMail.Interval = 200;
			timerCheckMail.Enabled = true;
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

			if (comboBoxPlayMode.Text != "Random" && comboBoxPlayMode.Text != "Sequential")
			{
				comboBoxPlayMode.Text = "Sequential";
			}

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

			ColourVisible();

			#endregion

			#region Setup Button images and Icons

			//Setup Button images
			buttonStop.Image = Tools.GetIcon(Resources.Stop, 40);
			buttonStart.Image = Tools.GetIcon(Resources.StartB_W, 40);
			buttonStop.Image = Tools.GetIcon(Resources.Stop, 40);
			buttonHelp.Image = Tools.GetIcon(Resources.Help2, 30);
			pictureBoxSaveWhitelist.Image = Tools.ResizeImage(Resources.SaveWhitelist, 100, 60);
			pictureBoxSaveBlacklist.Image = Tools.ResizeImage(Resources.SaveBlacklist, 100, 60);
			SaveAll.Image = Tools.ResizeImage(Resources.Save, 130, 30);

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
				var messageBox = new MessageBoxForm(@"Welcome to Vixen Messaging, as this is the first time you have run Vixen Messaging you are required to enter in some information on the following Data form. Also it is recommended that you create a new Email account for use with Vixen Messaging as it will process every incoming email.",
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
			comboBoxString.Text = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "StringOrienation", "Horizontal");
			GlobalVar.MessageLog = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "LogMessageFile",
				Path.Combine(Environment.ExpandEnvironmentVariables("%userprofile%"),
					"Documents\\Vixen 3 Messaging\\Logs\\Message.log"));
			GlobalVar.BlacklistLog = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "LogBlacklistFile",
				Path.Combine(Environment.ExpandEnvironmentVariables("%userprofile%"),
					"Documents\\Vixen 3 Messaging\\Logs\\Blacklist.log"));
			GlobalVar.AutoStartMsgRetrieval = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxAutoStart", false);
			GlobalVar.CenterStop = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxCenterStop", false);
			checkBoxCenterStop.Checked = GlobalVar.CenterStop;
			GlobalVar.CenterText = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxCenterText", false);
			checkBoxCenterText.Checked = GlobalVar.CenterText;
			checkBoxBlacklist.Checked = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxBlack_list", true);
			incomingMessageColourOption.Text = profile.GetSetting(XmlProfileSettings.SettingType.Profiles,
				"incomingMessageColourOption", "Random");
			TextColor1.BackColor =
				Color.FromArgb(Convert.ToInt32(profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "TextColor1", -16776961)));
			TextColor2.BackColor =
				Color.FromArgb(Convert.ToInt32(profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "TextColor2", -65536)));
			TextColor3.BackColor =
				Color.FromArgb(Convert.ToInt32(profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "TextColor3", -16711936)));
			TextColor4.BackColor =
				Color.FromArgb(Convert.ToInt32(profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "TextColor4", -16776961)));
			TextColor5.BackColor =
				Color.FromArgb(Convert.ToInt32(profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "TextColor5", -32640)));
			TextColor6.BackColor =
				Color.FromArgb(Convert.ToInt32(profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "TextColor6", -32513)));
			TextColor7.BackColor =
				Color.FromArgb(Convert.ToInt32(profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "TextColor7", -16711681)));
			TextColor8.BackColor =
				Color.FromArgb(Convert.ToInt32(profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "TextColor8", -8372160)));
			TextColor9.BackColor =
				Color.FromArgb(Convert.ToInt32(profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "TextColor9", -65536)));
			TextColor10.BackColor =
				Color.FromArgb(Convert.ToInt32(profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "TextColor10", -8388353)));
			trackBarTextSpeed.Value = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "trackBarTextSpeed", 1);
			trackBarTextPosition.Value = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "trackBarTextPosition", 0);
			trackBarIntensity.Value = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "trackBarIntensity", 100);
			tabControlMain.SelectedIndex = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "tabControlMain", 0);
			textBoxFont.Text = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "textBoxFont", "Arial");
			textBoxFontSize.Text = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "textBoxFontSize", "10");
			GlobalVar.SeqIntervalTime = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "SeqIntervalTime", 15);
			comboBoxTextDirection.Text = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "comboBoxTextDirection",
				"Left");
			GlobalVar.ReturnBannedMSG = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "ReturnBannedMSG",
				"You have been banned for the night for sending inappropiate words.");
			comboBoxPlayMode.Text = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "comboBoxPlayMode",
				"Play Only Incoming Msgs");
			checkBoxLocalRandom.Checked = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxLocalRandom", true);
			numericUpDownIntervalMsgs.Value = profile.GetSetting(XmlProfileSettings.SettingType.Profiles,
				"numericUpDownIntervalMsgs", 0);
			GlobalVar.TwilioSID = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "TwilioSID", "");
			GlobalVar.TwilioToken = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "TwilioToken", "");
			checkBoxLocal.Checked = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxLocal", true);
			checkBoxTwilio.Checked = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxTwilio", false);
			GlobalVar.TwilioPhoneNumber = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "TwilioPhoneNumber", "");
			numericUpDownMaxWords.Value = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "numericUpDownMaxWords", 0);
			GlobalVar.CountDownDate = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "dateCountDownString",
				"25/12/15");
			dateCountDown.Value = Convert.ToDateTime(GlobalVar.CountDownDate);
			checkBoxVixenControl.Checked = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxVixenControl",
				false);
			GlobalVar.GroupName = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "GroupName", "");
			GlobalVar.GroupID = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "GroupID", "");
			textBoxInstantMSG.Text = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "InstantMSG", "");

			//	GlobalVar.OutputSequenceFolder = textBoxVixenFolder.Text + "\\Sequence\\VixenOut.tim"; 

		}
		#endregion

#region Main Form

		private void timerCheckMail_Tick(object sender, EventArgs e)
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

			timerCheckMail.Interval = Convert.ToInt16(GlobalVar.SeqIntervalTime + 5 + numericUpDownIntervalMsgs.Value)*1000;
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
				GlobalVar.Sequential = rnd.Next(1, 3);
			}
			switch (GlobalVar.Sequential)
			{
				case 1:
					if (checkBoxLocal.Checked)
					{
				//		PlayLocalMsgs();
					}
					else
					{
						ShortTimer();
					}
					GlobalVar.Sequential++;
					break;
				case 2:
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
			if (GlobalVar.Sequential == 3)
			{
				GlobalVar.Sequential = 1;
			}
		}

		#endregion

		//#region Play Local Msgs

		//private void PlayLocalMsgs()
		//{
		//	if (richTextBoxMessage.Text != "")
		//	{
		//		bool blacklist;
		//		bool notWhitemsg;
		//		bool maxWordCount;
		//		string msg;

		//		var phrases = richTextBoxMessage.Text.Split('\n');
		//		var msgcount = phrases.Length;
		//		if (checkBoxLocalRandom.Checked) //Play Random
		//		{

		//			var rndLineNumber = new Random();
		//			var rndLineNumberResult = rndLineNumber.Next(0, msgcount + comboBoxName.Items.Count);
		//			if (rndLineNumberResult >= msgcount | richTextBoxMessage.Text == "")
		//			{
		//				var i = 0;
		//				do
		//				{
		//					var rndCustomMsg = new Random();
		//					var rndCustomMsgResult = rndCustomMsg.Next(0, comboBoxName.Items.Count - 1);
		//					if (GlobalVar.MessageEnabled[rndCustomMsgResult])
		//					{
		//						comboBoxName.SelectedIndex = rndCustomMsgResult;
		//					}
		//				} while (!checkBoxMessageEnabled.Checked & i++ < 200 & checkBoxCountDownEnable.Checked);
		//				if (checkBoxMessageEnabled.Checked)
		//				{
		//					msg = "play counter"; //Play counter is used as its in the Whitelist
		//				}
		//				else
		//				{
		//					ShortTimer();
		//					return;
		//				}
		//			}
		//			else
		//			{
		//				msg = phrases[rndLineNumberResult];
		//			}
		//		}
		//		else //Play Sequential
		//		{
		//			if (GlobalVar.Msgindex < msgcount & richTextBoxMessage.Text != "")
		//			{
		//				msg = phrases[GlobalVar.Msgindex];
		//				GlobalVar.Msgindex++;
		//			}
		//			else
		//			{
		//				if (((GlobalVar.Msgindex >= msgcount | richTextBoxMessage.Text == "") &
		//					 GlobalVar.CustomMessageCount < comboBoxName.Items.Count) & checkBoxCountDownEnable.Checked)
		//				{
		//					do
		//					{
		//						comboBoxName.SelectedIndex = GlobalVar.CustomMessageCount;
		//						GlobalVar.CustomMessageCount ++;
		//					} while (!checkBoxMessageEnabled.Checked & GlobalVar.CustomMessageCount != comboBoxName.Items.Count);
		//					if (checkBoxMessageEnabled.Checked)
		//					{
		//						msg = "play counter"; //Play counter is used as its in the Whitelist
		//						GlobalVar.Msgindex++;
		//					}
		//					else
		//					{
		//						GlobalVar.Msgindex = 1;
		//						ShortTimer();
		//						return;
		//					}
		//				}
		//				else
		//				{
		//					GlobalVar.CustomMessageCount = 0;
		//					if (richTextBoxMessage.Text == "")
		//					{
		//						do
		//						{
		//							comboBoxName.SelectedIndex = GlobalVar.CustomMessageCount;
		//							GlobalVar.CustomMessageCount++;
		//						} while (!checkBoxMessageEnabled.Checked & GlobalVar.CustomMessageCount != comboBoxName.Items.Count);
		//						if (checkBoxMessageEnabled.Checked)
		//						{
		//							msg = "play counter"; //Play counter is used as its in the Whitelist
		//							GlobalVar.Msgindex++;
		//						}
		//						else
		//						{
		//							GlobalVar.Msgindex = 1;
		//							ShortTimer();
		//							return;
		//						}
		//					}
		//					else
		//					{
		//						msg = phrases[0];
		//					}
		//					GlobalVar.Msgindex = 1;
		//				}
		//			}
		//		}
		//		SendMessageToVixen(msg, out blacklist, out notWhitemsg, out maxWordCount);
		//	}
		//}

		//#endregion

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
								using (var file = new StreamWriter(@GlobalVar.Blacklistlocation, true))
								{
									file.WriteLine(messageFrom);
								}
								SendReturnTextTwilio(messageFrom,
									"Auto Reply: Please reframe from using inappropiate words. If this happens again your phone number will be banned.");
								twilio.DeleteMessage(messageSid);
								ShortTimer();
								return;
							}
							if (!notWhitemsg)
							{
								SendReturnTextTwilio(messageFrom, "Auto Reply: Your message will appear soon in lights.");
								twilio.DeleteMessage(messageSid);
								return;
							}
						}
						else
						{
							SendReturnTextTwilio(messageFrom,
								"Auto Reply: Sorry, your message is too long and will not be display. Please reduce the number of words in your message to below " +
								(numericUpDownMaxWords.Value + 1) + " and resend. Thank you.");
							twilio.DeleteMessage(messageSid);
						}
						SendReturnTextTwilio(messageFrom,
							"Auto Reply: Sorry one or more of the names you sent is not in the approved list or you are using unapproved abbriviations! You words have been recoreded and if found to be non offensive then they will be added to the list. Please try again on another day.");
						twilio.DeleteMessage(messageSid);
						ShortTimer();
						return;
					}
					twilio.DeleteMessage(messageSid);
					ShortTimer();
				}
				SendReturnTextTwilio(messageFrom, GlobalVar.ReturnBannedMSG);
				LogDisplay(GlobalVar.LogMsg = (messageFrom + " has been banned for sending inappropiate messages."));
				Log(" " + messageFrom + " has been banned for sending inappropiate messages.");
				twilio.DeleteMessage(messageSid);
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
			#region Custom Effects

						if (msg != "play counter" & msg != "play sequence")
						{
							GlobalVar.SeqIntervalTime = 10;//Convert.ToDecimal(EffectTime.Value) + 1;
						}
						else
						{
							GlobalVar.SeqIntervalTime = 10;// Convert.ToDecimal(CustomMsgLength.Value) + 1;
						}

						outputFileName = GlobalVar.OutputSequenceFolder;
						

						string fileText1;
						TextSettings(fileText, msg, out fileText1);

						fileText = fileText1;
		//				fileText = fileText.Replace("PT20S", "PT" + GlobalVar.SeqIntervalTime + "S"); //Sequence time
		//				fileText = fileText.Replace("TextTime_Change", GlobalVar.SeqIntervalTime.ToString()); //Text Sequence time
						

						File.Delete(outputFileName);
						File.WriteAllText(outputFileName, fileText);
					
			  #endregion
					

			#region Send Play command to Vixen Web API

					var url = GlobalVar.VixenServer;
					try
					{
						
						var result = new WebClient().DownloadString(url + "?name=" + WebUtility.UrlEncode(outputFileName)); //Used to output to Vixen WebClient
						LogDisplay(GlobalVar.LogMsg = ("Vixen Playing: + " + result));
					}
					catch
					{}
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
					{}
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
					var messageBox = new MessageBoxForm(@"Warning - Check that Vixen Web Server is enabled and that Vixen 3 is running.", @"Warning", MessageBoxButtons.OK, SystemIcons.Warning);
					messageBox.ShowDialog();
				}
				ShortTimer();
			}
			#endregion

			notWhitemsg = notWhite;
			maxWordCount = false;
		}

		

		public object JsonObject { get; set; }

	#region Write to Sequence File Text Settings

		private void TextSettings(string fileText1, string msg, out string fileText)
		{
			string hexMultiValue;
			UInt32 multilineColour;

			CountDown(msg, out msg);

			//Text Line Number
			fileText1 = fileText1.Replace("NamePlaceholder1", msg);

			//		fileText1 = fileText1.Replace("TextPosition_Change", trackBarTextPosition.Value.ToString());
			if (comboBoxTextDirection.Text == "Random")
			{
				comboBoxTextDirection.SelectedIndex = _random.Next(0, 5);
				fileText1 = fileText1.Replace("TextDirection_Change", comboBoxTextDirection.Text);
				comboBoxTextDirection.SelectedIndex = 5;
			}
			else
			{
				fileText1 = fileText1.Replace("TextDirection_Change", comboBoxTextDirection.Text);
			}
			fileText1 = fileText1.Replace("NodeId_Change", GlobalVar.GroupID); //adds NodeId
			fileText1 = fileText1.Replace("StringOrienation_Change", comboBoxString.Text);
			fileText1 = fileText1.Replace("Speed_Change", trackBarTextSpeed.Value.ToString());
			fileText1 = fileText1.Replace("Intensity_Change", trackBarIntensity.Value.ToString());
			fileText1 = fileText1.Replace("FontName_Change", textBoxFont.Text);
			fileText1 = fileText1.Replace("FontSize_Change", textBoxFontSize.Text);
			fileText1 = fileText1.Replace("CenterStop_Change", (checkBoxCenterStop.Checked.ToString()).ToLower());
			fileText1 = fileText1.Replace("CenterText_Change", (checkBoxCenterText.Checked.ToString()).ToLower());

			double X = 1, Y = 1, Z = 1;
			switch (incomingMessageColourOption.Text)
			{
				case "Single":
					hexMultiValue = TextColor1.BackColor.A.ToString("x2") + TextColor1.BackColor.R.ToString("x2") + TextColor1.BackColor.G.ToString("x2") + TextColor1.BackColor.B.ToString("x2");
					HEXToXYZ(hexMultiValue, out X, out Y, out Z);
					break;
				//case "Multi":
				//	hexMultiValue = colourOption1[messageSelection].BackColor.A.ToString("x2") +
				//					colourOption1[messageSelection].BackColor.R.ToString("x2") +
				//					colourOption1[messageSelection].BackColor.G.ToString("x2") +
				//					colourOption1[messageSelection].BackColor.B.ToString("x2");
				//	multilineColour = Convert.ToUInt32(hexMultiValue, 16);
				//	fileText1 = fileText1.Replace("Colour_Change1", multilineColour.ToString());
				//	break;
				case "Random":
					RandomColourSelect(out hexMultiValue);
					HEXToXYZ(hexMultiValue, out X, out Y, out Z);
					break;
			}
			
			fileText1 = fileText1.Replace("Color_ChangeX", X.ToString());
			fileText1 = fileText1.Replace("Color_ChangeY", Y.ToString());
			fileText1 = fileText1.Replace("Color_ChangeZ", Z.ToString());
			Thread.Sleep(300);
			fileText = fileText1;
		}

		#endregion

#endregion

		#region Convert Color to XYZ
		public void HEXToXYZ(string hexMultiValue, out double X, out double Y, out double Z)
		{
			Color color = ColorTranslator.FromHtml("#" + hexMultiValue);

			float r = (color.R / 255); //R from 0 to 255
			float g = (color.G / 255); //G from 0 to 255
			float b = (color.B / 255); //B from 0 to 255

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
							Log(" " + msg + ". Bad Word Detected! - " + textLine);
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

			var btn = new Button[] { TextColor1, TextColor1, TextColor2, TextColor3, TextColor4, TextColor5, TextColor6, TextColor7, TextColor8, TextColor9, TextColor10 };
			btn[colNum].BackColor = colorDialog1.Color;
			SeqSave();
		}
		#endregion

		#region Colour Selection
		private static Random _random = new Random();
		private void RandomColourSelect(out string hexValue)
		{
			do
			{
			//	var random = new Random();
				var randomCol = _random.Next(0, 10);
				var btn = new Button[] { TextColor1, TextColor2, TextColor3, TextColor4, TextColor5, TextColor6, TextColor7, TextColor8, TextColor9, TextColor10 };
				hexValue = btn[randomCol].BackColor.A.ToString("x2") + btn[randomCol].BackColor.R.ToString("x2") + btn[randomCol].BackColor.G.ToString("x2") + btn[randomCol].BackColor.B.ToString("x2");
			} while (hexValue == "ff000000");
		}
#endregion

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
			if (GlobalVar.GroupID != "")
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
			richTextBoxLog1.Text = richTextBoxLog.Text.Insert(0, (DateTime.Now.ToString("h:mm tt ")) + logMsg + "\n");
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

#region Close Vixen Messaging
		private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
		{
			e.Cancel = false;
			var messageBox = new MessageBoxForm(@"Would you like to save all Settings and Lists on exit?", @"Save", MessageBoxButtons.YesNoCancel, SystemIcons.Information);
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
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "StringOrienation", comboBoxString.Text);
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "LogMessageFile", GlobalVar.MessageLog);
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "LogBlacklistFile", GlobalVar.Blacklistlocation);
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxAutoStart", GlobalVar.AutoStartMsgRetrieval);
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxCenterStop", (checkBoxCenterStop.Checked.ToString()).ToLower());
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxCenterText", (checkBoxCenterText.Checked.ToString()).ToLower());
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxBlack_list", checkBoxBlacklist.Checked);
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "incomingMessageColourOption",
				incomingMessageColourOption.Text);
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
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "trackBarTextPosition",
				trackBarTextPosition.Value.ToString());
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "trackBarTextSpeed", trackBarTextSpeed.Value.ToString());
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "trackBarIntensity", trackBarIntensity.Value.ToString());
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "tabControlMain", tabControlMain.SelectedIndex);
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "SeqIntervalTime", GlobalVar.SeqIntervalTime.ToString());
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "textBoxFont", textBoxFont.Text);
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "textBoxFontSize", textBoxFontSize.Text);
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "comboBoxTextDirection", comboBoxTextDirection.Text);
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "ReturnBannedMSG", GlobalVar.ReturnBannedMSG);
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "comboBoxPlayMode", comboBoxPlayMode.Text);
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxLocalRandom",
				checkBoxLocalRandom.Checked.ToString());
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "numericUpDownIntervalMsgs",
				numericUpDownIntervalMsgs.Value.ToString());
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "TwilioSID", GlobalVar.TwilioSID);
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "TwilioToken", GlobalVar.TwilioToken);
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxLocal", checkBoxLocal.Checked.ToString());
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxTwilio", checkBoxTwilio.Checked.ToString());
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "TwilioPhoneNumber", GlobalVar.TwilioPhoneNumber);
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "dateCountDownString", GlobalVar.CountDownDate);
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "numericUpDownMaxWords",
				numericUpDownMaxWords.Value.ToString());
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxVixenControl",
				checkBoxVixenControl.Checked.ToString());
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "GroupName", GlobalVar.GroupName);
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "GroupID", GlobalVar.GroupID);
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "InstantMSG", textBoxInstantMSG.Text);
			#endregion
		}
			
#endregion

#region Misc Area


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
		private void checkBoxWhitelist_CheckedChanged(object sender, EventArgs e)
		{
			checkBoxBlacklist.Checked = !checkBoxWhitelist.Checked;
		}
		private void checkBoxBlacklist_CheckedChanged(object sender, EventArgs e)
		{
			checkBoxWhitelist.Checked = !checkBoxBlacklist.Checked;
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
			var messageBox = new MessageBoxForm(@"Blacklist saved!", @"Saved", MessageBoxButtons.OK, SystemIcons.Information);
			messageBox.ShowDialog();
		}

		private void SaveBlackList()
		{
			richTextBoxBlacklist.SaveFile(GlobalVar.Blacklistlocation, RichTextBoxStreamType.PlainText);
			richTextBoxBlacklist.SaveFile(GlobalVar.Blacklistlocation + ".bkp", RichTextBoxStreamType.PlainText);
		}

		private void pictureBoxSaveWhitelist_Click(object sender, EventArgs e)
		{
			SaveWhiteList();
			var messageBox = new MessageBoxForm(@"Whitelist saved!", @"Saved", MessageBoxButtons.OK, SystemIcons.Information);
			messageBox.ShowDialog();
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

		private void buttonSaveLog_Click(object sender, EventArgs e)
		{
			if (richTextBoxLog.Text != "")
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
			var messageBox = new MessageBoxForm(@"All Settings, Whitelist, Blacklist and Messagelists have been saved.", @"Saved", MessageBoxButtons.OK, SystemIcons.Information);
			messageBox.ShowDialog();
		}

		private void incomingMessageColourOption_SelectedIndexChanged(object sender, EventArgs e)
		{
			ColourVisible();
		}

#endregion

		private void buttonSettings_Click(object sender, EventArgs e)
		{
			var MSGSettings = new MessagingSettings();
			MSGSettings.ShowDialog();
		}

		private void buttonInstantMSG_Click(object sender, EventArgs e)
		{
			if (textBoxInstantMSG.Text != "")
			{
				bool blacklist, notWhitemsg, maxWordCount;
				SendMessageToVixen(textBoxInstantMSG.Text, out blacklist, out notWhitemsg, out maxWordCount);
			}
			else
			{
				var messageBox = new MessageBoxForm(@"Instant Message box is empty. Add message and try again", @"Information", MessageBoxButtons.OK, SystemIcons.Information);
				messageBox.ShowDialog();
			}
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

		private void trackBarIntensity_Scroll(object sender, EventArgs e)
		{
			toolTip1.SetToolTip(trackBarIntensity, trackBarIntensity.Value.ToString());
		}

		private void trackBarTextIntensity_MouseDown(object sender, MouseEventArgs e)
		{
			toolTip1.SetToolTip(trackBarIntensity, trackBarIntensity.Value.ToString());
		}

		private void trackBarTextIntensity_MouseHover(object sender, EventArgs e)
		{
			toolTip1.SetToolTip(trackBarIntensity, trackBarIntensity.Value.ToString());
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
	}
}
