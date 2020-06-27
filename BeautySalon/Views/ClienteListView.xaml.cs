using BeautySalon.ViewModels;
using System.Windows;

namespace BeautySalon.Views
{
    public partial class ClienteListView : Window
    {
        public ClienteListView()
        {
            InitializeComponent();
            Activate();
            DataContext = new ClienteListViewModel();
        }
    }
}
