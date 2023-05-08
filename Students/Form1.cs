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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "studentDataSet.family". При необходимости она может быть перемещена или удалена.
            this.familyTableAdapter.Fill(this.studentDataSet.family);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "studentDataSet.Students". При необходимости она может быть перемещена или удалена.
            this.studentsTableAdapter.Fill(this.studentDataSet.Students);

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            int id;
            int index;
            index = dataGridView1.CurrentRow.Index;
            id = (int)dataGridView1.Rows[index].Cells[0].Value;
            familyBindingSource.Filter = "id_s= " + id.ToString();
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            int id;
            int index;
            index = dataGridView1.CurrentRow.Index;
            id = (int)dataGridView1.Rows[index].Cells[0].Value;
            familyBindingSource.Filter = "id_s= " + id.ToString();
        }

        private void добавитьСтудентаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formaddstudent f1 = new Formaddstudent();
            if (f1.ShowDialog() == DialogResult.OK)
            {
                string fname_S, adress, Phone_number, Pol, birthplace, email;
                DateTime Birthday;
                fname_S = f1.textBox1.Text;
                adress = f1.textBox2.Text;

                Phone_number = f1.textBox3.Text;
                Birthday = Convert.ToDateTime(f1.textBox4.Text);
                Pol = f1.comboBox1.Items[f1.comboBox1.SelectedIndex].ToString();
                birthplace = f1.textBox5.Text;
                email = f1.textBox6.Text;
                this.studentsTableAdapter.Insert(fname_S, adress, Phone_number, Birthday, Pol, birthplace, email);
                this.studentsTableAdapter.Fill(this.studentDataSet.Students);


            }
        }

        private void удалитьСтудентаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formdelstudent f2 = new Formdelstudent();
            int id_s;
            string fname_S, adress, Phone_number, Pol, birthplace, email;
            DateTime Birthday;
            int index;
            index = dataGridView1.CurrentRow.Index;
            id_s = Convert.ToInt32(dataGridView1[0, index].Value);
            fname_S = Convert.ToString(dataGridView1[1, index].Value);
            adress = Convert.ToString(dataGridView1[2, index].Value);
            Phone_number = Convert.ToString(dataGridView1[3, index].Value);
            Birthday = Convert.ToDateTime(dataGridView1[4, index].Value);
            Pol = Convert.ToString(dataGridView1[5, index].Value);
            birthplace = Convert.ToString(dataGridView1[5, index].Value);
            email = Convert.ToString(dataGridView1[7, index].Value);
            f2.label2.Text = fname_S + " " + adress;
            if (f2.ShowDialog() == DialogResult.OK)
            {
                studentsTableAdapter.Delete(id_s, fname_S, adress, Phone_number, Birthday, Pol, birthplace, email);
                this.studentsTableAdapter.Fill(this.studentDataSet.Students);
            }
        }

        private void редактироватьСтудентаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formeditstudent f3 = new Formeditstudent();
            int index;
            string fname_S, adress, Phone_number, Pol, birthplace, email;
            DateTime Birthday;
            int id_s;
            if (dataGridView1.RowCount <= 1) return;
            index = dataGridView1.CurrentRow.Index;
            if (index == dataGridView1.RowCount - 1) return;
            id_s = (int)dataGridView1.Rows[index].Cells[0].Value;
            fname_S = (string)dataGridView1.Rows[index].Cells[1].Value;
            adress = (string)dataGridView1.Rows[index].Cells[2].Value;
            Phone_number = (string)dataGridView1.Rows[index].Cells[3].Value;
            Birthday = (DateTime)dataGridView1.Rows[index].Cells[4].Value;
            Pol = (string)dataGridView1.Rows[index].Cells[5].Value;
            birthplace = (string)dataGridView1.Rows[index].Cells[6].Value;
            email = (string)dataGridView1.Rows[index].Cells[7].Value;

            f3.textBox1.Text = fname_S;
            f3.textBox2.Text = adress;
            f3.textBox3.Text = Phone_number;
            f3.textBox4.Text = Birthday.ToShortDateString();
            f3.textBox5.Text = birthplace;
            f3.textBox6.Text = email;
            if (Pol == "М") f3.comboBox1.SelectedIndex = 0;
            else f3.comboBox1.SelectedIndex = 1;
            if (f3.ShowDialog() == DialogResult.OK)
            {
                string nfname_S, nadress, nPhone_number, nPol, nbirthplace, nemail;
                DateTime nBirthday;
                nfname_S = f3.textBox1.Text;
                nadress = f3.textBox2.Text;
                nPhone_number = f3.textBox3.Text;
                nBirthday = Convert.ToDateTime(f3.textBox4.Text);
                nPol = f3.comboBox1.Items[f3.comboBox1.SelectedIndex].ToString();
                nbirthplace = f3.textBox5.Text;
                nemail = f3.textBox6.Text;
                studentsTableAdapter.Update(nfname_S, nadress, nPhone_number, nBirthday, nPol, nbirthplace, nemail, id_s, fname_S, adress, Phone_number, Birthday, Pol, birthplace, email);
                this.studentsTableAdapter.Fill(this.studentDataSet.Students);

            }

        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formaddrelative f4 = new Formaddrelative();
            if (f4.ShowDialog() == DialogResult.OK)
            {
                int id_s;
                int index;
                string FIO_r, relation, adress_r, Phone_number_r, email_r, profession;
                index = dataGridView1.CurrentRow.Index;
                id_s = (int)dataGridView1.Rows[index].Cells[0].Value;
                FIO_r = f4.textBox1.Text;
                relation = f4.textBox2.Text;
                adress_r = f4.textBox3.Text;
                Phone_number_r = f4.textBox4.Text;
                email_r = f4.textBox5.Text;
                profession = f4.textBox6.Text;
                this.familyTableAdapter.Insert(id_s, FIO_r, relation, adress_r, Phone_number_r, email_r, profession);
                this.familyTableAdapter.Fill(this.studentDataSet.family);
            }
        }

        private void удалитьРодственникаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formdelrelative f5 = new Formdelrelative();
            int id_s, id_r;
            string FIO_r, relation, adress_r, Phone_number_r, email_r, profession;
            int index;
            index = dataGridView2.CurrentRow.Index;
            id_r = Convert.ToInt32(dataGridView2[0, index].Value);
            id_s = Convert.ToInt32(dataGridView2[1, index].Value);
            FIO_r = Convert.ToString(dataGridView2[2, index].Value);
            relation = Convert.ToString(dataGridView2[3, index].Value);
            adress_r = Convert.ToString(dataGridView2[4, index].Value);
            Phone_number_r = Convert.ToString(dataGridView2[5, index].Value);
            email_r = Convert.ToString(dataGridView2[6, index].Value);
            profession = Convert.ToString(dataGridView2[7, index].Value);
            f5.label2.Text = FIO_r + "/ " + relation + " /" + profession;
            if (f5.ShowDialog() == DialogResult.OK)
            {
                this.familyTableAdapter.Delete(id_r, id_s, FIO_r, relation, adress_r, Phone_number_r, email_r, profession); 
                this.familyTableAdapter.Fill(this.studentDataSet.family);
            }

        }


        private void редактироватьРодственникаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formeditrelative f6 = new Formeditrelative();
            int id_s, id_r;
            string FIO_r, relation, adress_r, Phone_number_r, email_r, profession;
            int index;
            if (dataGridView2.RowCount <= 1) return;
            index = dataGridView2.CurrentRow.Index;
            if (index == dataGridView2.RowCount - 1) return;
            id_r = (int)dataGridView2.Rows[index].Cells[0].Value;
            id_s = (int)dataGridView2.Rows[index].Cells[1].Value;
            FIO_r = (string)dataGridView2.Rows[index].Cells[2].Value;
            relation = (string)dataGridView2.Rows[index].Cells[3].Value;
            adress_r = (string)dataGridView2.Rows[index].Cells[4].Value;
            Phone_number_r = (string)dataGridView2.Rows[index].Cells[5].Value;
            email_r = (string)dataGridView2.Rows[index].Cells[6].Value;
            profession = (string)dataGridView2.Rows[index].Cells[7].Value;
            f6.textBox1.Text = FIO_r;
            f6.textBox2.Text = relation;
            f6.textBox3.Text =adress_r;
            f6.textBox4.Text = Phone_number_r;
            f6.textBox5.Text = email_r;
            f6.textBox6.Text = profession;
            if (f6.ShowDialog() == DialogResult.OK)
            {
                string nFIO_r, nrelation, nadress_r, nPhone_number_r, nemail_r, nprofession;
                nFIO_r = f6.textBox1.Text.ToString();
                nrelation = f6.textBox2.Text;
                nadress_r = f6.textBox3.Text;
                nPhone_number_r = f6.textBox4.Text.ToString();
                nemail_r = f6.textBox5.Text;
                nprofession = f6.textBox6.Text;
                this.familyTableAdapter.Update(id_s, nFIO_r, nrelation, nadress_r, nPhone_number_r, nemail_r, nprofession, id_r, id_s, FIO_r, relation, adress_r, Phone_number_r, email_r, profession);
                this.familyTableAdapter.Fill(this.studentDataSet.family);
            }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            studentsBindingSource.Filter = "fname_S LIKE'" + textBox1.Text + "%'";
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void юношиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f = new Form2();
            f.ShowDialog();
        }

        private void девушкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 f = new Form3();
            f.ShowDialog();
        }

        private void нарынToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 f = new Form4();
            f.ShowDialog();
        }

        private void баткенToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form5 f = new Form5();
            f.ShowDialog();
        }

        private void жалалабадToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form6 f = new Form6();
            f.ShowDialog();
        }

        private void ошToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form7 f = new Form7();
            f.ShowDialog();
        }

        private void таласToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form8 f = new Form8();
            f.ShowDialog();
        }

        private void чуйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form9 f = new Form9();
            f.ShowDialog();
        }

        private void ыссыкКолToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form10 f = new Form10();
            f.ShowDialog();
        }

        private void отецToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form11 f = new Form11();
            f.ShowDialog();
        }

        private void матьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form12 f = new Form12();
            f.ShowDialog();
        }
    }
}