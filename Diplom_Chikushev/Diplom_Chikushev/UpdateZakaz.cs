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
    public partial class UpdateZakaz : Form
    {
        ZakazLogic zakazLogic;
        ZakazModel model;
       
        public UpdateZakaz(ZakazModel zakazModel)
        {
            InitializeComponent();
            zakazLogic = new ZakazLogic();
            model = zakazModel;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var mat = zakazLogic.Materiales.FirstOrDefault(m => m.Material1.Equals(materialComboBox.Text));
            int materi = mat != null ? mat.Id : 1;
            zakazLogic.Update(new ZakazModel
            {
                Id = model.Id,
                Id_service = model.Id_service,
                Id_client = model.Id_client,
                Id_manager = model.Id_manager,
                Id_material = materi,
                Service = serviceComboBox.Text,
                Material = materialComboBox.Text,
                DateOfIssue = date.Value,
                CirculationTerm = int.Parse(SrokTextBox.Text),
                Width = int.Parse(widthTextBox.Text),
                Height = int.Parse(HeightTextBox.Text),
                kol = int.Parse(KolTextBox.Text),
                Price_material = float.Parse(PriceTextBox.Text),
            });

            //  model.Material = materialComboBox.Text;
            //  model.Service = serviceComboBox.Text;
            // zakazLogic.Update(model);
        }

        private void UpdateZakaz_FormClosed(object sender, FormClosedEventArgs e)
        {
            zakazLogic.Dispose();
        }

        private async void UpdateZakaz_Load(object sender, EventArgs e)
        {
            try
            {
                await zakazLogic.FillServices();
                await zakazLogic.FillMaterial();

                serviceComboBox.DataSource = new BindingSource { DataSource = zakazLogic.Services.Select(service => service.Service) };
                materialComboBox.DataSource = new BindingSource { DataSource = zakazLogic.Materiales.Select(material => material.Material1) };

                if (model == null)
                    throw new Exception("model is empty");

                serviceComboBox.Text        = model.Service;
                materialComboBox.Text       = model.Material;
                date.Value                  = model.DateOfIssue;
                SrokTextBox.Text            = model.CirculationTerm.ToString();
                widthTextBox.Text           = model.Width.ToString();
                HeightTextBox.Text          = model.Height.ToString();
                KolTextBox.Text             = model.kol.ToString();
                PriceTextBox.Text           = model.Price_material.ToString();
               // materialComboBox.Text       = model.Material.ToString();
               // serviceComboBox.Text        = model.Service.ToString();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message,"Ошибка-");
            }
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

        private void serviceComboBox_TextChanged(object sender, EventArgs e)
        {
            CalculatePriceOfOrder(materialComboBox.Text);
        }

        private void materialComboBox_TextChanged(object sender, EventArgs e)
        {
            CalculatePriceOfOrder(serviceComboBox.Text);

        }

        private void SrokTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) == true) return; // Если символ цифра, то возвращаемся из метода
            e.Handled = true;
            return;
        }

        private void HeightTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) == true) return; // Если символ цифра, то возвращаемся из метода
            e.Handled = true;
            return;
        }

        private void WidthTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) == true) return; // Если символ цифра, то возвращаемся из метода
            e.Handled = true;
            return;
        }

        private void KolTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) == true) return; // Если символ цифра, то возвращаемся из метода
            e.Handled = true;
            return;
        }
    }
}
