using Moq;
using NUnit.Framework;
using Projekt_s16696.Controllers;
using Projekt_s16696.DTOs;
using Projekt_s16696.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NUnitTestProject1
{
    [TestFixture]
    class CampaingTest
    {

    [Test]
    public void getCampaingsResponse_test()
        {
            var db = new Mock<ICampaingsDBService>();
            db.Setup(
                p => p.ListCampaigns());

            var controller = new CampaignController(db);
            var result = controller.ListAllCampaigns();

            Assert.IsNotNull(result);
        }

        [Test]
        public void NewCampaign_Correct()
        {
            RegCampaignRequest request = new RegCampaignRequest
            {
                IdClient = 1,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(20),
                PricePerSquareMeter = 3,
                FromIdBuilding = 1,
                ToIdBuilding = 2,
            };

            var con = new ValidationContext(request, null, null);
            var res = new List<ValidationResult>();

            Assert.IsTrue(Validator.TryValidateObject(request, con, res, true));
        }
    }
}
