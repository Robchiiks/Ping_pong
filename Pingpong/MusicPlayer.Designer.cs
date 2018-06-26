namespace Pingpong
{
    partial class MusicPlayer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MusicPlayer));
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.PlaylistListbox = new System.Windows.Forms.ListBox();
            this.OpenButton = new System.Windows.Forms.Button();
            this.axWindowsMediaPlayer2 = new AxWMPLib.AxWindowsMediaPlayer();
            this.PlaylistLstBox = new System.Windows.Forms.ListBox();
            this.OpenBtn = new System.Windows.Forms.Button();
            this.BackButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer2)).BeginInit();
            this.SuspendLayout();
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(1, 152);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(362, 51);
            this.axWindowsMediaPlayer1.TabIndex = 0;
            // 
            // PlaylistListbox
            // 
            this.PlaylistListbox.FormattingEnabled = true;
            this.PlaylistListbox.Location = new System.Drawing.Point(1, 60);
            this.PlaylistListbox.Name = "PlaylistListbox";
            this.PlaylistListbox.Size = new System.Drawing.Size(362, 95);
            this.PlaylistListbox.TabIndex = 1;
            // 
            // OpenButton
            // 
            this.OpenButton.Location = new System.Drawing.Point(1, 13);
            this.OpenButton.Name = "OpenButton";
            this.OpenButton.Size = new System.Drawing.Size(94, 23);
            this.OpenButton.TabIndex = 2;
            this.OpenButton.Text = "Open";
            this.OpenButton.UseVisualStyleBackColor = true;
            // 
            // axWindowsMediaPlayer2
            // 
            this.axWindowsMediaPlayer2.Enabled = true;
            this.axWindowsMediaPlayer2.Location = new System.Drawing.Point(1, 0);
            this.axWindowsMediaPlayer2.Name = "axWindowsMediaPlayer2";
            this.axWindowsMediaPlayer2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer2.OcxState")));
            this.axWindowsMediaPlayer2.Size = new System.Drawing.Size(375, 225);
            this.axWindowsMediaPlayer2.TabIndex = 0;
            // 
            // PlaylistLstBox
            // 
            this.PlaylistLstBox.FormattingEnabled = true;
            this.PlaylistLstBox.Location = new System.Drawing.Point(82, 231);
            this.PlaylistLstBox.Name = "PlaylistLstBox";
            this.PlaylistLstBox.Size = new System.Drawing.Size(294, 95);
            this.PlaylistLstBox.TabIndex = 1;
            this.PlaylistLstBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.PlaylistLstBox_MouseDoubleClick);
            // 
            // OpenBtn
            // 
            this.OpenBtn.Location = new System.Drawing.Point(1, 231);
            this.OpenBtn.Name = "OpenBtn";
            this.OpenBtn.Size = new System.Drawing.Size(75, 46);
            this.OpenBtn.TabIndex = 2;
            this.OpenBtn.Text = "Open";
            this.OpenBtn.UseVisualStyleBackColor = true;
            this.OpenBtn.Click += new System.EventHandler(this.OpenBtn_Click);
            // 
            // BackButton
            // 
            this.BackButton.Location = new System.Drawing.Point(1, 283);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(75, 43);
            this.BackButton.TabIndex = 3;
            this.BackButton.Text = "Back";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // MusicPlayer
            // 
            this.ClientSize = new System.Drawing.Size(380, 329);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.OpenBtn);
            this.Controls.Add(this.PlaylistLstBox);
            this.Controls.Add(this.axWindowsMediaPlayer2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MusicPlayer";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MusicPlayer_FormClosed);
            this.Load += new System.EventHandler(this.MusicPlayer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private System.Windows.Forms.ListBox PlaylistListbox;
        private System.Windows.Forms.Button OpenButton;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer2;
        private System.Windows.Forms.ListBox PlaylistLstBox;
        private System.Windows.Forms.Button OpenBtn;
        private System.Windows.Forms.Button BackButton;
    }
}