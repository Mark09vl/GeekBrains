//Коротких М.А.

using System;
using System.Windows.Forms;
using MyHelper;

namespace HomeWorkNumber7
{
    public partial class GameGuess : Form
    {

        int randValue = MyFunctions.GetRandomValue(1, 100);

        private void AddTry(object sender)
        {
            LblTry.Text = (int.Parse(LblTry.Text) + 1).ToString();
            CheckWinner();
        }

        private void CheckWinner()
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "0";
            }

            int value = int.Parse(textBox1.Text);

            if (randValue == value)
            {

                MessageBox.Show($"Ура! У вас получилось! \n" +
                            $"Вы смогли угадать число {randValue} за {LblTry.Text} попыток!");

                this.Close();
            }
            else if (randValue > value)
            {
                MessageBox.Show($"Увы :( \n" +
                            $"Вы не угадали. Загаданное число больше!");
            }
            else if (randValue < value)
            {
                MessageBox.Show($"Увы :( \n" +
                            $"Вы не угадали. Загаданное число меньше!");
            }
        }

        public GameGuess()
        {
            InitializeComponent();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddTry(sender);
        }

        private void GameGuess_Load(object sender, EventArgs e)
        {
            textBox1.Text = "0";

            MessageBox.Show($"Ваша задача: \n" +
                            $"За минимальное количество попыток, угадать загаданное число!");
        }
    }
}
