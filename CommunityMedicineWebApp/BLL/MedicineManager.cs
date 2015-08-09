using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CommunityMedicineWebApp.DAL;
using CommunityMedicineWebApp.Model;

namespace CommunityMedicineWebApp.BLL
{
    public class MedicineManager
    {
        private MedicineGateway aMedicineGateway = new MedicineGateway();
        public string Save(Medicine aMedicine)
        {
                if (aMedicineGateway.Save(aMedicine) > 0)
                {
                    return "Saved Successfully";
                }
                else
                {
                    return "Failed";
                }
        }

        public List<Medicine> ShowMedicine()
        {
            return aMedicineGateway.ShowMedicine();
        }

        /*---------------------------------Stock Medicine----------------------------------------*/

        public List<Center> ShowDistrictList()
        {
            return aMedicineGateway.ShowDistrictList();
        }

        public List<Center> ShowthanaList()
        {
            return aMedicineGateway.ShowthanaList();
        }

        public List<Center> ShowcenterList()
        {
            return aMedicineGateway.ShowcenterList();
        }

        MedicineGateway gMedicineGateway = new MedicineGateway();
        public List<Center> ShowmedicineList()
        {
            return aMedicineGateway.ShowmedicineList();
        }
        public Medicine GetCenterAllMedicines(int medicineId)
        {
            return gMedicineGateway.GetCenterAllMedicines(medicineId);
        }


        public string SaveMedicine(StockMedicine aStockMedicine)
        {
            if (aMedicineGateway.SaveMedicine(aStockMedicine) > 0)
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
