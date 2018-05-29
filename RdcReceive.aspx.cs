using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class customs_code_RdcReceive : System.Web.UI.Page
{

    DataTable dtTop, dtBottom;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["USER"] == null)
        {
            Response.Redirect("Authorize.aspx");
        }

        String OrderDetailID = Request.QueryString["id"];
        dtTop = GetDataTop(OrderDetailID);
        StringBuilder html = new StringBuilder();


        if(dtTop.Rows.Count > 0)
        {
	string rwGSOrderNo=null,rwProdName=null,rwDescription = null;
            rwGSOrderNo = dtTop.Rows[0]["GSOrderNo"].ToString();
            rwProdName = dtTop.Rows[0]["ProdName"].ToString();
            rwDescription = dtTop.Rows[0]["Description"].ToString();

            html.Append("<form id= \"form1\" name= \"form1\" method= \"post\" action= \"./ customs/code/UpdateGSOrderDetail.php\">");
            html.Append("<table width= \"400\" border= \"0\" cellspacing= \"1\" cellpadding= \"1\" class= \"table-main-form\">");
            html.Append("<tbody>");
            html.Append("<tr>");
            html.Append("<td></td>");
            html.Append("<td>");
            html.Append("<input type= \"text\" name= \"txtGSOrderId\" id= \"txtGSOrderId\" value= \"" + OrderDetailID + "\" hidden></td>");
            html.Append("</tr>");
            html.Append("<tr>");
            html.Append("<td><b>GS Order No.<b></td>");
            html.Append("<td>");
            html.Append("<input type= \"text\" name= \"txtGSOrderNo\" id= \"txtGSOrderNo\" value= \"" + rwGSOrderNo + "\" readonly></td>");
            html.Append("</tr>");
            html.Append("<tr>");
            html.Append("<td>Goods</td>");
            html.Append("<td>");
            html.Append("<input type= \"text\" name= \"txtProdName\" id= \"txtProdName\" value= \"" + rwProdName + "\"readonly></td>");
            html.Append("</tr>");
            html.Append("<tr>");
            html.Append("<td>Description</td>");
            html.Append("<td>");
            html.Append("<input type= \"text\" name= \"txtDesc\" id= \"txtDesc\" value= \"" + rwDescription + "\" readonly></td>");
            html.Append("</tr>");
            html.Append("<tr>");
            html.Append("< td>&nbsp;</td>");
            html.Append("<td><table width= \"120\" border= \"0\" cellspacing= \"1\" cellpadding= \"1\">");
            html.Append("<tbody>");
            html.Append("<tr>");
            html.Append("<td><input type= \"submit\" name= \"submit\" id= \"submit\" value= \"Submit\" class= \"ui-button ui-widget ui-corner-all\"></td>");
            html.Append("<td><input type= \"button\" name= \"reset\" id= \"reset\" value= \"Cancel\" onClick= \"window.history.go(-1); return false;\" class=\"ui-button ui-widget ui-corner-all\"></td>");
            html.Append("</tr>");
            html.Append("</tbody>");
            html.Append("</table></td>");
            html.Append("</tr>");
            html.Append("</tbody>");
            html.Append("</table>");
            html.Append("</form>");
        }


        ContentPlaceHolder cph;
        cph = (ContentPlaceHolder)Master.FindControl("ContentPlaceHolder1");
        cph.Controls.Add(new Literal { Text = html.ToString() });

    }

    private DataTable GetDataTop(String OrderDetailID)
    {
        DataTable dt = null;
        BLL.RDCReceive _BLL = new BLL.RDCReceive();
        dt = _BLL.getRDCReceive(OrderDetailID);
        return dt;
    }
}