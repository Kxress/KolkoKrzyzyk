using System.Windows;
using System.Windows.Controls;
using System.Diagnostics;

namespace KolkoKrzyzyk.states
{
    public partial class StartPage : Page
    {
        public StartPage()
        {
            InitializeComponent();
        }

        private void btnGraj_Click(object sender, RoutedEventArgs e)
        {
            Game game_ = new Game();
            MainWindow mainWindow_ = (MainWindow)Window.GetWindow(this);
            mainWindow_.mainFrame.Content = game_; 
        }

        private void btnZasady_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("notepad.exe", "..\\..\\..\\zasady.txt");
        }
    }
}