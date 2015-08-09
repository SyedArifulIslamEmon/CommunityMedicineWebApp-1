using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using CommunityMedicineWebApp.Model;

namespace CommunityMedicineWebApp.DAL
{
    public class CenterGateway
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["CMconnection"].ConnectionString;
        public List<Center> ShowDistrictList()
        {
            List<Center> districtList = new List<Center>(); 

            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM district_table";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader aReader = command.ExecuteReader();
            while (aReader.Read())
            {
                Center aStudent = new Center();
                aStudent.Id = (int)aReader["district_id"]; 
                aStudent.Name = (string)aReader["district_name"];
                districtList.Add(aStudent);
            }
            aReader.Close();
            connection.Close();
            return districtList;
        }

        public List<Center> ShowthanaList()
        {
            List<Center> thanaList = new List<Center>();

            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM thana_table";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader aReader = command.ExecuteReader();
            while (aReader.Read())
            {
                Center aStudent = new Center();
                aStudent.Id = (int)aReader["thana_id"];
                aStudent.Name = (string)aReader["thana_name"];
                thanaList.Add(aStudent);
            }
            aReader.Close();
            connection.Close();
            return thanaList;
        }

        public int SaveCenter(Center aCenter)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO center_table VALUES ('" + aCenter.Name+ "', '" + aCenter.Code+ "', '" + aCenter.Password + "', '"+aCenter.ThanaId + "') ";
            SqlCommand aCommand = new SqlCommand(query, connection);
            connection.Open();
            int rowAffedted = aCommand.ExecuteNonQuery();
            connection.Close();
            return rowAffedted;
        }
    }
}