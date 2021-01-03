using System.IO;

namespace RE6SaveEditor
{
    public class CALCULATE
    {
        public static uint CHECKSUM(string FILEPATH)
        {
            var binaryReader = new BinaryReader(File.OpenRead(FILEPATH));
            binaryReader.BaseStream.Position = 4L;
            var num1 = (long) (binaryReader.ReadInt32() - 24);
            binaryReader.BaseStream.Position = 24L;
            long num2 = 0;
            for (long index = 0; index < num1; index += 4L)
            {
                num2 += binaryReader.ReadInt32();
            }

            while (num2 > 4294967296L)
            {
                num2 -= 4294967296L;
            }

            binaryReader.Close();
            var binaryWriter = new BinaryWriter(File.OpenWrite(FILEPATH));
            binaryWriter.BaseStream.Position = 8L;
            binaryWriter.Write(num2);
            binaryWriter.Flush();
            binaryWriter.Close();
            return 1;
        }
    }
}
