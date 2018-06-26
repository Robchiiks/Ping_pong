namespace Pingpong
{
    partial class StartScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartScreen));
            this.StartPanel = new System.Windows.Forms.Panel();
            this.OptionsPanel = new System.Windows.Forms.Panel();
            this.AudioPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // StartPanel
            // 
            this.StartPanel.BackColor = System.Drawing.Color.Transparent;
            this.StartPanel.Location = new System.Drawing.Point(227, 219);
            this.StartPanel.Name = "StartPanel";
            this.StartPanel.Size = new System.Drawing.Size(108, 41);
            this.StartPanel.TabIndex = 0;
            this.StartPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.StartPanel_MouseClick);
            // 
            // OptionsPanel
            // 
            this.OptionsPanel.BackColor = System.Drawing.Color.Transparent;
            this.OptionsPanel.Location = new System.Drawing.Point(211, 279);
            this.OptionsPanel.Name = "OptionsPanel";
            this.OptionsPanel.Size = new System.Drawing.Size(143, 35);
            this.OptionsPanel.TabIndex = 1;
            this.OptionsPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.OptionsPanel_Paint);
            this.OptionsPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OptionsPanel_MouseClick);
            // 
            // AudioPanel
            // 
            this.AudioPanel.BackColor = System.Drawing.Color.Transparent;
            this.AudioPanel.Location = new System.Drawing.Point(164, 333);
            this.AudioPanel.Name = "AudioPanel";
            this.AudioPanel.Size = new System.Drawing.Size(234, 43);
            this.AudioPanel.TabIndex = 2;
            this.AudioPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.AudioPanel_MouseClick);
            // 
            // StartScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Pingpong.Properties.Resources.kaka;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(562, 442);
            this.Controls.Add(this.AudioPanel);
            this.Controls.Add(this.OptionsPanel);
            this.Controls.Add(this.StartPanel);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "StartScreen";
            this.Text = "PingPong1337";
            this.Load += new System.EventHandler(this.StartScreen_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel StartPanel;
        private System.Windows.Forms.Panel OptionsPanel;
        private System.Windows.Forms.Panel AudioPanel;
    }
}