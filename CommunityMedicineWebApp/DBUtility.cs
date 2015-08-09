using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace CommunityMedicineWebApp.DBUtility
{
    public class DBUtility
    {

        private SqlTransaction tran;
        public static string ConnectionString = WebConfigurationManager.ConnectionStrings["CMconnection"].ConnectionString;

        private SqlCommand iSqlCommand = new SqlCommand();
        SqlConnection iSqlConnection = new SqlConnection(ConnectionString);

        public DataSet GetDateSet(string sql)
        {
            DataSet ds = new DataSet();
            try
            {
                if (iSqlConnection.State != ConnectionState.Open)
                {
                    //iSqlConnection = new SqlConnection(conn);
                    iSqlConnection.Open();
                }
                SqlDataAdapter oDap = new SqlDataAdapter(sql, iSqlConnection);
                ds.Tables.Clear();
                oDap.Fill(ds);
                iSqlConnection.Close();
                //errormessage = "";
            }
            catch (Exception iException)
            {
                throw iException;
            }
            return ds;

        }

        public long InsertData(Hashtable htable, string procedureName)
        {

            long retID = 0;
            try
            {
                if (iSqlConnection.State != ConnectionState.Open)
                {
                    iSqlConnection.Open();
                }
                iSqlCommand.Connection = iSqlConnection;
                iSqlCommand.CommandText = procedureName;
                iSqlCommand.CommandType = CommandType.StoredProcedure;

                foreach (object OBJ in htable.Keys)
                {
                    string COLUMN_NAME = Convert.ToString(OBJ);
                    SqlParameter param = new SqlParameter("@" + COLUMN_NAME, htable[OBJ]);
                    iSqlCommand.Parameters.Add(param);
                }

                iSqlCommand.ExecuteNonQuery();
                retID = 1;
                iSqlCommand.Parameters.Clear();
            }
            catch (SqlException ex)
            {
                if (tran != null)
                {
                    tran.Rollback();
                    tran = null;
                }
                iSqlConnection.Close();
                throw ex;

            }
            catch (Exception ex)
            {
                if (tran != null)
                {
                    tran.Rollback();
                    tran = null;
                    iSqlConnection.Close();
                    throw ex;
                }
            }
            finally
            {
                iSqlConnection.Close();
            }
            return retID;
        }

        public long ExecuteCommand(Hashtable htable, string procedureName)
        {
            long retID = 0;
            try
            {
                if (iSqlConnection.State != ConnectionState.Open)
                {
                    iSqlConnection.Open();
                }
                iSqlCommand.Connection = iSqlConnection;
                iSqlCommand.CommandText = procedureName;
                iSqlCommand.CommandTimeout = 36000 * 10;
                // cmd.Transaction = tran;   
                iSqlCommand.CommandType = CommandType.StoredProcedure;

                foreach (object OBJ in htable.Keys)
                {
                    string COLUMN_NAME = Convert.ToString(OBJ);
                    SqlParameter param = new SqlParameter("@" + COLUMN_NAME, htable[OBJ]);
                    iSqlCommand.Parameters.Add(param);
                }
                iSqlCommand.ExecuteNonQuery();
                retID = 1;
                iSqlCommand.Parameters.Clear();
                if (tran == null)
                {
                    iSqlConnection.Close();
                }
            }
            catch (SqlException ex)
            {
                if (tran != null)
                {
                    tran.Rollback();
                    tran = null;
                }
                iSqlConnection.Close();
                throw ex;

            }
            catch (Exception ex)
            {
                if (tran != null)
                {
                    tran.Rollback();
                    tran = null;
                    iSqlConnection.Close();
                    throw ex;
                }

            }
            finally
            {
                iSqlConnection.Close();
            }

            return retID;
        }

        public DataTable GetDataByProc(Hashtable ht, string SProc)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            try
            {
                if (iSqlConnection.State != ConnectionState.Open)
                {
                    iSqlConnection.Open();
                }
                iSqlCommand.Connection = iSqlConnection;
                iSqlCommand.CommandText = SProc;
                iSqlCommand.CommandTimeout = 36000 * 10;
                iSqlCommand.CommandType = CommandType.StoredProcedure;
                foreach (object obj in ht.Keys)
                {
                    string ColumnName = Convert.ToString(obj);
                    SqlParameter param = new SqlParameter(ColumnName, ht[obj]);
                    iSqlCommand.Parameters.Add(param);
                }
                adp.SelectCommand = iSqlCommand;
                adp.Fill(ds, "Table1");
                iSqlCommand.Parameters.Clear();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                iSqlConnection.Close();
            }
            return ds.Tables[0];
        }

        public DataTable GetDataByProc(string SProc)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            try
            {
                if (iSqlConnection.State != ConnectionState.Open)
                {
                    iSqlConnection.Open();
                }
                iSqlCommand.Connection = iSqlConnection;
                iSqlCommand.CommandText = SProc;
                iSqlCommand.CommandTimeout = 36000 * 10;
                iSqlCommand.CommandType = CommandType.Text;
                adp.SelectCommand = iSqlCommand;
                adp.Fill(ds, "Table1");
                iSqlCommand.Parameters.Clear();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                iSqlConnection.Close();
            }
            return ds.Tables[0];
        }
        public DataTable GetDataTableByQuery(string SqlQuery)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            try
            {
                if (iSqlConnection.State != ConnectionState.Open)
                {
                    iSqlConnection.Open();
                }
                iSqlCommand.Connection = iSqlConnection;
                iSqlCommand.CommandText = SqlQuery;
                iSqlCommand.CommandTimeout = 36000 * 10;
                iSqlCommand.CommandType = CommandType.Text;
                adp.SelectCommand = iSqlCommand;
                adp.Fill(ds, "Table1");
                iSqlCommand.Parameters.Clear();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                iSqlConnection.Close();
            }
            return ds.Tables[0];
        }


        public int ExecuteStoredProcedure(string Procedure)
        {
            int retID = 0;
            try
            {
                if (iSqlConnection.State != ConnectionState.Open)
                {
                    //iSqlConnection = new SqlConnection(conn);
                    iSqlConnection.Open();
                }
                iSqlCommand.Connection = iSqlConnection;
                iSqlCommand.CommandText = Procedure;
                // cmd.Transaction = tran;   
                iSqlCommand.CommandType = CommandType.StoredProcedure;
                iSqlCommand.ExecuteNonQuery();
                retID = 1;
            }
            catch (SqlException ex)
            {
                if (tran != null)
                {
                    tran.Rollback();
                    tran = null;
                }
                //iSqlConnection.Close();
                throw ex;

            }
            catch (Exception ex)
            {
                if (tran != null)
                {
                    tran.Rollback();
                    tran = null;
                    //iSqlConnection.Close();
                    throw ex;
                }

            }
            finally
            {
                iSqlConnection.Close();
            }
            return retID;
        }
        public int ExecuteSqlQuery(string sql)
        {
            int retID = 0;
            try
            {
                if (iSqlConnection.State != ConnectionState.Open)
                {
                    //iSqlConnection = new SqlConnection(conn);
                    iSqlConnection.Open();
                }
                iSqlCommand.Connection = iSqlConnection;
                iSqlCommand.CommandText = sql;
                // cmd.Transaction = tran;   
                iSqlCommand.CommandType = CommandType.Text;
                iSqlCommand.ExecuteNonQuery();
                retID = 1;
            }
            catch (SqlException ex)
            {
                if (tran != null)
                {
                    tran.Rollback();
                    tran = null;
                }
                //iSqlConnection.Close();
                throw ex;

            }
            catch (Exception ex)
            {
                if (tran != null)
                {
                    tran.Rollback();
                    tran = null;
                    //iSqlConnection.Close();
                    throw ex;
                }

            }
            finally
            {
                iSqlConnection.Close();
            }
            return retID;
        }



    }
}