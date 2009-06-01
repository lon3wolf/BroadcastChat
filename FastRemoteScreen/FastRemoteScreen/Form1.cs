using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using XRegistryOperations;

namespace FastChat
{
    public partial class ChatWindow: Form
    {
        UDPServer UDPS;
        public bool AllowNotifications;

        public Notifications.NotificationSounds SelectedSound = Notifications.NotificationSounds.Exclamation;

        public ChatWindow()
        {
            InitializeComponent();
            UDPS = new UDPServer(this);
            UDPS.Start();
            AllowNotifications = true;
            SetHostName();
        }

        public void SetHostName()
        {
            IPHostEntry local = Dns.GetHostEntry("127.0.0.1");
            UserName.Text = local.HostName;
        }

        private void Send_Click(object sender, EventArgs e)
        {
            if (Message.Text.Length != 0)
            {
                //preprocess message to escape ':' character
                Message.Text = Message.Text.Replace(":",@"\:");
                
                UDPS.Send(UserName.Text + ": " + Message.Text + "\r\n");
                Message.Clear();
                Message.Focus();
            }
        }

        private void ChatWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            UDPS.Stop();
            Application.Exit();
        }

        private void Start_Click(object sender, EventArgs e)
        {
            ///TODO: Add validating code to user name
            if (UserName.Text.Length != 0)
            {
                SetState(true);
                global::FastChat.Properties.Settings.Default.UserName = UserName.Text;
                FastChat.Properties.Settings.Default.Save();
            }

        }

            public static void SetHTMLText(string msg)
        {
            
        }

        public void SetState(bool state)
        {
            Message.Enabled = state;
            Send.Enabled = state;
            Conversation.Enabled = state;
            UserName.Enabled = !state;
            Start.Enabled = !state;
        }

        private void About_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show(global::FastChat.Properties.Settings.Default.About);
        }

        private void Message_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() == "\r\n")
            {
                UDPS.Send(UserName.Text + ": " + Message.Text + "\r");
                Message.Clear();
                Message.Text = "";
            }
        }

        private void Conversation_TextChanged(object sender, EventArgs e)
        {
            Conversation.Focus();
            Conversation.AutoScrollOffset = new Point(302, 262);
            Conversation.ScrollToCaret();
            Conversation.ScrollToCaret();
            Message.Focus();
            //Not Implemented
        }

        public void NewMessageArrived(string Msg)
        {
            if (this.WindowState == FormWindowState.Minimized && AllowNotifications )
            {
                MessageNotification.ShowBalloonTip(3000, "New XBC Message", Msg, ToolTipIcon.Info);
            }
        }

        private void Hide_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (HideLink.Text == "Hide")
            {
                HideWindow();
            }
            else
            {
                ShowWindow();
            }
        }

        private void ShowWindow()
        {
            this.ShowInTaskbar = true;
            HideLink.Text = "Hide";
            this.WindowState = FormWindowState.Normal;
            MessageNotification.Visible = false;
            this.Visible = true;
            this.Opacity = 1.0f;
        }

        private void HideWindow()
        {
            this.ShowInTaskbar = false;
            HideLink.Text = "Don't Hide";
            this.WindowState = FormWindowState.Minimized;
            MessageNotification.Visible = true;
            this.Opacity = 0.0f;
        }

        private void MessageNotification_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UDPS.Stop();
            Application.Exit();
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowWindow();
        }

        private void MessageNotification_Click(object sender, EventArgs e)
        {
            ShowWindow();
        }

        private void ChatWindow_Load(object sender, EventArgs e)
        {
            this.Left = Screen.PrimaryScreen.WorkingArea.Right - this.Width;
            this.Top = Screen.PrimaryScreen.WorkingArea.Bottom - this.Height;
            
            //Retrieve and set user settings
            global::FastChat.Properties.Settings.Default.Reload();
            UserName.Text = global::FastChat.Properties.Settings.Default.UserName;
            notificationsToolStripMenuItem.Checked = global::FastChat.Properties.Settings.Default.AllowNotifications;
            SetNotificationSound((Notifications.NotificationSounds)global::FastChat.Properties.Settings.Default.NotificationSound);
            onTopToolStripMenuItem.Checked = global::FastChat.Properties.Settings.Default.OnTop;
            this.TopMost = global::FastChat.Properties.Settings.Default.OnTop;
            AllowNotifications = global::FastChat.Properties.Settings.Default.AllowNotifications;            
        }

        //Pops Messages
        private void Msg_Click(object sender, EventArgs e)
        {
            UDPS.Send(UserName.Text + ":MsgBox:" + Message.Text+"\r\n");
        }

        //Asks Question
        private void Ques_Click(object sender, EventArgs e)
        {
            UDPS.Send(UserName.Text + ":QuesBox:" + Message.Text + "\r\n");
        }

        //Pings
        private void Ping_Click(object sender, EventArgs e)
        {
            UDPS.Send("PING");
        }

        //Request for Online User Presence Notification
        private void Echo_Click(object sender, EventArgs e)
        {
            UDPS.Send("ECHO");
        }

        // Notifies others of users presence
        private void ImOnline_Click(object sender, EventArgs e)
        {
            UDPS.Send("#" + UserName.Text);
        }

        private void clearChat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(null, "Are you sure, you want to clear all chat?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Conversation.Text = "";
                File.WriteAllText("code.html", "");
                Uri code = new Uri(Application.StartupPath + @"\code.html", UriKind.Absolute);
                HTMLConversation.Url = code;
                HTMLConversation.Refresh(WebBrowserRefreshOption.Completely);
            }
        }

        private void saveChatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog SFD = new SaveFileDialog();
            SFD.Filter = "Web Page (*.htm)|*.htm";
            SFD.ShowDialog();

            if (SFD.FileName.Length != 0)
            {
                File.WriteAllText(SFD.FileName, Conversation.Text);
            }
        }

        private void Options_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Options.ContextMenuStrip.Show(Options,new Point(Options.Width,Options.Height));
        }

        private void notificationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (notificationsToolStripMenuItem.Checked)
            {
                AllowNotifications = true;
            }
            else
            {
                AllowNotifications = false;
            }
            global::FastChat.Properties.Settings.Default.AllowNotifications = notificationsToolStripMenuItem.Checked;
            FastChat.Properties.Settings.Default.Save();
        }

        private void onTopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.TopMost = onTopToolStripMenuItem.Checked;
            global::FastChat.Properties.Settings.Default.OnTop = onTopToolStripMenuItem.Checked;
            FastChat.Properties.Settings.Default.Save();
        }

        private void ChatWindow_Move(object sender, EventArgs e)
        {

            //TODO: Add Win7 like Docking code
            //Rectangle ScreenRect = Screen.GetBounds(new Point(0, 0));
            //this.Left = 0;  // Left Dock
        }
        
        //Setting the notification sound
        private void asterisk_Click(object sender, EventArgs e)
        {
            SetNotificationSound(Notifications.NotificationSounds.Asterisk);
            global::FastChat.Properties.Settings.Default.NotificationSound = (uint)Notifications.NotificationSounds.Asterisk;
            FastChat.Properties.Settings.Default.Save();
        }

        private void beep_Click(object sender, EventArgs e)
        {
            SetNotificationSound(Notifications.NotificationSounds.Beep);
            global::FastChat.Properties.Settings.Default.NotificationSound = (uint)Notifications.NotificationSounds.Beep;
            FastChat.Properties.Settings.Default.Save();
        }

        private void exclaim_Click(object sender, EventArgs e)
        {
            SetNotificationSound(Notifications.NotificationSounds.Exclamation);
            global::FastChat.Properties.Settings.Default.NotificationSound = (uint)Notifications.NotificationSounds.Exclamation;
            FastChat.Properties.Settings.Default.Save();
        }

        private void SetNotificationSound(Notifications.NotificationSounds Sound)
        {
            SelectedSound = Sound;

            switch (Sound)
            {
                case Notifications.NotificationSounds.Asterisk:
                    {
                        asterisk.Checked = true;
                        exclaim.Checked = false;
                        beep.Checked = false;
                    }
                    break;
                case Notifications.NotificationSounds.Beep:
                    {
                        asterisk.Checked = false;
                        exclaim.Checked = false;
                        beep.Checked = true;
                    }
                    break;
                case Notifications.NotificationSounds.Exclamation:
                    {
                        asterisk.Checked = false;
                        exclaim.Checked = true;
                        beep.Checked = false;
                    }
                    break;
            }

        }

        private void AutoStart_Click(object sender, EventArgs e)
        {
            if (AutoStart.Checked)
            {
                //AutoStart.Checked = false;
                //string.empty is used as a macj=hine name for opening Lacal machine Reg Key
                if (RegistryOperations.AddKey(Microsoft.Win32.RegistryHive.CurrentUser, string.Empty, @"Software\Microsoft\Windows\CurrentVersion\Run", "XBC", (object)Application.StartupPath + @"\XBC.exe"))
                {
                    MessageBox.Show("XBC will now auto start, at Log on");
                }
                else
                {
                    MessageBox.Show("Error");
                }
                
            }
            else
            {
                //string.empty is used as a macj=hine name for opening Lacal machine Reg Key
                if (RegistryOperations.RemoveKey(Microsoft.Win32.RegistryHive.CurrentUser, string.Empty, @"Software\Microsoft\Windows\CurrentVersion\Run", "XBC"))
                {
                    MessageBox.Show("Disabled auto start at log on");
                }
                else
                {
                    MessageBox.Show("Error");
                }
            }
        }

        private void ChatWindow_Deactivate(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                HideWindow();
            }
        }

        private void ChatWindow_Activated(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                MessageNotification.Visible = false;
            }
        }

        private void ChatWindow_Paint(object sender, PaintEventArgs e)
        {
            Rectangle WinRect = new Rectangle(new Point(0, 0), this.Size);
            using (Brush B = new System.Drawing.Drawing2D.LinearGradientBrush(WinRect, Color.Black, Color.Gray, System.Drawing.Drawing2D.LinearGradientMode.Vertical))
            {
                e.Graphics.FillRectangle(B, WinRect);
            }
        }

    }
}
