namespace Myblogg
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Resim")]
    public partial class Resim
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Resim()
        {
            Kullanici = new HashSet<Kullanici>();
            Makale = new HashSet<Makale>();
        }

        public int ID { get; set; }

        [StringLength(200)]
        public string ResimAdi { get; set; }

        [StringLength(500)]
        public string KucukResimYol { get; set; }

        [StringLength(500)]
        public string OrtaResimYol { get; set; }

        [StringLength(500)]
        public string BuyukResimYol { get; set; }

        [StringLength(500)]
        public string YazarResimYol { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Kullanici> Kullanici { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Makale> Makale { get; set; }
    }
}
