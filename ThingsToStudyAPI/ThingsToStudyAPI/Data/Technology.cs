namespace ThingsToStudyAPI.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Technology
    {
        [Key]
        public long TechID { get; set; }

        [StringLength(1000)]
        public string TechName { get; set; }

        [StringLength(1000)]
        public string Category { get; set; }

        [StringLength(8000)]
        public string TechDescription { get; set; }

        [StringLength(2083)]
        public string TechURL { get; set; }
    }
}
