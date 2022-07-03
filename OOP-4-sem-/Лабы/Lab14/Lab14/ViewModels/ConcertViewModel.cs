using Lab14.Context;
using Lab14.Models;
using Models.Commands;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Lab14.ViewModels
{
    public class ConcertViewModel : ViewModelBase
    {
        private UnitOfWork unitOfWork;
        private ObservableCollection<Concert> concerts;
        private ObservableCollection<Concert> userConcerts;
        private string group;        
        private int count;
        private string zone;
        private DateTime when;
        private Concert selectedConcert;

        public Concert SelectedConcert
        {
            get => selectedConcert;
            set
            {
                selectedConcert = value;
                OnPropertyChanged("SelectedConcert");
            }

        }

        public ObservableCollection<Concert> Concerts
        {
            get => concerts;
            set
            {
                concerts = value;
                OnPropertyChanged("Concerts");
            }
        }

        public ObservableCollection<Concert> UserConcerts
        {
            get => userConcerts;
            set
            {
                userConcerts = value;
                OnPropertyChanged("UserConcerts");
            }
        }

        public string Group
        {
            get => group;
            set 
            { 
                group = value; 
                OnPropertyChanged("Group"); 
            }
        }

        public int Count
        {
            get => count;
            set 
            { 
                count = value; 
                OnPropertyChanged("Count"); 
            }
        }

        public string Zone
        {
            get => zone;
            set
            {
                zone = value;
                OnPropertyChanged("Zone");
            }
        }

        public DateTime When
        {
            get => when;
            set
            {
                when = value;
                OnPropertyChanged("Zone");
            }
        }

        private void Load()
        {
            concerts = new ObservableCollection<Concert>(unitOfWork.ConcertRepository.GetList());
            userConcerts = new ObservableCollection<Concert>();
        }

        public ConcertViewModel()
        {
            unitOfWork = new UnitOfWork();
            Load();
        }

        public ICommand BuyCommand => new RelayCommand(obj => CanBuy());

        private async void CanBuy()
        {
            await unitOfWork.ConcertRepository.RemoveAsync(unitOfWork.ConcertRepository.GetByGroup(SelectedConcert.Group).ConcertId);
            CanUpdate();
            userConcerts.Add(selectedConcert);
            MessageBox.Show($"Билет забронирован!\nДоступных билетов: {SelectedConcert.Count.ToString()}");
        }

        public ICommand DeleteGroupCommand => new RelayCommand(obj => CanDelete());

        private void CanDelete()
        {
            try
            {
                MessageBox.Show($"Группа {selectedConcert.Group} будет удалена из заявленных концертов");
                unitOfWork.ConcertRepository.Remove(selectedConcert.ConcertId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public ICommand UpdateCommand => new RelayCommand(obj => CanUpdate());

        private void CanUpdate() => Concerts = new ObservableCollection<Concert>(unitOfWork.ConcertRepository.GetList());

        public ICommand RemoveCommand => new RelayCommand(obj => CanRemoveTicket());

        private async void CanRemoveTicket()
        {
            try
            {
                await unitOfWork.ConcertRepository.RemoveTicket(selectedConcert.Group);
                UserConcerts.Remove(selectedConcert);
                CanUpdate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public ICommand UpdateTicketCommand => new RelayCommand(obj => CanUpdateTicket());

        private async void CanUpdateTicket()
        {
            try
            {
                var newConcert = new Concert();

                newConcert.Zone = Zone;
                newConcert.Count = Count;

                await unitOfWork.ConcertRepository.UpdateAsync(selectedConcert.ConcertId, newConcert);
                CanUpdate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
