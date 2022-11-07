using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp_10_ICommand.GenerateDB
{
    public interface DataBase
    {
        string ipMachine { get; }
        int portMachine { get; }
        string userName { get; }
        string password { get; }
        string nameDB { get; }

        //NpgsqlConnection npgSqlConnection { get; set; }
        string connectionString { get; set; }

        void InitDB(
            string ipMachine,
            int portMachine,
            string nameDB,
            string userName,
            string password
            );
        string InitConnection();
        bool Open();
        bool Close();
        bool ExecutiveSQLDataBase(string sql, out DataTable dtpg_);
        DataTable GetComment(string tab);
    }
}
