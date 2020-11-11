using ProjetRESOTEL.Entities;
using ProjetRESOTEL.Service;
using System;
using System.Collections.Generic;
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
		private readonly DateTime currentDate = DateTime.Now;
		private int pagination = 1;
		private int numberOfItems = 30;

		private Bedroom getRoom(int idBedrrom)
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

			currentDate = DateTime.Now;
			
			//exemple pour ajouter un jour à la date courante, ça aidera dans la génération (boucle du planning)
			//DateTime exempleToAddDay = today.AddDays(36);

			// Service charger les chambres
			bedrooms = BedroomService.Instance.LoadBedrooms();
			foreach(Bedroom room in bedrooms)
            {
				room.typeOfBedroom = BedroomService.Instance.TypeOfRoom(room.IdBedroom);
			}

			// Service charger les réservation
			reservations = ReservationService.Instance.LoadReservations();
			foreach (Reservation room in reservations)
			{
				room.bedroom = getRoom(room.IdBedroom);
			}

			//Premiere colonne dans le datagrid / binding sur le roomNUmber de la property bedroom (l.94 pour row)
			DataGridTextColumn c1 = new DataGridTextColumn();
			c1.Header = "Chambre";
			c1.Binding = new Binding("RoomNumber");
			c1.Width = 135;
			dgUsers.Columns.Add(c1);

			//Deuxieme colonne idem pour le type de la chmbre
			DataGridTextColumn c2 = new DataGridTextColumn();
			c2.Header = "Type";
			c2.Binding = new Binding("typeOfBedroom");
			c2.Width = 135;
			dgUsers.Columns.Add(c2);

			//génération des colonnes dates en fonction du nombre d'item et de la pagination (sur 30j) / button pagination not implement yet
            for (int i = 0; i < (numberOfItems * pagination); i++)
            {
				DataGridTextColumn c = new DataGridTextColumn();
				c.Header = currentDate;
				c.Width = 135;
				dgUsers.Columns.Add(c);
			}

			//génération des rows / check boolean isReserved à venir ...
			for (int i = 0; i < bedrooms.Count; i++)
			{
				//ajout une row[i]
				dgUsers.Items.Add(bedrooms[i]);
			}
		}

	}
}
