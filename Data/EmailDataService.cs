using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain;
using Core.Interface;
using Data.Infra;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class EmailDataService : IEmailDataService
    {
        private CampaignDbContext db;
        public EmailDataService(CampaignDbContext dbContext)
        {
            this.db = dbContext;
        }
        public async Task<int> AddEmail(Email email)
        {
            db.EmailRecs.Add(email);
            return await db.SaveChangesAsync();

        }

        public async Task<int> DeleteEmail(string campaingCode)
        {

            var email = await db.EmailRecs.FirstOrDefaultAsync(e => e.CampaignCode == campaingCode);
            db.EmailRecs.Remove(email);
            return await db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Email>> GetAll()
        {
            return await db.EmailRecs.ToListAsync();
        }

        public async Task<Email> GetByCampaignCode(string campaignCode)
        {
            return  await db.EmailRecs.FirstOrDefaultAsync(e => e.CampaignCode == campaignCode);
        }

        public async Task<int> UpdateEmail(Email email)
        {
            db.EmailRecs.Attach(email);
            db.Entry(email).State = EntityState.Modified;
            return await db.SaveChangesAsync();
        }
    }
}
