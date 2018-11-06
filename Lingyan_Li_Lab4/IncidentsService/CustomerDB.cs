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
    public static class CustomerDB
    {
        // Only customers that have at least one incident are returned
        public static List<Customer> GetCustomers()
        {
            List<Customer> customers = new List<Customer>(); //empty list
            Customer cust = null; //reference for reading
            //define conncetion
            SqlConnection conn = TechSupportDB.GetConnection();

            //define the select query command
            string selectQuery = "SELECT DISTINCT CustomerID " +
                                 "FROM Incidents ORDER BY CustomerID";
            SqlCommand cmd = new SqlCommand(selectQuery, conn);

            try
            {
                //open the connection
                conn.Open();

                //execute the query
                SqlDataReader dr = cmd.ExecuteReader(); // can be multiple records

                //process the results
                while (dr.Read()) //while there are customers
                {
                    cust = new Customer();
                    cust.CustomerID = (int)dr["CustomerID"];
                    customers.Add(cust);
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
            return customers;
        }
    }
}