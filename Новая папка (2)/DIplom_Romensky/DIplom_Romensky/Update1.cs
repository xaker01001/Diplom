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

namespace DIplom_Romensky
{
    public partial class Update1 : Form
    {
        public string connectStr = @"Data Source=WIN-9V0FR13D3MB;Initial Catalog=Diplom_Romensky;Persist Security Info=True;User ID=23-01;Password=1";

        public SqlConnection conn; SqlDataReader reader; SqlCommand command;
        private Information1 Form;
        public Update1(Information1 form,int number)
        {
            InitializeComponent();
            conn = new SqlConnection(connectStr);
            conn.Open();
            reader = null;
            Form = form;
            if (number == 2) { Сотрудники.SelectedTab = tabPage2; }
            if (number == 3) { Сотрудники.SelectedTab = tabPage3; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && maskedTextBox1.Text != "" &&
             maskedTextBox4.Text != "" && textBox4.Text != "" &&textBox5.Text != "")
            {
                command = new SqlCommand("UPDATE Employee SET Name = '" + textBox1.Text + "', Surname = '" +
                    textBox2.Text + "', Patronymic = '" + textBox3.Text + "', DateOfBirth = '" + maskedTextBox1.Text +
                    "', Phone = '" + maskedTextBox4.Text + "', Login = '" + textBox4.Text + "'," +
                    " Password= '" + textBox5.Text + "'WHERE Id = '" + Global.upd1 + "'; ", conn);
                command.ExecuteNonQuery();
                string sqlExpression = "SELECT * from Employee";
                using (SqlConnection connection = new SqlConnection(connectStr))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    Form.tab.Clear();
                    Form.tab.Load(command.ExecuteReader());
                    Form.dataGridView1.DataSource = Form.tab.DefaultView;
                    connection.Close();
                }
                conn.Close();

            }
            else
            {
                MessageBox.Show("Введены не все данные", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (textBox10.Text != "" && textBox9.Text != "" && textBox8.Text != "" && maskedTextBox2.Text != "" &&
            textBox7.Text != "")
            {
                command = new SqlCommand("UPDATE Client SET Name = '" + textBox10.Text + "', Surname = '" +
                    textBox9.Text + "', Patronymic = '" + textBox8.Text + "', DateOfBirth = '" + maskedTextBox2.Text +
                    "', Tovar = '" + textBox7.Text + "'WHERE Id = '" + Global.upd1 + "'; ", conn);
                command.ExecuteNonQuery();
                string sqlExpression = "SELECT * from Client";
                using (SqlConnection connection = new SqlConnection(connectStr))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    Form.tab1.Clear();
                    Form.tab1.Load(command.ExecuteReader());
                    Form.dataGridView2.DataSource = Form.tab1.DefaultView;
                    connection.Close();
                }
                conn.Close();

            }
            else
            {
                MessageBox.Show("Введены не все данные", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox12.Text != "" && textBox11.Text != "" && textBox6.Text != "")
            {
                command = new SqlCommand("UPDATE Tovar SET Tovar = '" + textBox12.Text + "', Saleepeople = '" +
                    textBox11.Text + "', Price = '" + textBox6.Text +  "'WHERE Id = '" + Global.upd1 + "'; ", conn);
                command.ExecuteNonQuery();
               
                string sqlExpression = "SELECT * from Tovar";
                using (SqlConnection connection = new SqlConnection(connectStr))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    Form.tab2.Clear();
                    Form.tab2.Load(command.ExecuteReader());
                    Form.dataGridView2.DataSource = Form.tab2.DefaultView;
                    connection.Close();
                }
                conn.Close();

            }
            else
            {
                MessageBox.Show("Введены не все данные", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Update1_Load(object sender, EventArgs e)
        {

        }
    }
}
