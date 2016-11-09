using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CryptoRandom
{
    public static class Generator
    {
        private const int INT_MAX_BOUNDS = 4096;
        private static RNGCryptoServiceProvider _generator = new RNGCryptoServiceProvider();
        private static byte[] _intArray = new byte[INT_MAX_BOUNDS];
        private static int _currentIndex = 0;

        // pilfered from .NET Source code
        // https://referencesource.microsoft.com/#mscorlib/system/random.cs,bb77e610694e64ca
        private static int InternalSample()
        {
            int retVal = 0;
            lock(_generator)
            {
                if ( _currentIndex >= INT_MAX_BOUNDS)
                {
                    _generator.GetBytes(_intArray);
                    _currentIndex = 0;
                }
                retVal = BitConverter.ToInt32(_intArray, _currentIndex);
                _currentIndex += 4;
            }
            if (retVal < 0)
            {
                retVal += int.MaxValue;
            }
            return retVal;
        }

        private static double Sample()
        {
            return (InternalSample() * (1.0 / Int32.MaxValue));
        }

        public static int Next()
        {
            return InternalSample();
        }

        public static int Next(int maxValue)
        {
            if (maxValue < 0)
            {
                throw new ArgumentOutOfRangeException("maxValue", "maxValue must be positive");
            }
            return (int)(Sample() * maxValue);
        }

        public static int Next(int minValue, int maxValue)
        {
            if (minValue > maxValue)
            {
                throw new ArgumentOutOfRangeException("minValue", "minValue must be less than maxValue");
            }

            long range = (long)maxValue - minValue;
            if (range <= (long)Int32.MaxValue)
            {
                return ((int)(Sample() * range) + minValue);
            }
            else
            {
                throw new ArgumentException("Range is too large");
            }
        }

        public static void NextBytes(byte[] buffer)
        {
            if (buffer == null) throw new ArgumentNullException("buffer");
            lock(_generator)
            {
                _generator.GetBytes(buffer);
            }
        }
    }
}
