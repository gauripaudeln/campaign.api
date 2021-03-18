using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Core.Domain
{
    public class Email
    {
        public Email(string campaignCode, string subject, string headerTex, string bodyHtml, string footerText, string receipients)
        {
            CampaignCode = campaignCode;
            Subject = subject;
            HeaderTex = headerTex;
            BodyHtml = bodyHtml;
            FooterText = footerText;
            Receipients = receipients;
        }
        public Email(string campaingCode)
        {
            this.CampaignCode = campaingCode;
        }
        [Key]
        public string CampaignCode { get;  set; }
        public string Subject { get;  set; }
        public string HeaderTex { get;  set; }
        public string BodyHtml { get;  set; }
        public string FooterText { get;  set; }
        public string Receipients { get;  set; }

        
        public Email()
        {

        }
    }
}
