using Diplom_Chikushev.Core;
using Diplom_Chikushev.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diplom_Chikushev
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private async void button1_Click(object sender, EventArgs e)
        {
               Autoriz();
        }

        private void Autoriz()
        {
            try
            {
                using (var db = new Model1())
                {
                    Manager manager =  db.Manager.FirstOrDefault(IsCurrentUser);
                    if (manager == null)
                        throw new Exception("NYET!!!>_<");
                    ManagerSingleton.Instance(manager);
                    this.Hide();
                    new Information().ShowDialog();
                    this.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool IsCurrentUser(Manager manager)
        {
            return manager.Login.Equals(textBox1.Text) && manager.Password.Equals(textBox2.Text);
        }
    }
}
