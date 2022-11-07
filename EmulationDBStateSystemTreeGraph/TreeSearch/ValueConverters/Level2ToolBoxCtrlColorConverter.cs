using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Bornander.UI.ViewModels;
using WpfApp_10_ICommand.GenerateDB;

namespace Bornander.UI.ValueConverters
{
    [ValueConversion(typeof(TreeNodeViewModel), typeof(ImageSource))]
    internal class Level2ToolBoxCtrlColorConverter : IValueConverter
    {

        static Level2ToolBoxCtrlColorConverter()
        {

        }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            //return Binding.DoNothing;

            var viewModel = value as TreeNodeViewModel;
            if (viewModel == null)
                return Binding.DoNothing;
            //if (viewModel.BitmapName == "") return Binding.DoNothing;

            //if (viewModel.typeVar == DataStatic.typeVar_boolean)
            //    return new SolidColorBrush(Colors.Black);
            //if (viewModel.typeVar == DataStatic.typeVar_real)
            //    return new SolidColorBrush(Colors.Red);
            //if (viewModel.typeVar == DataStatic.typeVar_integer)
            //    return new SolidColorBrush(Colors.Yellow);
            //else return new SolidColorBrush(Colors.LightGreen);


            return Binding.DoNothing;
            //return ToolBox.ColorBackground(ToolBox._ThemeName);



        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return Binding.DoNothing;
            //throw new NotImplementedException();
        }
    }

    [ValueConversion(typeof(TreeNodeViewModel), typeof(ImageSource))]
    internal class Level2ToolBoxCtrlColorConverterFore : IValueConverter
    {

        static Level2ToolBoxCtrlColorConverterFore()
        {

        }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            //return Binding.DoNothing;

            var viewModel = value as TreeNodeViewModel;
            if (viewModel == null)
                return Binding.DoNothing;
            
            if(viewModel.typeVar==DataStatic.typeVar_boolean)
            return new SolidColorBrush(Colors.Gray);
            if (viewModel.typeVar == DataStatic.typeVar_real)
                return new SolidColorBrush(Colors.Red);
            if (viewModel.typeVar == DataStatic.typeVar_integer)
                return new SolidColorBrush(Colors.Black);
            else return new SolidColorBrush(Colors.LightGreen);

        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return Binding.DoNothing;
            //throw new NotImplementedException();
        }
    }

}
