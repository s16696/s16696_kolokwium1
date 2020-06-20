using Microsoft.AspNetCore.Mvc;
using Projekt_s16696.DTOs;
using Projekt_s16696.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_s16696.Services
{
    public interface ICampaingsDBService
    {
        IActionResult RegisterCampaign(MyDbContext context,
            RegCampaignRequest request);

        IActionResult ListCampaigns(MyDbContext context);


       
    }
}
