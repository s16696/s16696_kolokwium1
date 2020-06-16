using Kolokwium_2.DTOs;
using Kolokwium_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium_2.Services
{
    public interface IChampionshipDbService
    {
        List<TeamDto> GetAllTeams(int id);
        Task AddPlayer(PlayerDtos player);

    }
}
