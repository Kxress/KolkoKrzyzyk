using System.Windows;
using System.Windows.Controls;

namespace KolkoKrzyzyk.states
{
    public partial class Game : Page
    {
        string krzyzyk = "\x2715";
        string kolko = "\x25EF";
        char biezacySymbol = 'x';

        List<Button> listaPrzyciskow = new List<Button>();

        char[,] planszaGry =
        {
            {'n', 'n', 'n'},
            {'n', 'n', 'n'},
            {'n', 'n', 'n'}
        };

        int indexRzedu;
        int indexKolumny;

        int ruchCounter = 0;

        //przechodzenie po rzedach planszy i dodawanie przyciskow do listy
        private void AddButtonsToList(Grid grid, List<Button> list)
        {
            foreach (UIElement element in grid.Children)
            {
                if (element is Button button)
                {
                    list.Add(button);
                }
            }
        }

        public Game()
        {
            InitializeComponent();

            AddButtonsToList(buttonRow1, listaPrzyciskow);
            AddButtonsToList(buttonRow2, listaPrzyciskow);
            AddButtonsToList(buttonRow3, listaPrzyciskow);
        }

        private void btnClick(object sender, RoutedEventArgs e)
        {

            Button nacisnietyPrzycisk = (Button)e.Source;

            for (int i = 0; i < listaPrzyciskow.Count; i++)
            {
                if (nacisnietyPrzycisk == listaPrzyciskow[i])
                {
                    indexRzedu = i / 3;
                    indexKolumny = i % 3;

                    // zamienia odpowiadajace planszy n w planszaGry na symbol
                    if (biezacySymbol == 'x')
                    {
                        planszaGry[indexRzedu, indexKolumny] = 'x';
                    }
                    else
                    {
                        planszaGry[indexRzedu, indexKolumny] = 'o';
                    }

                    break;
                }
            }

            // sprawdzenie wygranej
            WinCheck(nacisnietyPrzycisk);

            // naprzemienne pojawianie sie symboli i zmiana ruchu
            if (biezacySymbol == 'x')
            {
                nacisnietyPrzycisk.Content = krzyzyk;
                ruchInfo.Content = $"Ruch {kolko}";
                biezacySymbol = 'o';
            }
            else
            {
                nacisnietyPrzycisk.Content = kolko;
                ruchInfo.Content = $"Ruch {krzyzyk}";
                biezacySymbol = 'x';
            }

            // zapobieganie zaznaczenia pola drugi raz
            nacisnietyPrzycisk.Click -= btnClick;

            ruchCounter++;
        }

        bool gameEnd = false;

        private void WinCheck(Button nacisnietyPrzycisk)
        {
            // sprawdzanie rzedow
            for (int i = 0; i < 3; i++)
            {
                if (planszaGry[i, 0] == biezacySymbol && planszaGry[i, 1] == biezacySymbol && planszaGry[i, 2] == biezacySymbol)
                {
                    gameEnd = true;
                    IsHitTestVisible = false;
                    EndWindow endWindow_ = new EndWindow(biezacySymbol);
                    endWindow_.Show();
                }
            }

            // sprawdzanie kolumn
            for (int j = 0; j < 3; j++)
            {
                if (planszaGry[0, j] == biezacySymbol && planszaGry[1, j] == biezacySymbol && planszaGry[2, j] == biezacySymbol)
                {
                    gameEnd = true;
                    IsHitTestVisible = false;
                    EndWindow endWindow_ = new EndWindow(biezacySymbol);
                    endWindow_.Show();
                }
            }

            // sprawdzanie na skos
            if ((planszaGry[0, 0] == biezacySymbol && planszaGry[1, 1] == biezacySymbol && planszaGry[2, 2] == biezacySymbol) ||
                (planszaGry[0, 2] == biezacySymbol && planszaGry[1, 1] == biezacySymbol && planszaGry[2, 0] == biezacySymbol))
            {
                gameEnd = true;
                IsHitTestVisible = false;
                EndWindow endWindow_ = new EndWindow(biezacySymbol);
                endWindow_.Show();
            }

            // remis
            if (ruchCounter == 8 && !gameEnd)
            {
                IsHitTestVisible = false;
                EndWindow endWindow_ = new EndWindow();
                endWindow_.Show();
            }
        }
    }
}