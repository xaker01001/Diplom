using Diplom_Chikushev.Core;
using Diplom_Chikushev.Entity;
using Diplom_Chikushev.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diplom_Chikushev
{
    public partial class Information : Form
    {
        private ClientLogic clientLogic;
        BindingList<ClientModel> bindingList;
        
        public Information()
        {
            InitializeComponent();
            clientLogic = new ClientLogic();
            FormClosed += Information_FormClosed;
            dataGridView1.CellClick += DataGridView1_CellClick;
            CreateBinding();

        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void Information_FormClosed(object sender, FormClosedEventArgs e)
        {
            clientLogic.Dispose();
        }

        private void Information_Load(object sender, EventArgs e)
        {
            FillDataGrid();
        }

        private async void FillDataGrid()
        {
            await clientLogic.Fill();
            FillBindingList(clientLogic.Clients);
            dataGridView1.DataSource = new BindingSource { DataSource = bindingList };
        }

        private void FillBindingList(IEnumerable<ClientModel> clients)
        {
            foreach (var client in clients)
            {
                bindingList.Add(client);
            }
        }

        private void CreateBinding()
        {
            try
            {
                bindingList = new BindingList<ClientModel>();

                ClientName.DataPropertyName = nameof(ClientModel.Name);
                Surname.DataPropertyName = nameof(ClientModel.SurName);
                Patronymic.DataPropertyName = nameof(ClientModel.Patronymic);
                Email.DataPropertyName = nameof(ClientModel.Email);
                CompanyName.DataPropertyName = nameof(ClientModel.CompanyName);
                PhoneColumn.DataPropertyName = nameof(ClientModel.Phone);
                CompanyAdress.DataPropertyName = nameof(ClientModel.CompanyAdress);

                CompanyId.DataPropertyName = nameof(ClientModel.CompanyId);
                ClientId.DataPropertyName = nameof(ClientModel.Id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                    ClientModel client = new ClientModel()
                    {
                        Patronymic = row.Cells["Patronymic"].Value.ToString(),
                        CompanyAdress = row.Cells["CompanyAdress"].Value.ToString(),
                        Phone = row.Cells["PhoneColumn"].Value.ToString(),
                        Email = row.Cells["Email"].Value.ToString(),
                        CompanyName = row.Cells["CompanyName"].Value.ToString(),
                        CompanyId = Int32.Parse(row.Cells["CompanyId"].Value.ToString()),
                        Id = Int32.Parse(row.Cells["ClientId"].Value.ToString())
                    };
                    clientLogic.SelectedClient = client;
                    new Zakaz(clientLogic.SelectedClient).ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " CellContentClick", "Error");
            }
        }
        
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddClient client = new AddClient();
            try
            {
                if (client.ShowDialog(this).Equals(DialogResult.OK))
                {
                    if (dataGridView1.DataSource != null)
                    {
                        UpdateDAtaSet();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " button1_Click", "Error");

            }
           
        }

        private async void UpdateButton_Click(object sender, EventArgs e)
        {
            
            try
            {
                // if (clientLogic.SelectedClient == null)
                //     throw new Exception("NIEY!!!>_< UpdateButton");
               
                if (dataGridView1.CurrentRow != null)
                {
                    DataGridViewRow row = dataGridView1.CurrentRow;
                    using (var context = new Model1())
                    {
                        ClientModel client = new ClientModel()
                        {
                            Name = row.Cells["ClientName"].Value.ToString(),
                            SurName = row.Cells["Surname"].Value.ToString(),
                            Patronymic = row.Cells["Patronymic"].Value.ToString(),
                            CompanyAdress = row.Cells["CompanyAdress"].Value.ToString(),
                            Phone = row.Cells["PhoneColumn"].Value.ToString(),
                            Email = row.Cells["Email"].Value.ToString(),
                            CompanyName = row.Cells["CompanyName"].Value.ToString(),
                            CompanyId = Int32.Parse(row.Cells["CompanyId"].Value.ToString()),
                            Id = Int32.Parse(row.Cells["ClientId"].Value.ToString()),
                          
                        };
                      await context.Client.LoadAsync();
                      client.PersonId = context.Client.Local.First(c => c.Id.Equals(client.Id)).Person_id;
                      clientLogic.SelectedClient = client;
                    }

                }
                new Updateinf(clientLogic.SelectedClient).ShowDialog();             
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
          
        }

        private void delete_Click(object sender, EventArgs e)
        {
            try
            {
                //if (clientLogic.SelectedClient == null)
                //    throw new Exception("NIEY!!!>_< UpdateButton");
                if (dataGridView1.CurrentRow != null)
                {
                   
                    DataGridViewRow row = dataGridView1.CurrentRow;
                    ClientModel client = new ClientModel()
                    {
                        CompanyId = Int32.Parse(row.Cells["CompanyId"].Value.ToString()),
                        Id = Int32.Parse(row.Cells["ClientId"].Value.ToString()),
                      //  PersonId = Int32.Parse(row.Cells["PersonId"].Value.ToString()),
                        Name                = row.Cells["ClientName"].Value.ToString(),
                        SurName             = row.Cells["Surname"].Value.ToString(),
                        Patronymic          = row.Cells["Patronymic"].Value.ToString(),
                        CompanyAdress       = row.Cells["CompanyAdress"].Value.ToString(),
                        Phone               = row.Cells["PhoneColumn"].Value.ToString(),
                        Email               = row.Cells["Email"].Value.ToString(),
                        CompanyName         = row.Cells["CompanyName"].Value.ToString(),
                        
                       
                    };
                    clientLogic.Delete(client);
                    UpdateDAtaSet();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Zakaz zakaz = new Zakaz(clientLogic.SelectedClient);
            zakaz.ShowDialog(this);
        }

      
        private void button3_Click(object sender, EventArgs e)
        {
            var col = clientLogic.Clients.Where(client => client.Name.Equals(textBox1.Text) || client.SurName.Equals(textBox1.Text) || client.Patronymic.Equals(textBox1.Text));
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            //UpdateDAtaSet();

            FillBindingList(col);
            dataGridView1.DataSource = new BindingSource { DataSource = bindingList };
        }
        public void UpdateDAtaSet()
        {

            if (dataGridView1.DataSource != null)
            {
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();
                clientLogic.Clients = new List<ClientModel>();
                bindingList = new BindingList<ClientModel>();
                FillDataGrid();
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            UpdateDAtaSet();
        }

        private void Prosmotr_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            UpdateDAtaSet();
        }

        private void ВыходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ОПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Oprogramme oprogramme = new Oprogramme();
            oprogramme.ShowDialog(this);
        }

        private void СправкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("Spravka.chm");
        }
    }
}

