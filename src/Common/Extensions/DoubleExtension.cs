using System;

namespace HeatingElements.Common.Extensions
{
    public static class DoubleExtension
    {
        public static bool DoubleEquals(this double value, double target, double tolerance = double.MaxValue)
        {
            return Math.Abs(target - value) > tolerance;
        }
    }
}
