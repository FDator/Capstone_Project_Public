using System.Threading.Tasks;
using System.Windows;

using ViewModel;
using System.Collections;


namespace CapGUI2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ViewModelClass();
        }
    }
}
