using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;



namespace Lab_Task_3
{
    public partial class Form1 : Form
    {

        SqlConnection c = new SqlConnection(@"Data Source=DESKTOP-O06QAG9\SQLEXPRESS;Initial Catalog=Employee;Integrated Security=True");
        SqlCommand cmd, cmd2, dCmd,cmd3;
        SqlDataAdapter ad;
        DataTable dt;
        public Form1()
        {
            InitializeComponent();
            showData();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void AGE_Click(object sender, EventArgs e)
        {

        }

        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        public void Showall_Click(object sender, EventArgs e)
        {
           

        }
        public void showData()
        {
              c = new SqlConnection(@"Data Source=DESKTOP-O06QAG9\SQLEXPRESS;Initial Catalog=Employee;Integrated Security=True");
              ad = new SqlDataAdapter("SELECT * FROM Employee1;", c);
              DataTable dt = new DataTable();
              c.Open();
              ad.Fill(dt);
              dataGridView1.DataSource = dt;
                
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    int selectedRowIndex = dataGridView1.SelectedRows[0].Index;
                    int selectedEmployeeID = Convert.ToInt32(dataGridView1.Rows[selectedRowIndex].Cells["ID"].Value);

                    c = new SqlConnection(@"Data Source=DESKTOP-O06QAG9\SQLEXPRESS;Initial Catalog=Employee;Integrated Security=True");

                    c.Open();

                    dCmd = new SqlCommand("DELETE FROM Employee1 WHERE ID = @EmployeeID", c);

                    dCmd.Parameters.AddWithValue("@EmployeeID", selectedEmployeeID);
                    dCmd.ExecuteNonQuery();
                    MessageBox.Show("Data Deleted from Database");

                    showData();
                    c.Close();
                }
                else
                {
                    MessageBox.Show("Please select a row to delete.");
                }
            }
            
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }
            private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.ResetText();
            textBox2.ResetText();
            textBox3.ResetText();
            textBox4.ResetText();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int idValue = Convert.ToInt32(textBox1.Text);
            string newName = textBox2.Text;
            decimal newSalary = Convert.ToDecimal(textBox3.Text);
            string newCity = textBox4.Text;

            using (SqlConnection c = new SqlConnection(@"Data Source=DESKTOP-O06QAG9\SQLEXPRESS;Initial Catalog=Employee;Integrated Security=True"))
            {
                c.Open();

                using (SqlCommand cmd3 = new SqlCommand("update Employee1 set Name=@Name, Salary=@Salary, City=@City where ID=@id", c))
                {
                    cmd3.Parameters.AddWithValue("@Name", newName);
                    cmd3.Parameters.AddWithValue("@Salary", newSalary);
                    cmd3.Parameters.AddWithValue("@City", newCity);
                    cmd3.Parameters.AddWithValue("@id", idValue);


                    cmd3.ExecuteNonQuery();
                    MessageBox.Show("Record Updated Successfully");
                }
            }
        

            showData();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            try
            {

                int newID = Convert.ToInt32(textBox1.Text);
                string newName = textBox2.Text;
                decimal newSalary = Convert.ToDecimal(textBox3.Text);
                string newCity = textBox4.Text;

                c = new SqlConnection(@"Data Source=DESKTOP-O06QAG9\SQLEXPRESS;Initial Catalog=Employee;Integrated Security=True");
                
                c.Open();

                cmd2 = new SqlCommand("INSERT INTO Employee1 (ID, NAME, SALARY, CITY) VALUES (@ID, @Name, @Salary, @City)", c);
                    
                        cmd2.Parameters.AddWithValue("@ID", newID);
                        cmd2.Parameters.AddWithValue("@Name", newName);
                        cmd2.Parameters.AddWithValue("@Salary", newSalary);
                        cmd2.Parameters.AddWithValue("@City", newCity);

                        cmd2.ExecuteNonQuery();
                        MessageBox.Show("Data Inserted into Database");
                    
                


                showData();
                c.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
