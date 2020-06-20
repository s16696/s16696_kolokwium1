using Microsoft.AspNetCore.Mvc;
using Projekt_s16696.DTOs;
using Projekt_s16696.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_s16696.Services
{
    public interface IClientsDBService
    {
        IActionResult Register(RegisterRequest register);

        IActionResult Login(LoginRequest login);

        List<Client> AllClients();

        IActionResult RefreshTok(string token);
    }
}
