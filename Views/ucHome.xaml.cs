using ProjetRESOTEL.Entities;
using ProjetRESOTEL.Service;
using ProjetRESOTEL.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
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

namespace ProjetRESOTEL.Views
{
	/// <summary>
	/// Logique d'interaction pour ucHome.xaml
	/// </summary>
	public partial class ucHome : UserControl
	{
		ItemsReservationViewModel items;
		public ucHome()
		{
		
			InitializeComponent();
			InitFixGrid();

			//To Define Context
			DataContext = new ViewModels.ItemsReservationViewModel();
			items = DataContext as ItemsReservationViewModel;
			CreateGridTemplate();
			LoadData(items);

		}

		private void CreateGridTemplate()
        {
			// Create column date/reservation
			for (int i = 0; i < (items.numberOfItems * items.pagination); i++)
			{
				ColumnDefinition gridColDynamic = new ColumnDefinition();
				DynamicGrid.ColumnDefinitions.Add(gridColDynamic);
			}

			// Create row by rooms
			for (int i = 0; i < items.bedrooms.Count; i++)
			{
				RowDefinition gridRow = new RowDefinition();
				DynamicGrid.RowDefinitions.Add(gridRow);
			}


		}

		private void RefreshItemsGrid()
        {
			//refresh items
			for (int i = 0; i < items.bedrooms.Count; i++)
			{
				for (int j = 0; j < items.numberOfItems; j++)
				{
					TextBlock res = new TextBlock();
					res.Text = "";
					res.Background = new SolidColorBrush(Colors.White);
					res.TextAlignment = TextAlignment.Center;
					res.VerticalAlignment = VerticalAlignment.Center;
					Grid.SetRow(res, i + 1);
					Grid.SetColumn(res, j + 2);
					DynamicGrid.Children.Add(res);
				}
			}
		}

		private void LoadData(ItemsReservationViewModel items)
		{
			AddHeaderToGrid(items);
			AddColumnRoomAndTypeToGrid(items);
			AddItemsReservationToGrid(items);
		}

		private void AddItemsReservationToGrid(ItemsReservationViewModel items)
        {
			// Check reservation
			for (int i = 0; i < items.bedrooms.Count; i++)
			{
				for (int j = 0; j < items.numberOfItems; j++)
				{

					CreateBackgroundItems(i + 1, j + 2); 

					TextBlock res = new TextBlock();
					res.Background = new SolidColorBrush(Colors.White);
					if (items.IsReserved(items.bedrooms[i].IdBedroom, j))
					{
						res.Background = new SolidColorBrush(Colors.Red);
					}
					res.Text = "";
					res.TextAlignment = TextAlignment.Center;
					res.VerticalAlignment = VerticalAlignment.Center;
					Grid.SetRow(res, i + 1);
					Grid.SetColumn(res, j + 2);
					DynamicGrid.Children.Add(res);
				}
			}
		}

		private void AddColumnRoomAndTypeToGrid(ItemsReservationViewModel items)
        {

			// Add rooms and types
			for (int i = 0; i < items.bedrooms.Count; i++)
			{

				CreateBackgroundHeader(i +1, 0);
				CreateBackgroundHeader(i + 1, 1);

				//create dynamic NumberOfRoom
				TextBlock NumberOfRoom = new TextBlock();
				NumberOfRoom.Text = "N° " + items.bedrooms[i].RoomNumber;
				NumberOfRoom.FontSize = 18;
				NumberOfRoom.TextAlignment = TextAlignment.Center;
				NumberOfRoom.VerticalAlignment = VerticalAlignment.Center;
				NumberOfRoom.Foreground = new SolidColorBrush(Colors.Gold);
				Grid.SetRow(NumberOfRoom, i + 1);
				Grid.SetColumn(NumberOfRoom, 0);
				DynamicGrid.Children.Add(NumberOfRoom);

				//create dynamic TypeOfRoom
				TextBlock TypeOfRoom = new TextBlock();
				TypeOfRoom.Text = "" + items.bedrooms[i].typeOfBedroom;
				TypeOfRoom.FontSize = 18;
				TypeOfRoom.TextAlignment = TextAlignment.Center;
				TypeOfRoom.VerticalAlignment = VerticalAlignment.Center;
				TypeOfRoom.Foreground = new SolidColorBrush(Colors.White);
				Grid.SetRow(TypeOfRoom, i + 1);
				Grid.SetColumn(TypeOfRoom, 1);
				DynamicGrid.Children.Add(TypeOfRoom);
			}
		}

		private void AddHeaderToGrid(ItemsReservationViewModel items)
        {
			// Dynamic Header with dates values
			for (int i = 0; i < (items.numberOfItems * items.pagination); i++)
			{
				var date = items.currentDate.AddDays(i).ToString("dddd, dd MMMM yyyy", CultureInfo.CreateSpecificCulture("fr-FR"));
				int position = i + 2;

				CreateBackgroundHeader(0,position);

				//create dynamic header
				TextBlock dateHeader = new TextBlock();
				dateHeader.Text = "" + date;
				dateHeader.FontSize = 16;
				dateHeader.Foreground = new SolidColorBrush(Colors.White);
				dateHeader.TextWrapping = TextWrapping.Wrap;
				dateHeader.TextAlignment = TextAlignment.Center;
				dateHeader.VerticalAlignment = VerticalAlignment.Center;

				Grid.SetRow(dateHeader, 0);
				Grid.SetColumn(dateHeader, position);

				DynamicGrid.Children.Add(dateHeader);
			}
		}

		private void InitFixGrid()
        {
			//Init Grid
			DynamicGrid.ShowGridLines = false;
			//Params Grid
			ColumnDefinition gridCol1 = new ColumnDefinition();
			DynamicGrid.ColumnDefinitions.Add(gridCol1);
			ColumnDefinition gridCol2 = new ColumnDefinition();
			DynamicGrid.ColumnDefinitions.Add(gridCol2);

			CreateBackgroundHeader(0, 0);
			CreateBackgroundHeader(0, 1);

			//create fix Header
			TextBlock RoomHeader = new TextBlock();
			RoomHeader.Text = "Chambre";
			RoomHeader.FontSize = 24;
			Grid.SetRow(RoomHeader, 0);
			Grid.SetColumn(RoomHeader, 0);
			RoomHeader.Foreground = new SolidColorBrush(Colors.White);
			RoomHeader.TextAlignment = TextAlignment.Center;
			RoomHeader.VerticalAlignment = VerticalAlignment.Center;
			DynamicGrid.Children.Add(RoomHeader);
			TextBlock HeaderTypeRoom = new TextBlock();
			HeaderTypeRoom.Text = "Type";
			HeaderTypeRoom.FontSize = 24;
			HeaderTypeRoom.Foreground = new SolidColorBrush(Colors.White);
			HeaderTypeRoom.TextAlignment = TextAlignment.Center;
			HeaderTypeRoom.VerticalAlignment = VerticalAlignment.Center;
			Grid.SetRow(HeaderTypeRoom, 0);
			Grid.SetColumn(HeaderTypeRoom, 1);
			DynamicGrid.Children.Add(HeaderTypeRoom);
		}

		private void CreateBackgroundHeader(int row, int col)
        {
			Rectangle rect = new Rectangle();
			rect.Stroke = System.Windows.Media.Brushes.Black;
			rect.Fill = System.Windows.Media.Brushes.DimGray;
			rect.Stretch = Stretch.UniformToFill;
			rect.Opacity = 1;
			Grid.SetRow(rect, row);
			Grid.SetColumn(rect, col);
			DynamicGrid.Children.Add(rect);
		}

		private void CreateBackgroundItems(int row, int col)
		{
			Rectangle rect = new Rectangle();
			rect.Stroke = System.Windows.Media.Brushes.Black;
			rect.Stretch = Stretch.UniformToFill;
			rect.Opacity = .5;
			Grid.SetRow(rect, row);
			Grid.SetColumn(rect, col);
			DynamicGrid.Children.Add(rect);
		}

		private void btnPrev_Click(object sender, RoutedEventArgs e)
        {
			items.RefreshMoveToPrev();
			RefreshItemsGrid();
			LoadData(items);
		}

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
			items.RefreshMoveToNext();
			RefreshItemsGrid();
			LoadData(items);
		}
    }
}
