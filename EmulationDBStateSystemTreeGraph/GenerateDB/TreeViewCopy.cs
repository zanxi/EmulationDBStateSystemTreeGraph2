using Bornander.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp_10_ICommand.GenerateDB
{
    public class TreeViewCopy
    {

        public static SettingsViewModel TreeDBEmulation()
        {
            SettingsViewModel svm = new SettingsViewModel();

            DriverDBEmulation dbBars2 = new DriverDBEmulation();
            dbBars2.Open();
            try
            {
                for (int i = 0; i < GenerateValue.table_name.Length; i++)
                {
                    //DataTable dtPgComment = dbBars2.GetComment(GenerateValue.table_name[i]);
                    List<string> listColumns = dbBars2.SortColumn(GenerateValue.table_name[i]);

                    ObservableCollection<TreeNodeViewModel> child =
                          new ObservableCollection<TreeNodeViewModel>();

                    //TreeNode tree4 = tv.Nodes.Add(GenerateValue.table_name[i] + ":" + dtPgComment.Rows[0][1].ToString());
                    //tree4.SelectedImageIndex = ;
                    foreach (string stCol in listColumns)
                    {
                        //TreeNode colum = tree4.Nodes.Add(stCol);
                        TreeNodeViewModel tn =
                            new TreeNodeViewModel(stCol);
                        if (stCol.Contains(DataStatic.typeVar_boolean)) tn.typeVar = DataStatic.typeVar_boolean;
                        if (stCol.Contains(DataStatic.typeVar_real)) tn.typeVar = DataStatic.typeVar_real;
                        if (stCol.Contains(DataStatic.typeVar_integer)) tn.typeVar = DataStatic.typeVar_integer;
                        if (stCol.Contains(DataStatic.typeVar_text)) tn.typeVar = DataStatic.typeVar_text;
                        if (stCol.Contains(DataStatic.typeVar_timestamp)) tn.typeVar = DataStatic.typeVar_timestamp;

                        child.Add(tn);
                    }
                    var n = new TreeNodeViewModel(
                        GenerateValue.table_name[i],
                        child);
                    svm.Add(new[] { n });
                    child.Clear();

                }
                return svm;
            }
            catch (Exception ex)
            {
                //mainStatusS.Items.Add(ex.Message);
                return svm;
            }
        }
        public static List<string[]> ListView()
        {
            List<string[]> listData = new List<string[]>();


            DriverDBEmulation dbBars2 = new DriverDBEmulation();
            dbBars2.Open();
            try
            {
                for (int i = 0; i < GenerateValue.table_name.Length; i++)
                {
                    //DataTable dtPgComment = dbBars2.GetComment(GenerateValue.table_name[i]);
                    List<string> listColumns = dbBars2.SortColumn(GenerateValue.table_name[i]);

                    foreach (string stCol in listColumns)
                    {
                        string[] list;
                        string str1 = stCol.Split(':')[0];
                        string str2 = stCol.Split(':')[1].Replace("-", "");
                        list = new string[] { str1, str2 };
                        listData.Add(list);
                    }
                }
                return listData;
            }
            catch
            {
                return null;
            }            
        }
    }
}


                
                
