# MBOX Control System - C# .NET 6 Migration

This is a modern C# .NET 6+ Windows Forms application migrated from the original Visual Basic 6 project. It controls a 6-axis motion platform (MBOX) via UDP network communication.

## Requirements

- .NET 6.0 SDK or later
- Windows operating system
- Visual Studio 2022 or later (recommended) or VS Code with C# extension

## Project Structure

```
MBOX/
├── MBOX.csproj           - Project file
├── Program.cs            - Application entry point
├── MboxProtocol.cs       - UDP packet structure (50-byte protocol)
├── MboxUdpClient.cs      - UDP communication wrapper
├── MainForm.cs           - Main form with business logic
├── MainForm.Designer.cs  - Form UI designer code
└── README.md             - This file
```

## Building the Project

### Using Visual Studio

1. Open `MBOX.csproj` in Visual Studio 2022 or later
2. Press F5 to build and run, or Ctrl+Shift+B to build only
3. The executable will be in `bin/Debug/net6.0-windows/` or `bin/Release/net6.0-windows/`

### Using Command Line

```bash
# Build the project
dotnet build MBOX.csproj

# Run the project
dotnet run --project MBOX.csproj

# Publish a self-contained executable (no .NET runtime required)
dotnet publish MBOX.csproj -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true
```

## Features

### Screw Parameters Configuration
- **Screw Stroke (丝杠行程)**: Maximum travel distance in millimeters (default: 50mm)
- **Screw Lead (丝杠导程)**: Lead distance in millimeters (default: 5mm)
- **Pulses Per Revolution (每圈脉冲数)**: Motor pulses per revolution (default: 10000)

### Network Configuration
- **Accept IP (接收IP)**: IP address of device to accept commands (default: 255.255 for broadcast)
- **Reply IP (应答IP)**: IP address for replies (default: 255.255 for broadcast)
- **Host TX Port (主机发送端口)**: Local transmit port (default: 8410)
- **Host RX Port (主机接收端口)**: Local receive port (default: 8409)
- **MBOX TX Port (MBOX发送端口)**: MBOX device transmit port (default: 7409)
- **MBOX RX Port (MBOX接收端口)**: MBOX device receive port (default: 7408)

### Motion Control
- **Move to Max Position (移动到最大位置)**: Move all 6 axes to maximum stroke position
- **Move to Middle Position (移动到中间位置)**: Move all 6 axes to half stroke position
- **Move to Zero Position (移动到零位)**: Move all 6 axes to zero/home position

### Sine Wave Motion
- **Peak Amplitude (振幅)**: Sine wave peak in millimeters (default: 50mm)
- **Frequency (频率)**: Sine wave frequency in Hz (default: 1Hz)
- **Sampling Period (采样周期)**: Sampling period in seconds (default: 0.01s = 100Hz sampling rate)
- **Start Sine Motion (开始正弦运动)**: Begin continuous sine wave motion
- **Stop Sine Motion (停止正弦运动)**: Stop the sine wave motion

## UDP Protocol

The application uses a custom 50-byte UDP protocol with **big-endian byte order** (network byte order):

### Packet Structure

| Offset | Size | Type | Field | Description |
|--------|------|------|-------|-------------|
| 0-1 | 2 | UInt16 | ConfirmCode | 0x55AA (magic number) |
| 2-3 | 2 | UInt16 | PassCode | 0x0000 |
| 4-5 | 2 | UInt16 | FunctionCode | 0x1301 (broadcast) / 0x1401 (timed) |
| 6-7 | 2 | UInt16 | ChannelCode | 0x0001 (platform channel) |
| 8-9 | 2 | UInt16 | WhoAccept | Target platform (0xFFFF = all) |
| 10-11 | 2 | UInt16 | WhoReply | Reply platform (0xFFFF = all) |
| 12-15 | 4 | Int32 | PlayLine | Sequence number |
| 16-19 | 4 | Int32 | PlayTime | Time in milliseconds |
| 20-23 | 4 | Int32 | XPosition | X-axis position in pulses |
| 24-27 | 4 | Int32 | YPosition | Y-axis position in pulses |
| 28-31 | 4 | Int32 | ZPosition | Z-axis position in pulses |
| 32-35 | 4 | Int32 | UPosition | U-axis position in pulses |
| 36-39 | 4 | Int32 | VPosition | V-axis position in pulses |
| 40-43 | 4 | Int32 | WPosition | W-axis position in pulses |
| 44-45 | 2 | UInt16 | BaseDoutCode | Digital outputs (0x1234) |
| 46-47 | 2 | UInt16 | DacOneCode | DAC 1 value (0x5678) |
| 48-49 | 2 | UInt16 | DacTwoCode | DAC 2 value (0xABCD) |

### Function Codes
- **0x1301**: Broadcast command (non-timed) - Used for direct position commands
- **0x1401**: Timed broadcast - Used for sine wave motion with timing

## Migration Notes from VB6

### Replaced Components
1. **Winsock OCX Control** → `System.Net.Sockets.UdpClient`
   - Native .NET UDP implementation
   - Supports broadcast mode (255.255.255.255)

2. **CopyMemory API** → `System.Buffers.Binary.BinaryPrimitives`
   - Modern .NET big-endian conversion
   - Type-safe, no unsafe code needed

### Improvements Over VB6
1. **Error Handling**: Comprehensive try-catch blocks for network and validation errors
2. **Input Validation**: Real-time validation with user feedback
3. **Configuration Validation**: Validates all parameters before sending commands
4. **Resource Management**: Proper IDisposable pattern implementation
5. **Type Safety**: Strong typing with C# generics and modern .NET types
6. **Sine Wave Accuracy**: Fixed time calculation bug from VB6 (now uses seconds correctly)

### Known Differences
- **Pulse Calculation**: The C# version uses the same formula as VB6, including the `/2` division at the end of the pulse calculation for sine wave motion
- **Timer Precision**: Uses Windows Forms Timer (similar to VB6), adequate for the default 10ms sampling period

## Testing

### Hardware Testing Checklist
1. ✅ Verify network connectivity to MBOX device
2. ✅ Test "Go to Zero" command (safest, no movement expected)
3. ✅ Test "Go to Middle" command (small movement)
4. ✅ Test "Go to Max" command (full stroke)
5. ✅ Test sine wave with low amplitude (1-5mm)
6. ✅ Test sine wave with full amplitude
7. ✅ Verify all 6 axes respond correctly

### Debugging with Wireshark
You can use Wireshark to capture and analyze UDP packets:
1. Install Wireshark
2. Start capture on your network interface
3. Filter: `udp.port == 7408`
4. Send a command from the application
5. Verify packet structure matches the protocol specification

### Packet Validation
The packet bytes can be inspected in Wireshark. For example, a zero position command should show:
- Bytes 0-1: `55 AA` (ConfirmCode)
- Bytes 4-5: `13 01` (FunctionCode for broadcast)
- Bytes 20-43: All zeros (6 axes at position 0)

## Troubleshooting

### "Failed to initialize UDP client"
- Check that the ports are not already in use
- Ensure no firewall is blocking the application
- Try running as Administrator

### "Failed to send UDP packet"
- Verify network connectivity
- Check that MBOX device is powered on
- Verify broadcast is enabled on network adapter
- Confirm MBOX RX port is correct (default: 7408)

### Sine wave not working
- Verify sampling period is reasonable (0.001 to 1.0 seconds)
- Check that frequency * sampling period doesn't cause overflow
- Ensure MBOX device supports timed broadcast mode (0x1401)

## License

This is a migration of the original VB6 MBOX control application. All rights reserved by the original authors.

## Version History

- **Version 2.0** (2025): C# .NET 6 migration with modern UI and improved error handling
- **Version 1.0** (Original): Visual Basic 6 application
