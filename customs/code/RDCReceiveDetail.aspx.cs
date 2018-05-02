using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class customs_code_RDCReceiveDetail : System.Web.UI.Page
{

    DataTable dtTop, dtBottom;
    protected void Page_Load(object sender, EventArgs e)
    {

        String ID = Request.QueryString["ID"];
        dtTop = GetDataTop(ID);
        dtBottom = GetDataBottom(ID);
        StringBuilder html = new StringBuilder();


        string	rwGROrderId = null,rwGROrderNo = null ,rwCustName=null,rwMTBranchName=null,rwOrderStatus=null,rwTotalQty=null,rwRTVData=null;
		string rwOrderDate=null,rwCheckDay=null,rwCreatedDate=null,rwRemark=null,Status=null;


        if(dtTop.Rows.Count > 0 )
        {

            rwGROrderId = dtTop.Rows[0]["ID"].ToString();
            rwGROrderNo = dtTop.Rows[0]["GSOrderNo"].ToString();
            rwCustName = dtTop.Rows[0]["CustName"].ToString();
            rwMTBranchName = dtTop.Rows[0]["MTBranchName"].ToString();
            rwOrderStatus = dtTop.Rows[0]["OrderStatus"].ToString();
            rwTotalQty = dtTop.Rows[0]["TotalQty"].ToString();
            rwRTVData = dtTop.Rows[0]["RTVData"].ToString();
            rwOrderDate = dtTop.Rows[0]["OrderDate"].ToString();
            rwCheckDay = dtTop.Rows[0]["CheckDay"].ToString();
            rwCreatedDate = dtTop.Rows[0]["CreatedDate"].ToString();
            rwRemark = dtTop.Rows[0]["Remark"].ToString();

        }



        switch (rwOrderStatus) {
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
			Status = "3-Driver received";
            break;
		case "4":
			Status = "4-Receive Pending";
            break;
		case "5":
			Status = "5-RDC received";
            break;
		case "6":
			Status = "6-CDC received";
            break;
		case "7":
			Status = "7-Completed";
            break;
        }

        html.Append("<table class= \"table - main - form\">");
        html.Append("<tbody>");
        html.Append("<tr>");
        html.Append("<td width= \"30%\" > &nbsp;</td>");
        html.Append("<td width= \"70%\" > &nbsp;</td>");
        html.Append("</tr>");
        html.Append("<tr>");
        html.Append("<td><b>Order No.<b></td>");
        html.Append("<td><b>" + rwGROrderNo + "<b></td>");
        html.Append("</tr>");
        html.Append("<tr>");
        html.Append("<td>Branch</td>");
        html.Append("<td>" + rwCustName + "</td>");
        html.Append("</tr>");
        html.Append("<tr>");
        html.Append("<td>Status</td>");
        html.Append("<td>" + Status + "</td>");
        html.Append("</tr>");
        html.Append("<tr>");
        html.Append("<td>Pickup date</td>");
        html.Append("<td>" + rwOrderDate + "</td>");
        html.Append("</tr>");
        html.Append("<tr>");
        html.Append("<td>RTV Data</td>");
        html.Append("<td>" + rwRTVData + "</td>");
        html.Append("</tr>");
        html.Append("<tr>");
        html.Append("<td>&nbsp;</td>");
        html.Append("<td>&nbsp;</td>");
        html.Append("</tr>");
        html.Append("<tr>");
        html.Append("<td colspan= \"2\"><table class= \"table table-hover\">");
        html.Append("<thead>");
        html.Append("<tr>");
        html.Append("<th>No.</th>");
        html.Append("<th>Order</th>");
        html.Append("<th>Label</th>");
        html.Append("<th class='visible-lg'>Status</th>");
        html.Append("<th>&nbsp;</th>");
        html.Append("</tr>");
        html.Append("</thead>");
        html.Append("<tbody>");


        string 	rwId = null,rwProdName=null,rwDesc=null,rwProdStatus=null,ProdStatus=null ;

        if(dtBottom.Rows.Count > 0)
        {
            for(int i=0;i < dtBottom.Rows.Count - 1;i++)
            {
                rwId = dtBottom.Rows[i]["ID"].ToString();
                rwProdName = dtBottom.Rows[i]["ProductName"].ToString();
                rwDesc = dtBottom.Rows[i]["Description"].ToString();
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
				Status = "3-Driver received";
                break;
			case "4":
				Status = "4-Receive Pending";
                break;
			case "5":
				Status = "5-RDC received";
                break;
			case "6":
				Status = "6-CDC received";
                break;
			case "7":
				Status = "7-Completed";
                break;
            }


               html.Append("<tr>");
                html.Append("<td>" + (i + 1 ) + "</td>");
                html.Append("<td>" + rwProdName +"</td>");
                html.Append("<td>" + rwDesc + "</td>");
                html.Append("<td class='visible-lg'>" + Status + "</td>");
                html.Append("<td><a href=\"RdcReceive.aspx?id=" + rwId + "\" class='ui-button ui-wiget ui-corner-all'>Receive</a></td>");
                html.Append("</tr>");
            }

        }

        html.Append("</tbody>");
        html.Append("</table></td>");
        html.Append("</tr>");
        html.Append("<tr><td colspan= \"2\"> &nbsp;</td></tr>");
        html.Append("<tr>");
        html.Append("<td colspan= \"2\"> &nbsp;</td>");
        html.Append("</tr>");
        html.Append("</tbody>");
        html.Append("</table>");

       ContentPlaceHolder cph;
        cph = (ContentPlaceHolder)Master.FindControl("ContentPlaceHolder1");
        cph.Controls.Add(new Literal { Text = html.ToString() });

    }

    private DataTable GetDataTop(String GSOrderID)
    {
        DataTable dt = null;
        BLL.RDCReceiveDetail _BLL = new BLL.RDCReceiveDetail();
        dt = _BLL.getRDCReceiveDetail_Top(GSOrderID);
        return dt;
    }


    private DataTable GetDataBottom(String GSOrderID)
    {
        DataTable dt = null;
        BLL.RDCReceiveDetail _BLL = new BLL.RDCReceiveDetail();
        dt = _BLL.getRDCReceiveDetail_Bottom(GSOrderID);
        return dt;
    }
}