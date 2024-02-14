using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Student_Application
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult res= MessageBox.Show("really","Really",MessageBoxButtons.OKCancel,MessageBoxIcon.Error);
            if (res == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text=="admin" && textBox2.Text == "123")
            {
                MessageBox.Show("Login Succesful");
                Form1 f=new Form1();
                f.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid Username Or Password");
                textBox1.Clear();
                textBox2.Clear();
                textBox1.Focus();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
