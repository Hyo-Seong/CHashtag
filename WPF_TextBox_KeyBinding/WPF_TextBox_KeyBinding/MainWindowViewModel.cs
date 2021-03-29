using Prism.Commands;
using Prism.Mvvm;
using System.Windows;

namespace WPF_TextBox_KeyBinding
{
    public class MainWindowViewModel : BindableBase
    {
        private string _id;
        public string Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        public DelegateCommand LoginCommand { get; private set; }
        
        public MainWindowViewModel()
        {
            LoginCommand = new DelegateCommand(Login);
        }

        private void Login()
        {
            // ViewModel에서 MessageBox를 사용하는 것은 좋지 않지만 이해를 돕기위해 MessagegBox를 사용하였습니다.
            MessageBox.Show("Id: " + Id);
        }
    }
}
