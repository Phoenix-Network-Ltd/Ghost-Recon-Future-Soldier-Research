﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuazalWV
{
    public class AnyDataHeader
    {
        public string DataClass { get; set; }
        public uint OuterSize { get; set; }
        public uint InnerSize { get; set; }

        public AnyDataHeader()
        {

        }

        public AnyDataHeader(Stream s)
        {
            FromStream(s);
        }

        public virtual void FromStream(Stream s)
        {
            DataClass = Helper.ReadString(s);
            OuterSize = Helper.ReadU32(s);
            InnerSize = Helper.ReadU32(s);
        }

        public virtual void ToBuffer(Stream s)
        {
            Helper.WriteString(s, DataClass);
            Helper.WriteU32(s, OuterSize);
            Helper.WriteU32(s, InnerSize);
        }
    }
}