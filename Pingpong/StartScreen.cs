using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pingpong
{
    public partial class StartScreen : Form
    {
        Settings frm2;
        MusicPlayer frm4;
        public StartScreen()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            if (this.Visible)
            {
                
            }
        }        
        private void StartScreen_Load(object sender, EventArgs e)
        {
        }        
        private void StartPanel_MouseClick(object sender, MouseEventArgs e)
        {
            //Game game = Application.OpenForms.OfType<Game>().FirstOrDefault();
            //if (game != null)
            //    game.ShowDialog();
            //else
            //{
            //    using (game = new Game())
            //    {
            //        game.ShowDialog();
            //    }
            //}
            Game game = new Game();
            game.Tag = this;
            game.Show(this);
            game.Location = this.Location;
            Hide();

        }

        private void OptionsPanel_MouseClick(object sender, MouseEventArgs e)
        {
            if (frm2 == null)
            {
                frm2 = new Settings();   
                frm2.FormClosed += frm2_FormClosed;  //Add eventhandler to cleanup after form closes
            }

            frm2.Show(this);  //Show Form assigning this form as the forms owner
            Hide();
        }
        void frm2_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm2 = null;  //If form is closed make sure reference is set to null
            Show();
        }

        private void AudioPanel_MouseClick(object sender, MouseEventArgs e)
        {
            if (frm4 == null)
            {
                frm4 = new MusicPlayer();
                frm4.FormClosed += frm4_FormClosed;
            }
            frm4.ShowDialog();
            Hide();
        }
        void frm4_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm4 = null;
            Show();
        }

        private void OptionsPanel_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}
