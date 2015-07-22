using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketChainApp.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        private string message;

        public string Message
        {
            get
            {
                return this.message;
            }
            protected set
            {
                if (this.message != null && this.message.Equals(value))
                {
                    return;
                }
                this.message = value;
                this.OnPropertyChanged("Message");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
