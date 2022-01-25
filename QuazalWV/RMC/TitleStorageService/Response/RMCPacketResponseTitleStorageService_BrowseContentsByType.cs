using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuazalWV
{
    public class RMCPacketResponseTitleStorageService_BrowseContentsByType : RMCPResponse
    {
        public List<GameConfigContent> Contents { get; set; }

        public RMCPacketResponseTitleStorageService_BrowseContentsByType()
        {
            Contents = new List<GameConfigContent>()
            {
                new GameConfigContent()
            };
        }

        public override string PayloadToString()
        {
            return "";
        }

        public override byte[] ToBuffer()
        {
            MemoryStream m = new MemoryStream();
            Helper.WriteU32(m, (uint)Contents.Count);
            AnyDataHolder<GameConfigContent> h;
            foreach (GameConfigContent c in Contents)
            {
                h = new AnyDataHolder<GameConfigContent>(c);
                h.ToBuffer(m);
            }
            return m.ToArray();
        }

        public override string ToString()
        {
            return "[BrowseContentsByType Response]";
        }
    }
}
