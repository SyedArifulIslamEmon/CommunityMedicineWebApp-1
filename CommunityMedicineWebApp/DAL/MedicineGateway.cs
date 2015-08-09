using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using CommunityMedicineWebApp.Model;

namespace CommunityMedicineWebApp.DAL
{
    public class MedicineGateway
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["CMconnection"].ConnectionString;

        public int Save(Medicine aMedicine)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO medicine_table VALUES ('"+aMedicine.Name+"') ";
            SqlCommand aCommand = new SqlCommand(query,connection);
            connection.Open();
            int rowAffedted = aCommand.ExecuteNonQuery();
            connection.Close();
            return rowAffedted;
        }

        public List<Medicine> ShowMedicine()
        {
            List<Medicine> medicineList = new List<Medicine>();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM medicine_table order By id";
            SqlCommand aCommand = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader aReader = aCommand.ExecuteReader();
            while (aReader.Read())
            {
                Medicine aMedicine = new Medicine();
                aMedicine.Id = (int)aReader["id"];
                aMedicine.Name = (string)aReader["name"];
 
                medicineList.Add(aMedicine);
            }
            aReader.Close();
            connection.Close();

            return medicineList;
        }

        /*-------------------------------------------Stock Medicine------------------------------------------------*/
       
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
                aStudent.Id = (int)aReader["id"];
                aStudent.Name = (string)aReader["districtname"];
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
                aStudent.Id = (int)aReader["id"];
                aStudent.Name = (string)aReader["thananame"];
                thanaList.Add(aStudent);
            }
            aReader.Close();
            connection.Close();
            return thanaList;
        }

        public List<Center> ShowcenterList()
        {
            List<Center> centerList = new List<Center>();

            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM center_table";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader aReader = command.ExecuteReader();
            while (aReader.Read())
            {
                Center aStudent = new Center();
                aStudent.Id = (int)aReader["id"];
                aStudent.Name = (string)aReader["name"];
                centerList.Add(aStudent);
            }
            aReader.Close();
            connection.Close();
            return centerList;
        }

        public List<Center> ShowmedicineList()
        {
            List<Center> medicineList = new List<Center>();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM medicine_table";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader aReader = command.ExecuteReader();
            while (aReader.Read())
            {
                Center aStudent = new Center();
                aStudent.Id = (int)aReader["id"];
                aStudent.Name = (string)aReader["name"];
                medicineList.Add(aStudent);
            }
            aReader.Close();
            connection.Close();
            return medicineList;
        }

        public int SaveMedicine(StockMedicine aStockMedicine)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = " INSERT INTO CenterMedicineRelationTBL VALUES ('" + aStockMedicine.CenterId + "', '" + aStockMedicine.MedicineId + "', '" + aStockMedicine.Quantaty + "') ";
            SqlCommand aCommand = new SqlCommand(query, connection);
            connection.Open();
            int rowAffedted = aCommand.ExecuteNonQuery();
            connection.Close();
            return rowAffedted;
        }
        public Medicine GetCenterAllMedicines(int medicineId)
        {
            Medicine aMedicine = new Medicine();
            string query = "SELECT * FROM MedicineTBL WHERE Id='" + medicineId + "'";
            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {

                aMedicine.Id = int.Parse(reader["Id"].ToString());
                aMedicine.Name = reader["Name"].ToString();

            }
            reader.Close();
            connection.Close();
            return aMedicine;
        }


  
    }


}