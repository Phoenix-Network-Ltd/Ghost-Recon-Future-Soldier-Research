using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuazalWV
{
    public interface IData
    {
        void FromStream(Stream s);
        void ToBuffer(Stream s);
        string GetClass();
        uint GetBufferSize();
    }
}