using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class customs_code_GSOrderFile : System.Web.UI.Page
{

    DataTable dtTop, dtBottom;

    String GSOrderID = null;
    String GSOrderNO = null;


    protected void Page_Load(object sender, EventArgs e)
    {

         GSOrderID = Request.QueryString["id"];
         GSOrderNO = Request.QueryString["no"];
        dtTop = GetDataTop(GSOrderID);

        StringBuilder html = new StringBuilder();


        html.Append("<Table width=80% class='table table-hover'>");
        html.Append("<THEAD><TR>");
        html.Append("<th>No.</th>");
        html.Append("<th>File name</th>");
        html.Append("<th>Created by</th>");
        html.Append("<th>Created date</th>");
        html.Append("<th></th>");
        html.Append("</TR></THEAD>");
        html.Append("<TBody>");

        if(dtTop.Rows.Count > 0 )
        {

            String rwId=null,rwFileName=null,rwCreatedBy=null,rwCreatedDate=null;
            
            for(int i = 0;i < dtTop.Rows.Count;i++)
            {
                rwId = dtTop.Rows[i]["ID"].ToString();
                rwFileName = dtTop.Rows[i]["File_Name"].ToString();
                rwCreatedBy = dtTop.Rows[i]["CreatedBy"].ToString();
                rwCreatedBy = dtTop.Rows[i]["CreatedDate"].ToString();

                html.Append("<tr>");
                html.Append("<td>" + (i+1) + "</td>");
                html.Append("<td><a href='./uploads/GSOrder/" + GSOrderNO + "/" + rwFileName + "' target='_blank'>" + rwFileName + "</a></td>");
                html.Append("<td>" + rwCreatedBy +"</td>");
                html.Append("<td>"+ rwCreatedDate +"</td>");
                html.Append("<td><a href='#' class='ui-button ui-widget ui-corner-all'>Delete</a></td>");
                html.Append("</tr>");
            }

            html.Append("</TBody>");
            html.Append("</Table>");
        }


        html.Append("<BR>");
        html.Append("<input type= \"button\" value= \"Back\" onclick= \"window.history.go(-1);\" class= \"ui-button ui-widget ui-corner-all\">");
        html.Append("&nbsp;<input type= \"button\" name= \"btnFile\" id= \"btnFile\" value= \"Upload new file\">");




        html.Append("<div id= \"dialog-form\" title= \"Create new Message\">");
        html.Append("<p class= \"validateTips\">Please select your file for upload.</p>");
        html.Append("<form id= \"frmFile\" action= \"./gsorderfileupload.aspx\" method= \"post\" enctype= \"multipart/form-data\">");
        html.Append("<fieldset>");
        html.Append("<table class= \"tableclass\">");
        html.Append("<tbody>");
        html.Append("<tr id= \"hiddenSet\" name= \"hiddenSet\">");
        html.Append("<td>");
        html.Append("<input type= \"hidden\" name= \"gsorderid\" id= \"gsorderid\" value= \"" + GSOrderID + "\">");
        html.Append("<input type= \"hidden\" name= \"gsorderno\" id= \"gsorderno\" value= \"" + GSOrderNO + "\">");
        html.Append("</td>");
        html.Append("</tr>");
        html.Append("<tr>");
        html.Append("<td>");
        html.Append("<label for= \"msgdetail\">File attachment</label>");
        html.Append("</td>");
        html.Append("</tr>");
        html.Append("<tr>");
        html.Append("<td>");
        html.Append("<input type= \"file\" name= \"fUpload\" id= \"fUpload\" >");
        html.Append("</td>");
        html.Append("</tr>");
        html.Append("<tr>");
        html.Append("<td><p id= \"textarea_feedback\" ></p></ td >");
        html.Append("</tr>");
        html.Append("</tbody>");
        html.Append("</table>");
        html.Append("</fieldset>");
        html.Append("</form>");
        html.Append("</div>");


        ContentPlaceHolder cph;
        cph = (ContentPlaceHolder)Master.FindControl("ContentPlaceHolder1");
        cph.Controls.Add(new Literal { Text = html.ToString() });




    }


    private DataTable GetDataTop(String GSOrderID)
    {
        DataTable dt = null;
        BLL.GSOrderFile _BLL = new BLL.GSOrderFile();
        dt = _BLL.getGSOrderFile(GSOrderID);
        return dt;
    }

}