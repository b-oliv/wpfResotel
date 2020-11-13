using ProjetRESOTEL.Entities;
using ProjetRESOTEL.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace ProjetRESOTEL.ViewModels
{
    class ItemsReservationViewModel : ViewModelBase
    {

        public ObservableCollection<ItemReservationViewModel> Items { get => _itemsPlanning; }

        private ObservableCollection<ItemReservationViewModel> _itemsPlanning;
        private ICollectionView _observer;
   
        public List<Bedroom> bedrooms = new List<Bedroom>();
        private List<Reservation> reservations = new List<Reservation>();
        private DateTime _currentDate;
        public DateTime currentDate
        {
            get
            {
                return _currentDate;
            }

            set
            {
                _currentDate = value;
                NotifyPropertyChanged("currentDate");
            }
        }
        public int pagination = 1;
        public int numberOfItems = 7;

        public ItemsReservationViewModel()
        {
            currentDate = DateTime.Now;
            InitItemsReservationPlanning();
        }

        public void RefreshMoveToNext()
        {
            currentDate = currentDate.AddDays(7);
        }

        public void RefreshMoveToPrev()
        {
            currentDate = currentDate.AddDays(-7);
        }

        public void AddReservation()
        {
            MessageBox.Show("Functionalities not implements yet");
        }

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

        private void InitItemsReservationPlanning() {
            //Init item source planning
            List<ItemReservation> lst = new List<ItemReservation>();

            // Service charger les chambres
            bedrooms = BedroomService.Instance.LoadBedrooms();
            foreach (Bedroom room in bedrooms)
            {
                room.typeOfBedroom = BedroomService.Instance.TypeOfRoom(room.IdBedroom);
                lst.Add(new ItemReservation(room));
            }

            // Service charger les réservation
            reservations = ReservationService.Instance.LoadReservations();
            foreach (Reservation reservation in reservations)
            {
                reservation.bedroom = GetRoom(reservation.IdBedroom);
                foreach (ItemReservation item in lst)
                {
                    if (item.bedroom.IdBedroom == reservation.IdBedroom)
                    {
                        item.reservation = reservation;
                    }
                }
            }

            _itemsPlanning = new ObservableCollection<ItemReservationViewModel>();

            foreach (ItemReservation item in lst)
            {
                ItemReservationViewModel vm = new ItemReservationViewModel(item);
                _itemsPlanning.Add(vm);
            }

            _observer = CollectionViewSource.GetDefaultView(_itemsPlanning);
            _observer.CurrentChanged += OnSelectedItemChanged;
            _observer.MoveCurrentToLast();
        }



        private void OnSelectedItemChanged(object sender, EventArgs e)
        {
            NotifyPropertyChanged("ItemSelected");
        }

        public ItemReservationViewModel ItemSelected
        {
            get
            {
                return _observer.CurrentItem as ItemReservationViewModel;
            }
        }

        public bool IsReserved(int idBedrooms, int index)
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
    }
}
