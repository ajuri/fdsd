using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Customer
/// </summary>
public class Customer
{
    private string astunnus;

    public string Astunnus
    {
        get { return astunnus; }
        set { astunnus = value; }
    }

    private string asnimi;

    public string Asnimi
    {
        get { return asnimi; }
        set { asnimi = value; }
    }

    private string yhteyshlo;

    public string Yhteyshlo
    {
        get { return yhteyshlo; }
        set { yhteyshlo = value; }
    }

    private string maa;

    public string Maa
    {
        get { return maa; }
        set { maa = value; }
    }

    private string postinro;

    public string Postinro
    {
        get { return postinro; }
        set { postinro = value; }
    }

    private string postitmp;

    public string Postitmp
    {
        get { return postitmp; }
        set { postitmp = value; }
    }

    private int? ostot;

    public int? Ostot
    {
        get { return ostot; }
        set { ostot = value; }
    }

    private string asvuosi;

    public string Asvuosi
    {
        get { return asvuosi; }
        set { asvuosi = value; }
    }

    public Customer()
    {
        
    }

    public Customer(string tunnus, string nimi, string yhteyshenkilo, string asuinmaa, string postinumero, string postitoimipaikka, string vuosi, int? osto)
    {
        astunnus = tunnus;
        asnimi = nimi;
        yhteyshlo = yhteyshenkilo;
        maa = asuinmaa;
        postinro = postinumero;
        postitmp = postitoimipaikka;
        asvuosi = vuosi;
        ostot = osto;
    }
}