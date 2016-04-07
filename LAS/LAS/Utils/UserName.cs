using System.ComponentModel;

namespace Tao.LAS.Utils
{
    public class UserName : INotifyPropertyChanged

    {
        private string _name;

        public UserName(string name)
        {
            _name = name;
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set 
            { 
                _name = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Name"));
            }
        }

        public string Value
        {
            get
            {
                return _name;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}