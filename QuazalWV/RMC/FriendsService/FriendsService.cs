using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuazalWV
{
    public static class FriendsService
    {
        public static void ProcessFriendsServiceRequest(Stream s, RMCP rmc)
        {
            switch (rmc.methodID)
            {
                default:
                    Log.WriteLine(1, "[RMC Friends] Error: Unknown Method 0x" + rmc.methodID.ToString("X"));
                    break;
            }
        }

        public static void HandleFriendsServiceRequest(QPacket p, RMCP rmc, ClientInfo client)
        {
            RMCPResponse reply;
            switch (rmc.methodID)
            {
                default:
                    Log.WriteLine(1, "[RMC FriendsService] Error: Unknown Method 0x" + rmc.methodID.ToString("X"));
                    break;
            }
        }
    }
}
