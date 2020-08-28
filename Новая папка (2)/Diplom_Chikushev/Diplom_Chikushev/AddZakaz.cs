using Diplom_Chikushev.Core;
using Diplom_Chikushev.Models;
using System;
using System.Collections;
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
    public partial class AddZakaz : Form
    {
        ZakazModel model;
        ZakazLogic zakazLogic;
        ClientModel clientModel;
        public AddZakaz(ClientModel clientModel)
        {
            InitializeComponent();
            zakazLogic = new ZakazLogic();
            this.clientModel = clientModel;
            
        }

        private async void AddZakaz_Load(object sender, EventArgs e)
        {
            await zakazLogic.FillMaterial();
            await zakazLogic.FillServices();
            serviceComboBox.DataSource = new BindingSource { DataSource = zakazLogic.Services.Select(service => service.Service) };
            materialComboBox.DataSource = new BindingSource { DataSource = zakazLogic.Materiales.Select(material => material.Material1) };
           
        }

        private void AddZakaz_FormClosed(object sender, FormClosedEventArgs e)
        {
            zakazLogic.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            model = new ZakazModel()
            {
                Service         = serviceComboBox.Text,
                Material        = materialComboBox.Text,
                DateOfIssue     = date.Value,
                CirculationTerm = Int32.Parse( SrokTextBox.Text),
                Width           =  Int32.Parse(widthTextBox.Text),
                Height          = Int32.Parse(HeightTextBox.Text),
                kol             = Int32.Parse(KolTextBox.Text),
                Id_manager      = ManagerSingleton.Instance().Id,
                Id_client       = clientModel.Id,
                Id_material     = zakazLogic.Materiales.FirstOrDefault(m => m.Material1.Equals(materialComboBox.Text)).Id,
                Id_service      = zakazLogic.Services.FirstOrDefault(s => s.Service.Equals(serviceComboBox.Text)).Id,
            };
            zakazLogic.Add(model);
        }

        private void serviceComboBox_TabStopChanged(object sender, EventArgs e)
        {

        }

        private void serviceComboBox_TextChanged(object sender, EventArgs e)
        {
            CalculatePriceOfOrder(materialComboBox.Text);
        }

        private void materialComboBox_TextChanged(object sender, EventArgs e)
        {
            CalculatePriceOfOrder(serviceComboBox.Text);
        }

        private async void CalculatePriceOfOrder(string comboBoxText)
        {
            if (!(string.IsNullOrWhiteSpace(comboBoxText)
               || string.IsNullOrEmpty(comboBoxText)))
            {
                if (!(string.IsNullOrEmpty(HeightTextBox.Text)
                    || string.IsNullOrEmpty(widthTextBox.Text)
                    || string.IsNullOrEmpty(KolTextBox.Text)))
                {
                    PriceTextBox.Text = (await zakazLogic.GetPriceOfOrder(
                        service: serviceComboBox.Text,
                        material: materialComboBox.Text,
                        height: Convert.ToInt32(HeightTextBox.Text),
                        width: Convert.ToInt32(widthTextBox.Text),
                        count: Convert.ToInt32(KolTextBox.Text)
                    )).ToString();
                }
            }
        }
    }
}
