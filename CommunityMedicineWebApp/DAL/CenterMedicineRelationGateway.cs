using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using CommunityMedicineWebApp.BLL;
using CommunityMedicineWebApp.Model;

namespace CommunityMedicineWebApp.DAL
{
    public class CenterMedicineRelationGateway
    {
        MedicineManager medicineManager = new MedicineManager();
        private string connectionString = ConfigurationManager.ConnectionStrings["CMconnection"].ConnectionString;

        public int GetCenterMedicineQuantity(int centerId, int medicineId)
        {
            int quantity = 0;
            string query = "SELECT * FROM CenterMedicineRelationTBL WHERE CenterId='" + centerId + "' AND MedicineId='" + medicineId + "'";
            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                quantity = int.Parse(reader["Quantity"].ToString());

            }
            reader.Close();
            connection.Close();
            return quantity;
        }
        public void UpdateCenterMedicineQuantity(int centerId, int medicineId, int quantity)
        {
            string query = "UPDATE CenterMedicineRelationTBL SET Quantity='" + quantity + "' WHERE CenterId='" + centerId + "' AND MedicineId='" + medicineId + "'";
            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

        }
        public List<Medicine> GetCenterAllMedicineList(int centerId)
        {
            List<Medicine> medicineList = new List<Medicine>();
            string query = "SELECT * FROM CenterMedicineRelationTBL WHERE CenterId='" + centerId + "'";
            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int medicineId = int.Parse(reader["MedicineId"].ToString());
                Medicine aMedicine = new Medicine();
                aMedicine = medicineManager.GetCenterAllMedicines(medicineId);
                aMedicine.Quantity = int.Parse(reader["Quantity"].ToString());
                medicineList.Add(aMedicine);
            }
            reader.Close();
            connection.Close();
            return medicineList;
        }

        public bool IsMedicineExists(int centerId, int medicineId)
        {
            bool exists = false;
            string query = "SELECT * FROM CenterMedicineRelationTBL WHERE CenterId='" + centerId + "' AND MedicineId='" + medicineId + "'"; ;
            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                exists = true;
            }
            reader.Close();
            connection.Close();

            return exists;
        }

    }
}