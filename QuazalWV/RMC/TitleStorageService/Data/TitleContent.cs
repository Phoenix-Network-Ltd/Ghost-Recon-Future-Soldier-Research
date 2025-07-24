using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuazalWV
{
    public class TitleContent : IData
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ulong Size { get; set; }
        public string ContentType { get; set; }
        public uint Flags { get; set; }
        public uint ExtendedFlags { get; set; }

        public TitleContent()
        {
            Id = 1;
            Name = "TitleContentName";
            Description = "TitleContentDescription";
            Size = 100;
            ContentType = "GameConfigContent";
            Flags = 0x0;
            ExtendedFlags = 0x0;
        }

        public TitleContent(Stream s)
        {
            FromStream(s);
        }

        public void FromStream(Stream s)
        {
            Id = Helper.ReadU32(s);
            Name = Helper.ReadString(s);
            Description = Helper.ReadString(s);
            Size = Helper.ReadU64(s);
            ContentType = Helper.ReadString(s);
            Flags = Helper.ReadU32(s);
            ExtendedFlags = Helper.ReadU32(s);
        }

        public uint GetBufferSize()
        {
            MemoryStream m = new MemoryStream();
            ToBuffer(m);
            return (uint)m.Length;
        }

        public string GetClass()
        {
            return "TitleContent";
        }

        public void ToBuffer(Stream s)
        {
            Helper.WriteU32(s, Id);
            Helper.WriteString(s, Name);
            Helper.WriteString(s, Description);
            Helper.WriteU64(s, Size);
            Helper.WriteString(s, ContentType);
            Helper.WriteU32(s, Flags);
            Helper.WriteU32(s, ExtendedFlags);
        }
    }
}
