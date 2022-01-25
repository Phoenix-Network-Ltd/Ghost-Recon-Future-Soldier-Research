using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuazalWV
{
    public static class UplayWinService
    {
        public static void ProcessUplayWinServiceRequest(Stream s, RMCP rmc)
        {
            switch (rmc.methodID)
            {
                case 7:
                    rmc.request = new RMCPacketRequestUPlayWinService_GetActionsForUser(s);
                    break;
                default:
                    Log.WriteLine(1, "[RMC Uplay Win] Error: Unknown Method 0x" + rmc.methodID.ToString("X"));
                    break;
            }
        }

        public static void HandleUplayWinServiceRequest(QPacket p, RMCP rmc, ClientInfo client)
        {
            RMCPResponse reply;
            switch (rmc.methodID)
            {
                case 7:
                    reply = new RMCPacketResponseUPlayWinService_GetActionsForUser();
                    RMC.SendResponseWithACK(client.udp, p, rmc, client, reply);
                    break;
                default:
                    Log.WriteLine(1, "[RMC Uplay Win] Error: Unknown Method 0x" + rmc.methodID.ToString("X"));
                    break;
            }
        }
    }
}
