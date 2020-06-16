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

    [Route("api/teams")]
    [ApiController]
    public class AddPlayerController : ControllerBase
    {
        private readonly IChampionshipDbService _service;

        public AddPlayerController(IChampionshipDbService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult AddPlayer(PlayerDtos request)
        {
            try
            {
                _service.AddPlayer(request);
                return NoContent();
            }
            catch (PlayerExistExc exc)
            {
                return BadRequest(exc.Message);
            }
            catch (TooOldExc exc)
            {
                return BadRequest(exc.Message);
            }
        }
    }
}
