using Core.Domain;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.SwaggerExample
{
    public class CampaignExmpale : IExamplesProvider<Campaign>
    {
        public Campaign GetExamples()
        {
            return new Campaign("newYear", "New year campaign", "New year campaign description");
        }
    }
}
