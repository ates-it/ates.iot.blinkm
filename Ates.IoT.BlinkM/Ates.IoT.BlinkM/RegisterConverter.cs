using System;
using Windows.UI;

namespace Ates.IoT.BlinkM
{
    /// <summary>
    /// Helpers methods for reading and writing from
    /// the BlinkM registers.
    /// </summary>
    public static class RegisterConverter
    {
        public static Color ToRgbColor(byte[] registerValue)
        {
            if (registerValue.Length == 3)
            {
                return ColorHelper.FromArgb(0, registerValue[0], registerValue[1], registerValue[2]);
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(registerValue));
            }

        }
    }
}
