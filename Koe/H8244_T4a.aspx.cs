using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

public partial class H8244_T4a : System.Web.UI.Page
{
    
   // List<Record> tempRecords;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {            
            if (!IsPostBack)
            {
                GetRecords();
                GetCountries();
                BindData(Session["records"] as List<Record>);
            }    
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void BindData(List<Record> data)
    {
        try
        {
            Session["temprecords"] = data;
            lblCount.Text = "" + data.Count;
            gvRecords.DataSource = null;
            gvRecords.DataSource = data;
            gvRecords.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }        
    }

    protected void GetCountries()
    {
        try
        {
            List<Record> records = (Session["records"] as List<Record>);
            var countries = records.Select(e => e.Country).Distinct().ToList();
            ddlCountry.DataSource = countries;
            ddlCountry.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }       
    }

    protected void GetRecords()
    {
        try
        {
            List<Record> records = new List<Record>();
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(Server.MapPath(WebConfigurationManager.AppSettings["levyt"]));
            XmlNodeList temp = xdoc.SelectNodes("//catalog/record");
            string title;
            string artist;
            string country;
            string year;
            int price;

            foreach (XmlNode record in temp)
            {
                title = record.SelectSingleNode("title").InnerText;
                artist = record.SelectSingleNode("artist").InnerText;
                country = record.SelectSingleNode("country").InnerText;
                year = record.SelectSingleNode("year").InnerText;
                price = Int32.Parse(record.SelectSingleNode("value").InnerText);
                records.Add(new Record(title, artist, country, year, price));
            }
            Session["records"] = records;
            Session["temprecords"] = records;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected List<Record> GetRecordsByCountry(List<Record> data, string country)
    {
        try
        {
            return (from record in data where record.Country == country select record).ToList();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        
    }

    protected List<Record> SortByArtist(List<Record> data)
    {
        try
        {
            return data.OrderBy(o => o.Artist).ToList();
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    protected void btnOrderByArtist_Click(object sender, EventArgs e)
    {
        try
        {
            List<Record> records = (Session["temprecords"] as List<Record>);
            List<Record> recordsByArtist = SortByArtist(records);
            BindData(recordsByArtist);
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }       
    }

    protected void btnGetRecordByCountry_Click(object sender, EventArgs e)
    {
        try
        {
            List<Record> records = (Session["records"] as List<Record>);
            string country = ddlCountry.SelectedItem.Value;
            List<Record> recordsByCountry = GetRecordsByCountry(records, country);
            BindData(recordsByCountry);
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void btnGetAllRecords_Click(object sender, EventArgs e)
    {
        try
        {
            BindData(Session["records"] as List<Record>);
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }        
    }
}