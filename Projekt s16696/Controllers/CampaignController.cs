using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Projekt_s16696.DTOs;
using Projekt_s16696.Models;
using Projekt_s16696.Services;

namespace Projekt_s16696.Controllers
{
    [ApiController]
    [Route("api/campaigns")]
    public class CampaignController : ControllerBase
    {
        private ICampaingsDBService _service;
        private MyDbContext _context;

        public CampaignController(ICampaingsDBService service, MyDbContext context)
        {
            _service = service;
            _context = context;
        }



        [HttpPost("registerCampaign")]
        [Authorize(Roles = "registered")]
        public IActionResult RegisterCampaign([FromBody] RegCampaignRequest req)
        {
            var exists = _context.Clients.Where(c => c.IdClient == req.IdClient).ToList();
            if (exists.Count == 0)
            {
                return StatusCode(401);
            }

            var street1 = _context.Buildings.Where(p => p.IdBuilding == req.FromIdBuilding)
                .Select(p => p.Street);
            var street2 = _context.Buildings.Where(p => p.IdBuilding == req.ToIdBuilding)
                .Select(p => p.Street);

            if (!street1.Equals(street1))
            {
                return StatusCode(400);
            }

            return _service.RegisterCampaign(_context, req);
        }


        [HttpGet]
        [Authorize(Roles = "loggedUser")]
        public IActionResult ListAllCampaigns()
        {
            return Ok(_service.ListCampaigns(_context));
        }
    }
}
