using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Domain;
using Core.Interface;
using Swashbuckle.AspNetCore.Filters;
using Newtonsoft.Json.Linq;
using Api.SwaggerExample;

namespace Api.Controllers
{

    [ApiController]
    [Route("api/campaigns")]
    public class CampaignController : ControllerBase
    {
        private ICampaignDataService campaignDataService;
        public CampaignController(ICampaignDataService campaignData)
        {
            this.campaignDataService = campaignData;
        }

        // GET: api/campaigns
        [HttpGet]
        public async Task<ActionResult> GetCampaigns()
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await campaignDataService.GetAll();
            return Ok(result);
        }

        // GET: api/campaigns/newYear
        [HttpGet("{campaignCode}")]
        public async Task<IActionResult> GetCampaignByCode([FromRoute] string campaignCode)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var email = await campaignDataService.GetByCampaignCode(campaignCode);

            if (email == null)
            {
                return NotFound();
            }

            return Ok(email);
        }

        // PUT: api/campaigns/thanksgiving
        [HttpPut("{campaign}")]
        public async Task<IActionResult> PutCampaign([FromRoute] string campaignCode, [FromBody] Campaign campaign)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            if (campaignCode != campaign.Code)
            {
                return BadRequest();
            }
            else if (campaignDataService.GetByCampaignCode(campaignCode) == null)
            {
                return NotFound();
            }

            await campaignDataService.UpdateCmapaign(campaign);

            return Ok(campaign);
        }

        // POST: api/campaigns
        [HttpPost]
        
        public async Task<IActionResult> AddNewCampagign([FromBody] Campaign campaign)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await campaignDataService.AddCmapaign(campaign);

            return Ok();
        }

        // DELETE: api/campaigns/thanksgiving
        [HttpDelete("{campaignCode}")]
        public async Task<IActionResult> DeleteCampaign([FromRoute] string campaignCode)
        {


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (campaignDataService.GetByCampaignCode(campaignCode) == null)
            {
                return NotFound();
            }

            await campaignDataService.DeleteCmapaign(campaignCode);
            return Ok();

        }
    }

}
