using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Lab_Task_3
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-O06QAG9\SQLEXPRESS;Initial Catalog=Login;Integrated Security=True;");

        private void button1_Click(object sender, EventArgs e)
        {
            String username, user_password;
            username = textBox1.Text;
            user_password = textBox2.Text;

            try
            {
                string query = "SELECT * FROM Table_1 WHERE username = '"+textBox1.Text+"'AND password = '"+textBox2.Text + "' ";

                SqlDataAdapter sda = new SqlDataAdapter(query,conn);
                DataTable dataTable = new DataTable();
                sda.Fill(dataTable);
                if(dataTable.Rows.Count > 0 )
                {
                    username = textBox1.Text;
                     user_password = textBox2.Text;
                    Form1 From1 = new Form1();
                    From1.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid details");
                    textBox1.Clear();
                    textBox2.Clear();
                }
            }
            catch {
                MessageBox.Show("Error");
            }
            finally
            {
                conn.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
