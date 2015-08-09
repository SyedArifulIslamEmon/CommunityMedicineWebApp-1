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
    public partial class DiseaseEntry : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            diseaseGridView.DataSource = aDiseaseManager.ShowDisease();
            diseaseGridView.DataBind();
        }

        DiseaseManager aDiseaseManager = new DiseaseManager();
        protected void saveButton_Click(object sender, EventArgs e)
        {
            Disease aDisease = new Disease();
            aDisease.Name = diseaseTextBox.Text;
            aDisease.Description = descripTextBox.Text;
            aDisease.Treatment = treatmentTextBox.Text;

            msgLabel.Text = aDiseaseManager.Save(aDisease);

            diseaseGridView.DataSource = aDiseaseManager.ShowDisease();
            diseaseGridView.DataBind();

        }
    }
}