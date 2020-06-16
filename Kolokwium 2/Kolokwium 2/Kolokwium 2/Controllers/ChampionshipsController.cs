using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kolokwium_2.DTOs;
using Kolokwium_2.Exceptions;
using Kolokwium_2.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kolokwium_2.Controllers
{
    [Route("api/championships")]
    [ApiController]
    public class ChampionshipsController : ControllerBase
    {
        public readonly IChampionshipDbService _dbService;

        public ChampionshipsController(IChampionshipDbService dbService)
        {
            _dbService = dbService;
        }


        [HttpPost("/{id: int}/players")]
        public IActionResult GetAllTeams(int id)
        {
            try
            {
                var result = _dbService.GetAllTeams(id);
                return Ok(result);
            }
            catch (NotFoundTeamExc exc)
            {
                return NotFound(exc.Message);
            }
        }

    }
}
