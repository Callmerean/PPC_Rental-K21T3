namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PROPERTY")]
    public partial class PROPERTY
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PROPERTY()
        {
            PROPERTY_FEATURE = new HashSet<PROPERTY_FEATURE>();
        }

        public int ID { get; set; }

        [StringLength(100)]
        public string PropertyName { get; set; }

        [StringLength(200)]
        public string Avatar { get; set; }

        [StringLength(200)]
        public string Images { get; set; }

        public int? PropertyType_ID { get; set; }

        [StringLength(500)]
        public string Content { get; set; }

        public int? Street_ID { get; set; }

        public int? Ward_ID { get; set; }

        public int? District_ID { get; set; }

        public int? Price { get; set; }

        [StringLength(30)]
        public string UnitPrice { get; set; }

        [StringLength(30)]
        public string Area { get; set; }

        public int? BedRoom { get; set; }

        public int? BathRoom { get; set; }

        public int? PackingPlace { get; set; }

        public int? UserID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Created_at { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Create_post { get; set; }

        public int? Status_ID { get; set; }

        [StringLength(100)]
        public string Note { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Updated_at { get; set; }

        public int? Sale_ID { get; set; }

        public virtual DISTRICT DISTRICT { get; set; }

        public virtual PROJECT_STATUS PROJECT_STATUS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PROPERTY_FEATURE> PROPERTY_FEATURE { get; set; }

        public virtual PROPERTY_TYPE PROPERTY_TYPE { get; set; }

        public virtual STREET STREET { get; set; }

        public virtual USER USER { get; set; }

        public virtual USER USER1 { get; set; }

        public virtual WARD WARD { get; set; }
    }
}
