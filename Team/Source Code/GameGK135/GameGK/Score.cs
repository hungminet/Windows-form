using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameGK
{
    public partial class Score : Form
    {
        int top = 10;
        public Score()
        {
            InitializeComponent();
        }
        public DataTable GetData()
        {
            int count = 0;
            UserEntities playerEntity = new UserEntities();
            Player player1 = new Player();
            var sorted_score = playerEntity.Players.OrderByDescending(c => c.P_Score);                                  ;
            DataTable dt = new DataTable();
            dt.Columns.Add("Username");
            dt.Columns.Add("Score");
            
            foreach (var p in sorted_score)
            {
                
                dt.Rows.Add(p.P_Username, p.P_Score);
                if (count >= 10)
                {
                    count = 0;
                    break;
                }    
                count++;
            }
            return dt;
        }
        private void Score_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = GetData();
            dataGridView1.AutoResizeColumns();
        }
    }
}
