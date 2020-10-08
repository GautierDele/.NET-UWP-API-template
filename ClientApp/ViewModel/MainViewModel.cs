using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Windows.Input;
using WebApp.Models.EntityFramework;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace ClientApp.ViewModel
{
    class MainViewModel : ViewModelBase
    {
        private string _reference;

        public string Reference
        {
            get { return _reference; }
            set
            {
                _reference = value;
                RaisePropertyChanged("Reference");
            }
        }

        public Telephone telephone { get; set; }


        public ICommand Add_Click { get; private set; }
        public ICommand GetByReference_Click { get; private set; }

        public MainViewModel()
        {
            Add_Click = new RelayCommand(ActionAdd);
            GetByReference_Click = new RelayCommand(ActionGetTelephoneByReference);
        }

        private void ActionAdd()
        {
            throw new NotImplementedException("TODO");
        }

        private void ActionGetTelephoneByReference()
        {
            telephone = WSService.GetTelephoneByReference(Reference).Result;
        }
    }
}
