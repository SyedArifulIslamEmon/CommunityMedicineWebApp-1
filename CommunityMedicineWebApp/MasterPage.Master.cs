using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CommunityMedicineWebApp.DAL;


namespace CommunityMedicineWebApp
{
  
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            CommonGatway GCommon = new CommonGatway();
            if (txtUserID.Text.Trim() == "")
            {
                Alert.Show("UserID Can't be Empty.");
                txtUserID.Focus();
                return;
            }
            else if (txtPassword.Text.Trim() == "")
            {
                Alert.Show("Password Can't be Empty.");
                txtPassword.Focus();
                return;
            }
            else
            {
                string sql = "SELECT center_id,center_name,code FROM center_table WHERE code='" + txtUserID.Text + "' And password='" + txtPassword.Text.Trim() + "'";
                DataTable DTabUser = new DataTable();
                DTabUser = GCommon.GetDataTableByQuery(sql);
                if (DTabUser.Rows.Count > 0)
                {
                    Session["Center_id"] = DTabUser.Rows[0]["center_id"].ToString();
                    Session["Center_name"] = DTabUser.Rows[0]["center_name"].ToString();
                    Session["code"] = DTabUser.Rows[0]["code"].ToString();
                    Response.Redirect("~/UI/CenterHome.aspx");
                }
                else
                {
                    Alert.Show("InValid User & Password.");
                    return;
                }
            }
        }
    }
}