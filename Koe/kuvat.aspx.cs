using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class kuvat : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            FillControls();

        }

    }

    protected void FillControls()
    {
        string[] filepaths = Directory.GetFiles(Server.MapPath("~/pictures/"));
        List<Imagerow> imagerows = new List<Imagerow>();
        Imagerow imagerow;
        string[] split;
        string filename;
        char dashSeparator = @"\"[0];

        foreach (string filepath in filepaths)
        {
            split = filepath.Split(dashSeparator);
            filename = split[split.Count() - 1];
            imagerow = new Imagerow();
            imagerow.Filename = filename;
            imagerow.Filepath = Server.MapPath("~/pictures/" + filename);
            imagerows.Add(imagerow);
        }

        gvPics.DataSource = imagerows;
        gvPics.DataBind();
    }

    protected void gvPics_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        imgBig.ImageUrl = "~/pictures/" + e.CommandArgument.ToString();
    }
}