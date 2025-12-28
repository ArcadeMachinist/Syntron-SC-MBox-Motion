namespace SyntronMboxTools
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            inputMBoxIP = new TextBox();
            label2 = new Label();
            inputMBoxMode = new ComboBox();
            btnJoystickInit = new Button();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            btnJoy0 = new Button();
            btnJoy1 = new Button();
            btnJoy2 = new Button();
            btnJoy3 = new Button();
            lblTargetX = new Label();
            lblTargetY = new Label();
            btnMBoxConnect = new Button();
            btnZero = new Button();
            btnSetZero = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(60, 56);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 0;
            label1.Text = "MBox IP";
            // 
            // inputMBoxIP
            // 
            inputMBoxIP.Location = new Point(117, 53);
            inputMBoxIP.Name = "inputMBoxIP";
            inputMBoxIP.Size = new Size(100, 23);
            inputMBoxIP.TabIndex = 1;
            inputMBoxIP.Text = "192.168.233.201";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(236, 56);
            label2.Name = "label2";
            label2.Size = new Size(38, 15);
            label2.TabIndex = 2;
            label2.Text = "Mode";
            // 
            // inputMBoxMode
            // 
            inputMBoxMode.DropDownStyle = ComboBoxStyle.DropDownList;
            inputMBoxMode.FormattingEnabled = true;
            inputMBoxMode.Location = new Point(280, 53);
            inputMBoxMode.Name = "inputMBoxMode";
            inputMBoxMode.Size = new Size(121, 23);
            inputMBoxMode.TabIndex = 3;
            // 
            // btnJoystickInit
            // 
            btnJoystickInit.Location = new Point(433, 53);
            btnJoystickInit.Name = "btnJoystickInit";
            btnJoystickInit.Size = new Size(110, 23);
            btnJoystickInit.TabIndex = 4;
            btnJoystickInit.Text = "Joystick Init";
            btnJoystickInit.UseVisualStyleBackColor = true;
            btnJoystickInit.Click += btnJoystickInit_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(433, 79);
            label3.Name = "label3";
            label3.Size = new Size(181, 15);
            label3.TabIndex = 5;
            label3.Text = "Waiting for joystick connection...";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(433, 103);
            label4.Name = "label4";
            label4.Size = new Size(14, 15);
            label4.TabIndex = 6;
            label4.Text = "X";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(505, 103);
            label5.Name = "label5";
            label5.Size = new Size(14, 15);
            label5.TabIndex = 7;
            label5.Text = "Y";
            // 
            // btnJoy0
            // 
            btnJoy0.Location = new Point(433, 134);
            btnJoy0.Name = "btnJoy0";
            btnJoy0.Size = new Size(23, 23);
            btnJoy0.TabIndex = 8;
            btnJoy0.UseVisualStyleBackColor = true;
            // 
            // btnJoy1
            // 
            btnJoy1.Location = new Point(462, 134);
            btnJoy1.Name = "btnJoy1";
            btnJoy1.Size = new Size(23, 23);
            btnJoy1.TabIndex = 9;
            btnJoy1.UseVisualStyleBackColor = true;
            // 
            // btnJoy2
            // 
            btnJoy2.Location = new Point(491, 134);
            btnJoy2.Name = "btnJoy2";
            btnJoy2.Size = new Size(23, 23);
            btnJoy2.TabIndex = 10;
            btnJoy2.UseVisualStyleBackColor = true;
            // 
            // btnJoy3
            // 
            btnJoy3.Location = new Point(520, 134);
            btnJoy3.Name = "btnJoy3";
            btnJoy3.Size = new Size(23, 23);
            btnJoy3.TabIndex = 11;
            btnJoy3.UseVisualStyleBackColor = true;
            // 
            // lblTargetX
            // 
            lblTargetX.AutoSize = true;
            lblTargetX.Location = new Point(439, 252);
            lblTargetX.Name = "lblTargetX";
            lblTargetX.Size = new Size(38, 15);
            lblTargetX.TabIndex = 12;
            lblTargetX.Text = "label6";
            // 
            // lblTargetY
            // 
            lblTargetY.AutoSize = true;
            lblTargetY.Location = new Point(439, 284);
            lblTargetY.Name = "lblTargetY";
            lblTargetY.Size = new Size(38, 15);
            lblTargetY.TabIndex = 13;
            lblTargetY.Text = "label6";
            // 
            // btnMBoxConnect
            // 
            btnMBoxConnect.Location = new Point(326, 95);
            btnMBoxConnect.Name = "btnMBoxConnect";
            btnMBoxConnect.Size = new Size(75, 23);
            btnMBoxConnect.TabIndex = 14;
            btnMBoxConnect.Text = "Connect";
            btnMBoxConnect.UseVisualStyleBackColor = true;
            btnMBoxConnect.Click += btnMBoxConnect_Click;
            // 
            // btnZero
            // 
            btnZero.Enabled = false;
            btnZero.Location = new Point(326, 124);
            btnZero.Name = "btnZero";
            btnZero.Size = new Size(75, 23);
            btnZero.TabIndex = 15;
            btnZero.Text = "Go to Zero";
            btnZero.UseVisualStyleBackColor = true;
            btnZero.Click += btnZero_Click;
            // 
            // btnSetZero
            // 
            btnSetZero.Location = new Point(326, 153);
            btnSetZero.Name = "btnSetZero";
            btnSetZero.Size = new Size(75, 23);
            btnSetZero.TabIndex = 16;
            btnSetZero.Text = "Set as Zero";
            btnSetZero.UseVisualStyleBackColor = true;
            btnSetZero.Click += btnSetZero_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSetZero);
            Controls.Add(btnZero);
            Controls.Add(btnMBoxConnect);
            Controls.Add(lblTargetY);
            Controls.Add(lblTargetX);
            Controls.Add(btnJoy3);
            Controls.Add(btnJoy2);
            Controls.Add(btnJoy1);
            Controls.Add(btnJoy0);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(btnJoystickInit);
            Controls.Add(inputMBoxMode);
            Controls.Add(label2);
            Controls.Add(inputMBoxIP);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Syntron MBox Tools 0.1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox inputMBoxIP;
        private Label label2;
        private ComboBox inputMBoxMode;
        private Button btnJoystickInit;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button btnJoy0;
        private Button btnJoy1;
        private Button btnJoy2;
        private Button btnJoy3;
        private Label lblTargetX;
        private Label lblTargetY;
        private Button btnMBoxConnect;
        private Button btnZero;
        private Button btnSetZero;
    }
}
