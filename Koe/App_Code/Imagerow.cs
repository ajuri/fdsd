using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Imagerow
/// </summary>
public class Imagerow
{
    private string filename;

    public string Filename
    {
        get { return filename; }
        set { filename = value; }
    }

    private string filepath;

    public string Filepath
    {
        get { return filepath; }
        set { filepath = value; }
    }

    public Imagerow()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public Imagerow(string name, string path)
    {
        filename = name;
        filepath = path;
    }
}