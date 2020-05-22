using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameGK
{
    public class Tetramino
    {
        private Point curPosition;
        private Point[] curShape;
        private Image curColor;
        private bool rotate;

        public Tetramino(int num)
        {
            curPosition = new Point(0, 0);
            curShape = SetShape(num);
        }

        public Image GetColor
        {
            get
            {
                return curColor;
            }
        }

        public Point GetPosition
        {
            get
            {
                return curPosition;
            }
        }

        public Point [] GetShape
        {
            get
            {
                return curShape;
            }
        }

        public void MoveLeft()
        {
            curPosition.X--;
        }

        public void MoveRight()
        {
            curPosition.X++;
        }

        public void MoveDown()
        {
            curPosition.Y++;
        }

        public void MovRotate()
        {
            if(rotate)
            {
                for(int i=0; i<curShape.Length; i++)
                {
                    int v = curShape[i].X;
                    curShape[i].X = curShape[i].Y * (-1);
                    curShape[i].Y = v;
                }
            }
        }

        private Point [] SetShape (int num)
        {
            switch(num)
            {
                case 0: //I
                    rotate = true;
                    curColor = Properties.Resources.blue;
                    return new Point[]
                    {
                        new Point (0,0),
                        new Point (-1,0),
                        new Point (1,0),
                        new Point (2,0)
                    };
                case 1: //J
                    rotate = true;
                    curColor = Properties.Resources.bluebold; 
                    return new Point[]
                    {
                        new Point (0,0),
                        new Point (1,0),
                        new Point (-1,0),
                        new Point (-1,-1)
                    };
                case 2: //L
                    rotate = true;
                    curColor = Properties.Resources.green;
                    return new Point[]
                    {
                        new Point (0,0),
                        new Point (-1,0),
                        new Point (1,0),
                        new Point (1,-1)
                    };
                case 3: //O
                    rotate = false;
                    curColor = Properties.Resources.red;
                    return new Point[]
                    {
                        new Point (0,0),
                        new Point (0,-1),
                        new Point (1,0),
                        new Point (1,-1)
                    };
                case 4: //S
                    rotate = true;
                    curColor = Properties.Resources.orange;
                    return new Point[]
                    {
                            new Point (0,0),
                            new Point (-1,0),
                            new Point (0,-1),
                            new Point (1,-1)
                    };
                case 5: //T
                    rotate = true;
                    curColor = Properties.Resources.yellow;
                    return new Point[]
                    {
                            new Point (0,0),
                            new Point (-1,0),
                            new Point (0,-1),
                            new Point (1,0)
                    };
                case 6: //Z
                    rotate = true;
                    curColor = Properties.Resources.pink;
                    return new Point[]
                    {
                            new Point (0,0),
                            new Point (1,0),
                            new Point (0,-1),
                            new Point (-1,-1)
                    };
                default:
                    return null;
            }
        }
    }
}
