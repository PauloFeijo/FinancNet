﻿using FinancNet.Dtos;
using FinancNet.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinancNet.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUserService serv;

        public LoginController(IUserService serv)
        {
            this.serv = serv;
        }

        [AllowAnonymous]
        [HttpPost]
        public object Post([FromBody] LoginDTO login)
        {
            if (login == null) return BadRequest();

            return serv.FindByLogin(login);
        }
    }
}