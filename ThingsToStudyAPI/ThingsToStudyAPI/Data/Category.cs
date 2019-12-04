namespace ThingsToStudyAPI.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Category")]
    public partial class Category
    {
        public long CategoryID { get; set; }

        [StringLength(1000)]
        public string CategoryName { get; set; }
    }
}
