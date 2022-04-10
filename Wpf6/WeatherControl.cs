using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Wpf6
{
    enum Precipitation
    {
        sunny,
        cloudy,
        rain,
        snow
    }
    class WeatherControl : DependencyObject
    {
        private Precipitation precipitation;
        private string windDirection;
        private int windSpeed;

        public string WindDirection { get; set; }
        public int WindSpeed { get; set; }

        public WeatherControl(string windDir, int windSp, Precipitation precipitation )
        {
            this.WindDirection = windDir;
            this.windSpeed = windSp;
            this.precipitation = precipitation;
        }
        public static readonly DependencyProperty TempProperty;
        public int Temp
        {
            get=>(int) GetValue(TempProperty);
            set=>SetValue(TempProperty, value);
        }
        static WeatherControl()
        {
            TempProperty = DependencyProperty.Register(
            nameof(Temp),
            typeof(int),
            typeof(WeatherControl),
            new FrameworkPropertyMetadata(
                0,
                FrameworkPropertyMetadataOptions.AffectsArrange |
                FrameworkPropertyMetadataOptions.AffectsRender,
                null,
                new CoerceValueCallback(CoerceTemp)),
            new ValidateValueCallback(ValidateTemp));
        }

        private static bool ValidateTemp(object value)
        {
            int v = (int)value;
            if (v >= -50 && v<= 50)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private static object CoerceTemp(DependencyObject d, object baseValue)
        {
            int v = (int)baseValue;
            if (v >= -50 && v <= 50)
            {
                return v;
            }
            else
            {
                return null;
            }
        }
    }
}
