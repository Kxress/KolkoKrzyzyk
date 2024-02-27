using System.Windows;
using KolkoKrzyzyk.states;

namespace KolkoKrzyzyk
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Game game_ = new Game();
            mainFrame.Content = game_;
        }
    }
}