namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FEATURE")]
    public partial class FEATURE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FEATURE()
        {
            PROPERTY_FEATURE = new HashSet<PROPERTY_FEATURE>();
        }

        public int ID { get; set; }

        [StringLength(50)]
        public string FeatureName { get; set; }

        public bool? Status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PROPERTY_FEATURE> PROPERTY_FEATURE { get; set; }
    }
}
