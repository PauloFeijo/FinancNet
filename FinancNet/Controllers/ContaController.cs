using FinancNet.Models;
using FinancNet.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinancNet.Controllers
{
    public class ContaController : Controller<Conta>
    {
        public ContaController(IService<Conta> serv) : base(serv) { }
    }
}