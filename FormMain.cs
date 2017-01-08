using CodeProject;

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
		private readonly Pop3Client _pop = new Pop3Client();

		public FormMain()
		{
			InitializeComponent();
			ClientSize = new Size(784, 1091);
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

			var vixenMovieFolder = textBoxVixenFolder.Text +
			                       "\\Module Data Files\\Nutcracker\\EEEEEEEE-EEEE-EEEE-EEEE-EEEEEEEEEEEE";
			if (!Directory.Exists(vixenMovieFolder))
			{
				Directory.CreateDirectory(vixenMovieFolder);
			}
			GlobalVar.MovieFolder = vixenMovieFolder;

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
			GlobalVar.CustomMessageCount = 0;
			GlobalVar.PlayMessage = false;

			#region Initial Groups, Tab and Checkboxs are Visable/Enabled/Setup

			//Ensures correct groups are enabled or visable on first load.
			buttonStop.Enabled = false;


			if (checkBoxMultiLine.Checked)
			{
				TextLineNumber.Enabled = false;
				numericUpDownMultiLine.Enabled = true;
			}

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
			buttonAddNodeID.Image = Tools.GetIcon(Resources.add, 16);
			buttonAddNodeID.Text = "";
			buttonRemoveNodeID.Image = Tools.GetIcon(Resources.delete, 16);
			buttonRemoveNodeID.Text = "";

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
				MessageBox.Show(
					@"Vixen 3 User files do not appear to be in the default Documents folder or Vixen 3 is not Installed, Ensure you add the correct folder first or Install Vixen 3.");
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
				MessageBox.Show(
					@"Welcome to Vixen Messaging, as this is the first time you have run Vixen Messaging you are required to enter in some information on the following Data form. Also it is recommended that you create a new Email account for use with Vixen Messaging as it will process every incoming email.");
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
			textBoxVixenFolder.Text = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "textBoxVixenFolder",
				Path.Combine(Environment.ExpandEnvironmentVariables("%userprofile%"), "Documents\\Vixen 3"));
			textBoxVixenServer.Text = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "VixenServer",
				"http://localhost:8888/api/play/playSequence");
			GlobalVar.Blacklistlocation = Path.Combine(GlobalVar.SettingsPath + "\\Blacklist.txt");
			GlobalVar.Whitelistlocation = Path.Combine(GlobalVar.SettingsPath + "\\Whitelist.txt");
			GlobalVar.LocalMessages = Path.Combine(GlobalVar.SettingsPath + "\\LocalMessages.txt");
			textBoxSequenceTemplate.Text = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "SequenceTemplate",
				Path.Combine(Environment.ExpandEnvironmentVariables("%userprofile%"), "Documents\\Vixen 3 Messaging"));
			textBoxOutputSequence.Text = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "OutputSequence",
				Path.Combine(Environment.ExpandEnvironmentVariables("%userprofile%"), "Documents\\Vixen 3\\Sequence\\VixenOut.tim"));
			comboBoxString.Text = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "StringOrienation", "Horizontal");
			textBoxLogFileName.Text = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "LogMessageFile",
				Path.Combine(Environment.ExpandEnvironmentVariables("%userprofile%"),
					"Documents\\Vixen 3 Messaging\\Logs\\Message.log"));
			textBoxBlacklistEmailLog.Text = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "LogBlacklistFile",
				Path.Combine(Environment.ExpandEnvironmentVariables("%userprofile%"),
					"Documents\\Vixen 3 Messaging\\Logs\\Blacklist.log"));
			checkBoxAutoStart.Checked = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxAutoStart", false);
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
			trackBarTextSpeed.Value = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "trackBarTextSpeed", 5);
			trackBarTextPosition.Value = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "trackBarTextPosition", 5);
			tabControlMain.SelectedIndex = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "tabControlMain", 0);
			textBoxFont.Text = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "textBoxFont", "Arial");
			textBoxFontSize.Text = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "textBoxFontSize", "10");
			GlobalVar.SeqIntervalTime = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "SeqIntervalTime", 15);
			comboBoxTextDirection.Text = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "comboBoxTextDirection",
				"Left");
			TextLineNumber.Value = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "TextLineNumber", 1);
			textBoxReturnBannedMSG.Text = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "textBoxReturnBannedMSG",
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
			checkBoxMultiLine.Checked = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxMultiLine", false);
			numericUpDownMultiLine.Value = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "numericUpDownMultiLine",
				1);
			numericUpDownMaxWords.Value = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "numericUpDownMaxWords", 0);
			var dateCountDownString = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "dateCountDownString",
				"25/12/15");
			dateCountDown.Value = Convert.ToDateTime(dateCountDownString);
			checkBoxVixenControl.Checked = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxVixenControl",
				false);
			textBoxTextFileFolder.Text = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "textBoxTextFileFolder", "");
			checkBoxdeleteTextFile.Checked = profile.GetSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxdeleteTextFile",
				true);


			textBoxOutputSequence.Text = textBoxVixenFolder.Text + "\\Sequence\\VixenOut.tim";

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
					GlobalVar.GroupNodeID.Add(profile.GetSetting(XmlProfileSettings.SettingType.Message, line + i, ""));
					line = "GroupNameID";
					i++;
				} while (i < GlobalVar.GroupIDNumber);
				comboBoxNodeID.SelectedIndex = groupIDNumberSel;
			}

			#endregion

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
						PlayLocalMsgs();
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
			if (GlobalVar.Sequential == 5)
			{
				GlobalVar.Sequential = 1;
			}
		}

		#endregion

		#region Play Local Msgs

		private void PlayLocalMsgs()
		{
			if (richTextBoxMessage.Text != "")
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
							var rndCustomMsgResult = rndCustomMsg.Next(0, comboBoxName.Items.Count - 1);
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
						if (((GlobalVar.Msgindex >= msgcount | richTextBoxMessage.Text == "") &
						     GlobalVar.CustomMessageCount < comboBoxName.Items.Count) & checkBoxCountDownEnable.Checked)
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
				//		 foreach (var message in messages.Messages)
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
							SendReturnTextTwilio(messageFrom,
								"Sorry, your message is too long and will not be display. Please reduce the number of words in your message to below " +
								(numericUpDownMaxWords.Value + 1) + " and resend. Thank you.");
							twilio.DeleteMessage(messageSid);
						}
						SendReturnTextTwilio(messageFrom,
							"Sorry one or more of the names you sent is not in the approved list or you are using unapproved abbriviations! You words have been recoreded and if found to be non offensive then they will be added to the list. Please try again on another day.");
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


#endregion



#region Send Message to Vixen

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
			#region Custom Effects

						if (msg != "play counter" & msg != "play sequence")
						{
							GlobalVar.SeqIntervalTime = Convert.ToDecimal(EffectTime.Value) + 1;
						}
						else
						{
							GlobalVar.SeqIntervalTime = Convert.ToDecimal(CustomMsgLength.Value) + 1;
						}

						outputFileName = textBoxOutputSequence.Text;
						

						string fileText1;
						TextSettings(fileText, msg, out fileText1);

						fileText = fileText1;
						fileText = fileText.Replace("PT20S", "PT" + GlobalVar.SeqIntervalTime + "S"); //Sequence time
						fileText = fileText.Replace("TextTime_Change", GlobalVar.SeqIntervalTime.ToString()); //Text Sequence time
						
						//Random or selected Selection
						string selectedSeq = "";
						if (msg == "play sequence")
						{
							fileText = fileText.Replace("EffectTime_Change", GlobalVar.SeqIntervalTime.ToString());
						}

						File.Delete(outputFileName);
						File.WriteAllText(outputFileName, fileText);
					
			  #endregion
					

			#region Send Play command to Vixen Web API
					
					var url = textBoxVixenServer.Text;
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
					MessageBox.Show(@"Warning - Check that Vixen Web Server is enabled and that Vixen 3 is running.", @"Warning");
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
			var i = 0;
			var textDirection = 0;
			int messageSelection;
			string hexMultiValue;
			UInt32 multilineColour;
			if (msg == "play counter" & checkBoxCountDownEnable.Checked)
			{
				fileText1 = fileText1.Replace("NamePlaceholder1", msg);
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
						break;
					case "Multi":
						hexMultiValue = colourOption1[messageSelection].BackColor.A.ToString("x2") + colourOption1[messageSelection].BackColor.R.ToString("x2") + colourOption1[messageSelection].BackColor.G.ToString("x2") + colourOption1[messageSelection].BackColor.B.ToString("x2");
						multilineColour = Convert.ToUInt32(hexMultiValue, 16);
						fileText1 = fileText1.Replace("Colour_Change1", multilineColour.ToString());
						break;
					case "Random":
						RandomColourSelect(out hexMultiValue);
						multilineColour = Convert.ToUInt32(hexMultiValue, 16);
						fileText1 = fileText1.Replace("Colour_Change1", multilineColour.ToString());
						Thread.Sleep(300);
						break;
				}
			fileText1 = fileText1.Replace("CenterStop_Change", "false");
			fileText = fileText1;
		}
#endregion

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
					textBoxOutputSequence.Text = textBoxVixenFolder.Text + "\\Sequence\\VixenOut.tim";
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
			if (textBoxNodeId.Text != "")
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
				MessageBox.Show(@"Vixen Messaging is unable to start as there are no Group Node ID's. Add a node ID on the Messaging Settings page");
			}
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
				{
					var uri = textBoxVixenServer.Text.Replace("playSequence", "stopSequence");
					try
					{
						using (var wc = new WebClient())
						{
							wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
							wc.UploadString(textBoxVixenServer.Text.Replace("playSequence", "stopSequence"), "");
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
			var logFileName = textBoxLogFileName.Text;
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
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "textBoxVixenFolder", textBoxVixenFolder.Text);
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "VixenServer", textBoxVixenServer.Text);
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "SequenceTemplate", textBoxSequenceTemplate.Text);
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "OutputSequence", textBoxOutputSequence.Text);
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "StringOrienation", comboBoxString.Text);
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "LogMessageFile", textBoxLogFileName.Text);
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "LogBlacklistFile", textBoxBlacklistEmailLog.Text);
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxAutoStart", checkBoxAutoStart.Checked);
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
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "tabControlMain", tabControlMain.SelectedIndex);
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "SeqIntervalTime", GlobalVar.SeqIntervalTime.ToString());
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "textBoxFont", textBoxFont.Text);
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "textBoxFontSize", textBoxFontSize.Text);
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "comboBoxTextDirection", comboBoxTextDirection.Text);
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "TextLineNumber", TextLineNumber.Value.ToString());
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "textBoxReturnBannedMSG", textBoxReturnBannedMSG.Text);
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
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "dateCountDownString", dateCountDown.Value.ToString());
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxMultiLine", checkBoxMultiLine.Checked.ToString());
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "numericUpDownMultiLine",
				numericUpDownMultiLine.Value.ToString());
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "numericUpDownMaxWords",
				numericUpDownMaxWords.Value.ToString());
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxVixenControl",
				checkBoxVixenControl.Checked.ToString());
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "textBoxTextFileFolder", textBoxTextFileFolder.Text);
			profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "checkBoxdeleteTextFile",
				checkBoxdeleteTextFile.Checked.ToString());

			#endregion

			#region Group ID Settings

			int i;
			string line;
			if (comboBoxNodeID.Items.Count > 0)
			{
				profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "GroupIDNumberSel", comboBoxNodeID.SelectedIndex);
				profile.PutSetting(XmlProfileSettings.SettingType.Profiles, "GroupIDNumber", comboBoxNodeID.Items.Count);
				i = 0;
				line = "GroupNameID";
				do
				{
					profile.PutSetting(XmlProfileSettings.SettingType.Message, line + i, Convert.ToString(comboBoxNodeID.Items[i]));
					line = "GroupNodeID";
					profile.PutSetting(XmlProfileSettings.SettingType.Message, line + i, GlobalVar.GroupNodeID[i]);
					line = "GroupNameID";
					i++;
				} while (i < GlobalVar.GroupNodeID.Count());
			}
		}

		#endregion
			
#endregion

#region Misc Area


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
				comboBoxNodeID.Items.RemoveAt(comboBoxNodeID.SelectedIndex);
				if (comboBoxNodeID.Items.Count > 0)
				{
					comboBoxNodeID.SelectedIndex = 0;
					textBoxNodeId.Text = GlobalVar.GroupNodeID[0];
				}
				else
				{
					comboBoxNodeID.Items.Clear();
					comboBoxNodeID.Text = "";
					textBoxNodeId.Text = "";
				}
			}
		}

#endregion

#region Play Custom Sequence

		private void PlayCustomSeq()
		{
			bool blacklist;
			bool notWhitemsg;
			bool maxWordCount;
			string msg = "play sequence";
			SendMessageToVixen(msg, out blacklist, out notWhitemsg, out maxWordCount);
		}
		#endregion

		private void textBoxTextFileFolder_MouseClick(object sender, MouseEventArgs e)
		{
			FolderBrowserDialog folderDlg = new FolderBrowserDialog();
			if (folderDlg.ShowDialog(this) == DialogResult.OK)
			{
				textBoxTextFileFolder.Text = folderDlg.SelectedPath;
			}
		}
	}
}
