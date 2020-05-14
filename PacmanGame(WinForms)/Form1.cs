using PacmanGame_WinForms_.Cells;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Runtime.CompilerServices;
using System.Text;
//using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PacmanGame_WinForms_
{
    public partial class Form1 : Form
    {
        public static Timer timer2;
        public static Timer timer3;
        public static Timer timer4;
        public static Timer timer5;

        public static int min = 1;
        public static int sec = 0;

        private static int minutes { get; set; }
        private static int seconds { get; set; }

        private static LiveBonus LiveBonus;
        private static LiveBonus PlusLive;

        private static DoubleCoin DoubleCoin;
        //private static DoubleCoin PlusCoin;

        private static Surprise Surprise;
        private static List<Panel> Bonuses = new List<Panel>();

        private static Panel AddLife { get; set; }
        private static Panel PlusLife { get; set; }
        private static Panel MoneyLong { get; set; }
        private static Panel SurpriseBox { get; set; }

        private static Panel[,] Map { get; set; }
        private static Panel Hero { get; set; }
        private static Panel YouWin { get; set; }
        private static Panel GameOver { get; set; }
        private bool gameOver = false;
        private static Panel[] Enemies { get; set; }
        private static int ElementSize { get; set; }
        public static Image Pacman_r = Properties.Resources.Pacman_R;
        public static Field Field;
        public static Pacman Pacman;
        public static Ghosts Ghosts;
        public static int Score { get; set; }
        public static int Lives { get; set; }
        public static int Steps { get; set; }
        public static int Level { get; set; }

        public static List<Energiser> Energisers = new List<Energiser>();
        public static int time_active = 3000;
        public static int Interval = 100;
        public static string PlayerName;

        public Form1()
        {

            Field = new Field();
            Pacman = new Pacman(13, 13);
            Field[13, 13] = new EmptyPoint(13, 13);
            Ghosts = new Ghosts();

            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Sounds.PlayMusic();
            PlayerName = Program.Name;
            Level = 1;
            Lives = 3;
            Score = 0;
            ElementSize = Math.Min((int)Size.Height / Field.Matrix.GetLength(0), (int)Size.Width / Field.Matrix.GetLength(1));

            minutes = 0;
            seconds = 0;

            Execute();
            SetInfoLabel();
            SetTimer();
            timer7.Start();
            timer8.Start();
        }

        private void SetInfoLabel()
        {
            label1 = new Label();
            label1.BackColor = Color.Lime;
            label1.BorderStyle = BorderStyle.Fixed3D;
            label1.Font = new Font("Berlin Sans FB", 20.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            label1.ForeColor = SystemColors.MenuText;
            label1.Location = new Point(1120, 0);
            label1.Name = "label1";
            label1.Size = new Size(169, 194);
            label1.TabIndex = 0;
            label1.Text = $"Level: 1\r\nScore: {Score}\r\nSteps: {Steps}\r\nLives: {Lives}\r\n\r\n";
            Controls.Add(label1);

            UpdateInfo();
        }

        private void RestartGame()
        {
            Field = new Field();
            Pacman = new Pacman(13, 13);
            Field[13, 13] = new EmptyPoint(13, 13);
            Ghosts = new Ghosts();

            Sounds.PlayMusic();
            PlayerName = Program.Name;
            Level = 1;
            Score = 0;
            Steps = 0;
            Lives = 3;
            ElementSize = Math.Min((int)Size.Height / Field.Matrix.GetLength(0), (int)Size.Width / Field.Matrix.GetLength(1));
            Execute();

            minutes = 0;
            seconds = 0;

            SetTimer();
        }

        private void NextLevel()
        {
            Field = new Field();
            Pacman = new Pacman(13, 13);
            Field[13, 13] = new EmptyPoint(13, 13);
            Ghosts = new Ghosts();
            PlayerName = Program.Name;
            Level += 1;
            ElementSize = Math.Min((int)Size.Height / Field.Matrix.GetLength(0), (int)Size.Width / Field.Matrix.GetLength(1));
            Execute();

            SetTimer();
            //timer8.Enabled = true; 
        }

        private void SetTimer()
        {
            timer2 = new Timer(components);
            timer3 = new Timer(components);
            timer4 = new Timer(components);
            timer5 = new Timer(components);
            timer7 = new Timer(components);

            timer2.Tick += new EventHandler(timer2_Tick);
            timer3.Tick += new EventHandler(timer3_Tick);
            timer4.Tick += new EventHandler(timer4_Tick);
            timer5.Tick += new EventHandler(timer5_Tick);
            timer7.Tick += new EventHandler(timer7_Tick);

            if (Interval == 100)
            {
                min = 1;
                sec = 0;
                time_active = 3000;
            }
            else if (Interval == 70)
            {
                min = 0;
                sec = 42;
                time_active = 2000;
            }
            else if (Interval == 150)
            {
                min = 1;
                sec = 30;
                time_active = 4000;
            }

            timer1.Interval = Interval;
            timer2.Interval = Ghosts[0].Interval;
            timer3.Interval = Ghosts[1].Interval;
            timer4.Interval = Ghosts[2].Interval;
            timer5.Interval = Ghosts[3].Interval;
            timer7.Interval = 1000;

            timer1.Enabled = true;
            timer2.Enabled = true;
            timer3.Enabled = true;
            timer4.Enabled = true;
            timer5.Enabled = true;
            timer7.Enabled = true;
            timer8.Enabled = true;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            label5.Text = $"Last key pressed: {e.KeyData}";

            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
            {
                Pacman.ChangeDirection(e);
            }

            else if (e.KeyCode == Keys.F5)
            {
                if ((Field.Finish() || Score == 3170) && Level == 5)
                {                   
                    YouWin.Dispose();
                }
                else if (gameOver)
                {
                    GameOver.Dispose();
                    BackColor = SystemColors.Window;
                    gameOver = false;
                }
                else
                {
                    Clear();
                }

                RestartGame();
            }

            else if (e.KeyCode == Keys.Escape)
            {
                YouFailed();
            }

            else if (e.KeyCode == Keys.Home)
            {
                Program.Menu.button1.BackColor = Color.Lime;
                Program.Menu.button1.ForeColor = SystemColors.ControlText;
                Close();
            }

            UpdateHero(true);
        }

        private void timer6_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < 4; ++i)
            {
                if (Pacman.X == Ghosts[i].X && Pacman.Y == Ghosts[i].Y)
                {
                    Ghosts[i].Action();
                    UpdateEnemy(Ghosts[i], i, true);
                    UpdateInfo();
                }
            }
        }

        private void YouFailed()
        {
            for (int i = 0; i < Bonuses.Count; ++i)
            {
                Bonuses[i].Dispose();
            }

            timer8.Enabled = false;
            timer9.Stop();
            gameOver = true;
            Clear();
            BackColor = Color.Red;
            GameOver = new Panel()
            {
                Parent = this,
                //BackgroundImageLayout = ImageLayout.Stretch,
                Size = new Size(Width, Height),
                BackgroundImage = Properties.Resources.GameOver
            };
            if (PlayerName != null)
                MessageBox.Show($"{PlayerName},\r\nYOU FAILED!");
            else
                MessageBox.Show("YOU FAILED!");
        }

        private void Clear()
        {
            Hero.Dispose();
            foreach (Panel p in Map)
            {
                p.Dispose();
            }
            foreach (Panel p in Enemies)
            {
                p.Dispose();
            }
            timer1.Enabled = false;
            timer2.Enabled = false;
            timer3.Enabled = false;
            timer4.Enabled = false;
            timer5.Enabled = false;
            timer7.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Pacman.Move();

            if (Field.Finish())
            {
                if (Level != 5)
                {
                    if (Level == 2)
                    {
                        if (DoubleCoin != null)
                        {
                            MoneyLong.Dispose();
                            DoubleCoin = null;
                        }
                    }
                    else if (Level == 3)
                    {
                        if (PlusLive != null && Surprise != null)
                        {
                            PlusLife.Dispose();
                            PlusLive = null;

                            SurpriseBox.Dispose();
                            Surprise = null;
                        }
                    }
                    else if (Level == 4)
                    {
                        if (DoubleCoin != null)
                        {
                            MoneyLong.Dispose();
                            DoubleCoin = null;
                        }
                    }

                    Clear();
                    NextLevel();
                }
                else
                    YouWon();
            }
            else if (Lives <= 0)
            {
                //Sounds.SoundOff();
                //Sounds.Stop();
                
                YouFailed();
            }
            if (LiveBonus != null && Pacman.X == LiveBonus.X && Pacman.Y == LiveBonus.Y)
            {
                LiveBonus.Action();
                UpdateBonus(LiveBonus, AddLife, true);
                LiveBonus = null;
            }
            if (DoubleCoin != null && Pacman.X == DoubleCoin.X && Pacman.Y == DoubleCoin.Y)
            {
                DoubleCoin.Action();
                UpdateBonus(DoubleCoin, MoneyLong, true);
                DoubleCoin = null;
            }
            if (PlusLive != null && Pacman.X == PlusLive.X && Pacman.Y == PlusLive.Y)
            {
                PlusLive.Action();
                UpdateBonus(PlusLive, PlusLife, true);
                PlusLive = null;
            }
            if (Surprise != null && Pacman.X == Surprise.X && Pacman.Y == Surprise.Y)
            {
                Surprise.Action();
                label6.Text = $"Time left:\r\n0{min}:{sec}\r\n\r\n";
                UpdateBonus(Surprise, SurpriseBox, true);
                Surprise = null;
            }
            //if ((LiveBonus == null && DoubleCoin == null) ^ (LiveBonus == null && Surprise == null))
            //{
            //    timer9.Enabled = false;
            //}

            UpdateHero(true);
            UpdateInfo();
        }

        private void YouWon()
        {
            for (int i = 0; i < Bonuses.Count; ++i)
            {
                Bonuses[i].Dispose();
            }

            timer8.Stop();
            timer9.Stop();
            Clear();

            YouWin = new Panel()
            {
                Parent = this,
                BackgroundImageLayout = ImageLayout.Stretch,
                Size = new Size(1200, 1000),
                BackgroundImage = Properties.Resources.YouWin
            };
            if (PlayerName != null)
                MessageBox.Show($"{PlayerName},\r\nYOU WON!");
            else
                MessageBox.Show("YOU WON!");
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            //Ghosts[0].PacmanHit();
            Ghosts[0].Move();
            Ghosts[0].EnergizerActive();
            //Ghosts[0].PacmanHit();
            UpdateEnemy(Ghosts[0], 0, true);

            if (Ghosts[0].isEmpty)
            {
                timer2.Enabled = false;
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            //Ghosts[3].PacmanHit();
            Ghosts[3].Move();
            Ghosts[3].EnergizerActive();
            //Ghosts[3].PacmanHit();
            UpdateEnemy(Ghosts[3], 3, true);

            if (Ghosts[3].isEmpty)
            {
                timer3.Enabled = false;
            }
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            //Ghosts[2].PacmanHit();
            Ghosts[2].Move();
            Ghosts[2].EnergizerActive();
            //Ghosts[2].PacmanHit();
            UpdateEnemy(Ghosts[2], 2, true);

            if (Ghosts[2].isEmpty)
            {
                timer4.Enabled = false;
            }
        }

        private void timer5_Tick(object sender, EventArgs e)
        {
            //Ghosts[1].PacmanHit();
            Ghosts[1].Move();
            Ghosts[1].EnergizerActive();
            //Ghosts[1].PacmanHit();
            UpdateEnemy(Ghosts[1], 1, true);

            if (Ghosts[1].isEmpty)
            {
                timer5.Enabled = false;
            }
        }

        private void Execute()
        {
            Map = new Panel[Field.Matrix.GetLength(0), Field.Matrix.GetLength(1)];
            Enemies = new Panel[4];
            Hero = new Panel();

            for (int i = 0; i < Map.GetLength(0); i++)
            {
                for (int j = 0; j < Map.GetLength(1); j++)
                {
                    Map[i, j] = new Panel
                    {
                        Parent = this,
                        BackgroundImageLayout = ImageLayout.Stretch
                    };
                    UpdatePanel(Field[i, j], true);
                    Controls.Add(Map[i, j]);
                }
            }

            for (int i = 0; i < 4; ++i)
            {
                Enemies[i] = new Panel
                {
                    Parent = this,
                    BackgroundImageLayout = ImageLayout.Stretch
                };
                Controls.Add(Enemies[i]);
                UpdateEnemy(Ghosts[i], i, true);
            }

            UpdateInfo();

            Hero.Parent = this;
            Hero.BringToFront();
            Hero.BackgroundImageLayout = ImageLayout.Stretch;
            UpdateHero(true);
        }

        public static void UpdateEnemy(Ghost element, int i, bool updateImage = false)
        {
            if (Ghosts[i].isEmpty)
            {
                Enemies[i].Dispose();
            }
            else
            {
                Enemies[i].Size = new Size(ElementSize, ElementSize);
                Enemies[i].Location = new Point(element.X * ElementSize,
                            element.Y * ElementSize);
                Enemies[i].BringToFront();
                if (updateImage) Enemies[i].BackgroundImage = element.Image;
            }           
        }

        public static void UpdatePanel(BasePoint element, bool updateImage = false)
        {
            if (element != null)
            {
                if (element is Coin)
                {
                    Map[element.Y, element.X].Size = new Size(ElementSize / 2, ElementSize / 2);
                    Map[element.Y, element.X].Location = new Point(element.X * ElementSize + 10,
                        element.Y * ElementSize + 10);
                }
                else
                {
                    Map[element.Y, element.X].Size = new Size(ElementSize, ElementSize);
                    Map[element.Y, element.X].Location = new Point(element.X * ElementSize,
                        element.Y * ElementSize);
                }
                if (updateImage) Map[element.Y, element.X].BackgroundImage = Field[element.Y, element.X].Image;
            }
        }

        private void UpdateHero(bool updateImage = false)
        {
            Hero.Size = new Size(ElementSize, ElementSize);
            Hero.Location = new Point(Pacman.X * ElementSize,
                Pacman.Y * ElementSize);
            if (updateImage) Hero.BackgroundImage = Pacman.Image;
        }

        public static void UpdateInfo()
        {
            label1.Text = $"Level: {Level}\r\nScore: {Score}\r\nSteps: {Steps}\r\nLives: {Lives}\r\nSpent time:\r\n0{minutes}:{seconds}";

        }

        private void timer7_Tick(object sender, EventArgs e)
        {
            label6.Text = $"Time left:\r\n0{min}:{sec}\r\n\r\n";

            sec = sec - 1;
            if (sec == -1)
            {
                min = min - 1;
                sec = 59;
            }

            if (min == 0 && sec == 0)
            {
                timer7.Enabled = false;
                //Sounds.SoundOff();
                //Sounds.Stop();
                label6.Text = $"Time left:\r\n0{min}:{sec}\r\n\r\n";
                YouFailed();
            }

            label6.Text = $"Time left:\r\n0{min}:{sec}\r\n\r\n";

            if (Level == 2)
            {
                if (sec == 41)
                {
                    LiveBonus = new LiveBonus(12, 18, false);
                    
                    AddLife = new Panel
                    {
                        Parent = this,
                        BackgroundImageLayout = ImageLayout.Stretch
                    };
                    Controls.Add(AddLife);
                    UpdateBonus(LiveBonus, AddLife, true);
                    Bonuses.Add(AddLife);

                    timer9.Interval = 500;
                    timer9.Enabled = true;
                }
                else if (sec == 30)
                {
                    DoubleCoin = new DoubleCoin(10, 13, true)
                    {
                        direction = Direction.RIGHT
                    };
                    MoneyLong = new Panel
                    {
                        Parent = this,
                        BackgroundImageLayout = ImageLayout.Stretch
                    };
                    Controls.Add(MoneyLong);
                    UpdateBonus(DoubleCoin, MoneyLong, true);
                    Bonuses.Add(MoneyLong);
                }
            }
            else if (Level == 3)
            {
                if (sec == 40)
                {
                    PlusLive = new LiveBonus(15, 1, true);
                    PlusLife = new Panel
                    {
                        Parent = this,
                        BackgroundImageLayout = ImageLayout.Stretch
                    };
                    Controls.Add(PlusLife);
                    UpdateBonus(PlusLive, PlusLife, true);
                    Bonuses.Add(PlusLife);
                    timer9.Enabled = true;
                }
                else if (sec == 30)
                {
                    Surprise = new Surprise(10, 13);
                    SurpriseBox = new Panel
                    {
                        Parent = this,
                        BackgroundImageLayout = ImageLayout.Stretch
                    };
                    Controls.Add(SurpriseBox);
                    UpdateBonus(Surprise, SurpriseBox, true);
                    Bonuses.Add(SurpriseBox);
                }
            }
            else if (Level == 4)
            {
                if (sec == 30)
                {
                    DoubleCoin = new DoubleCoin(15, 18, false);
                    MoneyLong = new Panel
                    {
                        Parent = this,
                        BackgroundImageLayout = ImageLayout.Stretch
                    };
                    Controls.Add(MoneyLong);
                    UpdateBonus(DoubleCoin, MoneyLong, true);
                    Bonuses.Add(MoneyLong);
                }


                for (int i = 0; i < Ghosts.List.Count; ++i)
                {
                    if (Ghosts[i].isEmpty)
                    {
                        ++Ghosts[i].Wait;
                        if (Ghosts[i].Wait - Ghosts[i].ReadyRespaun == 5)
                        {
                            Ghosts[i].Respaun();
                            Enemies[i] = new Panel
                            {
                                Parent = this,
                                BackgroundImageLayout = ImageLayout.Stretch
                            };
                            Controls.Add(Enemies[i]);
                            UpdateEnemy(Ghosts[i], i, true);
                            timerRestart(i);
                        }
                    }
                }
            }
            else if (Level == 5)
            {
                if (sec == 30)
                {
                    PlusLive = new LiveBonus(15, 1, true);
                    PlusLife = new Panel
                    {
                        Parent = this,
                        BackgroundImageLayout = ImageLayout.Stretch
                    };
                    Controls.Add(PlusLife);
                    UpdateBonus(PlusLive, PlusLife, true);
                    Bonuses.Add(PlusLife);
                    timer9.Enabled = true;
                }

                for (int i = 0; i < Ghosts.List.Count; ++i)
                {
                    if (Ghosts[i].isEmpty)
                    {
                        ++Ghosts[i].Wait;
                        if (Ghosts[i].Wait == Ghosts[i].ReadyRespaun)
                        {
                            Ghosts[i].Respaun();
                            Enemies[i] = new Panel
                            {
                                Parent = this,
                                BackgroundImageLayout = ImageLayout.Stretch
                            };
                            Controls.Add(Enemies[i]);
                            UpdateEnemy(Ghosts[i], i, true);
                            timerRestart(i);
                        }
                    }
                }
            }
            
        }

        private void timerRestart(int i)
        {
            if (i == 0)
            {
                timer2.Enabled = true;
            }
            else if (i == 1)
            {
                timer5.Enabled = true;
            }
            else if (i == 2)
            {
                timer4.Enabled = true;
            }
            else if (i == 3)
            {
                timer3.Enabled = true;
            }
        }

        private void UpdateBonus(Bonus el, Panel lab, bool updateImage = false)
        {
            if (el.isEmpty)
            {
                lab.Dispose();
            }
            else
            {
                lab.Size = new Size(ElementSize, ElementSize);
                lab.Location = new Point(el.X * ElementSize,
                            el.Y * ElementSize);
                lab.BringToFront();
                if (updateImage) lab.BackgroundImage = el.Image;
            }
        }

        private void timer8_Tick(object sender, EventArgs e)
        {
            seconds += 1;
            if (seconds == 60)
            {
                minutes += 1;
                seconds = 0;
            }

            UpdateInfo();
        }

        private void timer9_Tick(object sender, EventArgs e)
        {
            if (LiveBonus != null)
            {
                LiveBonus.Move();
                UpdateBonus(LiveBonus, AddLife, true);
            }
            

            if (DoubleCoin != null)
            {
                DoubleCoin.Move();
                UpdateBonus(DoubleCoin, MoneyLong, true);
            }
            
            if (Surprise != null)
            {
                Surprise.Move();
                UpdateBonus(Surprise, SurpriseBox, true);
            }

            if (PlusLive != null)
            {
                PlusLive.Move();
                UpdateBonus(PlusLive, PlusLife, true);
            }
        }
    }
}
