using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp_10_ICommand
{
    // Класс для построения дерева действий

    public static class ToolBox
    {

        public static bool _Stop = true;
        public static bool _StopChange = true;
        //public static string activityCategory = "";

        public static bool isDark = false;
        public static string _ThemeName = "";
        public const string _ThemeName_Office2019Dark = "Office2019Dark";
        public const string _ThemeName_ControlDefault = "ControlDefault";
        public const string _ThemeName_Office2019Gray = "Office2019Gray";
        //public static string _ThemeName = ;
        //public static string _ThemeName = ;

        public static string color_white = "White";
        public static string color_red = "Red";
        public static string color_yellow = "Yellow";
        public static string color_blue = "Blue";
        public static string color_dark = "#002F2F2F";
        public static string color_lightdark = "#003C3C3C";
        public static string color_toolboxctrl_name = "#00E9ECEE";
        //public static string color_Name_activity_yellow = "#00FFE8A6";

        public static System.Windows.Media.Color theme_color_white = System.Windows.Media.Colors.White;
        public static System.Windows.Media.Color theme_color_white2lime = System.Windows.Media.Colors.White;
        public static System.Windows.Media.Color theme_color_black = System.Windows.Media.Colors.Black;
        public static System.Windows.Media.Color theme_color_red = System.Windows.Media.Colors.Red;
        public static System.Windows.Media.Color theme_color_yellow = System.Windows.Media.Colors.Yellow;
        public static System.Windows.Media.Color theme_color_blue = System.Windows.Media.Colors.Blue;
        public static System.Windows.Media.Color theme_color_dark = System.Windows.Media.Color.FromArgb(0, 47, 47, 47);
        public static System.Windows.Media.Color theme_color_lightdark = System.Windows.Media.Color.FromArgb(0, 60, 60, 60);
        //public static System.Windows.Media.Color theme_color_lightgray = System.Windows.Media.Color.FromArgb(0, 211, 211, 211);
        public static System.Windows.Media.Color theme_color_lightgray = System.Windows.Media.Color.FromArgb(255, 221, 221, 221);

        public static System.Windows.Media.Color theme_toolboxctrl_name = System.Windows.Media.Color.FromArgb(0, 233, 235, 238);
        public static string theme_toolboxctrl_name_str = "#00E8ECEF";

        public static System.Windows.Media.Color theme_tabItem_NoSelect = System.Windows.Media.Color.FromArgb(0, 241, 241, 241);
        public static System.Windows.Media.Color theme_tabItem_Select = System.Windows.Media.Color.FromArgb(0, 255, 255, 255);
        public static System.Windows.Media.Color theme_toolBar = System.Windows.Media.Color.FromArgb(0, 240, 240, 240);

        public static System.Windows.Media.Color theme_color_lifgtSelect = System.Windows.Media.Color.FromArgb(0, 161, 205, 237);
        public static string theme_color_lifgtSelect_str = "#00A1CDED";

        public static System.Windows.Media.Color theme_color_blue2 = System.Windows.Media.Color.FromArgb(0, 16, 110, 190);
        public static string theme_color_blue2_str = "#00106EBE";

        public static System.Windows.Media.Color theme_color_office2019Gray = System.Windows.Media.Color.FromArgb(0, 203, 203, 203);
        public static string theme_coolor_office2019Gray_str = "#00CBCBCB";

        public static string color_Name_activity_tabItem_NoSelect = "#00F1F1F1";
        public static string color_Name_activity_yellow = "#00F0F0F0";

        public static string color_dark2 = "#424f5a";
        public static string color_dark2_light = "#e8e8e8";
        public static string color_dark2_light2 = "#383838";



    }

}
