using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CommunityMedicineWebApp
{
    public partial class CenterMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Center_id"] != null)
                {

                    lbl_name.Text = "Wellcome to " + Session["Center_name"].ToString();


                }
                else
                {
                    Session["Center_id"] = "";
                    Response.Redirect("~/UI/Home.aspx");
                }
            }
        }
    }
}