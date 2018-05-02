using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class customs_code_GSOrderPickup : System.Web.UI.Page
{

    DataTable dtTop, dtBottom;

    protected void Page_Load(object sender, EventArgs e)
    {

        String GSOrderID = Request.QueryString["id"];
        String GSOrderNO = Request.QueryString["no"];
        dtTop = GetDataTop(GSOrderID);
   
        StringBuilder html = new StringBuilder();

        html.Append("<Table width=90% class='table table-hover'>");
        html.Append("<THEAD><TR>");
        html.Append("<th>No.</th>");
        html.Append("<th>Pickup no.</th>");
        html.Append("<th>Round</th>");
        html.Append("<th>Total Qty.</th>");
        html.Append("<th>Pickup date</th>");
        html.Append("<th>Pickup By</th>");
        html.Append("<th></th>");
        html.Append("</TR></THEAD>");
        html.Append("<TBody>");


        if(dtTop.Rows.Count > 0)
        {

            	String rwId=null,PickupNo=null,RDCPlanningNo=null,Round=null,TotalQty=null,PickupDate=null,PickupBy=null;

            


           for(int i = 0;i < dtTop.Rows.Count;i++)
            {

                rwId = dtTop.Rows[i]["ID"].ToString();
                PickupNo = dtTop.Rows[i]["PickupNo"].ToString();
                RDCPlanningNo = dtTop.Rows[i]["RDCPlanningNo"].ToString();
                Round = dtTop.Rows[i]["Round"].ToString();
                TotalQty = dtTop.Rows[i]["TotalQty"].ToString();
                PickupDate = dtTop.Rows[i]["PickupDate"].ToString();
                PickupBy= dtTop.Rows[i]["PickupBy"].ToString();
     


                html.Append("<tr>");
                html.Append("<td>"+ (i+1) +"</td>");
                html.Append("<td>"+ PickupNo + "</td>");
                html.Append("<td>" + Round + "</td>");
                html.Append("<td>" +TotalQty +"</td>");
                html.Append("<td>" + PickupDate +"</td>");
                html.Append("<td>"+ PickupBy + "</td>");
                html.Append("<td><a href='gsorderpickupdetail.aspx?id=" + rwId + "' class='ui-button ui-widget ui-corner-all'>Detail</a></td>");
                html.Append("</tr>");

            }



        }
        html.Append("</TBody>");
        html.Append("</Table>");
        html.Append("<BR>");
        html.Append("<input type= \"button\" name= \"btnBack\" id = \"btnBack\" value= \"Back\" onClick= \"window.history.go(-1); return false;\" class='ui-button ui-widget ui-corner-all'>");

        ContentPlaceHolder cph;
        cph = (ContentPlaceHolder)Master.FindControl("ContentPlaceHolder1");
        cph.Controls.Add(new Literal { Text = html.ToString() });
    }

    private DataTable GetDataTop(String GSOrderID)
    {
        DataTable dt = null;
        BLL.GSOrderPickup _BLL = new BLL.GSOrderPickup();
        dt = _BLL.getGSOrderPickup(GSOrderID);
        return dt;
    }
}