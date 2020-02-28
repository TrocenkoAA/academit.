using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Convertor.Views
{
    public interface IView
    {
        void SetTemperature(double value);

        double InputDegree { get; }
        int InputIndexSelected { get; }
        int OutputIndexSelected { get; }

        event EventHandler<EventArgs> SetedTemperature;
    }
}
