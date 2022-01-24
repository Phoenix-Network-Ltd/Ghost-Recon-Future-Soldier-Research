using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuazalWV
{
    public static class AuthenticationService
    {
        public static void ProcessAuthenticationServiceRequest(Stream s, RMCP rmc)
        {
            switch (rmc.methodID)
            {
                case 1:
                    rmc.request = new RMCPacketRequestAuthenticationService_Login(s);
                    break;
                case 2:
                    rmc.request = new RMCPacketRequestLoginCustomData(s);
                    break;
                case 3:
                    rmc.request = new RMCPacketRequestRequestTicket(s);
                    break;
                default:
                    Log.WriteLine(1, "[RMC Authentication] Error: Unknown Method 0x" + rmc.methodID.ToString("X"));
                    break;
            }
        }


        public static void HandleAuthenticationServiceRequest(QPacket p, RMCP rmc, ClientInfo client)
        {
            RMCPResponse reply;
            switch (rmc.methodID)
            {
                // 'Tracking' user - ignore username, identified by Global.TrackingPid
                case 1:
                    RMCPacketRequestAuthenticationService_Login rLogin = (RMCPacketRequestAuthenticationService_Login)rmc.request;
                    switch(rLogin.username)
                    {
                        case "Tracking":
                            reply = new RMCPacketResponseAuthenticationService_Login(client, rLogin.username);
                            RMC.SendResponseWithACK(client.udp, p, rmc, client, reply, useCompression: false);
                            break;
                        default:
                            Log.WriteLine(1, "[RMC Authentication] Error: Unknown (1) Login user: " + rLogin.username);
                            break;
                    }
                    break;
                // UPlay user credentials (i have no idea who designed this to work that way)
                case 2:
                    RMCPacketRequestLoginCustomData rCustom = (RMCPacketRequestLoginCustomData)rmc.request;
                    switch (rCustom.className)
                    {
                        case "UbiAuthenticationLoginCustomData":
                            // Ubisoft Connect prod username
                            client.name = rCustom.username;
                            // Ubisoft Connect prod password (sic)
                            client.pass = rCustom.password;
                            // Ubisoft Connect user activation key for GRFS
                            client.onlineKey = rCustom.onlineKey;
                            reply = new RMCPacketResponseLoginCustomData(client);
                            RMC.SendResponseWithACK(client.udp, p, rmc, client, reply);
                            break;
                        default:
                            Log.WriteLine(1, "[RMC Authentication] Error: Unknown Custom Data class " + rCustom.className);
                            break;
                    }
                    break;
                case 3:
                    RMCPacketRequestRequestTicket rTicket = (RMCPacketRequestRequestTicket)rmc.request;
                    reply = new RMCPacketResponseRequestTicket(client, rTicket.sourcePID);
                    RMC.SendResponseWithACK(client.udp, p, rmc, client, reply);
                    break;
                default:
                    Log.WriteLine(1, "[RMC Authentication] Error: Unknown Method 0x" + rmc.methodID.ToString("X"));
                    break;
            }
        }
    }
}
