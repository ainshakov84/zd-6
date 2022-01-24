using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace zd_6
{


    class WeatherControl:DependencyObject
    {
        public static readonly DependencyProperty TemperatureProperty;
        private string wind;
        private int windvelocity;
        private int wheathertype;
        enum whenwheathertype
        {
            sunny = 0,
            cloudy = 1,
            rainy = 2,
            snowly = 3,
        }
        public int Temperature
        {
            get => (int)GetValue(TemperatureProperty);
            set => SetValue(TemperatureProperty, value);
        }
        public string Wind
        {
            get => wind;
            set => wind = value;
        }
        public int Windvelocity
        {
            get => windvelocity;
            set => windvelocity = value;
        }
        public int Wheathertype
        {
            get => wheathertype;
            set => wheathertype = value;
        }
        public WeatherControl(int temperature, string wind, int windvelocity, int wheathertype)
        {
            this.Temperature = temperature;
            this.Wind = wind;
            this.Windvelocity = windvelocity;
            this.Wheathertype = wheathertype;
        }
        static WeatherControl()
        {
            TemperatureProperty = DependencyProperty.Register(
                nameof(Temperature),
                typeof(int),
                typeof(WeatherControl),
                new FrameworkPropertyMetadata(
                    0,
                    FrameworkPropertyMetadataOptions.AffectsMeasure |
                    FrameworkPropertyMetadataOptions.AffectsRender |
                    FrameworkPropertyMetadataOptions.Journal,
                    null,
                    new CoerceValueCallback(CoerceTemperature)),
                new ValidateValueCallback(ValidateTemperature));
        }
        private static bool ValidateTemperature(object value)
        {
            int t = (int)value;
            if (t >= -50 && t <= 50)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private static object CoerceTemperature(DependencyObject d, object baseValue)
        {
            int t = (int)baseValue;
            if (t >= 50 && t <= 50)
            { return t; }
            else
            {
                if (t < -50)
                {
                    return -50;
                }
                return 50;
            }
        }
        public string Print()
        {
            return $"{Temperature} {Wind} {Windvelocity} {Wheathertype}";
        }
    }
}
