using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CommunityMedicineWebApp.DAL;
using CommunityMedicineWebApp.Model;

namespace CommunityMedicineWebApp.BLL
{
    public class CenterManager
    {
        CenterGateway aCenterGateway = new CenterGateway();

        public List<Center> ShowDistrictList()
        {
            return aCenterGateway.ShowDistrictList();
        }

        public List<Center> ShowthanaList()
        {
            return aCenterGateway.ShowthanaList();
        }

        public string SaveCenter(Center aCenter)
        {

            if (aCenterGateway.SaveCenter(aCenter) > 0)
            {
                return "Saved Successfully";
            }
            else
            {
                return "Failed";
            }
        }
    }
}