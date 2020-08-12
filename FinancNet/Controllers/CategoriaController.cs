﻿using FinancNet.Models;
using FinancNet.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinancNet.Controllers
{
    public class CategoriaController : Controller<Categoria>
    {
        public CategoriaController(IService<Categoria> serv) : base(serv) { }
    }
}