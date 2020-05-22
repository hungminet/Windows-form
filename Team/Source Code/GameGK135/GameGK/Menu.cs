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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = Properties.Resources.menu;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            ptTetris.BackgroundImage = Properties.Resources.tetristl; 
            ptTetris.BackgroundImageLayout = ImageLayout.Stretch;
            ptLogin.BackgroundImage = Properties.Resources.login;
            ptLogin.BackgroundImageLayout = ImageLayout.Stretch;
            ptPlayNow.BackgroundImage = Properties.Resources.playnown; 
            ptPlayNow.BackgroundImageLayout = ImageLayout.Stretch;
            ptCancel.BackgroundImage = Properties.Resources.cancel;
            ptCancel.BackgroundImageLayout = ImageLayout.Stretch;
            ptInfo.BackgroundImage = Properties.Resources.info;
            ptInfo.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void ptLogin_Click(object sender, EventArgs e)
        {
            Login login = new Login(this);
           
            login.ShowDialog();
            
        }

        private void ptCancel_Click(object sender, EventArgs e)
        {
            DialogResult di;
            di = MessageBox.Show("Exit?", "Confirm", MessageBoxButtons.YesNo);
            if (di == DialogResult.Yes)
                Application.Exit();
            else
            { }    


        }

        public void ptPlayNow_Click(object sender, EventArgs e)
        {
            MainWindow main = new MainWindow(this);
            main.ShowDialog();
        }

        private void ptInfo_Click(object sender, EventArgs e)
        {
            Score score = new Score();
            score.ShowDialog();
        }
    }
}
