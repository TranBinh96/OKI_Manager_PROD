using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Production.Models
{
    public class DetailTools
    {
        public int Id { get; set; }
        public string LineName { get; set; }
        public string UnitName { get; set; }
        public string Station { get; set; }
        public string HostName { get; set; }
        public string IP { get; set; }
        public string NameTool { get; set; }
        public string HourRun { get; set; }
        public string Note { get; set; }
        public string DateCreate { get; set; }
    }

}
