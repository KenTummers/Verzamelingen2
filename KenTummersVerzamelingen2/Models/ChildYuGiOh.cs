namespace KenTummersVerzamelingen2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ChildYuGiOh
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public int ParentID { get; set; }

        [StringLength(50)]
        public string Categorie { get; set; }

        public double Waarde { get; set; }

        public double Prijs { get; set; }

        [StringLength(50)]
        public string Type { get; set; }

        [StringLength(30)]
        public string Status { get; set; }

        public virtual ParentYuGiOh ParentYuGiOh { get; set; }
    }
}
