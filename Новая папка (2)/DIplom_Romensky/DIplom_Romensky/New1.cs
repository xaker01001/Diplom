using DIplom_Romensky.Core;
using DIplom_Romensky.Entity;
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
    public partial class New1 : Form
    {
        public string connectStr = @"Data Source=WIN-9V0FR13D3MB;Initial Catalog=Diplom_Romensky;Persist Security Info=True;User ID=23-01;Password=1";
        private ClientLogic logic;
        private ClientModel model;
        public SqlConnection conn; SqlDataReader reader; SqlCommand command;
        private Information1 Form;
        public New1(Information1 form,int number)
        {
            InitializeComponent();
            logic = new ClientLogic();
            conn = new SqlConnection(connectStr);
            conn.Open();
            reader = null;
            Form = form;
            if (number == 2) {
                Сотрудники.SelectedTab = tabPage2;               
            }
            if (number == 3) { Сотрудники.SelectedTab = tabPage3; }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

     

        private async void New1_Load(object sender, EventArgs e)
        {
            

        }

        private async void button1_Click_1(object sender, EventArgs e)
        {
            command = new SqlCommand("SELECT Id FROM [Employee]", conn);
            try
            {
                reader = command.ExecuteReader();
                while (await reader.ReadAsync())
                {
                    Global.kod1 = Convert.ToInt32(reader["Id"]);
                    if (Global.max1 < Global.kod1) { Global.max1 = Global.kod1; }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {

                if (reader != null)
                {
                    reader.Close();

                }
            }

            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" &&
                maskedTextBox1.Text != "" && maskedTextBox4.Text != "" && textBox4.Text != "" &&
                textBox5.Text != "")
            {
                command = new SqlCommand("INSERT INTO[Employee](Name,Surname,Patronymic,DateOfBirth,Phone,Login,Password)VALUES(@Name,@Surname,@Patronymic,@DateOfBirth,@Phone,@Login,@Password)", conn);

              //  command.Parameters.AddWithValue("Id", Global.max1 + 1);
                command.Parameters.AddWithValue("Name", textBox1.Text);
                command.Parameters.AddWithValue("Surname", textBox2.Text);
                command.Parameters.AddWithValue("Patronymic", textBox3.Text);
                command.Parameters.AddWithValue("DateOfBirth", maskedTextBox1.Text);
                command.Parameters.AddWithValue("Phone", maskedTextBox4.Text);
                command.Parameters.AddWithValue("Login", textBox4.Text);
                command.Parameters.AddWithValue("Password", textBox5.Text);
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

        private async void button16_Click(object sender, EventArgs e)
        {
             command = new SqlCommand("SELECT Id FROM [Client]", conn);
             try
             {
                 reader = command.ExecuteReader();
                 while (await reader.ReadAsync())
                 {
                     Global.kod2 = Convert.ToInt32(reader["Id"]);
                     if (Global.max2 < Global.kod2) { Global.max2 = Global.kod2; }
                 }

             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
             }
             finally
             {

                 if (reader != null)
                 {
                     reader.Close();

                 }
             }

             if (textBox10.Text != "" && textBox9.Text != "" && textBox8.Text != "" &&
                 maskedTextBox2.Text != "" && comboBox1.Text != "")
             {
                 command = new SqlCommand("INSERT INTO[Client](Name,Surname,Patronymic,DateOfBirth,Tovar)VALUES(@Name,@Surname,@Patronymic,@DateOfBirth,@Tovar)", conn);

              
                 command.Parameters.AddWithValue("Name", textBox10.Text);
                 command.Parameters.AddWithValue("Surname", textBox9.Text);
                 command.Parameters.AddWithValue("Patronymic", textBox8.Text);
                 command.Parameters.AddWithValue("DateOfBirth", maskedTextBox2.Text);
                 command.Parameters.AddWithValue("Tovar", comboBox1.Text);
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
            /*logic.Add(new ClientModel
            {
                Name = textBox10.Text,
                Surname = textBox9.Text,
                Patronymic = textBox8.Text,
                DateOfBirth = DateTime.Parse(maskedTextBox2.Text),
                

            });*/
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            command = new SqlCommand("SELECT Id FROM [Tovar]", conn);
            try
            {
                reader = command.ExecuteReader();
                while (await reader.ReadAsync())
                {
                    Global.kod3 = Convert.ToInt32(reader["Id"]);
                    if (Global.max3 < Global.kod3) { Global.max3 = Global.kod3; }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {

                if (reader != null)
                {
                    reader.Close();

                }
            }

            if (textBox12.Text != "" && textBox11.Text != "" && textBox6.Text != "")
            {
                command = new SqlCommand("INSERT INTO[Tovar](Tovar,Saleepeople,Price)VALUES(@Tovar,@Saleepeople,@Price)", conn);

                command.Parameters.AddWithValue("Tovar", textBox12.Text);
                command.Parameters.AddWithValue("Saleepeople", textBox11.Text);
                command.Parameters.AddWithValue("Price", textBox6.Text);
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
    }
}
