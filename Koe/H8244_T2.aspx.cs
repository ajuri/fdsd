using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;

public partial class H8244_T2 : System.Web.UI.Page
{
    List<Country> countries;
    protected void Page_Load(object sender, EventArgs e)
    {
        GetXmlNodeList();
        BindData(countries);
    }

    protected void BindData(List<Country> data)
    {
        lblPopulation.Text = "" + SumPopulations(data);
        lblCountryCount.Text = "" + data.Count;
        gvCountries.DataSource = null;
        gvCountries.DataSource = data;
        gvCountries.DataBind();
    }

    protected List<Country> SortTenBiggestPopulations(List<Country> data)
    {
        List<Country> ordered = data.OrderByDescending(o => o.Population).ToList();
        return ordered.Take(10).ToList();
    }

    protected List<Country> SortFiveByLifeExcpectancy(List<Country> data)
    {
        List<Country> ordered = data.OrderBy(o => o.LifeExpectancy).ToList();
        return ordered.Take(5).ToList();
    }
    
    protected long SumPopulations(List<Country> data)
    {
        long sum = 0;
        foreach(Country row in data)
        {
            sum += row.Population;
        }
        return sum;
    }

    protected List<Country> FindCountryByName(List<Country> data, string queryString)
    {
        return data.Where(c => c.Name.ToLower().Contains(queryString)).ToList();
    }
    
    protected void GetXmlNodeList()
    {
        XmlDocument xdoc = new XmlDocument();
        xdoc.Load(Server.MapPath(WebConfigurationManager.AppSettings["maat"]));
        XmlNodeList temp = xdoc.SelectNodes("//DATA/ROW");
        string name;
        string headofstate;
        string localname;
        string continent;
        int population;
        double? lifeexpectancy;
        countries = new List<Country>();
        foreach(XmlNode country in temp)
        {
            name = country.SelectSingleNode("Name").InnerText;
            headofstate = country.SelectSingleNode("HeadOfState").InnerText;
            localname = country.SelectSingleNode("LocalName").InnerText;
            continent = country.SelectSingleNode("Continent").InnerText;
            population = Int32.Parse(country.SelectSingleNode("Population").InnerText);
            double result;
            if(Double.TryParse(country.SelectSingleNode("LifeExpectancy").InnerText, out result))
            {
                lifeexpectancy = result;
            }   
            else
            {
                lifeexpectancy = null;
            }
            countries.Add(new Country(population, name, continent, localname, headofstate, lifeexpectancy));
        }
    }

    protected void btnGetBiggestCountriesByPopulation_Click(object sender, EventArgs e)
    {
        BindData(SortTenBiggestPopulations(countries));
    }

    protected void btnGetCountriesByLifeExpectancy_Click(object sender, EventArgs e)
    {
        BindData(SortFiveByLifeExcpectancy(countries));
    }


    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BindData(FindCountryByName(countries, tbSearch.Text));
    }
}