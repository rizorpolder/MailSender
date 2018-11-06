using GalaSoft.MvvmLight;
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace GUI.ViewModel
{
  
    public class MainViewModel : ViewModelBase
    {

        #region Value: double - Численное значение
        private double _Value;

        public double Value
        {
            get => _Value;
            set => Set(ref _Value, value);
        }

        #endregion

        public MainViewModel()
        {
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
        }
    }


    [MarkupExtensionReturnType(typeof(GreaterThen))]
    [ValueConversion(typeof(double),typeof(bool))]

    class GreaterThen : MarkupExtension, IValueConverter
    {
        public double Value { get; set; }

        public override object ProvideValue(IServiceProvider sp) => this;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (double)value > Value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}