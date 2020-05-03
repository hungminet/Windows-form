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
            this.BackgroundImage = Image.FromFile(Application.StartupPath + @"\menu.jpg");
            this.BackgroundImageLayout = ImageLayout.Stretch;
            ptTetris.BackgroundImage = Image.FromFile(Application.StartupPath + @"\tetristl.png");
            ptTetris.BackgroundImageLayout = ImageLayout.Stretch;
            ptLogin.BackgroundImage = Image.FromFile(Application.StartupPath + @"\login.png");
            ptLogin.BackgroundImageLayout = ImageLayout.Stretch;
            ptPlayNow.BackgroundImage = Image.FromFile(Application.StartupPath + @"\playnown.png");
            ptPlayNow.BackgroundImageLayout = ImageLayout.Stretch;
            ptCancel.BackgroundImage = Image.FromFile(Application.StartupPath + @"\cancel.png");
            ptCancel.BackgroundImageLayout = ImageLayout.Stretch;
            ptInfo.BackgroundImage = Image.FromFile(Application.StartupPath + @"\info.png");
            ptInfo.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void ptLogin_Click(object sender, EventArgs e)
        {
            Login login = new Login(this);
           
            login.ShowDialog();
            
        }

        private void ptCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ptPlayNow_Click(object sender, EventArgs e)
        {
            MainWindow main = new MainWindow(this);
            main.ShowDialog();
        }
    }
}
