using System.Windows;
using System.Windows.Controls;

namespace KolkoKrzyzyk.states
{
    public partial class Game : Page
    {
        public string krzyzyk = "\x2715";
        public string kolko = "\x25EF";
        public bool czyKrzyzyk = false;

        public Game()
        {
            InitializeComponent();

            // przypisywanie eventu btnClick wszystkim przyciskom
            foreach (UIElement element in plansza.Children)
            {
                if (element is Button button)
                {
                    button.Click += new RoutedEventHandler(btnClick);
                }
            }
        }

        // naprzemienna zmiana symbolu
        private void btnClick(object sender, RoutedEventArgs e)
        {
            var nacisnietyPrzycisk = e.Source as Button;

            if (!czyKrzyzyk)
            {
                nacisnietyPrzycisk.Content = krzyzyk;
                czyKrzyzyk = true;
            }
            else
            {
                nacisnietyPrzycisk.Content = kolko;
                czyKrzyzyk = false;
            }
        }
    }
}