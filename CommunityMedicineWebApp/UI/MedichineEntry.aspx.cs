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
    public partial class MedichineEntry : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            medicineGridView.DataSource = aMedicineManager.ShowMedicine();
            medicineGridView.DataBind();
        }

        MedicineManager aMedicineManager = new MedicineManager();
        protected void saveButton_Click(object sender, EventArgs e)
        {
            Medicine aMedicine = new Medicine();

            aMedicine.Name = medicineTextBox.Text;

            msgLabel.Text = aMedicineManager.Save(aMedicine);
            medicineGridView.DataSource = aMedicineManager.ShowMedicine();
            medicineGridView.DataBind();
        }
    }
}