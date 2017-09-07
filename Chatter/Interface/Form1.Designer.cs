namespace Interface
{
    partial class ChatForm
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
            this.enterChat = new System.Windows.Forms.Button();
            this.guiUserName = new System.Windows.Forms.Label();
            this.userName = new System.Windows.Forms.TextBox();
            this.chatBox = new System.Windows.Forms.TextBox();
            this.chatMsg = new System.Windows.Forms.TextBox();
            this.chatSend = new System.Windows.Forms.Button();
            this.guiChat = new System.Windows.Forms.Label();
            this.onlineVisitors = new System.Windows.Forms.TextBox();
            this.onlineLabel = new System.Windows.Forms.Label();
            this.textBoxIP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxIgnore = new System.Windows.Forms.TextBox();
            this.buttonIgnore = new System.Windows.Forms.Button();
            this.buttonDisconnect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // enterChat
            // 
            this.enterChat.Location = new System.Drawing.Point(254, 6);
            this.enterChat.Name = "enterChat";
            this.enterChat.Size = new System.Drawing.Size(123, 23);
            this.enterChat.TabIndex = 0;
            this.enterChat.Text = "Войти в чат";
            this.enterChat.UseVisualStyleBackColor = true;
            this.enterChat.Click += new System.EventHandler(this.enterChat_Click);
            // 
            // guiUserName
            // 
            this.guiUserName.AutoSize = true;
            this.guiUserName.Location = new System.Drawing.Point(10, 9);
            this.guiUserName.Name = "guiUserName";
            this.guiUserName.Size = new System.Drawing.Size(32, 13);
            this.guiUserName.TabIndex = 1;
            this.guiUserName.Text = "Имя:";
            // 
            // userName
            // 
            this.userName.Location = new System.Drawing.Point(120, 5);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(100, 20);
            this.userName.TabIndex = 2;
            // 
            // chatBox
            // 
            this.chatBox.Enabled = false;
            this.chatBox.Location = new System.Drawing.Point(141, 98);
            this.chatBox.Multiline = true;
            this.chatBox.Name = "chatBox";
            this.chatBox.ReadOnly = true;
            this.chatBox.Size = new System.Drawing.Size(395, 288);
            this.chatBox.TabIndex = 3;
            // 
            // chatMsg
            // 
            this.chatMsg.Enabled = false;
            this.chatMsg.Location = new System.Drawing.Point(141, 392);
            this.chatMsg.Name = "chatMsg";
            this.chatMsg.Size = new System.Drawing.Size(266, 20);
            this.chatMsg.TabIndex = 4;
            this.chatMsg.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chatMsg_KeyDown);
            // 
            // chatSend
            // 
            this.chatSend.Enabled = false;
            this.chatSend.Location = new System.Drawing.Point(413, 392);
            this.chatSend.Name = "chatSend";
            this.chatSend.Size = new System.Drawing.Size(123, 23);
            this.chatSend.TabIndex = 5;
            this.chatSend.Text = "Отправить";
            this.chatSend.UseVisualStyleBackColor = true;
            this.chatSend.Click += new System.EventHandler(this.chatSend_Click);
            // 
            // guiChat
            // 
            this.guiChat.AutoSize = true;
            this.guiChat.Location = new System.Drawing.Point(138, 68);
            this.guiChat.Name = "guiChat";
            this.guiChat.Size = new System.Drawing.Size(29, 13);
            this.guiChat.TabIndex = 6;
            this.guiChat.Text = "Чат:";
            // 
            // onlineVisitors
            // 
            this.onlineVisitors.Enabled = false;
            this.onlineVisitors.Location = new System.Drawing.Point(12, 98);
            this.onlineVisitors.Multiline = true;
            this.onlineVisitors.Name = "onlineVisitors";
            this.onlineVisitors.ReadOnly = true;
            this.onlineVisitors.Size = new System.Drawing.Size(121, 314);
            this.onlineVisitors.TabIndex = 7;
            // 
            // onlineLabel
            // 
            this.onlineLabel.AutoSize = true;
            this.onlineLabel.Location = new System.Drawing.Point(9, 68);
            this.onlineLabel.Name = "onlineLabel";
            this.onlineLabel.Size = new System.Drawing.Size(115, 13);
            this.onlineLabel.TabIndex = 8;
            this.onlineLabel.Text = "Пользователи в сети";
            // 
            // textBoxIP
            // 
            this.textBoxIP.Location = new System.Drawing.Point(120, 29);
            this.textBoxIP.Name = "textBoxIP";
            this.textBoxIP.Size = new System.Drawing.Size(100, 20);
            this.textBoxIP.TabIndex = 10;
            this.textBoxIP.Text = "127.0.0.1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "IP-адрес сервера:";
            // 
            // textBoxIgnore
            // 
            this.textBoxIgnore.Location = new System.Drawing.Point(412, 6);
            this.textBoxIgnore.Name = "textBoxIgnore";
            this.textBoxIgnore.Size = new System.Drawing.Size(123, 20);
            this.textBoxIgnore.TabIndex = 11;
            // 
            // buttonIgnore
            // 
            this.buttonIgnore.Location = new System.Drawing.Point(412, 32);
            this.buttonIgnore.Name = "buttonIgnore";
            this.buttonIgnore.Size = new System.Drawing.Size(123, 20);
            this.buttonIgnore.TabIndex = 12;
            this.buttonIgnore.Text = "В игнор\\Антиигнор";
            this.buttonIgnore.UseVisualStyleBackColor = true;
            this.buttonIgnore.Click += new System.EventHandler(this.buttonIgnore_Click);
            // 
            // buttonDisconnect
            // 
            this.buttonDisconnect.Enabled = false;
            this.buttonDisconnect.Location = new System.Drawing.Point(254, 29);
            this.buttonDisconnect.Name = "buttonDisconnect";
            this.buttonDisconnect.Size = new System.Drawing.Size(123, 23);
            this.buttonDisconnect.TabIndex = 13;
            this.buttonDisconnect.Text = "Выйти из чата";
            this.buttonDisconnect.UseVisualStyleBackColor = true;
            this.buttonDisconnect.Click += new System.EventHandler(this.buttonDisconnect_Click);
            // 
            // ChatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(548, 424);
            this.Controls.Add(this.buttonDisconnect);
            this.Controls.Add(this.buttonIgnore);
            this.Controls.Add(this.textBoxIgnore);
            this.Controls.Add(this.textBoxIP);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.onlineLabel);
            this.Controls.Add(this.onlineVisitors);
            this.Controls.Add(this.guiChat);
            this.Controls.Add(this.chatSend);
            this.Controls.Add(this.chatMsg);
            this.Controls.Add(this.chatBox);
            this.Controls.Add(this.userName);
            this.Controls.Add(this.guiUserName);
            this.Controls.Add(this.enterChat);
            this.Name = "ChatForm";
            this.Text = "Чат";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button enterChat;
        private System.Windows.Forms.Label guiUserName;
        private System.Windows.Forms.TextBox userName;
        private System.Windows.Forms.TextBox chatBox;
        private System.Windows.Forms.TextBox chatMsg;
        private System.Windows.Forms.Button chatSend;
        private System.Windows.Forms.Label guiChat;
        private System.Windows.Forms.TextBox onlineVisitors;
        private System.Windows.Forms.Label onlineLabel;
        private System.Windows.Forms.TextBox textBoxIP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxIgnore;
        private System.Windows.Forms.Button buttonIgnore;
        private System.Windows.Forms.Button buttonDisconnect;
    }
}

