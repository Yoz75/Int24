
using System;
namespace Int24
{
    public struct Int24
    {

        public const int MAX_VALUE = 8388607;
        public const int MIN_VALUE = -8388608;
        private const byte MIDDLE_BITS_SHIFT = 8;
        private const byte HIGH_BITS_SHIFT = 16;
        private readonly byte LowBits = 0;
        private readonly byte MiddleBits = 0;
        private readonly sbyte HighBits = 0;


        public Int24(long value)
        {

            if (value < MIN_VALUE || value > MAX_VALUE)
            {
                throw new ArgumentOutOfRangeException($"Value is {value}. It is unacceptable value");
            }

            //В Int24 3 байта, так что берём три последних байта из числа и используем
            //побитовые сдвиги для того, чтобы в каждом поле оказался свой байт.
            LowBits = (byte)value;
            MiddleBits = (byte)(value >> MIDDLE_BITS_SHIFT);
            HighBits = (sbyte)(value >> HIGH_BITS_SHIFT);
        }

        public Int24(sbyte highBits, byte middleBits, byte lowBits)
        {
            HighBits = highBits;
            MiddleBits = middleBits;
            LowBits = lowBits;
        }

        public int GetIntValue()
        {
            //"Складываем" при помощи побитового или
            //значения из  наших 3 байтов, попутно возвращая их на свои места.
            return LowBits | MiddleBits << MIDDLE_BITS_SHIFT | HighBits << HIGH_BITS_SHIFT;
        }

        public override int GetHashCode()
        {
            return GetIntValue();
        }

        public override string ToString()
        {
            return GetIntValue().ToString();
        }

        public static implicit operator Int24(sbyte value) => new Int24(value);

        public static implicit operator Int24(short value) => new Int24(value);

        public static implicit operator Int24(int value) => new Int24(value);
        public static explicit operator int(Int24 value) => value.GetIntValue();

        public static implicit operator Int24(long value) => new Int24(value);
        public static explicit operator long(Int24 value) => value.GetIntValue();

        public static bool operator ==(Int24 left, Int24 right)
        {
            return left.GetIntValue() == right.GetIntValue();
        }

        public static bool operator !=(Int24 left, Int24 right)
        {
            return !(left == right);
        }

        public static Int24 operator -(Int24 left, Int24 right)
        {
            return left.GetIntValue() - right.GetIntValue();
        }
        
        public static Int24 operator +(Int24 number)
        {
            return number.GetIntValue();
        }

        public static Int24 operator +(Int24 left, Int24 right)
        {
            return left.GetIntValue() + right.GetIntValue();
            
        }

        public static bool operator <(Int24 left, Int24 right)
        {
            return left.GetIntValue() < right.GetIntValue();
        }

        public static bool operator >(Int24 left, Int24 right)
        {
            return left.GetIntValue() > right.GetIntValue();
        }

        public static bool operator <=(Int24 left, Int24 right) 
        { 
            return (left.GetIntValue() < right.GetIntValue() || left == right);
        }

        public static bool operator >=(Int24 left, Int24 right)
        {
            return left.GetIntValue() > right.GetIntValue() || left == right;
        }

        public static Int24 operator -(Int24 number)
        {
            return -number.GetIntValue();
        }

        public static Int24 operator *(Int24 left, Int24 right)
        {
            return right.GetIntValue() * left.GetIntValue();
        }

        public static Int24 operator /(Int24 left, Int24 right)
        {
            return right.GetIntValue() / left.GetIntValue();
        }

        public static Int24 operator %(Int24 left, Int24 right)
        {
            return left.GetIntValue() % right.GetIntValue();
        }

        public static Int24 operator ++(Int24 number) 
        {
            return number.GetIntValue() + 1;
        }

        public static Int24 operator --(Int24 number)
        {
            return number.GetIntValue() - 1;
        }

        public static Int24 operator >>(Int24 number, int shift)
        {
            return number.GetIntValue() >> shift;
        }

        public static Int24 operator <<(Int24 number, int shift)
        {
            return number.GetIntValue() >> shift;
        }

        public static Int24 operator >>>(Int24 number, int shift)
        {
            return number.GetIntValue() >>> shift;
        }

        public static Int24 operator ~(Int24 number)
        {
            return ~number.GetIntValue();
        }

    }
}
