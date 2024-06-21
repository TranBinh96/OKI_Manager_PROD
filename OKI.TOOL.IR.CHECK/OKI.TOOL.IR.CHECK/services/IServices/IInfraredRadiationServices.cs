using OKI.TOOL.IR.CHECK.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKI.TOOL.IR.CHECK.repositories.IRepositories
{
    public interface IInfraredRadiationServices
    {
        List<InfraredRadiation> GetAllInfraredRadiation(string seri_number);
        List<InfraredRadiation> GetInfraredRadiationAll(string seri_number);
        Quantity GetQuantity();
    }
}
