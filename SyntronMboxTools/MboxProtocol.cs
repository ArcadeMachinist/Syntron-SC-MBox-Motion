
using System.Buffers.Binary;

namespace SyntronMboxTools
{
    /// <summary>
    /// Function codes for MBOX UDP protocol
    /// </summary>
    public enum FunctionCode : ushort
    {
        BroadcastCommand = 0x1301,  // Non-timed broadcast command
        TimedBroadcast = 0x1401      // Timed broadcast (for sine wave motion)
    }

    /// <summary>
    /// MBOX UDP packet structure (50 bytes, big-endian byte order)
    /// </summary>
    public class MboxPacket
    {
        // Protocol constants
        public const ushort CONFIRM_CODE = 0x55AA;
        public const ushort PASS_CODE = 0x0000;
        public const ushort CHANNEL_CODE = 0x0001;
        public const ushort DEFAULT_BASE_DOUT = 0x1234;
        public const ushort DEFAULT_DAC_ONE = 0x5678;
        public const ushort DEFAULT_DAC_TWO = 0xABCD;
        public const int PACKET_SIZE = 50;

        // Packet fields
        public FunctionCode FunctionCode { get; set; }
        public ushort WhoAccept { get; set; } = 0xFFFF;
        public ushort WhoReply { get; set; } = 0xFFFF;
        public int PlayLine { get; set; }
        public int PlayTime { get; set; }

        // Axis positions (in pulses)
        public int XPosition { get; set; }
        public int YPosition { get; set; }
        public int ZPosition { get; set; }
        public int UPosition { get; set; }
        public int VPosition { get; set; }
        public int WPosition { get; set; }

        // Digital outputs and DAC values
        public ushort BaseDoutCode { get; set; } = DEFAULT_BASE_DOUT;
        public ushort DacOneCode { get; set; } = DEFAULT_DAC_ONE;
        public ushort DacTwoCode { get; set; } = DEFAULT_DAC_TWO;

        /// <summary>
        /// Converts the packet to a 50-byte array with big-endian byte order (network byte order)
        /// </summary>
        public byte[] ToByteArray()
        {
            byte[] packet = new byte[PACKET_SIZE];

            // Write all fields in big-endian format (network byte order)
            BinaryPrimitives.WriteUInt16BigEndian(packet.AsSpan(0), CONFIRM_CODE);
            BinaryPrimitives.WriteUInt16BigEndian(packet.AsSpan(2), PASS_CODE);
            BinaryPrimitives.WriteUInt16BigEndian(packet.AsSpan(4), (ushort)FunctionCode);
            BinaryPrimitives.WriteUInt16BigEndian(packet.AsSpan(6), CHANNEL_CODE);
            BinaryPrimitives.WriteUInt16BigEndian(packet.AsSpan(8), WhoAccept);
            BinaryPrimitives.WriteUInt16BigEndian(packet.AsSpan(10), WhoReply);
            BinaryPrimitives.WriteInt32BigEndian(packet.AsSpan(12), PlayLine);
            BinaryPrimitives.WriteInt32BigEndian(packet.AsSpan(16), PlayTime);
            BinaryPrimitives.WriteInt32BigEndian(packet.AsSpan(20), XPosition);
            BinaryPrimitives.WriteInt32BigEndian(packet.AsSpan(24), YPosition);
            BinaryPrimitives.WriteInt32BigEndian(packet.AsSpan(28), ZPosition);
            BinaryPrimitives.WriteInt32BigEndian(packet.AsSpan(32), UPosition);
            BinaryPrimitives.WriteInt32BigEndian(packet.AsSpan(36), VPosition);
            BinaryPrimitives.WriteInt32BigEndian(packet.AsSpan(40), WPosition);
            BinaryPrimitives.WriteUInt16BigEndian(packet.AsSpan(44), BaseDoutCode);
            BinaryPrimitives.WriteUInt16BigEndian(packet.AsSpan(46), DacOneCode);
            BinaryPrimitives.WriteUInt16BigEndian(packet.AsSpan(48), DacTwoCode);

            return packet;
        }
    }
}
