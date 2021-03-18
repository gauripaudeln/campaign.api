using Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface
{
    public interface IEmailDataService
    {
        public Task<IEnumerable<Email>> GetAll();
        public Task<int> AddEmail(Email email);
        public Task<int> DeleteEmail(string campaignCode);
        public Task<int> UpdateEmail(Email email);
        public Task<Email> GetByCampaignCode(string campaignCode);


    }
}
