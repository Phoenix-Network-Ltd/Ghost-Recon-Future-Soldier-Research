using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuazalWV
{
    public class RMCPacketResponsePrivilegesService_GetPrivilegesEx : RMCPResponse
    {
        public List<PrivilegeEx> Privileges { get; set; }

        /// <summary>
        /// Privilege list based on captures from GRFS live server.
        /// </summary>
        public RMCPacketResponsePrivilegesService_GetPrivilegesEx()
        {
            Privileges = new List<PrivilegeEx>()
            {
                new PrivilegeEx(1, "Allow to play online"),
                new PrivilegeEx(0x404, "Weapon M40A5"),
                new PrivilegeEx(0x405, "Weapon MK14"),
                new PrivilegeEx(0x406, "Weapon MN913"),
                new PrivilegeEx(0x401, "Weapon AK47"),
                new PrivilegeEx(0x3FE, "Scout Head Variant 7"),
                new PrivilegeEx(0x410, "Map MH01 Tramway"),
                new PrivilegeEx(0x422, "Tiger Stripe Camo"),
                new PrivilegeEx(0x453, "Winter Digital Camo"),
                new PrivilegeEx(0x3E8, "Engineer Head Variant 1"),
                new PrivilegeEx(0x3E9, "Engineer Head Variant 2"),
                new PrivilegeEx(0x3EA, "Engineer Head Variant 3"),
                new PrivilegeEx(0x3EB, "Engineer Head Variant 4"),
                new PrivilegeEx(0x3EC, "Engineer Head Variant 5"),
                new PrivilegeEx(0x3ED, "Engineer Head Variant 6"),
                new PrivilegeEx(0x3EE, "Engineer Head Variant 7"),
                new PrivilegeEx(0x3EF, "Engineer Head Variant 8"),
                new PrivilegeEx(0x3F0, "Rifleman Head Variant 1"),
                new PrivilegeEx(0x3F1, "Rifleman Head Variant 2"),
                new PrivilegeEx(0x3F2, "Rifleman Head Variant 3"),
                new PrivilegeEx(0x3F3, "Rifleman Head Variant 4"),
                new PrivilegeEx(0x3F4, "Rifleman Head Variant 5"),
                new PrivilegeEx(0x3F5, "Rifleman Head Variant 6"),
                new PrivilegeEx(0x3F6, "Rifleman Head Variant 7"),
                new PrivilegeEx(0x3F7, "Rifleman Head Variant 8"),
                new PrivilegeEx(0x3F8, "Scout Head Variant 1"),
                new PrivilegeEx(0x3F9, "Scout Head Variant 2"),
                new PrivilegeEx(0x3FA, "Scout Head Variant 3"),
                new PrivilegeEx(0x3FB, "Scout Head Variant 4"),
                new PrivilegeEx(0x3FC, "Scout Head Variant 5"),
                new PrivilegeEx(0x3FD, "Scout Head Variant 6"),
                new PrivilegeEx(0x3FE, "Scout Head Variant 7"),
                new PrivilegeEx(0x3FF, "Scout Head Variant 8"),
                new PrivilegeEx(0x13BA, "Unlock an R6 weapon skin by having a save file or achievement for GRAW 1/2, or SC: Conviction"),
                new PrivilegeEx(0x13C4, "Unlock a Tom Clancy weapon skin by having a save game or achievement for GRAW 1/2, or SC: Conviction"),
                new PrivilegeEx(0x13CE, "Unlock a Splinter Cell weapon skin by having a save game or achievement from SC: Conviction"),
            };
        }

        public override string PayloadToString()
        {
            return "";
        }

        public override byte[] ToBuffer()
        {
            MemoryStream m = new MemoryStream();
            Helper.WriteU32(m, (uint)Privileges.Count);
            foreach (PrivilegeEx p in Privileges)
                p.ToBuffer(m);
            return m.ToArray();
        }

        public override string ToString()
        {
            return "[GetPrivilegesEx Response]";
        }

    }
}
