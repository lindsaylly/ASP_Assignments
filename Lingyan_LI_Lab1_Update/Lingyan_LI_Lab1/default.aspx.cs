using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/*
 * Purpose: ASP.NET Lab1
 * Author: Lindsay
 * Date:July, 2018 
 */
namespace Lingyan_LI_Lab1
{
    public partial class _default : System.Web.UI.Page
    {
        //default conversion is from Celsius to Fahrenheit 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) //happens on the first loading
            {
                ddlFrom.SelectedIndex = 0;
                ddlTo.SelectedIndex = 0;

            }
        }

        protected void btnConvert_Click(object sender, EventArgs e)
        {
            decimal input = Convert.ToDecimal(txtInput.Text); // get the input
            decimal result = 0m; // the result of conversion
            
            switch (ddlFrom.SelectedValue) // whick kind of teperature is converted
            {
                case "Celsius":                 
                    if (ddlTo.SelectedValue == "Fahrenheit") result = input * (9m / 5m) + 32m;
                    else if (ddlTo.SelectedValue== "Kelvin") result = input + 273.15m;
                    else result = input;
                    break;
                case "Fahrenheit":
                    if (ddlTo.SelectedValue == "Celsius") result = (input - 32m) * (5m / 9m);
                    else if (ddlTo.SelectedItem.Value == "Kelvin") result = (input - 32m) * 5m / 9m + 273.15m;
                    else result = input;
                    break;
                case "Kelvin":
                    if (ddlTo.SelectedValue == "Celsius") result = input - 273.15m;
                    else if (ddlTo.SelectedValue == "Fahrenheit") result = (input - 273.15m) * 9m / 5m + 32m;
                    else result = input;
                    break;
            }
            txtOutput.Text = result.ToString("0.00"); // rounds to 2 decimal positons
        }

        // reset controls as default status
        protected void btnClear_Click(object sender, EventArgs e)
        {
             ddlFrom.SelectedIndex = 0;
             ddlTo.SelectedIndex = 0;
            txtInput.Text = "";
            txtOutput.Text = "";          
        }
    }
}