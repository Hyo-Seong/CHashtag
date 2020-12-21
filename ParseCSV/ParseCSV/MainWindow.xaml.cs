using ParseCSV.ViewModels;
using System.Windows;

namespace ParseCSV
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainWindowViewModel _viewModel;
        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new MainWindowViewModel();
            this.DataContext = _viewModel;
        }
    }
}
