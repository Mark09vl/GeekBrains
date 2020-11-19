//Коротких М.А.

using System;
using System.Windows.Forms;
using MyHelper;
namespace HomeWorkNumber8
{
    public partial class FormNum5 : Form
    {
        public FormNum5()
        {
            InitializeComponent();
        }

        private void FormNum5_Load(object sender, EventArgs e)
        {
            MyFunctions.ConverterCSVinXML("..\\..\\..\\HomeWorkNumber6\\students.csv", "..\\..\\students.xml");
            
            Close();
        }
    }
}
