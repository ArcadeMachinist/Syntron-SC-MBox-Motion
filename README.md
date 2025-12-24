# Syntron MBOX Control System Tool

This is a modern C# .NET Windows Forms application for SYNTROC SC-MBOX v3 motion control board.
It controls a 3, 6, 10-axis motion platform (MBOX) via UDP network communication.
This tool is a work in progress. Research based on original Chinese documentation and now defunct VB6 app.

I did this for the purpose of controlling my VR360 chair, made by NineD.
Demo vide: https://youtu.be/qMGMdICjUk8

Default Board IP: 192.168.233.201
Default PC IP: 192.168.233.100
Default ports: Host 8410 <--> Board 7408 (UDP)

## Requirements

- .NET 10.0 SDK or later (you might easy backport to .NET 6.0, it was tested with .NET 6.0)
- Windows operating system (because of WinForms, but logic can work anywhere)

## Building the Project

### Using Visual Studio

1. Open `MBOX.csproj` in Visual Studio 2022 or later
2. Press F5 to build and run, or Ctrl+Shift+B to build only
3. The executable will be in `bin/Debug/net10.0-windows/` or `bin/Release/net10.0-windows/`

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
- **Screw Stroke**: Maximum travel distance in millimeters (default: 50mm)
- **Screw Lead**: Lead distance in millimeters (default: 5mm)
- **Pulses Per Revolution**: Motor pulses per revolution (default: 10000)

### Network Configuration
- **Accept IP**: IP address MASK of device to accept commands (default: 255.255 for broadcast)
- **Reply IP**: IP address MASK for replies (default: 255.255 for broadcast)
- **Host TX Port**: Local transmit port (default: 8410)
- **Host RX Port**: Local receive port (default: 8409)
- **MBOX TX Port**: MBOX device transmit port (default: 7409)
- **MBOX RX Port**: MBOX device receive port (default: 7408)

### Motion Control
- **Move to Max Position**: Move all 6 axes to maximum stroke position
- **Move to Middle Position**: Move all 6 axes to half stroke position
- **Move to Zero Position**: Move all 6 axes to zero/home position

### Sine Wave Motion
- **Peak Amplitude**: Sine wave peak in millimeters (default: 50mm)
- **Frequency**: Sine wave frequency in Hz (default: 1Hz)
- **Sampling Period**: Sampling period in seconds (default: 0.01s = 100Hz sampling rate)
- **Start Sine Motion**: Begin continuous sine wave motion
- **Stop Sine Motion**: Stop the sine wave motion

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
- **0x1101**: Read settings registers (not implemented yet)
- **0x1201**: Write settings registers (not implemented yet)
- 

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

## Version History

- **Version 2.0** (2025): C# .NET 6 migration with modern UI and improved error handling.
- **Version 1.0** (Original): Visual Basic 6 application, shipped by original manufacturer.
