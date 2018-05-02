using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class customs_code_GSOrderDetail : System.Web.UI.Page
{

    DataTable dtTop, dtBottom;
    protected void Page_Load(object sender, EventArgs e)
    {

        String ID = Request.QueryString["ID"];

        dtTop = GetDataTop(ID);
        dtBottom = GetDataBottom(ID);
        StringBuilder html = new StringBuilder();


        String GROrderId = null, GROrderNo = null, CustName = null, MTBranchName = null;
        String OrderStatus = null, TotalQty = null, RTVData = null, OrderDate = null, CheckDay = null;
        String CreatedDate = null, Remark = null;
        String Status = null;
        if(dtTop.Rows.Count > 0)
        {
            GROrderId = dtTop.Rows[0]["ID"].ToString();
            GROrderNo = dtTop.Rows[0]["GSOrderNo"].ToString();
            CustName = dtTop.Rows[0]["CustName"].ToString();
            MTBranchName = dtTop.Rows[0]["MTBranchName"].ToString();
            OrderStatus = dtTop.Rows[0]["OrderStatus"].ToString();
            TotalQty = dtTop.Rows[0]["TotalQty"].ToString();
            RTVData = dtTop.Rows[0]["RTVData"].ToString();
            OrderDate = dtTop.Rows[0]["OrderDate"].ToString();
            CheckDay = dtTop.Rows[0]["CheckDay"].ToString();
            CreatedDate = dtTop.Rows[0]["CreatedDate"].ToString();
            Remark = dtTop.Rows[0]["Remark"].ToString();

            switch (OrderStatus) {
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

        }
      


        html.Append("<table class=\"table-main-form\" width= \"100%\">");
        html.Append("<tbody>");
        html.Append("<tr>");
        html.Append("<td width = \"30%\"> &nbsp;</td>");
        html.Append("<td width = \"7 %\"> &nbsp;</td>");
        html.Append("</tr>");
        html.Append("<tr>");
        html.Append("<td><b>RN No.<b></td>");
        html.Append("<td><b>" + RTVData + "<b></td>");
        html.Append("</tr>");
        html.Append("<tr>");
        html.Append("<td>Customer</td>");
        html.Append("<td>" + CustName + "</td>");
        html.Append("</tr>");
        html.Append("<tr>");
        html.Append("<td>BRANCH</td>");
        html.Append("<td>" + MTBranchName + "</td>");
        html.Append("</tr>");
        html.Append("<tr>");
        html.Append("<td>Status</td>");
        html.Append("<td>" + Status + "</td>");
        html.Append("</tr>");
        html.Append("<tr>");
        html.Append("<td>Order date</td>");
        html.Append("<td>" + OrderDate + "</td>");
        html.Append("</tr>");
        html.Append("<tr>");
        html.Append("<td>Check Date</td>");
        html.Append("<td>" + CheckDay + "</td>");
        html.Append("</tr>");
        html.Append("<tr>");
        html.Append("<td>Order No</td>");
        html.Append("<td>" + GROrderNo + "</td>");
        html.Append("</tr>");
        html.Append("<tr>");
        html.Append("<td>Remark</td>");
        html.Append("<td>" + Remark + "</td>");
        html.Append("</tr>");
        html.Append("<tr>");
        html.Append("<td>Create Date</td>");
        html.Append("<td>" + CreatedDate + "</td>");
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
        html.Append("<th width= \"40%\">Order No.</th>");
        html.Append("<th width = \"10%\" >Label</ th >");
        html.Append("<th width= \"20%\" class=\"visible-lg\">Status</th>");
        html.Append("<th width = \"20%\" class=\"visible-lg\">Remark</th>");
        html.Append("<th>&nbsp;</th>");
        html.Append("</tr>");
        html.Append("</thead>");
        html.Append("<tbody>");


        if (dtBottom.Rows.Count > 0)
        {
            string Id, ProdName, Desc, rwProdStatus; 
            for (int i = 0; i < dtBottom.Rows.Count; i++)
            {
                Id = dtBottom.Rows[i]["ID"].ToString();
                ProdName = dtBottom.Rows[i]["ProductName"].ToString();
                Desc = dtBottom.Rows[i]["Description"].ToString();
                rwProdStatus = dtBottom.Rows[i]["Status"].ToString();

                switch (rwProdStatus)
                {
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
                html.Append("<td>" + (i + 1) + "</td>");
                html.Append("<td>" + ProdName + "</td>");

                html.Append("<td><textarea name= \"txtlbl\" id= \"txtlbl\" rows= \"4\" cols= \"60\">" + Desc + "</textarea></td>");
                html.Append("<td class='visible-lg'>" + Status + "</td>");
                html.Append("</td>");
                html.Append("<td><a href='#' class='ui-button ui-widget ui-corner-all'>Update Label</a></td>");
                html.Append("</tr>");
            }

        }


        html.Append("</tbody>");
        html.Append("</table></td>");
        html.Append("</tr>");
        html.Append("<tr><td colspan= \"2\"> &nbsp;</td></tr>");
        html.Append("<tr>");
        html.Append("<td colspan= \"2\" ><table width= \"420\" border= \"0\" cellspacing= \"0\" cellpadding= \"0\" align= \"center\" >");
        html.Append("<tbody>");
        html.Append("<tr align= \"left\">");
        html.Append("<td width= \"80\"><input type= \"button\" name= \"btnBack\" id= \"btnBack\" value= \"Back\" onClick= \"window.history.go(-1); return false;\" class='ui-button ui-widget ui-corner-all'></td>");
        html.Append("<td width= \"80\"><input type= \"button\" name= \"btnPrint\" id= \"btnPrint\" value= \"Print\" onClick= \"window.open('./customs/code/qrcodegen/gsorderprintqr.php?id=>','_blank');\" class='ui-button ui-widget ui-corner-all'></td>");
        html.Append("<td width= \"100\"><a href='./gsorderpickup.aspx?id=" + ID + "&no=" + GROrderNo + "' class='ui-button ui-widget ui-corner-all'>Pick up</a></td>");
        html.Append("<td width= \"160\"><a href='./gsorderfile.aspx?id=" + ID + "&no=" + GROrderNo + "' class='ui-button ui-widget ui-corner-all'>File Attachment</a></td>");
        html.Append("</tr>");
        html.Append("</tbody>");
        html.Append("</table></td>");
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
        BLL.GSOrderDetail _BLL = new BLL.GSOrderDetail();
        dt = _BLL.getGSOrderDetail_Top(GSOrderID);
        return dt;
    }


    private DataTable GetDataBottom(String GSOrderID)
    {
        DataTable dt = null;
        BLL.GSOrderDetail _BLL = new BLL.GSOrderDetail();
        dt = _BLL.getGSOrderDetail_Bottom(GSOrderID);
        return dt;
    }






}