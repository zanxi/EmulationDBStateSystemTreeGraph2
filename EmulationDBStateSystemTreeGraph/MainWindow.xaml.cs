using Bornander.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using WpfApp_10_ICommand.GenerateDB;
using WpfApp_10_ICommand.TabItem;
using WpfTabCloseDemo;

namespace WpfApp_10_ICommand
{

    // 2022.07.31 https://metanit.com/sharp/wpf/22.3.php

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //int widthX = (int)(SystemInformation.PrimaryMonitorSize.Width * 0.5);
            //protected int widthY = (int)(SystemInformation.PrimaryMonitorSize.Height * 0.95);

            tree.SelectedItemChanged += Tree_SelectedItemChanged;

           Loaded += MainWindow_Loaded;
        }

        private void Tree_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            gridStateViewVal.Children.Clear();
            gridStateViewVal.Children.Add(new UserControlTabItem());

            gridStateViewPlot.Children.Clear();
            gridStateViewPlot.Children.Add(new UserControlPlotGraph());

            //gridStateViewVal.Children.Add(new Window1());
            //StateViewVal 
            //StateViewVal.
            // desienerPanel.DataContext = new UserControl();
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            SettingsViewModel svm = TreeViewCopy.TreeDBEmulation();
            tree.DataContext = svm;
            cmb.DataContext = svm;

        }
    }
}
