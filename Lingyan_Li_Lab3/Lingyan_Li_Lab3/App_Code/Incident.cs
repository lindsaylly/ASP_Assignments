using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Purpose: ASP.NET Lab3
//Author: Lindsay
//Date:July, 2018

namespace Lingyan_Li_Lab3
{
    public class Incident
    {
        public Incident() { }
        public int IncidentID { get; set; }
        public int CustomerID { get; set; }
        public string ProductCode { get; set; }
        public int TechID { get; set; }
        public DateTime DateOpened { get; set; }
        public DateTime? DateClosed { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string CustomerName { get; set; }  //add the property for display instead of displaying customerID
    }
}
