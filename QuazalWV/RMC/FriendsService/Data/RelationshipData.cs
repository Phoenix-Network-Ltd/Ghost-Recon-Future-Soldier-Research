using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuazalWV
{
    public class RelationshipData : IData
    {
        public uint Pid { get; set; }
        public string Name { get; set; }
        public byte Relationship { get; set; }
        public uint Details { get; set; }
        public byte Status { get; set; }

        public RelationshipData()
        {
            // Experimental
            Pid = 0x1233;
            Name = "mimak";
            Relationship = 0x1;
            Details = 0x1;
            Status = 0x1;
        }

        public RelationshipData(Stream s)
        {
            FromStream(s);
        }

        public void FromStream(Stream s)
        {
            Pid = Helper.ReadU32(s);
            Name = Helper.ReadString(s);
            Relationship = Helper.ReadU8(s);
            Details = Helper.ReadU32(s);
            Status = Helper.ReadU8(s);
        }

        public uint GetBufferSize()
        {
            MemoryStream m = new MemoryStream();
            ToBuffer(m);
            return (uint)m.Length;
        }

        public string GetClass()
        {
            return "RelationshipData";
        }

        public void ToBuffer(Stream s)
        {
            Helper.WriteU32(s, Pid);
            Helper.WriteString(s, Name);
            Helper.WriteU8(s, Relationship);
            Helper.WriteU32(s, Details);
            Helper.WriteU8(s, Status);
        }
    }
}
