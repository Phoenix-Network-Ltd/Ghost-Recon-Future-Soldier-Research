using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuazalWV
{
    /// <summary>
    /// Class name assumed.
    /// </summary>
    public class MiscFriendObject : IData
    {
        public uint Uint1 { get; set; }
        public uint Uint2 { get; set; }

        public MiscFriendObject()
        {
            // Experimental
            Uint1 = 1;
            Uint2 = 1;
        }

        public MiscFriendObject(Stream s)
        {
            FromStream(s);
        }

        public void FromStream(Stream s)
        {
            Uint1 = Helper.ReadU32(s);
            Uint2 = Helper.ReadU32(s);
        }

        public uint GetBufferSize()
        {
            return 8;
        }

        public string GetClass()
        {
            return "MiscFriendObject";
        }

        public void ToBuffer(Stream s)
        {
            Helper.WriteU32(s, Uint1);
            Helper.WriteU32(s, Uint2);
        }
    }
}
