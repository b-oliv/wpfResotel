using ProjetRESOTEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetRESOTEL.ViewModels
{
    class ItemReservationViewModel : ViewModelBase
    {

        //l'entité du modèle
        private readonly ItemReservation _item;

        //Accesseur sur le modèle (Property en lecture seule)
        public ItemReservation ItemReservation
        {

            get { return _item; }
        }

        public ItemReservationViewModel()
        { }

        //Initialisation de la vue modèle avec l'entité modèle
        public ItemReservationViewModel(ItemReservation item)
        {
            this._item = item ?? throw new NullReferenceException("ItemReservation");
        }

        public Bedroom bedroom
        {
            get { return _item.bedroom; }
            set
            {
                _item.bedroom = value;
                NotifyPropertyChanged();
            }
        }

        public Client client
        {
            get { return _item.client; }
            set
            {
                _item.client = value;
                NotifyPropertyChanged();
            }
        }

        public Reservation reservation
        {
            get { return _item.reservation; }
            set
            {
                _item.reservation = value;
                NotifyPropertyChanged();
            }
        }
    }
}
