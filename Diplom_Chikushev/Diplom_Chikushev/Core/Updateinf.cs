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

namespace Diplom_Chikushev.Core
{
    public partial class Updateinf : Form
    {
        private ClientLogic clientLogic;
        private ClientModel _clientModel;
        public Updateinf(ClientModel clientModel)
        {
            InitializeComponent();
            Load += Updateinf_Load;
            _clientModel = clientModel;
            clientLogic = new ClientLogic();
            FormClosed += Updateinf_FormClosed;
        }

        private void Updateinf_FormClosed(object sender, FormClosedEventArgs e)
        {
            clientLogic.Dispose();
        }

        private void Updateinf_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
                clientLogic.Update1(new ClientModel
            {
                Id = _clientModel.Id,
                PersonId = _clientModel.PersonId,
                CompanyId = _clientModel.CompanyId,
                Name = NameTextBox.Text,
                SurName = SureNameTextBox.Text,
                Patronymic = PatronymicTextBox.Text,
                Email = EmailBox.Text,
                Phone = PhoneTextBox.Text,
                CompanyName = CompanyNameTextBox.Text,
                CompanyAdress = AdressTextBox.Text,
            });
        }

        private void Updateinf_Load_1(object sender, EventArgs e)
        {
            try
            {
                if (_clientModel == null)
                    throw new Exception("NIET>_<!!!!");

                NameTextBox.Text = _clientModel.Name;
                SureNameTextBox.Text = _clientModel.SurName;
                PatronymicTextBox.Text = _clientModel.Patronymic;
                EmailBox.Text = _clientModel.Email;
                PhoneTextBox.Text = _clientModel.Phone;
                CompanyNameTextBox.Text = _clientModel.CompanyName;
                AdressTextBox.Text = _clientModel.CompanyAdress;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void NameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) == false) return; // Если символ цифра, то возвращаемся из метода
            e.Handled = true;
            return;
        }

        private void SureNameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) == false) return; // Если символ цифра, то возвращаемся из метода
            e.Handled = true;
            return;
        }

        private void PatronymicTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) == false) return; // Если символ цифра, то возвращаемся из метода
            e.Handled = true;
            return;
        }

        private void CompanyNameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) == false) return; // Если символ цифра, то возвращаемся из метода
            e.Handled = true;
            return;
        }

        private void AdressTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }
    }
}
