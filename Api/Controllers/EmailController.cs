using Core.Domain;
using Core.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/emails")]
    public class EmailController : ControllerBase
    {
        private IEmailDataService emailDataService;
        public EmailController(IEmailDataService emailData)
        {
            this.emailDataService = emailData;
        }

        // GET: api/emails
        [HttpGet]
        public async Task<ActionResult> GetEmails()
        {
            var result = await emailDataService.GetAll();
            return Ok(result);
        }

        // GET: api/emails/newYear
        [HttpGet("{campaignCode}")]
        public async Task<IActionResult> GetEmailByCampaign([FromRoute] string campaignCode)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var email = await emailDataService.GetByCampaignCode(campaignCode);

            if (email == null)
            {
                return NotFound();
            }

            return Ok(email);
        }

        // PUT: api/emails/thanksgiving
        [HttpPut("{campaignCode}")]
        public async Task<IActionResult> PutEmail([FromRoute] string campaignCode, [FromBody] Email email)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (campaignCode != email.CampaignCode)
            {
                return BadRequest();
            } else  if (emailDataService.GetByCampaignCode(campaignCode) ==null)
            {
                return NotFound();
            }
                
            await emailDataService.UpdateEmail(email);
           
            return Ok(email);
        }

        // POST: api/emails
        [HttpPost]
        public async Task<IActionResult> AddNewEmail([FromBody] Email email)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await emailDataService.AddEmail(email);

            return Ok();
        }

        // DELETE: api/emails/thanksgiving
        [HttpDelete("{campaignCode}")]
        public async Task<IActionResult> DeleteEmail([FromRoute] string campaignCode)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (emailDataService.GetByCampaignCode(campaignCode) == null)
            {
                return NotFound();
            }

            await emailDataService.DeleteEmail(campaignCode);
            return Ok();
            
        }
    }
}
