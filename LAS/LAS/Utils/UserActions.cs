using System.ComponentModel;

namespace Tao.LAS.Utils
{
    public class UserActions : INotifyPropertyChanged
    {
        private string _action;

        public UserActions(string action)
        {
            _action = action;
        }

        public string Action
        {
            get { return _action; }
            set 
            { 
                _action = value;
                PropertyChanged(this,new PropertyChangedEventArgs("Action"));
            }
        }

        public string Value
        {
            get { return _action; }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
    
    
}