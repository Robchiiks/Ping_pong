using RotatePictureBox;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Pingpong.Properties;
using System.Media;
using System.IO;

namespace Pingpong
{
    public partial class Game : Form
    {
       
        public Game()
        {
            InitializeComponent();
            KeyPreview = true;
            CurrentHitLabel.Visible = true;
            MaxHitLabel.Visible = true;
        }
        
        PictureBox[] Score_Player = new PictureBox[5];  
        PictureBox[] Score_Enemy = new PictureBox[5];   
        Color ScoreColor = Color.Silver;    
        bool Player_Up, Player_Down = false;         
        bool BallGoingLeft = true;                   
        bool GameOn = false;                        
        Random rng = new Random();
        public static WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer();
        string fileName = @"scorelog.txt";
        int Speed_Player, Speed_Enemy, BallSpeed, BallForce;   
        int Round, CurrentHitStreak, MaxHitStreak, playerScore, CPUScore = 0;

        public void ApplySettings()
        {   
            pb_Player.BackColor = Properties.Settings.Default.Color_Player;
            pb_Enemy.BackColor = Properties.Settings.Default.Color_Enemy;
            pb_Ball.BackColor = Properties.Settings.Default.Color_Ball;
            WorldFrame.BackColor = Properties.Settings.Default.Color_Frame;
            BallSpeed = Properties.Settings.Default.BallSpeed;
            timer_Moveball.Interval = Properties.Settings.Default.Timer_Movement;
            timer_Enemy.Interval = Properties.Settings.Default.Timer_Enemy;
            Speed_Enemy = Properties.Settings.Default.EnemySpeed;
            Speed_Player = Properties.Settings.Default.Speed_Player;
        }

        public void RandomStart(Boolean x)
        {

            for (int i = 0; i < rng.Next(5, 10); i++)
            {
                if (x)
                {
                    x = false;
                }
                else
                {
                    x = true;
                }
            }
        }

        public bool Collision_Left(PictureBox obj)
        {
            if (obj.Location.X <= 0)    //vai "obj" picturebox ir aiz ekrāna KREISAJĀ pusē
            {
                return true;
            }
            return false;
        }

        public bool Collision_Right(PictureBox obj)
        {
            if (obj.Location.X + obj.Width >= WorldFrame.Width) //vai obj ir aiz ekrāna LABĀS malas
            {
                return true;
            }
            return false;
        }

        public bool Collision_Up(PictureBox obj)
        {
            if (obj.Location.Y <= 0)    // vai ir VIRS ekrāna
            {
                return true;
            }
            return false;
        }

        public bool Collision_Down(PictureBox obj)
        {
            if (obj.Location.Y + obj.Height >= WorldFrame.Height)   //vai ir ZEM ekrāna
            {
                return true;
            }
            return false;
        }

        public bool Collision_Enemy(PictureBox tar)
        {
            if (tar.Bounds.IntersectsWith(pb_Enemy.Bounds))
            {
                PictureBox temp1 = new PictureBox
                {
                    Bounds = pb_Enemy.Bounds
                };
                CurrentHitStreak++;
                CurrentHitLabel.Text = "Current Hit Streak: " + CurrentHitStreak;
                temp1.SetBounds(temp1.Location.X, temp1.Location.Y, 1, 10);  //10 pikseļi katrai kastei
                if (tar.Bounds.IntersectsWith(temp1.Bounds))
                {
                    BallForce = 3; 
                    return true;
                }
                temp1.SetBounds(temp1.Location.X, temp1.Location.Y + 5, 1, 10); //temp kaste 5 pix tālāk
                if (tar.Bounds.IntersectsWith(temp1.Bounds)) 
                {
                    BallForce = 2; 
                    return true;
                }
                temp1.SetBounds(temp1.Location.X, temp1.Location.Y + 10, 1, 10);
                if (tar.Bounds.IntersectsWith(temp1.Bounds))
                {
                    BallForce = 1;
                    return true;
                }
                temp1.SetBounds(temp1.Location.X, temp1.Location.Y + 10, 1, 10);
                if (tar.Bounds.IntersectsWith(temp1.Bounds))
                {
                    BallForce = 0;
                    return true;
                }
                temp1.SetBounds(temp1.Location.X, temp1.Location.Y + 10, 1, 10);
                if (tar.Bounds.IntersectsWith(temp1.Bounds))
                {
                    BallForce = -1;
                    return true;
                }
                temp1.SetBounds(temp1.Location.X, temp1.Location.Y + 10, 1, 10);
                if (tar.Bounds.IntersectsWith(temp1.Bounds))
                {
                    BallForce = -2;
                    return true;
                }
                temp1.SetBounds(temp1.Location.X, temp1.Location.Y + 10, 1, 10);
                if (tar.Bounds.IntersectsWith(temp1.Bounds))
                {
                    BallForce = -3;
                    return true;
                }
            }

            return false;
        }
        public bool Collision_Player(PictureBox tar)
        {
            
            if (tar.Bounds.IntersectsWith(pb_Player.Bounds))   
            {
                PictureBox temp1 = new PictureBox
                {
                    Bounds = pb_Player.Bounds
                };
                temp1.SetBounds(temp1.Location.X + temp1.Width, temp1.Location.Y, 1, 10);
                CurrentHitStreak++;
                CurrentHitLabel.Text = "Current Hit Streak: " + CurrentHitStreak;

                if (tar.Bounds.IntersectsWith(temp1.Bounds))    
                {
                    BallForce = 3;
                    return true;
                }
                temp1.SetBounds(temp1.Location.X, temp1.Location.Y + 5, 1, 10);
               
                if (tar.Bounds.IntersectsWith(temp1.Bounds))
                {
                    BallForce = 2;
                    return true;
                }
                temp1.SetBounds(temp1.Location.X, temp1.Location.Y + 10, 1, 10);
                
                if (tar.Bounds.IntersectsWith(temp1.Bounds))
                {
                    BallForce = 1;
                    return true;
                }
                temp1.SetBounds(temp1.Location.X, temp1.Location.Y + 10, 1, 10);
                
                if (tar.Bounds.IntersectsWith(temp1.Bounds))
                {
                    BallForce = 0;
                    return true;
                }
                temp1.SetBounds(temp1.Location.X, temp1.Location.Y + 10, 1, 10);
                
                if (tar.Bounds.IntersectsWith(temp1.Bounds))
                {
                    BallForce = -1;
                    return true;
                }
                temp1.SetBounds(temp1.Location.X, temp1.Location.Y + 10, 1, 10);
                
                if (tar.Bounds.IntersectsWith(temp1.Bounds))
                {
                    BallForce = -2;
                    return true;
                }
                temp1.SetBounds(temp1.Location.X, temp1.Location.Y + 10, 1, 10);
               
                if (tar.Bounds.IntersectsWith(temp1.Bounds))
                {
                    BallForce = -3;
                    return true;
                }
                
            }
            return false;
        }

        public void PaintBox(int X, int Y, int W, int H, Color C)
        {
            PictureBox Temp = new PictureBox
            {
                BackColor = C,
                Size = new Size(W, H),
                Location = new Point(X, Y)
            };
            WorldFrame.Controls.Add(Temp);
        }      

       

        
        private void Timer_Moveball_Tick(object sender, EventArgs e)
        {
            ApplySettings();
            if (CurrentHitStreak >= MaxHitStreak)
            {
                MaxHitStreak = CurrentHitStreak;
                MaxHitLabel.Text = "Max Hit Streak: " + CurrentHitStreak;
            }
            if (GameOn)
            {
                if (Player_Up && !Collision_Up(pb_Player))
                {               
                    pb_Player.Top -= Speed_Player;    
                }
                if (Player_Down && !Collision_Down(pb_Player))
                {               
                    pb_Player.Top += Speed_Player;
                }
                if (BallForce > 0)
                {   
                    pb_Ball.Top -= BallForce;//kustina bumbu augšā par #ballforce pixeļiem
                }
                if (BallForce < 0)
                {   
                    pb_Ball.Top -= BallForce;
                }

                if (pb_Ball.Location.Y <= 1)
                {   
                    BallForce = ReverseInt(BallForce, true, true); //ja pieskaras augšai, reverse ball
                }
                
                if (pb_Ball.Location.Y + pb_Ball.Height >= WorldFrame.Height - 1)      //ja pieskaras apakšai, mainas uz pozitīvu un lido augšā
                {
                    BallForce = ReverseInt(BallForce, true, false);
                }

                if (BallGoingLeft)  
                {
                    if (Collision_Left(pb_Ball))    
                    {
                        AddScore(Score_Player);     
                        pb_Ball.Location = new Point(206, 67);//vidus
                        RandomStart(BallGoingLeft);
                        BallForce = 0;
                        CPUScore++;
                    }
                    if (!Collision_Player(pb_Ball)) 
                    {
                        pb_Ball.Left -= BallSpeed;
                    }
                    else
                    {                               
                        BallGoingLeft = false;      //ja pieskaras playerim, kustas pa labi
                    }
                }
                else
                {
                    if (Collision_Right(pb_Ball))  //tas pats, tikai enemy
                    {
                        AddScore(Score_Enemy);
                        pb_Ball.Location = new Point(206, 67);
                        RandomStart(BallGoingLeft);
                        BallForce = 0;
                        playerScore++;
                    }
                    if (!Collision_Enemy(pb_Ball))
                    {
                        pb_Ball.Left += BallSpeed;
                    }
                    else
                    {
                        BallGoingLeft = true;
                    }
                }
            }
        }
        public void CircleThis(PictureBox pic)  //bumba
        {            
            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            gp.AddEllipse(0, 0, pic.Width, pic.Height);
            Region rg = new Region(gp);
            pic.Region = rg;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)      
            {
                case Keys.W:
                case Keys.Up:
                    Player_Down = false;
                    Player_Up = true;
                    break;
                case Keys.S:
                case Keys.Down:
                    Player_Up = false;
                    Player_Down = true;
                    break;
                case Keys.Space:    
                    GameOn = true;
                    RandomStart(BallGoingLeft);
                    label_Start.Visible = false;
                    Game_paused.Visible = false;
                    break;
                case Keys.P:
                    GameOn = false;                    
                    Game_paused.Visible = true;                   
                    Game_paused.Text = "Paused!";
                    break;
            }
        }
        
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                case Keys.Up:
                    Player_Up = false;
                    break;
                case Keys.S:
                case Keys.Down:
                    Player_Down = false;
                    break;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                Score_Player[i] = PicID(i + 1);        
                Score_Enemy[i] = PicID(i + 1, true);
            }
            
            CircleThis(pb_Ball);   
            ApplySettings();        
            pb_Ball.Location = new Point(208, rng.Next(10, 190));  
            RandomStart(BallGoingLeft); 
        }        

        public void AddScore(PictureBox[] Arr)
        {
            for (int i = 0; i < Arr.Length; i++)
            {   
                if (Arr[i].BackColor == ScoreColor)
                {   
                    Arr[i].BackColor = Color.Black; 
                    break;
                }
            }
            CurrentHitStreak = 0;
            CurrentHitLabel.Text = "Current Hit Streak: " + CurrentHitStreak;
            if (Arr[4].BackColor == Color.Black)
            {
                TimeSpan time = TimeSpan.FromSeconds(Round);
                string str = time.ToString(@"mm\:ss");

                using (FileStream fs = new FileStream(fileName, FileMode.Append, FileAccess.Write))
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine("Player Score: " + CPUScore);
                    sw.WriteLine("CPU Score: " + playerScore);
                    sw.WriteLine("Max Hit Record: " + MaxHitStreak);
                    sw.WriteLine("Time Elapsed: " + str);
                    sw.WriteLine("----------------------------------------------");
                }
                GameOn = false;
                CheckScore(Score_Player, Score_Enemy);                
                label_Start.Visible = true;
                RestoreScore();
                pb_Ball.Location = new Point(208, rng.Next(10, 190));
                pb_Player.Location = new Point(3, 67);
                pb_Enemy.Location = new Point(409, 67);
                MaxHitStreak = 0;
                Round = 0;
                label_Time.Visible = false;
            }
        }
        public void CheckScore(PictureBox[] Arr_Player, PictureBox[] Arr_Enemy)
        {
            if (Arr_Enemy[4].BackColor == Color.Black)
            {
                MessageBox.Show("Winner is Player", "", MessageBoxButtons.OK);
            }
            else if (Arr_Player[4].BackColor == Color.Black)
            {
                MessageBox.Show("Winner is CPU", "", MessageBoxButtons.OK);
            }
        }
        public void RestoreScore()
        {
            for (int i = 0; i <= 5; i++)
            {   
                PicID(i).BackColor = ScoreColor;
                PicID(i, true).BackColor = ScoreColor;
            }
            playerScore = 0;
            CPUScore = 0;
        }

        private void Music_Panel_MouseClick(object sender, MouseEventArgs e)
        {
            MusicPlayer f = Application.OpenForms.OfType<MusicPlayer>().FirstOrDefault();
            if (f != null&&f.Visible)
            {
                f.Hide();
            }
            else if (f != null&&f.Visible==false)
                f.Show();
            else
            {
            
                using (f = new MusicPlayer())
                {
                    f.ShowDialog();                         //vajag palīdzību
                }
            }
            
            f.Location = new Point(this.Right + this.Right, this.Top);
            //MusicPlayer player = new MusicPlayer();
            //player.Show();
        }

        public PictureBox PicID(int i, Boolean Enemy = false)
        {
            if (Enemy)
            {   
                switch (i)
                {
                    case 1:
                        return enemy_1;
                    case 2:
                        return enemy_2;
                    case 3:
                        return enemy_3;
                    case 4:
                        return enemy_4;
                    case 5:
                        return enemy_5;
                }
            }
            else
            {
                switch (i)
                {
                    case 1:
                        return player_1;
                    case 2:
                        return player_2;
                    case 3:
                        return player_3;
                    case 4:
                        return player_4;
                    case 5:
                        return player_5;
                }
            }
            return pb_Ball;
        }

        private void Timer_Enemy_Tick(object sender, EventArgs e)
        {
            if (GameOn) 
            {   
                if (pb_Enemy.Location.Y + 28 < pb_Ball.Location.Y)      //vienmēr vidū
                {   
                    pb_Enemy.Top += Speed_Enemy;
                }
                else
                {
                    pb_Enemy.Top -= Speed_Enemy;
                }
            }
        }

        public void SettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings sF = new Settings();
            sF.Location = new Point(this.Right + this.Width, this.Top);
            sF.Show();
        }

        

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            Owner.Show();  
            Hide();
        }

        public int ReverseInt(int x, Boolean Force = false, Boolean Negative = false)
        {
            if (Force)
            {
                if (Negative)   //ja negative bool ir true, tad atgriež negatīvu skaitli
                {
                    if (x > 0)
                    {
                        x = ~x + 1; //NOT
                    }
                }
                else
                {
                    x = x - (x * 2);//apgriež skaitlo
                }
            }
            else
            {
                if (x > 0)
                {
                    x = x - (x * 2);
                }
                else
                {
                    x = ~x + 1;
                }
            }
            return x;
        }

        private void Game_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        public void Timer_Sec_Tick(object sender, EventArgs e)
        {
            if (GameOn)
            {
                Round++;
                label_Time.Visible = true;

                TimeSpan time = TimeSpan.FromSeconds(Round);

                string str = time.ToString(@"mm\:ss");
                label_Time.Text = "Time: " + str;

            }
        }
    }
}

