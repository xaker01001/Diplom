using Diplom_Chikushev.Entity;
using Diplom_Chikushev.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diplom_Chikushev.Core
{
    /// <summary>
    /// Класс реализующий логику работы клиента
    /// </summary>
    public class ClientLogic : IDisposable
    {
        #region Private Members
        private Model1 db;
        #endregion
        #region Public Properties
        /// <summary>
        /// Все клиенты
        /// </summary>
        public List<ClientModel> Clients { get; set; }

        /// <summary>
        /// Выбраный клиент
        /// </summary>
        public ClientModel SelectedClient { get; set; }
        #endregion

        #region Constructors
        public ClientLogic()
        {
            db = new Model1();
            Clients = new List<ClientModel>();
        }
        #endregion
        #region Public Methods
        /// <summary>
        /// Метод заполняет коллекцию клиент
        /// </summary>
        public async Task Fill()
        {
            await db.Client.LoadAsync();
            foreach (var client in db.Client.Local)
                Clients.Add(new ClientModel().Fill(client));
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public void Add1(ClientModel client)
        {
            try
            {
                db.Person.Add(new Person
                {
                    Surname = client.SurName,
                    Name = client.Name,
                    Patronymic = client.Patronymic,
                });
                db.Company.Add(new Company
                {
                    Name = client.CompanyName,
                    Adress = client.CompanyAdress
                });
                db.SaveChanges();

                db.Client.Add(new Client
                {
                    Email = client.Email,
                    Person_id = db.Person.Local.Last().Id,
                    Company_id = db.Company.Local.Last().Id,
                    Phone = client.Phone
                });
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка", ex.Message);
            }
          
        }
        public void Update1(ClientModel clientModel)
        {
            //  db.Person = db.Person.Where(c => c.Id == 1).FirstOrDefault();
            Person person       = db.Client.FirstOrDefault(p => p.Id.Equals(clientModel.Id)).Person;
            Company company     = db.Company.FirstOrDefault(p => p.Id.Equals(clientModel.CompanyId));
            Client client       = db.Client.FirstOrDefault(p => p.Id.Equals(clientModel.Id));
            person.Name         = clientModel.Name;
            person.Surname      = clientModel.SurName;
            person.Patronymic   = clientModel.Patronymic;
            client.Email        = clientModel.Email;
            client.Phone        = clientModel.Phone;
            company.Name        = clientModel.CompanyName;
            company.Adress      = clientModel.CompanyAdress;
            db.SaveChanges();           
        }
        public void Delete(ClientModel clientModel)
        {
            Person  person  = db.Client.FirstOrDefault(p => p.Id.Equals(clientModel.Id)).Person;
            Company company = db.Company.FirstOrDefault(p => p.Id.Equals(clientModel.CompanyId));
            Client  client  = db.Client.FirstOrDefault(p => p.Id.Equals(clientModel.Id));
            db.Person.Remove(person);
            db.Company.Remove(company);
            db.Client.Remove(client);
            db.SaveChanges();
        }
        #endregion
        #region Private Methods

        #endregion
    }
}
