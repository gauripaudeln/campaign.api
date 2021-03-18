using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Domain;
using Core.Interface;
using Data.Infra;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class CampaignDataService : ICampaignDataService
    {
        private CampaignDbContext db;
        public CampaignDataService(CampaignDbContext dbContext)
        {
            this.db = dbContext;
        }
        public async Task<int> AddCmapaign(Campaign campaign)
        {
            db.CampaignRecs.Add(campaign);
            return await db.SaveChangesAsync();
        }

        public async Task<int> DeleteCmapaign(string campaingCode)
        {
            var campaing = await db.CampaignRecs.FirstOrDefaultAsync(c => c.Code == campaingCode);
            db.CampaignRecs.Remove(campaing);
            return await db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Campaign>> GetAll()
        {
            return await db.CampaignRecs.ToListAsync();
        }

        public async Task<int> UpdateCmapaign(Campaign campaign)
        {
            db.CampaignRecs.Attach(campaign);
            db.Entry(campaign).State = EntityState.Modified;
           return await db.SaveChangesAsync();
        }

        public async Task<Campaign> GetByCampaignCode(string campaignCode)
        {
            return await db.CampaignRecs.FirstOrDefaultAsync(e => e.Code == campaignCode);
        }
    }
}
