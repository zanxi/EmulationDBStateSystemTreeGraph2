using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Bornander.UI.ViewModels;
using WpfApp_10_ICommand.GenerateDB;

namespace Bornander.UI.ValueConverters
{
    [ValueConversion(typeof(TreeNodeViewModel), typeof(ImageSource))]
    public class TreeNodeToImageConverter : IValueConverter
    {
        static TreeNodeToImageConverter()
        {
            
        }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            //return Binding.DoNothing;

            var viewModel = value as TreeNodeViewModel;
            if (viewModel == null)
                return Binding.DoNothing;
            //if (viewModel.BitmapName == "") return Binding.DoNothing;
            //if (!File.Exists(viewModel.BitmapName)) return Binding.DoNothing;
            //return new BitmapImage(new Uri(viewModel.BitmapName));            

            if (viewModel.typeVar == DataStatic.typeVar_boolean)
                return new BitmapImage(new Uri(@"C:\_downloads__\cred.png"));
            if (viewModel.typeVar == DataStatic.typeVar_real)
                return new BitmapImage(new Uri(@"C:\_downloads__\cblue.png"));
            if (viewModel.typeVar == DataStatic.typeVar_integer)
                return new BitmapImage(new Uri(@"C:\_downloads__\cyellow.png"));
            else return Binding.DoNothing;
        }


        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return Binding.DoNothing;
            //throw new NotImplementedException();
        }
    }
}
