using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Projekt_s16696.DTOs;
using Projekt_s16696.Services;

namespace Projekt_s16696.Controllers
{

    [ApiController]
    [Route("api/clients")]
    public class ClientsController : Controller
    {
        IClientsDBService _service;

        public ClientsController(IClientsDBService service)
        {
            _service = service;
        }
       

        [HttpPost]
        public IActionResult Register(RegisterRequest register)
        {
            return _service.Register(register);

        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest login) 
        {
            return _service.Login(login);
        }


        [HttpPost("refreshToken/{tokenRequest}")]
        public IActionResult RefreshTok(string token)
            {

            return _service.RefreshTok(token);
        }

        [HttpGet]
        public IActionResult getAll()
        {
            return Ok(_service.AllClients());

        }
    }
}
