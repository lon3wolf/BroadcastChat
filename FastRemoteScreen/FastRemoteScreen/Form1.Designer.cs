namespace FastChat
{
    partial class ChatWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChatWindow));
            this.Message = new System.Windows.Forms.TextBox();
            this.Conversation = new System.Windows.Forms.TextBox();
            this.ChatMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.clearChat = new System.Windows.Forms.ToolStripMenuItem();
            this.saveChatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notificationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.onTopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.soundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asterisk = new System.Windows.Forms.ToolStripMenuItem();
            this.beep = new System.Windows.Forms.ToolStripMenuItem();
            this.exclaim = new System.Windows.Forms.ToolStripMenuItem();
            this.AutoStart = new System.Windows.Forms.ToolStripMenuItem();
            this.UserName = new System.Windows.Forms.TextBox();
            this.Start = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.About = new System.Windows.Forms.LinkLabel();
            this.MessageNotification = new System.Windows.Forms.NotifyIcon(this.components);
            this.SysTrayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HideLink = new System.Windows.Forms.LinkLabel();
            this.Ques = new System.Windows.Forms.Button();
            this.ImOnline = new System.Windows.Forms.Button();
            this.Options = new System.Windows.Forms.LinkLabel();
            this.HTMLConversation = new System.Windows.Forms.WebBrowser();
            this.Msg = new System.Windows.Forms.Button();
            this.Ping = new System.Windows.Forms.Button();
            this.Echo = new System.Windows.Forms.Button();
            this.Send = new System.Windows.Forms.Button();
            this.ChatMenu.SuspendLayout();
            this.SysTrayMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // Message
            // 
            this.Message.AutoCompleteCustomSource.AddRange(new string[] {
            "MsgBox:",
            "QuesBox:",
            "Hi!",
            "Hello!",
            "Come Here!",
            "Hold on!",
            "What?",
            "Why?"});
            this.Message.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.Message.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.Message.BackColor = System.Drawing.Color.White;
            this.Message.Enabled = false;
            this.Message.ForeColor = System.Drawing.Color.Navy;
            this.Message.Location = new System.Drawing.Point(12, 297);
            this.Message.Name = "Message";
            this.Message.Size = new System.Drawing.Size(216, 20);
            this.Message.TabIndex = 2;
            this.Message.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Message_KeyPress);
            // 
            // Conversation
            // 
            this.Conversation.BackColor = System.Drawing.Color.Black;
            this.Conversation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Conversation.CausesValidation = false;
            this.Conversation.ContextMenuStrip = this.ChatMenu;
            this.Conversation.Enabled = false;
            this.Conversation.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Conversation.ForeColor = System.Drawing.Color.White;
            this.Conversation.Location = new System.Drawing.Point(12, 31);
            this.Conversation.Multiline = true;
            this.Conversation.Name = "Conversation";
            this.Conversation.ReadOnly = true;
            this.Conversation.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Conversation.Size = new System.Drawing.Size(290, 231);
            this.Conversation.TabIndex = 5;
            this.Conversation.TextChanged += new System.EventHandler(this.Conversation_TextChanged);
            // 
            // ChatMenu
            // 
            this.ChatMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearChat,
            this.saveChatToolStripMenuItem,
            this.notificationsToolStripMenuItem,
            this.onTopToolStripMenuItem,
            this.soundToolStripMenuItem,
            this.AutoStart});
            this.ChatMenu.Name = "ChatMenu";
            this.ChatMenu.Size = new System.Drawing.Size(152, 136);
            // 
            // clearChat
            // 
            this.clearChat.Name = "clearChat";
            this.clearChat.Size = new System.Drawing.Size(151, 22);
            this.clearChat.Text = "&Clear Chat";
            this.clearChat.Click += new System.EventHandler(this.clearChat_Click);
            // 
            // saveChatToolStripMenuItem
            // 
            this.saveChatToolStripMenuItem.Name = "saveChatToolStripMenuItem";
            this.saveChatToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.saveChatToolStripMenuItem.Text = "&Save Chat";
            this.saveChatToolStripMenuItem.Click += new System.EventHandler(this.saveChatToolStripMenuItem_Click);
            // 
            // notificationsToolStripMenuItem
            // 
            this.notificationsToolStripMenuItem.Checked = true;
            this.notificationsToolStripMenuItem.CheckOnClick = true;
            this.notificationsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.notificationsToolStripMenuItem.Name = "notificationsToolStripMenuItem";
            this.notificationsToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.notificationsToolStripMenuItem.Text = "&Notifications";
            this.notificationsToolStripMenuItem.Click += new System.EventHandler(this.notificationsToolStripMenuItem_Click);
            // 
            // onTopToolStripMenuItem
            // 
            this.onTopToolStripMenuItem.CheckOnClick = true;
            this.onTopToolStripMenuItem.Name = "onTopToolStripMenuItem";
            this.onTopToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.onTopToolStripMenuItem.Text = "On &Top";
            this.onTopToolStripMenuItem.Click += new System.EventHandler(this.onTopToolStripMenuItem_Click);
            // 
            // soundToolStripMenuItem
            // 
            this.soundToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.asterisk,
            this.beep,
            this.exclaim});
            this.soundToolStripMenuItem.Name = "soundToolStripMenuItem";
            this.soundToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.soundToolStripMenuItem.Text = "&Sound";
            // 
            // asterisk
            // 
            this.asterisk.CheckOnClick = true;
            this.asterisk.Name = "asterisk";
            this.asterisk.Size = new System.Drawing.Size(115, 22);
            this.asterisk.Text = "&Asterisk";
            this.asterisk.Click += new System.EventHandler(this.asterisk_Click);
            // 
            // beep
            // 
            this.beep.CheckOnClick = true;
            this.beep.Name = "beep";
            this.beep.Size = new System.Drawing.Size(115, 22);
            this.beep.Text = "&Beep";
            this.beep.Click += new System.EventHandler(this.beep_Click);
            // 
            // exclaim
            // 
            this.exclaim.Checked = true;
            this.exclaim.CheckOnClick = true;
            this.exclaim.CheckState = System.Windows.Forms.CheckState.Checked;
            this.exclaim.Name = "exclaim";
            this.exclaim.Size = new System.Drawing.Size(115, 22);
            this.exclaim.Text = "&Exclaim";
            this.exclaim.Click += new System.EventHandler(this.exclaim_Click);
            // 
            // AutoStart
            // 
            this.AutoStart.CheckOnClick = true;
            this.AutoStart.Name = "AutoStart";
            this.AutoStart.Size = new System.Drawing.Size(151, 22);
            this.AutoStart.Text = "Start at &Log on";
            this.AutoStart.Click += new System.EventHandler(this.AutoStart_Click);
            // 
            // UserName
            // 
            this.UserName.BackColor = System.Drawing.Color.Black;
            this.UserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.UserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserName.ForeColor = System.Drawing.Color.White;
            this.UserName.Location = new System.Drawing.Point(60, 7);
            this.UserName.Name = "UserName";
            this.UserName.Size = new System.Drawing.Size(119, 20);
            this.UserName.TabIndex = 0;
            // 
            // Start
            // 
            this.Start.BackColor = System.Drawing.SystemColors.Control;
            this.Start.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Start.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Start.Location = new System.Drawing.Point(227, 5);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(75, 23);
            this.Start.TabIndex = 1;
            this.Start.Text = "Start";
            this.Start.UseVisualStyleBackColor = false;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(16, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Name:";
            // 
            // About
            // 
            this.About.AutoSize = true;
            this.About.BackColor = System.Drawing.Color.Transparent;
            this.About.LinkColor = System.Drawing.Color.Black;
            this.About.Location = new System.Drawing.Point(272, 326);
            this.About.Name = "About";
            this.About.Size = new System.Drawing.Size(34, 13);
            this.About.TabIndex = 6;
            this.About.TabStop = true;
            this.About.Text = "about";
            this.About.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.About_LinkClicked);
            // 
            // MessageNotification
            // 
            this.MessageNotification.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.MessageNotification.BalloonTipText = "New Xinx Broadcast Message";
            this.MessageNotification.BalloonTipTitle = "New XBC Message";
            this.MessageNotification.ContextMenuStrip = this.SysTrayMenu;
            this.MessageNotification.Icon = ((System.Drawing.Icon)(resources.GetObject("MessageNotification.Icon")));
            this.MessageNotification.Text = "New Xinx Broadcast Message";
            this.MessageNotification.Visible = true;
            this.MessageNotification.DoubleClick += new System.EventHandler(this.MessageNotification_Click);
            this.MessageNotification.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.MessageNotification_MouseDoubleClick);
            // 
            // SysTrayMenu
            // 
            this.SysTrayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.SysTrayMenu.Name = "SysTrayMenu";
            this.SysTrayMenu.Size = new System.Drawing.Size(104, 48);
            // 
            // showToolStripMenuItem
            // 
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.showToolStripMenuItem.Text = "Show";
            this.showToolStripMenuItem.Click += new System.EventHandler(this.showToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // HideLink
            // 
            this.HideLink.AutoSize = true;
            this.HideLink.BackColor = System.Drawing.Color.Transparent;
            this.HideLink.LinkColor = System.Drawing.Color.Black;
            this.HideLink.Location = new System.Drawing.Point(9, 326);
            this.HideLink.Name = "HideLink";
            this.HideLink.Size = new System.Drawing.Size(29, 13);
            this.HideLink.TabIndex = 7;
            this.HideLink.TabStop = true;
            this.HideLink.Text = "Hide";
            this.HideLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Hide_LinkClicked);
            // 
            // Ques
            // 
            this.Ques.AccessibleDescription = "Ask question";
            this.Ques.AccessibleName = "Ask question";
            this.Ques.BackColor = System.Drawing.SystemColors.Control;
            this.Ques.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Ques.FlatAppearance.BorderSize = 0;
            this.Ques.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Ques.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ques.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.Ques.Location = new System.Drawing.Point(76, 269);
            this.Ques.Name = "Ques";
            this.Ques.Size = new System.Drawing.Size(26, 23);
            this.Ques.TabIndex = 10;
            this.Ques.Text = "Q";
            this.Ques.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.Ques.UseVisualStyleBackColor = false;
            this.Ques.Click += new System.EventHandler(this.Ques_Click);
            // 
            // ImOnline
            // 
            this.ImOnline.AccessibleDescription = "Sends \"I\'m Online\"";
            this.ImOnline.AccessibleName = "Sends \"I\'m Online\"";
            this.ImOnline.BackColor = System.Drawing.SystemColors.Control;
            this.ImOnline.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ImOnline.FlatAppearance.BorderSize = 0;
            this.ImOnline.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ImOnline.Font = new System.Drawing.Font("Byington", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ImOnline.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.ImOnline.Location = new System.Drawing.Point(140, 269);
            this.ImOnline.Name = "ImOnline";
            this.ImOnline.Size = new System.Drawing.Size(26, 23);
            this.ImOnline.TabIndex = 12;
            this.ImOnline.Text = "#";
            this.ImOnline.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.ImOnline.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.ImOnline.UseVisualStyleBackColor = false;
            this.ImOnline.Click += new System.EventHandler(this.ImOnline_Click);
            // 
            // Options
            // 
            this.Options.AutoSize = true;
            this.Options.BackColor = System.Drawing.Color.Transparent;
            this.Options.ContextMenuStrip = this.ChatMenu;
            this.Options.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Options.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.Options.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.Options.LinkColor = System.Drawing.Color.Black;
            this.Options.Location = new System.Drawing.Point(176, 274);
            this.Options.Name = "Options";
            this.Options.Size = new System.Drawing.Size(52, 13);
            this.Options.TabIndex = 13;
            this.Options.TabStop = true;
            this.Options.Text = "Options >";
            this.Options.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.Options.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Options_LinkClicked);
            // 
            // HTMLConversation
            // 
            this.HTMLConversation.AllowNavigation = false;
            this.HTMLConversation.AllowWebBrowserDrop = false;
            this.HTMLConversation.ContextMenuStrip = this.ChatMenu;
            this.HTMLConversation.IsWebBrowserContextMenuEnabled = false;
            this.HTMLConversation.Location = new System.Drawing.Point(12, 31);
            this.HTMLConversation.Margin = new System.Windows.Forms.Padding(0);
            this.HTMLConversation.MinimumSize = new System.Drawing.Size(20, 20);
            this.HTMLConversation.Name = "HTMLConversation";
            this.HTMLConversation.ScriptErrorsSuppressed = true;
            this.HTMLConversation.Size = new System.Drawing.Size(290, 232);
            this.HTMLConversation.TabIndex = 14;
            this.HTMLConversation.WebBrowserShortcutsEnabled = false;
            // 
            // Msg
            // 
            this.Msg.AccessibleDescription = "Pops Message";
            this.Msg.AccessibleName = "Pops Message";
            this.Msg.BackColor = System.Drawing.SystemColors.Control;
            this.Msg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Msg.FlatAppearance.BorderSize = 0;
            this.Msg.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Msg.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Msg.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.Msg.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.Msg.Location = new System.Drawing.Point(108, 269);
            this.Msg.Name = "Msg";
            this.Msg.Size = new System.Drawing.Size(26, 23);
            this.Msg.TabIndex = 11;
            this.Msg.Text = "!";
            this.Msg.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Msg.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.Msg.UseVisualStyleBackColor = false;
            this.Msg.Click += new System.EventHandler(this.Msg_Click);
            // 
            // Ping
            // 
            this.Ping.AccessibleDescription = "Buzz users!!";
            this.Ping.AccessibleName = "Buzz users!!";
            this.Ping.BackgroundImage = global::FastChat.Properties.Resources.favourites_32;
            this.Ping.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Ping.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.Ping.Location = new System.Drawing.Point(12, 269);
            this.Ping.Name = "Ping";
            this.Ping.Size = new System.Drawing.Size(26, 23);
            this.Ping.TabIndex = 8;
            this.Ping.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Ping.UseVisualStyleBackColor = true;
            this.Ping.Click += new System.EventHandler(this.Ping_Click);
            // 
            // Echo
            // 
            this.Echo.AccessibleDescription = "Search online users";
            this.Echo.AccessibleName = "Search online users";
            this.Echo.BackgroundImage = global::FastChat.Properties.Resources.search_32_h;
            this.Echo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Echo.Location = new System.Drawing.Point(44, 269);
            this.Echo.Name = "Echo";
            this.Echo.Size = new System.Drawing.Size(26, 23);
            this.Echo.TabIndex = 9;
            this.Echo.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.Echo.UseVisualStyleBackColor = true;
            this.Echo.Click += new System.EventHandler(this.Echo_Click);
            // 
            // Send
            // 
            this.Send.BackColor = System.Drawing.SystemColors.Control;
            this.Send.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Send.Enabled = false;
            this.Send.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Send.ForeColor = System.Drawing.Color.White;
            this.Send.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.Send.Location = new System.Drawing.Point(234, 268);
            this.Send.Name = "Send";
            this.Send.Size = new System.Drawing.Size(68, 51);
            this.Send.TabIndex = 3;
            this.Send.Text = "send >>";
            this.Send.UseVisualStyleBackColor = false;
            this.Send.Click += new System.EventHandler(this.Send_Click);
            // 
            // ChatWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(324, 344);
            this.Controls.Add(this.ImOnline);
            this.Controls.Add(this.Ques);
            this.Controls.Add(this.HTMLConversation);
            this.Controls.Add(this.Ping);
            this.Controls.Add(this.Options);
            this.Controls.Add(this.HideLink);
            this.Controls.Add(this.Msg);
            this.Controls.Add(this.Echo);
            this.Controls.Add(this.About);
            this.Controls.Add(this.Send);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Start);
            this.Controls.Add(this.UserName);
            this.Controls.Add(this.Conversation);
            this.Controls.Add(this.Message);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(330, 380);
            this.MinimumSize = new System.Drawing.Size(330, 362);
            this.Name = "ChatWindow";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "XBC - Xinx Broadcast Chat - Sanil";
            this.Deactivate += new System.EventHandler(this.ChatWindow_Deactivate);
            this.Load += new System.EventHandler(this.ChatWindow_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ChatWindow_Paint);
            this.Activated += new System.EventHandler(this.ChatWindow_Activated);
            this.Move += new System.EventHandler(this.ChatWindow_Move);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChatWindow_FormClosing);
            this.ChatMenu.ResumeLayout(false);
            this.SysTrayMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Message;
        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Send;
        public System.Windows.Forms.TextBox Conversation;
        private System.Windows.Forms.LinkLabel About;
        public System.Windows.Forms.NotifyIcon MessageNotification;
        private System.Windows.Forms.LinkLabel HideLink;
        public System.Windows.Forms.TextBox UserName;
        private System.Windows.Forms.ContextMenuStrip SysTrayMenu;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Button Ping;
        private System.Windows.Forms.Button Echo;
        private System.Windows.Forms.Button Ques;
        private System.Windows.Forms.Button Msg;
        private System.Windows.Forms.Button ImOnline;
        private System.Windows.Forms.ContextMenuStrip ChatMenu;
        private System.Windows.Forms.ToolStripMenuItem clearChat;
        private System.Windows.Forms.ToolStripMenuItem saveChatToolStripMenuItem;
        private System.Windows.Forms.LinkLabel Options;
        private System.Windows.Forms.ToolStripMenuItem notificationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem onTopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem soundToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem asterisk;
        private System.Windows.Forms.ToolStripMenuItem beep;
        private System.Windows.Forms.ToolStripMenuItem exclaim;
        private System.Windows.Forms.ToolStripMenuItem AutoStart;
        public System.Windows.Forms.WebBrowser HTMLConversation;
    }
}

