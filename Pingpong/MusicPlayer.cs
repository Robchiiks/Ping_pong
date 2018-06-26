using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Collections;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Windows.Forms.VisualStyles;
using WMPLib;

namespace Pingpong
{
    public partial class MusicPlayer : Form
    {
        string[] FileName;
        public MusicPlayer()
        {
            InitializeComponent();
            axWindowsMediaPlayer1.CreateControl();
            String filterfile = "(*.mp3; *.wav)|*.mp3; *.wav";
            OpenFileDialog bukaFile = new OpenFileDialog();
            bukaFile.Filter = filterfile;
        }
        public void OpenButton_Click(object sender, EventArgs e)
        {

        }
        private void MusicPlayer_Load(object sender, EventArgs e)
        {
            
        }

        private void PlaylistLstBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //axWindowsMediaPlayer2.Ctlcontrols.play();
            //string mediaPath = ((ListBox)PlaylistLstBox.SelectedValue).Items.ToString();
            ////axWindowsMediaPlayer2 = new Uri(mediaPath);
            //axWindowsMediaPlayer2.Ctlcontrols.play();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            try
            {
                Owner.Show();
                Owner.Location = new Point(this.Left + this.Width, this.Top);
                
            }
            catch (Exception NullReferenceException)
            {
                StartScreen start = new StartScreen();
                start.Show();
            }
            
        }

        private void OpenBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog bukaFile = new OpenFileDialog();
            bukaFile.Multiselect = true;
            if (bukaFile.ShowDialog() == DialogResult.OK)
            {
                FileName = bukaFile.SafeFileNames;
                for (int i = 0; i <= FileName.Length - 1; i++)
                {
                    PlaylistLstBox.Items.Add((FileName[i]));
                }
                axWindowsMediaPlayer2.currentPlaylist = axWindowsMediaPlayer2.newPlaylist("aa", "");
                foreach (string fn in bukaFile.FileNames)
                {
                    axWindowsMediaPlayer2.currentPlaylist.appendItem(axWindowsMediaPlayer2.newMedia(fn));
                }
                axWindowsMediaPlayer2.Ctlcontrols.play();
            }
        }

        private void MusicPlayer_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}
