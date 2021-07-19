// MainWindow.xaml.cs
using System.Windows;

namespace WPF_DatePicker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();

            // View와 ViewModel을 연결시켜줍니다.
            _viewModel = new MainWindowViewModel();
            this.DataContext = _viewModel;
        }
    }
}
