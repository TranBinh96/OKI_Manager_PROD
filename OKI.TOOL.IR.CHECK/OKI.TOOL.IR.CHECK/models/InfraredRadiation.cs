using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKI.TOOL.IR.CHECK.models
{
    public class InfraredRadiation
    {
        public int no { get; set; }
        public int job_no { get; set; }
        public string kotei_filename { get; set; }
        public string unit_no { get; set; }
        public string st_no { get; set; }
        public string start_time { get; set; }
        public string finish_time { get; set; }
        public string remarks { get; set; }
        public string time_access { get; set; }
    }
}
