using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommunityMedicineWebApp.Model
{
    public class Patient
    {
        public int Id { get; set; }
        public string VoterId { get; set; }
        public int ServiceTimes { get; set; }

    }
}