using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Record
/// </summary>
public class Record
{
    private string title;

    public string Title
    {
        get { return title; }
        set { title = value; }
    }

    private string artist;

    public string Artist
    {
        get { return artist; }
        set { artist = value; }
    }

    private string country;

    public string Country
    {
        get { return country; }
        set { country = value; }
    }

    private string year;

    public string Year
    {
        get { return year; }
        set { year = value; }
    }

    private int price;

    public int Price
    {
        get { return price; }
        set { price = value; }
    }

    public Record(string title, string artist, string country, string year, int price)
    {
        this.title = title;
        this.artist = artist;
        this.country = country;
        this.year = year;
        this.price = price;
    }

    public Record()
    {
        
    }
}