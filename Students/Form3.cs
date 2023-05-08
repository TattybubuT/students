using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Students
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "studentDataSet.девушки". При необходимости она может быть перемещена или удалена.
            this.девушкиTableAdapter.Fill(this.studentDataSet.девушки);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "studentDataSet.Юноши". При необходимости она может быть перемещена или удалена.
          //  this.ДевушкиTableAdapter.Fill(this.studentDataSet.Девушки);

            this.reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.ShowDialog();
        }
    }
}
