using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BloodCheck
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public string getInventoryDetails()
        {
            string htmlText = "<table>";
            DataTable dataTable = new DataTable();
            string conString = ConfigurationManager.ConnectionStrings["BloodBankConnection"].ConnectionString;
            SqlConnection conn = new SqlConnection(conString);
            SqlCommand cmd = new SqlCommand("Select * from BloodUnits", conn);
            conn.Open();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            dataAdapter.Fill(dataTable);
            conn.Close();

            foreach(DataRow row in dataTable.Rows)
            {
                string divClass = "";
                if ((int)row["AvailableUnits"] >= 999)
                    divClass = "fullDiv";
                else if ((int)row["AvailableUnits"] >= 499)
                    divClass = "partialDiv";
                else
                    divClass = "emptyDiv";

                    htmlText += "<tr><td>";
                htmlText += "<div class='"+ divClass +"'> <h4><b>"+row["BloodType"]+"<b> <h4> </div>";
                htmlText += "</td></tr>";       
            }

            return htmlText + "</table>";
        }

        public string getNotifications()
        {
            string htmlText = "<p>";
            DataTable dataTable = new DataTable();
            string conString = ConfigurationManager.ConnectionStrings["BloodBankConnection"].ConnectionString;
            SqlConnection conn = new SqlConnection(conString);
            SqlCommand cmd = new SqlCommand("Select * from BloodUnits", conn);
            conn.Open();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            dataAdapter.Fill(dataTable);
            conn.Close();

            foreach (DataRow row in dataTable.Rows)
            {
                if((int)row["RequestNeeded"] ==1 && (int)row["RequestMade"] == 0)
                {
                    htmlText += "<b>" + row["BloodType"] + "</b> blood is low, please place a request!<br /><br />";
                    htmlText += "<p> ";
                }
            }

            return htmlText + "</p>";
        }
    }
}