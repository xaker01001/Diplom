namespace Diplom_Chikushev.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        public int Id { get; set; }

        public int Id_service { get; set; }

        public int id_manager { get; set; }

        public int Id_material { get; set; }

        public int Id_client { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateOfIssue { get; set; }

        public int СirculationTerm { get; set; }

        public float Width { get; set; }

        public float Height { get; set; }

        public int kol { get; set; }

        public virtual Client Client { get; set; }

        public virtual Manager Manager { get; set; }

        public virtual Material Material { get; set; }

        public virtual Services Services { get; set; }
    }
}
