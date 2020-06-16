using Kolokwium_2.DTOs;
using Kolokwium_2.Exceptions;
using Kolokwium_2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium_2.Services
{
    public class SqlServerMusicDbService : IChampionshipDbService
    {
        private readonly MyDbContext _context;

        public SqlServerMusicDbService(MyDbContext context)
        {
            _context = context;
        }

        public  List<TeamDto> GetAllTeams(int id)
        {
            var teams =  _context.Teams.Include(e => e.IdTeam).Where(e => e.IdTeam == id).ToList();

            if (teams == null)
            {
                throw new NotFoundTeamExc($"NOT FOUND TEAM ID: {id}");
            }

            var championshipTeam =  _context.Championship_Teams.Include(e => e.IdTeam).Where(e => e.IdTeam == id).ToList();

            List<TeamDto> lista= new List<TeamDto>();

            int test = 0;
            foreach(Team nazwa in teams)
            {
                foreach(Championship_Team t in championshipTeam)
                {
                    if (test == 0)
                    {
                      
                        TeamDto teamDto = new TeamDto
                        {
                            IdTeam = nazwa.IdTeam,
                            TeamName = nazwa.TeamName,
                            Score = t.Score
                        };
                        lista.Add(teamDto);
                        test++;
                    }
                    
                }
                test = 0;

            }


           

            return lista;

        }

        public async Task AddPlayer(PlayerDtos player)
        {
            throw new NotImplementedException();
        }


    }
}
