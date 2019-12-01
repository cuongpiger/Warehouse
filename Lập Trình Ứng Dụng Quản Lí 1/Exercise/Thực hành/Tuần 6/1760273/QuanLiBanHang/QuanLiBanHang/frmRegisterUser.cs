using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiBanHang
{
    public partial class frmRegisterForm : Form
    {
        static DAL_Users dalUsers = new DAL_Users();

        public frmRegisterForm()
        {
            InitializeComponent();
        }

        public bool IsValidEmail(string iEmail)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(iEmail);
                return addr.Address == iEmail;
            }
            catch
            {
                return false;
            }
        }

        private string HashStringToPassword(string iPassword)
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
            var pbkdf2 = new Rfc2898DeriveBytes(iPassword, salt, 1000);
            byte[] hash = pbkdf2.GetBytes(20);
            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);
            string savedPasswordHash = Convert.ToBase64String(hashBytes);

            return savedPasswordHash;
        }

        private bool CheckAcceptedPassword(string iValidPassword, string iPassword)
        {
            string savedPasswordHash = iValidPassword;
            byte[] hashBytes = Convert.FromBase64String(savedPasswordHash);
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);
            var pbkdf2 = new Rfc2898DeriveBytes(iPassword, salt, 1000);
            byte[] hash = pbkdf2.GetBytes(20);

            for (int i = 0; i < 20; i++)
            {
                if (hashBytes[i + 16] != hash[i])
                {
                    return false;
                } 
            }

            return true;
        }

        private void btnRegisterUser_Click(object sender, EventArgs e)
        {
            if (btnRegisterUser.Text == "Clear")
            {
                txbEmail.Text = "";
                txbName.Text = "";
                txbPassword.Text = "";
                txbUsername.Text = "";
                mtbDOB.Text = "  /  /";

                btnRegisterUser.Text = "Register User";
                lblSuccess.Text = "";
                return;
            }

            if (txbUsername.Text.Length == 0)
            {
                lblUsername.Text = "(*) Username can not be empty.";
                return;
            }

            if (txbPassword.Text.Length == 0)
            {
                lblPassword.Text = "(*) Password can not be empty.";
                return;
            }

            if (txbName.Text.Length == 0)
            {
                lblName.Text = "(*) Name can not be empty.";
                return;
            }

            if (txbEmail.Text.Length == 0)
            {
                lblEmail.Text = "(*) Email can not be empty.";
                return;
            }

            if (true)
            {
                string tmp = mtbDOB.Text;
                for (int i = 0; i < tmp.Length; ++i)
                {
                    if (tmp[i] == ' ')
                    {
                        lblDOB.Text = "(*) DOB can not be empty.";
                        return;
                    }
                }
            }

            if (lblDOB.Text != "" || lblEmail.Text != "" || lblName.Text != "" || lblPassword.Text != "" || lblUsername.Text != "")
            {
                return;
            }

            string[] date = mtbDOB.Text.Split('/');
            string DOB = date[2] + '-' + date[1] + '-' + date[0];

            while (true)
            {
                if (dalUsers.InsertNewUser(txbUsername.Text, HashStringToPassword(txbPassword.Text), txbName.Text, txbEmail.Text, DOB) == 1)
                {
                    lblSuccess.Text = "Insert success!";
                    btnRegisterUser.Text = "Clear";
                    break;
                }
            }
        }

        private void txbUsername_Leave(object sender, EventArgs e)
        {
            if (txbUsername.Text.Length == 0)
            {
                return;
            }

            if (txbUsername.Text.Any(char.IsUpper))
            {
                lblUsername.Text = "(*) Username must not contain uppercase letters.";
                return;
            }

            if (txbUsername.Text.Contains(' '))
            {
                lblUsername.Text = "(*) Username must not contain space letters.";
                return;
            }

            if ('a' > txbUsername.Text[0] || txbUsername.Text[0] > 'z')
            {
                lblUsername.Text = "(*) Username must start with an lower alphabet letter.";
                return;
            }

            for (int i = 0; i < txbUsername.Text.Length; ++i)
            {
                if ((txbUsername.Text[i] < 'a' || txbUsername.Text[i] > 'z') && (txbUsername.Text[i] < '0' || txbUsername.Text[i] > '9') &&
                    txbUsername.Text[i] != '-' && txbUsername.Text[i] != '_' && txbUsername.Text[i] != '.')
                {
                    lblUsername.Text = "(*) Username only contains letters (a-z, 0-9, '-', '_', '.').";
                    return;
                }
            }

            if (dalUsers.CheckIdentityUsername(txbUsername.Text) == 0)
            {
                lblUsername.Text = "(*) Username already exists in the system.";
                return;
            }

            lblUsername.Text = "";
        }

        private void txbPassword_Leave(object sender, EventArgs e)
        {
            if (txbPassword.Text.Length < 3 && txbPassword.Text.Length > 0)
            {
                lblPassword.Text = "(*) Password length must be at least 3 characters.";
                return;
            }

            for (int i = 0; i < txbPassword.Text.Length; ++i)
            {
                if ((txbPassword.Text[i] < 'a' || txbPassword.Text[i] > 'z') && (txbPassword.Text[i] < '0' || txbPassword.Text[i] > '9'))
                {
                    lblPassword.Text = "(*) Password only contains letters (a-z, 0-9).";
                    return;
                }
            }

            lblPassword.Text = "";
        }

        private void txbName_Leave(object sender, EventArgs e)
        {
            if (txbName.Text.Length == 0)
            {
                return;
            }

            if (('a' > txbName.Text[0] || txbName.Text[0] > 'z') && ('A' > txbName.Text[0] || txbName.Text[0] > 'Z'))
            {
                lblName.Text = "(*) Name only contains letters (a-z, A-Z).";
                return;
            }

            lblName.Text = "";
        }

        private void txbEmail_Leave(object sender, EventArgs e)
        {
            if (txbEmail.Text.Length == 0)
            {
                return;
            }

            if (IsValidEmail(txbEmail.Text) == false)
            {
                lblEmail.Text = "(*) Email address is not valid.";
                return;
            }

            lblEmail.Text = "";
        }

        private void mtbDOB_Leave(object sender, EventArgs e)
        {
            try
            {
                string[] date = mtbDOB.Text.Split('/');
                DateTime dateTime = new DateTime(int.Parse(date[2]), int.Parse(date[1]), int.Parse(date[0]));
            }
            catch
            {
                lblDOB.Text = "(*) DOB is not valid.";
                return;
            }

            lblDOB.Text = "";
        }
    }
}
