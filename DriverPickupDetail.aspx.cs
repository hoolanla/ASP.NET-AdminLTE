using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class customs_code_DriverPickupDetail : System.Web.UI.Page
{


    DataTable dtTop, dtBottom;

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["USER"] == null)
        {
            Response.Redirect("Authorize.aspx");
        }


        dtTop = GetDataTop(22);
        dtBottom = GetDataBottom(22);
        StringBuilder html = new StringBuilder();

        String GROrderId = null, GROrderNo = null, CustName = null, MTBranchName = null;
        String OrderStatus = null, TotalQty = null, RTVData = null, OrderDate = null, CheckDay = null;
        String CreatedDate = null, Remark = null;
        String Status = null;
        if (dtTop.Rows.Count > 0)
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

            switch (OrderStatus)
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
            html.Append("<td>Pickup Date</td>");
            html.Append("<td>" + OrderDate + "</td>");
            html.Append("</tr>");

            html.Append("<tr>");
            html.Append("<td>Order No</td>");
            html.Append("<td>" + GROrderNo + "</td>");
            html.Append("</tr>");
          
    
            html.Append("<tr>");
            html.Append("<td>&nbsp;</td>");
            html.Append("<td>&nbsp;</td>");
            html.Append("</tr>");
            html.Append("<tr>");
            html.Append("<td colspan= \"2\"> <table width= \"100%\" class= \"table table - hover\">");
            html.Append("<thead>");
            html.Append("<tr>");

            html.Append("<th></th>");
            html.Append("<th> No.</th>");
            html.Append("<th> Goods </th>");
            html.Append("<th> Label </th>");
            html.Append("<th class='visible-lg'>Status</th>");
            html.Append("<th>&nbsp;</th>");
            html.Append("</tr>");
            html.Append("</thead>");
            html.Append("<tbody>");



            html.Append("<form id= \"form1\" name= \"form1\" method= \"post\" action= \"driverpickupsel.aspx\">");


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
                    html.Append("<td><input type= \"checkbox\" name= \"checkId[]\" value= \"" + Id + "\"></td>");
                    html.Append("<td>"+(i+1)+"</td>");
                    html.Append("<td>"+ ProdName + "</td>");
                    html.Append("<td><textarea rows='4' cols='60' readonly='true'>" + Desc + "</textarea></td>");
                    html.Append("<td class='visible-lg'>" + Status + "</td>");
                    html.Append("<td><a href= \"index.php?option=driverpickup&id=" + Id + "&planningid= \"class='ui-button ui-wiget ui-corner-all'>Pickup</a></td>");
                    html.Append("</tr>");



                }

                html.Append("<tr>");
                html.Append("<td colspan= \"5\"><input type= \"submit\" value= \"Pickup by select\" class= \"ui-button ui-widget ui-corner-all\"></td>");
                html.Append("<td><input type= \"hidden\" name= \"txtPlanningId\" value= \"3\"></td>");
                html.Append("</tr>");
                html.Append("</tbody>");
                html.Append("</table></td>");
                html.Append("</tr>");
                html.Append("<tr><td colspan= \"2\"> &nbsp;</td></tr>");
                html.Append("<tr>");
                html.Append("<td colspan= \"2\" > &nbsp;</td>");
                html.Append("</tr>");
                html.Append("</form>");
                html.Append("</tbody>");
                html.Append("</table>");
            }

            ContentPlaceHolder cph;
            cph = (ContentPlaceHolder)Master.FindControl("ContentPlaceHolder1");
            cph.Controls.Add(new Literal { Text = html.ToString() });
        }






    }


    private DataTable GetDataTop(int GSOrderID)
    {
        DataTable dt = null;
        BLL.DriverPickupDetail _BLL = new BLL.DriverPickupDetail();
        dt = _BLL.getDriverPickupDetail_Top(GSOrderID);
        return dt;
    }


    private DataTable GetDataBottom(int GSOrderID)
    {
        DataTable dt = null;
        BLL.DriverPickupDetail _BLL = new BLL.DriverPickupDetail();
        dt = _BLL.getDriverPickupDetail_Bottom(GSOrderID);
        return dt;
    }

}