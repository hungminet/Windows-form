using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameGK.Class
{
    class MainWindowController
    {
        public MainWindowController(MainWindow mainWindow)
        {
            this.ShowMainMenu(mainWindow);
        }

        public void ShowMainMenu(MainWindow mainWindow)
        {
            //MainMenu mainMenu = new MainMenu();
            //mainMenu.Show();
            mainWindow.Close();
        }

        private Board board;
        private MainWindow mainWindowControl;

        private Timer Timer;
        private GameBoard gameBoard;

        public GameBoard gameboard => gameBoard;

        private readonly int GAMESPEED = 750;
        private int gameSpeed;
        private int level;


        public MainWindowController(Board BOARD, MainWindow mainWindow, int level)
        {
            board = BOARD;
            mainWindowControl = mainWindow;

            this.level = level;
            gameSpeed = GAMESPEED;
            SetLevel(this.level);
            Timer = new Timer();
            Timer.Tick += new EventHandler(GameTick);
            Timer.Interval = gameSpeed;
            GameStart();
        }

        public void SetLevel(int level)
        {
            gameSpeed = GAMESPEED;
            for (int i = 1; i < level; i++)
                gameSpeed -= 100;
        }

        public void GameStart()
        {
            board.GetMainGrid.Clear();
            board.GetExtraGrid.Clear();
            level = 1;
            mainWindowControl.btnStartStop.Enabled = true;
            mainWindowControl.pnGameOver.Visible = false;
            gameBoard = new GameBoard(board);
            SetLevel(level);
            Timer.Start();
        }

        void CheckLevel()
        {
            if (gameBoard.GetLines >= 5)
            {
                level++;
                SetLevel(this.level);

                mainWindowControl.lbLevel.Text = "Level " + level.ToString("");
                Timer.Interval = gameSpeed;
                gameBoard.GetLines = 0;
            }
        }

        void GameTick(object sender, EventArgs e)
        {
            mainWindowControl.lbScore.Text = String.Format("{0,7}", gameBoard.GetScore.ToString());
            
            //mainWindowControl.lbLevel.Text = gameBoard.GetLines.ToString("");
            mainWindowControl.lbLevel.Text = "Level " + level.ToString("");
            gameBoard.CurTetraminoMovDown();
            CheckGameState();
            CheckLevel();
        }

        private void CheckGameState()
        {
            if (gameBoard.GameOver())
            {
                GamePause();
                mainWindowControl.btnStartStop.BackgroundImage = Image.FromFile(Application.StartupPath + @"\pause1.png");
                mainWindowControl.btnStartStop.Enabled = false;
                mainWindowControl.pnGameOver.Visible = true;
                PlayerEntities playerEntity = new PlayerEntities();
                Player player1 = new Player();
                var pl = (from player in playerEntity.Players
                          where player.P_State == true
                          select player).SingleOrDefault();
                if(pl!=null)
                {
                    if (pl.P_Score < (int)gameBoard.GetScore)
                    {
                        pl.P_Score = (int)gameBoard.GetScore;
                        playerEntity.SaveChanges();
                        MessageBox.Show("Congrat "+pl.P_Username+".New Record: " + gameBoard.GetScore);
                    }
                }    

                //Kiem tra username trong database

                //gameBoard.GetScore.ToString()


            }
        }
        
        public void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    if (Timer.Enabled) gameBoard.CurTetraminoMovLeft();
                    break;
                case Keys.Right:
                    if (Timer.Enabled) gameBoard.CurTetraminoMovRight();
                    break;
                case Keys.Down:
                    if (Timer.Enabled) gameBoard.CurTetraminoMovDown();
                    break;
                case Keys.Up:
                    if (Timer.Enabled) gameBoard.CurTetraminoMovRotate();
                    break;
                case Keys.F2:
                    GameStart();
                    break;
                case Keys.F3:
                    if (!gameBoard.GameOver()) GamePause();
                    else GameStart();
                    break;
                default:
                    break;
            }
        }

        public void GamePause()
        {
            if (Timer.Enabled)
            {
                Timer.Stop();
                mainWindowControl.btnStartStop.BackgroundImage= Image.FromFile(Application.StartupPath + @"\play.png");
            }
            else
            {
                Timer.Start();
                mainWindowControl.btnStartStop.BackgroundImage= Image.FromFile(Application.StartupPath + @"\pause.png");
            }
        }
    }
}
