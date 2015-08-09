using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommunityMedicineWebApp.Model
{
    [Serializable]
    public class Treatment
    {
        public int Id { get; set; }
        public string NameOfDisease { get; set; }
        public string NameOfMedicine { get; set; }
        public string Dose { get; set; }
        public string TakenTime { get; set; }
        public int Quantity { get; set; }
        public string Note { get; set; }
        public string Observation { get; set; }
        public string Date { get; set; }
        public int DoctorId { get; set; }
        public int MedicineId { get; set; }
        public int DiseaseId { get; set; }
        public int CenterId { get; set; }
        public int ObservationId { get; set; }
    }
}