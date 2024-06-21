using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Production.Models { 
    public class DetailComputer
    {
        public int Id { get; set; }
        public string? LineName { get; set; }
        public string? UnitName { get; set; }
        public string? Station { get; set; }
        public string? HostName { get; set; }
        public string? AddressIP { get; set; }
        public string? TypePC { get; set; }
        public int? Rage { get; set; }
        public int? Running { get; set; }
        public string? PersonCharge { get; set; }
        public string? Note { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }

}
