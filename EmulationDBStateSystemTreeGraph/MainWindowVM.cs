using RealTimeGraphX;
using RealTimeGraphX.DataPoints;
using RealTimeGraphX.Renderers;
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
using System.Windows.Media;

//namespace RealTimeGraphX.WPF.Demo
namespace WpfApp_10_ICommand
{
    public class MainWindowVM// : INotifyPropertyChanged
    {
        static double z = 0;

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyNameVal = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyNameVal));

        //private WpfGraphController<TimeSpanDataPoint, DoubleDataPoint> _controller;
        private WpfGraphController<TimeSpanDataPoint, DoubleDataPoint> _multiController; //{ get; set; }

        public WpfGraphController<TimeSpanDataPoint, DoubleDataPoint> MultiController //{ get; set; }
        {
            get => _multiController;
            set
            {
                _multiController = value;
                OnPropertyChanged();
            }
        }



        private Random r = new Random();

        //public WpfGraphController<TimeSpanDataPoint, DoubleDataPoint> MultiController { get; set; }

        public MainWindowVM()
        {

            MultiController = new WpfGraphController<TimeSpanDataPoint, DoubleDataPoint>();
            MultiController.Range.MinimumY = 0;
            MultiController.Range.MaximumY = 1080;
            MultiController.Range.MaximumX = TimeSpan.FromSeconds(10);
            MultiController.Range.AutoY = true;

            MultiController.DataSeriesCollection.Add(new WpfGraphDataSeries()
            {
                Name = "Series 1",
                Stroke = Colors.Red,
            });

            MultiController.DataSeriesCollection.Add(new WpfGraphDataSeries()
            {
                Name = "Series 2",
                Stroke = Colors.Green,
            });

            MultiController.DataSeriesCollection.Add(new WpfGraphDataSeries()
            {
                Name = "Series 3",
                Stroke = Colors.Blue,
            });

            MultiController.DataSeriesCollection.Add(new WpfGraphDataSeries()
            {
                Name = "Series 4",
                Stroke = Colors.Yellow,
            });

            MultiController.DataSeriesCollection.Add(new WpfGraphDataSeries()
            {
                Name = "Series 5",
                Stroke = Colors.Gray,
            });

            Start();
            //Application.Current.MainWindow.ContentRendered += (_, __) => Start();
        }

        private void Start()
        {
            Task.Factory.StartNew(() =>
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();

                while (true)
                {
                    z += 0.1;
                    //var y = System.Windows.Forms.Cursor.Position.Y;
                    var y = (int)(500+ ((r.Next()%10)*10 + 100) * Math.Sin(2*z));// System.Windows.Forms.Cursor.Position.Y;
                    var y2 = (int)(300 + ((r.Next()%10)*10 + 100) * Math.Sin(z) + 200 * Math.Cos(2*z));// System.Windows.Forms.Cursor.Position.Y;
                    var y3 = (int)(400 + ((r.Next()%10)*10 + 100) * Math.Sin(-4*z) + 100 * Math.Sin(3*z));// System.Windows.Forms.Cursor.Position.Y;
                    //var y4 = (int)(200 + 100 * Math.Sin(5*z));// System.Windows.Forms.Cursor.Position.Y;
                    //var y5 = (int)(700 + 200 * Math.Sin(2*z));// System.Windows.Forms.Cursor.Position.Y;

                    List<DoubleDataPoint> yy = new List<DoubleDataPoint>()
                    {
                        y,
                        y2 + 20,
                        y3 + 40,
                        //y4 + 60,
                        //y5 + 80,
                    };

                    var x = watch.Elapsed;

                    List<TimeSpanDataPoint> xx = new List<TimeSpanDataPoint>()
                    {
                        x,
                        x,
                        x,
                        //x,
                        //x
                    };

                    MultiController.PushData(xx, yy);

                    Thread.Sleep(30);
                }
            }, TaskCreationOptions.LongRunning);
        }

        private Color GetRandomColor()
        {
            return Color.FromRgb((byte)r.Next(50, 255), (byte)r.Next(50, 255), (byte)r.Next(50, 255));
        }
    }
}
