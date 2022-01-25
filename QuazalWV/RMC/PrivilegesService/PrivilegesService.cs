using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuazalWV
{
    public static class PrivilegesService
    {
        public static void ProcessPrivilegesServiceRequest(Stream s, RMCP rmc)
        {
            switch (rmc.methodID)
            {
                case 6:
                    rmc.request = new RMCPacketRequestPrivilegesService_GetPrivilegesEx(s);
                    break;
                default:
                    Log.WriteLine(1, "[RMC Privileges] Error: Unknown Method 0x" + rmc.methodID.ToString("X"));
                    break;
            }
        }

        public static void HandlePrivilegesServiceRequest(QPacket p, RMCP rmc, ClientInfo client)
        {
            RMCPResponse reply;
            switch (rmc.methodID)
            {
                case 6:
                    reply = new RMCPacketResponsePrivilegesService_GetPrivilegesEx();
                    RMC.SendResponseWithACK(client.udp, p, rmc, client, reply);
                    break;
                default:
                    Log.WriteLine(1, "[RMC Privileges] Error: Unknown Method 0x" + rmc.methodID.ToString("X"));
                    break;
            }
        }
    }
}
