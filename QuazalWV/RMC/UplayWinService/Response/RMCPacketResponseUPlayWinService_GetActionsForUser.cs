using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuazalWV
{
    public class RMCPacketResponseUPlayWinService_GetActionsForUser : RMCPResponse
    {
        public List<UPlayAction> Actions { get; set; }

        public RMCPacketResponseUPlayWinService_GetActionsForUser()
        {
            Actions = new List<UPlayAction>()
            {
                new UPlayAction()
            };
        }

        public override string PayloadToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"\t[Actions : {Actions.Count}]");
            return sb.ToString();
        }

        public override byte[] ToBuffer()
        {
            MemoryStream m = new MemoryStream();
            Helper.WriteU32(m, (uint)Actions.Count);
            foreach (UPlayAction a in Actions)
                a.ToBuffer(m);
            return m.ToArray();
        }

        public override string ToString()
        {
            return "[GetActionsForUser Response]";
        }
    }
}
