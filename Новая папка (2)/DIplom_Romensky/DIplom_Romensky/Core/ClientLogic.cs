using DIplom_Romensky.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DIplom_Romensky.Core
{
    public class ClientLogic : IDisposable
    {
       private EntityContext context;
       public List<Tovar> Tovar { get; set; }

        public void Dispose()
        {
            context.Dispose();
        }

        public async Task FillTovar()
        {
            await context.Tovar.LoadAsync();
            foreach (var coeff in context.Tovar.Local)
            {
                Tovar.Add(coeff);
            }
        }
       /* public async void Add(ClientModel client)
        {
            try
            {
                context.Client.Add(new Client
                {
                    Name = client.Name,
                    Surname = client.Surname,
                    Patronymic = client.Patronymic,
                    DateOfBirth = client.DateOfBirth,
                 //   Tovar = client.Tovar,
                    
                });
                await context.SaveChangesAsync();
                    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Ошибка!!!",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }*/
    }
}
