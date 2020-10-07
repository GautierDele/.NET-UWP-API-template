using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace ClientApp.ViewModel
{
    class MainViewModel : ViewModelBase
    {
        private int _id;

        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                RaisePropertyChanged("Id");
            }
        }


        public ICommand Add_Click { get; private set; }
        public ICommand Navigate_Click { get; private set; }

        public MainViewModel()
        {
            Add_Click = new RelayCommand(ActionAdd);
            Navigate_Click = new RelayCommand(ActionNavigate);
        }

        private void ActionAdd()
        {
            throw new NotImplementedException("TODO");
        }

        private void ActionNavigate()
        {
            (Window.Current.Content as Frame).Navigate(typeof(MainPage));
        }
    }
}
