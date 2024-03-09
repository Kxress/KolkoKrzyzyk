using System.Windows;
using System.Windows.Media.Imaging;
using WpfAnimatedGif;

namespace KolkoKrzyzyk.states
{
    public partial class EndWindow : Window
    {
        public EndWindow(char biezacySymbol = 'r')
        {
            InitializeComponent();

            BitmapImage gif = new BitmapImage();
            
            gif.BeginInit();
            switch (biezacySymbol)
            {
                case 'x':
                    gif.UriSource = new Uri("../assets/winkrzyzyk.gif", UriKind.RelativeOrAbsolute);
                    break;
                case 'o':
                    gif.UriSource = new Uri("../assets/winkolko.gif", UriKind.RelativeOrAbsolute);
                    break;
                case 'r':
                    gif.UriSource = new Uri("../assets/remis.gif", UriKind.RelativeOrAbsolute);
                    
                    break;
            }
            gif.EndInit();

            ImageBehavior.SetAnimatedSource(winMessage, gif);
        }

        MainWindow mainWindow_ = (MainWindow)Application.Current.MainWindow;
        bool closeMainWindow = true;

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (closeMainWindow)
            {
                mainWindow_.Close();
            }
        }

        private void btnNowaGra_Click(object sender, RoutedEventArgs e)
        {
            closeMainWindow = false;
            Game game_ = new Game();
            mainWindow_.mainFrame.Content = game_;
            Close();
        }

        private void btnWyjdzDoMenu_Click(object sender, RoutedEventArgs e)
        {
            closeMainWindow = false;
            StartPage startPage_ = new StartPage();
            mainWindow_.mainFrame.Content = startPage_;
            Close();
        }
    }
}