using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq.Mapping;
using System.Data.Linq;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestLinQ.WorkBase;

namespace TestLinQ
{
    public partial class Form1 : Form
    {
        bool Adding;
        WorkBaseCity workBaseCity = null;
        string err;
        public Form1()
        {
            InitializeComponent();
            
        }

        public void LoadData()
        {
            txt_cityID.ResetText();
            txt_cityName.ResetText();
            workBaseCity = new WorkBaseCity();
            dataGridView1.DataSource = workBaseCity.GetCities();
            this.btn_add.Enabled = true;
            this.btn_del.Enabled = true;
            this.btn_edit.Enabled = true;
            this.btn_reload.Enabled = true;
            this.btn_exit.Enabled = true;
            this.btn_save.Enabled = false;
            this.txt_cityID.Enabled = false;
            this.dataGridView1.ReadOnly = true;
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult;
            dialogResult = MessageBox.Show("Chắc không?","Trả lời",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
            if(dialogResult == DialogResult.OK)
            {
                workBaseCity = new WorkBaseCity();
                if (workBaseCity.RemoveCity(txt_cityID.Text, ref err))
                {
                    LoadData();
                    MessageBox.Show("Xoa Thanh Cong");
                }
                else
                {
                    MessageBox.Show("Xoa Khong Thanh Cong", "Loi", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Khong thuc hien xoa");
            }
        }

        private void btn_reload_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            // Hiện hộp thoại hỏi đáp
            traloi = MessageBox.Show("Chắc xóa không?", "Trả lời",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if(traloi== DialogResult.OK)
            {
                this.Close();
            }

        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (!txt_cityID.Text.Trim().Equals(""))
            {
                // Thêm dữ liệu
                if (Adding)
                {
                    workBaseCity = new WorkBaseCity();
                    if(workBaseCity.AddCity(txt_cityID.Text,txt_cityName.Text, ref err))
                    {
                        LoadData();
                        MessageBox.Show("Them Thanh Cong");
                    }    
                    else
                    {
                        MessageBox.Show("Them Khong Thanh Cong","Loi",MessageBoxButtons.OKCancel,MessageBoxIcon.Error);
                    }    
                }
                else //sua
                {
                    workBaseCity = new WorkBaseCity();
                    if (workBaseCity.UpdateCity(txt_cityID.Text, txt_cityName.Text, ref err))
                    {
                        LoadData();
                        MessageBox.Show("Sua Thanh Cong");
                    }
                    else
                    {
                        MessageBox.Show("Sua Khong Thanh Cong", "Loi", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    }
                }
            }
            this.Adding = false;
            LoadData();
            this.txt_cityID.Enabled = false;
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            Adding = false;
            this.btn_save.Enabled = true;
            this.btn_reload.Enabled = true;
            this.btn_exit.Enabled = false;
            this.btn_edit.Enabled = false;
            this.btn_add.Enabled = false;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            Adding = true;
            txt_cityID.ResetText();
            txt_cityName.ResetText();
            dataGridView1_CellClick(null, null);
            this.btn_save.Enabled = true;
            this.btn_reload.Enabled = true;
            this.btn_exit.Enabled = false;
            this.btn_edit.Enabled = false;
            this.btn_add.Enabled = false;
            this.txt_cityID.Enabled = true;
            txt_cityID.Focus();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dataGridView1.CurrentCell.RowIndex;
            txt_cityID.Text = dataGridView1.Rows[r].Cells[0].Value.ToString();
            txt_cityName.Text = dataGridView1.Rows[r].Cells[1].Value.ToString();
        }
    }
}
