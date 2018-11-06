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
    [ServiceContract]
    public interface IIncidentsService
    {
        [OperationContract]
        List<Customer> GetCustomers();

        [OperationContract]
        List<Incident> GetOpenTechIncidents(int techID);

        [OperationContract]
        List<Incident> GetCustomerIncidents(int customerID);

    }

    [DataContract]
    public class Incident
    {
        [DataMember]
        public int IncidentID { get; set; }
        [DataMember]
        public int CustomerID { get; set; }
        [DataMember]
        public string ProductCode { get; set; }
        [DataMember]
        public int? TechID { get; set; }
        [DataMember]
        public DateTime DateOpened { get; set; }
        [DataMember]
        public DateTime? DateClosed { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string Description { get; set; }

    }

    [DataContract]
    public class Customer
    {
        [DataMember]
        public int CustomerID { get; set; }
    }

}
