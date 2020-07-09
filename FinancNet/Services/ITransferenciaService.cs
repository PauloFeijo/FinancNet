using FinancNet.Models;
using System.Collections.Generic;

namespace FinancNet.Services
{
    public interface ITransferenciaService : IService<Transferencia>
    {
        List<Transferencia> FindByPeriodo(string dini, string dfin);
    }
}
