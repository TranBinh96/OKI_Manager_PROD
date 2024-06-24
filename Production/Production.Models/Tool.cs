using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Production.Models
{
    public class Tool
    {
        public int Id { get; set; }
        public string NameTool { get; set; }
        public string HourRun { get; set; }
        public string DateCreate { get; set; }
        public string Note { get; set; }
        public int ComputerId { get; set; }
    }

}