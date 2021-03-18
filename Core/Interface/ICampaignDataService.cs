using Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface
{
    public interface ICampaignDataService
    {
        public  Task<IEnumerable<Campaign>> GetAll();
        public  Task<int> AddCmapaign(Campaign campaign);
        public Task<int> DeleteCmapaign(string campaignCode);
        public Task<int> UpdateCmapaign(Campaign campaign);
        public Task<Campaign> GetByCampaignCode(string campaignCode);

    }
}
