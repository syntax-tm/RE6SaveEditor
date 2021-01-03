using System;
using System.IO;

namespace RE6SaveEditor
{
    internal class BinaryReaderEB : BinaryReader
    {
        private byte[] a16 = new byte[2];
        private byte[] a32 = new byte[4];
        private byte[] a64 = new byte[8];

        public BinaryReaderEB(Stream stream)
          : base(stream)
        {
        }

        public override int ReadInt32()
        {
            this.a32 = this.ReadBytes(4);
            Array.Reverse((Array)this.a32);
            return BitConverter.ToInt32(this.a32, 0);
        }

        public override short ReadInt16()
        {
            this.a16 = this.ReadBytes(2);
            Array.Reverse((Array)this.a16);
            return BitConverter.ToInt16(this.a16, 0);
        }

        public override long ReadInt64()
        {
            this.a64 = this.ReadBytes(8);
            Array.Reverse((Array)this.a64);
            return BitConverter.ToInt64(this.a64, 0);
        }

        public override uint ReadUInt32()
        {
            this.a32 = this.ReadBytes(4);
            Array.Reverse((Array)this.a32);
            return BitConverter.ToUInt32(this.a32, 0);
        }
    }
}
