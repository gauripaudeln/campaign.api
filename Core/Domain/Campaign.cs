using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Core.Domain
{
    public class Campaign
    {
        
        [Key]
        public string Code { get;  set; }
        public string Name { get;  set; }
        public string Description { get;  set; }
        public Campaign(string code , string name, string description)
        {
            this.Code = code;
            this.Name = name;
            this.Description = description;
        }
        public Campaign(string code)
        {
            this.Code = code;
            
        }

        public Campaign()
        {

        }
    }
}
