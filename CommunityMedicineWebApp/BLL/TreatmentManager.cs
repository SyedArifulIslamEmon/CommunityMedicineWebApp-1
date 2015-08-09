using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CommunityMedicineWebApp.DAL;
using CommunityMedicineWebApp.Model;


namespace CommunityMedicineWebApp.BLL
{
    public class TreatmentManager
    {
        TreatmentGateway treatmentGateway = new TreatmentGateway();
        public int SaveObservation(Treatment aTreatment, Patient aPatient, int centerId)
        {
            return treatmentGateway.SaveObservation(aTreatment, aPatient, centerId);
        }
        public void SaveTreatment(Treatment aTreatment, int observationId)
        {
            treatmentGateway.SaveTreatment(aTreatment, observationId);
        }
        public List<Treatment> GetObservationList(Patient aPatient)
        {
            return treatmentGateway.GetObservationList(aPatient);
        }
        public List<Treatment> GetTreatmentList(int observationId)
        {
            return treatmentGateway.GetTreatmentList(observationId);
        }
    }
}