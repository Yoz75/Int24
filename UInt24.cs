
using System;
namespace Int24
{
    public struct UInt24
    {

        public const int MAX_VALUE = 16777215;
        public const int MIN_VALUE = 0;
        private const byte MIDDLE_BITS_SHIFT = 8;
        private const byte HIGH_BITS_SHIFT = 16;
        private readonly byte LowBits = 0;
        private readonly byte MiddleBits = 0;
        private readonly byte HighBits = 0;


        public UInt24(ulong value)
        {

            if (value < MIN_VALUE || value > MAX_VALUE)
            {
                throw new ArgumentOutOfRangeException($"Value is {value}. It is unacceptable value");
            }

            //В Int24 3 байта, так что берём три последних байта из числа и используем
            //побитовые сдвиги для того, чтобы в каждом поле оказался свой байт.
            LowBits = (byte)value;
            MiddleBits = (byte)(value >> MIDDLE_BITS_SHIFT);
            HighBits = (byte)(value >> HIGH_BITS_SHIFT);
        }

        public UInt24(byte highBits, byte middleBits, byte lowBits)
        {
            HighBits = highBits;
            MiddleBits = middleBits;
            LowBits = lowBits;
        }

        public uint GetUintValue()
        {
            //"Складываем" при помощи побитового или
            //значения из  наших 3 байтов, попутно возвращая их на свои места.

            return (uint)(LowBits | MiddleBits << MIDDLE_BITS_SHIFT | HighBits << HIGH_BITS_SHIFT);
        }

        public override int GetHashCode()
        {
            //Так как у  нас 24 битное число, то даже беззнаковая версия этого числа
            //всегда уместится в 32 битный int, поэтому можно не проделывать таких выкрутасов,
            //как с uint или ulong
            return (int)GetUintValue();
        }

        public override string ToString()
        {
            return GetUintValue().ToString();
        }

        public static implicit operator UInt24(byte value) => new UInt24(value);

        public static implicit operator UInt24(ushort value) => new UInt24(value);

        public static implicit operator UInt24(uint value) => new UInt24(value);
        public static explicit operator uint(UInt24 value) => value.GetUintValue();

        public static implicit operator UInt24(ulong value) => new UInt24(value);
        public static explicit operator ulong(UInt24 value) => value.GetUintValue();

        public static bool operator ==(UInt24 left, UInt24 right)
        {
            return left.GetUintValue() == right.GetUintValue();
        }

        public static bool operator !=(UInt24 left, UInt24 right)
        {
            return !(left == right);
        }

        public static UInt24 operator -(UInt24 left, UInt24 right)
        {
            return left.GetUintValue() - right.GetUintValue();
        }

        public static UInt24 operator +(UInt24 number)
        {
            return number.GetUintValue();
        }

        public static UInt24 operator +(UInt24 left, UInt24 right)
        {
            return left.GetUintValue() + right.GetUintValue();

        }

        public static bool operator <(UInt24 left, UInt24 right)
        {
            return left.GetUintValue() < right.GetUintValue();
        }

        public static bool operator >(UInt24 left, UInt24 right)
        {
            return left.GetUintValue() > right.GetUintValue();
        }

        public static bool operator <=(UInt24 left, UInt24 right)
        {
            return (left.GetUintValue() < right.GetUintValue() || left == right);
        }

        public static bool operator >=(UInt24 left, UInt24 right)
        {
            return left.GetUintValue() > right.GetUintValue() || left == right;
        }


        public static UInt24 operator *(UInt24 left, UInt24 right)
        {
            return right.GetUintValue() * left.GetUintValue();
        }

        public static UInt24 operator /(UInt24 left, UInt24 right)
        {
            return right.GetUintValue() / left.GetUintValue();
        }

        public static UInt24 operator %(UInt24 left, UInt24 right)
        {
            return left.GetUintValue() % right.GetUintValue();
        }

        public static UInt24 operator ++(UInt24 number)
        {
            return number.GetUintValue() + 1;
        }

        public static UInt24 operator --(UInt24 number)
        {
            return number.GetUintValue() - 1;
        }

        public static UInt24 operator >>(UInt24 number, int shift)
        {
            return number.GetUintValue() >> shift;
        }

        public static UInt24 operator <<(UInt24 number, int shift)
        {
            return number.GetUintValue() >> shift;
        }

        public static UInt24 operator >>>(UInt24 number, int shift)
        {
            return number.GetUintValue() >>> shift;
        }

        public static UInt24 operator ~(UInt24 number)
        {
            return ~number.GetUintValue();
        }

    }
}
