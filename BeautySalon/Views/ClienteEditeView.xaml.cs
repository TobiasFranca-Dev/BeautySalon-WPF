using BeautySalon.ViewModels;
using System.Windows;
using System.Windows.Input;

namespace BeautySalon.Views
{
    public partial class ClienteEditeView : Window
    {
        public ClienteEditeView(int codCliente)
        {            
            InitializeComponent();

            Activate();

            if (codCliente == 0)
            {
                Title = "Beaut Salon - Cadastro de cliente";
            }
            else
            {
                Title = "Beaut Salon - Edição de cadastro de cliente";
            }

            DataContext = new ClienteEditeViewModel(codCliente);
        }

        private void Window_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            var elemento = e.OriginalSource as UIElement;


            if (elemento == null)
            {
                return;
            }

            if (e.Key == Key.Enter)
            {
                elemento.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
            }

            if (e.Key == Key.Escape)
            {
                Close();
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
