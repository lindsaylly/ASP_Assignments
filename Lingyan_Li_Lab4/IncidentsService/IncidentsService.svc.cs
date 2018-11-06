using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

/*Purpose: ASP.NET Lab4
Author: Lindsay
Date:July, 2018*/

namespace IncidentsService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "IncidentsService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select IncidentsService.svc or IncidentsService.svc.cs at the Solution Explorer and start debugging.
    public class IncidentsService : IIncidentsService
    {
        public List<Customer> GetCustomers()
        {
            return CustomerDB.GetCustomers();
        }

        public List<Incident> GetCustomerIncidents(int customerID)
        {
            return IncidentDB.GetCustomerIncidents(customerID);
        }

        public List<Incident> GetOpenTechIncidents(int techID)
        {
            return IncidentDB.GetOpenTechIncidents(techID);
        }
    }
}
