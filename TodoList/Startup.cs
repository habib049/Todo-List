using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TodoList
{
    public partial class Startup : Form
    {
        DataAccess dataAccess;

        public Startup()
        {
            InitializeComponent();
            dataAccess = DataAccess.Instance;
        }

        private const int shadow = 0x00020000;
        protected override CreateParams CreateParams {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle = shadow;
                return cp;
            }
        }

        private void Startup_Load(object sender, EventArgs e)
        {
            this.ActiveControl = usernameLogin;
            regestrationPanel.Visible = false;
            loginPanel.Visible = true;
            usernameErrorLabel.Visible = false;
            incorrectPassLabel.Visible = false;
            usernameSignupError.Visible = false;
            emailSignupError.Visible = false;
            pass1SignupLabel.Visible = false;
            pass2SignupLabel.Visible = false;
            
        }
        private void loginPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2HtmlLabel3_Click(object sender, EventArgs e)
        {

        }

        private void loginLink_Click(object sender, EventArgs e)
        {
            regestrationPanel.Visible = false;
            loginPanel.Visible = true;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            loginPanel.Visible = false;
            regestrationPanel.Visible = true;
            this.ActiveControl = usernameSignup;

        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string username = usernameLogin.Text;
            string password = passwordLogin.Text;
            if (username.Length == 0)
            {
                usernameIconLogin.ForeColor = Color.Red;
                loginUsernameUnderline.BackColor = Color.Red;
                usernameErrorLabel.Text = "field required";
                usernameErrorLabel.Visible = true;
            }
            if (password.Length == 0)
            {
                passIconLogin.ForeColor = Color.Red;
                loginPassUnderline.BackColor = Color.Red;
                incorrectPassLabel.Text = "field required";
                incorrectPassLabel.Visible = true;
            }

            if(password.Length>0 && username.Length > 0)
            {
                int result = dataAccess.ValidateUser(username, password);
                if (result==1)
                {
                   
                    this.Hide();
                    new MainScreen().Show();
                }                
                else if(result==0)
                {
                    passIconLogin.ForeColor = Color.Red;
                    loginPassUnderline.BackColor = Color.Red;
                    usernameErrorLabel.Text = "incorrect password";
                    incorrectPassLabel.Visible = true;
                    
                }
                else if (result == -1)
                {
                    usernameIconLogin.ForeColor = Color.Red;
                    loginUsernameUnderline.BackColor = Color.Red;
                    usernameErrorLabel.Text = "username does not exist";
                    usernameErrorLabel.Visible = true;
                }

            }         

        }

        private void usernameLogin_TextChanged(object sender, EventArgs e)
        {
            usernameIconLogin.ForeColor = Color.Black;
            loginUsernameUnderline.BackColor = Color.Black;
            usernameErrorLabel.Visible = false;

        }

        private void passwordLogin_TextChanged(object sender, EventArgs e)
        {
            passIconLogin.ForeColor = Color.Black;
            loginPassUnderline.BackColor = Color.Black;
            incorrectPassLabel.Visible = false;
        }

        private void showPassword_CheckStateChanged(object sender, EventArgs e)
        {
            passwordLogin.PasswordChar = showPassword.Checked ? '\0' : '●';
        }

        private void signupButton_Click(object sender, EventArgs e)
        {
            string username = usernameSignup.Text;
            string email = emailSignup.Text;
            string password1 = pass1Signup.Text;
            string password2 = pass2Signup.Text;

            if (username.Length == 0)
            {
                userIconSignup.ForeColor = Color.Red;
                usernameSignupUnderline.BackColor = Color.Red;
                usernameSignupError.Text = "field required";
                usernameSignupError.Visible = true;
            }
            if (email.Length == 0)
            {
                emailIconSignup.ForeColor = Color.Red;
                emailSignupUnderline.BackColor = Color.Red;
                emailSignupError.Text = "field required";
                emailSignupError.Visible = true;
            }
            if (password1.Length == 0)
            {
                pass1IconSignup.ForeColor = Color.Red;
                pass1SignupUnderline.BackColor = Color.Red;
                pass1SignupLabel.Text = "field required";
                pass1SignupLabel.Visible = true;
            }
            if (password2.Length == 0)
            {
                pass2IconSignup.ForeColor = Color.Red;
                pass2SignupUnderline.BackColor = Color.Red;
                pass2SignupLabel.Text = "field required";
                pass2SignupLabel.Visible = true;
            }

            //if all are filled
            if (username.Length > 0 && email.Length > 0 && password1.Length > 0 && password2.Length > 0)
            {
                //check if user already exists
                if (dataAccess.CheckUsernameAvailability(username))
                {
                    if (dataAccess.IsValidEmail(email))
                    {
                        if (dataAccess.CheckEmailAvailability(email))
                        {
                            if (password1 == password2)
                            {
                                dataAccess.AddUser(username, "", "", email, password1);
                                PerformSuccessfulRegistration();
                            }
                            else
                            {
                                pass1IconSignup.ForeColor = Color.Red;
                                pass1SignupUnderline.BackColor = Color.Red;
                                pass1SignupLabel.Text = "passwords are not same";
                                pass1SignupLabel.Visible = true;

                                pass2IconSignup.ForeColor = Color.Red;
                                pass2SignupUnderline.BackColor = Color.Red;
                                pass2SignupLabel.Text = "passwords are not same";
                                pass2SignupLabel.Visible = true;
                            }
                        }
                        else
                        {
                            emailIconSignup.ForeColor = Color.Red;
                            emailSignupUnderline.BackColor = Color.Red;
                            emailSignupError.Text = "email already regsitered";
                            emailSignupError.Visible = true;
                        }
                    }
                    else
                    {
                        emailIconSignup.ForeColor = Color.Red;
                        emailSignupUnderline.BackColor = Color.Red;
                        emailSignupError.Text = "Invalid email";
                        emailSignupError.Visible = true;
                    }
                }
                else
                {
                    userIconSignup.ForeColor = Color.Red;
                    usernameSignupUnderline.BackColor = Color.Red;
                    usernameSignupError.Text = "user already exists";
                    usernameSignupError.Visible = true;
                }
            }
        }
        private async void PerformSuccessfulRegistration()
        {
            signupButton.Text = "Successfully Registered";
            signupButton.FillColor = Color.FromArgb(71, 148, 71);
            await System.Threading.Tasks.Task.Delay(TimeSpan.FromSeconds(5));
            signupButton.Text = "Sign up";
            signupButton.FillColor = Color.WhiteSmoke;
        }

        private void usernameSignup_TextChanged(object sender, EventArgs e)
        {
            userIconSignup.ForeColor = Color.Black;
            usernameSignupUnderline.BackColor = Color.Black;
            usernameSignupError.Visible = false;

        }

        private void emailSignup_TextChanged(object sender, EventArgs e)
        {
            emailIconSignup.ForeColor = Color.Black;
            emailSignupUnderline.BackColor = Color.Black;            
            emailSignupError.Visible = false;
        }

        private void pass1Signup_TextChanged(object sender, EventArgs e)
        {
            pass1IconSignup.ForeColor = Color.Black;
            pass1SignupUnderline.BackColor = Color.Black;
            pass1SignupLabel.Visible = false;
        }

        private void pass2Signup_TextChanged(object sender, EventArgs e)
        {
            pass2IconSignup.ForeColor = Color.Black;
            pass2SignupUnderline.BackColor = Color.Black;
            pass2SignupLabel.Visible = false;
        }

        private void showPassSignup_CheckedChanged(object sender, EventArgs e)
        {
            pass1Signup.PasswordChar = showPassSignup.Checked ? '\0' : '●';
            pass2Signup.PasswordChar = showPassSignup.Checked ? '\0' : '●';
        }
    }
}
