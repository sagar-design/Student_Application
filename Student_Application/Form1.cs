using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Student_Application
{
    public partial class Form1 : Form
    {
        static string s = "server=SAGAR-SS;database=SAGAR;integrated security=true";
        SqlConnection con = new SqlConnection(s);
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            autoincrement();
            Data();
        }
        public void autoincrement()
        {
            int r;
            con.Open();
            SqlCommand cmd = new SqlCommand("select max(rno)from studentt", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string d = dr[0].ToString();
                if (d == "")
                {
                    textBox1.Text = "1";
                }
                else
                {
                    r = Convert.ToInt16(dr[0].ToString());
                    r = r + 1;
                    textBox1.Text = r.ToString();
                }
            }
            dr.Close();
            con.Close();
        }
        public void Data()
        {
            SqlDataAdapter adp = new SqlDataAdapter("select * from studentt", con);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Show();
        }
        public void cleardata()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            comboBox1.Text = "";
        }

        private void label1_Click(object sender, EventArgs e)
        {
            //no use
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {//cell click event
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells[0].Value.ToString();
                textBox2.Text = row.Cells[1].Value.ToString();
                if (row.Cells[2].Value.ToString() == "Male")
                    radioButton1.Checked = true;
                else
                    radioButton2.Checked = true;

                textBox3.Text = row.Cells[3].Value.ToString();
                comboBox1.Text = row.Cells[4].Value.ToString();
                dateTimePicker1.Text = row.Cells[5].Value.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {//insert button
            string gender;
            if (radioButton1.Checked == true)
                gender = "Male";
            else if (radioButton2.Checked == true)
                gender = "Female";
            else
                gender = "Other";
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into studentt values(@p1,@p2,@p3,@p4,@p5,@p6)";
            cmd.Parameters.AddWithValue("@p1", textBox1.Text);
            cmd.Parameters.AddWithValue("@p2", textBox2.Text);
            cmd.Parameters.AddWithValue("@p3", gender);
            cmd.Parameters.AddWithValue("@p4", textBox3.Text);
            cmd.Parameters.AddWithValue("@p5", comboBox1.Text);
            cmd.Parameters.AddWithValue("@p6", dateTimePicker1.Value.Date);
            DialogResult res = MessageBox.Show("Do You Want To Add New Student", "Added Student", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                cmd.ExecuteNonQuery();
            }
            con.Close();
            cleardata();
            autoincrement();
            Data();
        }
        private void button2_Click(object sender, EventArgs e)
        {//search
            SqlDataAdapter adp = new SqlDataAdapter("select * from studentt where rno=" + textBox4.Text + "", con);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Student rno was not found");
            }
            else
            {
                textBox1.Text = dt.Rows[0][0].ToString();
                textBox2.Text = dt.Rows[0][1].ToString();
                if (dt.Rows[0][2].ToString() == "Male")
                    radioButton1.Checked = true;
                else
                    radioButton2.Checked = false;
                textBox3.Text = dt.Rows[0][3].ToString();
                comboBox1.Text = dt.Rows[0][4].ToString();
                dateTimePicker1.Text = dt.Rows[0][5].ToString();
            }


        }
        private void button4_Click(object sender, EventArgs e)
        {//delete
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from studentt where rno=@p1";
            cmd.Parameters.AddWithValue("@p1", textBox1.Text);
            DialogResult res = MessageBox.Show("Do You Want To Delete Student", "Deleted Student", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                cmd.ExecuteNonQuery();
            }
            con.Close();
            cleardata();
            autoincrement();
            Data();
        }

        private void button5_Click(object sender, EventArgs e)
        {//close button
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {//update button
            string gender;
            if (radioButton1.Checked == true)
                gender = "Male";
            else if (radioButton2.Checked == true)
                gender = "Female";
            else
                gender = "Other";
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update studentt set name=@p2,gender=@p3,mob=@p4,qualification=@p5,dob=@p6 where rno=@p1";
            cmd.Parameters.AddWithValue("@p1", textBox1.Text);
            cmd.Parameters.AddWithValue("@p2", textBox2.Text);
            cmd.Parameters.AddWithValue("@p3", gender);
            cmd.Parameters.AddWithValue("@p4", textBox3.Text);
            cmd.Parameters.AddWithValue("@p5", comboBox1.Text);
            cmd.Parameters.AddWithValue("@p6", dateTimePicker1.Value.Date);
            DialogResult res = MessageBox.Show("Do You Want To Update New Student", "Deleted Student", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                cmd.ExecuteNonQuery();
            }
            con.Close();
            cleardata();
            autoincrement();
            Data();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //

        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            comboBox1.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            dateTimePicker1.Text = null;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
