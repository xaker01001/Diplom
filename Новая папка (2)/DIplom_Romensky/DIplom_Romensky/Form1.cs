using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace DIplom_Romensky
{
    public partial class Form1 : Form
    {
        public string connectStr = @"Data Source=WIN-9V0FR13D3MB;Initial Catalog=Diplom_Romensky;Persist Security Info=True;User ID=23-01;Password=1";

        public SqlConnection conn; SqlDataReader reader; SqlCommand command;
        public Form1()
        {
            InitializeComponent();
            conn = new SqlConnection(connectStr);
            conn.Open();
            reader = null;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            command = new SqlCommand("SELECT * FROM Employee", conn);

            try
            {
                reader = command.ExecuteReader();
                while (await reader.ReadAsync())
                {

                    if ((textBox1.Text == Convert.ToString(reader["Login"]) &&
                        textBox2.Text == Convert.ToString(reader["Password"])))
                    {
                        Information1 information = new Information1();
                        information.ShowDialog(this);
                        this.Hide();


                    }
                    else
                    {
                        label4.Visible = true;
                    }

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
        }
    }
}
