using BeautySalon.ViewModels;
using BeautySalon.Views;
using System.Windows;

namespace BeautySalon
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            var frm = new Login();
            frm.ShowDialog();

            if (Shared.UsuarioLogado != null)
            {
                InitializeComponent();
                DataContext = new MenuViewModel();
            }
            else
            {
                Close();
            }
        }
    }
}
