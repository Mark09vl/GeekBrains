//Коротких М.А.

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MyHelper;

namespace HomeWorkNumber7
{
    public partial class GameDoubler : Form
    {

        Stack<string> tryValue = new Stack<string>();

        private void AddTryValue(object sender)
        {
            tryValue.Push(((System.Windows.Forms.ButtonBase)sender).Text);
        }

        private void AddTry(object sender)
        {
            LblTry.Text = (int.Parse(LblTry.Text) + 1).ToString();
            AddTryValue(sender);
            CheckWinner();
        }

        private void CheckWinner()
        {
            if (LblNumber.Text == LblTarget.Text)
            {

                MessageBox.Show($"Ура! У вас получилось! \n" +
                            $"Вы смогли получить число {LblTarget.Text} за {LblTry.Text} попыток!");

                this.Close();
            }
            else if (int.Parse(LblNumber.Text) > int.Parse(LblTarget.Text))
            {
                if (BtnBackTry.Enabled)
                {
                    MessageBox.Show($"Увы :( \n" +
                            $"Вы не смогли получить число {LblTarget.Text} за {LblTry.Text} попыток!\n" +
                            $"У вас есть возможность отменить одну попытку!");
                }
                else
                {
                    MessageBox.Show($"Увы :( \n" +
                            $"Вы не смогли получить число {LblTarget.Text} за {LblTry.Text} попыток!\n" +
                            $"Вы проиграли!");
                    this.Close();
                }
            }
        }

        private void ResetGame()
        {
            LblNumber.Text = "0";
            LblTry.Text = "0";
        }

        private void BackTry()
        {
            string LastTry = tryValue.Pop();

            LblTry.Text = (int.Parse(LblTry.Text) - 1).ToString();

            if (LastTry == "x2")
            {
                LblNumber.Text = (int.Parse(LblNumber.Text) / 2).ToString();
            }
            else if (LastTry == "+1")
            {
                LblNumber.Text = (int.Parse(LblNumber.Text) - 1).ToString();
            }

        }

        private void AccessButton(object sender, bool access)
        {
            ((System.Windows.Forms.Control)sender).Enabled = access;
        }

        public GameDoubler()
        {
            InitializeComponent();
        }

        private void BtnCommand1_Click(object sender, EventArgs e)
        {
            LblNumber.Text = (int.Parse(LblNumber.Text) + 1).ToString();
            AddTry(sender);
            if (LblTry.Text == "1")
            {
                AccessButton(BtnBackTry, true);
            }
        }

        private void BtnCommand2_Click(object sender, EventArgs e)
        {
            LblNumber.Text = (int.Parse(LblNumber.Text) * 2).ToString();
            AddTry(sender);
            if (LblTry.Text == "1")
            {
                AccessButton(BtnBackTry, true);
            }
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            ResetGame();
            AccessButton(BtnBackTry, true);
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            LblTarget.Text = MyFunctions.GetRandomValue(1, 100).ToString();

            MessageBox.Show($"Ваша задача: \n" +
                            $"За минимальное количество попыток, получить число: {LblTarget.Text}");

            AccessButton(BtnBackTry, false);
        }

        private void BtnBackTry_Click(object sender, EventArgs e)
        {
            BackTry();
            AccessButton(sender, false);
        }
    }
    
}
