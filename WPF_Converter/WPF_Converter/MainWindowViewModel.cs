// MainWindowViewModel.cs
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WPF_Converter
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private int _personCount;
        public int PersonCount
        {
            get => _personCount;
            set
            {
                _personCount = value;
                NotifyPropertyChanged();
            }
        }

        private bool _checkBoxIsChecked;
        public bool CheckBoxIsChecked
        {
            get => _checkBoxIsChecked;
            set
            {
                _checkBoxIsChecked = value;
                NotifyPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
