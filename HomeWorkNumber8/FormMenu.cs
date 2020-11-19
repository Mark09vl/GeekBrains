//Коротких М.А.

using System;
using System.Windows.Forms;

namespace HomeWorkNumber8
{
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
        }

        private void Btn1_Click(object sender, EventArgs e)
        {
            FormNum1 f = new FormNum1();
            f.ShowDialog();
        }

        private void Btn2_Click(object sender, EventArgs e)
        {
            FormNum2 f = new FormNum2();
            f.ShowDialog();
        }

        private void Btn3_Click(object sender, EventArgs e)
        {
            FormNum3 f = new FormNum3();
            f.ShowDialog();
        }

        private void Btn4_Click(object sender, EventArgs e)
        {
            FormNum4 f = new FormNum4();
            f.ShowDialog();
        }

        private void Btn5_Click(object sender, EventArgs e)
        {
            FormNum5 f = new FormNum5();
            f.ShowDialog();
        }
    }
}
