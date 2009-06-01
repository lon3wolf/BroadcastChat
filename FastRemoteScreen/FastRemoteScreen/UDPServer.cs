using System;
using System.Collections.Generic;
using System.Text;
//version 1.0
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Diagnostics;
using System.Threading;
//version 2.0
using System.Text.RegularExpressions;

namespace FastChat
{
    class UDPServer
    {
        //You have to change it manually, it will be hardcoded right now
        int UDPPort = 55669;
        string[] ColonSplit = { ":" };
        Byte[] Buffer;
        Thread Listener, MessageBoxThread;
        public FastChat.ChatWindow ChatInterface;
        public bool Running = false;
        public delegate void Update(string Message);
        

        //Constructor, well you already know what this is, but just in case you don't know
        public UDPServer(FastChat.ChatWindow UIref)
        {
            Buffer = new Byte[256];
            ChatInterface = UIref;
            Listener = new Thread(new ThreadStart(Listen));
        }

        //Send Method - Sends Message over UDP Broadcast
        public void Send(string Message)
        {

            UdpClient udpClient = new UdpClient();
            try
            {
                udpClient.Connect(IPAddress.Broadcast, UDPPort);
                Byte[] sendBytes = Encoding.ASCII.GetBytes(Message);
                udpClient.Send(sendBytes, sendBytes.Length);
            }
            catch (Exception e)
            {
                MessageBox.Show("Exception: " + e.ToString());
                udpClient.Close();
            }
            udpClient.Close();
        }

        #region ServerCode
        private void Listen() 
        {
            ///TODO: Make use of another while-loop here, so listener doesn't get exited, if exception is thrown
            Socket UDPSock = null;
            try
            {
                UDPSock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                IPEndPoint Server = new IPEndPoint(IPAddress.Any, UDPPort);
                EndPoint Client = (EndPoint)new IPEndPoint(IPAddress.Broadcast, 0);
                UDPSock.Bind(Server);
                while (Running)
                {
                    Thread.Sleep(100);
                    if (UDPSock.Available > 0)
                    {
                        int rcv = UDPSock.ReceiveFrom(Buffer, ref Client);
                        string Message = Encoding.ASCII.GetString(Buffer);
                        Message = Message.Trim();
                        Message = Message.Substring(0, rcv);
                        //Clear Buffer
                        Buffer = new Byte[256];
                        Regex splitter = new Regex(@"(?<!\\)\:", RegexOptions.Compiled);
                        string[] Parts = splitter.Split(Message, 3);
                        if (Parts.Length > 1)
                        {
                            //Preprocess message part to replace escaped : (\:) with :
                            Parts[1] = Parts[1].Replace(@"\:", ":");
                            Message = Message.Replace(@"\:", ":");
                        }
                        #region XBC Commands
                        //::::::::::::::::::::::::::::::::::
                        //::Code for XBC Commands::

                        if (Parts.Length > 1)
                        {
                            #region MessageBox
                            //To Open MessageBox
                            if (Parts[1].Trim() == "MsgBox")
                            {
                                //Version 1.1 Fix (Issue: MessageBox blocks server thread)
                                PopUpData NewPopUp = new PopUpData(Parts[0] + " is saying: \n" + Parts[2], PopUpType.Message);
                                MessageBoxThread = new Thread(new ParameterizedThreadStart(ShowPopUp));
                                MessageBoxThread.Start(NewPopUp);
                            }
                            #endregion

                            #region TO OPEN YES/NO QuesBox
                            if (Parts[1].Trim() == "QuesBox")
                            {
                                //Version 1.1 Fix (Issue: MessageBox blocks server thread)
                                PopUpData NewPopUp = new PopUpData(Parts[0] + " is asking: \n" + Parts[2], PopUpType.Question);
                                MessageBoxThread = new Thread(new ParameterizedThreadStart(ShowPopUp));
                                MessageBoxThread.Start(NewPopUp);
                            }
                            #endregion

                            if (Parts.Length > 2)
                            {
                                Message = "<strong>" + Parts[0] + "</strong>" + ": " + Parts[2];
                            }
                            else
                            {
                                Message = "<strong>" + Parts[0] + "</strong>" + ": " + Parts[1];
                            }
                        }
                        else
                        {

                            if (Parts[0].Length > 4)
                            {
                                #region PING
                                //To Ping (make a ding sound)
                                if (Parts[0].Substring(0, 4).Equals("PING"))
                                {
                                    Parts[0] = "";
                                    #region Use system sound
                                    switch (ChatInterface.SelectedSound)
                                    {
                                        case Notifications.NotificationSounds.Asterisk:
                                            {
                                                System.Media.SystemSounds.Asterisk.Play();
                                            }
                                            break;
                                        case Notifications.NotificationSounds.Beep:
                                            {
                                                System.Media.SystemSounds.Beep.Play();
                                            }
                                            break;
                                        case Notifications.NotificationSounds.Exclamation:
                                            {
                                                System.Media.SystemSounds.Exclamation.Play();
                                            }
                                            break;
                                    }
                                    #endregion
                                    Message = ""; //We don't want to see PINGS, we want to hear them. 
                                }
                                #endregion

                                #region ECHO
                                //Request ECHOing -- To detect user presence - Listener Thread reply with UserName suffixed to Unique MessageID Character (#)
                                else if (Parts[0].Substring(0, 4).Equals("ECHO"))
                                {
                                    Parts[0] = "";
                                    Message = "";
                                    this.Send("#" + ChatInterface.UserName.Text);
                                }
                                #endregion
                            }
                            #region ECHO REPLY
                            // Echo Reply
                            //Show Online User
                            if (Message.Trim().StartsWith("#"))
                            {
                                Message = "";
                                if (Parts[0].Trim('\0').Substring(1) != ChatInterface.UserName.Text) //this is yourself
                                {
                                    Message = "**<strong>" + Parts[0].Trim('\0').Substring(1) + " is online **</strong>\r\n";  //Trim():just remove the #
                                    UpdateConversation(Message);
                                }
                            }
                            #endregion
                        }

                        //End of XBC Cheats Code
                        //::::::::::::::::::::::::::::::::::
                        #endregion

                        if (Message != "") //After all, what's the point in showing a empty message :)
                        {
                            if (Parts.Length > 1)
                            {
                                UpdateConversation(Message);
                            }
                        }
                    }
                }
                UDPSock.Close();
            }
            catch(Exception e)
            {
                //Must be a ThreadAbortException for normal cases
                if (UDPSock != null)
                {
                    if (e.GetType() != typeof(ThreadAbortException))
                    {
                        MessageBox.Show("Error in receiving part: " + e.ToString());
                    }
                    UDPSock.Shutdown(SocketShutdown.Receive);
                    return;
                }
            }
        }
        #endregion

        private void SetText(string msg)
        {
            //URL Identifier
            Regex URL = new Regex(@"(http|https)://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?",RegexOptions.IgnoreCase);
            try
            {
                MatchCollection matches = URL.Matches(msg);
                foreach (Match match in matches)
                {
                    string replace = ProcessMessage(match);
                    msg = msg.Replace(match.Value, replace);
                }
            }
            catch
            {
                MessageBox.Show("Error! :-(");
            }
            finally
            {
                msg = msg + "<br />";
                ChatInterface.Conversation.Text = msg + ChatInterface.Conversation.Text;
                msg = "<html><head></head><body style='padding: 0px; margin: 0px;' >"+ChatInterface.Conversation.Text+"</body></html>";
                File.WriteAllText("code.html", msg);
                Uri code = new Uri(Application.StartupPath+@"\code.html", UriKind.Absolute);
                ChatInterface.HTMLConversation.Url = code;
                ChatInterface.HTMLConversation.Refresh(WebBrowserRefreshOption.Completely);
                try
                {
                    ChatInterface.HTMLConversation.Document.Window.ScrollTo(0, 0);
                    ChatInterface.HTMLConversation.Document.Body.ScrollLeft = 0;
                }
                catch
                {
                    ChatInterface.HTMLConversation.Document.Window.ScrollTo(0, 500);
                }
                ChatInterface.NewMessageArrived(msg);
            }
        }

        string ProcessMessage(Match  match)
        {
            string ret = "<a href=\"" + match.Value + "\" target=\"_blank\" >" + match.Value + "</a>";
            return ret;
         }

        private void UpdateConversation(string Message)
        {
            if (ChatInterface.Conversation.InvokeRequired)
            {
                Update ConversionUpdate = new Update(SetText);
                ChatInterface.Conversation.Invoke(ConversionUpdate, Message);
            }
        }

        #region Server Start-Stop Code
        public void Start()
        {
            Running = true;
            Listener.Start();
        }

        public void Stop()
        {
            Listener.Abort();
            Running = false;            
        }
        #endregion

        #region PopUps Related code

        public enum PopUpType
        {
            Message,
            Question
        };

        public struct PopUpData
        {
            //Methods
            public PopUpData(string msg, PopUpType type)
            {
                Message = msg;
                Type = type;
            }

            //Members
            public string Message;
            public PopUpType Type;
            //Any future Addtions
        }

        public void ShowPopUp(object Data)
        {
            PopUpData Pop = (PopUpData)Data;
            switch (Pop.Type)
            {
                case PopUpType.Message:
                    {
                        MessageBox.Show(null, Pop.Message, "Message:", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    break;
                case PopUpType.Question:
                    {
                        DialogResult reply = MessageBox.Show(null, Pop.Message, "Question:", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                        this.Send(ChatInterface.UserName.Text + ": " + reply.ToString() + "\r\n");
                    }
                    break;
            }
        }
        #endregion
    }
}
