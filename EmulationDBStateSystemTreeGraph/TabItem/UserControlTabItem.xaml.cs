using Bornander.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
using WpfApp_10_ICommand;
using WpfApp_10_ICommand.GenerateDB;

namespace WpfApp_10_ICommand.TabItem
{
    /// <summary>
    /// Логика взаимодействия для UserControlTabItem.xaml
    /// </summary>
    public partial class UserControlTabItem : UserControl, INotifyPropertyChanged
	{

		private ObservableCollection<DataDB> _dataDB;

		public ObservableCollection<DataDB> DataDB
		{
			get => _dataDB;
			set
			{
				_dataDB = value;
				OnPropertyChanged();
			}
		}

		

		public event PropertyChangedEventHandler PropertyChanged;
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyNameVal = null)
			=> PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyNameVal));



		private GridViewColumnHeader listViewSortCol = null;
		private SortAdorner listViewSortAdorner = null;

		public UserControlTabItem()
		{
			InitializeComponent();

			DataContext = this;
            Loaded += UserControlTabItem_Loaded;
            lvDataDB.MouseLeftButtonDown += LvDataDB_MouseLeftButtonDown;
            lvDataDB.MouseLeave += LvDataDB_MouseLeave; ;
			return;

			
			//lvDataDB.ItemsSource = items;
		}

        private void LvDataDB_MouseLeave(object sender, MouseEventArgs e)
        {
			if(!ToolBox._StopChange) ToolBox._StopChange = true;
		}

        private void LvDataDB_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
			ToolBox._StopChange = false;
			return;
		}

        private async void UserControlTabItem_Loaded(object sender, RoutedEventArgs e)
        {
			DataDB = new ObservableCollection<DataDB>();
			await FillDataDBAsync(DataDB, 100, 2, true);
		}

		string SwitchValue(string str)
        {
			if (str.Contains(DataStatic.typeVar_integer)) return GenerateValue.Random_(100).ToString();
			else if (str.Contains(DataStatic.typeVar_boolean)) return GenerateValue.f13(GenerateValue.Random_(10)).ToString();
			else if (str.Contains(DataStatic.typeVar_real)) return (GenerateValue.Random_(1000) * 355.0 / 113.0).ToString();
			else return GenerateValue.CreateRandomVar_();
		}

		private async Task FillDataDBAsync(ObservableCollection<DataDB> items, int count, int depth, bool isRoot)
		{
			//for (int i = 0; i < count; i++)
			//for (; ; )
			long i = 0;
			List<string[]> listData = TreeViewCopy.ListView();
			while (ToolBox._Stop)
			{				
				foreach (var item in listData)
				{
					DataDB dataDB = new DataDB() { 
						NameVal = item[0], 
						DescrVal = item[1].
						Replace(DataStatic.typeVar_real, "").
						Replace(DataStatic.typeVar_integer, "").
						Replace(DataStatic.typeVar_boolean, "").
						Replace("-", ""), 
						Val = SwitchValue(item[1]) }; // $"{isRoot ? "Хлеб" : "Сорт хлеба"} {i + 1}" };				
					if (ToolBox._StopChange)
					{
						items.Add(dataDB);
					}					
				}
				await Task.Delay(1000);
				if (ToolBox._StopChange)
				{
					items.Clear();
				}


				i++;
				//if (i == count - 1 && depth > 1)
				//	FillDataDB(user.Items, count, depth - 1, false);
			}
		}


    private void lvDataDBColumnHeader_Click(object sender, RoutedEventArgs e)
	{
			ToolBox._StopChange = false;

			GridViewColumnHeader column = (sender as GridViewColumnHeader);
		string sortBy = column.Tag.ToString();
		if (listViewSortCol != null)
		{
			AdornerLayer.GetAdornerLayer(listViewSortCol).Remove(listViewSortAdorner);
			lvDataDB.Items.SortDescriptions.Clear();
		}

		ListSortDirection newDir = ListSortDirection.Ascending;
		if (listViewSortCol == column && listViewSortAdorner.Direction == newDir)
			newDir = ListSortDirection.Descending;

		listViewSortCol = column;
		listViewSortAdorner = new SortAdorner(listViewSortCol, newDir);
		AdornerLayer.GetAdornerLayer(listViewSortCol).Add(listViewSortAdorner);
		lvDataDB.Items.SortDescriptions.Add(new SortDescription(sortBy, newDir));

//			if (!ToolBox._StopChange) ToolBox._StopChange = true;
		}
}

public enum ValType { Male, Female };

	public class DataDB : INotifyPropertyChanged
	{

		private ObservableCollection<DataDB> _items = new ObservableCollection<DataDB>();

		public ObservableCollection<DataDB> Items
		{
			get => _items;
			set
			{
				_items = value;
				OnPropertyChanged();
			}
		}

		private string _nameVal;
		public string NameVal
		{
			get => _nameVal;
			set
			{
				_nameVal = value;
				OnPropertyChanged();
			}
		}


		private string _descrVal;
		public string DescrVal
		{
			get => _descrVal;
			set
			{
				_descrVal = value;
				OnPropertyChanged();
			}
		}
				

		

		private string _val;
		public string Val
		{
			get => _val;
			set
			{
				_val = value;
				OnPropertyChanged();
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyNameVal = null)
		 => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyNameVal));
	}

public class SortAdorner : Adorner
{
	private static Geometry ascGeometry =
		Geometry.Parse("M 0 4 L 3.5 0 L 7 4 Z");

	private static Geometry descGeometry =
		Geometry.Parse("M 0 0 L 3.5 4 L 7 0 Z");

	public ListSortDirection Direction { get; private set; }

	public SortAdorner(UIElement element, ListSortDirection dir)
		: base(element)
	{
		this.Direction = dir;
	}

	protected override void OnRender(DrawingContext drawingContext)
	{
		base.OnRender(drawingContext);

		if (AdornedElement.RenderSize.Width < 20)
			return;

		TranslateTransform transform = new TranslateTransform
			(
				AdornedElement.RenderSize.Width - 15,
				(AdornedElement.RenderSize.Height - 5) / 2
			);
		drawingContext.PushTransform(transform);

		Geometry geometry = ascGeometry;
		if (this.Direction == ListSortDirection.Descending)
			geometry = descGeometry;
		drawingContext.DrawGeometry(Brushes.Black, null, geometry);

		drawingContext.Pop();
	}
}
}

