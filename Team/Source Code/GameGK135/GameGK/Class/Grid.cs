using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameGK.Class
{
    public class Grid
    {
        private Point[,] Points;
        public Grid(MyPanel panel,int col, int row)
        {
            Panel = panel;
            Col = col;
            Row = row;
            Width = col * 27 - 1;
            Height = row * 27 - 1;
            Points = new Point[Row, Col];
            for(int i=0; i<Row; i++)
                for(int j=0; j<Col; j++)
                {
                    Points[i, j].X = 27 * j - 1;
                    Points[i, j].Y = 27 * i - 1;
                }
        }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Col { get; set; }
        public int Row { get; set; }

        public MyPanel Panel { get; set; }
        public void GraphicGrid(MyPanel panel,Graphics graphic)
        {
            Panel = panel;
            Pen pen = new Pen(Color.FromArgb(89, 10, 148), 2);
            Pen pen1 = new Pen(Color.FromArgb(89, 10, 148), 1);
            for (int i = 0; i <= Col; i++)
            {
                if (i == 0)
                    graphic.DrawLine(pen1, 0, 0, 0, panel.Height);
                else
                    graphic.DrawLine(pen, i * 27 - 1, 0, i * 27 - 1, panel.Height);
            }

            for (int i = 0; i <= Row; i++)
            {
                if (i == 0)
                    graphic.DrawLine(pen1, 0, 0, panel.Width, 0);
                else
                    graphic.DrawLine(pen, 0, i * 27 - 1, panel.Width, i * 27 - 1);
            }
        }

        public void Add(Control control,int row, int col)
        {
            control.Location = Points[col, row];
            Panel.Controls.Add(control);
        }

        public void Clear()
        {
            Panel.Controls.Clear();
        }
    }
}