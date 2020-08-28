using DIplom_Romensky.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIplom_Romensky.Core
{
   public class ClientModel: IFillable<Client,ClientModel>
    {
        public int Id { get; set; }       
        public string Name { get; set; }     
        public string Surname { get; set; }     
        public string Patronymic { get; set; }     
        public DateTime DateOfBirth { get; set; }
        
        public string Tovar { get; set; }

        public ClientModel Fill(Client data)
        {
            return new ClientModel()
            {
                Id = data.Id,
                Name = data.Name,
                Surname = data.Surname,
                Patronymic = data.Patronymic,
                DateOfBirth = data.DateOfBirth,
                Tovar=data.Tovar.Tovar1,
            };
        }
    }
}
