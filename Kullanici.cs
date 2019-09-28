namespace Myblogg
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Kullanici")]
    public partial class Kullanici
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Kullanici()
        {
            kullanicirol = new HashSet<kullanicirol>();
            Kullanici1 = new HashSet<Kullanici>();
            Kullanici2 = new HashSet<Kullanici>();
        }

        public int id { get; set; }

        [StringLength(100)]
        public string KullaniciAdi { get; set; }

        [StringLength(100)]
        public string Adi { get; set; }

        [StringLength(100)]
        public string Soyadi { get; set; }

        [StringLength(100)]
        public string Parola { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        public DateTime? DogumTarihi { get; set; }

        public DateTime? KayitTarihi { get; set; }

        public int? ResimID { get; set; }

        public bool? Yazar { get; set; }

        public bool? Aktif { get; set; }

        public string Aciklama { get; set; }

        public bool? Onaylandimi { get; set; }

        public virtual Resim Resim { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<kullanicirol> kullanicirol { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Kullanici> Kullanici1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Kullanici> Kullanici2 { get; set; }
    }
}
