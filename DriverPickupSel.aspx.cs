using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class customs_code_DriverPickupSel : System.Web.UI.Page
{

    DataTable dtTop, dtBottom;

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["USER"] == null)
        {
            Response.Redirect("Authorize.aspx");
        }


        string broadcastSelect = Request.Form["checkId[]"];

        dtTop = GetDataTop(broadcastSelect);
        StringBuilder html = new StringBuilder();


        html.Append("<table class= \"table table - hover\">");
        html.Append("<thead>");
        html.Append("<tr>");
        html.Append("<th></th>");
        html.Append("<th>No.</th>");
        html.Append("<th>GS Order</th>");
        html.Append("<th>Goods</th>");
        html.Append("<th>Label</th>");
        html.Append("</tr>");
        html.Append("</thead>");
        html.Append("<tbody>");
        html.Append("<form id= \"form1\" name= \"form1\" method= \"post\" action= \"index.php?option=driverpickupsave\" >");

        if(dtTop.Rows.Count > 0)
        {

            
            String GSOrderNo=null,GSOrderId=null,Id=null,ProdName=null,Desc=null,ProdStatus = null;
		 String Status = "";

            for (int i = 0;i < dtTop.Rows.Count;i++)
                {
                GSOrderNo = dtTop.Rows[i]["GSOrderNo"].ToString();
                GSOrderId = dtTop.Rows[i]["GSOrderId"].ToString();
                Id = dtTop.Rows[i]["ID"].ToString();
                ProdName = dtTop.Rows[i]["ProductName"].ToString();
                Desc = dtTop.Rows[i]["Description"].ToString();
                ProdStatus = dtTop.Rows[i]["Status"].ToString();
            

                switch (ProdStatus) {
				case "0":
					Status = "0-Cancel";
                break;
				case "1":
					Status = "1-Open";
                break;
				case "2":
					Status = "2-Confirm";
                break;
				case "3":
					Status = "3-Pickup-Partial";
                break;
				case "4":
					Status = "4-Pickup";
                break;
				case "5":
					Status = "5-RDC receive-Partial";
                break;
				case "6":
					Status = "6-RDC received";
                break;
				case "7":
					Status = "7-CDC receive-Partial";
                break;
				case "8":
					Status = "8-CDC received";
                break;
				case "9":
					Status = "9-Completed";
                break;
            }
                html.Append("<tr>");
                html.Append("<td><input type= \"Hidden\" name= \"gsorderdetailid[]\" value= \"" + Id +"\"></td>");
                html.Append("<td>"+ (i+1) +"</td>");
                html.Append("<td>"+ GSOrderNo + "</td>");
                html.Append("<td>" + ProdName +"</td>");
                html.Append("<td>" + Desc + "</td>");
                html.Append("</tr>");


            }


            html.Append("<tr>");
            html.Append("<td><input type= \"hidden\" name= \"txtQty\" value= \"3\"></td>");
            html.Append("<td colspan= \"3\"><label> Remark:&nbsp;</label><input type= \"text\" name= \"txtRemark\" size= \"50\"></td>");
            html.Append("<td><input type= \"hidden\" name= \"txtGSOrderId\" value= \"<?php echo $rwGSOrderId; ?>\">");
            html.Append("<input type= \"hidden\" name= \"txtLocation\" id= \"txtLocation\" value=></ td >");
            html.Append("</tr>");
            html.Append("<tr>");
            html.Append("<td><input type= \"hidden\" name= \"planningid\" value= \"<?php echo $PlanningId; ?>\"></td>");
            html.Append("<td colspan= \"4\" ><input type= \"submit\" value= \"Confirm\" class= \"ui-button ui-widget ui-corner-all\">&nbsp;<input type= \"reset\" value= \"Cancel\" onclick= \"window.history.go(-1);\" class= \"ui-button ui-widget ui-corner-all\"></td>");
            html.Append("</tr>");
            html.Append("</form>");
            html.Append("</tbody>");
            html.Append("</table>");

        }











        ContentPlaceHolder cph;
        cph = (ContentPlaceHolder)Master.FindControl("ContentPlaceHolder1");
        cph.Controls.Add(new Literal { Text = html.ToString() });



    }


    private DataTable GetDataTop(String id)
    {
        DataTable dt = null;
        BLL.DriverPickupSel _BLL = new BLL.DriverPickupSel();
        dt = _BLL.getDriverPickupSel(id);
        return dt;
    }
}