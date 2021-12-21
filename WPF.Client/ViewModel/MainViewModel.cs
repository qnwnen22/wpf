using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using PropertyChanged;
using System;
using System.ComponentModel;

namespace WPF.Client.ViewModel
{
    public class MainViewModel : ViewModelBase, IDataErrorInfo, INotifyPropertyChanged
    {
        public RelayCommand RelayCommand { get; set; }
        public MainViewModel()
        {
            RelayCommand = new RelayCommand(GetTime);
        }
        public void GetTime()
        {
            currentTime = DateTime.Now.ToString();
        }

        public string currentTime;
        public string CurrentTime
        {
            get
            {
                if (currentTime.IsNullOrWhiteSpace())
                {
                    currentTime = DateTime.Now.ToString();
                }
                return currentTime;
            }
            set
            {
                currentTime = value;
            }
        }

        public string Error => throw new NotImplementedException();

        public string this[string columnName]
        {
            get
            {
                return null;
            }
        }
    }
}