//Коротких М.А.

using System;
using System.Windows.Forms;

namespace HomeWorkNumber8
{
    public partial class FormNum1 : Form
    {
        public FormNum1()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            var prop = new DateTime().GetType().GetProperties();
            foreach (var s in prop)
                dataGridView1.Rows.Add(s.Name, s.GetMethod.ReturnParameter);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FormNum1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
