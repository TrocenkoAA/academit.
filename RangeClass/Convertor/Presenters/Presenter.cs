using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Convertor.Models;
using Convertor.Views;

namespace Convertor.Presenters
{
    public class Presenter
    {
        private Model _model = new Model();
        private IView _view;

        public Presenter(IView view)
        {
            _view = view;
            _view.SetedTemperature += OnSetTemperature;
        }

        private void OnSetTemperature(object sender, EventArgs e)
        {
            OnIndexSelected(_view.InputIndexSelected);
            RefreshView(_view.OutputIndexSelected);
        }

        private void OnIndexSelected(int InputIndex)
        {
            if (InputIndex == 0)
            {
                _model.ValueCelsius = _view.InputDegree;
            }
            else if (InputIndex == 1)
            {
                _model.ValueFahrenheit = _view.InputDegree;
            }
            else
            {
                _model.ValueKalvin = _view.InputDegree;
            }
        }

        private void RefreshView(int OutputIndex)
        {
            if (OutputIndex == 0)
            {
                _view.SetTemperature(_model.ValueCelsius);
            }
            else if (OutputIndex == 1)
            {
                _view.SetTemperature(_model.ValueFahrenheit);
            }
            else
            {
                _view.SetTemperature(_model.ValueKalvin);
            }
        }
    }
}
