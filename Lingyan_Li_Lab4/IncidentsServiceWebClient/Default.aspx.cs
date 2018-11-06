using IncidentsServiceWebClient.IncidentsServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/*Purpose: ASP.NET Lab4
Author: Lindsay
Date:July, 2018*/

namespace IncidentsServiceWebClient
{
    public partial class Default : System.Web.UI.Page
    {
        // create proxy object for the WCF service
        IncidentsServiceClient proxy =  new IncidentsServiceClient();

        Customer[] customers;
        Incident[] incidents;
        Customer cust;

        // populate drop down list when page loads first time
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) // first time
            {
                // load the combo box
                customers = proxy.GetCustomers();
                Session["cust"] = customers;
                ddlCustomers.DataSource = customers;
                ddlCustomers.DataTextField = "CustomerID";
                ddlCustomers.DataValueField = "CustomerID";
                ddlCustomers.DataBind();                
            }
            else // retrieve from session
            {
                customers = (Customer[])Session["cust"];
            }
            DisplayIncidents(0);
        }

        // display details of the selected customer's incident
        protected void ddlCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayIncidents(ddlCustomers.SelectedIndex);            
        }

        private void DisplayIncidents(int index)
        {
            cust = customers[index]; // selected customer
            incidents = proxy.GetCustomerIncidents(cust.CustomerID);
            gvIncident.DataSource = incidents;
            gvIncident.DataBind();
        }
    }
}