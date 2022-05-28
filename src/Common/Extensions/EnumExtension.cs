using System;
using System.Drawing;

namespace HeatingElements.Common.Extensions
{
    public static class EnumExtension
    {
        public static Color ToColor(this State state)
        {
            switch (state)
            {
                case State.Alarm:
                    return Color.FromArgb(240, 0, 0);
                case State.Warning:
                    return Color.FromArgb(255, 255, 0);
                case State.GoodOrOff:
                    return Color.FromArgb(0, 176, 80);
            }

            throw new NotImplementedException();
        }
    }
}