using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancNet.Services
{
    public interface ISaldoService
    {
        void ProcessarSaldoConta(long contaId);
    }
}
