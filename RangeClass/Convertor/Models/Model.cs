using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Convertor.Models
{
    public class Model
    {
        private double _valueFahrenheit;
        private double _valueCelsius;
        private double _valueKalvin;

        public double ValueFahrenheit
        {
            get
            {
                return _valueFahrenheit;
            }
            set
            {
                _valueFahrenheit = value;
                _valueCelsius = (_valueFahrenheit - 32) * 5 / 9;
                _valueKalvin = _valueCelsius + 273.15;
            }
        }

        public double ValueCelsius
        {
            get { return _valueCelsius; }
            set
            {
                _valueCelsius = value;
                _valueFahrenheit = _valueCelsius * 9 / 5 + 32;
                _valueKalvin = _valueCelsius + 273.15;
            }
        }

        public double ValueKalvin
        {
            get { return _valueKalvin; }
            set
            {
                _valueKalvin = value;
                _valueCelsius = _valueKalvin - 273.15;
                _valueFahrenheit = _valueCelsius * 9 / 5 + 32;
            }
        }

    }
}
