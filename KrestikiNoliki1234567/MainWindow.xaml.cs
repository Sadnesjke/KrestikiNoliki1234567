using System.Windows;
using System.Windows.Controls;

namespace KrestikiNoliki1234567
{
    public partial class MainWindow : Window
    {
        private char[,] board = new char[3, 3];
        private char currentPlayer = 'X';
        private Button[,] buttons;

        public MainWindow()
        {
            InitializeComponent();
            InitializeButtons();
            NewGame();
        }

        private void InitializeButtons()
        {
            buttons = new Button[3, 3]
            {
                { Btn00, Btn01, Btn02 },
                { Btn10, Btn11, Btn12 },
                { Btn20, Btn21, Btn22 }
            };
        }

        private void NewGame()
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    board[i, j] = ' ';
                    buttons[i, j].Content = "";
                    buttons[i, j].IsEnabled = true;
                }
            currentPlayer = 'X';
            Title = "Крестики-нолики v1.0 — Ходит X";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if (btn.Content != null && btn.Content.ToString() != "")
                return;

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if (buttons[i, j] == btn)
                    {
                        board[i, j] = currentPlayer;
                        btn.Content = currentPlayer.ToString();
                        btn.IsEnabled = false;

                        if (CheckWinner())
                        {
                            MessageBox.Show($"Игрок {currentPlayer} победил!");
                            NewGame();
                            return;
                        }

                        if (IsBoardFull())
                        {
                            MessageBox.Show("Ничья!");
                            NewGame();
                            return;
                        }

                        currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
                        Title = $"Крестики-нолики v1.0 — Ходит {currentPlayer}";
                        return;
                    }
        }

        private bool CheckWinner()
        {
            for (int i = 0; i < 3; i++)
                if (board[i, 0] != ' ' && board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2])
                    return true;

            for (int j = 0; j < 3; j++)
                if (board[0, j] != ' ' && board[0, j] == board[1, j] && board[1, j] == board[2, j])
                    return true;

            if (board[0, 0] != ' ' && board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
                return true;
            if (board[0, 2] != ' ' && board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
                return true;

            return false;
        }

        private bool IsBoardFull()
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if (board[i, j] == ' ')
                        return false;
            return true;
        }
    }
}