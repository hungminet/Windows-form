using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameGK.Class
{
    public class Board
    {
        private Grid MainGrid;
        private Grid ExtraGrid;

        public Board(Grid mainGrid, Grid extraGrid)
        {
            MainGrid = mainGrid;
            ExtraGrid = extraGrid;
        }

        public Grid GetMainGrid
        {
            get
            {
                return MainGrid;
            }
            set
            {
                MainGrid = value;
            }
        }

        public Grid GetExtraGrid
        {
            get
            {
                return ExtraGrid;
            }
            set
            {
                ExtraGrid = value;
            }
        }

        public int GetMainGridCol
        {
            get
            {
                return MainGrid.Col;
            }
        }

        public int GetMainGridRow
        {
            get
            {
                return MainGrid.Row;
            }
        }

        public int GetExtraGridCol
        {
            get
            {
                return ExtraGrid.Col;
            }
        }

        public int GetExtraGridRow
        {
            get
            {
                return ExtraGrid.Row;
            }
        }
    }
}
