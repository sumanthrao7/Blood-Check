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
    public partial class Manage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dataTable = new DataTable();
                string conString = ConfigurationManager.ConnectionStrings["BloodBankConnection"].ConnectionString;
                SqlConnection conn = new SqlConnection(conString);
                SqlCommand cmd = new SqlCommand("Select * from BloodUnits", conn);
                conn.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                dataAdapter.Fill(dataTable);
                conn.Close();

                ddlList.DataSource = dataTable;
                ddlList.DataTextField = "BloodType";
                ddlList.DataValueField = "Id";
                ddlList.DataBind();
            }

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
                if ((int)row["RequestNeeded"] == 1 && (int)row["RequestMade"] == 0)
                {
                    htmlText += "<b>" + row["BloodType"] + "</b> blood is low, please place a request!<br /><br />";
                    htmlText += "<p> ";
                }
            }

            return htmlText + "</p>";
        }

        protected void ddlList_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();
            string conString = ConfigurationManager.ConnectionStrings["BloodBankConnection"].ConnectionString;
            SqlConnection conn = new SqlConnection(conString);
            SqlCommand cmd = new SqlCommand("Select * from BloodUnits where id='"+ddlList.SelectedValue+"'", conn);
            conn.Open();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            dataAdapter.Fill(dataTable);
            conn.Close();
            lblAvailable.Text = dataTable.Rows[0]["AvailableUnits"].ToString();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string conString = ConfigurationManager.ConnectionStrings["BloodBankConnection"].ConnectionString;
            SqlConnection conn = new SqlConnection(conString);
            SqlCommand cmd = new SqlCommand("Update BloodUnits set availableunits =  availableunits + "+ txtNewUnits.Text +" , requestneeded=0 where id='" + ddlList.SelectedValue + "'", conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            Response.Redirect("Manage.aspx");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int currentValue = 0;
            if(lblAvailable.Text != "")
            {
                currentValue = Convert.ToInt32(lblAvailable.Text);
            }
            int newValue = currentValue - Convert.ToInt32(txtNewUnits.Text);
            int requestNeeded = 0; 
            if(newValue < 498)
            {
                requestNeeded = 1;
            }

            string conString = ConfigurationManager.ConnectionStrings["BloodBankConnection"].ConnectionString;
            SqlConnection conn = new SqlConnection(conString);
            SqlCommand cmd = new SqlCommand("Update BloodUnits set availableunits = "+ newValue + ", requestneeded="+requestNeeded + ", requestMade=0 where id='" + ddlList.SelectedValue + "'", conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            Response.Redirect("Manage.aspx");
        }
    }
}