using System;
using System.Collections.Generic;
using System.Text;

using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Diagnostics;
using System.Threading;

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
        }

        #region ServerCode
        private void Listen() 
        {
            ///TODO: Make use of another while-loop here, so listener doesn't get exited, if exception is thrown
            ///
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

                        //Clear Buffer
                        Buffer = new Byte[256];

                        string[] Parts = Message.Split(ColonSplit, StringSplitOptions.RemoveEmptyEntries);

                        #region XBC Cheats
                        //::::::::::::::::::::::::::::::::::
                        //::Code for XBC Cheats::

                        if (Parts.Length > 1)
                        {
                            #region MessageBox
                            //To Open MessageBox
                            if (Parts[1].Trim() == "MsgBox")
                            {
                                //Version 1.1 Fix (Issue: MessageBox blocks server thread)
                                PopUpData NewPopUp = new PopUpData(Parts[2], PopUpType.Message);
                                MessageBoxThread = new Thread(new ParameterizedThreadStart(ShowPopUp));
                                MessageBoxThread.Start(NewPopUp);

                                //** Version 1.0 left out code **
                                //MessageBox.Show(Parts[2]);
                            }
                            #endregion

                            #region TO OPEN YES/NO QuesBox
                            if (Parts[1].Trim() == "QuesBox")
                            {
                                //Version 1.1 Fix (Issue: MessageBox blocks server thread)
                                PopUpData NewPopUp = new PopUpData(Parts[2], PopUpType.Question);
                                MessageBoxThread = new Thread(new ParameterizedThreadStart(ShowPopUp));
                                MessageBoxThread.Start(NewPopUp);

                                //** Version 1.0 left out code **
                                //DialogResult reply = MessageBox.Show(null, Parts[2], "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                                //this.Send(ChatInterface.UserName.Text + ": " + reply.ToString() + "\r\n");
                            }
                            #endregion
                        }
                        else
                        {
                            #region PING
                            //To Ping (make a ding sound)

                            if (Parts[0].Substring(0, 4).Equals("PING"))
                            {
                                Parts[0] = "";

                                #region Redundant Code (v1.0)
                                /*
                                if (System.IO.File.Exists("Notify.wav")) //To avoid errors if file doesn't exist
                                {
                                    //To change sound, replace Notify.wav with any other WAV
                                    //System.Media.SoundPlayer player = new System.Media.SoundPlayer("Notify.wav");
                                    //player.Play();
                                }
                                */
                                #endregion

                                //new notification code (v 1.2)
                                //Uses system sound
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

                                Message = ""; //We don't want to see PINGS, we want to hear them. 
                                //Perhaps in future we can write them on Standard ear stream, just like stdout : stdEar.write("Ding"); "-- PJ :) --" 
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
                            // Echo Reply
                            //Show Online User
                            if (Message.Trim().StartsWith("#"))
                            {
                                Message = "";
                                if (Parts[0].Trim('\0').Substring(1) != ChatInterface.UserName.Text)
                                {
                                    Message = "** " + Parts[0].Trim('\0').Substring(1) + " is online **\r\n";  //Trim():just remove the #
                                    UpdateConversation(Message);
                                }
                            }
                            #endregion

                        }
                        //Repairment Work - To be done in last, after cheat codes processing
                        if (Parts.Length > 2)
                        {
                            Message = Parts[0] + ": " + Parts[2];
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
            catch
            {
                //Must be a ThreadAbortException for normal cases
                if (UDPSock != null)
                {
                    UDPSock.Shutdown(SocketShutdown.Both);
                    return;
                }
            }
        }
        #endregion

        private void SetText(string msg)
        {
            ChatInterface.Conversation.Text += msg;
            ChatInterface.NewMessageArrived(msg);
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
