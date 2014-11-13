
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Framework
{
    public class EncodingType
    {
        public static System.Text.Encoding GetType(string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read)

            System.Text.Encoding encoding = GetType(fs);
            fs.Close();
            return encoding;
        }

        public static System.Text.Encoding GetType(FileStream fs)
        {
            BinaryReader reader = new BinaryReader(fs, System.Text.Encoding.Default);
            byte[] bytes = reader.ReadBytes(3);
            reader.Close();
            if (bytes[0] >= 0xEF)
            {
                if (bytes[0] == 0xEf && bytes[1] == 0xBB && bytes[2] == 0xBF)
                {
                    return System.Text.Encoding.UTF8;
                }
                else if (bytes[0] == 0xFE && bytes[1] == 0xEF)
                {
                    return System.Text.Encoding.BigEndianUnicode;
                }
                else if (bytes[0] == 0xFF && bytes[1] == 0xFE)
                {
                    return System.Text.Encoding.Unicode;
                }
            }
            return System.Text.Encoding.Default;
        }
    }
}
