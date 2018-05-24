using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class customs_code_OpenRTNFile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string filePath = null;
        HttpPostedFile postedFile = Request.Files["rtnFile"];

        if (postedFile != null && postedFile.ContentLength > 0)
        {
            //Save the File.
            //   string filePath = Server.MapPath(uploaddir) + Path.GetFileName(postedFile.FileName);
           filePath = postedFile.FileName;
        }


            StreamReader StrWer;
        try
        {
            StrWer = File.OpenText(filePath);
            while (!(StrWer.EndOfStream))
            {
                this.lblText.Text = this.lblText.Text + StrWer.ReadLine() + "<br>";
            }
            StrWer.Close();
        }
        catch (Exception ex)
        {
            this.lblText.Text = "Read failed. (" + ex.Message + ")";
        }


    }
}