using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

public partial class H8244_T4b : System.Web.UI.Page
{    
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            GetEntries();
            BindData(Session["entries"] as List<Entry>);
            FillControls();
        }        
    }

    protected void BindData(List<Entry> data)
    {
        lblCount.Text = "" + data.Count;
        lblHours.Text = "" + CountHours(data);
        Session["tempentries"] = data;
        gvEntries.DataSource = null;
        gvEntries.DataSource = data;
        gvEntries.DataBind();
    }

    protected bool ValidateInput()
    {
        return true;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {

        XmlDocument xmldoc = new XmlDocument();
        xmldoc.Load(Server.MapPath("~/entries.xml"));
        XmlElement root = xmldoc.DocumentElement;
        XmlElement entry = xmldoc.CreateElement("entry");
        XmlElement date = xmldoc.CreateElement("date");
        XmlElement hours = xmldoc.CreateElement("hours");
        XmlElement name = xmldoc.CreateElement("name");
        date.InnerText = tbDate.Text;
        hours.InnerText = tbHours.Text;
        name.InnerText = tbName.Text;
        entry.AppendChild(date);
        entry.AppendChild(hours);
        entry.AppendChild(name);
        root.AppendChild(entry);
        xmldoc.Save(Server.MapPath("~/entries.xml"));

        GetEntries();
        FillControls();
        BindData(Session["entries"] as List<Entry>);
    }

    protected int CountHours(List<Entry> data)
    {
        return data.Sum(e => e.Hours);
    }

    protected List<Entry> SortEntriesByDate(List<Entry> data)
    {
        try
        {
            return data.OrderByDescending(e => e.Date).ToList();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        
    }

    protected void GetEntries()
    {
        try
        {
            if(File.Exists(Server.MapPath("~/entries.xml")))
            {
                List<Entry> entries = new List<Entry>();
                XmlDocument data = new XmlDocument();
                data.Load(Server.MapPath("~/entries.xml"));
                XmlNodeList temp = data.SelectNodes("//entries/entry");
                string name;
                int hours;
                string date;

                foreach (XmlNode entry in temp)
                {
                    name = entry.SelectSingleNode("name").InnerText;
                    hours = Int32.Parse(entry.SelectSingleNode("hours").InnerText);
                    date = entry.SelectSingleNode("date").InnerText;
                    entries.Add(new Entry(hours, date, name));
                }
                Session["entries"] = entries;
                Session["tempentries"] = entries;
            }
            else
            {
                XmlDocument xmldoc = new XmlDocument();
                XmlElement root = xmldoc.CreateElement("entries");
                xmldoc.AppendChild(root);
                xmldoc.Save(Server.MapPath("~/entries.xml"));
                Session["entries"] = new List<Entry>();
            }   
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void btnSortButton_Click(object sender, EventArgs e)
    {
        List<Entry> entries = (Session["tempentries"] as List<Entry>);
        List<Entry> result = SortEntriesByDate(entries);
        BindData(result);
    }

    protected List<Entry> SearchByName(List<Entry> data, string name)
    {
        try
        {
            return data.Where(e => e.Name == name).ToList();
        }
        catch (Exception ex)
        {
            throw ex;
        }        
    }

    protected void FillControls()
    {
        try
        {
            List<Entry> entries = (Session["entries"] as List<Entry>);
            var names = entries.Select(e => e.Name).Distinct().ToList();
            ddlName.DataSource = names;
            ddlName.DataBind();
            tbDate.Text = DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void btnSearchByName_Click(object sender, EventArgs e)
    {
        try
        {
            List<Entry> result = SearchByName((Session["entries"] as List<Entry>), ddlName.SelectedValue);
            BindData(result);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void btnGetEntries_Click(object sender, EventArgs e)
    {
        BindData(Session["entries"] as List<Entry>);
    }
}