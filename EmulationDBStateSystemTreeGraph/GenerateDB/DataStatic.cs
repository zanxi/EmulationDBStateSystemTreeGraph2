using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp_10_ICommand.GenerateDB
{
    public class DataStatic
    {
        //public static DataTable dataTable = new DataTable();
        //public static Dictionary<string, DataTableExt> dictDB = new Dictionary<string, DataTableExt>();
        //public static Dictionary<string, string> dictDB = new Dictionary<string, string>();
        //public static Dictionary<string, DataTableExt> dictDBtable = new Dictionary<string, DataTableExt>();
        public static DateTime dtm1;
        public static DateTime dtm2;
        public static string tm0;

        public const string typeVar_boolean = "boolean";
        public const string typeVar_real = "real";
        public const string typeVar_integer = "integer";
        public const string typeVar_text = "text";
        public const string typeVar_timestamp = "timestamp";
        public const string typeVar_ = "";
        //if (stCol.Contains("real")) colum.ImageIndex = 3;
        //if (stCol.Contains("integer")) colum.ImageIndex = 4;
        //if (stCol.Contains("text")) colum.ImageIndex = 5;
        //if (stCol.Contains("timestamp")) colum.ImageIndex = 1;

        public class AutorizationBlackBox
        {
            public string nameBase { get; set; }
            public string ipMachineName { get; set; }
            public string machineName { get; set; }
            public string userName { get; set; }
            public string password { get; set; }
            public int portMachine { get; set; }
            public string dbMachine { get; set; }

        }
        public static List<AutorizationBlackBox> initConnectDB = new List<AutorizationBlackBox>()
        {
            new AutorizationBlackBox
            {
                nameBase="Combo",
                ipMachineName = "127.0.0.1",
                machineName = "База данных состояния системы",
                portMachine = 5432,
                dbMachine = "combo",
                userName = "combo",
                password = "combo"
            },
            new AutorizationBlackBox
            {
                nameBase="Combo",
                ipMachineName = "192.168.10.30",
                machineName = "База данных состояния системы",
                portMachine = 5432,
                dbMachine = "combo",
                userName = "combo",
                password = "combo"
            },
            new AutorizationBlackBox
            {
                nameBase="Aggregate", // описание установленной на машине БД
                ipMachineName = "127.0.0.1",
                machineName = "База данных переменных сервера Aggregate",
                portMachine = 5432,
                dbMachine = "dump",  // ИМЯ установленной на машине БД
                userName = "postgres",
                password = "162747"
            },
            new AutorizationBlackBox
            {
                nameBase="Aggregate",
                ipMachineName = "192.168.10.12",
                machineName = "База данных переменных сервера Aggregate",
                portMachine = 5432,
                dbMachine = "dump",
                userName = "postgres",
                password = "162747"
            }
        };



        public static int progresValue = 0;
        public static int progresMin = 0;
        public static int progresMax = 0;
        public static double timer = 0;
        public static double timer2 = 0;
        public static string pixelOrline = "";
        public static double numRows = 0;
        public static string numwWorkers = "";
        public static string timeBuildRealTime = "";
        public static string tmCurrent = "";



        //static string pathFileDesktop = @"D:\_V2018_\_black_box__\";
        public static string pathFileDesktop = AppDomain.CurrentDomain.BaseDirectory;
        string pathFileImageApp = AppDomain.CurrentDomain.BaseDirectory;
        //pathFileLogger = GeneratorNameDateFile("logger_ShieldPult_", ".txt");

        public static Color ColorType(int h)
        {
            switch (h)
            {
                case -1: return Color.White;
                case 0: return Color.Red;
                case 5: return Color.Yellow;
                case 2: return Color.Blue;
                case 4: return Color.Violet;
                case 7: return Color.DarkViolet;
                case 3: return Color.Indigo;


                case 6: return Color.Brown;
                case 10: return Color.Gray;
                case 8: return Color.DarkRed;
                case 9: return Color.Pink;
                case 12: return Color.Khaki;
                case 11: return Color.Lavender;
                case 1: return Color.Black;

                default: return Color.Black;
            }
        }

        public static Color ColorGraphics(int h)
        {
            switch (h)
            {
                case 0: return Color.Red;
                case 1: return Color.Green;
                case 2: return Color.Blue;
                case 3: return Color.Violet;
                case 4: return Color.DarkViolet;
                case 5: return Color.Indigo;


                case 6: return Color.Brown;
                case 7: return Color.Gray;
                case 8: return Color.DarkRed;
                case 9: return Color.Pink;
                case 10: return Color.Khaki;
                case 11: return Color.Lavender;
                default: return Color.Black;
            }
            //return Color.Red;
        }


        public static string GeneratorNameDateFile(string domName, string typeName)
        {
            //return "2018Feb.pdf";
            DateTime tm7 = DateTime.Now;
            string rndStr = "";//Path.GetRandomFileName();

            //return "2018Feb.pdf";
            string generate = pathFileDesktop +
            tm7.GetDateTimeFormats()[0] + "__" + domName +
            "__" +
            tm7.Hour + "_" + tm7.Minute + "_" + tm7.Second + "__" +
            rndStr + typeName;

            return generate;
        }


        public static string GeneratorNameWrite(string signature)
        {
            DateTime tm7 = DateTime.Now;
            string rndStr = Path.GetRandomFileName();

            string generate = signature + " " +
            tm7.GetDateTimeFormats()[0] + " " +
            tm7.Hour + ":" + tm7.Minute + ":" + tm7.Second + " ";

            return generate;
        }




    }
}
