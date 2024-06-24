using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Production.Models
{
    public class MachineDelivery
    {
        public int Id { get; set; }
        public int IdComputer { get; set; }
        public int IdPersonnel { get; set; }
        public string Note { get; set; }
        public DateTime DateCreate { get; set; }
    }
}
