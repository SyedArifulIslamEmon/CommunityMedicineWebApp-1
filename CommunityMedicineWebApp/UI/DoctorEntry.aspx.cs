using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CommunityMedicineWebApp.BLL;
using CommunityMedicineWebApp.Model;

namespace CommunityMedicineWebApp.UI
{
    public partial class DoctorEntry : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        DoctorManager doctorManager = new DoctorManager();
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            Doctor aDoctor = new Doctor();
            aDoctor.DoctorName = txtDoctorName.Text;
            aDoctor.Degree = txtDegree.Text;
            aDoctor.Specialization = txtSpecialization.Text;
            int centerId = int.Parse(Session["Center_id"].ToString());
            Alert.Show(doctorManager.SaveDoctor(aDoctor, centerId));
        }
    }
}