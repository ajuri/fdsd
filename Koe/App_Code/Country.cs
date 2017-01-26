using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Country
/// </summary>
public class Country
{
    private string name;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    private string headOfState;

    public string HeadOfState
    {
        get { return headOfState; }
        set { headOfState = value; }
    }

    private int population;

    public int Population
    {
        get { return population; }
        set { population = value; }
    }

    private string continent;

    public string Continent
    {
        get { return continent; }
        set { continent = value; }
    }

    private string localName;

    public string LocalName
    {
        get { return localName; }
        set { localName = value; }
    }

    private double? lifeExpectancy;

    public double? LifeExpectancy
    {
        get { return lifeExpectancy; }
        set { lifeExpectancy = value; }
    }




    public Country()
    {
      

    }

    public Country(int popul, string nimi, string manner, string paiknimi, string johtaja, double? expectancy)
    {
        population = popul;
        name = nimi;
        continent = manner;
        localName = paiknimi;
        headOfState = johtaja;
        lifeExpectancy = expectancy;
    }
}