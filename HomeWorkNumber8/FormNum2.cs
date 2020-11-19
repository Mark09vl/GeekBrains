//Коротких М.А.

using System;
using System.Windows.Forms;

namespace HomeWorkNumber8
{
    public partial class FormNum2 : Form
    {
        public FormNum2()
        {
            InitializeComponent();
            Text = "Text<->Value";
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            textBox1.Text = numericUpDown1.Value.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                numericUpDown1.Value = decimal.Parse(textBox1.Text);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show($"Некорректный ввод: {ex.Message}");
            }
            catch (FormatException ex)
            {
                MessageBox.Show($"Некорректный ввод: {ex.Message}");
            }
        }
    }
}
