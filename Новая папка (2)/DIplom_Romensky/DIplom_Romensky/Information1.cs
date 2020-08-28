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
    public partial class Information1 : Form
    {
        BindingSource bs = new BindingSource();
        public DataTable tab = new DataTable();
        public DataTable tab1 = new DataTable();
        public DataTable tab2 = new DataTable();
        public string connectStr = @"Data Source=WIN-9V0FR13D3MB;Initial Catalog=Diplom_Romensky;Persist Security Info=True;User ID=23-01;Password=1";
        public SqlConnection conn; SqlDataReader reader; SqlCommand command;
        public Information1()
        {
            InitializeComponent();
            conn = new SqlConnection(connectStr);
           
            reader = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            New1 new1 = new New1(this, 1);
            new1.ShowDialog(this);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            New1 new1 = new New1(this, 2);
            new1.ShowDialog(this);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            New1 new1 = new New1(this, 3);
            new1.ShowDialog(this);
        }

        private void Information1_Load(object sender, EventArgs e)
        {

           
            string sqlExpression = "SELECT * from Employee";
            using (SqlConnection connection = new SqlConnection(connectStr))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                tab.Load(command.ExecuteReader());
                dataGridView1.DataSource = tab.DefaultView;
                connection.Close();
            }
            string sqlExpression1 = "SELECT * from Client";
            using (SqlConnection connection1 = new SqlConnection(connectStr))
            {
                connection1.Open();
                SqlCommand command1 = new SqlCommand(sqlExpression1, connection1);
                tab1.Load(command1.ExecuteReader());
                dataGridView2.DataSource = tab1.DefaultView;
                connection1.Close();
            }
            string sqlExpression2 = "SELECT * from Tovar";
            using (SqlConnection connection2 = new SqlConnection(connectStr))
            {
                connection2.Open();
                SqlCommand command2 = new SqlCommand(sqlExpression2, connection2);
                tab2.Load(command2.ExecuteReader());
                dataGridView3.DataSource = tab2.DefaultView;
                connection2.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            command = new SqlCommand(
              "DELETE FROM Employee WHERE Id=" + int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString()), conn);
            command.ExecuteNonQuery();
            string sqlExpression = "SELECT * from Employee";
            using (SqlConnection connection = new SqlConnection(connectStr))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                tab.Clear();
                tab.Load(command.ExecuteReader());
                dataGridView1.DataSource = tab.DefaultView;
                connection.Close();
            }
            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Update1 update = new Update1(this,1);
            Global.upd1 = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            update.ShowDialog(this);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Update1 update = new Update1(this, 2);
            Global.upd1 = Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value.ToString());
            update.ShowDialog(this);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Update1 update = new Update1(this, 3);
            Global.upd1 = Convert.ToInt32(dataGridView3.CurrentRow.Cells[0].Value.ToString());
            update.ShowDialog(this);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows[i].Selected = false;
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    if (dataGridView1.Rows[i].Cells[j].Value != null)
                        if (dataGridView1.Rows[i].Cells[j].Value.ToString().Contains(textBox1.Text))
                        {
                            dataGridView1.Rows[i].Selected = true;
                            break;
                        }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView2.RowCount; i++)
            {
                dataGridView2.Rows[i].Selected = false;
                for (int j = 0; j < dataGridView2.ColumnCount; j++)
                    if (dataGridView2.Rows[i].Cells[j].Value != null)
                        if (dataGridView2.Rows[i].Cells[j].Value.ToString().Contains(textBox2.Text))
                        {
                            dataGridView2.Rows[i].Selected = true;
                            break;
                        }
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView3.RowCount; i++)
            {
                dataGridView3.Rows[i].Selected = false;
                for (int j = 0; j < dataGridView3.ColumnCount; j++)
                    if (dataGridView3.Rows[i].Cells[j].Value != null)
                        if (dataGridView3.Rows[i].Cells[j].Value.ToString().Contains(textBox3.Text))
                        {
                            dataGridView3.Rows[i].Selected = true;
                            break;
                        }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            conn.Open();
            command = new SqlCommand(
              "DELETE FROM Client WHERE Id=" + int.Parse(dataGridView2.CurrentRow.Cells[0].Value.ToString()), conn);
            command.ExecuteNonQuery();
            string sqlExpression = "SELECT * from Client";
            using (SqlConnection connection = new SqlConnection(connectStr))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                tab1.Clear();
                tab1.Load(command.ExecuteReader());
                dataGridView2.DataSource = tab1.DefaultView;
                connection.Close();
            }
            conn.Close();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            conn.Open();
            command = new SqlCommand(
              "DELETE FROM Tovar WHERE Id=" + int.Parse(dataGridView3.CurrentRow.Cells[0].Value.ToString()), conn);
            command.ExecuteNonQuery();
            string sqlExpression = "SELECT * from Tovar";
            using (SqlConnection connection = new SqlConnection(connectStr))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                tab2.Clear();
                tab2.Load(command.ExecuteReader());
                dataGridView3.DataSource = tab2.DefaultView;
                connection.Close();
            }
            conn.Close();
        }
    }
}
