using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Purpose: ASP.NET Lab3
//Author: Lindsay
//Date:July, 2018

namespace Lingyan_Li_Lab3
{
    [DataObject(true)]
    public static class IncidentDB
    {
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List<Incident> GetOpenTechIncidents(int techID)
        {
            List<Incident> incidents = new List<Incident>(); //empty list
            Incident inci = null; //reference for reading
            //define conncetion
            SqlConnection conn = TechSupportDB.GetConnection();

            //define the select query command
            //inner joins customer and incident table, only dipspay the open incidents
            string selectQuery = "SELECT IncidentID, I.CustomerID, ProductCode, TechID, DateOpened, DateClosed, Title, Description, C.Name " +
                                 "FROM Incidents I JOIN Customers C " +
                                 "ON I.CustomerID = C.CustomerID " +
                                 "WHERE DateClosed IS NULL AND TechID = @TechID " +
                                 "ORDER BY DateOpened";
            SqlCommand selectCmd = new SqlCommand(selectQuery, conn);
            selectCmd.Parameters.AddWithValue("@TechID", techID);
            try
            {
                //open the connection
                conn.Open();

                //execute the query
                SqlDataReader dr = selectCmd.ExecuteReader(); // can be multiple records

                //process the results
                while (dr.Read()) //while there are incidents
                {
                    inci = new Incident();
                    inci.IncidentID = (int)dr["IncidentID"];
                    inci.CustomerID= (int)dr["CustomerID"];
                    inci.ProductCode = (string)dr["ProductCode"];
                    inci.TechID = (int)dr["TechID"];
                    inci.DateOpened = (DateTime)dr["DateOpened"];
                    inci.DateClosed = dr["DateClosed"] as DateTime?;
                    inci.Title = (string)dr["Title"];
                    inci.Description = (string)dr["Description"];
                    inci.CustomerName = dr["Name"].ToString();
                    incidents.Add(inci);
                }
            }
            catch (SqlException ex)
            {
                throw ex;// let the form handle it
            }
            finally
            {
                conn.Close();// close connection no matter what
            }

            return incidents;
        }
    }
        
}
