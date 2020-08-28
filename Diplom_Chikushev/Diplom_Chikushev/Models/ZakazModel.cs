using Diplom_Chikushev.Core;
using Diplom_Chikushev.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom_Chikushev.Models
{
    public class ZakazModel : IFillable1<Order, ZakazModel>
    {
        public Int32 Id                 { get; set; }
        public Int32 Id_service         { get; set; }
        public Int32 Id_manager         { get; set; }
        public Int32 Id_material        { get; set; }
        public Int32 Id_client          { get; set; }
        public DateTime DateOfIssue     { get; set; }
        public Int32 CirculationTerm    { get; set; }
        public String Material          { get; set; }
        public String Service           { get; set; }
        public float Width              { get; set; }
        public float Height             { get; set; }
        public Int32 kol                { get; set; }
        public float Price_material    { get; set; }
       

        public ZakazModel Fill(Order data)
       {
            return new ZakazModel
            {
                Id              = data.Id,
                Id_service      = data.Id_service,
                Id_manager      = data.id_manager,
                Id_material     = data.Id_material,
                Id_client       = data.Id_client,
                Material        = data.Material.Material1,
                Service         = data.Services.Service,
                DateOfIssue     = data.DateOfIssue,
                CirculationTerm = data.СirculationTerm,              
                Width           = data.Width,
                Height          = data.Height,
                kol             = data.kol,
                Price_material  =data.Material.Price,
           
            };
        }
    }
}
