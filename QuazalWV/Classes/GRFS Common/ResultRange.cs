﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuazalWV
{
    public class ResultRange : IData
    {
        public uint Offset { get; set; }
        public uint Size { get; set; }

        public ResultRange(Stream s)
        {
            FromStream(s);
        }

        public void FromStream(Stream s)
        {
            Offset = Helper.ReadU32(s);
            Size = Helper.ReadU32(s);
        }

        public uint GetBufferSize()
        {
            return 8;
        }

        public string GetClass()
        {
            return "ResultRange";
        }

        public void ToBuffer(Stream s)
        {
            Helper.WriteU32(s, Offset);
            Helper.WriteU32(s, Size);
        }
    }
}
