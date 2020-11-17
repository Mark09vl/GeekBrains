//Коротких М.А.

using System;
using System.Windows.Forms;

namespace HomeWorkNumber7
{
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
        }

        private void BtnPlay_Click(object sender, EventArgs e)
        {
            GameDoubler gameForm = new GameDoubler();
            gameForm.ShowDialog();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            GameGuess gameForm = new GameGuess();
            gameForm.ShowDialog();
        }
    }
}
