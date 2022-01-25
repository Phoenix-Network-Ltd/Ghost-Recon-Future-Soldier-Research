using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuazalWV
{
    public class PrivilegeEx : IData
    {
        public uint Id { get; set; }
        public string Description { get; set; }
        public uint Duration { get; set; }

        public PrivilegeEx()
        {

        }

        public PrivilegeEx(uint id, string desc, uint duration = 0xFFFFFFFF)
        {
            Id = id;
            Description = desc;
            Duration = duration;
        }

        public PrivilegeEx(Stream s)
        {
            FromStream(s);
        }

        public void FromStream(Stream s)
        {
            Id = Helper.ReadU32(s);
            Description = Helper.ReadString(s);
            Duration = Helper.ReadU32(s);
        }

        public uint GetBufferSize()
        {
            MemoryStream m = new MemoryStream();
            ToBuffer(m);
            return (uint)m.Length;
        }

        public string GetClass()
        {
            return "PrivilegeEx";
        }

        public void ToBuffer(Stream s)
        {
            Helper.WriteU32(s, Id);
            Helper.WriteString(s, Description);
            Helper.WriteU32(s, Duration);
        }
    }
}
