using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameGK.Class
{
    public class GameBoard
    {
        private int rows;
        private int cols;
        private int ROWS;
        private int COLS;
        private float score;
        private int linesFilled;
        private Tetramino curTetramino;
        private Tetramino nextTetramino;
        private PictureBox[,] BlockControls;
        private PictureBox[,] BlockShape;
        private bool gameOver = false;
        private int curNumber;
        private int nextNumber;
        private Random tetraminoRandom;

        static public Image NoImage = null;

        public GameBoard(Board board)
        {
            rows = board.GetMainGridRow;
            cols = board.GetMainGridCol;
            ROWS = board.GetExtraGridRow;
            COLS = board.GetExtraGridCol;

            tetraminoRandom = new Random();
            curNumber = tetraminoRandom.Next(0, 7);
            nextNumber = tetraminoRandom.Next(0, 7);


            score = 0;
            linesFilled = 0;

            BlockControls = new PictureBox[cols, rows];// block trong main grid
            BlockShape = new PictureBox[COLS, ROWS];// block tiếp theo

            for (int h = 0; h < COLS; h++)
            {
                for (int k = 0; k < ROWS; k++)
                {
                    BlockShape[h, k] = new PictureBox
                    {
                        BackgroundImage = NoImage,
                        BackgroundImageLayout = ImageLayout.Stretch,
                        BackColor = Color.Transparent,
                        Width=27,
                        Height=27,
                    };
                    board.GetExtraGrid.Add(BlockShape[h, k], h, k);
                }
            }

            for (int i = 0; i < cols; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    BlockControls[i, j] = new PictureBox
                    {
                        BackgroundImage = NoImage,
                        BackgroundImageLayout = ImageLayout.Stretch,
                        Width = 27,
                        Height = 27,
                        BackColor = Color.Transparent,
                    };
                    board.GetMainGrid.Add(BlockControls[i, j], i, j);
                }
            }
            curTetramino = new Tetramino(this.curNumber);
            nextTetramino = new Tetramino(nextNumber);
            CurTetraminoDraw();
            NextTetraminoDraw();
        }

        public float GetScore
        {
            get
            {
                return score;
            }
            set
            {
                score = value;
            }

        }

        public int GetLines
        {
            get
            {
                return linesFilled;
            }
            set
            {
                linesFilled = value;
            }
        }

        public void NextTetraminoDraw()
        {
            Point position = nextTetramino.GetPosition;
            Point[] Shape = nextTetramino.GetShape;
            Image Color = nextTetramino.GetColor;

            foreach (Point S in Shape)
            {
                BlockShape[(int)(S.X + position.X + 1),
                              (int)(S.Y + position.Y) + 2].BackgroundImage = Color;
            }
        }

        private void CurTetraminoDraw()
        {
            Point position = curTetramino.GetPosition;
            Point[] Shape = curTetramino.GetShape;
            Image Color = curTetramino.GetColor;

            foreach (Point S in Shape)
            {
                BlockControls[(int)(S.X + position.X) + ((cols / 2) - 1),
                              (int)(S.Y + position.Y) + 1].BackgroundImage = Color;
            }
        }

        private void NextTetraminoErase()
        {
            Point position = nextTetramino.GetPosition;
            Point[] Shape = nextTetramino.GetShape;

            foreach (Point S in Shape)
            {
                BlockShape[(int)(S.X + position.X + 1),
                              (int)(S.Y + position.Y) + 2].BackgroundImage = NoImage;
            }
        }
        private void CurTetraminoErase()
        {
            Point position = curTetramino.GetPosition;
            Point[] Shape = curTetramino.GetShape;

            foreach (Point S in Shape)
            {
                BlockControls[(int)(S.X + position.X) + ((cols / 2) - 1),
                              (int)(S.Y + position.Y) + 1].BackgroundImage = NoImage;
            }
        }

        private void CheckRows()
        {
            bool full;

            for (int i = rows - 1; i > 0; i--)
            {
                full = true;
                for (int j = 0; j < cols; j++)
                {
                    if (BlockControls[j, i].BackgroundImage == NoImage)
                    {
                        full = false;
                    }
                }

                if (full)
                {
                    RemoveRow(ref i);
                    score += 100;
                    linesFilled += 1;
                }
            }
        }

        private void RemoveRow(ref int row)
        {
            for (int i = row; i > 0; i--)
            {
                for (int j = 0; j < cols; j++)
                {
                    BlockControls[j, i].BackgroundImage = BlockControls[j, i - 1].BackgroundImage;
                }
            }
            row++;
        }

        public void CurTetraminoMovLeft()
        {
            Point Position = curTetramino.GetPosition;
            Point[] Shape = curTetramino.GetShape;
            bool move = true;

            CurTetraminoErase();

            foreach (Point S in Shape)
            {
                if (((int)(S.X + Position.X) + ((cols / 2) - 1) - 1) < 0)
                {
                    move = false;
                }

                else if (BlockControls[((int)(S.X + Position.X) + ((cols / 2) - 1) - 1),
                    (int)(S.Y + Position.Y) + 1].BackgroundImage != NoImage)
                {
                    move = false;
                }
            }

            if (move)
            {
                curTetramino.MoveLeft();
                CurTetraminoDraw();
            }

            else
            {
                CurTetraminoDraw();
            }
        }

        public void CurTetraminoMovRight()
        {
            Point Position = curTetramino.GetPosition;
            Point[] Shape = curTetramino.GetShape;
            bool move = true;

            CurTetraminoErase();

            foreach (Point S in Shape)
            {
                if (((int)(S.X + Position.X) + ((cols / 2) - 1) + 1) >= cols)
                {
                    move = false;
                }

                else if (BlockControls[((int)(S.X + Position.X) + ((cols / 2) - 1) + 1),
                    (int)(S.Y + Position.Y) + 1].BackgroundImage != NoImage)
                {
                    move = false;
                }
            }

            if (move)
            {
                curTetramino.MoveRight();
                CurTetraminoDraw();
            }

            else
            {
                CurTetraminoDraw();
            }
        }

        public void CurTetraminoMovDown()
        {
            Point Position = curTetramino.GetPosition;
            Point[] Shape = curTetramino.GetShape;
            bool move = true;

            CurTetraminoErase();

            foreach (Point S in Shape)
            {
                if (((int)(S.Y + Position.Y) + 1 + 1) >= rows)
                {
                    move = false;
                }

                else if (BlockControls[((int)(S.X + Position.X) + ((cols / 2) - 1)),
                    (int)(S.Y + Position.Y) + 1 + 1].BackgroundImage != NoImage)
                {
                    move = false;
                }
            }

            if (move)
            {
                curTetramino.MoveDown();
                CurTetraminoDraw();
            }

            else
            {
                CurTetraminoDraw();
                CheckRows();

                if ((int)Position.Y <= 1)
                {
                    gameOver = true;
                }

                else
                {
                    curNumber = nextNumber;
                    nextNumber = tetraminoRandom.Next(0, 7);
                    curTetramino = new Tetramino(curNumber);
                    NextTetraminoErase();
                    nextTetramino = new Tetramino(nextNumber);
                    NextTetraminoDraw();
                }

            }
        }

        public void CurTetraminoMovRotate()
        {
            Point Position = curTetramino.GetPosition;
            Point[] S = new Point[4];
            Point[] Shape = curTetramino.GetShape;
            bool move = true;
            Shape.CopyTo(S, 0);
            CurTetraminoErase();

            for (int i = 0; i < S.Length; i++)
            {
                int x = S[i].X;
                S[i].X = S[i].Y * -1;
                S[i].Y = x;

                if (((int)((S[i].Y + Position.Y) + 1)) >= rows)
                {
                    move = false;
                }

                else if (((int)(S[i].X + Position.X) + ((cols / 2) - 1)) < 0)
                {
                    move = false;
                }

                else if (((int)(S[i].X + Position.X) + ((cols / 2) - 1)) >= cols)
                {
                    move = false;
                }

                else if (BlockControls[((int)(S[i].X + Position.X) + ((cols / 2) - 1)),
                                       (int)(S[i].Y + Position.Y) + 1].BackgroundImage != NoImage)
                {
                    move = false;
                }
            }
            if (move)
            {
                curTetramino.MovRotate();
                CurTetraminoDraw();
            }
            else
            {
                CurTetraminoDraw();
            }
        }
        public bool GameOver()
        {
            return gameOver;
        }
    }
}
