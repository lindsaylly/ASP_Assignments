using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

//Purpose: ASP.NET Lab3
//Author: Lindsay
//Date:July, 2018

namespace Lingyan_Li_Lab3
{
    [DataObject(true)]
    public static class TechnicianDB
    {
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List<Technician> GetAllTechnicians()
        {
            List<Technician> technicians = new List<Technician>(); //empty the list
            Technician tech = null; // reference for reading
            //define connection
            SqlConnection conn = TechSupportDB.GetConnection();

            // define the select query command
            string selectQuery = "SELECT TechID, Name, Email, Phone " +
                                 "FROM Technicians " +
                                 "ORDER BY Name";
            SqlCommand selectCmd = new SqlCommand(selectQuery, conn);

            try
            {
                //open the connection
                conn.Open();

                //execute the query
                SqlDataReader dr = selectCmd.ExecuteReader(); // can be multiple records

                //process the results
                while (dr.Read()) //while there are technicians
                {
                    tech = new Technician();
                    tech.TechID = (int)dr["TechID"];
                    tech.Name = (string)dr["Name"];
                    tech.Email = (string)dr["Email"];
                    tech.Phone = (string)dr["Phone"];
                    technicians.Add(tech);
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

            return technicians;
        }


    }
}