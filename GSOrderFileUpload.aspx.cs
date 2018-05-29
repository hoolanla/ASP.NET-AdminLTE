using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class customs_code_GSOrderFileUpload : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["USER"] == null)
        {
            Response.Redirect("Authorize.aspx");
        }

        String gsorderid = null, gsorderno = null;
        HttpPostedFile postedFile = Request.Files["fUpload"];
        gsorderid = Request.Form["gsorderid"];
        gsorderno = Request.Form["gsorderno"];
        string uploaddir = "~/uploads/GSOrder/" + gsorderno + "/";


        //Check if File is available.
        if (postedFile != null && postedFile.ContentLength > 0)
        {
            //Save the File.
            string filePath = Server.MapPath(uploaddir) + Path.GetFileName(postedFile.FileName);
            postedFile.SaveAs(filePath);

            MODEL.GSOrderFile criteria = new MODEL.GSOrderFile();

            criteria.File_Name = Path.GetFileName(postedFile.FileName);
            criteria.GsOrderID = gsorderid;
            criteria.Createdby = "1";
            BLL.GSOrderFile _BLL = new BLL.GSOrderFile();
            _BLL.Insert_GSOrderFile(criteria);


            StringBuilder html = new StringBuilder();
            html.Append("<br><i class=\"fa fa-check-square-o\"></i>&nbsp;Your file (" + postedFile.FileName  + ") was uploaded successfully.");
            html.Append("<BR><input type=\"button\" value=\"Back\" onclick=\"window.history.go(-1);\" class=\"ui-button ui-widget ui-corner-all\">");

            ContentPlaceHolder cph;
            cph = (ContentPlaceHolder)Master.FindControl("ContentPlaceHolder1");
            cph.Controls.Add(new Literal { Text = html.ToString() });
        }


    }
}