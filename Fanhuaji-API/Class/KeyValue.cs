using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Fanhuaji_API.Class
{
    public class KeyValue : INotifyPropertyChanged
    {
        private string _Key, _Value;
        public string Key { get => _Key; set { _Key = value; OnPropertyChanged(); } }
        public string Value { get => _Value; set { _Value = value; OnPropertyChanged(); } }
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
