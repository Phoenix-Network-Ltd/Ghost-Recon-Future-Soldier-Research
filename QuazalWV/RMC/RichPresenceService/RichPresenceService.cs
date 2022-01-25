using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuazalWV
{
    public static class RichPresenceService
    {
        public static void ProcessRichPresenceServiceRequest(Stream s, RMCP rmc)
        {
            switch (rmc.methodID)
            {
                case 1:
                    rmc.request = new RMCPacketRequestRichPresenceService_StartPresence(s);
                    break;
                default:
                    Log.WriteLine(1, "[RMC Rich Presence] Error: Unknown Method 0x" + rmc.methodID.ToString("X"));
                    break;
            }
        }

        public static void HandleRichPresenceServiceRequest(QPacket p, RMCP rmc, ClientInfo client)
        {
            RMCPResponse reply;
            switch (rmc.methodID)
            {
                case 1:
                    reply = new RMCPResponseEmpty();
                    RMC.SendResponseWithACK(client.udp, p, rmc, client, reply);
                    break;
                default:
                    Log.WriteLine(1, "[RMC Rich Presence] Error: Unknown Method 0x" + rmc.methodID.ToString("X"));
                    break;
            }
        }
    }
}
