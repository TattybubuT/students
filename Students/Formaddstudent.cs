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
    public partial class Formaddstudent : Form
    {
        public Formaddstudent()
        {
            InitializeComponent();
        }

        private void Formaddstudent_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            comboBox1.SelectedIndex = 1;
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
