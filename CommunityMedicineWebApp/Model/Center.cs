using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommunityMedicineWebApp.Model
{
    public class Center
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ThanaId { get; set; }
    
        public string Code { get; set; }
        public string Password { get; set; }
    }
}