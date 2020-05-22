using GameGK.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameGK
{

    public partial class MainWindow : Form
    {
       // private GameBoard gameBoard;
        Grid MainGrid;
        Grid ExtraGrid;
        private Board board;
        private int level;
        MainWindowController mainWindowController;
        Menu MENU;
        public MainWindow(int level)
        {
            InitializeComponent();
            this.level = level;
            
        }
        public MainWindow(Menu menu)
        {
            InitializeComponent();
            UserEntities playerEntity = new UserEntities();
            Player player1 = new Player();
            var pl = (from player in playerEntity.Players
                      where player.P_State == true
                      select player).SingleOrDefault();
            if (pl != null)
            {
                this.pn_info_player.Visible = true;
                this.lb_name_acc.Text = pl.P_Username.Trim();
                this.lb_name_score.Text = pl.P_Score.ToString();
            }    
            else
            {
                this.pn_info_player.Visible = false;
            }    

            MENU = menu;
            MENU.Hide();
            this.Size = this.MaximumSize;
            lbScore.Text = String.Format("{0,7}", "");
            //level = int.Parse(lbLevel.Text);
            level = 1;
            MainGrid = new Grid(myPanel1, 10, 20);
            myPanel1.Width = MainGrid.Width;
            myPanel1.Height = MainGrid.Height;
            ExtraGrid = new Grid(myPanel2, 4, 4);
            myPanel2.Width = ExtraGrid.Width;
            myPanel2.Height = ExtraGrid.Height;
            board = new Board(MainGrid, ExtraGrid);
            mainWindowController = new MainWindowController(board, this, this.level);
        }
        
        private void myPanel1_Paint(object sender, PaintEventArgs e)
        {
            MainGrid.GraphicGrid(myPanel1, e.Graphics);
        }

        private void myPanel2_Paint(object sender, PaintEventArgs e)
        {
            ExtraGrid.GraphicGrid(myPanel2, e.Graphics);
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            mainWindowController.MainWindow_KeyDown(sender, e);
        }
      
        private void MainWindow_Load(object sender, EventArgs e)
        {
            btnStartStop.BackgroundImage = Properties.Resources.pause; 
            btnStartStop.BackgroundImageLayout = ImageLayout.Stretch;
            btnRestart.BackgroundImage = Properties.Resources.restart; 
            btnRestart.BackgroundImageLayout = ImageLayout.Stretch;
            panel1.BackgroundImage = Properties.Resources.neonwall; 
            panel1.BackgroundImageLayout = ImageLayout.Stretch;
            pnGameOver.BackgroundImage = Properties.Resources.gameover; 
            pnGameOver.BackgroundImageLayout = ImageLayout.Stretch;
            pnScore.BackgroundImage = Properties.Resources.fs;
            pnScore.BackgroundImageLayout = ImageLayout.Stretch;
            lbScore.Font = new Font("Digital Numbers", 20);
            lbScore.ForeColor = Color.FromArgb(39, 255, 229);
            lbLevel.Font = new Font("2020 Outline Fortune Kei", 22);
            lbLevel.ForeColor = Color.FromArgb(144, 13, 205);
            ptTetris.BackgroundImage = Properties.Resources.tetris;
            ptTetris.BackgroundImageLayout = ImageLayout.Stretch;
            lbHighScore.ForeColor = Color.FromArgb(255, 185, 26);
            lbName.ForeColor = Color.FromArgb(255, 185, 26);
            lb_name_acc.ForeColor = Color.FromArgb(254,227,42);
            lb_name_score.ForeColor = Color.FromArgb(254, 227, 42);
        }

        private void btnStartStop_Click(object sender, EventArgs e)
        {
            mainWindowController.GamePause();
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {

            btnStartStop.BackgroundImage = Properties.Resources.pause; 
            btnStartStop.BackgroundImageLayout = ImageLayout.Stretch;
            mainWindowController.GameRestart();
        }

        private void pnScore_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawString("0000000", new Font("Digital Numbers", 20), new SolidBrush(Color.FromArgb(58, 77, 75)), new Point(37, 47));
        }

        private void ptTetris_Click(object sender, EventArgs e)
        {
            UserEntities playerEntity = new UserEntities();
            Player player1 = new Player();
            var pl = (from player in playerEntity.Players
                      where player.P_State == true
                      select player).SingleOrDefault();
            if(pl!=null)
            {
                pl.P_State = false;
                playerEntity.SaveChanges();
            }    
            MENU.Show();
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lb_name_acc_Click(object sender, EventArgs e)
        {

        }
    }
    public class MyPanel:Panel
    {
        public MyPanel():base()
        {
            this.DoubleBuffered = true;
        }
    }
}
