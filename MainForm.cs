using System;
using System.Windows.Forms;
using Microsoft.Extensions.Logging;

namespace MBOX
{
    public partial class MainForm : Form
    {
        // Configuration fields
        private double _screwStroke = 50.0;
        private double _screwLead = 5.0;
        private int _pulsesPerRev = 10000;
        private ushort _acceptIPGroup = 255;
        private ushort _acceptIPNode = 255;
        private ushort _replyIPGroup = 255;
        private ushort _replyIPNode = 255;
        private int _hostTxPort = 8410;
        private int _hostRxPort = 8409;
        private int _mboxTxPort = 7409;
        private int _mboxRxPort = 7408;


        // Sine wave parameters
        private double _sinePeak = 50.0;
        private double _sineFrequency = 1.0;
        private double _samplingPeriod = 0.01;

        // Sine wave state
        private int _sineSequenceNumber = 0;

        // UDP client
        private readonly MboxUdpClient _udpClient = new MboxUdpClient();

        public MainForm()
        {
			        using var loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddConsole()  // Add console logging
                   .SetMinimumLevel(LogLevel.Debug);  // Set log level to Debug (shows Debug, Information, Warning, Error, Critical)
        });

        // Create a logger instance for the "Program" category
        var logger = loggerFactory.CreateLogger("Program");

        // Log some messages
        logger.LogTrace("This is a Trace log.");
        logger.LogDebug("This is a Debug log.");
        logger.LogInformation("Hello, this is an Information log!");
        logger.LogWarning("This is a Warning log.");
        logger.LogError("This is an Error log.");
        logger.LogCritical("This is a Critical log.");
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Initialize default values (already set in Designer, but ensure they're loaded into variables)


            UpdateConfigurationFromUI();
        }

        private void UpdateConfigurationFromUI()
        {
            // Update all configuration values from textboxes
            if (double.TryParse(txtScrewStroke.Text, out double screwStroke))
                _screwStroke = screwStroke;

            if (double.TryParse(txtScrewLead.Text, out double screwLead))
                _screwLead = screwLead;

            if (int.TryParse(txtPulsesPerRev.Text, out int pulsesPerRev))
                _pulsesPerRev = pulsesPerRev;

            if (ushort.TryParse(txtAcceptIPGroup.Text, out ushort acceptIPGroup))
                _acceptIPGroup = acceptIPGroup;

            if (ushort.TryParse(txtAcceptIPNode.Text, out ushort acceptIPNode))
                _acceptIPNode = acceptIPNode;

            if (ushort.TryParse(txtReplyIPGroup.Text, out ushort replyIPGroup))
                _replyIPGroup = replyIPGroup;

            if (ushort.TryParse(txtReplyIPNode.Text, out ushort replyIPNode))
                _replyIPNode = replyIPNode;

            if (int.TryParse(txtHostTxPort.Text, out int hostTxPort))
                _hostTxPort = hostTxPort;

            if (int.TryParse(txtHostRxPort.Text, out int hostRxPort))
                _hostRxPort = hostRxPort;

            if (int.TryParse(txtMboxTxPort.Text, out int mboxTxPort))
                _mboxTxPort = mboxTxPort;

            if (int.TryParse(txtMboxRxPort.Text, out int mboxRxPort))
                _mboxRxPort = mboxRxPort;

            if (double.TryParse(txtSinePeak.Text, out double sinePeak))
                _sinePeak = sinePeak;

            if (double.TryParse(txtSineFrequency.Text, out double sineFrequency))
                _sineFrequency = sineFrequency;

            if (double.TryParse(txtSamplingPeriod.Text, out double samplingPeriod))
                _samplingPeriod = samplingPeriod;
        }

        /// <summary>
        /// Calculate pulses from distance in millimeters
        /// </summary>
        private int CalculatePulses(double distanceMm)
        {
            return (int)(distanceMm / _screwLead * _pulsesPerRev);
        }

        /// <summary>
        /// Initialize UDP connection and send position command
        /// </summary>
        private void SendPositionCommand(int xPulse, int yPulse, int zPulse, int uPulse, int vPulse, int wPulse, FunctionCode functionCode = FunctionCode.BroadcastCommand, int playLine = 0, int playTime = 0)
        {
            try
            {
                ValidateConfiguration();
				Console.WriteLine("Validation OK");
                // Initialize UDP client
                _udpClient.Initialize(_hostTxPort, "255.255.255.255", _mboxRxPort);

                // Build WhoAccept code from IP group and node
                ushort whoAccept = (ushort)((_acceptIPGroup << 8) | _acceptIPNode);

                // Build WhoReply code from IP group and node
                ushort whoReply = (ushort)((_replyIPGroup << 8) | _replyIPNode);

                // Create packet
                var packet = new MboxPacket
                {
                    FunctionCode = functionCode,
                    WhoAccept = whoAccept,
                    WhoReply = whoReply,
                    PlayLine = playLine,
                    PlayTime = playTime,
                    XPosition = xPulse,
                    YPosition = yPulse,
                    ZPosition = zPulse,
                    UPosition = uPulse,
                    VPosition = vPulse,
                    WPosition = wPulse
                };

                // Send packet
                byte[] data = packet.ToByteArray();
                _udpClient.SendPacket(data);

                // Close connection (matching VB6 behavior)
                if (functionCode == FunctionCode.BroadcastCommand)
                {
                    _udpClient.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"发送命令失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ValidateConfiguration()
        {
            if (_screwStroke <= 0)
                throw new ArgumentException("丝杠行程必须大于0");

            if (_screwLead <= 0)
                throw new ArgumentException("丝杠导程必须大于0");

            if (_pulsesPerRev <= 0)
                throw new ArgumentException("每圈脉冲数必须大于0");

            if (_hostTxPort < 1024 || _hostTxPort > 65535)
                throw new ArgumentException("主机发送端口必须在1024-65535之间");

            if (_mboxRxPort < 1024 || _mboxRxPort > 65535)
                throw new ArgumentException("MBOX接收端口必须在1024-65535之间");
        }

        // Button event handlers

        private void btnGoToMax_Click(object sender, EventArgs e)
        {
            UpdateConfigurationFromUI();

            // Calculate pulses for maximum position (full stroke)
            int pulses = CalculatePulses(_screwStroke);

            // Send command to all 6 axes
            // Up/Down, Rotate, NA, NA, NA, NA
            SendPositionCommand(pulses*2, pulses, pulses, pulses, pulses, pulses);
            //SendPositionCommand(pulses, 0, 0, 0, 0, 0);
        }

        private void btnGoToMiddle_Click(object sender, EventArgs e)
        {
            UpdateConfigurationFromUI();

            // Calculate pulses for middle position (half stroke)
            int pulses = CalculatePulses(_screwStroke / 2);

            // Send command to all 6 axes
            SendPositionCommand(pulses*2, pulses, pulses, pulses, pulses, pulses);
            //SendPositionCommand(pulses, 0, 0, 0, 0, 0);
        }

        private void btnGoToZero_Click(object sender, EventArgs e)
        {
            UpdateConfigurationFromUI();

            // Send command to move all axes to zero position
            SendPositionCommand(0, 0, 0, 0, 0, 0);
        }

        private void btnSineStart_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateConfigurationFromUI();
                ValidateConfiguration();

                // Initialize UDP client
                _udpClient.Initialize(_hostTxPort, "192.168.233.201", _mboxRxPort);

                // Reset sequence number
                _sineSequenceNumber = 0;

                // Set timer interval (convert seconds to milliseconds)
                sineWaveTimer.Interval = (int)(_samplingPeriod * 1000);

                // Start timer
                sineWaveTimer.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"启动正弦运动失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSineStop_Click(object sender, EventArgs e)
        {
            // Stop timer
            sineWaveTimer.Enabled = false;

            // Close UDP connection
            _udpClient.Close();

            // Reset sequence number
            _sineSequenceNumber = 0;
        }

        private void sineWaveTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                _sineSequenceNumber++;

                // Calculate time in seconds
                double t = _sineSequenceNumber * _samplingPeriod;

                // Calculate sine wave position
                // Formula: distance = Peak/2 + (Peak/2) * sin(2π * frequency * t)
                double distance = _sinePeak / 2 + (_sinePeak / 2) * Math.Sin(2 * Math.PI * _sineFrequency * t);

                // Calculate pulses for the sine position
                // Note: VB6 code divides by 2 at the end, replicating that behavior
                int pulses = (int)(distance / _screwLead * _pulsesPerRev / 2);

                // Build WhoAccept and WhoReply codes
                ushort whoAccept = (ushort)((_acceptIPGroup << 8) | _acceptIPNode);
                ushort whoReply = (ushort)((_replyIPGroup << 8) | _replyIPNode);

                // Create timed packet
                var packet = new MboxPacket
                {
                    FunctionCode = FunctionCode.TimedBroadcast,  // 0x1401 for timed
                    WhoAccept = whoAccept,
                    WhoReply = whoReply,
                    PlayLine = _sineSequenceNumber,
                    PlayTime = sineWaveTimer.Interval,  // Time in milliseconds
                    XPosition = pulses,
                    YPosition = pulses,
                    ZPosition = pulses,
                    UPosition = pulses,
                    VPosition = pulses,
                    WPosition = pulses
                };

                // Send packet
                byte[] data = packet.ToByteArray();
                _udpClient.SendPacket(data);
            }
            catch (Exception ex)
            {
                sineWaveTimer.Enabled = false;
                _udpClient.Close();
                MessageBox.Show($"正弦运动错误: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Input validation event handlers

        private void FloatTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow control keys (backspace, etc.)
            if (char.IsControl(e.KeyChar))
                return;

            // Allow decimal point only if not already present
            TextBox? textBox = sender as TextBox;
            if (e.KeyChar == '.' && textBox != null && !textBox.Text.Contains('.'))
                return;

            // Allow digits
            if (char.IsDigit(e.KeyChar))
                return;

            // Block everything else
            e.Handled = true;
        }

        private void IntegerTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow control keys (backspace, etc.)
            if (char.IsControl(e.KeyChar))
                return;

            // Allow digits only
            if (char.IsDigit(e.KeyChar))
                return;

            // Block everything else
            e.Handled = true;
        }

        // TextChanged event handlers to update internal variables

        private void txtScrewStroke_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(txtScrewStroke.Text, out double value))
                _screwStroke = value;
        }

        private void txtScrewLead_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(txtScrewLead.Text, out double value))
                _screwLead = value;
        }

        private void txtPulsesPerRev_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(txtPulsesPerRev.Text, out int value))
                _pulsesPerRev = value;
        }

        private void txtAcceptIPGroup_TextChanged(object sender, EventArgs e)
        {
            if (ushort.TryParse(txtAcceptIPGroup.Text, out ushort value))
                _acceptIPGroup = value;
        }

        private void txtAcceptIPNode_TextChanged(object sender, EventArgs e)
        {
            if (ushort.TryParse(txtAcceptIPNode.Text, out ushort value))
                _acceptIPNode = value;
        }

        private void txtReplyIPGroup_TextChanged(object sender, EventArgs e)
        {
            if (ushort.TryParse(txtReplyIPGroup.Text, out ushort value))
                _replyIPGroup = value;
        }

        private void txtReplyIPNode_TextChanged(object sender, EventArgs e)
        {
            if (ushort.TryParse(txtReplyIPNode.Text, out ushort value))
                _replyIPNode = value;
        }

        private void txtHostTxPort_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(txtHostTxPort.Text, out int value))
                _hostTxPort = value;
        }

        private void txtHostRxPort_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(txtHostRxPort.Text, out int value))
                _hostRxPort = value;
        }

        private void txtMboxTxPort_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(txtMboxTxPort.Text, out int value))
                _mboxTxPort = value;
        }

        private void txtMboxRxPort_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(txtMboxRxPort.Text, out int value))
                _mboxRxPort = value;
        }

        private void txtSinePeak_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(txtSinePeak.Text, out double value))
                _sinePeak = value;
        }

        private void txtSineFrequency_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(txtSineFrequency.Text, out double value))
                _sineFrequency = value;
        }

        private void txtSamplingPeriod_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(txtSamplingPeriod.Text, out double value))
                _samplingPeriod = value;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                components?.Dispose();
                _udpClient?.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
