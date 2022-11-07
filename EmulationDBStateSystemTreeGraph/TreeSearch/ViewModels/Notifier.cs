using System.ComponentModel;

namespace Bornander.UI.ViewModels {
    public class Notifier : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;
        

        protected void OnPropertyChanged(string propertyName) {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }        
    }
}
