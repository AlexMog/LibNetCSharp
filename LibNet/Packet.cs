using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mognetwork
{
    class Packet
    {
        private List<byte> datas;
        private int reader = 0;
        private byte[] formatted;

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
            formatted = datas.ToArray();
        }

        public void addBool(bool b)
        {
            datas.AddRange(new List<byte>(BitConverter.GetBytes(b)));
        }

        public bool getBool()
        {
            bool ret = BitConverter.ToBoolean(formatted, reader);
            reader += sizeof(bool);
            return ret;
        }

        public void addChar(char c)
        {
            datas.AddRange(new List<byte>(BitConverter.GetBytes(c)));
        }

        public char getChar()
        {
            char ret = BitConverter.ToChar(formatted, reader);
            reader += sizeof(bool);
            return ret;
        }

        public void addDouble(double d)
        {
            datas.AddRange(new List<byte>(BitConverter.GetBytes(d)));
        }

        public double getDouble()
        {
            double ret = BitConverter.ToDouble(formatted, reader);
            reader += sizeof(double);
            return ret;
        }

        public void addInt16(Int16 i)
        {
            datas.AddRange(new List<byte>(BitConverter.GetBytes(i)));
        }

        public Int16 getInt16()
        {
            Int16 ret = BitConverter.ToInt16(formatted, reader);
            reader += sizeof(Int16);
            return ret;
        }

        public void addInt32(Int32 i)
        {
            datas.AddRange(new List<byte>(BitConverter.GetBytes(i)));
        }

        public Int32 getInt32()
        {
            Int32 ret = BitConverter.ToInt32(formatted, reader);
            reader += sizeof(Int32);
            return ret;
        }

        public void addInt64(Int64 i)
        {
            datas.AddRange(new List<byte>(BitConverter.GetBytes(i)));
        }

        public Int64 getInt64()
        {
            Int64 ret = BitConverter.ToInt64(formatted, reader);
            reader += sizeof(Int64);
            return ret;
        }

        public void addFloat(float f)
        {
            datas.AddRange(new List<byte>(BitConverter.GetBytes(f)));
        }

        public float getFloat()
        {
            float ret = BitConverter.ToSingle(formatted, reader);
            reader += sizeof(float);
            return ret;
        }

        public List<byte> getDatas()
        {
            return datas;
        }
    }
}
