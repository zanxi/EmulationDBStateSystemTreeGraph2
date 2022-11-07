using RealTimeGraphX.DataPoints;
using RealTimeGraphX.Renderers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace RealTimeGraphX.WPF.Demo
{
    public class MainWindowVM
    {
        private Random r = new Random();
                
        public WpfGraphController<TimeSpanDataPoint, DoubleDataPoint> MultiController { get; set; }
                
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
                    var y = System.Windows.Forms.Cursor.Position.Y;

                    List<DoubleDataPoint> yy = new List<DoubleDataPoint>()
                    {
                        y,
                        y + 20,
                        y + 40,
                        y + 60,
                        y + 80,
                    };

                    var x = watch.Elapsed;

                    List<TimeSpanDataPoint> xx = new List<TimeSpanDataPoint>()
                    {
                        x,
                        x,
                        x,
                        x,
                        x
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
