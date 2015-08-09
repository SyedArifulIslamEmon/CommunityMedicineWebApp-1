using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using CommunityMedicineWebApp.Model;

namespace CommunityMedicineWebApp.DAL
{
    public class DiseaseGateway
    {

        private string connectionString = WebConfigurationManager.ConnectionStrings["CMconnection"].ConnectionString;


        public int Save(Disease aDisease)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO disease_table VALUES ('" + aDisease.Name + "', '"+aDisease.Description+"', '"+aDisease.Treatment+"') ";
            SqlCommand aCommand = new SqlCommand(query, connection);
            connection.Open();
            int rowAffedted = aCommand.ExecuteNonQuery();
            connection.Close();
            return rowAffedted;
        }

        public bool Save(string nametext)
        {
            bool isNameExists = false;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * from disease_table where name ='" + nametext + "'", connection);
                connection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();


                while (rdr.Read())
                {
                    isNameExists = true;
                    break;
                }
            }
            return isNameExists;
        }


        public List<Disease> ShowDisease()
        {
            List<Disease> diseaseList = new List<Disease>();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM disease_table";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader aReader = command.ExecuteReader();
            while(aReader.Read())
            {
                Disease aDisease = new Disease();
                aDisease.Id = (int)aReader["id"];
                aDisease.Name = (string) aReader["name"];
                aDisease.Description = (string)aReader["description"];
                aDisease.Treatment = (string)aReader["treatment"];
                diseaseList.Add(aDisease);
            }
            aReader.Close();
            connection.Close();

            return diseaseList;
        }
    }
}