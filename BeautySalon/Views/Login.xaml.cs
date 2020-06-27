using BeautySalon.Repositorios;
using System.Windows;
using System.Windows.Input;

namespace BeautySalon.Views
{
    public partial class Login : Window
    {
        RepositorioUsuario repositorio;
        public Login()
        {
            InitializeComponent();

            repositorio = new RepositorioUsuario();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            var user = txtUsuario.Text;
            var pss = txtSenha.Password;

            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pss))
            {
                MessageBox.Show("Usuário e senha devem ser preenchidos, verifique!", "Atenção", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }

            var result = repositorio.Login(user, pss);

            if (result != null)
            {
                Shared.UsuarioLogado = result;
                Close();
            }
            else
            {
                MessageBox.Show("Usuário ou senha inválidos. Verifique!!!", "Atenção", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }

        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Deseja realmente sair do sistema?", "Atenção", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                Close();
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TraversalRequest tRequest = new TraversalRequest(FocusNavigationDirection.Next);
                UIElement keyboardFocus = Keyboard.FocusedElement as UIElement;

                if (keyboardFocus != null)
                {
                    keyboardFocus.MoveFocus(tRequest);
                }

                e.Handled = true;
            }
        }
    }
}
