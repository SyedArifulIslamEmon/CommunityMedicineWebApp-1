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
    public partial class CreateCenter : System.Web.UI.Page
    {
        CenterManager aCenterManager = new CenterManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                districtDropDownList.DataSource = aCenterManager.ShowDistrictList();
                districtDropDownList.DataTextField = "name";
                districtDropDownList.DataValueField = "id";
                districtDropDownList.DataBind();

                thanaDropDownList.DataSource = aCenterManager.ShowthanaList();
                thanaDropDownList.DataTextField = "name";
                thanaDropDownList.DataValueField = "id";
                thanaDropDownList.DataBind();

            }
        }
        public string CreatePassword()
        {

            var chars = " .'#@^><*&abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            var result = new string(
                Enumerable.Repeat(chars, 8)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());

            return result;
        }

        public string CreateCode()
        {

            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var random = new Random();
            var result = new string(
                Enumerable.Repeat(chars, 5)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());

            return result;
        }

        public string CreateCode(string thanaName)
        {
            return thanaName + "_" + CreateCode();
        }
        Center aCenter = new Center();
        protected void saveButton_Click(object sender, EventArgs e)
        {
            Center aCenter = new Center();
            aCenter.Name = centerTextBox.Text;
            string thanaName = thanaDropDownList.SelectedItem.ToString();
            aCenter.ThanaId = int.Parse(thanaDropDownList.SelectedValue);
            aCenter.Password = CreatePassword();
            aCenter.Code = CreateCode(thanaName);
            Session["Name"] = aCenter.Name;
            Session["Code"] = aCenter.Code;
            Session["Password"] = aCenter.Password;
            msgLabel.Text = aCenterManager.SaveCenter(aCenter);
            Response.Redirect("CenterView.aspx");

        }
    }
}