namespace KenTummersVerzamelingen2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ChildFish
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public int ParentID { get; set; }

        [StringLength(50)]
        public string Categorie { get; set; }

        [StringLength(500)]
        public string Beschrijving { get; set; }

        [StringLength(50)]
        public string Waarde { get; set; }

        public double Prijs { get; set; }

        public double Gewicht { get; set; }

        [StringLength(50)]
        public string Kleur { get; set; }

        [StringLength(50)]
        public string Lengte { get; set; }

        [StringLength(30)]
        public string Status { get; set; }

        public virtual ParentFish ParentFish { get; set; }
    }
}
