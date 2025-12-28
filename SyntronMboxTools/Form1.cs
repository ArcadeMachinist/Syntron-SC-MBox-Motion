using SharpDX.DirectInput;
using System.Timers;
using System.Drawing;

namespace SyntronMboxTools
{
    public partial class Form1 : Form
    {
        private Joystick joystick;
        private System.Windows.Forms.Timer pollTimer;
        private float _angleDegrees = -1f;
        private Color _topHatColor = SystemColors.Control;
        private readonly AxisFilter _xFilter = new AxisFilter();
        private readonly AxisFilter _yFilter = new AxisFilter();

        private int _targetX, _sentX = 0;
        private int _targetY, _sentY = 0;

        private int _multiplierX = 7000;
        private int _multiplierY = 7000;

        private ushort _acceptIPGroup = 255;
        private ushort _acceptIPNode = 255;
        private ushort _replyIPGroup = 255;
        private ushort _replyIPNode = 255;

        private bool _mboxConnected = false;
        private String _mboxIP = "192.168.233.201";
        private int _hostTxPort = 8410;
        private int _hostRxPort = 8409;
        private int _mboxTxPort = 7409;
        private int _mboxRxPort = 7408;

        // UDP client
        private readonly MboxUdpClient _udpClient = new MboxUdpClient();

        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            int barWidth = 200;
            int barHeight = 20;

            // Horizontal bar for X, centered at 0
            DrawSignedBar(e.Graphics, new Rectangle(btnJoy0.Left, btnJoy0.Top + 40, barWidth, barHeight), _xFilter.Value);
            // Vertical bar for Y
            DrawSignedBar(e.Graphics, new Rectangle(btnJoy0.Left, btnJoy0.Top + 70, barWidth, barHeight), _yFilter.Value);

            // Example: center of form
            Point center = new Point(btnJoy0.Left + 170, btnJoy0.Top + 10);

            DrawCircleWithMarker(
                e.Graphics,
                center,
                outerDiameter: 50,
                innerDiameter: 10,
                angleDegrees: _angleDegrees);
            lblTargetX.Text = $"X Target: 0x{_targetX:X8}";
            lblTargetY.Text = $"Y Target: 0x{_targetY:X8}";
        }
        private void UpdateAxisTarget(ref int target, float value, int multiplier)
        {

            int step = (int)(multiplier * Math.Abs(value));

            if (value > 0)
            {
                target = unchecked(target + (int)step); // wraps at 0xFFFFFFFF
            }
            else
            {
                target = unchecked(target - (int)step); // wraps backwards
            }
        }
        private void DrawSignedBar(Graphics g, Rectangle rect, float value)
        {
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            g.DrawRectangle(Pens.Gray, rect);

            int halfWidth = rect.Width / 2;
            int centerX = rect.Left + halfWidth;

            // Draw center line
            g.DrawLine(Pens.LightGray, centerX, rect.Top, centerX, rect.Bottom);

            //label3.Text = value.ToString();

            int pixels = (int)(halfWidth * Math.Abs(value));

            Rectangle fill;
            if (value > 0)
                fill = new Rectangle(centerX, rect.Top, pixels, rect.Height);
            else
                fill = new Rectangle(centerX - pixels, rect.Top, pixels, rect.Height);

            using var brush = new SolidBrush(Color.Lime);
            g.FillRectangle(brush, fill);
        }
        private void DrawCircleWithMarker(Graphics g, Point center, int outerDiameter, int innerDiameter, float angleDegrees = -1)
        {
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            int outerRadius = outerDiameter / 2;
            int innerRadius = innerDiameter / 2;

            // Outer circle rectangle
            var outerRect = new Rectangle(
                center.X - outerRadius,
                center.Y - outerRadius,
                outerDiameter,
                outerDiameter);

            using (var whiteBrush = new SolidBrush(_topHatColor))
            using (var blackPen = new Pen(Color.Black, 2))
            using (var blackBrush = new SolidBrush(Color.Black))
            {
                // Fill + outline outer circle
                g.FillEllipse(whiteBrush, outerRect);
                g.DrawEllipse(blackPen, outerRect);

                // Convert angle to radians
                double radians = angleDegrees * Math.PI / 180.0;
                float markerCenterX;
                float markerCenterY;
                if (angleDegrees == -1)
                {
                    // Center marker
                    markerCenterX = center.X;
                    markerCenterY = center.Y;
                }
                else
                {
                    // Position of inner circle center on circumference
                    // Note: Y is inverted because screen coordinates increase downward
                    markerCenterX = center.X + (float)(outerRadius * Math.Sin(radians));
                    markerCenterY = center.Y - (float)(outerRadius * Math.Cos(radians));
                }
                // Inner circle rectangle
                var innerRect = new Rectangle(
                    (int)(markerCenterX - innerRadius),
                    (int)(markerCenterY - innerRadius),
                    innerDiameter,
                    innerDiameter);

                g.FillEllipse(blackBrush, innerRect);
            }
        }

        public void SetAngle(float degrees)
        {
            if (degrees == -1) _angleDegrees = -1;
            else
            {
                _angleDegrees = ((degrees / 100)) % 360f;
                if (_angleDegrees < 0) _angleDegrees += 360f;
            }
            Invalidate(); // triggers repaint
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            inputMBoxMode.Items.Add("3 Axis");
            inputMBoxMode.Items.Add("6 Axis");
            inputMBoxMode.Items.Add("10 Axis");

            inputMBoxMode.SelectedIndex = 0;
        }

        private void btnJoystickInit_Click(object sender, EventArgs e)
        {
            btnJoystickInit.Enabled = false;
            var directInput = new DirectInput();
            btnJoystickInit.Enabled = false;
            btnJoy0.BackColor = Color.White;
            btnJoy1.BackColor = Color.White;
            btnJoy2.BackColor = Color.White;
            btnJoy3.BackColor = Color.White;
            _topHatColor = Color.White;
            Invalidate();

            var joystickGuid = Guid.Empty;
            foreach (var deviceInstance in directInput.GetDevices(DeviceType.Joystick,
                DeviceEnumerationFlags.AllDevices))
                joystickGuid = deviceInstance.InstanceGuid;
            if (joystickGuid == Guid.Empty)
            {
                Environment.Exit(1);
            }
            label3.Text = joystickGuid.ToString();
            joystick = new Joystick(directInput, joystickGuid);
            // Query all suported ForceFeedback effects
            var allEffects = joystick.GetEffects();
            foreach (var effectInfo in allEffects)
                Console.WriteLine("Effect available {0}", effectInfo.Name);

            // Set BufferSize in order to use buffered data.
            joystick.Properties.BufferSize = 128;
            label3.Text = joystick.Properties.ProductName;
            // Acquire the joystick
            joystick.Acquire();
            pollTimer = new System.Windows.Forms.Timer();
            pollTimer.Tick += new EventHandler(OnTimedEvent);
            pollTimer.Interval = 50;
            pollTimer.Start();
            void OnTimedEvent(object sender, EventArgs e)
            {
                joystick.Poll();
                var datas = joystick.GetBufferedData();
                foreach (var state in datas)
                {
                    switch (state.Offset.ToString())
                    {
                        case "X":
                            label4.Text = state.Value.ToString();
                            _xFilter.Update((int)state.Value);

                            Invalidate();
                            break;
                        case "Y":
                            label5.Text = state.Value.ToString();
                            _yFilter.Update((int)state.Value);

                            Invalidate();
                            break;

                        case "Buttons0":
                            if (state.Value > 0) btnJoy0.BackColor = Color.Red; else btnJoy0.BackColor = Color.White;
                            break;
                        case "Buttons1":
                            if (state.Value > 0) btnJoy1.BackColor = Color.Red; else btnJoy1.BackColor = Color.White;
                            break;
                        case "Buttons2":
                            if (state.Value > 0) btnJoy2.BackColor = Color.Red; else btnJoy2.BackColor = Color.White;
                            break;
                        case "Buttons3":
                            if (state.Value > 0) btnJoy3.BackColor = Color.Red; else btnJoy3.BackColor = Color.White;
                            break;
                        case "PointOfViewControllers0":
                            SetAngle((int)state.Value);
                            break;
                        default:
                            label3.Text = state.ToString();
                            break;

                    }

                }
                UpdateAxisTarget(ref _targetX, _xFilter.Value, _multiplierX);
                UpdateAxisTarget(ref _targetY, _yFilter.Value, _multiplierY);
                if (_mboxConnected)
                {
                    if (_targetX != _sentX || _targetY != _sentY)
                    {
                        if (_targetY > 0x8ec00) _targetY = 0x8ec00;
                        if (_targetY < 0x0) _targetY = 0x0;
                        if (_targetX > 0xe6b00) _targetX = 0xe6b00;
                        if (_targetX < -0x0e6b00) _targetX = -0xe6b00;
                        SendPositionCommand(_targetY, _targetX, 0, 0, 0, 0);
                        _sentX = _targetX;
                        _sentY = _targetY;
                    }
                }
            }
        }

        private void SendPositionCommand(int xPulse, int yPulse, int zPulse, int uPulse, int vPulse, int wPulse, FunctionCode functionCode = FunctionCode.BroadcastCommand, int playLine = 0, int playTime = 0)
        {
            try
            {
                _udpClient.Initialize(_hostTxPort, _mboxIP, _mboxRxPort);

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
                MessageBox.Show($"Error: {ex.Message}", "Ooops", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnMBoxConnect_Click(object sender, EventArgs e)
        {
            _mboxConnected = true;
            btnMBoxConnect.Enabled = false;
            btnZero.Enabled = true;
        }

        private void btnZero_Click(object sender, EventArgs e)
        {
            if (_mboxConnected)
            {

                _sentX = _targetX = 0;
                _sentY = _targetY = 0;
                SendPositionCommand(_targetY, _targetX, 0, 0, 1000, 0);

            }
        }

        private void btnSetZero_Click(object sender, EventArgs e)
        {
            _sentX = _targetX = 0;
            _sentY = _targetY = 0;
        }
    }
}
