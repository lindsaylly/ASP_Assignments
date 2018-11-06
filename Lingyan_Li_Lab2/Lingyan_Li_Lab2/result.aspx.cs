using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/*
 * Purpose: ASP.NET Lab2(a website that allows users voting on a preferred date for a party)
 * Author: Lindsay
 * Date:July, 2018 
 */

namespace Lingyan_Li_Lab2
{
    public partial class result : System.Web.UI.Page
    {
        int[] counter = { 0, 0, 0 }; // initialize the local counters
        string[] count = { "count1", "count2", "count3" }; //declare the application objects' names

        protected void Page_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                if (Application[count[i]] != null) // if it is in the application state
                    counter[i] = (int)Application[count[i]]; // transfer the value to the current page
            }
            //display the tally of votes
            txtDay1.Text = counter[0].ToString();
            txtDay2.Text = counter[1].ToString();
            txtDay3.Text = counter[2].ToString();           
        }

        //once user click the return button
        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/default.aspx", false); //go to the default page
        }
    }
}