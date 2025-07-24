using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuazalWV
{
    public class UPlayActionPlatform : IData
    {
        public string Str1 { get; set; }
        public bool Bool1 { get; set; }
        public string Str2 { get; set; }

        public UPlayActionPlatform()
        {
            Str1 = "PlatformStr1";
            Bool1 = true;
            Str2 = "PlatformStr2";
        }

        public UPlayActionPlatform(Stream s)
        {
            FromStream(s);
        }

        public void FromStream(Stream s)
        {
            Str1 = Helper.ReadString(s);
            Bool1 = Helper.ReadBool(s);
            Str2 = Helper.ReadString(s);
        }

        public uint GetBufferSize()
        {
            MemoryStream m = new MemoryStream();
            ToBuffer(m);
            return (uint)m.Length;
        }

        public string GetClass()
        {
            return "UPlayActionPlatform";
        }

        public void ToBuffer(Stream s)
        {
            Helper.WriteString(s, Str1);
            Helper.WriteBool(s, Bool1);
            Helper.WriteString(s, Str2);
        }
    }
}
