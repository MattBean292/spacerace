using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace spacerace
{
    public partial class Form1 : Form
    {
        List<Rectangle> asteroidList = new List<Rectangle>();
        List<int> asteroidDirection = new List<int>();
        List<int> asteroidSpeed = new List<int>();      
        int asteroidspot;

        Rectangle player1 = new Rectangle(120, 570, 10, -30);
        Rectangle player2 = new Rectangle(420, 570, 10, -30);
        Rectangle firePlayer1 = new Rectangle(120, 615, 10, -30);
        Rectangle firePlayer2 = new Rectangle(420, 615, 10, -30);
        Rectangle touchbox = new Rectangle(387, 540, 75, 50);

        Rectangle timelimit = new Rectangle(300, 600, 10, -600);


        int playerspeed = 3;
        int player1point;
        int player2point;

        bool wPressed = false;
        bool sPressed = false;
        bool upPressed = false;
        bool downPressed = false;
        bool qPressed = false;
        bool AI = false;

        SoundPlayer victory = new SoundPlayer(Properties.Resources.victory);
        SoundPlayer crickets = new SoundPlayer(Properties.Resources.crickets);

        int x;
        int timer;

        Random randGen = new Random();
        int randValue;

        SolidBrush whiteBrush = new SolidBrush(Color.White);
        SolidBrush orangeBrush = new SolidBrush(Color.Orange);
        SolidBrush blackBrush = new SolidBrush(Color.Black);
        public Form1()
        {
            InitializeComponent();            
            startButton.BackColor = Color.Black;
            player1scoreLabel.Text = "";
            player2scoreLabel.Text = "";
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {

                case Keys.W:
                    wPressed = true;
                    break;
                case Keys.S:
                    sPressed = true;
                    break;
                case Keys.Up:
                    upPressed = true;
                    break;
                case Keys.Down:
                    downPressed = true;
                    break;
                case Keys.Q:
                    qPressed = true;
                    break;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {

                case Keys.W:
                    wPressed = false;
                    break;
                case Keys.S:
                    sPressed = false;
                    break;
                case Keys.Up:
                    upPressed = false;
                    break;
                case Keys.Down:
                    downPressed = false;
                    break;
                case Keys.Q:
                    qPressed = false;
                    break;
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (gameTimer.Enabled == false && timer > 0)
            {
                asteroidList.Clear();
                tellplayerLabel.Visible = true;
                startButton.Enabled = true;
                startButton.Visible = true;
                AILabel.Enabled = true;
                AILabel.Visible = true;
                startButton.Text = "Try Again";
                AILabel.Text = "Bye";
                if (player1point > player2point)
                {
                    tellplayerLabel.Text = "Player1 Wins";
                    victory.Play();
                }
                else if (player1point < player2point)
                {
                    tellplayerLabel.Text = "Player2 Wins";
                    victory.Play();
                }
                else
                {
                    tellplayerLabel.Text = "You both suck";
                    crickets.Play();
                }
            }
            else
            {
                if (wPressed == true)
                {
                    e.Graphics.FillEllipse(orangeBrush, firePlayer1);
                }
                if (upPressed == true && AI == false)
                {
                    e.Graphics.FillEllipse(orangeBrush, firePlayer2);
                }
                if (AI == true)
                {
                    e.Graphics.FillEllipse(orangeBrush, firePlayer2);
                    for (int i = 0; i < asteroidList.Count; i++)
                    {
                        if (asteroidList[i].IntersectsWith(touchbox))
                        {
                            e.Graphics.FillEllipse(blackBrush, firePlayer2);
                        }
                    }
                }
                e.Graphics.FillRectangle(whiteBrush, player1);
                e.Graphics.FillRectangle(whiteBrush, player2);              
                e.Graphics.FillRectangle(whiteBrush, timelimit);
                if (qPressed == true)
                {
                    e.Graphics.FillRectangle(whiteBrush, touchbox);
                }

                for (int i = 0; i < asteroidList.Count; i++)
                {
                    e.Graphics.FillRectangle(whiteBrush, asteroidList[i]);
                }
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {                                              
            //player1 movement
            if (wPressed == true)
            {
               
                    player1.Y = player1.Y - playerspeed;
                firePlayer1.Y = firePlayer1.Y - playerspeed;
            }
            
                if (sPressed == true && player1.Y < this.Height - player1.Height)
                {
                   
                        player1.Y = player1.Y + playerspeed;
                firePlayer1.Y = firePlayer1.Y + playerspeed;
            }

            //player2 movement
            if (AI == true) 
            {
                

                for (int i = 0; i < asteroidList.Count; i++) {
                    if (asteroidList[i].IntersectsWith(touchbox) && player2.Y < this.Height - player2.Height)
                        {
                        touchbox.Y = touchbox.Y + playerspeed;
                        player2.Y = player2.Y + playerspeed;
                        firePlayer2.Y = firePlayer2.Y + playerspeed;
                    }                   
                }
                
                touchbox.Y = touchbox.Y - playerspeed;
                player2.Y = player2.Y - playerspeed;
                firePlayer2.Y = firePlayer2.Y - playerspeed;
            }
            else
            {
                if (upPressed == true)
                {

                    player2.Y = player2.Y - playerspeed;
                    firePlayer2.Y = firePlayer2.Y - playerspeed;
                }

                if (downPressed == true && player2.Y < this.Height - player2.Height)
                {

                    player2.Y = player2.Y + playerspeed;
                    firePlayer2.Y = firePlayer2.Y + playerspeed;
                }
            }

            //points
            
                if (player1.Y < 10)
                {

                player1.Y = this.Height - player1.Height;
                firePlayer1.Y = this.Height + 15;
                player1point++;
                    
                }
            
            
                if (player2.Y < 10)
                {

                player2.Y = this.Height - player1.Height;
                firePlayer2.Y = this.Height + 15;
                touchbox.Y = this.Height - 60;
                player2point++;
                    
                }
            
            //projectiles
            if (asteroidList.Count < 12)
            {
                randValue = randGen.Next(1,3);
                if (randValue == 1)
                {
                    asteroidspot = 0;
                    asteroidDirection.Add(asteroidspot);                    
                }
                else
                {
                    asteroidspot = this.Width;
                    asteroidDirection.Add(asteroidspot);
                }
                asteroidSpeed.Add(randGen.Next(5, 10));
                randValue = randGen.Next(10, this.Height - 5);
                Rectangle asteroid = new Rectangle(asteroidspot, randValue, 10, 5);
                asteroidList.Add(asteroid);          
            }
            for (int i = 0; i < asteroidList.Count; i++)
            {
                if (asteroidList[i].X >= this.Width + asteroidList[i].Width || asteroidList[i].X <= 0 - asteroidList[i].Width)
                {
                    asteroidList.RemoveAt(i);
                    asteroidDirection.RemoveAt(i);
                    asteroidSpeed.RemoveAt(i);
                }
            }
            // projectile movement
            for (int i = 0; i < asteroidList.Count; i++)
            {
                if (asteroidDirection[i] == 0)
                {
                    x = asteroidList[i].X + asteroidSpeed[i];
                    asteroidList[i] = new Rectangle(x, asteroidList[i].Y, 10, 5);
                }
                else
                {
                    x = asteroidList[i].X - asteroidSpeed[i];
                    asteroidList[i] = new Rectangle(x, asteroidList[i].Y, 10, 5);
                }
            }
            // projectile interaction
            for (int i = 0; i < asteroidList.Count; i++)
            {
                
                    if (asteroidList[i].IntersectsWith(player1))
                    {

                    player1.Y = this.Height - player1.Height;
                    firePlayer1.Y = this.Height + 15;

                }
             
               
                    if (asteroidList[i].IntersectsWith(player2))
                    {
                       
                    player2.Y = this.Height - player1.Height;
                    firePlayer2.Y = this.Height + 15;
                    touchbox.Y = this.Height - 60;
                }
                
            }
            // time limit
             timelimit = new Rectangle(300, 0 + timer, 10, 600 - timer);
            if (timer == 600)
            {
                gameTimer.Stop();
            }
             
            player1scoreLabel.Text = $"{player1point}";
            player2scoreLabel.Text = $"{player2point}";
            timer++;
            Refresh();
        }

        private void startButton_Click_1(object sender, EventArgs e)
        {
            if (gameTimer.Enabled == false && timer > 0)
            {
                crickets.Stop();
                victory.Stop();
                tellplayerLabel.Text = "Space Race";
                startButton.Text = "Start";
                AILabel.Text = "Vs AI";
                player1scoreLabel.Text = "";
                player2scoreLabel.Text = "";
                player1point = 0;
                player2point = 0;
                timer = 0;
            }
            else
            {
                player1 = new Rectangle(120, 570, 10, 30);
                player2 = new Rectangle(420, 570, 10, 30);
                firePlayer1 = new Rectangle(120, 615, 10, -30);
                firePlayer2 = new Rectangle(420, 615, 10, -30);
                startButton.Enabled = false;
                startButton.Visible = false;
                AILabel.Enabled = false;
                AILabel.Visible = false;
                tellplayerLabel.Visible = false;
                gameTimer.Start();
            }
        }

        private void AILabel_Click(object sender, EventArgs e)
        {
            if (gameTimer.Enabled == false && timer > 0)
            {
             Application.Exit();
            }

            player1 = new Rectangle(120, 570, 10, 30);
            player2 = new Rectangle(420, 570, 10, 30);
            firePlayer1 = new Rectangle(120, 615, 10, -30);
            firePlayer2 = new Rectangle(420, 615, 10, -30);
            startButton.Enabled = false;
            startButton.Visible = false;
            AILabel.Enabled = false;
            AILabel.Visible = false;
            tellplayerLabel.Visible = false;
            AI = true;
            gameTimer.Start();
        }
    }
}
