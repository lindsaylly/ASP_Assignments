using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/*Purpose: ASP.NET Lab4
Author: Lindsay
Date:July, 2018*/

namespace IncidentsService
{
    public static class IncidentDB
    {
        //Only incidents that have DateClosed null and matching TechID are returned
        public static List<Incident> GetOpenTechIncidents(int techID)
        {
            List<Incident> incidents = new List<Incident>(); //empty list
            Incident inci = null; //reference for reading
            //define conncetion
            SqlConnection conn = TechSupportDB.GetConnection();

            //define the select query command
            string selectQuery = "SELECT IncidentID, CustomerID, ProductCode, TechID, DateOpened, DateClosed, Title, Description " +
                                 "FROM Incidents " +
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
                    inci.CustomerID = (int)dr["CustomerID"];
                    inci.ProductCode = (string)dr["ProductCode"];
                    inci.TechID = (int)dr["TechID"];
                    inci.DateOpened = (DateTime)dr["DateOpened"];
                    inci.DateClosed = dr["DateClosed"] as DateTime?;
                    inci.Title = (string)dr["Title"];
                    inci.Description = (string)dr["Description"];
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

        //All incidents with matching CustomerID are returned. 
        public static List<Incident> GetCustomerIncidents(int customerID)
        {
            List<Incident> incidents = new List<Incident>(); //empty list
            Incident inci = null; //reference for reading
            //define conncetion
            SqlConnection conn = TechSupportDB.GetConnection();

            //define the select query command
            string selectQuery = "SELECT IncidentID, CustomerID, ProductCode, TechID, DateOpened, DateClosed, Title, Description " +
                                 "FROM Incidents " +
                                 "WHERE CustomerID = @CustomerID " +
                                 "ORDER BY DateOpened";
            SqlCommand selectCmd = new SqlCommand(selectQuery, conn);
            selectCmd.Parameters.AddWithValue("@CustomerID", customerID);
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
                    inci.CustomerID = (int)dr["CustomerID"];
                    inci.ProductCode = (string)dr["ProductCode"];
                    inci.TechID = dr["TechID"] as int?;
                    inci.DateOpened = (DateTime)dr["DateOpened"];
                    inci.DateClosed = dr["DateClosed"] as DateTime?;
                    inci.Title = (string)dr["Title"];
                    inci.Description = (string)dr["Description"];
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