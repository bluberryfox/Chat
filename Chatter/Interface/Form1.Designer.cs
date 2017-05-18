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
            this.chatMsg = new System.Windows.Forms.RichTextBox();
            this.chatSend = new System.Windows.Forms.Button();
            this.guiChat = new System.Windows.Forms.Label();
            this.onlineVisitors = new System.Windows.Forms.TextBox();
            this.onlineLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // enterChat
            // 
            this.enterChat.Location = new System.Drawing.Point(226, 4);
            this.enterChat.Name = "enterChat";
            this.enterChat.Size = new System.Drawing.Size(123, 23);
            this.enterChat.TabIndex = 0;
            this.enterChat.Text = "Войти в чат";
            this.enterChat.UseVisualStyleBackColor = true;
            this.enterChat.Click += new System.EventHandler(this.enterChat_Click);
            // 
            // gui_userName
            // 
            this.guiuserName.AutoSize = true;
            this.guiUserName.Location = new System.Drawing.Point(10, 9);
            this.guiUserName.Name = "gui_userName";
            this.guiUserName.Size = new System.Drawing.Size(107, 13);
            this.guiUserName.TabIndex = 1;
            this.guiUserName.Text = "Введите ваше имя: ";
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
            this.chatBox.Location = new System.Drawing.Point(12, 74);
            this.chatBox.Multiline = true;
            this.chatBox.Name = "chatBox";
            this.chatBox.ReadOnly = true;
            this.chatBox.Size = new System.Drawing.Size(395, 275);
            this.chatBox.TabIndex = 3;
           //this.chatBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chatBox_KeyDown);
            // 
            // chat_msg
            // 
            this.chatMsg.Enabled = false;
            this.chatMsg.Location = new System.Drawing.Point(12, 344);
            this.chatMsg.Name = "chat_msg";
            this.chatMsg.Size = new System.Drawing.Size(395, 20);
            this.chatMsg.TabIndex = 4;
            this.chatMsg.WordWrap = true;
            this.chatMsg.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chat_msg_KeyDown);
            // 
            // chat_send
            // 
            this.chatSend.Enabled = false;
            this.chatSend.Location = new System.Drawing.Point(413, 342);
            this.chatSend.Name = "chat_send";
            this.chatSend.Size = new System.Drawing.Size(123, 23);
            this.chatSend.TabIndex = 5;
            this.chatSend.Text = "Отправить";
            this.chatSend.UseVisualStyleBackColor = true;
            this.chaSend.Click += new System.EventHandler(this.chat_send_Click);
            // 
            // gui_chat
            // 
            this.guiChat.AutoSize = true;
            this.guiChat.Location = new System.Drawing.Point(12, 45);
            this.guiChat.Name = "gui_chat";
            this.guiChat.Size = new System.Drawing.Size(29, 13);
            this.guiChat.TabIndex = 6;
            this.guiChat.Text = "Чат:";
            // 
            // onlineVisitors
            // 
            this.onlineVisitors.Location = new System.Drawing.Point(414, 61);
            this.onlineVisitors.Multiline = true;
            this.onlineVisitors.Name = "onlineVisitors";
            this.onlineVisitors.Size = new System.Drawing.Size(121, 275);
            this.onlineVisitors.TabIndex = 7;
            this.onlineVisitors.Enabled = false;
            this.onlineVisitors.ReadOnly = true;
            // 
            // onlineLabel
            // 
            this.onlineLabel.AutoSize = true;
            this.onlineLabel.Location = new System.Drawing.Point(413, 44);
            this.onlineLabel.Name = "onlineLabel";
            this.onlineLabel.Size = new System.Drawing.Size(45, 13);
            this.onlineLabel.TabIndex = 8;
            this.onlineLabel.Text = "Онлайн";
            // 
            // ChatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 385);
            this.Controls.Add(this.onlineLabel);
            this.Controls.Add(this.onlineVisitors);
            this.Controls.Add(this.gui_chat);
            this.Controls.Add(this.chat_send);
            this.Controls.Add(this.chat_msg);
            this.Controls.Add(this.chatBox);
            this.Controls.Add(this.userName);
            this.Controls.Add(this.gui_userName);
            this.Controls.Add(this.enterChat);
            this.Name = "ChatForm";
            this.Text = "Чат";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button enterChat;
        private System.Windows.Forms.Label gui_userName;
        private System.Windows.Forms.TextBox userName;
        private System.Windows.Forms.TextBox chatBox;
        private System.Windows.Forms.RichTextBox chat_msg;
        private System.Windows.Forms.Button chat_send;
        private System.Windows.Forms.Label gui_chat;
        private System.Windows.Forms.TextBox onlineVisitors;
        private System.Windows.Forms.Label onlineLabel;
    }
}

