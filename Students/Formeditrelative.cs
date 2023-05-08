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
    public partial class Formeditrelative : Form
    {
        public Formeditrelative()
        {
            InitializeComponent();
        }

        private void Formeditrelative_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
        }
    }
}
