using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CommunityMedicineWebApp.Model;
using System.Configuration;
using System.Data.SqlClient;

namespace CommunityMedicineWebApp.DAL
{
    public class DoctorGateway
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["CMconnection"].ConnectionString;

        public int SaveDoctor(Doctor aDoctor, int centerId)
        {
            string query = "INSERT INTO doctor_table VALUES('" + aDoctor.DoctorName + "','" + aDoctor.Degree + "','" + aDoctor.Specialization + "','" + centerId + "')";
            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;

        }
        public List<Doctor> GetAllDoctors(int centerId)
        {

            List<Doctor> doctorsList = new List<Doctor>();

            string query = "SELECT * FROM DoctorTBL WHERE CenterId='" + centerId + "'";
            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Doctor aDoctor = new Doctor();
                aDoctor.Id = int.Parse(reader["Id"].ToString());
                aDoctor.DoctorName = reader["DoctorName"].ToString();
                doctorsList.Add(aDoctor);
            }

            reader.Close();
            connection.Close();

            return doctorsList;



        }
        public string GetDoctorName(int doctorId)
        {
            string doctorName = "";
            string query = "SELECT * FROM DoctorTBL WHERE Id='" + doctorId + "'";
            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {

                doctorName = reader["DoctorName"].ToString();

            }
            reader.Close();
            connection.Close();
            return doctorName;
        }

    }
}