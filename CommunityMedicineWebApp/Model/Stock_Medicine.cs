using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommunityMedicineWebApp.Model
{
    public class StockMedicine
    {
        public int Id { get; set; }
        public int DistrictId { get; set; }
        public int ThanaId { get; set; }
        public int CenterId { get; set; }
        public int MedicineId { get; set; }
        public int Quantaty { get; set; }
    }
}