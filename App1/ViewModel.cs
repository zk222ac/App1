using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace App1
{
    class ViewModel : INotifyPropertyChanged
    {
        private string _info;

        public string Info
        {
            get { return _info; }
            set { _info = value; OnPropertyChanged(); }
        }

        private string _numberOfCharacters;
        public string NumberOfCharacters
        {
            get => _numberOfCharacters;
            set
            { _numberOfCharacters = value; OnPropertyChanged(); }
        }

        public ViewModel()
        {
            // enable sync : unresponsiveness
            //CountButton = new RelayCommand(CountNumbersInFileSync);
            // enable Async : responsiveness
            CountButton = new RelayCommand(CountNumbersInFileAsync);
        }

        public ICommand CountButton { get; set; }


        // Enable this method when synchronous call
        public  void CountNumbersInFileSync()
        {
            NumberOfCharacters = "";
            //Read from File
            //Synchronize call
            Info = "Is counting on";
            int numbers = Count();
            Info = "Every thing is now spoken";
            NumberOfCharacters = "there are " + numbers + " count in the file";
            Info = " Now are files spoken";
        }
        public async void CountNumbersInFileAsync()
        {
            NumberOfCharacters = "";
            //Read from File
            //ASynchronize call
            Info = "Is counting on";
            //Asynchronous
            Task<int> task = new Task<int>(Count);
            task.Start();
            Info = "Every thing is now spoken";
            int numbers12 = await task;
            NumberOfCharacters = "there are " + numbers12 + " count in the file";
            Info = "Every thing is now spoken";

        }


        public int Count()
        {
            Task.Delay(8000).Wait();
            return 1000000;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

   
}
