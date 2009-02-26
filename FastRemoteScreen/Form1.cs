using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace FastChat
{
    public partial class ChatWindow: Form
    {
        UDPServer UDPS;
        public bool Notifications;

        public NotificationSounds SelectedSound = NotificationSounds.Exclamation;
        public enum NotificationSounds
        {
            Asterisk,
            Exclamation,
            Beep
        };

        public ChatWindow()
        {
            InitializeComponent();
            UDPS = new UDPServer(this);
            UDPS.Start();
            Notifications = true;
            SetHostName();
        }

        public void SetHostName()
        {
            IPHostEntry local = Dns.GetHostEntry("127.0.0.1");
            UserName.Text = local.HostName;
        }
        private void Send_Click(object sender, EventArgs e)
        {
            UDPS.Send(UserName.Text + ": " + Message.Text+"\r\n");
            Message.Clear();
            Message.Focus();
        }

        private void ChatWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            UDPS.Stop();
        }

        private void Start_Click(object sender, EventArgs e)
        {
            if (UserName.Text.Length != 0)
            {
                SetState(true);
            }

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
            MessageBox.Show("XBC\n\nXinx Broadcast Chat\n-By Sanil");
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
            if (this.WindowState == FormWindowState.Minimized && Notifications )
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
            //this.Visible = false;
            this.Opacity = 0.0f;
        }

        private void MessageNotification_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
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
            }
        }

        private void saveChatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog SFD = new SaveFileDialog();
            SFD.Filter = "Notepad Plain Text (*.txt)|*.txt";
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
                Notifications = true;
            }
            else
            {
                Notifications = false;
            }
        }

        private void onTopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.TopMost = onTopToolStripMenuItem.Checked;
        }

        private void ChatWindow_Move(object sender, EventArgs e)
        {

            //TODO: Add Docking code
            //Rectangle ScreenRect = Screen.GetBounds(new Point(0, 0));
            //this.Left = 0;  // Left Dock
        }


        //Setting the notification sound
        private void asterisk_Click(object sender, EventArgs e)
        {
            SetNotificationSound(NotificationSounds.Asterisk);
        }

        private void beep_Click(object sender, EventArgs e)
        {
            SetNotificationSound(NotificationSounds.Beep);
        }

        private void exclaim_Click(object sender, EventArgs e)
        {
            SetNotificationSound(NotificationSounds.Exclamation);
        }


        private void SetNotificationSound(NotificationSounds Sound)
        {
            SelectedSound = Sound;

            switch (Sound)
            {
                case NotificationSounds.Asterisk:
                    {
                        asterisk.Checked = true;
                        exclaim.Checked = false;
                        beep.Checked = false;
                    }
                    break;
                case NotificationSounds.Beep:
                    {
                        asterisk.Checked = false;
                        exclaim.Checked = false;
                        beep.Checked = true;
                    }
                    break;
                case NotificationSounds.Exclamation:
                    {
                        asterisk.Checked = false;
                        exclaim.Checked = true;
                        beep.Checked = false;
                    }
                    break;
            }

        }
    }
}
