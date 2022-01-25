using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuazalWV
{
    public class GameConfigContent : IData
    {
        public TitleContent Content { get; set; }
        public string Str1 { get; set; }

        public GameConfigContent()
        {
            Content = new TitleContent();
            Str1 = "GameConfigContentStr1";
        }

        public GameConfigContent(Stream s)
        {
            FromStream(s);
        }

        public void FromStream(Stream s)
        {
            throw new NotImplementedException();
        }

        public uint GetBufferSize()
        {
            MemoryStream m = new MemoryStream();
            ToBuffer(m);
            return (uint)m.Length;
        }

        public string GetClass()
        {
            return "GameConfigContent";
        }

        public void ToBuffer(Stream s)
        {
            Content.ToBuffer(s);
            Helper.WriteString(s, Str1);
        }
    }
}
