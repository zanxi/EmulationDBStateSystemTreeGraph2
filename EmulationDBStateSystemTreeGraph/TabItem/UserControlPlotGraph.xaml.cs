using RealTimeGraphX;
using RealTimeGraphX.DataPoints;
using RealTimeGraphX.WPF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;



namespace WpfApp_10_ICommand.TabItem
{
    /// <summary>
    /// Логика взаимодействия для UserControlPlotGraph.xaml
    /// </summary>
    public partial class UserControlPlotGraph : UserControl
    {
        
        public UserControlPlotGraph()
        {
            InitializeComponent();
            //Plot_MainWindowVM_();
            Loaded += UserControlPlotGraph_Loaded;            
        }

        private void UserControlPlotGraph_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = new MainWindowVM();
        }


    }
}
