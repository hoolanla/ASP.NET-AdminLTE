using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class customs_code_AddRdcPlanning : System.Web.UI.Page
{

    DataTable DT_GSOrderNo;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["USER"] == null)
        {

            Response.Redirect("Authorize.aspx");
        }

        DT_GSOrderNo = GetGSOrderNo();
        StringBuilder html = new StringBuilder();
        string nl = System.Environment.NewLine;




        html.Append("<script type= 'text/javascript'>" + nl);
        html.Append("function AddOrder()" + nl);
        html.Append("{" + nl);
        html.Append("var index = parseInt(document.getElementById(\"txtIndex\").value);" + nl);
        html.Append("index = index + 1;" + nl);
        html.Append("tr = document.createElement(\"TR\");" + nl);
        html.Append("tr.id = \"TROrder\" + index;" + nl);
        html.Append("var td1 = document.createElement(\"TD\");" + nl);
        html.Append("var tN = document.createElement(\"DIV\");" + nl);
        html.Append("tN.setAttribute(\"id\", \"divNo\" + index);" + nl);
        html.Append("tN.innerHTML = index;" + nl);
        html.Append("td1.appendChild(tN);" + nl);
        html.Append("tr.appendChild(td1);" + nl);
        html.Append("var td2 = document.createElement(\"TD\");" + nl);
        html.Append("var select = document.createElement(\"SELECT\");" + nl);
        html.Append("select.setAttribute(\"name\", \"selOrder\"+ index);" + nl);
        html.Append("select.setAttribute(\"id\", \"selOrder\" + index);" + nl);

        //Start Loop
        if (DT_GSOrderNo.Rows.Count > 0)
        {
            String id = null, GSOrderNo = null;
            for (Int16 i = 0; i < DT_GSOrderNo.Rows.Count; i++)
            {
                id = DT_GSOrderNo.Rows[i]["id"].ToString();
                GSOrderNo = DT_GSOrderNo.Rows[i]["GSOrderNo"].ToString();
                html.Append("var option = document.createElement(\"OPTION\");" + nl);
                html.Append("option.setAttribute(\"value\",\"" + id + "\");" + nl);
                html.Append("option.text = \"" + GSOrderNo + "\";" + nl);
                html.Append("select.appendChild(option);" + nl);
            }
        }
        //End Loop
        html.Append("td2.appendChild(select);" + nl);
        html.Append("tr.appendChild(td2);" + nl);
        html.Append("var td4 = document.createElement(\"TD\");" + nl);
        html.Append("var maxChar = 400;" + nl);
        html.Append("var tL = document.createElement(\"textarea\");" + nl);
        html.Append("tL.setAttribute(\"Name\", \"txtlbl\" + index);" + nl);
        html.Append("tL.setAttribute(\"id\", \"txtlbl\" + index);" + nl);
        html.Append(" tL.setAttribute(\"rows\", \"4\");" + nl);
        html.Append("tL.setAttribute(\"cols\", \"80\");" + nl);
        html.Append("tL.setAttribute(\"maxlength\", maxChar);" + nl);
        html.Append("tL.setAttribute(\"onkeyup\", \"textCounter(\" + \"txtlbl\" + index + \",\" + \"textarea_feedback\" + index + \",\" + maxChar + \"); \");" + nl);
        html.Append("td4.appendChild(tL);" + nl);

        html.Append("var td5 = document.createElement(\"TD\");" + nl);
        html.Append("var tP = document.createElement(\"P\");" + nl);
        html.Append("tP.setAttribute(\"Name\", \"textarea_feedback\" + index);" + nl);
        html.Append("tP.setAttribute(\"id\", \"textarea_feedback\" + index);" + nl);
        html.Append("tP.innerHTML = maxChar + \" characters remaining\";" + nl);
        html.Append("td4.appendChild(tP);" + nl);
        html.Append("tr.appendChild(td4);" + nl);
        html.Append("document.getElementById(\"tbOrder\").appendChild(tr);" + nl);
        html.Append("document.getElementById(\"txtIndex\").value = index;" + nl);

        html.Append("if (index != 0)" + nl);
        html.Append("{" + nl);
        html.Append("document.getElementById(\"btnRemove\").disabled = false;" + nl);
        html.Append("}" + nl);
        html.Append("}" + nl);

        html.Append("</Script>" + nl);














        html.Append("<form id= \"form1\" name= \"form1\" method= \"post\" action= \"saverdcplanning.aspx\" >");
        html.Append("<table width= \"100%\" class= \"table - main - form\">");
        html.Append("<tbody>");
        html.Append("<tr>");
        html.Append("<td>&nbsp;</td>");
        html.Append("<td>&nbsp;</td>");
        html.Append("</tr>");
        html.Append("<tr>");
        html.Append("<td>Pickup date</td>");
        html.Append("<td>");
        html.Append("<input type = \"text\" name= \"txtPickupDate\" id= \"datepicker\">");
        html.Append("</td>");
        html.Append("</tr>");
        html.Append("<tr>");
        html.Append("<td> Pickup Time</td>");
        html.Append("<td>");
        html.Append("<input type= \"text\" name= \"txtPickupTime\" id= \"txtPickupTime\"></td>");
         html.Append("</tr>");
        html.Append("<tr>");
        html.Append("<td> Truck </td>");
        html.Append("<td>");
        html.Append("<select name= \"selTruck\" id= \"selTruck\">");
        html.Append("<option value= \"1\"> 11111111 </option>");
        html.Append("</select>");
        html.Append("</td>");
        html.Append("</tr>");
        html.Append("<tr>");
        html.Append("<td> Remark </td>");
        html.Append("<td>");
        html.Append("<input type= \"text\" name= \"txtRemark\" id= \"textfield2\" ></td>");
        html.Append("</tr>");
        html.Append("<tr>");
        html.Append("<td> &nbsp;</td>");
        html.Append("<td><table width= \"120\" border=\"0\" cellspacing=\"1\" cellpadding=\"1\">");
        html.Append("<tbody>");
        html.Append("<tr>");
        html.Append("<td><input type= \"button\" name= \"btnAdd\" id= \"btnAdd\" value= \"ADD\" onclick= \"AddOrder(); \"class= \"ui-button ui-widget ui-corner-all\" ></td>");
        html.Append("<td><input type= \"button\" name= \"btnRemove\" id= \"btnRemove\" value= \"Remove\" onclick= \"RemoveOrder();\" class= \"ui-button ui-widget ui-corner-all\"></td>");
        html.Append("</tr>");
        html.Append("</tbody>");
        html.Append("</table></td>");
        html.Append("</tr>");
        html.Append("<tr>");
        html.Append("<td>");
        html.Append("<input type= \"text\" name= \"txtIndex\" id= \"txtIndex\" value= \"0\" hidden>");
        html.Append("</td>");
        html.Append("<td>");
        html.Append("<table width= \"450\" class= \"table table-hover\">");
        html.Append("<thead>");
        html.Append("<tr>");
        html.Append("<th width= \"100\" > No.</th>");
        html.Append("<th width= \"150\">GS Order No.</th>");
        html.Append("<th width= \"200\" > Remark </th>");
        html.Append("</tr>");
        html.Append("</thead>");
        html.Append("<tbody id= \"tbOrder\">");
        html.Append("</tbody>");
        html.Append("</table>");
        html.Append("</td>");
        html.Append("</tr>");
        html.Append("<tr>");
        html.Append("<td>&nbsp;</td>");
        html.Append("<td><table width= \"120\" border= \"0\" cellspacing= \"1\" cellpadding= \"1\">");
        html.Append("<tbody>");
        html.Append("<tr>");
        html.Append("<td><input type= \"submit\" name= \"submit\" id= \"submit\" value= \"Submit\" class= \"ui-button ui-widget ui-corner-all\"></td>");
        html.Append("<td><input type= \"reset\" name= \"reset\" id= \"reset\" value= \"Reset\" class= \"ui-button ui-widget ui-corner-all\"></td>");
        html.Append("</tr>");
        html.Append("</tbody>");
        html.Append("</table></td>");
        html.Append("</tr>");
        html.Append("<tr>");
        html.Append("<td>&nbsp;</td>");
        html.Append("<td>&nbsp;</td>");
        html.Append("</tr>");
        html.Append("<tr>");
        html.Append("<td>&nbsp;</td>");
        html.Append("<td>&nbsp;</td>");
        html.Append("</tr>");
        html.Append("<tr>");
        html.Append("<td>&nbsp;</td>");
        html.Append("<td>&nbsp;</td>");
        html.Append("</tr>");
        html.Append("</tbody>");
        html.Append("</table>");
        html.Append("</form>");




        ContentPlaceHolder cph;
        cph = (ContentPlaceHolder)Master.FindControl("ContentPlaceHolder1");
        cph.Controls.Add(new Literal { Text = html.ToString() });

    }

    private DataTable GetGSOrderNo()
    {
        DataTable dt = null;
        BLL.AllComboBox _BLL = new BLL.AllComboBox();
        dt = _BLL.getGSOrcerNo();
        return dt;
    }



    [System.Web.Services.WebMethod]
    public static List<MODEL.Truck> getTruck()
    {
        BLL.AllComboBox objBLL = new BLL.AllComboBox();
        var list = new List<MODEL.Truck>();
        list = objBLL.gettruck();
        return list;
    }


}