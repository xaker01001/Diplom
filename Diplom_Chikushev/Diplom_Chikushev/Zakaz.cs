using Diplom_Chikushev.Core;
using Diplom_Chikushev.Entity;
using Diplom_Chikushev.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diplom_Chikushev
{
    public partial class Zakaz : Form
    {
        private ZakazLogic zakazLogic;
        BindingList<ZakazModel> bindingList;

        private ClientModel _currentClient;
        public Zakaz(ClientModel clientModel)
        {
            InitializeComponent();
            zakazLogic = new ZakazLogic();
            _currentClient = clientModel;
            FormClosed += Zakaz_FormClosed;
            CreateBindings();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void Zakaz_FormClosed(object sender, FormClosedEventArgs e)
        {
            zakazLogic.Dispose();
        }

        private async void FillDataGrid()
        {
            await zakazLogic.Fill();
            FillBindingList(zakazLogic.Zakaz);
            dataGridView1.DataSource = new BindingSource { DataSource = bindingList.Where(order => order.Id_client.Equals(_currentClient.Id)) };

        }
        private void FillBindingList(IEnumerable<ZakazModel>model)
        {
            foreach (var zakaz1 in model)
            {
                bindingList.Add(zakaz1);
            }
        }
        private void CreateBindings()
        {
            try
            {
                bindingList = new BindingList<ZakazModel>();

                Id.DataPropertyName                 = nameof(ZakazModel.Id);
                Id_service.DataPropertyName         = nameof(ZakazModel.Id_service);
                id_manager.DataPropertyName         = nameof(ZakazModel.Id_manager);
                id_material.DataPropertyName        = nameof(ZakazModel.Id_material);
                id_client.DataPropertyName          = nameof(ZakazModel.Id_client);
                DateOfIssue.DataPropertyName        = nameof(ZakazModel.DateOfIssue);
                CirculationTerm.DataPropertyName    = nameof(ZakazModel.CirculationTerm);
                Width.DataPropertyName              = nameof(ZakazModel.Width);
                Height.DataPropertyName             = nameof(ZakazModel.Height);
                Kol.DataPropertyName                = nameof(ZakazModel.kol);
                Price_material.DataPropertyName     = nameof(ZakazModel.Price_material);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Error");
            }
        }
        private void Zakaz_Load(object sender, EventArgs e)
        {
            FillDataGrid();

        }

        private void Zakaz_FormClosing(object sender, FormClosingEventArgs e)
        {
            zakazLogic.Dispose();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                    ZakazModel zakaz = new ZakazModel()
                    {
                        Id = Int32.Parse(row.Cells["Id"].Value.ToString()),
                        Id_service = Int32.Parse(row.Cells["Id_service"].Value.ToString()),
                        Id_manager = Int32.Parse(row.Cells["Id_manager"].Value.ToString()),
                        Id_material = Int32.Parse(row.Cells["Id_material"].Value.ToString()),
                        Id_client = Int32.Parse(row.Cells["Id_client"].Value.ToString()),
                        DateOfIssue = DateTime.Parse(row.Cells["DateOfIssue"].Value.ToString()),
                        CirculationTerm = Int32.Parse(row.Cells["CirculationTerm"].Value.ToString()),
                        Width = float.Parse(row.Cells["Width"].Value.ToString()),
                        Height = float.Parse(row.Cells["Height"].Value.ToString()),
                        kol = Int32.Parse(row.Cells["kol"].Value.ToString()),
                        Material = row.Cells["Material"].Value.ToString(),
                        Service = row.Cells["Service"].Value.ToString(),
                        Price_material = float.Parse(row.Cells["Price_material"].Value.ToString()),
                    };
                    zakazLogic.SelectedZakaz = zakaz;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Ошибка");
              
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //AddZakaz zakaz = new AddZakaz(_currentClient);
            //try
            //{
            //    if (zakaz.ShowDialog(this).Equals(DialogResult.OK))
            //    {
            //        if (dataGridView1.DataSource != null)
            //        {
            //            UpdateDataSet();
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message + " button1_Click", "Error");

            //}
            new AddZakaz(_currentClient).ShowDialog();
            UpdateDataSet();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if(dataGridView1.CurrentRow != null)
                {
                    DataGridViewRow row = dataGridView1.CurrentRow;
                    using (var context = new Model1())
                    {
                        ZakazModel model = new ZakazModel()
                        {
                            Id = Int32.Parse(row.Cells["Id"].Value.ToString()),
                            Id_client = Int32.Parse(row.Cells["Id_client"].Value.ToString()),
                            Id_manager = Int32.Parse(row.Cells["Id_material"].Value.ToString()),
                            Id_material = Int32.Parse(row.Cells["Id_material"].Value.ToString()),
                            Id_service = Int32.Parse(row.Cells["Id_service"].Value.ToString()),
                            DateOfIssue = DateTime.Parse(row.Cells["DateOfIssue"].Value.ToString()),
                            CirculationTerm = Int32.Parse(row.Cells["CirculationTerm"].Value.ToString()),
                            Width = Int32.Parse(row.Cells["Width"].Value.ToString()),
                            Height = Int32.Parse(row.Cells["Height"].Value.ToString()),
                            kol = Int32.Parse(row.Cells["kol"].Value.ToString()),
                            Material = row.Cells["Material"].Value.ToString(),
                            Service = row.Cells["Service"].Value.ToString(),
                            Price_material = float.Parse(row.Cells["Price_material"].Value.ToString()),

                        };
                        await context.Order.LoadAsync();
                        //model.Id = context.Order.Local.First(c=>c.Id.Equals(Id)).Id;    
                        zakazLogic.SelectedZakaz = model;
                    }

                }
                new UpdateZakaz(zakazLogic.SelectedZakaz).ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



          
            //UpdateDataSet();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            //DataGridViewRow row = dataGridView1.CurrentRow;
            //ZakazModel zakaz = new ZakazModel()
            //{
            //    Id = Int32.Parse(row.Cells["Id"].Value.ToString()),
            //    Id_service = Int32.Parse(row.Cells["Id_service"].Value.ToString()),
            //    Id_manager = Int32.Parse(row.Cells["Id_manager"].Value.ToString()),
            //    Id_material = Int32.Parse(row.Cells["Id_material"].Value.ToString()),
            //    Id_client = Int32.Parse(row.Cells["Id_client"].Value.ToString()),
            //    DateOfIssue = DateTime.Parse(row.Cells["DateOfIssue"].Value.ToString()),
            //    CirculationTerm = Int32.Parse(row.Cells["CirculationTerm"].Value.ToString()),
            //    Width = float.Parse(row.Cells["Width"].Value.ToString()),
            //    Height = float.Parse(row.Cells["Height"].Value.ToString()),
            //    kol = Int32.Parse(row.Cells["kol"].Value.ToString()),


            //};
            //zakazLogic.SelectedZakaz = zakaz;
        }
        public void UpdateDataSet()
        {
            if (dataGridView1.DataSource != null)
            {
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();
                zakazLogic.Zakaz = new List<ZakazModel>();
                bindingList = new BindingList<ZakazModel>();
                FillDataGrid();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                //if (clientLogic.SelectedClient == null)
                //    throw new Exception("NIEY!!!>_< UpdateButton");
                if (dataGridView1.CurrentRow != null)
                {

                    DataGridViewRow row = dataGridView1.CurrentRow;
                   ZakazModel zakaz = new ZakazModel()
                    {
                       Id = Int32.Parse(row.Cells["Id"].Value.ToString()),
                       Id_client = Int32.Parse(row.Cells["Id_client"].Value.ToString()),
                       Id_manager = Int32.Parse(row.Cells["Id_material"].Value.ToString()),
                       Id_material = Int32.Parse(row.Cells["Id_material"].Value.ToString()),
                       Id_service = Int32.Parse(row.Cells["Id_service"].Value.ToString()),
                       DateOfIssue = DateTime.Parse(row.Cells["DateOfIssue"].Value.ToString()),
                       CirculationTerm = Int32.Parse(row.Cells["CirculationTerm"].Value.ToString()),
                       Width = Int32.Parse(row.Cells["Width"].Value.ToString()),
                       Height = Int32.Parse(row.Cells["Height"].Value.ToString()),
                       kol = Int32.Parse(row.Cells["kol"].Value.ToString()),
                       Material = row.Cells["Material"].Value.ToString(),
                       Service = row.Cells["Service"].Value.ToString(),
                       Price_material = float.Parse(row.Cells["Price_material"].Value.ToString()),


                   };
                    zakazLogic.Delete(zakaz);
                    UpdateDataSet();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
