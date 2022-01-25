using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuazalWV
{
    public class UPlayAction : IData
    {
        public string Str1 { get; set; }
        public string Str2 { get; set; }
        public string Str3 { get; set; }
        public uint Uint1 { get; set; }
        public string Str4 { get; set; }
        public List<UPlayActionPlatform> Platforms { get; set; }

        public UPlayAction()
        {
            Str1 = "ActionStr1";
            Str2 = "ActionStr2";
            Str3 = "ActionStr3";
            Uint1 = 1;
            Str4 = "ActionStr4";
            Platforms = new List<UPlayActionPlatform>() {new UPlayActionPlatform()};
        }

        public UPlayAction(Stream s)
        {
            FromStream(s);
        }

        public void FromStream(Stream s)
        {
            Str1 = Helper.ReadString(s);
            Str2 = Helper.ReadString(s);
            Str3 = Helper.ReadString(s);
            Uint1 = Helper.ReadU32(s);
            Str4 = Helper.ReadString(s);
            uint count = Helper.ReadU32(s);
            for (uint i = 0; i < count; i++)
                Platforms.Add(new UPlayActionPlatform(s));
        }

        public uint GetBufferSize()
        {
            MemoryStream m = new MemoryStream();
            ToBuffer(m);
            return (uint)m.Length;
        }

        public string GetClass()
        {
            return "UPlayAction";
        }

        public void ToBuffer(Stream s)
        {
            Helper.WriteString(s, Str1);
            Helper.WriteString(s, Str2);
            Helper.WriteString(s, Str3);
            Helper.WriteU32(s, Uint1);
            Helper.WriteString(s, Str4);
            foreach (UPlayActionPlatform p in Platforms)
                p.ToBuffer(s);
        }
    }
}
