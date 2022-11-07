using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp_10_ICommand.GenerateDB
{
    public class GenerateValue
    {

        // 4 февраля
        // http://www.cyberforum.ru/csharp-beginners/thread1786229.html
        //Насыщеный рандомный цвет - C# 27.07.2016, 13:32 

        public static double Random_(byte h)
        {
            return (new Random().Next(0, h)) * 1.0;
        }

        static Random rnd = new Random();
        public static int Random_(int h)
        {
            //rnd = new Random(h);
            int m = rnd.Next(0, h);
            return m;
        }


        private static double f11(double x)
        {
            if (x == 0)
            {
                return 1;
            }

            return Math.Sin(x) / x;
        }


        private static double f22(double x)
        {
            if (x == 0)
            {
                return 1;
            }

            return 10 * Math.Sin(x * 0.5) / x;
        }


        private static double f33(double x)
        {
            if (x == 0)
            {
                return 1;
            }

            return 0.1 * Math.Sin(x * 2) / x;
        }




        private static double f1(double x)
        {
            return 10.0 * (Math.Sin(x));
        }

        private static double f2(double x)
        {
            return 50.0 * (Math.Cos(x));
        }

        private static double f3(double x)
        {
            return (x * Math.Sin(x));
        }


        //DateTime dt = MilliSecondToDateTime.DT("10.11.2018 13:30:00");
        DateTime dt_deginkalendar = MilliSecondToDateTime.DT("01.01.1971 19:00:14");
        private static double f4(double x)
        {
            //return Random_(5) * 0 + 1000 + (Math.Cos(x * x));
            //MilliSecondToDateTime.Interval();
            //double y = (Math.Sin(x * 12 * Math.PI ));
            double y = (Math.Sin(x * 12 * Math.PI) + 3 * Math.Cos(x * 4 * Math.PI) + 5 * Math.Sin(x * 2 * Math.PI) - 7 * Math.Cos(x * 20 * Math.PI) - 9 * Math.Sin(x * 15 * Math.PI));
            //return 50 + (-Random_(700) + Random_(1000)) * Random_(5);
            //return RandomBig();
            return y;
        }

        private static double f41(double x)
        {
            return 1;
        }

        private static double f42(double x)
        {
            return 2;
        }

        private static double f4_(int a, int b, int c, double x)
        {
            //return Random_(5) * 0 + 1000 + (Math.Cos(x * x));
            //MilliSecondToDateTime.Interval();
            //double y = (Math.Sin(x * 12 * Math.PI ));
            double y = (0 * Math.Sin(x * 12 * Math.PI) + a * Math.Cos(x * 4 * Math.PI) + b * Math.Sin(x * 2 * Math.PI) - 7 * Math.Cos(x * 20 * Math.PI) - c * Math.Sin(x * 15 * Math.PI));
            //double y = (Math.Sin(x * 5 * Math.PI));// + a * Math.Cos(x * 4 * Math.PI) + b * Math.Sin(x * 2 * Math.PI) - 7 * Math.Cos(x * 20 * Math.PI) - c * Math.Sin(x * 15 * Math.PI));

            //return 50 + (-Random_(700) + Random_(1000)) * Random_(5);
            //return RandomBig();
            return y;
        }

        static int maxInt = 100;
        private static int RandomBig()
        {
            int r = Random_(2325);
            switch (r)
            {
                case 0: return maxInt + Random_(maxInt);
                case 2: return maxInt + Random_(maxInt);
                case 1: return -maxInt - Random_(maxInt);
                case 3: return -maxInt - Random_(maxInt);
                default: return -15 + Random_(30);

            }
        }

        private static int f5(double x)
        {
            //return 5000 + Random_(10);
            //return 50 + Random_(1000)*Random_(5);
            //return 10 + (-Random_(50)+ 1000*Random_(1000)*Random_(2) * Random_(1) * Random_(1));
            //return 10 + (-Random_(50) + 1000 * Random_(1000) * Random_(2) * Random_(1) * Random_(1));
            return RandomBig();
            //return (int)(x/1000000);
        }

        private static double f55(double x)
        {
            return 5000 + (Math.Sin(x / 8));
        }

        private static double f6(double x)
        {
            return (Math.Cos(x / 20));
        }

        private static double f7(double x)
        {
            return 500 * (x * Math.Cos(x));
        }

        private static double f8(double x)
        {
            return 50 * (Math.Cos(x * x));
        }

        private static double f9(double x)
        {
            return Math.Sin(x) * Random_(50);
        }

        private static double f10(double x)
        {
            return Math.Cos(x) * Random_(50);
        }

        private static double f12(double x)
        {
            return Random_(2);
        }

        private delegate double func_(int a, int b, int c, double x);
        private static event func_ function_ = null;

        private delegate double func(double x);
        private static event func function = null;

        private delegate object func2(double x);
        private static event func2 function2 = null;

        public static double funct(double x, int i)
        {
            switch (i)
            {
                case 1: function = f1; break;
                case 2: function = f2; break;
                case 3: function = f3; break;
                case 4: function = f4; break;
                case 5: function = f55; break;
                case 6: function = f6; break;
                case 7: function = f7; break;
                case 8: function = f8; break;
                case 9: function = f9; break;
                case 10: function = f10; break;/**/
                default: function = f1; break;
            }

            return function(x);
        }

        public static string f13_(double x)
        {
            if (((int)x) % 2 == 0) return "true";
            else return "false";
        }

        public static string f13(double x)
        {
            int k = Random_((int)x);
            switch (k)
            {
                case 1: return "true";
                case 2: return "false";
                default: return "false";
            }
        }

        private static string f14(double x)
        {
            int k = Random_(745);
            switch (k)
            {
                case 1: return "false";
                //case 10: return "true";
                //case 2: return "false";
                //case 2: return "false";
                ///case 3: return "true";
                //case 4: return "false";
                //default: return "false";
                default: return "true";
            }
        }

        private static string f16(double x)
        {
            int k = Random_(5);
            return Math.Sin(Math.PI * Random_(70)).ToString();
        }

        public static object funct3(double x, int i)
        {
            switch (i)
            {
                case 0: function2 = f16; return function2(x);
                case 1: function2 = f16; return function2(x);
                case 2: function2 = f16; return function2(x);
                case 3: function2 = f16; return function2(x);
                case 11: function = f12; break;
                case 22: function2 = f13; return function2(x);
                case 33: function = f3; break;
                case 4: function2 = f13; return function2(x);
                case 5: function = f55; break;
                case 6: function = f6; break;
                case 7: function2 = f13; return function2(x);
                case 71: function = f7; break;
                case 8: function = f8; break;
                case 9: function = f9; break;
                case 10: function = f10; break;/**/
                default: function = f10; break;
            }

            return function(x);
        }




        public static object funct2(double x, int i)
        {
            switch (i)
            {
                case 0: function2 = f14; return function2(x);
                case 1: function2 = f14; return function2(x);
                case 2: function2 = f14; return function2(x);
                case 3: function2 = f14; return function2(x);
                case 4: function2 = f14; return function2(x);
                case 14: function2 = f14; return function2(x);
                case 5: function = f1; return function(x);
                case 6: function = f2; return function(x);
                case 7: function = f3; return function(x);

                case 8: function = f4; return function(x);
                case 81: function = f41; return function(x);
                case 82: function = f42; return function(x);
                //case 8: function_ = f4_; return function_(x);

                case 9: return f5(x);
                case 10: function = f6; return function(x);
                default: function2 = f14; break;
            }

            return function2(x);
        }

        public static object funct2_real(int a, int b, int c, double x)
        {
            function_ = f4_;
            return function_(a, b, c, x);
        }


        public static string CreateRandomVar_()
        {
            string st = "";
            for (int i = 0; i < 10; i++) st += Ch(GenerateValue.Random_((int)50));
            return st;
        }

        public static string[] table_name = { "baz1", "baz2", "du", "ctrl", "log", "scm" };

        public static string CreateRandomVar()
        {
            string st = "";
            st += Ch(GenerateValue.Random_((int)26));
            st += Ch(GenerateValue.Random_((int)26));
            st += Chnum(GenerateValue.Random_((int)10));
            st += Ch(GenerateValue.Random_((int)26));
            st += Ch(GenerateValue.Random_((int)26));
            st += Ch(GenerateValue.Random_((int)26));
            st += Chnum(GenerateValue.Random_((int)10));
            st += Chnum(GenerateValue.Random_((int)10));
            st += Ch(GenerateValue.Random_((int)26));
            st += Ch(GenerateValue.Random_((int)26));
            return st;
        }


        public static string RandomType()
        {
            //string[] alphabet = new string[] { "real", "boolean", "integer", "text", "timestamp" };
            string[] alphabet = new string[] { "real", "boolean", "integer" };
            return alphabet[GenerateValue.Random_((int)alphabet.Length)];
        }


        public static string RandomComment()
        {
            string[] alphabet = new string[] {
                "температра",
                "мощность",
                "реактивность",
                "координата ИС1",
                "координата ИС2",
                "Средняя мощность по baz1",
                "Средняя мощность по baz2",
                "расчетная реактивность",
                "состояние калибровки",
                "квитирование",
                "давление",
                "поток нейтронов",
                "Сброс ББ",
                "состояние индикаторов",
                "флаг положения тележки"
            };
            return alphabet[GenerateValue.Random_((int)alphabet.Length)];
        }

        static char Ch(int i)
        {
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            if (i > 0 && i < alphabet.Length) return alphabet[i];
            else return 'z';
        }

        static char Chnum(int i)
        {
            string alphabet = "0123456789";
            if (i > 0 && i < alphabet.Length) return alphabet[i];
            else return '0';
        }
    }


    public class MilliSecondToDateTime
    {
        DateTime dt = DateTime.Now;


        static string tm_begin_min = "18.02.2300 13:30:00";
        static string tm_end_min = "18.02.2300 13:35:00";

        static double stepTimeDB = 0;

        static string tm_begin = "18.12.2017 13:55:00";
        static string tm_end = "18.12.2017 14:00:00";

        // 14 февраля
        // https://social.msdn.microsoft.com/Forums/en-US/88802a84-cc25-495b-a758-7c82091109f3/converting-milli-seconds-to-datetime-in-c?forum=wpdevelop

        private static long Nportion = 100;

        public static void SetPortion(long portion)
        {
            Nportion = portion;
        }

        public static double GetStepTimeReadDB(string tm1, string tm2)
        {
            //stepTimeDB = Interval(DT(tm1), DT(tm2))/Nportion;
            stepTimeDB = Interval(DT(tm1), DT(tm2)) / Nportion;
            //stepTimeDB = Nportion*1000;
            return stepTimeDB;
        }

        public static double GetStepTimeReadDB(DateTime tm1, DateTime tm2)
        {
            //stepTimeDB = Interval(DT(tm1), DT(tm2))/Nportion;
            stepTimeDB = Interval(tm1, tm2) / Nportion;
            //stepTimeDB = Nportion*1000;
            return stepTimeDB;
        }

        public static double Interval(DateTime dt1, DateTime dt2)
        {
            TimeSpan ts = dt2.Subtract(dt1); // интервал между t1 и t2 в миллисекундах
            return ts.TotalMilliseconds;
        }

        public static string Interval2(DateTime dt1, DateTime dt2)
        {
            TimeSpan ts = dt2.Subtract(dt1); // интервал между t1 и t2 в миллисекундах
            return ts.Days + " дней " + ts.Hours + " часов " + ts.Minutes +
                " минут " + ts.Seconds + " секунд ." + ts.Milliseconds + " мс";
        }


        public static string StringStepTime()
        {
            DateTime t1 = DateTime.Now;
            DateTime t2 = StepDT(t1, stepTimeDB);
            return Interval2(t1, t2);
        }

        public static DateTime DT(string str)
        {
            try
            {
                return System.Convert.ToDateTime(str);  // преобразование строки в дату времени
            }
            catch (Exception err)
            {
                return DateTime.Now;
            }
        }

        public static DateTime StepDT(DateTime dt, double step)
        {
            return dt.AddMilliseconds(step); // новая дата, полученная шагом на step миллисекунд
        }


        public static double DateToMilliSecobds2()
        {
            DateTime dt1 = DT(tm_begin);
            DateTime dt2 = DT(tm_end);

            double step = Interval(dt1, dt2);
            step /= 100;
            Console.WriteLine("\n\n\ndate 1: " + tm_begin + "\ndate 2: " + tm_end + "\n date 2: " + StepDT(dt1, step));

            dt1 = DT(tm_begin_min);
            dt2 = DT(tm_end_min);
            double step2 = Interval(dt1, dt2);
            //step2 /= 100;

            Console.WriteLine("\n\ndate 1: " + tm_begin + "\ndate 2: " + tm_end + "\n date 2: " + StepDT(DT(tm_begin), step2));

            //dt2 = dt2.AddMilliseconds(ts.TotalMilliseconds);
            //Console.WriteLine(tm_end + "\n" + dt2);

            return step;

        }


    }
}
