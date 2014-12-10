using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mognetwork
{
    public class Packet
    {
        private List<byte> datas;
        private int reader = 0;
        private byte[] formatted = null;

        public Packet()
        {
            datas = new List<byte>();
        }

        public Packet(List<byte> datas)
        {
            this.datas = datas;
        }

        public void format()
        {
            if (formatted != null)
                return;
            formatted = datas.ToArray();
        }

        public void addBool(bool b)
        {
            datas.AddRange(BitConverter.GetBytes(b));
        }

        public bool getBool()
        {
            format();
            bool ret = BitConverter.ToBoolean(formatted, reader);
            reader += sizeof(bool);
            return ret;
        }

        public void addChar(char c)
        {
            datas.Add(Convert.ToByte(c));
        }

        public char getChar()
        {
            format();
            char ret = (char)formatted[reader];
            reader += 1;
            return ret;
        }

        public void addDouble(double d)
        {
            datas.AddRange(BitConverter.GetBytes(d));
        }

        public double getDouble()
        {
            format();
            double ret = BitConverter.ToDouble(formatted, reader);
            reader += sizeof(double);
            return ret;
        }

        public void addInt16(Int16 i)
        {
            datas.AddRange(BitConverter.GetBytes(i));
        }

        public Int16 getInt16()
        {
            format();
            Int16 ret = BitConverter.ToInt16(formatted, reader);
            reader += sizeof(Int16);
            return ret;
        }

        public void addInt32(Int32 i)
        {
            datas.AddRange(BitConverter.GetBytes(i));
        }

        public Int32 getInt32()
        {
            format();
            Int32 ret = BitConverter.ToInt32(formatted, reader);
            reader += sizeof(Int32);
            return ret;
        }

        public void addInt64(Int64 i)
        {
            datas.AddRange(BitConverter.GetBytes(i));
        }

        public Int64 getInt64()
        {
            format();
            Int64 ret = BitConverter.ToInt64(formatted, reader);
            reader += sizeof(Int64);
            return ret;
        }

        public void addFloat(float f)
        {
            datas.AddRange(BitConverter.GetBytes(f));
        }

        public float getFloat()
        {
            format();
            float ret = BitConverter.ToSingle(formatted, reader);
            reader += sizeof(float);
            return ret;
        }

        public List<byte> getDatas()
        {
            return datas;
        }

        public void addString(String s)
        {
            this.addInt32(Convert.ToInt32(s.Length));
            datas.AddRange(Encoding.ASCII.GetBytes(s));
        }

        public String getString()
        {
            format();
            Int32 size = getInt32();
            String ret = "";
            for (int i = 0; i < size; ++i)
                ret += getChar();
            return ret;
        }
    }
}
