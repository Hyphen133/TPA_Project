using System.Windows;
using ViewModel;

namespace ViewWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var viewModel = new MyViewModel(new ViewBrowse());
            DataContext = viewModel;
            Closing += viewModel.OnWindowClosing;
        }
    }
}
