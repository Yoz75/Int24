
namespace Int24
{
    public struct Int24
    {

        public const int MAX_VALUE = 8388607;
        public const int MIN_VALUE = -8388608;
        private byte LowBits = 0;
        private byte MiddleBits = 0;
        private byte HighBits = 0;


        public Int24(long value)
        {

            if (value < MIN_VALUE || value > MIN_VALUE)
            {

            }

            //В Int24 3 байта, так что берём три последних байта из числа и используем
            //побитовые сдвиги для того, чтобы в каждом поле оказался свой байт.
            LowBits = (byte)value;
            MiddleBits = (byte)(value >> 8);
            HighBits = (byte)(value >> 16);
        }

        public int GetIntValue()
        {
            //"Складываем" при помощи побитового или
            //значения из  наших 3 байтов, попутно возвращая их на свои места.
            return LowBits | MiddleBits << 8 | HighBits << 16;
        }
        public override string ToString()
        {
            return GetIntValue().ToString();
        }

        public static implicit operator Int24(byte value) => new Int24(value);

        public static implicit operator Int24(short value) => new Int24(value);

        public static implicit operator Int24(int value) => new Int24(value);
        public static explicit operator int(Int24 value) => value.GetIntValue();

        public static implicit operator Int24(long value) => new Int24(value);
        public static explicit operator long(Int24 value) => value.GetIntValue();

        public static bool operator ==(Int24 left, Int24 right)
        {
            return left.LowBits == right.LowBits &&
                    left.MiddleBits == right.MiddleBits &&
                    left.HighBits == right.HighBits;
        }

        public static bool operator !=(Int24 left, Int24 right)
        {
            return left == right;
        }

        public static Int24 operator -(Int24 left, Int24 right)
        {
            return left.GetIntValue() - right.GetIntValue();
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

    }
}
