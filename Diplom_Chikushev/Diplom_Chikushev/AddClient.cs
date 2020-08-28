using Diplom_Chikushev.Core;
using Diplom_Chikushev.Models;
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
    public partial class AddClient : Form
    {
        private ClientLogic clientLogic;
        public AddClient()
        {
            InitializeComponent();
            clientLogic = new ClientLogic();

            this.FormClosed += AddClient_FormClosed;
        }

        private void AddClient_FormClosed(object sender, FormClosedEventArgs e)
        {
            //this.DialogResult = DialogResult.Cancel;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClientModel client = new ClientModel()
            {
                Name = textBox1.Text,
                SurName = textBox2.Text,
                Patronymic = textBox3.Text,
                Email = textBox6.Text,
                Phone = maskedTextBox4.Text,
                CompanyAdress = textBox5.Text,                           
                CompanyName = textBox4.Text,
                
               /* CompanyId = Int32.Parse(row.Cells["CompanyId"].Value.ToString()),
                Id = Int32.Parse(row.Cells["ClientId"].Value.ToString())*/
            };
            clientLogic.Add1(client);
            this.DialogResult = DialogResult.OK;
        }

        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) == false) return; // Если символ цифра, то возвращаемся из метода
            e.Handled = true;
            return;
        }

        private void TextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) == false) return; // Если символ цифра, то возвращаемся из метода
            e.Handled = true;
            return;
        }

        private void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) == false) return; // Если символ цифра, то возвращаемся из метода
            e.Handled = true;
            return;
        }

        private void TextBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) == false) return; // Если символ цифра, то возвращаемся из метода
            e.Handled = true;
            return;
        }
    }
}
