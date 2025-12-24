namespace MBOX
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            // TextBoxes for configuration
            this.txtScrewStroke = new System.Windows.Forms.TextBox();
            this.txtScrewLead = new System.Windows.Forms.TextBox();
            this.txtPulsesPerRev = new System.Windows.Forms.TextBox();
            this.txtAcceptIPGroup = new System.Windows.Forms.TextBox();
            this.txtAcceptIPNode = new System.Windows.Forms.TextBox();
            this.txtReplyIPGroup = new System.Windows.Forms.TextBox();
            this.txtReplyIPNode = new System.Windows.Forms.TextBox();
            this.txtHostTxPort = new System.Windows.Forms.TextBox();
            this.txtHostRxPort = new System.Windows.Forms.TextBox();
            this.txtMboxTxPort = new System.Windows.Forms.TextBox();
            this.txtMboxRxPort = new System.Windows.Forms.TextBox();
            this.txtSinePeak = new System.Windows.Forms.TextBox();
            this.txtSineFrequency = new System.Windows.Forms.TextBox();
            this.txtSamplingPeriod = new System.Windows.Forms.TextBox();

            // Buttons
            this.btnGoToMax = new System.Windows.Forms.Button();
            this.btnGoToMiddle = new System.Windows.Forms.Button();
            this.btnGoToZero = new System.Windows.Forms.Button();
            this.btnSineStart = new System.Windows.Forms.Button();
            this.btnSineStop = new System.Windows.Forms.Button();

            // Labels
            this.lblScrewParams = new System.Windows.Forms.Label();
            this.lblScrewStroke = new System.Windows.Forms.Label();
            this.lblScrewLead = new System.Windows.Forms.Label();
            this.lblPulsesPerRev = new System.Windows.Forms.Label();
            this.lblNetworkConfig = new System.Windows.Forms.Label();
            this.lblAcceptIP = new System.Windows.Forms.Label();
            this.lblReplyIP = new System.Windows.Forms.Label();
            this.lblHostPorts = new System.Windows.Forms.Label();
            this.lblMboxPorts = new System.Windows.Forms.Label();
            this.lblMotionControl = new System.Windows.Forms.Label();
            this.lblSineWaveParams = new System.Windows.Forms.Label();
            this.lblSinePeak = new System.Windows.Forms.Label();
            this.lblSineFrequency = new System.Windows.Forms.Label();
            this.lblSamplingPeriod = new System.Windows.Forms.Label();
            this.lblMmUnit1 = new System.Windows.Forms.Label();
            this.lblMmUnit2 = new System.Windows.Forms.Label();
            this.lblMmUnit3 = new System.Windows.Forms.Label();
            this.lblHzUnit = new System.Windows.Forms.Label();
            this.lblSecUnit = new System.Windows.Forms.Label();
            this.lblIPDot1 = new System.Windows.Forms.Label();
            this.lblIPDot2 = new System.Windows.Forms.Label();

            // Timer
            this.sineWaveTimer = new System.Windows.Forms.Timer(this.components);

            this.SuspendLayout();

            //
            // txtScrewStroke
            //
            this.txtScrewStroke.Location = new System.Drawing.Point(150, 50);
            this.txtScrewStroke.Name = "txtScrewStroke";
            this.txtScrewStroke.Size = new System.Drawing.Size(100, 23);
            this.txtScrewStroke.TabIndex = 0;
            this.txtScrewStroke.Text = "50";
            this.txtScrewStroke.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FloatTextBox_KeyPress);
            this.txtScrewStroke.TextChanged += new System.EventHandler(this.txtScrewStroke_TextChanged);

            //
            // txtScrewLead
            //
            this.txtScrewLead.Location = new System.Drawing.Point(150, 80);
            this.txtScrewLead.Name = "txtScrewLead";
            this.txtScrewLead.Size = new System.Drawing.Size(100, 23);
            this.txtScrewLead.TabIndex = 1;
            this.txtScrewLead.Text = "5";
            this.txtScrewLead.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FloatTextBox_KeyPress);
            this.txtScrewLead.TextChanged += new System.EventHandler(this.txtScrewLead_TextChanged);

            //
            // txtPulsesPerRev
            //
            this.txtPulsesPerRev.Location = new System.Drawing.Point(150, 110);
            this.txtPulsesPerRev.Name = "txtPulsesPerRev";
            this.txtPulsesPerRev.Size = new System.Drawing.Size(100, 23);
            this.txtPulsesPerRev.TabIndex = 2;
            this.txtPulsesPerRev.Text = "10000";
            this.txtPulsesPerRev.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IntegerTextBox_KeyPress);
            this.txtPulsesPerRev.TextChanged += new System.EventHandler(this.txtPulsesPerRev_TextChanged);

            //
            // txtAcceptIPGroup
            //
            this.txtAcceptIPGroup.Location = new System.Drawing.Point(150, 170);
            this.txtAcceptIPGroup.Name = "txtAcceptIPGroup";
            this.txtAcceptIPGroup.Size = new System.Drawing.Size(50, 23);
            this.txtAcceptIPGroup.TabIndex = 3;
            this.txtAcceptIPGroup.Text = "255";
            this.txtAcceptIPGroup.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IntegerTextBox_KeyPress);
            this.txtAcceptIPGroup.TextChanged += new System.EventHandler(this.txtAcceptIPGroup_TextChanged);

            //
            // txtAcceptIPNode
            //
            this.txtAcceptIPNode.Location = new System.Drawing.Point(220, 170);
            this.txtAcceptIPNode.Name = "txtAcceptIPNode";
            this.txtAcceptIPNode.Size = new System.Drawing.Size(50, 23);
            this.txtAcceptIPNode.TabIndex = 4;
            this.txtAcceptIPNode.Text = "255";
            this.txtAcceptIPNode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IntegerTextBox_KeyPress);
            this.txtAcceptIPNode.TextChanged += new System.EventHandler(this.txtAcceptIPNode_TextChanged);

            //
            // txtReplyIPGroup
            //
            this.txtReplyIPGroup.Location = new System.Drawing.Point(150, 200);
            this.txtReplyIPGroup.Name = "txtReplyIPGroup";
            this.txtReplyIPGroup.Size = new System.Drawing.Size(50, 23);
            this.txtReplyIPGroup.TabIndex = 5;
            this.txtReplyIPGroup.Text = "255";
            this.txtReplyIPGroup.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IntegerTextBox_KeyPress);
            this.txtReplyIPGroup.TextChanged += new System.EventHandler(this.txtReplyIPGroup_TextChanged);

            //
            // txtReplyIPNode
            //
            this.txtReplyIPNode.Location = new System.Drawing.Point(220, 200);
            this.txtReplyIPNode.Name = "txtReplyIPNode";
            this.txtReplyIPNode.Size = new System.Drawing.Size(50, 23);
            this.txtReplyIPNode.TabIndex = 6;
            this.txtReplyIPNode.Text = "255";
            this.txtReplyIPNode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IntegerTextBox_KeyPress);
            this.txtReplyIPNode.TextChanged += new System.EventHandler(this.txtReplyIPNode_TextChanged);

            //
            // txtHostTxPort
            //
            this.txtHostTxPort.Location = new System.Drawing.Point(150, 260);
            this.txtHostTxPort.Name = "txtHostTxPort";
            this.txtHostTxPort.Size = new System.Drawing.Size(100, 23);
            this.txtHostTxPort.TabIndex = 7;
            this.txtHostTxPort.Text = "8410";
            this.txtHostTxPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IntegerTextBox_KeyPress);
            this.txtHostTxPort.TextChanged += new System.EventHandler(this.txtHostTxPort_TextChanged);

            //
            // txtHostRxPort
            //
            this.txtHostRxPort.Location = new System.Drawing.Point(150, 290);
            this.txtHostRxPort.Name = "txtHostRxPort";
            this.txtHostRxPort.Size = new System.Drawing.Size(100, 23);
            this.txtHostRxPort.TabIndex = 8;
            this.txtHostRxPort.Text = "8409";
            this.txtHostRxPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IntegerTextBox_KeyPress);
            this.txtHostRxPort.TextChanged += new System.EventHandler(this.txtHostRxPort_TextChanged);

            //
            // txtMboxTxPort
            //
            this.txtMboxTxPort.Location = new System.Drawing.Point(150, 320);
            this.txtMboxTxPort.Name = "txtMboxTxPort";
            this.txtMboxTxPort.Size = new System.Drawing.Size(100, 23);
            this.txtMboxTxPort.TabIndex = 9;
            this.txtMboxTxPort.Text = "7409";
            this.txtMboxTxPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IntegerTextBox_KeyPress);
            this.txtMboxTxPort.TextChanged += new System.EventHandler(this.txtMboxTxPort_TextChanged);

            //
            // txtMboxRxPort
            //
            this.txtMboxRxPort.Location = new System.Drawing.Point(150, 350);
            this.txtMboxRxPort.Name = "txtMboxRxPort";
            this.txtMboxRxPort.Size = new System.Drawing.Size(100, 23);
            this.txtMboxRxPort.TabIndex = 10;
            this.txtMboxRxPort.Text = "7408";
            this.txtMboxRxPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IntegerTextBox_KeyPress);
            this.txtMboxRxPort.TextChanged += new System.EventHandler(this.txtMboxRxPort_TextChanged);

            //
            // txtSinePeak
            //
            this.txtSinePeak.Location = new System.Drawing.Point(500, 80);
            this.txtSinePeak.Name = "txtSinePeak";
            this.txtSinePeak.Size = new System.Drawing.Size(100, 23);
            this.txtSinePeak.TabIndex = 11;
            this.txtSinePeak.Text = "50";
            this.txtSinePeak.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FloatTextBox_KeyPress);
            this.txtSinePeak.TextChanged += new System.EventHandler(this.txtSinePeak_TextChanged);

            //
            // txtSineFrequency
            //
            this.txtSineFrequency.Location = new System.Drawing.Point(500, 110);
            this.txtSineFrequency.Name = "txtSineFrequency";
            this.txtSineFrequency.Size = new System.Drawing.Size(100, 23);
            this.txtSineFrequency.TabIndex = 12;
            this.txtSineFrequency.Text = "1";
            this.txtSineFrequency.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FloatTextBox_KeyPress);
            this.txtSineFrequency.TextChanged += new System.EventHandler(this.txtSineFrequency_TextChanged);

            //
            // txtSamplingPeriod
            //
            this.txtSamplingPeriod.Location = new System.Drawing.Point(500, 140);
            this.txtSamplingPeriod.Name = "txtSamplingPeriod";
            this.txtSamplingPeriod.Size = new System.Drawing.Size(100, 23);
            this.txtSamplingPeriod.TabIndex = 13;
            this.txtSamplingPeriod.Text = "0.01";
            this.txtSamplingPeriod.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FloatTextBox_KeyPress);
            this.txtSamplingPeriod.TextChanged += new System.EventHandler(this.txtSamplingPeriod_TextChanged);

            //
            // btnGoToMax
            //
            this.btnGoToMax.Location = new System.Drawing.Point(400, 250);
            this.btnGoToMax.Name = "btnGoToMax";
            this.btnGoToMax.Size = new System.Drawing.Size(150, 35);
            this.btnGoToMax.TabIndex = 14;
            this.btnGoToMax.Text = "Move to Max";
            this.btnGoToMax.UseVisualStyleBackColor = true;
            this.btnGoToMax.Click += new System.EventHandler(this.btnGoToMax_Click);

            //
            // btnGoToMiddle
            //
            this.btnGoToMiddle.Location = new System.Drawing.Point(400, 295);
            this.btnGoToMiddle.Name = "btnGoToMiddle";
            this.btnGoToMiddle.Size = new System.Drawing.Size(150, 35);
            this.btnGoToMiddle.TabIndex = 15;
            this.btnGoToMiddle.Text = "Move Center";
            this.btnGoToMiddle.UseVisualStyleBackColor = true;
            this.btnGoToMiddle.Click += new System.EventHandler(this.btnGoToMiddle_Click);

            //
            // btnGoToZero
            //
            this.btnGoToZero.Location = new System.Drawing.Point(400, 340);
            this.btnGoToZero.Name = "btnGoToZero";
            this.btnGoToZero.Size = new System.Drawing.Size(150, 35);
            this.btnGoToZero.TabIndex = 16;
            this.btnGoToZero.Text = "Move Zero";
            this.btnGoToZero.UseVisualStyleBackColor = true;
            this.btnGoToZero.Click += new System.EventHandler(this.btnGoToZero_Click);

            //
            // btnSineStart
            //
            this.btnSineStart.Location = new System.Drawing.Point(580, 250);
            this.btnSineStart.Name = "btnSineStart";
            this.btnSineStart.Size = new System.Drawing.Size(150, 35);
            this.btnSineStart.TabIndex = 17;
            this.btnSineStart.Text = "Start SIN motion";
            this.btnSineStart.UseVisualStyleBackColor = true;
            this.btnSineStart.Click += new System.EventHandler(this.btnSineStart_Click);

            //
            // btnSineStop
            //
            this.btnSineStop.Location = new System.Drawing.Point(580, 295);
            this.btnSineStop.Name = "btnSineStop";
            this.btnSineStop.Size = new System.Drawing.Size(150, 35);
            this.btnSineStop.TabIndex = 18;
            this.btnSineStop.Text = "Stop SIN motion";
            this.btnSineStop.UseVisualStyleBackColor = true;
            this.btnSineStop.Click += new System.EventHandler(this.btnSineStop_Click);

            //
            // Labels
            //
            this.lblScrewParams.AutoSize = true;
            this.lblScrewParams.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblScrewParams.Location = new System.Drawing.Point(20, 20);
            this.lblScrewParams.Name = "lblScrewParams";
            this.lblScrewParams.Size = new System.Drawing.Size(100, 15);
            this.lblScrewParams.TabIndex = 19;
            this.lblScrewParams.Text = "WormScrew Params";

            this.lblScrewStroke.AutoSize = true;
            this.lblScrewStroke.Location = new System.Drawing.Point(20, 53);
            this.lblScrewStroke.Name = "lblScrewStroke";
            this.lblScrewStroke.Size = new System.Drawing.Size(120, 15);
            this.lblScrewStroke.TabIndex = 20;
            this.lblScrewStroke.Text = "WS Travel (mm):";

            this.lblScrewLead.AutoSize = true;
            this.lblScrewLead.Location = new System.Drawing.Point(20, 83);
            this.lblScrewLead.Name = "lblScrewLead";
            this.lblScrewLead.Size = new System.Drawing.Size(120, 15);
            this.lblScrewLead.TabIndex = 21;
            this.lblScrewLead.Text = "WS Lead (mm):";

            this.lblPulsesPerRev.AutoSize = true;
            this.lblPulsesPerRev.Location = new System.Drawing.Point(20, 113);
            this.lblPulsesPerRev.Name = "lblPulsesPerRev";
            this.lblPulsesPerRev.Size = new System.Drawing.Size(120, 15);
            this.lblPulsesPerRev.TabIndex = 22;
            this.lblPulsesPerRev.Text = "Pulses pR:";

            this.lblNetworkConfig.AutoSize = true;
            this.lblNetworkConfig.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblNetworkConfig.Location = new System.Drawing.Point(20, 145);
            this.lblNetworkConfig.Name = "lblNetworkConfig";
            this.lblNetworkConfig.Size = new System.Drawing.Size(100, 15);
            this.lblNetworkConfig.TabIndex = 23;
            this.lblNetworkConfig.Text = "NetConfig";

            this.lblAcceptIP.AutoSize = true;
            this.lblAcceptIP.Location = new System.Drawing.Point(20, 173);
            this.lblAcceptIP.Name = "lblAcceptIP";
            this.lblAcceptIP.Size = new System.Drawing.Size(120, 15);
            this.lblAcceptIP.TabIndex = 24;
            this.lblAcceptIP.Text = "ReceiveIP (Node):";

            this.lblReplyIP.AutoSize = true;
            this.lblReplyIP.Location = new System.Drawing.Point(20, 203);
            this.lblReplyIP.Name = "lblReplyIP";
            this.lblReplyIP.Size = new System.Drawing.Size(120, 15);
            this.lblReplyIP.TabIndex = 25;
            this.lblReplyIP.Text = "RespIP (Node):";

            this.lblHostPorts.AutoSize = true;
            this.lblHostPorts.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblHostPorts.Location = new System.Drawing.Point(20, 235);
            this.lblHostPorts.Name = "lblHostPorts";
            this.lblHostPorts.Size = new System.Drawing.Size(100, 15);
            this.lblHostPorts.TabIndex = 26;
            this.lblHostPorts.Text = "HostPorts";

            this.lblMboxPorts.AutoSize = true;
            this.lblMboxPorts.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblMboxPorts.Location = new System.Drawing.Point(20, 263);
            this.lblMboxPorts.Name = "lblMboxPorts";
            this.lblMboxPorts.Size = new System.Drawing.Size(100, 13);
            this.lblMboxPorts.TabIndex = 27;
            this.lblMboxPorts.Text = "MboxPorts:";

            this.lblMotionControl.AutoSize = true;
            this.lblMotionControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblMotionControl.Location = new System.Drawing.Point(400, 20);
            this.lblMotionControl.Name = "lblMotionControl";
            this.lblMotionControl.Size = new System.Drawing.Size(100, 15);
            this.lblMotionControl.TabIndex = 28;
            this.lblMotionControl.Text = "MotionControl";

            this.lblSineWaveParams.AutoSize = true;
            this.lblSineWaveParams.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblSineWaveParams.Location = new System.Drawing.Point(400, 50);
            this.lblSineWaveParams.Name = "lblSineWaveParams";
            this.lblSineWaveParams.Size = new System.Drawing.Size(100, 15);
            this.lblSineWaveParams.TabIndex = 29;
            this.lblSineWaveParams.Text = "SineWaveParams";

            this.lblSinePeak.AutoSize = true;
            this.lblSinePeak.Location = new System.Drawing.Point(400, 83);
            this.lblSinePeak.Name = "lblSinePeak";
            this.lblSinePeak.Size = new System.Drawing.Size(90, 15);
            this.lblSinePeak.TabIndex = 30;
            this.lblSinePeak.Text = "SinePeak (mm):";

            this.lblSineFrequency.AutoSize = true;
            this.lblSineFrequency.Location = new System.Drawing.Point(400, 113);
            this.lblSineFrequency.Name = "lblSineFrequency";
            this.lblSineFrequency.Size = new System.Drawing.Size(90, 15);
            this.lblSineFrequency.TabIndex = 31;
            this.lblSineFrequency.Text = "SineFreq (Hz):";

            this.lblSamplingPeriod.AutoSize = true;
            this.lblSamplingPeriod.Location = new System.Drawing.Point(400, 143);
            this.lblSamplingPeriod.Name = "lblSamplingPeriod";
            this.lblSamplingPeriod.Size = new System.Drawing.Size(90, 15);
            this.lblSamplingPeriod.TabIndex = 32;
            this.lblSamplingPeriod.Text = "SamplingPeriod (s):";

            this.lblIPDot1.AutoSize = true;
            this.lblIPDot1.Location = new System.Drawing.Point(205, 173);
            this.lblIPDot1.Name = "lblIPDot1";
            this.lblIPDot1.Size = new System.Drawing.Size(10, 15);
            this.lblIPDot1.TabIndex = 33;
            this.lblIPDot1.Text = ".";

            this.lblIPDot2.AutoSize = true;
            this.lblIPDot2.Location = new System.Drawing.Point(205, 203);
            this.lblIPDot2.Name = "lblIPDot2";
            this.lblIPDot2.Size = new System.Drawing.Size(10, 15);
            this.lblIPDot2.TabIndex = 34;
            this.lblIPDot2.Text = ".";

            // Additional port labels
            var lblHostRxPort = new System.Windows.Forms.Label();
            lblHostRxPort.AutoSize = true;
            lblHostRxPort.Location = new System.Drawing.Point(20, 293);
            lblHostRxPort.Name = "lblHostRxPort";
            lblHostRxPort.Size = new System.Drawing.Size(100, 13);
            lblHostRxPort.Text = "HostRxPort";

            var lblMboxTxPort = new System.Windows.Forms.Label();
            lblMboxTxPort.AutoSize = true;
            lblMboxTxPort.Location = new System.Drawing.Point(20, 323);
            lblMboxTxPort.Name = "lblMboxTxPort";
            lblMboxTxPort.Size = new System.Drawing.Size(120, 13);
            lblMboxTxPort.Text = "MboxTxPort:";

            var lblMboxRxPort = new System.Windows.Forms.Label();
            lblMboxRxPort.AutoSize = true;
            lblMboxRxPort.Location = new System.Drawing.Point(20, 353);
            lblMboxRxPort.Name = "lblMboxRxPort";
            lblMboxRxPort.Size = new System.Drawing.Size(120, 13);
            lblMboxRxPort.Text = "MboxRxport:";

            //
            // sineWaveTimer
            //
            this.sineWaveTimer.Tick += new System.EventHandler(this.sineWaveTimer_Tick);

            //
            // MainForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(192, 255, 255);
            this.ClientSize = new System.Drawing.Size(780, 420);
            this.Controls.Add(this.txtScrewStroke);
            this.Controls.Add(this.txtScrewLead);
            this.Controls.Add(this.txtPulsesPerRev);
            this.Controls.Add(this.txtAcceptIPGroup);
            this.Controls.Add(this.txtAcceptIPNode);
            this.Controls.Add(this.txtReplyIPGroup);
            this.Controls.Add(this.txtReplyIPNode);
            this.Controls.Add(this.txtHostTxPort);
            this.Controls.Add(this.txtHostRxPort);
            this.Controls.Add(this.txtMboxTxPort);
            this.Controls.Add(this.txtMboxRxPort);
            this.Controls.Add(this.txtSinePeak);
            this.Controls.Add(this.txtSineFrequency);
            this.Controls.Add(this.txtSamplingPeriod);
            this.Controls.Add(this.btnGoToMax);
            this.Controls.Add(this.btnGoToMiddle);
            this.Controls.Add(this.btnGoToZero);
            this.Controls.Add(this.btnSineStart);
            this.Controls.Add(this.btnSineStop);
            this.Controls.Add(this.lblScrewParams);
            this.Controls.Add(this.lblScrewStroke);
            this.Controls.Add(this.lblScrewLead);
            this.Controls.Add(this.lblPulsesPerRev);
            this.Controls.Add(this.lblNetworkConfig);
            this.Controls.Add(this.lblAcceptIP);
            this.Controls.Add(this.lblReplyIP);
            this.Controls.Add(this.lblHostPorts);
            this.Controls.Add(this.lblMboxPorts);
            this.Controls.Add(this.lblMotionControl);
            this.Controls.Add(this.lblSineWaveParams);
            this.Controls.Add(this.lblSinePeak);
            this.Controls.Add(this.lblSineFrequency);
            this.Controls.Add(this.lblSamplingPeriod);
            this.Controls.Add(this.lblIPDot1);
            this.Controls.Add(this.lblIPDot2);
            this.Controls.Add(lblHostRxPort);
            this.Controls.Add(lblMboxTxPort);
            this.Controls.Add(lblMboxRxPort);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MBOX Control";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox txtScrewStroke;
        private System.Windows.Forms.TextBox txtScrewLead;
        private System.Windows.Forms.TextBox txtPulsesPerRev;
        private System.Windows.Forms.TextBox txtAcceptIPGroup;
        private System.Windows.Forms.TextBox txtAcceptIPNode;
        private System.Windows.Forms.TextBox txtReplyIPGroup;
        private System.Windows.Forms.TextBox txtReplyIPNode;
        private System.Windows.Forms.TextBox txtHostTxPort;
        private System.Windows.Forms.TextBox txtHostRxPort;
        private System.Windows.Forms.TextBox txtMboxTxPort;
        private System.Windows.Forms.TextBox txtMboxRxPort;
        private System.Windows.Forms.TextBox txtSinePeak;
        private System.Windows.Forms.TextBox txtSineFrequency;
        private System.Windows.Forms.TextBox txtSamplingPeriod;
        private System.Windows.Forms.Button btnGoToMax;
        private System.Windows.Forms.Button btnGoToMiddle;
        private System.Windows.Forms.Button btnGoToZero;
        private System.Windows.Forms.Button btnSineStart;
        private System.Windows.Forms.Button btnSineStop;
        private System.Windows.Forms.Label lblScrewParams;
        private System.Windows.Forms.Label lblScrewStroke;
        private System.Windows.Forms.Label lblScrewLead;
        private System.Windows.Forms.Label lblPulsesPerRev;
        private System.Windows.Forms.Label lblNetworkConfig;
        private System.Windows.Forms.Label lblAcceptIP;
        private System.Windows.Forms.Label lblReplyIP;
        private System.Windows.Forms.Label lblHostPorts;
        private System.Windows.Forms.Label lblMboxPorts;
        private System.Windows.Forms.Label lblMotionControl;
        private System.Windows.Forms.Label lblSineWaveParams;
        private System.Windows.Forms.Label lblSinePeak;
        private System.Windows.Forms.Label lblSineFrequency;
        private System.Windows.Forms.Label lblSamplingPeriod;
        private System.Windows.Forms.Label lblMmUnit1;
        private System.Windows.Forms.Label lblMmUnit2;
        private System.Windows.Forms.Label lblMmUnit3;
        private System.Windows.Forms.Label lblHzUnit;
        private System.Windows.Forms.Label lblSecUnit;
        private System.Windows.Forms.Label lblIPDot1;
        private System.Windows.Forms.Label lblIPDot2;
        private System.Windows.Forms.Timer sineWaveTimer;
    }
}
