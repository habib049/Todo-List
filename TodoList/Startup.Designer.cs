using System.Drawing;

namespace TodoList
{
    partial class Startup
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        protected override bool ShowFocusCues => false;
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {                 
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Startup));
            this.panelTitleBar = new System.Windows.Forms.Panel();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.minimizeButton = new Guna.UI2.WinForms.Guna2ControlBox();
            this.maximizeButton = new Guna.UI2.WinForms.Guna2ControlBox();
            this.closeButton = new Guna.UI2.WinForms.Guna2ControlBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.welcomePanel = new System.Windows.Forms.Panel();
            this.mainLable = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.jDragControl1 = new JDragControl.JDragControl(this.components);
            this.regestrationPanel = new System.Windows.Forms.Panel();
            this.pass2SignupLabel = new System.Windows.Forms.Label();
            this.pass1SignupLabel = new System.Windows.Forms.Label();
            this.emailSignupError = new System.Windows.Forms.Label();
            this.usernameSignupError = new System.Windows.Forms.Label();
            this.loginLink = new System.Windows.Forms.Label();
            this.showPassSignup = new Guna.UI2.WinForms.Guna2CheckBox();
            this.emailSignup = new System.Windows.Forms.TextBox();
            this.pass2Signup = new System.Windows.Forms.TextBox();
            this.pass1Signup = new System.Windows.Forms.TextBox();
            this.usernameSignup = new System.Windows.Forms.TextBox();
            this.emailSignupUnderline = new System.Windows.Forms.Panel();
            this.pass2SignupUnderline = new System.Windows.Forms.Panel();
            this.pass1SignupUnderline = new System.Windows.Forms.Panel();
            this.usernameSignupUnderline = new System.Windows.Forms.Panel();
            this.signupButton = new Guna.UI2.WinForms.Guna2Button();
            this.signupPanel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.emailIconSignup = new FontAwesome.Sharp.IconPictureBox();
            this.pass2IconSignup = new FontAwesome.Sharp.IconPictureBox();
            this.pass1IconSignup = new FontAwesome.Sharp.IconPictureBox();
            this.userIconSignup = new FontAwesome.Sharp.IconPictureBox();
            this.usernameIconLogin = new FontAwesome.Sharp.IconPictureBox();
            this.passIconLogin = new FontAwesome.Sharp.IconPictureBox();
            this.loginButton = new Guna.UI2.WinForms.Guna2Button();
            this.loginUsernameUnderline = new System.Windows.Forms.Panel();
            this.loginPassUnderline = new System.Windows.Forms.Panel();
            this.usernameLogin = new System.Windows.Forms.TextBox();
            this.passwordLogin = new System.Windows.Forms.TextBox();
            this.showPassword = new Guna.UI2.WinForms.Guna2CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.loginPanel = new System.Windows.Forms.Panel();
            this.usernameErrorLabel = new System.Windows.Forms.Label();
            this.incorrectPassLabel = new System.Windows.Forms.Label();
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.panelTitleBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.welcomePanel.SuspendLayout();
            this.regestrationPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.emailIconSignup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pass2IconSignup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pass1IconSignup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userIconSignup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usernameIconLogin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.passIconLogin)).BeginInit();
            this.loginPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTitleBar
            // 
            this.panelTitleBar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelTitleBar.Controls.Add(this.guna2HtmlLabel1);
            this.panelTitleBar.Controls.Add(this.minimizeButton);
            this.panelTitleBar.Controls.Add(this.maximizeButton);
            this.panelTitleBar.Controls.Add(this.closeButton);
            this.panelTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitleBar.Location = new System.Drawing.Point(0, 0);
            this.panelTitleBar.Name = "panelTitleBar";
            this.panelTitleBar.Size = new System.Drawing.Size(1018, 25);
            this.panelTitleBar.TabIndex = 0;
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(9, 0);
            this.guna2HtmlLabel1.Margin = new System.Windows.Forms.Padding(3, 3, 5, 3);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Padding = new System.Windows.Forms.Padding(3);
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(99, 28);
            this.guna2HtmlLabel1.TabIndex = 1;
            this.guna2HtmlLabel1.Text = "    Terllo To Do";
            // 
            // minimizeButton
            // 
            this.minimizeButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.minimizeButton.BorderColor = System.Drawing.Color.White;
            this.minimizeButton.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.minimizeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.minimizeButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.minimizeButton.FillColor = System.Drawing.Color.Transparent;
            this.minimizeButton.HoverState.Parent = this.minimizeButton;
            this.minimizeButton.IconColor = System.Drawing.Color.Black;
            this.minimizeButton.Location = new System.Drawing.Point(913, 0);
            this.minimizeButton.Name = "minimizeButton";
            this.minimizeButton.PressedColor = System.Drawing.Color.Transparent;
            this.minimizeButton.ShadowDecoration.Parent = this.minimizeButton;
            this.minimizeButton.Size = new System.Drawing.Size(35, 25);
            this.minimizeButton.TabIndex = 5;
            // 
            // maximizeButton
            // 
            this.maximizeButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.maximizeButton.BorderColor = System.Drawing.Color.White;
            this.maximizeButton.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MaximizeBox;
            this.maximizeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.maximizeButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.maximizeButton.FillColor = System.Drawing.Color.Transparent;
            this.maximizeButton.HoverState.Parent = this.maximizeButton;
            this.maximizeButton.IconColor = System.Drawing.Color.Black;
            this.maximizeButton.Location = new System.Drawing.Point(948, 0);
            this.maximizeButton.Name = "maximizeButton";
            this.maximizeButton.PressedColor = System.Drawing.Color.Transparent;
            this.maximizeButton.ShadowDecoration.Parent = this.maximizeButton;
            this.maximizeButton.Size = new System.Drawing.Size(35, 25);
            this.maximizeButton.TabIndex = 5;
            // 
            // closeButton
            // 
            this.closeButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.closeButton.BorderColor = System.Drawing.Color.White;
            this.closeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closeButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.closeButton.FillColor = System.Drawing.Color.Transparent;
            this.closeButton.HoverState.Parent = this.closeButton;
            this.closeButton.IconColor = System.Drawing.Color.Black;
            this.closeButton.Location = new System.Drawing.Point(983, 0);
            this.closeButton.Name = "closeButton";
            this.closeButton.PressedColor = System.Drawing.Color.Transparent;
            this.closeButton.ShadowDecoration.Parent = this.closeButton;
            this.closeButton.Size = new System.Drawing.Size(35, 25);
            this.closeButton.TabIndex = 4;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.ErrorImage")));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(38, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(388, 464);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.CausesValidation = false;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(60, 413);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(328, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Sign in to account to get continue";
            // 
            // welcomePanel
            // 
            this.welcomePanel.Controls.Add(this.mainLable);
            this.welcomePanel.Controls.Add(this.label1);
            this.welcomePanel.Controls.Add(this.pictureBox1);
            this.welcomePanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.welcomePanel.Location = new System.Drawing.Point(0, 25);
            this.welcomePanel.Name = "welcomePanel";
            this.welcomePanel.Size = new System.Drawing.Size(429, 550);
            this.welcomePanel.TabIndex = 4;
            // 
            // mainLable
            // 
            this.mainLable.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.mainLable.BackColor = System.Drawing.Color.Transparent;
            this.mainLable.Font = new System.Drawing.Font("Microsoft YaHei", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainLable.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.mainLable.Location = new System.Drawing.Point(65, 66);
            this.mainLable.Name = "mainLable";
            this.mainLable.Size = new System.Drawing.Size(323, 37);
            this.mainLable.TabIndex = 1;
            this.mainLable.Text = "Welcome  to Terllo To Do";
            // 
            // jDragControl1
            // 
            this.jDragControl1.GetForm = this;
            this.jDragControl1.TargetControl = this.panelTitleBar;
            // 
            // regestrationPanel
            // 
            this.regestrationPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.regestrationPanel.Controls.Add(this.pass2SignupLabel);
            this.regestrationPanel.Controls.Add(this.pass1SignupLabel);
            this.regestrationPanel.Controls.Add(this.emailSignupError);
            this.regestrationPanel.Controls.Add(this.usernameSignupError);
            this.regestrationPanel.Controls.Add(this.loginLink);
            this.regestrationPanel.Controls.Add(this.showPassSignup);
            this.regestrationPanel.Controls.Add(this.emailSignup);
            this.regestrationPanel.Controls.Add(this.pass2Signup);
            this.regestrationPanel.Controls.Add(this.pass1Signup);
            this.regestrationPanel.Controls.Add(this.usernameSignup);
            this.regestrationPanel.Controls.Add(this.emailSignupUnderline);
            this.regestrationPanel.Controls.Add(this.pass2SignupUnderline);
            this.regestrationPanel.Controls.Add(this.pass1SignupUnderline);
            this.regestrationPanel.Controls.Add(this.usernameSignupUnderline);
            this.regestrationPanel.Controls.Add(this.signupButton);
            this.regestrationPanel.Controls.Add(this.signupPanel);
            this.regestrationPanel.Controls.Add(this.emailIconSignup);
            this.regestrationPanel.Controls.Add(this.pass2IconSignup);
            this.regestrationPanel.Controls.Add(this.pass1IconSignup);
            this.regestrationPanel.Controls.Add(this.userIconSignup);
            this.regestrationPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.regestrationPanel.Location = new System.Drawing.Point(435, 31);
            this.regestrationPanel.Name = "regestrationPanel";
            this.regestrationPanel.Size = new System.Drawing.Size(579, 532);
            this.regestrationPanel.TabIndex = 6;
            // 
            // pass2SignupLabel
            // 
            this.pass2SignupLabel.AutoSize = true;
            this.pass2SignupLabel.ForeColor = System.Drawing.Color.Red;
            this.pass2SignupLabel.Location = new System.Drawing.Point(347, 357);
            this.pass2SignupLabel.Name = "pass2SignupLabel";
            this.pass2SignupLabel.Size = new System.Drawing.Size(128, 13);
            this.pass2SignupLabel.TabIndex = 24;
            this.pass2SignupLabel.Text = "password does not match";
            // 
            // pass1SignupLabel
            // 
            this.pass1SignupLabel.AutoSize = true;
            this.pass1SignupLabel.ForeColor = System.Drawing.Color.Red;
            this.pass1SignupLabel.Location = new System.Drawing.Point(348, 293);
            this.pass1SignupLabel.Name = "pass1SignupLabel";
            this.pass1SignupLabel.Size = new System.Drawing.Size(128, 13);
            this.pass1SignupLabel.TabIndex = 24;
            this.pass1SignupLabel.Text = "password does not match";
            // 
            // emailSignupError
            // 
            this.emailSignupError.AutoSize = true;
            this.emailSignupError.ForeColor = System.Drawing.Color.Red;
            this.emailSignupError.Location = new System.Drawing.Point(373, 227);
            this.emailSignupError.Name = "emailSignupError";
            this.emailSignupError.Size = new System.Drawing.Size(97, 13);
            this.emailSignupError.TabIndex = 24;
            this.emailSignupError.Text = "email already exists";
            // 
            // usernameSignupError
            // 
            this.usernameSignupError.AutoSize = true;
            this.usernameSignupError.ForeColor = System.Drawing.Color.Red;
            this.usernameSignupError.Location = new System.Drawing.Point(352, 149);
            this.usernameSignupError.Name = "usernameSignupError";
            this.usernameSignupError.Size = new System.Drawing.Size(119, 13);
            this.usernameSignupError.TabIndex = 24;
            this.usernameSignupError.Text = "username already exists";
            // 
            // loginLink
            // 
            this.loginLink.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.loginLink.AutoSize = true;
            this.loginLink.Cursor = System.Windows.Forms.Cursors.Hand;
            this.loginLink.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginLink.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.loginLink.Location = new System.Drawing.Point(292, 464);
            this.loginLink.Name = "loginLink";
            this.loginLink.Size = new System.Drawing.Size(43, 19);
            this.loginLink.TabIndex = 7;
            this.loginLink.Text = "Login";
            this.loginLink.Click += new System.EventHandler(this.loginLink_Click);
            // 
            // showPassSignup
            // 
            this.showPassSignup.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.showPassSignup.AutoSize = true;
            this.showPassSignup.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.showPassSignup.CheckedState.BorderRadius = 0;
            this.showPassSignup.CheckedState.BorderThickness = 0;
            this.showPassSignup.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.showPassSignup.CheckMarkColor = System.Drawing.Color.Black;
            this.showPassSignup.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.showPassSignup.Location = new System.Drawing.Point(156, 369);
            this.showPassSignup.Name = "showPassSignup";
            this.showPassSignup.Size = new System.Drawing.Size(99, 17);
            this.showPassSignup.TabIndex = 5;
            this.showPassSignup.Text = "show password";
            this.showPassSignup.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.showPassSignup.UncheckedState.BorderRadius = 0;
            this.showPassSignup.UncheckedState.BorderThickness = 0;
            this.showPassSignup.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.showPassSignup.CheckedChanged += new System.EventHandler(this.showPassSignup_CheckedChanged);
            // 
            // emailSignup
            // 
            this.emailSignup.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.emailSignup.BackColor = System.Drawing.Color.WhiteSmoke;
            this.emailSignup.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.emailSignup.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailSignup.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.emailSignup.Location = new System.Drawing.Point(207, 181);
            this.emailSignup.Name = "emailSignup";
            this.emailSignup.Size = new System.Drawing.Size(264, 22);
            this.emailSignup.TabIndex = 2;
            this.emailSignup.TextChanged += new System.EventHandler(this.emailSignup_TextChanged);
            // 
            // pass2Signup
            // 
            this.pass2Signup.AcceptsReturn = true;
            this.pass2Signup.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pass2Signup.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pass2Signup.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pass2Signup.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pass2Signup.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pass2Signup.Location = new System.Drawing.Point(207, 316);
            this.pass2Signup.Name = "pass2Signup";
            this.pass2Signup.PasswordChar = '●';
            this.pass2Signup.Size = new System.Drawing.Size(264, 22);
            this.pass2Signup.TabIndex = 4;
            this.pass2Signup.TextChanged += new System.EventHandler(this.pass2Signup_TextChanged);
            // 
            // pass1Signup
            // 
            this.pass1Signup.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pass1Signup.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pass1Signup.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pass1Signup.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pass1Signup.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pass1Signup.Location = new System.Drawing.Point(206, 249);
            this.pass1Signup.Name = "pass1Signup";
            this.pass1Signup.PasswordChar = '●';
            this.pass1Signup.Size = new System.Drawing.Size(264, 22);
            this.pass1Signup.TabIndex = 3;
            this.pass1Signup.TextChanged += new System.EventHandler(this.pass1Signup_TextChanged);
            // 
            // usernameSignup
            // 
            this.usernameSignup.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.usernameSignup.BackColor = System.Drawing.Color.WhiteSmoke;
            this.usernameSignup.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.usernameSignup.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameSignup.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.usernameSignup.Location = new System.Drawing.Point(207, 107);
            this.usernameSignup.Name = "usernameSignup";
            this.usernameSignup.Size = new System.Drawing.Size(264, 22);
            this.usernameSignup.TabIndex = 1;
            this.usernameSignup.TextChanged += new System.EventHandler(this.usernameSignup_TextChanged);
            // 
            // emailSignupUnderline
            // 
            this.emailSignupUnderline.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.emailSignupUnderline.BackColor = System.Drawing.Color.Black;
            this.emailSignupUnderline.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.emailSignupUnderline.Location = new System.Drawing.Point(156, 213);
            this.emailSignupUnderline.Name = "emailSignupUnderline";
            this.emailSignupUnderline.Size = new System.Drawing.Size(316, 3);
            this.emailSignupUnderline.TabIndex = 20;
            // 
            // pass2SignupUnderline
            // 
            this.pass2SignupUnderline.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pass2SignupUnderline.BackColor = System.Drawing.Color.Black;
            this.pass2SignupUnderline.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pass2SignupUnderline.Location = new System.Drawing.Point(156, 348);
            this.pass2SignupUnderline.Name = "pass2SignupUnderline";
            this.pass2SignupUnderline.Size = new System.Drawing.Size(316, 3);
            this.pass2SignupUnderline.TabIndex = 20;
            // 
            // pass1SignupUnderline
            // 
            this.pass1SignupUnderline.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pass1SignupUnderline.BackColor = System.Drawing.Color.Black;
            this.pass1SignupUnderline.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pass1SignupUnderline.Location = new System.Drawing.Point(155, 281);
            this.pass1SignupUnderline.Name = "pass1SignupUnderline";
            this.pass1SignupUnderline.Size = new System.Drawing.Size(316, 3);
            this.pass1SignupUnderline.TabIndex = 20;
            // 
            // usernameSignupUnderline
            // 
            this.usernameSignupUnderline.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.usernameSignupUnderline.BackColor = System.Drawing.Color.Black;
            this.usernameSignupUnderline.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.usernameSignupUnderline.Location = new System.Drawing.Point(156, 139);
            this.usernameSignupUnderline.Name = "usernameSignupUnderline";
            this.usernameSignupUnderline.Size = new System.Drawing.Size(316, 3);
            this.usernameSignupUnderline.TabIndex = 20;
            // 
            // signupButton
            // 
            this.signupButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.signupButton.BackColor = System.Drawing.Color.Black;
            this.signupButton.BorderThickness = 2;
            this.signupButton.CheckedState.Parent = this.signupButton;
            this.signupButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.signupButton.CustomImages.Parent = this.signupButton;
            this.signupButton.FillColor = System.Drawing.Color.WhiteSmoke;
            this.signupButton.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signupButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.signupButton.HoverState.Parent = this.signupButton;
            this.signupButton.Location = new System.Drawing.Point(157, 407);
            this.signupButton.Name = "signupButton";
            this.signupButton.ShadowDecoration.Parent = this.signupButton;
            this.signupButton.Size = new System.Drawing.Size(315, 40);
            this.signupButton.TabIndex = 6;
            this.signupButton.Text = "Sign up";
            this.signupButton.Click += new System.EventHandler(this.signupButton_Click);
            // 
            // signupPanel
            // 
            this.signupPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.signupPanel.BackColor = System.Drawing.Color.Transparent;
            this.signupPanel.Font = new System.Drawing.Font("Microsoft YaHei", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signupPanel.ForeColor = System.Drawing.Color.Black;
            this.signupPanel.Location = new System.Drawing.Point(260, 32);
            this.signupPanel.Name = "signupPanel";
            this.signupPanel.Size = new System.Drawing.Size(102, 37);
            this.signupPanel.TabIndex = 0;
            this.signupPanel.Text = "Sign up";
            this.signupPanel.Click += new System.EventHandler(this.guna2HtmlLabel3_Click);
            // 
            // emailIconSignup
            // 
            this.emailIconSignup.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.emailIconSignup.BackColor = System.Drawing.Color.WhiteSmoke;
            this.emailIconSignup.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.emailIconSignup.IconChar = FontAwesome.Sharp.IconChar.Envelope;
            this.emailIconSignup.IconColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.emailIconSignup.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.emailIconSignup.IconSize = 40;
            this.emailIconSignup.Location = new System.Drawing.Point(156, 176);
            this.emailIconSignup.Name = "emailIconSignup";
            this.emailIconSignup.Size = new System.Drawing.Size(45, 40);
            this.emailIconSignup.TabIndex = 5;
            this.emailIconSignup.TabStop = false;
            // 
            // pass2IconSignup
            // 
            this.pass2IconSignup.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pass2IconSignup.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pass2IconSignup.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pass2IconSignup.IconChar = FontAwesome.Sharp.IconChar.Lock;
            this.pass2IconSignup.IconColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pass2IconSignup.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.pass2IconSignup.IconSize = 40;
            this.pass2IconSignup.Location = new System.Drawing.Point(156, 311);
            this.pass2IconSignup.Name = "pass2IconSignup";
            this.pass2IconSignup.Size = new System.Drawing.Size(45, 40);
            this.pass2IconSignup.TabIndex = 5;
            this.pass2IconSignup.TabStop = false;
            // 
            // pass1IconSignup
            // 
            this.pass1IconSignup.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pass1IconSignup.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pass1IconSignup.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pass1IconSignup.IconChar = FontAwesome.Sharp.IconChar.Lock;
            this.pass1IconSignup.IconColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pass1IconSignup.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.pass1IconSignup.IconSize = 40;
            this.pass1IconSignup.Location = new System.Drawing.Point(155, 244);
            this.pass1IconSignup.Name = "pass1IconSignup";
            this.pass1IconSignup.Size = new System.Drawing.Size(45, 40);
            this.pass1IconSignup.TabIndex = 5;
            this.pass1IconSignup.TabStop = false;
            // 
            // userIconSignup
            // 
            this.userIconSignup.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.userIconSignup.BackColor = System.Drawing.Color.WhiteSmoke;
            this.userIconSignup.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.userIconSignup.IconChar = FontAwesome.Sharp.IconChar.User;
            this.userIconSignup.IconColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.userIconSignup.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.userIconSignup.IconSize = 40;
            this.userIconSignup.Location = new System.Drawing.Point(156, 102);
            this.userIconSignup.Name = "userIconSignup";
            this.userIconSignup.Size = new System.Drawing.Size(45, 40);
            this.userIconSignup.TabIndex = 5;
            this.userIconSignup.TabStop = false;
            // 
            // usernameIconLogin
            // 
            this.usernameIconLogin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.usernameIconLogin.BackColor = System.Drawing.Color.WhiteSmoke;
            this.usernameIconLogin.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.usernameIconLogin.IconChar = FontAwesome.Sharp.IconChar.User;
            this.usernameIconLogin.IconColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.usernameIconLogin.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.usernameIconLogin.IconSize = 40;
            this.usernameIconLogin.Location = new System.Drawing.Point(151, 185);
            this.usernameIconLogin.Name = "usernameIconLogin";
            this.usernameIconLogin.Size = new System.Drawing.Size(45, 40);
            this.usernameIconLogin.TabIndex = 5;
            this.usernameIconLogin.TabStop = false;
            // 
            // passIconLogin
            // 
            this.passIconLogin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.passIconLogin.BackColor = System.Drawing.Color.WhiteSmoke;
            this.passIconLogin.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.passIconLogin.IconChar = FontAwesome.Sharp.IconChar.Lock;
            this.passIconLogin.IconColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.passIconLogin.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.passIconLogin.IconSize = 40;
            this.passIconLogin.Location = new System.Drawing.Point(151, 253);
            this.passIconLogin.Name = "passIconLogin";
            this.passIconLogin.Size = new System.Drawing.Size(45, 40);
            this.passIconLogin.TabIndex = 5;
            this.passIconLogin.TabStop = false;
            // 
            // loginButton
            // 
            this.loginButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.loginButton.BackColor = System.Drawing.Color.Black;
            this.loginButton.BorderThickness = 2;
            this.loginButton.CheckedState.Parent = this.loginButton;
            this.loginButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.loginButton.CustomImages.Parent = this.loginButton;
            this.loginButton.FillColor = System.Drawing.Color.WhiteSmoke;
            this.loginButton.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.loginButton.HoverState.Parent = this.loginButton;
            this.loginButton.Location = new System.Drawing.Point(152, 355);
            this.loginButton.Name = "loginButton";
            this.loginButton.ShadowDecoration.Parent = this.loginButton;
            this.loginButton.Size = new System.Drawing.Size(315, 40);
            this.loginButton.TabIndex = 4;
            this.loginButton.Text = "Login";
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // loginUsernameUnderline
            // 
            this.loginUsernameUnderline.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.loginUsernameUnderline.BackColor = System.Drawing.Color.Black;
            this.loginUsernameUnderline.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.loginUsernameUnderline.Location = new System.Drawing.Point(151, 222);
            this.loginUsernameUnderline.Name = "loginUsernameUnderline";
            this.loginUsernameUnderline.Size = new System.Drawing.Size(316, 3);
            this.loginUsernameUnderline.TabIndex = 20;
            // 
            // loginPassUnderline
            // 
            this.loginPassUnderline.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.loginPassUnderline.BackColor = System.Drawing.Color.Black;
            this.loginPassUnderline.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.loginPassUnderline.Location = new System.Drawing.Point(151, 290);
            this.loginPassUnderline.Name = "loginPassUnderline";
            this.loginPassUnderline.Size = new System.Drawing.Size(316, 3);
            this.loginPassUnderline.TabIndex = 20;
            // 
            // usernameLogin
            // 
            this.usernameLogin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.usernameLogin.BackColor = System.Drawing.Color.WhiteSmoke;
            this.usernameLogin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.usernameLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameLogin.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.usernameLogin.Location = new System.Drawing.Point(202, 190);
            this.usernameLogin.Name = "usernameLogin";
            this.usernameLogin.Size = new System.Drawing.Size(264, 22);
            this.usernameLogin.TabIndex = 1;
            this.usernameLogin.TextChanged += new System.EventHandler(this.usernameLogin_TextChanged);
            // 
            // passwordLogin
            // 
            this.passwordLogin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.passwordLogin.BackColor = System.Drawing.Color.WhiteSmoke;
            this.passwordLogin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.passwordLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordLogin.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.passwordLogin.Location = new System.Drawing.Point(202, 258);
            this.passwordLogin.Name = "passwordLogin";
            this.passwordLogin.PasswordChar = '●';
            this.passwordLogin.Size = new System.Drawing.Size(264, 22);
            this.passwordLogin.TabIndex = 2;
            this.passwordLogin.TextChanged += new System.EventHandler(this.passwordLogin_TextChanged);
            // 
            // showPassword
            // 
            this.showPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.showPassword.AutoSize = true;
            this.showPassword.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.showPassword.CheckedState.BorderRadius = 0;
            this.showPassword.CheckedState.BorderThickness = 0;
            this.showPassword.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.showPassword.CheckMarkColor = System.Drawing.Color.Black;
            this.showPassword.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.showPassword.Location = new System.Drawing.Point(151, 306);
            this.showPassword.Name = "showPassword";
            this.showPassword.Size = new System.Drawing.Size(99, 17);
            this.showPassword.TabIndex = 3;
            this.showPassword.Text = "show password";
            this.showPassword.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.showPassword.UncheckedState.BorderRadius = 0;
            this.showPassword.UncheckedState.BorderThickness = 0;
            this.showPassword.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.showPassword.CheckStateChanged += new System.EventHandler(this.showPassword_CheckStateChanged);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(288, 412);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 19);
            this.label2.TabIndex = 5;
            this.label2.Text = "Sign up";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // loginPanel
            // 
            this.loginPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.loginPanel.Controls.Add(this.usernameErrorLabel);
            this.loginPanel.Controls.Add(this.incorrectPassLabel);
            this.loginPanel.Controls.Add(this.label2);
            this.loginPanel.Controls.Add(this.showPassword);
            this.loginPanel.Controls.Add(this.passwordLogin);
            this.loginPanel.Controls.Add(this.usernameLogin);
            this.loginPanel.Controls.Add(this.loginPassUnderline);
            this.loginPanel.Controls.Add(this.loginUsernameUnderline);
            this.loginPanel.Controls.Add(this.loginButton);
            this.loginPanel.Controls.Add(this.guna2HtmlLabel2);
            this.loginPanel.Controls.Add(this.passIconLogin);
            this.loginPanel.Controls.Add(this.usernameIconLogin);
            this.loginPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.loginPanel.Location = new System.Drawing.Point(435, 31);
            this.loginPanel.Name = "loginPanel";
            this.loginPanel.Size = new System.Drawing.Size(579, 532);
            this.loginPanel.TabIndex = 5;
            this.loginPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.loginPanel_Paint);
            // 
            // usernameErrorLabel
            // 
            this.usernameErrorLabel.AutoSize = true;
            this.usernameErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.usernameErrorLabel.Location = new System.Drawing.Point(346, 233);
            this.usernameErrorLabel.Name = "usernameErrorLabel";
            this.usernameErrorLabel.Size = new System.Drawing.Size(126, 13);
            this.usernameErrorLabel.TabIndex = 24;
            this.usernameErrorLabel.Text = "username does not exists";
            // 
            // incorrectPassLabel
            // 
            this.incorrectPassLabel.AutoSize = true;
            this.incorrectPassLabel.ForeColor = System.Drawing.Color.Red;
            this.incorrectPassLabel.Location = new System.Drawing.Point(371, 300);
            this.incorrectPassLabel.Name = "incorrectPassLabel";
            this.incorrectPassLabel.Size = new System.Drawing.Size(96, 13);
            this.incorrectPassLabel.TabIndex = 24;
            this.incorrectPassLabel.Text = "incorrect password";
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel2.Font = new System.Drawing.Font("Microsoft YaHei", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel2.ForeColor = System.Drawing.Color.Black;
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(269, 103);
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(75, 37);
            this.guna2HtmlLabel2.TabIndex = 0;
            this.guna2HtmlLabel2.Text = "Login";
            // 
            // Startup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1018, 575);
            this.Controls.Add(this.welcomePanel);
            this.Controls.Add(this.panelTitleBar);
            this.Controls.Add(this.loginPanel);
            this.Controls.Add(this.regestrationPanel);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Startup";
            this.Text = "To do";
            this.Load += new System.EventHandler(this.Startup_Load);
            this.panelTitleBar.ResumeLayout(false);
            this.panelTitleBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.welcomePanel.ResumeLayout(false);
            this.welcomePanel.PerformLayout();
            this.regestrationPanel.ResumeLayout(false);
            this.regestrationPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.emailIconSignup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pass2IconSignup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pass1IconSignup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userIconSignup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usernameIconLogin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.passIconLogin)).EndInit();
            this.loginPanel.ResumeLayout(false);
            this.loginPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        

        #endregion

        private System.Windows.Forms.Panel panelTitleBar;
        private Guna.UI2.WinForms.Guna2ControlBox closeButton;
        private Guna.UI2.WinForms.Guna2ControlBox minimizeButton;
        private Guna.UI2.WinForms.Guna2ControlBox maximizeButton;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel welcomePanel;
        private Guna.UI2.WinForms.Guna2HtmlLabel mainLable;
        private JDragControl.JDragControl jDragControl1;
        private System.Windows.Forms.Panel regestrationPanel;
        private System.Windows.Forms.Label loginLink;
        private Guna.UI2.WinForms.Guna2CheckBox showPassSignup;
        private System.Windows.Forms.TextBox pass1Signup;
        private System.Windows.Forms.TextBox usernameSignup;
        private System.Windows.Forms.Panel pass1SignupUnderline;
        private System.Windows.Forms.Panel usernameSignupUnderline;
        private Guna.UI2.WinForms.Guna2Button signupButton;
        private Guna.UI2.WinForms.Guna2HtmlLabel signupPanel;
        private FontAwesome.Sharp.IconPictureBox pass1IconSignup;
        private FontAwesome.Sharp.IconPictureBox userIconSignup;
        private System.Windows.Forms.TextBox emailSignup;
        private System.Windows.Forms.TextBox pass2Signup;
        private System.Windows.Forms.Panel emailSignupUnderline;
        private System.Windows.Forms.Panel pass2SignupUnderline;
        private FontAwesome.Sharp.IconPictureBox emailIconSignup;
        private FontAwesome.Sharp.IconPictureBox pass2IconSignup;
        private System.Windows.Forms.Panel loginPanel;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2CheckBox showPassword;
        private System.Windows.Forms.TextBox passwordLogin;
        private System.Windows.Forms.TextBox usernameLogin;
        private System.Windows.Forms.Panel loginPassUnderline;
        private System.Windows.Forms.Panel loginUsernameUnderline;
        private Guna.UI2.WinForms.Guna2Button loginButton;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private FontAwesome.Sharp.IconPictureBox passIconLogin;
        private FontAwesome.Sharp.IconPictureBox usernameIconLogin;
        private System.Windows.Forms.Label usernameErrorLabel;
        private System.Windows.Forms.Label incorrectPassLabel;
        private System.Windows.Forms.Label pass2SignupLabel;
        private System.Windows.Forms.Label pass1SignupLabel;
        private System.Windows.Forms.Label emailSignupError;
        private System.Windows.Forms.Label usernameSignupError;
    }
}