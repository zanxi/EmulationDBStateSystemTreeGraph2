using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp_10_ICommand.GenerateDB
{
    public class DriverDBEmulation : DataBase
    {
        private string _ipMachine;
        public string ipMachine { get { return _ipMachine; } }
        private int _portMachine;
        public int portMachine { get { return _portMachine; } }
        private string _userName;
        public string userName { get { return _userName; } }
        private string _password;
        public string password { get { return _password; } }
        private string _nameDB;
        public string nameDB { get { return _nameDB; } set { nameDB = value; } }

        //public NpgsqlConnection npgSqlConnection { get; set; }
        public string connectionString { get; set; }

        public void InitDB(
            string ipMachine,
            int portMachine,
            string nameDB,
            string userName,
            string password
            )
        {
            this._ipMachine = ipMachine;
            this._portMachine = portMachine;
            this._userName = userName;
            this._password = password;
            this._nameDB = nameDB;

            InitConnection();
        }

        public DriverDBEmulation() { }

        public DriverDBEmulation(
            string ipMachine,
            int portMachine,
            string nameDB,
            string userName,
            string password
            )
        {
            this._ipMachine = ipMachine;
            this._portMachine = portMachine;
            this._userName = userName;
            this._password = password;
            this._nameDB = nameDB;
            InitConnection();
        }

        public string InitConnection()
        {
            connectionString =
                    "server=" + ipMachine + ";" +
                    "port=" + portMachine + ";" +
                    "username=" + userName + ";" +
                    "password=" + password + ";" +
                    "database=" + nameDB + ";";
            return connectionString;
        }

        public bool Open()
        {

            try
            {
                for (int i = 0; i < GenerateValue.table_name.Length; i++)
                {
                    structBase.Add(GenerateValue.table_name[i], 25 + GenerateValue.Random_(10));
                }
                return true;
            }
            catch (Exception exc)
            {
                //errorMessageConnection = "ERROR OPEN DB: " + exc.Message;
                string log = DataStatic.GeneratorNameDateFile("Log_error_DBBars_Open__", ".txt");
                File.AppendAllText(log, "Error DBBars Open:" + exc.Message + " \r\n");
                return false;

            }


        }

        public bool Close()
        {
            try
            {

                //npgSqlConnection.Close();
                return true;

            }
            catch (Exception exc)
            {
                //errorMessageConnection = exc.Message;
                string log = DataStatic.GeneratorNameDateFile("Log_error_DBBars_Close__", ".txt");
                File.AppendAllText(log, "Error DBBars Close:" + exc.Message + " \r\n");
                return false;
            }
        }

        public DateTime dtm1 = DateTime.Now, dtm2 = DateTime.Now;


        Dictionary<string, int> structBase = new Dictionary<string, int>();
        public bool ExecutiveSQLDataBase3(string sql, out DataTable dtpg_)
        {
            try
            {
                string tab = sql;
                dtpg_ = new DataTable();

                dtpg_.Columns.Add(new DataColumn() { ColumnName = "tab" });
                dtpg_.Columns.Add(new DataColumn() { ColumnName = "type" });
                dtpg_.Columns.Add(new DataColumn() { ColumnName = "tabVar" });
                dtpg_.Columns.Add(new DataColumn() { ColumnName = "tabVar2" });
                dtpg_.Rows.Add(structBase[tab]);

                string type = GenerateValue.RandomType();
                string tabVar = GenerateValue.CreateRandomVar();
                for (int i = 0; i < structBase[tab]; i++)
                {
                    type = GenerateValue.RandomType();
                    tabVar = GenerateValue.CreateRandomVar();
                    dtpg_.Rows.Add(tabVar, tabVar, tabVar, tabVar);

                }



                return true;
            }
            catch (Exception exc)
            {
                string log = DataStatic.GeneratorNameDateFile("Log_error_DBBars_Connect__", ".txt");
                File.AppendAllText(log, "Error_GetSQLDBBars:" + exc.Message + " \r\n");
                dtpg_ = null;
                return false;
            }
        }

        public DateTime dt0;
        public double stepInterval;
        public bool ExecutiveSQLDataBase(DateTime[] time, string tableName2, Dict tabCheck2, out DataTable dtpg_)
        {
            try
            {

                int a = 50 + GenerateValue.Random_(100);
                int b = 60 + GenerateValue.Random_(50);
                int c = 10 + GenerateValue.Random_(10000);

                string tab = "";
                dtpg_ = new DataTable();
                //dtpg_.Name =;
                List<string> varsCheck2 = new List<string>();
                varsCheck2 = tabCheck2[tableName2].ToList();

                dtpg_.Columns.Add(new DataColumn()
                {
                    ColumnName = "Время"
                });
                for (int i = 0; i < varsCheck2.Count; i++)
                    dtpg_.Columns.Add(new DataColumn()
                    {
                        ColumnName = varsCheck2[i].Split(new Char[] { ':' })[0]
                    });

                //dtpg_.Rows.ad(structBase[tab]);
                //dtpg_.Rows.Add();

                //string type = GenerateValue.RandomType();
                //string tabVar = GenerateValue.CreateRandomVar();

                double stepTime = MilliSecondToDateTime.Interval(time[0], time[1]);
                int numSeconds = (int)(stepTime / 1000);
                double step = stepTime / numSeconds;
                DateTime dtm = time[0];
                //DateTime dtm2 = time[1];

                for (int i = 0; i < numSeconds; i++)
                {
                    List<object> list = new List<object>();
                    double x = MilliSecondToDateTime.Interval(dtm,
                            //MilliSecondToDateTime.DT("01.01.1971 19:00:14"))/ (1.0*1000*1000*1000*1000);
                            MilliSecondToDateTime.DT("01.01.1971 19:00:14")) / (1.0 * 1000 * 1000);

                    x = MilliSecondToDateTime.Interval(dt0, time[0]) + MilliSecondToDateTime.Interval(time[0], time[1]);
                    x /= stepInterval;

                    list.Add(dtm);
                    for (int j = 0; j < varsCheck2.Count; j++)
                    {
                        //if(varsCheck2[j].Contains("real")) list.Add(GenerateValue.funct2(x, 8).ToString());
                        if (varsCheck2[j].Contains("real")) list.Add(GenerateValue.funct2_real(a, b, c, x).ToString());
                        if (varsCheck2[j].Contains("integer")) list.Add(GenerateValue.funct2(x, 9).ToString());
                        if (varsCheck2[j].Contains("boolean")) list.Add(GenerateValue.funct2(x, 0));
                    }

                    dtpg_.Rows.Add(list.ToArray());
                    dtm = MilliSecondToDateTime.StepDT(dtm, step);
                }



                return true;
            }
            catch (Exception exc)
            {
                string log = DataStatic.GeneratorNameDateFile("Log_error_DBBars_Connect__", ".txt");
                File.AppendAllText(log, "Error_GetSQLDBBars:" + exc.Message + " \r\n");
                dtpg_ = null;
                return false;
            }
        }


        public DataTable GetComment(string tab)
        {

            DataTable dt = new DataTable();

            dt.Columns.Add(new DataColumn() { ColumnName = "tab" });
            dt.Columns.Add(new DataColumn() { ColumnName = "type" });
            dt.Columns.Add(new DataColumn() { ColumnName = "comment" });
            dt.Columns.Add(new DataColumn() { ColumnName = "comment2" });

            //dt.Rows.Clear();
            //dt.Rows.Add(structBase[tab]);
            string type = GenerateValue.RandomType();
            string comment = GenerateValue.RandomComment();

            for (int i = 0; i < structBase[tab]; i++)
            {
                type = GenerateValue.RandomType();
                comment = GenerateValue.RandomComment();
                //dt.Rows[i].ItemArray[0] = tab;
                //dt.Rows[i].ItemArray[1] = type;
                //dt.Rows[i].ItemArray[2] = comment;
                dt.Rows.Add(tab, type, comment, type);
            }

            return dt;
        }

        public DataTable GetComment(string tab, int k)
        {
            //ExecutiveSQLDataBaseComment("SELECT column_name, data_type FROM INFORMATION_SCHEMA.COLUMNS WHERE table_name = '" + tab + "'; ");
            DataTable dtPgComment = null;
            ExecutiveSQLDataBase(
        "SELECT subq.relname, subq.obj_description, subq.attname, d.description " +
        "FROM" +
         "(SELECT c.relname, obj_description(c.oid) obj_description, a.attname, c.oid, a.attnum" +
         " FROM pg_class c, pg_attribute a"
         + " WHERE c.oid = a.attrelid"
         + " AND c.relname = '" + tab + "'"
         + " AND a.attnum > 0) subq LEFT OUTER JOIN pg_description d ON(d.objsubid = subq.attnum AND d.objoid = subq.oid);", out dtPgComment);
            /**/

            return dtPgComment;
        }

        public List<string> SortColumn(string tab)
        {
            DataTable dtPgComment = GetComment(tab);

            DataTable dtPgColums = null;
            ExecutiveSQLDataBase3(tab, out dtPgColums);

            List<string> listColumns = new List<string>();

            for (int j = 0; j < dtPgColums.Rows.Count - 1; j++)
            {
                string stCol = "";
                stCol = dtPgColums.Rows[j][0].ToString().ToUpper() + ":" + " -" +
                    dtPgComment.Rows[j][2].ToString() + " - " + dtPgComment.Rows[j][1].ToString();
                listColumns.Add(stCol);
            }
            listColumns.Sort();
            return listColumns;


            //return new List<string>();


        }

        public bool ExecutiveSQLDataBase(string sql, out DataTable dtpg_)
        {
            dtpg_ = null;
            return true;
        }
    }
}
