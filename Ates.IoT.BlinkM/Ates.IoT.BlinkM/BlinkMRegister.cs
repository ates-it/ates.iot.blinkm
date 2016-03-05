using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ates.IoT.BlinkM
{
    public static class BlinkMRegister
    {
        /// <summary>
        /// Go to RGB color now
        /// </summary>
        public const byte RGBNow = 0x6e;

        /// <summary>
        /// Fade to RGB color
        /// </summary>
        public const byte RGBFade = 0x63;

        /// <summary>
        /// Fade to HSB color
        /// </summary>
        public const byte HSBFade = 0x68;

        /// <summary>
        /// Fade to random RGB color
        /// </summary>
        public const byte RGBRandom = 0x43;

        /// <summary>
        /// Fade to random HSB color
        /// </summary>
        public const byte HSBRandom = 0x48;

        /// <summary>
        /// Play light script
        /// </summary>
        public const byte PlayScript = 0x70;

        /// <summary>
        /// Stop light script
        /// </summary>
        public const byte StopScript = 0x6f;

        /// <summary>
        /// Set fade speed
        /// </summary>
        public const byte SetFadeSpeed = 0x66;

        /// <summary>
        /// Set time adjust
        /// </summary>
        public const byte SetTimeAdjust = 0x74;

        /// <summary>
        /// Get current RGB color
        /// </summary>
        public const byte GetRGB = 0x67;

        /// <summary>
        /// Write script line
        /// </summary>
        public const byte WriteScript = 0x57;

        /// <summary>
        /// Read script line
        /// </summary>
        public const byte ReadScript = 0x52;

        /// <summary>
        /// Set script length and repeats
        /// </summary>
        public const byte SetScriptLengthRepeats = 0x4c;

        /// <summary>
        /// Set address
        /// </summary>
        public const byte SetAddress = 0x41;

        /// <summary>
        /// Get address
        /// </summary>
        public const byte GetAddress = 0x61;

        /// <summary>
        /// Set startup parameters
        /// </summary>
        public const byte SetStartup = 0x42;
    }
}
