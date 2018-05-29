using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;

public partial class customs_code_GSOrderAdd : System.Web.UI.Page
{

    DataTable DTBox;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["USER"] == null)
        {
            Response.Redirect("Authorize.aspx");
        }

        DTBox = GetBox();

        StringBuilder html = new StringBuilder();
        string nl = System.Environment.NewLine;



        html.Append("<script type= 'text/javascript'>" + nl) ;
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
        if (DTBox.Rows.Count > 0)
        {
            String id = null, name = null;
            for (Int16 i = 0; i < DTBox.Rows.Count; i++)
            {
                id = DTBox.Rows[i]["id"].ToString();
                name = DTBox.Rows[i]["name"].ToString();
                html.Append("var option = document.createElement(\"OPTION\");" + nl);
                html.Append("option.setAttribute(\"value\",\"" + id + "\");" + nl);
                html.Append("option.text = \"" + name + "\";" + nl);
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




        

        html.Append("<form id= \"frmOrder\" name= \"frmOrder\" method= \"post\" action= \"saveorder.aspx\" >");
        html.Append("<table width= \"100 % \" border= \"0\" cellspacing= \"10\" cellpadding= \"10\" class= \"table - main - form\">");
        html.Append("<tbody>");
        html.Append("<tr>");
        html.Append("<td width= \"10%\">Customer</td>");
        html.Append("<td width= \"90%\">");
        html.Append("<select name= \"selCust\" id= \"selCust\">");
        html.Append("<option value= \"THAILAND\" selected= \"selected\"></option>");
        html.Append("</select>");
        html.Append("</td>");
        html.Append("</tr>");
        html.Append("<tr>");
        html.Append("<td>Branch</td>");
        html.Append("<td>");
        html.Append("<select name= \"selBranch\" id= \"selBranch\">");
        html.Append("</select>");
        html.Append("</td>");
        html.Append("</tr>");
        html.Append("<tr>");
        html.Append("<td>Pickup date</td>");
        html.Append("<td>");
        html.Append("<input type= \"text\" id= \"datepicker\" name= \"datepicker\" size= \"10\" >");
        html.Append("</td>");
        html.Append("</tr>");
        html.Append("<tr>");
        html.Append("<td> Check days</td>");
        html.Append("<td>");
        html.Append("<div style= \"display: inline-block; margin-right: 5px; width: 60px; \" >");
        html.Append("<input type= \"text\" name= \"txtCheckDay\" id= \"txtCheckDay\" maxlength= \"3\" size= \"3\" value= \"0\" onchange= \"checkDayToEndDate();\" ></ div >");
        html.Append("<div style= \"display: inline-block; width: 150px; \" >");
        html.Append("<p id= \"end_date\" name= \"end_date\" > End date:</p>");
        html.Append("</div>");
        html.Append("</td>");
        html.Append("</tr>");
        html.Append("<tr>");
        html.Append("<td>RN No.</td>");
        html.Append("<td>");
        html.Append("<table>");
        html.Append("<tbody>");
        html.Append("<tr>");
        html.Append("<td>");
        html.Append("<input type= \"text\" id= \"txtRtvFile\" name= \"txtRtvFile\" size= \"15\" >");
        html.Append("</td>");
        html.Append("<td > &nbsp;<input type= \"button\" name= \"btnRTV\" id= \"btnRTV\" value= \"Open RN\" onclick= \" window.open('openRTV.html', '_blank')\" class='ui-button ui-widget ui-corner-all'>");
        html.Append("</td>");
        html.Append("</tr>");
        html.Append("<tbody>");
        html.Append("</table>");
        html.Append("</td>");
        html.Append("</tr>");
        html.Append("<tr>");
        html.Append("<td>Remark</td>");
        html.Append("<td>");
        html.Append("<textarea name= \"txtRemark\" id= \"txtRemark\"></textarea></td>");
        html.Append("</tr>");
        html.Append("<tr>");
        html.Append("<td>Order</td>");
        html.Append("<td>");
        html.Append("<table width= \"120\" border= \"0\">");
        html.Append("<tbody>");
        html.Append("<tr>");
        html.Append("<td>");
        html.Append("<input type= \"button\" name= \"btnAdd\" id= \"btnAdd\" value= \"Add\" onclick= \"AddOrder()\" class='ui-button ui-widget ui-corner-all'></td>");
        html.Append("<td>");
        html.Append("<input type= \"button\" name= \"btnRemove\" id= \"btnRemove\" value= \"Remove\" onclick= \"RemoveOrder()\" class='ui-button ui-widget ui-corner-all'></td>");
        html.Append("</tr>");
        html.Append("</tbody>");
        html.Append("</table>");
        html.Append("</td>");
        html.Append("</tr>");
        html.Append("<tr>");
        html.Append("<td>");
        html.Append("<input type= \"text\" name= \"txtIndex\" id= \"txtIndex\" value= \"0\" hidden>");
        html.Append("</td>");
        html.Append("<td>");
        html.Append("<table width= \"500\" border= \"0\" id= \"tOrder\" class= \"table table-hover\">");
        html.Append("<thead>");
        html.Append("<tr>");
        html.Append("<th width= \"50\" > No.</ th >");
        html.Append("<th width= \"150\">Order</th>");
        html.Append("<th width= \"300\" > Label </ th >");
        html.Append("</tr>");
        html.Append("</thead>");
        html.Append("<tbody id= \"tbOrder\">");
        html.Append("</tbody>");
        html.Append("</table>");
        html.Append("</td>");
        html.Append("</tr>");
        html.Append("<tr>");
        html.Append("<td>&nbsp;</td>");
        html.Append("<td>");
        html.Append("<table width= \"130\" border= \"0\">");
        html.Append("<tbody>");
        html.Append("<tr>");
        html.Append("<td>");
        html.Append("<input type= \"submit\" name= \"submit\" id= \"submit\" value= \"Confirm\" class='ui-button ui-widget ui-corner-all'></td>");
        html.Append("<td>");
        html.Append("<input type= \"reset\" name= \"reset\" id= \"reset\" value= \"Cancel\" class='ui-button ui-widget ui-corner-all'></td>");
        html.Append("</tr>");
        html.Append("</tbody>");
        html.Append("</table>");
        html.Append("</td>");
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


    private DataTable GetBox()
    {
        DataTable dt = null;
        BLL.AllComboBox _BLL = new BLL.AllComboBox();
        dt = _BLL.getBox();
        return dt;
    }



    [System.Web.Services.WebMethod]
    public static List<MODEL.Customer> getCustomer()
    {
        BLL.AllComboBox objBLL = new BLL.AllComboBox();
        var list = new List<MODEL.Customer>();
        list = objBLL.getCustomer();
        return list;
    }


    [System.Web.Services.WebMethod]
    public static List<MODEL.Branch> getBranch()
    {
        BLL.AllComboBox objBLL = new BLL.AllComboBox();
        var list = new List<MODEL.Branch>();
        list = objBLL.getBranch();
        return list;
    }
}