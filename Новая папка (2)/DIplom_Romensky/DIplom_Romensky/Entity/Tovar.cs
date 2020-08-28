namespace DIplom_Romensky.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tovar")]
    public partial class Tovar
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tovar()
        {
            Client = new HashSet<Client>();
        }

        public int Id { get; set; }

        [Column("Tovar")]
        [Required]
        [StringLength(50)]
        public string Tovar1 { get; set; }

        [Required]
        [StringLength(50)]
        public string Saleepeople { get; set; }

        public double Price { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Client> Client { get; set; }
    }
}
