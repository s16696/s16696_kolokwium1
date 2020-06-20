using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projekt_s16696.DTOs;
using Projekt_s16696.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_s16696.Services
{
    public class CampaingDBService : ControllerBase, ICampaingsDBService
    {
        public IActionResult ListCampaigns(MyDbContext context)
        {
            var ret = context.Campaigns.Include(p => p.Client).Include(p => p.Banners).ToList()
                .OrderByDescending(p => p.StartDate);
            return Ok(ret);
        }

        public IActionResult RegisterCampaign(MyDbContext _context, RegCampaignRequest request)
        {
            try
            {
                Building buildingF = _context.Buildings.Where(p => p.IdBuilding == request.FromIdBuilding).ToList().First();
                Building buildingT = _context.Buildings.Where(p => p.IdBuilding == request.ToIdBuilding).ToList().First();


                List<Building> allCampaignBuildings = _context.Buildings
                    .Where(p => p.StreetNumber >= buildingF.StreetNumber && 
                    p.StreetNumber <= buildingT.StreetNumber)
                    .OrderByDescending(p => p.StreetNumber).ToList();

                decimal high1 = 0;
                decimal high2 = 0;

                var sortByHigh = allCampaignBuildings.OrderByDescending(p => p.Height).ToList();
               
                Building highestBuilding = sortByHigh[0];
                Building hightestBuilding2 = sortByHigh[1];

                if ((highestBuilding.IdBuilding == buildingF.IdBuilding) 
                    || highestBuilding.IdBuilding == buildingT.IdBuilding) 
                {
                    high1 = highestBuilding.Height * 1;
                    high2 = hightestBuilding2.Height*(sortByHigh.Count-1);
                }
                else
                {
                    if (highestBuilding.StreetNumber<hightestBuilding2.StreetNumber)
                    {
                        high1 = (highestBuilding.StreetNumber - buildingF.StreetNumber)*highestBuilding.Height;
                        high2 = (highestBuilding.StreetNumber - buildingT.StreetNumber)*hightestBuilding2.Height;
                    }
                    else
                    {
                        high1 = (highestBuilding.StreetNumber - buildingT.StreetNumber)*highestBuilding.Height;
                        high2 = (highestBuilding.StreetNumber - buildingF.StreetNumber)*hightestBuilding2.Height;
                    }
                }

                decimal priceForBanner1 = high1*request.PricePerSquareMeter;
                decimal priceForBanner2 = high2*request.PricePerSquareMeter;


                Campaign camp = new Campaign
                {
                    IdClient = request.IdClient,
                    StartDate = request.StartDate,
                    EndDate = request.EndDate,
                    PricePerSquareMeter = request.PricePerSquareMeter,
                    FromIdBuilding = request.FromIdBuilding,
                    ToIdBuilding = request.ToIdBuilding

                };

                _context.Campaigns.Add(camp);
                _context.SaveChanges();


                Banner b1 = new Banner
                {
                    Name = 1,
                    Price = priceForBanner1,
                    IdCampaign = camp.IdCampaign,
                    Area = high1
                };

                Banner b2 = new Banner
                {
                    Name = 2,
                    Price = priceForBanner2,
                    IdCampaign = camp.IdCampaign,
                    Area = high2
                };

                _context.Banners.Add(b1);
                _context.Banners.Add(b2);
                _context.SaveChanges();
                _context.Campaigns.ToList();


                return StatusCode(201, new CampaignResponse
                {
                    IdCampaign = camp.IdCampaign,
                    IdClient = camp.IdClient,
                    EndDate = camp.EndDate,
                    StartDate = camp.StartDate,
                    FromIdBuilding = camp.FromIdBuilding,
                    PricePerSquareMeter = camp.PricePerSquareMeter,
                    ToIdBuilding = camp.ToIdBuilding,
                    Banners = camp.Banners
                });
            }
            catch(Exception e)
            {
                return BadRequest();
            }
        }
    }
}
