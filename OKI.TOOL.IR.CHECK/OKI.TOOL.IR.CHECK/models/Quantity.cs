using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKI.TOOL.IR.CHECK.models       
{
    public class Quantity
    {
        public int no { get; set; }
        public int ok { get; set; }
        public int ng { get; set; }
        public int day { get; set; }
        public int month { get; set; }
        public string time_update { get; set; }
    }
}
