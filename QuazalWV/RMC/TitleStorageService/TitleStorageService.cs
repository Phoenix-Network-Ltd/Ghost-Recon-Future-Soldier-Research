using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuazalWV
{
    public static class TitleStorageService
    {
        public static void ProcessTitleStorageServiceRequest(Stream s, RMCP rmc)
        {
            switch (rmc.methodID)
            {
                case 2:
                    rmc.request = new RMCPacketRequestTitleStorageService_BrowseContentsByType(s);
                    break;
                default:
                    Log.WriteLine(1, "[RMC Title Storage] Error: Unknown Method 0x" + rmc.methodID.ToString("X"));
                    break;
            }
        }

        public static void HandleTitleStorageServiceRequest(QPacket p, RMCP rmc, ClientInfo client)
        {
            RMCPResponse reply;
            switch (rmc.methodID)
            {
                case 2:
                    reply = new RMCPacketResponseTitleStorageService_BrowseContentsByType();
                    RMC.SendResponseWithACK(client.udp, p, rmc, client, reply);
                    break;
                default:
                    Log.WriteLine(1, "[RMC Title Storage] Error: Unknown Method 0x" + rmc.methodID.ToString("X"));
                    break;
            }
        }
    }
}
