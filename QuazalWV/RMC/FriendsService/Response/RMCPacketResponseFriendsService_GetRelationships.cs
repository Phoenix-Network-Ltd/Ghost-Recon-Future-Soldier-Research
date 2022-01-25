﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuazalWV
{
    public class RMCPacketResponseFriendsService_GetRelationships : RMCPResponse
    {
        public List<RelationshipData> Relationships { get; set; }

        public RMCPacketResponseFriendsService_GetRelationships()
        {
            Relationships = new List<RelationshipData>()
            {
                new RelationshipData(),
            };
        }

        public override string ToString()
        {
            return "[GetRelationships Response]";
        }

        public override string PayloadToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"\t[Relationships: {Relationships.Count}]");
            return sb.ToString();
        }

        public override byte[] ToBuffer()
        {
            MemoryStream m = new MemoryStream();
            Helper.WriteU32(m, (uint)Relationships.Count);
            foreach (RelationshipData r in Relationships)
                r.ToBuffer(m);
            return m.ToArray();
        }
    }
}
