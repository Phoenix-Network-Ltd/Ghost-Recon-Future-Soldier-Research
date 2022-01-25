using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace QuazalWV
{
    public class AnyDataHolder<T> : AnyDataHeader, IData where T : IData, new()
    {
        public T Data { get; set; }

        public AnyDataHolder()
        {
            Data = new T();
            DataClass = Data.GetClass();
            InnerSize = Data.GetBufferSize();
            OuterSize = InnerSize + 4;
        }

        public AnyDataHolder(T data)
        {
            Data = data;
            DataClass = Data.GetClass();
            InnerSize = Data.GetBufferSize();
            OuterSize = InnerSize + 4;
        }

        public AnyDataHolder(Stream s)
        {
            Data = new T();
            FromStream(s);
        }
        public override void ToBuffer(Stream s)
        {
            Helper.WriteString(s, DataClass);
            Helper.WriteU32(s, OuterSize);
            Helper.WriteU32(s, InnerSize);
            Data.ToBuffer(s);
        }

        public override void FromStream(Stream s)
        {
            base.FromStream(s);
            Data.FromStream(s);
        }

        public string GetClass()
        {
            return Data.GetClass();
        }

        public uint GetBufferSize()
        {
            MemoryStream m = new MemoryStream();
            ToBuffer(m);
            return (uint)m.Length;
        }

    }
}
