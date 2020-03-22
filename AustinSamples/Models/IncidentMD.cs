using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AustinSamples.Models
{
    public class IncidentMD
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string Gender { get; set; }
        public bool IsMarried { get; set; }
    }
}