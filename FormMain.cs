using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenPop;
using OpenPop.Pop3;
using System.Text.RegularExpressions; 


namespace Vixen_Messaging
{
    public partial class FormMain : Form
    {

        Pop3Client pop = new Pop3Client();

        public FormMain()
        {
            InitializeComponent();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            StartChecking();
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
                listBoxLog.Items.Insert(0, "Connecting to: " + server);
                Application.DoEvents();
                pop.Connect(server, 995, true);
                listBoxLog.Items.Insert(0, "Authenticating: " + uid);
                Application.DoEvents();
                pop.Authenticate(uid, pwd, AuthenticationMethod.UsernameAndPassword);
                listBoxLog.Items.Insert(0, "Logged Into Server");
                Application.DoEvents();
                return true;
            }
            catch (Exception ex)
            {
                listBoxLog.Items.Insert(0, "Pop Error: " + ex.Message);
                return false;
            }
        }

        private void timerCheckMail_Tick(object sender, EventArgs e)
        {
            timerCheckMail.Interval = 30000;
            try
            {
                if (Pop3Login())
                {
                    int messageCount = pop.GetMessageCount();
                    listBoxLog.Items.Insert(0, "Message Count: " + messageCount);
                    //var msgList = new List<int>();
                    for (int messageNum = 1; messageNum <= messageCount; messageNum++)
                    {
                        var header = pop.GetMessageHeaders(messageNum);
                        var msg = pop.GetMessage(messageNum);

						if (header.Subject == null || header.Subject == "") //need to sort this out.
						{
							pop.DeleteMessage(messageNum);
                            pop.Disconnect();
                            string rtnmsg = "Please ensure you enter the message in the subject line.";
                            SendReturnText("", header.From.ToString(), rtnmsg, messageNum); 
						}
						else
                        {
                            if (header.Subject.Contains("SMS from"))
                            {
                                var smsMessage = msg.MessagePart.GetBodyAsText();
                                var msgLines = smsMessage.Split('\r');
                                if (msgLines[0] != "")
                                {
                                    var phoneNumber = header.Subject.Substring(9).Trim();
								    listBoxLog.Items.Insert(0, "Retrieved Header # " + messageNum.ToString() + ": " + header.Subject.ToString());
								    try
								    {
									    smsMessage = msgLines[0];
									    listBoxLog.Items.Insert(0, "SMS Message: " + smsMessage);
									    pop.DeleteMessage(messageNum);
									    // We only want one message at a time so, disconnect and wait for next time.
									    pop.Disconnect();
									    SendMessageToVixen(smsMessage);
                                        string rtnmsg = "Your message will appear soon in lights.";
                                        SendReturnText(phoneNumber, header.From.ToString(), rtnmsg, messageNum);
									    return;
								    }
								    catch (Exception ex)
								    {
									    listBoxLog.Items.Insert(0, "Error Parsing Message Body: " + ex.Message);
								    }
                                }
                                else
                                {
                                    pop.DeleteMessage(messageNum);
                                    pop.Disconnect();
                                    string rtnmsg = "The body of your SMS is blank, please ensure the message you want to say in the body and not the subject line.";
                                    SendReturnText("", header.From.ToString(), rtnmsg, messageNum); 
                                }
					        }
					        else
						    {
						        listBoxLog.Items.Insert(0, "Retrieved Header # " + messageNum.ToString() + ": " + header.Subject.ToString());
						        try
						        {
                                    string emailMessage;
							        emailMessage = header.Subject;
								    listBoxLog.Items.Insert(0, "SMS Message: " + emailMessage);
							        pop.DeleteMessage(messageNum);
									// We only want one message at a time so, disconnect and wait for next time.
								    pop.Disconnect();
								    SendMessageToVixen(emailMessage);
                                    string rtnmsg = "Your message will appear soon in lights.";
                                    SendReturnText("", header.From.ToString(), rtnmsg, messageNum);
								    return;
							    }
							    catch (Exception ex)
							    {
								    listBoxLog.Items.Insert(0, "Error Parsing Message Body: " + ex.Message);
							    }  
                            }
						}
                        Application.DoEvents();
                    }
                }
            }
            catch (Exception ex)
            {
                listBoxLog.Items.Insert(0, ex.Message.ToString());
            }
            finally
            {
                if (pop.Connected)
                {
                    try
                    {
                        pop.Disconnect();
                    }
                    catch
                    {

                    }
                }
                listBoxLog.Items.Insert(0, "Disconnected");
            }
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            timerCheckMail.Enabled = false;
            buttonStart.Enabled = true;
            buttonStop.Enabled = false;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            XMLProfileSettings profile = new XMLProfileSettings();
            textBoxServer.Text = profile.GetSetting(XMLProfileSettings.SettingType.Profiles, "POP3Server", "pop.gmail.com");
            textBoxUID.Text = profile.GetSetting(XMLProfileSettings.SettingType.Profiles, "UID", "");
            textBoxPWD.Text = profile.GetSetting(XMLProfileSettings.SettingType.Profiles, "Password", "");
            textBoxVixenServer.Text = profile.GetSetting(XMLProfileSettings.SettingType.Profiles, "VixenServer", "http://localhost:8888/api/play/playSequence");
            textBoxSequenceTemplate.Text = profile.GetSetting(XMLProfileSettings.SettingType.Profiles, "SequenceTemplate", Path.Combine(Environment.ExpandEnvironmentVariables("%userprofile%"), "Documents\\Vixen 3\\Sequence"));
            textBoxOutputSequence.Text = profile.GetSetting(XMLProfileSettings.SettingType.Profiles, "OutputSequence", Path.Combine(Environment.ExpandEnvironmentVariables("%userprofile%"), "Documents\\Vixen 3\\Sequence\\HelloOut.tim"));
            textBoxReplaceText.Text = profile.GetSetting(XMLProfileSettings.SettingType.Profiles, "ReplaceText", "NamePlaceholder");
            textBoxLogFileName.Text = profile.GetSetting(XMLProfileSettings.SettingType.Profiles, "LogFile", Path.Combine(Environment.ExpandEnvironmentVariables("%userprofile%"), "Documents\\Vixen 3\\Logs\\Messaging.log")); // "C:\\Users\\Study\\Documents\\Vixen 3\\Logs\\Message.log");

            buttonStop.Enabled = false;
            StartChecking();
        }

        private void SendMessageToVixen(string msg)
        {
            try
            {
                var outputFileName = textBoxOutputSequence.Text.ToString();
                var inputFolderName = textBoxSequenceTemplate.Text.ToString();

                var files = Directory.GetFiles(inputFolderName, "Hello?.tim");
                var random = new Random();
                var fileNum = random.Next(1, files.Count());
                var inputFileName = inputFolderName + "\\Hello" + fileNum.ToString() + ".tim";

                var textToReplace = textBoxReplaceText.Text.ToString();
                var fileText = File.ReadAllText(inputFileName);
                if (!HasBadWords(msg))
                {
                    msg = msg.Replace("&", "&amp;");
                    fileText = fileText.Replace(textToReplace, msg);
                    File.Delete(outputFileName);
                    File.WriteAllText(outputFileName, fileText);
                    var url = textBoxVixenServer.Text.ToString() + "?name=" + WebUtility.UrlEncode(outputFileName);
                    var result = new WebClient().DownloadString(url);
                    listBoxLog.Items.Insert(0, "Vixen Started: + " + result);
                    Log(msg);
                }
            }
            catch (Exception ex)
            {
                listBoxLog.Items.Insert(0, ex.Message);
                Log("Error: " + ex.Message);
            }
        }

        private void Log(string st)
        {
            var logFileName = textBoxLogFileName.Text;
            File.AppendAllText(logFileName, DateTime.Now.ToString("g") + " " + st + "\r\n");
        }
        
        private bool HasBadWords(string msg)
        {
            string textLine = "";

            using (System.IO.StreamReader file = new System.IO.StreamReader(Path.Combine(Environment.ExpandEnvironmentVariables("%userprofile%"), "Documents\\Vixen 3\\Logs\\Blacklist.txt")))
            {
                do
                {

                    textLine = file.ReadLine();

                    Regex rgx = new Regex("[^a-zA-Z0-9]");
                    msg = rgx.Replace(msg, "");

                    if (msg.ToLower().Contains(textLine))
                    {
                        listBoxLog.Items.Insert(0, "Bad Words Detected!");
                        return true;
                    }
                } while (file.Peek() != -1);
                file.Close();
                return false;
            }
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            XMLProfileSettings profile = new XMLProfileSettings();
            profile.PutSetting(XMLProfileSettings.SettingType.Profiles, "POP3Server", textBoxServer.Text);
            profile.PutSetting(XMLProfileSettings.SettingType.Profiles, "UID", textBoxUID.Text);
            profile.PutSetting(XMLProfileSettings.SettingType.Profiles, "Password", textBoxPWD.Text);
            profile.PutSetting(XMLProfileSettings.SettingType.Profiles, "VixenServer", textBoxVixenServer.Text);
            profile.PutSetting(XMLProfileSettings.SettingType.Profiles, "SequenceTemplate", textBoxSequenceTemplate.Text);
            profile.PutSetting(XMLProfileSettings.SettingType.Profiles, "OutputSequence", textBoxOutputSequence.Text);
            profile.PutSetting(XMLProfileSettings.SettingType.Profiles, "ReplaceText", textBoxReplaceText.Text);
            profile.PutSetting(XMLProfileSettings.SettingType.Profiles, "LogFile", textBoxLogFileName.Text);
        }

        private void SendReturnText(string phoneNumber, string msgTo, string rtnmsg, int messageNum)
        {
           
            try
            {
                var message = new System.Net.Mail.MailMessage();
                listBoxLog.Items.Insert(0, "To: " + msgTo);
                message.To.Add(msgTo);
                message.Subject = "Northridge Lights";
                message.From = new System.Net.Mail.MailAddress("derek@kiwimill.com");
                message.Body = rtnmsg; // "Your message will appear soon in lights.";
                var smtp = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587);
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential(textBoxUID.Text.ToString(), textBoxPWD.Text.ToString());
                smtp.Send(message);
            }
            catch (Exception ex)
            {
                listBoxLog.Items.Insert(0, "SMTP Error: " + ex.Message);
            }
        }

		private void textBoxReplaceText_TextChanged(object sender, EventArgs e)
		{

		}

		private void listBoxLog_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}
