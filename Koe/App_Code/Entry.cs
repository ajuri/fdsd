using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Entry
/// </summary>
public class Entry
{

    private int hours;

    public int Hours
    {
        get { return hours; }
        set { hours = value; }
    }

    private string date;

    public string Date
    {
        get { return date; }
        set { date = value; }
    }

    private string name;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }


    public Entry()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public Entry(int h, string d, string n)
    {
        hours = h;
        date = d;
        name = n;
    }
}