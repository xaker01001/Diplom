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
    public class ZakazLogic : IDisposable
    {
        private EnityContext bd;
        public List<ZakazModel> Zakaz   { get; set; }
        public List<Services> Services  { get; set; }
        public List<Material> Materiales { get; set; }
        public ZakazModel SelectedZakaz { get; set; }
        public ZakazLogic()
        {
            bd = new EnityContext();
            Zakaz = new List<ZakazModel>();
            Services = new List<Services>();
            Materiales = new List<Material>();
        }
        public async Task FillServices()
        {
            await bd.Services.LoadAsync();
            foreach (var services in bd.Services.Local)
                Services.Add(services);

        }
        public async Task FillMaterial()
        {
            await bd.Material.LoadAsync();
            foreach (var material in bd.Material.Local)
                Materiales.Add(material);

        }
        public async Task Fill()
        {
            await bd.Order.LoadAsync();
            foreach (var zakaz in bd.Order.Local)
            {
                Zakaz.Add(new ZakazModel().Fill(zakaz));
            }

        }

        public async Task<float> GetPriceOfOrder(string service, string material, Int32 width, Int32 height, Int32 count)
        {
            float materialPrice = (await bd.Material.FirstAsync(mat => mat.Material1.Equals(material))).Price;
            float servicePrice = (await bd.Services.FirstAsync(ser => ser.Service.Equals(service))).Price;
            return ((materialPrice + servicePrice) / (height * width)) * count;
        }

        public void Dispose()
        {
            bd.Dispose();
        }
        public void Add(ZakazModel zakaz)
        {
            using (var context = new EnityContext())
            {
                context.Material.Add(new Material
                {
                    Price = zakaz.Price_material,
                });
                context.SaveChanges();

            }
            using (var context = new EnityContext())
            {
                context.Order.Add(new Order
                {
                    DateOfIssue = zakaz.DateOfIssue,
                    СirculationTerm = zakaz.CirculationTerm,
                    Width = zakaz.Width,
                    Height = zakaz.Height,
                    kol = zakaz.kol,
                    id_manager = zakaz.Id_manager,
                    Id_client = zakaz.Id_client,
                    Id_service = zakaz.Id_service,
                    Id_material = zakaz.Id_material,


                });
                context.SaveChanges();
            }
                
            try
            {
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Ошибка");
            }
        }

        public void Update(ZakazModel model)
        {
            Material material = bd.Material.FirstOrDefault(p=>p.Price.Equals(model.Price_material));
            var orderForUpdate              = bd.Order.FirstOrDefault(order => order.Id.Equals(model.Id));
            orderForUpdate.Id_material      = model.Id_material;
            orderForUpdate.Id_service       = model.Id_service;
            orderForUpdate.DateOfIssue      = model.DateOfIssue;
            orderForUpdate.СirculationTerm  = model.CirculationTerm;
            orderForUpdate.Width            = model.Width;
            orderForUpdate.Height           = model.Height;
            orderForUpdate.kol              = model.kol;
            material.Price                  = model.Price_material;
            bd.SaveChanges();
        }
        public void Delete(ZakazModel model)
        {
            Material material           = bd.Material.FirstOrDefault(c => c.Id.Equals(model.Id_material));
            Services cervices           = bd.Services.FirstOrDefault(c=>c.Id.Equals(model.Id_service));
            Order order                 = bd.Order.FirstOrDefault(c=> c.Id.Equals(model.Id));
            bd.Material.Remove(material);
            bd.Services.Remove(cervices);
            bd.Order.Remove(order);
            bd.SaveChanges();
        }
    }
}
