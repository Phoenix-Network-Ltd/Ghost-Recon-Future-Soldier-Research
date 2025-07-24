using System.IO;

namespace QuazalWV
{
    public class GenericSetting : IData
    {
        public uint Uint1 { get; set; }
        public uint Uint2 { get; set; }

        public GenericSetting()
        {
            // Experimental
            Uint1 = 1;
            Uint2 = 1;
        }

        public GenericSetting(Stream s)
        {
            FromStream(s);
        }

        public void FromStream(Stream s)
        {
            Uint1 = Helper.ReadU32(s);
            Uint2 = Helper.ReadU32(s);
        }

        public uint GetBufferSize()
        {
            return 8;
        }

        public string GetClass()
        {
            return "GenericSetting";
        }

        public void ToBuffer(Stream s)
        {
            Helper.WriteU32(s, Uint1);
            Helper.WriteU32(s, Uint2);
        }
    }
}
