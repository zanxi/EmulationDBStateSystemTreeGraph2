using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp_10_ICommand.GenerateDB
{
    public class Dict : Dictionary<string, List<string>>
    {
        public Dictionary<string, string> Comment = new Dictionary<string, string>();
        public void Add2(string key, string comment)
        {
            //base[var1].Add(var2);
            Comment.Add(key, comment);
        }
    }
}
