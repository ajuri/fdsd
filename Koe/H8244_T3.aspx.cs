using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

public partial class H8244_T3 : System.Web.UI.Page
{
    DataView asiakkaat;
    DataView tables;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            int result = TestConnection();
            lblHelp.Text = "Yhteys kantaan muodostettu onnistuneesti! " + result + " tietuetta luettu.";
            GetTables();
            gvTest.DataSource = tables;
            gvTest.DataBind();
        }
        catch (Exception ex)
        {
            lblError.Text = "Yhteyden muodostaminen epäonnistui. " + ex.Message;
        }        
    }

    protected void FillCountrySelector()
    {
        // TOIMIIKO?
        var result = asiakkaat.ToTable(true, "maa");
        ddlCountrySelect.DataSource = result;
        ddlCountrySelect.DataBind();
    }

    protected void GetTables()
    {
        using (SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["DemoxOyConnectionString"].ConnectionString))
        {
            conn.Open();
            string queryString = "SHOW DATABASES;";
            SqlCommand cmd = new SqlCommand(queryString, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            DataView dv = new DataView(dt);
            tables = dv;
        }
    }

    protected void GetCustomerData()
    {        
        
        try
        {
            using (SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["DemoxOyConnectionString"].ConnectionString))
            {                
                conn.Open();
                string queryString = "SELECT * FROM asiakas ORDERBY asnimi ASC;";
                SqlCommand cmd = new SqlCommand(queryString, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conn.Close();
                DataView dv = new DataView(dt);                
                asiakkaat = dv;
            }           
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected int TestConnection()
    {
        int result;
        try
        {           
            using (SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["DemoxOyConnectionString"].ConnectionString))
            {
                conn.Open();
                string queryString = "SELECT * FROM asiakas;";
                SqlCommand cmd = new SqlCommand(queryString, conn);
                result = cmd.ExecuteNonQuery();
                conn.Close();
            }

            return result;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void btnGetCustomerData_Click(object sender, EventArgs e)
    {
        try
        {
            GetCustomerData();
            gvCustomers.DataSource = asiakkaat;
            gvCustomers.DataBind();
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
}