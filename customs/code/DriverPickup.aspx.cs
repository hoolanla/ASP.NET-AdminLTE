using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class customs_code_DriverPickup : System.Web.UI.Page
{

    DataTable dtTop, dtBottom;


    protected void Page_Load(object sender, EventArgs e)
    {

        dtTop = GetDriverPickup(22);
  
        StringBuilder html = new StringBuilder();
        string GSOrderNo = null, ProdName = null, Description = null, OrderDetailId=null;
        if (dtTop.Rows.Count > 0)
        {
            GSOrderNo = dtTop.Rows[0]["GSOrderNo"].ToString();
            ProdName = dtTop.Rows[0]["ProdName"].ToString();
            Description = dtTop.Rows[0]["Description"].ToString();

        }



        html.Append("<form id= \"form1\" name = \"form1\" method= \"post\" action= \"./customs/code/UpdateGSOrderDetail.php\">");
        html.Append("<table width= \"400\" border= \"0\" cellspacing= \"1\" cellpadding= \"1\" class= \"table - main - form\">");
        html.Append("<tbody>");
        html.Append("<tr>");
        html.Append("<td></td>");
        html.Append("<td>");
        html.Append("<input type= \"text\" name= \"txtGSOrderId\" id= \"txtGSOrderId\" value=\"" + OrderDetailId + "\" hidden></td>");
        html.Append("</tr>");
        html.Append("<tr>");
        html.Append("<td><b>GS Order No.<b></td>");
        html.Append("<td>");
        html.Append("<input type= \"text\" name= \"txtGSOrderNo\" id= \"txtGSOrderNo\" value= \"" + GSOrderNo + "\" readonly></td>");
        html.Append("</tr>");
        html.Append("<tr>");
        html.Append("<td>Goods</td>");
        html.Append("<td>");
        html.Append("<input type= \"text\" name= \"txtProdName\" id= \"txtProdName\" value= \"" + ProdName + "\" readonly></td>");
        html.Append("</tr>");
        html.Append("<tr>");
        html.Append("<td>Description</td>");
        html.Append("<td>");
        html.Append("<input type= \"text\" name= \"txtDesc\" id= \"txtDesc\" value= \"" + Description + "\" readonly></td>");
        html.Append("</tr>");
        html.Append("<tr>");
        html.Append("<td>&nbsp;</td>");
        html.Append("<td><table width= \"120\" border= \"0\" cellspacing= \"1\" cellpadding= \"1\">");
        html.Append("<tbody>");
        html.Append("<tr>");
        html.Append("<td><input type= \"submit\" name= \"submit\" id= \"submit\" value= \"Submit\" class= \"ui-button ui-widget ui-corner-all\"></td>");
        html.Append("<td><input type = \"button\" name= \"reset\" id= \"reset\" value= \"Cancel\" onClick= \"window.history.go(-1); return false;\" class= \"ui-button ui-widget ui-corner-all\"></td>");
        html.Append("</tr>");
        html.Append("</tbody>");
        html.Append("</table></td>");
        html.Append("</tr>");
        html.Append("</tbody>");
        html.Append("</table>");

        html.Append("</form>");

        ContentPlaceHolder cph;
        cph = (ContentPlaceHolder)Master.FindControl("ContentPlaceHolder1");
        cph.Controls.Add(new Literal { Text = html.ToString() });
    }

private DataTable GetDriverPickup(int OrderDetailID)
{
    DataTable dt = null;
    BLL.DriverPickup _BLL = new BLL.DriverPickup();
    dt = _BLL.getDriverPickup(OrderDetailID);
    return dt;
}


}