using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Web.UI.WebControls;
using CommunityMedicineWebApp.BLL;
using System.Data;
using CommunityMedicineWebApp.Model;
using System.Data.SqlClient;

namespace CommunityMedicineWebApp.UI
{
    public partial class MedicineStock : System.Web.UI.Page
    {
        MedicineManager aMedicineManager = new MedicineManager();

        private string connectionString = WebConfigurationManager.ConnectionStrings["CMconnection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                medicineDropDownList.DataSource = aMedicineManager.ShowmedicineList();
                medicineDropDownList.DataTextField = "name";
                medicineDropDownList.DataValueField = "id";
                medicineDropDownList.DataBind();

                BindDistrictdropdown();

                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[3] { new DataColumn("id"),new DataColumn("Name"), new DataColumn("Quantaty") });
                ViewState["Medicine"] = dt;
                GridView1.DataSource = (DataTable)ViewState["Medicine"];
                GridView1.DataBind();

            }
        }
        protected void BindDistrictdropdown()
        {

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from district_table", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            ddlDistrict.DataSource = ds;
            ddlDistrict.DataTextField = "district_name";
            ddlDistrict.DataValueField = "district_id";
            ddlDistrict.DataBind();
            ddlDistrict.Items.Insert(0, new ListItem("--Select--", "0"));
        }


        protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            int did = Convert.ToInt32(ddlDistrict.SelectedValue);
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from thana_table where district_id=" + did, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            ddlThana.DataSource = ds;
            ddlThana.DataTextField = "thana_name";
            ddlThana.DataValueField = "thana_id";
            ddlThana.DataBind();
            ddlThana.Items.Insert(0, new ListItem("--Select--", "0"));
            if (ddlThana.SelectedValue == "0")
            {
                ddlCenter.Items.Clear();
                ddlCenter.Items.Insert(0, new ListItem("--Select--", "0"));
            }

        }


        protected void ddlThana_SelectedIndexChanged(object sender, EventArgs e)
        {
            int tid = Convert.ToInt32(ddlThana.SelectedValue);
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Center_table where thana_id=" + tid, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            ddlCenter.DataSource = ds;
            ddlCenter.DataTextField = "center_name";
            ddlCenter.DataValueField = "center_id";
            ddlCenter.DataBind();
            ddlCenter.Items.Insert(0, new ListItem("--Select--", "0"));
        }


        protected void addButton_Click(object sender, EventArgs e)
        {
            bool isNewRow = true;
            DataTable dt = (DataTable)ViewState["Medicine"];
            foreach(DataRow dr in dt.Rows)
            {
                if (dr["id"].ToString().Trim() == medicineDropDownList.SelectedValue.ToString().Trim())
                { 
                dr["Quantaty"]= Convert.ToInt16(dr["Quantaty"].ToString())+ Convert.ToInt16(quantatyTextBox.Text.Trim());
                isNewRow = false;
                }
            }
            if (isNewRow)
            {
                dt.Rows.Add(medicineDropDownList.SelectedValue,medicineDropDownList.SelectedItem, quantatyTextBox.Text.Trim());
            }
            ViewState["Medicine"] = dt;
            GridView1.DataSource = (DataTable)ViewState["Medicine"];
            GridView1.DataBind();
            quantatyTextBox.Text = String.Empty;

        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            DataTable DTab = (DataTable)ViewState["Medicine"];
                 foreach(DataRow dr in DTab.Rows)
            {
              
                StockMedicine aStockMedicine = new StockMedicine();

                aStockMedicine.ThanaId = int.Parse(ddlThana.SelectedValue);
                aStockMedicine.CenterId = int.Parse(ddlCenter.SelectedValue);

                aStockMedicine.MedicineId = int.Parse(dr["id"].ToString().Trim());
                aStockMedicine.Quantaty = int.Parse(dr["Quantaty"].ToString().Trim());

                msgLabel.Text = aMedicineManager.SaveMedicine(aStockMedicine);

            }

        }
        
    }
}