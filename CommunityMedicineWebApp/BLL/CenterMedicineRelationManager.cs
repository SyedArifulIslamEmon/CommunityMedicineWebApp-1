using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CommunityMedicineWebApp.DAL;
using CommunityMedicineWebApp.Model;

namespace CommunityMedicineWebApp.BLL
{
    public class CenterMedicineRelationManager
    {
        CenterMedicineRelationGateway centerMedicineRelationGateway = new CenterMedicineRelationGateway();
        public int GetCenterMedicineQuantity(int centerId, int medicineId)
        {
            return centerMedicineRelationGateway.GetCenterMedicineQuantity(centerId, medicineId);
        }
        public void UpdateCenterMedicineQuantity(int centerId, int medicineId, int quantity)
        {

            centerMedicineRelationGateway.UpdateCenterMedicineQuantity(centerId, medicineId, quantity);
        }
        public List<Medicine> GetCenterAllMedicineList(int centerId)
        {
            return centerMedicineRelationGateway.GetCenterAllMedicineList(centerId);
        }
        public bool IsMedicineExists(int centerId, int medicineId)
        {
            return centerMedicineRelationGateway.IsMedicineExists(centerId, medicineId);
        }
    }
}