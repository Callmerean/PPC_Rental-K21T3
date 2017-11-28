namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PROPERTY_FEATURE
    {
        public int ID { get; set; }

        public int? Property_ID { get; set; }

        public int? Feature_ID { get; set; }

        public virtual FEATURE FEATURE { get; set; }

        public virtual PROPERTY PROPERTY { get; set; }
    }
}
