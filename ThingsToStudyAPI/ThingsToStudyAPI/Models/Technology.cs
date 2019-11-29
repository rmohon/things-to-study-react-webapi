using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ThingsToStudyAPI.Models
{
    public class Technology
    {
        public long TechID { get; set; }
        public string TechName { get; set; }
        public string CatName { get; set; }
        public string TechDes { get; set; }
        public Uri TechURL { get; set; }
    }
}