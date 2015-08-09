using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.Script.Serialization;
using CommunityMedicineWebApp.Model;
using System.Web.UI.WebControls;
using CommunityMedicineWebApp.BLL;
using CommunityMedicineWebApp.DAL;
using System.Data;
using Newtonsoft.Json;


namespace CommunityMedicineWebApp.UI
{
    public partial class PatientTreantment : System.Web.UI.Page
    {
        CommonGatway GCommon = new CommonGatway();
        protected void Page_Load(object sender, EventArgs e)
        {
            int centerId = int.Parse(Session["Center_Id"].ToString());
            if (!IsPostBack)
            {
                diseaseDropDownList.DataSource =(DataTable) GCommon.GetDataTableByQuery("Select * from disease_table");
                diseaseDropDownList.DataTextField = "name";
                diseaseDropDownList.DataValueField = "Id";
                diseaseDropDownList.DataBind();


                medicineDropDownList.DataSource = (DataTable)GCommon.GetDataTableByQuery("SELECT [id],[name] FROM [dbo].[medicine_table] where id in( select distinct medicineid from dbo.CenterMedicineRelationTBL where CenterId =" + centerId.ToString() + ")");
                medicineDropDownList.DataTextField = "Name";
                medicineDropDownList.DataValueField = "Id";
                medicineDropDownList.DataBind();

                doctorDropDownList.DataSource = (DataTable) GCommon.GetDataTableByQuery("SELECT [id],[doctorname] FROM [dbo].[doctor_table] where Center_id=" + centerId.ToString() + "");
                doctorDropDownList.DataTextField = "DoctorName";
                doctorDropDownList.DataValueField = "Id";
                doctorDropDownList.DataBind();
            }

        }
        PatientManager patientManager = new PatientManager();
        protected void showButton_Click(object sender, EventArgs e)
        {
           
            List<Voter> voterList = new List<Voter>();
            using (var client = new WebClient())
            {
                var url = "http://nerdcastlebd.com/web_service/voterdb/index.php/voters/all/format/json";
                var jsonString = client.DownloadString(url);
                var json = new JavaScriptSerializer().Deserialize<dynamic>(jsonString);
                foreach (Dictionary<string, object> voter in json["voters"])
                {
                    Voter aVoter = new Voter();
                    aVoter.Id = voter["id"].ToString();
                    aVoter.Name = voter["name"].ToString();
                    aVoter.Address = voter["address"].ToString();
                    aVoter.Date_Of_Birth = voter["date_of_birth"].ToString();
                    voterList.Add(aVoter);
                }
            }

            //string jsonStringCollection = "[{\"id\":\"5644309456813\",\"name\":\"Rimi Khanom\",\"address\":\"House no: 12. Road no: 14. Dhanmondi, Dhaka\",\"date_of_birth\":\"1979-01-15\"},{\"id\":\"9509623450915\",\"name\":\"Asif Latif\",\"address\":\"House no: 98. Road no: 14. Katalgonj, Chittagong\",\"date_of_birth\":\"1988-07-11\"},{\"id\":\"1098789543218\",\"name\":\"Rakib Hasan\",\"address\":\"Vill. Shantinagar. Thana: Katalgonj, Faridpur\",\"date_of_birth\":\"1982-04-12\"},{\"id\":\"7865409458659\",\"name\":\"Rumon Sarker\",\"address\":\"Kishorginj\",\"date_of_birth\":\"1970-12-02\"},{\"id\":\"8909854343334\",\"name\":\"Gaji Salah Uddin\",\"address\":\"Chittagong\",\"date_of_birth\":\"1965-06-16\"}]";
            //List<Voter> voterList = new JavaScriptSerializer().Deserialize<List<Voter>>(jsonStringCollection);

            string voterId = voterIdTextBox.Text;
            foreach (var voter in voterList)
            {

                if (voter.Id.Equals(voterId))
                {
                    nameTextBox.Text = voter.Name;
                    addressTextBox.Text = voter.Address;
                    string year = voter.Date_Of_Birth.Substring(0, 4);
                    string age = (2015 - int.Parse(year)).ToString();
                    ageTextBox.Text = age;
                    serviceGivenTextBox.Text = patientManager.GetServiceTimes(voterId).ToString();
                    
                }
            }

            
        }

        CenterMedicineRelationManager centerMedicineRelationManager = new CenterMedicineRelationManager();
        protected void addButton_Click(object sender, EventArgs e)
        {
            Treatment aTreatment = new Treatment();
            aTreatment.NameOfDisease = diseaseDropDownList.SelectedItem.ToString();
            aTreatment.NameOfMedicine = medicineDropDownList.SelectedItem.ToString();
            aTreatment.Dose = doseDropDownList.SelectedItem.ToString();
            aTreatment.DiseaseId = int.Parse(diseaseDropDownList.SelectedValue);
            aTreatment.MedicineId = int.Parse(medicineDropDownList.SelectedValue);
            int centerId = int.Parse(Session["Center_Id"].ToString());
            if (beforMealRadioButton.Checked)
            {
                aTreatment.TakenTime = "Before Meal";
            }
            else
            {
                aTreatment.TakenTime = "After Meal";
            }
            aTreatment.Quantity = int.Parse(quantityTextBox.Text);
            aTreatment.Note = noteTextBox.Text;
            int medicineQuantity = centerMedicineRelationManager.GetCenterMedicineQuantity(centerId, aTreatment.MedicineId);
            if (medicineQuantity < aTreatment.Quantity)
            {
                megLabel.Text = "Stock Limited!";
            }
            else
            {
                int newQuantity = medicineQuantity - aTreatment.Quantity;
                centerMedicineRelationManager.UpdateCenterMedicineQuantity(centerId, aTreatment.MedicineId, newQuantity);
                TreatmentList.Add(aTreatment);
                treatmentGridView.DataSource = TreatmentList;
                treatmentGridView.DataBind();
            }
        }
        public List<Treatment> TreatmentList
        {
            get
            {
                if (!(ViewState["TreatmentList"] is List<Treatment>))
                {
                    ViewState["TreatmentList"] = new List<Treatment>();
                }

                return (List<Treatment>)ViewState["TreatmentList"];
            }
        }
        TreatmentManager treatmentManager = new TreatmentManager();

        protected void saveButton_Click(object sender, EventArgs e)
        {
            Patient aPatient = new Patient();
            aPatient.VoterId = voterIdTextBox.Text;
            int count = int.Parse(serviceGivenTextBox.Text);
            aPatient.ServiceTimes = count + 1;
            if (patientManager.IfPatientExists(aPatient))
            {

                megLabel.Text = patientManager.UpdateServiceTimes(aPatient);

            }
            else
            {
                megLabel.Text = patientManager.SavePatient(aPatient);
            }

            aPatient.Id = patientManager.GetPatientId(aPatient);
            int centerId = int.Parse(Session["Center_Id"].ToString());
            patientManager.PatientCenterTblValue(aPatient.Id, centerId);

            Treatment aTreatment = new Treatment();
            aTreatment.Observation = observationTextBox.Text;
            aTreatment.DoctorId = int.Parse(doctorDropDownList.SelectedValue);
            aTreatment.Date = Request.Form["bday"];

            int observationId = treatmentManager.SaveObservation(aTreatment, aPatient, centerId);

            foreach (var treatment in TreatmentList)
            {
                Treatment newTreatment = new Treatment();
                newTreatment.DiseaseId = treatment.DiseaseId;
                newTreatment.MedicineId = treatment.MedicineId;
                newTreatment.Dose = treatment.Dose;
                newTreatment.Quantity = treatment.Quantity;
                newTreatment.Note = treatment.Note;
                newTreatment.TakenTime = treatment.TakenTime;
                treatmentManager.SaveTreatment(newTreatment, observationId);
            }


        }

    }
}