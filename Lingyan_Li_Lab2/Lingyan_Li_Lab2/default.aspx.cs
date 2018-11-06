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
    public partial class _default : System.Web.UI.Page
    {
        DateTime firstSat = new DateTime(); // the next Saturday
        int[] counter = { 0, 0, 0 }; // the counters of selection for the three upcoming Saturday
        string[] count = { "count1", "count2", "count3" }; // the names of the application states

        protected void Page_Load(object sender, EventArgs e)
        {
            btnSubmit.Enabled = false;
            DateTime current = DateTime.Today; // get the date of today            

            if (current.DayOfWeek == DayOfWeek.Saturday) //if today is Saturday
                firstSat = current.AddDays(7); // the next Saturday is after 7 days today
            else
            {
                do
                {
                    current = current.AddDays(1); // go to the next day
                } while (current.DayOfWeek != DayOfWeek.Saturday); //until the day is Saturday, break the loop
                firstSat = current.Date; //assign the date to the firstSat
            }

            Calendar1.SelectedDates.Clear(); //make the SelectedDates empty
            //adds the three upcoming saturdays in the selectedDates and highlights them
            for (int i=0; i<3; i++) 
            {
                Calendar1.SelectedDates.Add(firstSat.AddDays(7*i));
            }  
            Calendar1.SelectedDayStyle.BackColor = System.Drawing.Color.White;
            Calendar1.SelectedDayStyle.ForeColor = System.Drawing.Color.Black;
        }

        //render the calendar, make un-selectable dates to be “grayed out”
        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            if ((e.Day.Date != firstSat) && (e.Day.Date != firstSat.AddDays(7)) && (e.Day.Date != firstSat.AddDays(7*2)))
            {
                e.Cell.BackColor = System.Drawing.Color.LightGray;
                e.Cell.ForeColor = System.Drawing.Color.DarkGray;
            }
        }

        //once user selects a date
        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            //The current date selection is confirmed in a label
            lblPickedDate.Text = Calendar1.SelectedDate.ToShortDateString();

            //highlights the current date selection
            Calendar1.SelectedDayStyle.BackColor = System.Drawing.Color.Orange;
            Calendar1.SelectedDayStyle.ForeColor = System.Drawing.Color.White;

            //if user makes a selection out of the three upcoming Saturdays or not
            if ((lblPickedDate.Text != firstSat.Date.ToShortDateString()) &&
                (lblPickedDate.Text != firstSat.AddDays(7).Date.ToShortDateString()) &&
                (lblPickedDate.Text != firstSat.AddDays(7 * 2).Date.ToShortDateString()))
            {
                lblMessage.Text = "Please select a date in the three upcoming Saturdays";
            }
            else
            {
                btnSubmit.Enabled = true; //let user be able to click submit button
                lblMessage.Text = ""; //clear the error message
            }

        }

        //once  user clicks the submit button
        protected void btnSubmit_Click(object sender, EventArgs e)
        { 
            Application.Lock(); //lock before changing shared data
            for (int i = 0; i < 3; i++)
            {
                if (Application[count[i]] != null)// if it is in the application state
                    counter[i] = Convert.ToInt32(Application[count[i]]); 
            }

            //check which Saturday is selected and add one vote to the relative counter of the selection
            for (int i = 0; i < 3; i++)
            {               
                if (lblPickedDate.Text == firstSat.AddDays(7 * i).Date.ToShortDateString())
                {
                    counter[i]++;
                    break;
                }
            }

            //update the application state(in order to transfer the records to the second page for multi-user)
            for (int i = 0; i < 3; i++)
            {
                Application[count[i]] = counter[i];
            }

            Application.UnLock(); // release the lock

            Response.Redirect("~/result.aspx", false); //go to the result page
        }       
    }
}