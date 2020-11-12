using ProjetRESOTEL.Entities;
using ProjetRESOTEL.Service;
using System;
using System.Collections.Generic;
using System.Data;
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

		private readonly List<Bedroom> bedrooms = new List<Bedroom>();
		private readonly List<Reservation> reservations = new List<Reservation>();
		private DateTime currentDate = DateTime.Now;
		private int pagination = 1;
		private int numberOfItems = 7;

		private Bedroom GetRoom(int idBedrrom)
		{
			Bedroom bedroom = new Bedroom();
			foreach (Bedroom room in bedrooms)
			{
				if (room.IdBedroom == idBedrrom)
				{
					bedroom = room;

				}
			}
			return bedroom;
		}



		public ucHome()
		{

			InitializeComponent();

			// Service charger les chambres
			bedrooms = BedroomService.Instance.LoadBedrooms();
			foreach (Bedroom room in bedrooms)
			{
				room.typeOfBedroom = BedroomService.Instance.TypeOfRoom(room.IdBedroom);
			}

			// Service charger les réservation
			reservations = ReservationService.Instance.LoadReservations();
			foreach (Reservation room in reservations)
			{
				room.bedroom = GetRoom(room.IdBedroom);
			}

			currentDate = DateTime.Now;

			//Params Grid
			DynamicGrid.ShowGridLines = true;

			ColumnDefinition gridCol1 = new ColumnDefinition();
			DynamicGrid.ColumnDefinitions.Add(gridCol1);
			ColumnDefinition gridCol2 = new ColumnDefinition();
			DynamicGrid.ColumnDefinitions.Add(gridCol2);

			//create fix Header
			TextBlock RoomHeader = new TextBlock();
			RoomHeader.Text = "Chambre";
			RoomHeader.FontSize = 24;
			Grid.SetRow(RoomHeader, 0);
			Grid.SetColumn(RoomHeader, 0);
			RoomHeader.Background = new SolidColorBrush(Colors.DimGray);
			RoomHeader.Foreground = new SolidColorBrush(Colors.White);
			RoomHeader.TextAlignment = TextAlignment.Center;
			DynamicGrid.Children.Add(RoomHeader);
			TextBlock HeaderTypeRoom = new TextBlock();
			HeaderTypeRoom.Text = "Type";
			HeaderTypeRoom.FontSize = 24;
			HeaderTypeRoom.Background = new SolidColorBrush(Colors.DimGray);
			HeaderTypeRoom.Foreground = new SolidColorBrush(Colors.White);
			HeaderTypeRoom.TextAlignment = TextAlignment.Center;
			Grid.SetRow(HeaderTypeRoom, 0);
			Grid.SetColumn(HeaderTypeRoom, 1);
			DynamicGrid.Children.Add(HeaderTypeRoom);

			// Dynamic Header with dates values
			for (int i = 0; i < (numberOfItems * pagination); i++)
			{
				var date = currentDate.AddDays(i).ToString("dd MMMM");
				int position = i + 2;
				ColumnDefinition gridColDynamic = new ColumnDefinition();
				DynamicGrid.ColumnDefinitions.Add(gridColDynamic);
				//create dynamic header
				TextBlock dateHeader = new TextBlock();
				dateHeader.Text = date + "";
				dateHeader.FontSize = 18;
				dateHeader.Background = new SolidColorBrush(Colors.DimGray);
				dateHeader.Foreground = new SolidColorBrush(Colors.White);
				dateHeader.TextAlignment = TextAlignment.Center;
				Grid.SetRow(dateHeader, 0);
				Grid.SetColumn(dateHeader, position);
				DynamicGrid.Children.Add(dateHeader);
			}

			// Add rooms and types
			for (int i = 0; i < bedrooms.Count; i++)
			{
				RowDefinition gridRow = new RowDefinition();
				DynamicGrid.RowDefinitions.Add(gridRow);

				//create dynamic NumberOfRoom
				TextBlock NumberOfRoom = new TextBlock();
				NumberOfRoom.Text = "N° " + bedrooms[i].RoomNumber;
				NumberOfRoom.FontSize = 18;
				NumberOfRoom.TextAlignment = TextAlignment.Center;
				NumberOfRoom.VerticalAlignment = VerticalAlignment.Center;
				Grid.SetRow(NumberOfRoom, i + 1);
				Grid.SetColumn(NumberOfRoom, 0);
				DynamicGrid.Children.Add(NumberOfRoom);

				//create dynamic TypeOfRoom
				TextBlock TypeOfRoom = new TextBlock();
				TypeOfRoom.Text = "" + bedrooms[i].typeOfBedroom;
				TypeOfRoom.FontSize = 18;
				TypeOfRoom.TextAlignment = TextAlignment.Center;
				TypeOfRoom.VerticalAlignment = VerticalAlignment.Center;
				Grid.SetRow(TypeOfRoom, i + 1);
				Grid.SetColumn(TypeOfRoom, 1);
				DynamicGrid.Children.Add(TypeOfRoom);
			}

			// Check reservation
			for (int i = 0; i < bedrooms.Count; i++)
			{
				for (int j = 0; j < numberOfItems; j++)
				{
					TextBlock res = new TextBlock();
					if (IsReserved(bedrooms[i].IdBedroom, j))
					{
						res.Text = "";
						res.Background = new SolidColorBrush(Colors.Red);
					}
					else
					{
						res.Text = "";
					}
					res.TextAlignment = TextAlignment.Center;
					res.VerticalAlignment = VerticalAlignment.Center;
					Grid.SetRow(res, i + 1);
					Grid.SetColumn(res, j + 2);
					DynamicGrid.Children.Add(res);
				}
			}
		}

		private bool IsReserved(int idBedrooms, int index)
		{
			bool isReserved = false;
			var date = currentDate.AddDays(index);
			foreach (Reservation reservation in reservations)
			{
				if (reservation.bedroom.IdBedroom == idBedrooms)
				{
					isReserved = CheckOutDate(date, reservation.StartDate, reservation.EndDate);

				}
			}
			return isReserved;
		}

		private bool CheckOutDate(DateTime curent, DateTime start, DateTime end)
		{
			bool isOut = false;
			int resultStart = DateTime.Compare(curent, start);
			int resultEnd = DateTime.Compare(curent, end);
			if (resultStart > 0 && resultEnd < 0)
			{
				isOut = true;
			}
			else if (resultStart == 0)
			{
				isOut = true;
			}

			return isOut;
		}

		void OnClickPrev(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("Prev planning Not implements yet");
			currentDate = currentDate.AddDays(-7);
		}

		void OnClickNext(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("Next Not implements yet");
			currentDate = currentDate.AddDays(+7);
		}

	}
}
