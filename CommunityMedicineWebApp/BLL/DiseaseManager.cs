using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CommunityMedicineWebApp.DAL;
using CommunityMedicineWebApp.Model;

namespace CommunityMedicineWebApp.BLL
{
    public class DiseaseManager
    {
        private DiseaseGateway aDiseaseGateway= new DiseaseGateway();
        public string Save(Disease aDisease)
        {
            if (IsNameExists(aDisease.Name))
            {
                return "Name Already Exists";
            }
            else
            {


                if (aDiseaseGateway.Save(aDisease) > 0)
                {
                    return "Saved Successfully";
                }
                else
                {
                    return "Failed";
                }
            }
        }

        public bool IsNameExists(string nametext)
        {
            return aDiseaseGateway.Save(nametext);
        }

        public List<Disease> ShowDisease()
        {
            return aDiseaseGateway.ShowDisease();
        }
    }
}