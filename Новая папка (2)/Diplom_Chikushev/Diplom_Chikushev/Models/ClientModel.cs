using Diplom_Chikushev.Core;
using Diplom_Chikushev.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom_Chikushev.Models
{
    public class ClientModel : IFillable<Client, ClientModel>
    {
        public Int32 Id             { get; set; }
        public Int32 CompanyId      { get; set; }
        public string Phone         { get; set; }
        public string Name          { get; set; }
        public string SurName       { get; set; }
        public string Email         { get; set; }
        public string Patronymic    { get; set; }
        public string CompanyName   { get; set; }
        public string CompanyAdress { get; set; }
        public object PersonId { get; internal set; }

        public ClientModel Fill(Client data)
        {
            return new ClientModel
            {
                Id              = data.Id,
                PersonId        = data.Person_id,
                Phone           = data.Phone,
                CompanyId       = data.Company_id,
                Name            = data.Person.Name,
                SurName         = data.Person.Surname,
                Patronymic      = data.Person.Patronymic,
                Email           = data.Email,
                CompanyName     = data.Company.Name,
                CompanyAdress   = data.Company.Adress
            };
        }
    }
}
