// MainWindowViewModel.cs
using System;
using System.ComponentModel;

namespace WPF_DatePicker
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        // 기본값을 설정해두지 않으면 0001년으로 표시되기 때문에 기본값을 지정해 주어야 합니다.
        private DateTime _selectedDateTime = DateTime.Now;
        public DateTime SelectedDateTime
        {
            get => _selectedDateTime;
            set
            {
                _selectedDateTime = value;
                NotifyPropertyChanged(nameof(SelectedDateTime));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
