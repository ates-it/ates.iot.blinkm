using Ates.IoT.BlinkM.Interfaces;
using Ates.IoT.BlinkM.Exceptions;
using System;
using System.Threading.Tasks;
using Windows.Devices.Enumeration;
using Windows.Devices.I2c;
using Windows.UI;
using System.Diagnostics;
using Windows.Foundation;

namespace Ates.IoT.BlinkM
{
    public class BlinkM : IBlinkM
    {

        /// <summary>
        /// Device I2C Bus
        /// </summary>
        private string i2cBusName;

        /// <summary>
        /// Device I2C Address
        /// </summary>
        private const byte BlinkMI2cAddress = 0x09;

        /// <summary>
        /// Used to signal that the device is properly initialized and ready to use
        /// </summary>
        private bool available = false;

        /// <summary>
        /// I2C Device
        /// </summary>
        private I2cDevice i2c;

        /// <summary>
        /// Constructs BlinkM with I2C bus identified
        /// </summary>
        /// <param name="i2cBusName">
        /// The bus name to provide to the enumerator
        /// </param>
        public BlinkM(string i2cBusName)
        {
            this.i2cBusName = i2cBusName;
        }

        /// <summary>
        /// Gets the current color in RGB
        /// </summary>
        /// <returns>
        /// Color as Windows.Ui.Color
        /// </returns>
        public Color CurrentColor
        {
            get
            {
                if (!this.available)
                {
                    throw new BlinkMNotInitializedException();
                }

                byte[] readData = new byte[3];

                this.i2c.WriteRead(new byte[] { BlinkMRegister.GetRGB }, readData);
                var col = RegisterConverter.ToRgbColor(readData);
                return col;
            }
        }

        /// <summary>
        /// Initialize the BlinkM device.
        /// </summary>
        /// <returns>
        /// Async operation object.
        /// </returns>
        public IAsyncOperation<bool> BeginAsync()
        {
            return this.BeginAsyncHelper().AsAsyncOperation<bool>();
        }

        /// <summary>
        /// Private helper to initialize the BlinkM device.
        /// </summary>
        /// <remarks>
        /// Setup and instantiate the I2C device object for the BlinkM.
        /// </remarks>
        /// <returns>
        /// Task object.
        /// </returns>
        private async Task<bool> BeginAsyncHelper()
        {
            string advancedQuerySyntax = I2cDevice.GetDeviceSelector(i2cBusName);
            DeviceInformationCollection deviceInformationCollection = await DeviceInformation.FindAllAsync(advancedQuerySyntax);
            string deviceId = deviceInformationCollection[0].Id;

            // Establish an I2C connection to the BlinkM
            I2cConnectionSettings blinkmConnection = new I2cConnectionSettings(BlinkM.BlinkMI2cAddress);
            blinkmConnection.BusSpeed = I2cBusSpeed.FastMode;
            //blinkmConnection.SharingMode = I2cSharingMode.Shared;

            this.i2c = await I2cDevice.FromIdAsync(deviceId, blinkmConnection);

            // Test to see if the I2C devices are available.
            if (null == this.i2c)
            {
                this.available = false;
            }
            else
            {
                byte[] currentColorData = new byte[3];

                try
                {
                    this.i2c.WriteRead(new byte[] { BlinkMRegister.GetRGB }, currentColorData);
                    this.available = true;
                }
                catch
                {
                    this.available = false;
                }
            }

            return this.available;
        }

        public void Dispose()
        {
            Debug.WriteLine("Disposing");
        }

        public void FadeToColor(Color color)
        {
            if (!this.available)
            {
                throw new BlinkMNotInitializedException();
            }
            byte[] writeBuff = { BlinkMRegister.RGBFade, color.R, color.G, color.B };
            this.i2c.Write(writeBuff);
        }
    }
}
