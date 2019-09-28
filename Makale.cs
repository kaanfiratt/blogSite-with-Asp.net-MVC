namespace Myblogg
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Makale")]
    public partial class Makale
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Makale()
        {
            Etiket = new HashSet<Etiket>();
        }

        public int id { get; set; }

        [StringLength(200)]
        public string Baslik { get; set; }

        public string Icerik { get; set; }

        public int? KategoriID { get; set; }

        public int ResimID { get; set; }

        public int? YazarID { get; set; }

        public DateTime? YayimTarihi { get; set; }

        public virtual Kategori Kategori { get; set; }

        public virtual Resim Resim { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Etiket> Etiket { get; set; }
    }
}
