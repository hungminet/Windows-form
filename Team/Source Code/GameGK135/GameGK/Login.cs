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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        Menu MENU;
        public Login(Menu menu)
        {
            InitializeComponent();
            MENU = menu;
            MENU.Hide();
            
        }

        
        
        private void lbExit_Click(object sender, EventArgs e)
        {
            MENU.Show();
            this.Close();
        }

        private void lbMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            pnSignUp.Visible = true;
        }

        private void txtUsername_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "Username")
                txtUsername.Text = "";
            
        }

        private void txtUsername_Leave(object sender, EventArgs e)
        {
            if (txtUsername.Text == "")
                txtUsername.Text = "Username";
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            {
               // txtPassword.PasswordChar = (char)0;
                txtPassword.Text = "Password";
            }
            

        }

        private void txtPassword_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Password")
            {
                txtPassword.Text = "";
                txtPassword.PasswordChar = '*';
            }
            
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {            
            MENU = new Menu();
            try
            {
                UserEntities playerEntity = new UserEntities();
                Player player1 = new Player();
                var pl = (from player in playerEntity.Players
                          where player.P_Username == this.txtUsername.Text.Trim()
                          select player).SingleOrDefault();
                if(pl!=null)
                {
                    if (this.txtPassword.Text.Trim() == pl.P_Password.Trim())
                    {
                        pl.P_State = true;
                        playerEntity.SaveChanges();
                        DialogResult a;
                        a = MessageBox.Show("Login Success! Click Ok to play game", "Success", MessageBoxButtons.OK);
                        if (a == DialogResult.OK)
                        {
                            this.Close();
                            this.Visible = false;
                            MENU.ptPlayNow_Click(sender, e);
                        }
                    }    
                }    
                else
                    MessageBox.Show("Username is not defined");

            }
            catch
            {

            }
        }

        private void txtUS_Click(object sender, EventArgs e)
        {
            if (txtUS.Text == "Username")
                txtUS.Text = "";
        }

        private void txtPW_Click(object sender, EventArgs e)
        {
            if (txtPW.Text == "Password")
            {
                txtPW.Text = "";
                txtPW.PasswordChar = '*';
            }
        }

        private void txtConfirm_Click(object sender, EventArgs e)
        {
            if (txtConfirm.Text == "Confirm Password")
            {
                txtConfirm.Text = "";
              //
                
                txtConfirm.PasswordChar = '*';
            }
        }

        private void txtUS_Leave(object sender, EventArgs e)
        {
            if (txtUS.Text == "")
                txtUS.Text = "Username";
        }

        private void txtPW_Leave(object sender, EventArgs e)
        {
            if (txtPW.Text == "")
            {
                txtPW.PasswordChar = (char)0;
                txtPW.Text = "Password";
            }
        }

        private void txtConfirm_Leave(object sender, EventArgs e)
        {
            if (txtConfirm.Text == "")
            {
                txtConfirm.PasswordChar = (char)0;
                txtConfirm.Text = "Confirm Password";
            }
        }

        private void lbLogin_Click(object sender, EventArgs e)
        {
            pnSignUp.Visible = false;
        }

        private void btnRG_Click_1(object sender, EventArgs e)
        {
            bool success = true;
            UserEntities playerEntity = new UserEntities();
            Player player1 = new Player();
            var pl =
                from p in playerEntity.Players
                select p;
            //Kiem tra username trong database
            foreach (var p in pl)
            {
                if (this.txtUS.Text.Trim() == p.P_Username.Trim())
                {
                    success = false;
                    MessageBox.Show("Username have been taken!");
                }
            }
            if(success)
            {
                player1.P_Username = this.txtUS.Text.Trim();
                player1.P_Password = this.txtPW.Text.Trim();
                player1.P_Score = 0;
                player1.P_State = false;
                playerEntity.Players.Add(player1);
                playerEntity.SaveChanges();
                MessageBox.Show("Register successfully!");
                this.txtUS.ResetText();
                this.txtPW.ResetText();
                this.txtConfirm.ResetText();
            }

        }

        private void txtPW_TextChanged(object sender, EventArgs e)
        {
            txtPW.PasswordChar = '*';
        }

        private void txtConfirm_TextChanged(object sender, EventArgs e)
        {
            txtConfirm.PasswordChar = '*';
        }


        private void txtPassword_TextChanged_1(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '*';
        }
    }
}
