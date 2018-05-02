using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI.Diagram;

public partial class customs_code_RdcPlanningDetail : System.Web.UI.Page
{

    DataTable dtTop, dtBottom;

    protected void Page_Load(object sender, EventArgs e)
    {
        dtTop = GetDataTop(2);
        dtBottom = GetDataBottom(2);
        StringBuilder html = new StringBuilder();


        String PlanningId=null, PlanningNo = string.Empty, RDC = null, TruckNo = null;
        String PickupTime=null , PickupDate=null , CreatedBy= null , CreatedDate = null , Remark = null;
		String  Status =null;

        if(dtTop.Rows.Count > 0)
        {
            PlanningId = dtTop.Rows[0]["ID"].ToString();
            PlanningNo = dtTop.Rows[0]["RDCPlanningNo"].ToString();
            RDC = dtTop.Rows[0]["RDC"].ToString();
            TruckNo = dtTop.Rows[0]["TruckNo"].ToString();
            Status = dtTop.Rows[0]["Status"].ToString();
            PickupTime = dtTop.Rows[0]["PickupTime"].ToString();
            PickupDate = dtTop.Rows[0]["PickupDate"].ToString();
            CreatedBy = dtTop.Rows[0]["CreatedBy"].ToString();
            CreatedDate = dtTop.Rows[0]["CreatedDate"].ToString();
            Remark = dtTop.Rows[0]["Remark"].ToString();

        }



        switch (Status) {
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



        html.Append("<table class=\"table-main-form\" width= \"100%\">");
        html.Append("<tbody>");
        html.Append("<tr>");
        html.Append("<td width = \"30%\"> &nbsp;</td>");
        html.Append("<td width = \"7 %\"> &nbsp;</td>");
        html.Append("</tr>");
        html.Append("<tr>");
        html.Append("<td><b>Planning No.<b></td>");
        html.Append("<td><b>" + PlanningNo + "<b><td>");
        html.Append("</tr>");
        html.Append("<tr>");
        html.Append("<td>RDC</td>");
        html.Append("<td>" + RDC + "</td>");
        html.Append("</tr>");
        html.Append("<tr>");
        html.Append("<td>Status</td>");
        html.Append("<td>" + Status + "</td>");
        html.Append("</tr>");
        html.Append("<tr>");
        html.Append("<td>Pickup date</td>");
        html.Append("<td>" + PickupDate + "</td>");
        html.Append("</tr>");
        html.Append("<tr>");
        html.Append("<td>Pickup Time</td>");
        html.Append("<td>" + PickupTime + "</td>");
        html.Append("</tr>");
        html.Append("<tr>");
        html.Append("<td>Created date</td>");
        html.Append("<td>" + CreatedDate + "</td>");
        html.Append("</tr>");
        html.Append("<tr>");
        html.Append("<td>Created by</td>");
        html.Append("<td>" + CreatedBy + "</td>");
        html.Append("</tr>");
        html.Append("<tr>");
        html.Append("<td>Remark</td>");
        html.Append("<td>" + Remark + "</td>");
        html.Append("</tr>");
        html.Append("<tr>");
        html.Append("<td>&nbsp;</td>");
        html.Append("<td>&nbsp;</td>");
        html.Append("</tr>");
        html.Append("<tr>");
        html.Append("<td colspan= \"2\"> <table width= \"100%\" class= \"table table - hover\">");
        html.Append("<thead>");
        html.Append("<tr>");
        html.Append("<th width = \"10%\" > No.</ th >");
        html.Append("<th width= \"40%\">GS Order No.</th>");
        html.Append("<th width = \"10%\" > Qty.</ th >");
        html.Append("<th width= \"20%\" class=\"visible-lg\">Status</th>");
        html.Append("<th width = \"20%\" class=\"visible-lg\">Remark</th>");
        html.Append("<th>&nbsp;</th>");
        html.Append("</tr>");
        html.Append("</thead>");
        html.Append("<tbody>");


        if(dtBottom.Rows.Count > 0)
        {

            string Id,RDCPlanningNo,GSOrderId,GSOrderNo,Qty, rwProdStatus;
         




            for (int i = 0; i < dtBottom.Rows.Count; i++)
            {
                Id = dtBottom.Rows[i]["ID"].ToString();
                RDCPlanningNo = dtBottom.Rows[i]["RDCPlanningNo"].ToString();
                GSOrderId = dtBottom.Rows[i]["GSOrderId"].ToString();
                GSOrderNo = dtBottom.Rows[i]["GSOrderNo"].ToString();
                Qty = dtBottom.Rows[i]["Qty"].ToString();
                Remark = dtBottom.Rows[i]["Remark"].ToString();
                rwProdStatus = dtBottom.Rows[i]["Status"].ToString();

                switch (rwProdStatus) {
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
                html.Append("<td>" +  (i + 1) + "</td>");
                html.Append("<td>" + GSOrderNo + "</td>");

                html.Append("<td>" + Qty + "</td>");
                html.Append("<td class='visible-lg'>" + Status + "</td>");
                html.Append("<td class='visible-lg'>" + Remark + "</td>");
                html.Append("<td><a href='index.php?option=gsorderdetail&id=" + GSOrderId + "' class='ui-button ui-widget ui-corner-all'>Detail</a></td>");
                html.Append("</tr>");
            }



        }



        html.Append("</tbody>");
        html.Append("</table></td>");
        html.Append("</tr>");
        html.Append("<tr><td colspan = \"2\"> &nbsp;</td></tr>");
        html.Append("<tr>");
        html.Append("<td colspan = \"2\" > &nbsp;</td>");
        html.Append ("</tr>");
        html.Append("</tbody>");
        html.Append("</table>");


        ContentPlaceHolder cph;
        Literal lit;

        cph = (ContentPlaceHolder)Master.FindControl("ContentPlaceHolder1");

        cph.Controls.Add(new Literal { Text = html.ToString() });

    }







    private DataTable GetDataTop(int planingId)
    {
        DataTable dt = null;
        BLL.RdcPlaningDetail _BLL = new BLL.RdcPlaningDetail();
        dt = _BLL.getRdcPlaningDetail_Top(planingId);
        return dt;
    }


    private DataTable GetDataBottom(int planingId)
    {
        DataTable dt = null;
        BLL.RdcPlaningDetail _BLL = new BLL.RdcPlaningDetail();
        dt = _BLL.getRdcPlaningDetail_Bottom(planingId);
        return dt;
    }
}