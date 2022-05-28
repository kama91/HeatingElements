using System;
using System.Drawing;

namespace HeatingElements.Common.Extensions
{
    public static class IntExtension
    {
        public static Color ToColor(this int value)
        {
            switch (value)
            {
                case -1:
                    return Color.FromArgb(0, 176, 80);
                case 0:
                    return Color.FromArgb(240, 0, 0);
                case 1:
                    return Color.FromArgb(127, 127, 127);
            }

            throw new NotImplementedException();
        }
    }
}
