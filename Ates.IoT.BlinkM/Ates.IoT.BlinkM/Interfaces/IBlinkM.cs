using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.I2c;
using Windows.UI;

namespace Ates.IoT.BlinkM.Interfaces
{
    public interface IBlinkM : IDisposable
    {
        void FadeToColor(Color color);
    }
}
