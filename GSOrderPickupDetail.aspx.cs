using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class customs_code_GSOrderPickupDetail : System.Web.UI.Page
{

    DataTable dtTop, dtBottom;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["USER"] == null)
        {
            Response.Redirect("Authorize.aspx");
        }

        String PickupID = Request.QueryString["id"];
        dtTop = GetDataTop(PickupID);
        dtBottom = GetDataBottom(PickupID);

        String rwId=null, PickupNo=null, RDCPlanningNo=null, Round=null, TotalQty=null, PickupDate=null;
        String PickupBy=null,Remark=null,Photo1=null,Photo2=null,Photo3=null,Signature=null;

        StringBuilder html = new StringBuilder();

        if(dtTop.Rows.Count >  0)
            {
            rwId = dtTop.Rows[0]["ID"].ToString();
            PickupNo = dtTop.Rows[0]["PickupNo"].ToString();
            RDCPlanningNo = dtTop.Rows[0]["RDCPlanningNo"].ToString();
            Round = dtTop.Rows[0]["Round"].ToString();
            TotalQty = dtTop.Rows[0]["TotalQty"].ToString();
            PickupDate = dtTop.Rows[0]["PickupDate"].ToString();
            PickupBy = dtTop.Rows[0]["PickupBy"].ToString();
            Remark = dtTop.Rows[0]["Remark"].ToString();
            Photo1 = dtTop.Rows[0]["Photo1"].ToString();
            Photo2 = dtTop.Rows[0]["Photo2"].ToString();
            Photo3 = dtTop.Rows[0]["Photo3"].ToString();
            Signature = dtTop.Rows[0]["Signature"].ToString();

        }


        html.Append("<Table width= \"80%\" border= \"0\" cellspacing= \"1\" cellpadding= \"1\" class= \"table-main-form\">");
        html.Append("<Tr><Td width= \"20%\"><B>Pickup No.</B></Td><Td><B>" + PickupNo +"</B></Td></Tr>");
        html.Append("<Tr><Td width= \"20%\">Planning No.</Td><Td>" + RDCPlanningNo + "</Td></Tr>");
        html.Append("<Tr><Td width= \"20%\">Round</Td><Td>" + Round + "</Td></Tr>");
        html.Append("<Tr><Td width= \"20%\">Total Qty.</Td><Td>" + TotalQty + "</Td></Tr>");
        html.Append("<Tr><Td width= \"20%\">Pickup date</Td><Td>" + PickupDate + "</Td></Tr>");
        html.Append("<Tr><Td width= \"20%\">Pickup by</Td><Td>" + PickupBy + "</Td></Tr>");
        html.Append("<Tr><Td width= \"20%\">Remark</Td><Td>" + Remark + "</Td></Tr>");
        html.Append("<Tr><Td colspan= \"2\">");



        if(dtBottom.Rows.Count > 0)
        {

            String rwbId=null,rwbProductName=null,rwbDescription=null,rwbStatus=null;
            String Status = null;
            Int16 SVal = 0;


                html.Append("<Table width=100% class='table table-hover'>");
            html.Append("<THEAD><TR>");
            html.Append("<th>No.</th>");
            html.Append("<th>Product Name</th>");
            html.Append("<th>Description</th>");
            html.Append("<th>Status</th>");
            html.Append("</TR></THEAD>");
            html.Append("<TBody>");


            for (int i=0;i < dtBottom.Rows.Count;i++)
            {
                rwbId = dtBottom.Rows[i]["ID"].ToString();
                rwbProductName = dtBottom.Rows[i]["ProductName"].ToString();
                rwbDescription = dtBottom.Rows[i]["Description"].ToString();
                rwbStatus = dtBottom.Rows[i]["Status"].ToString();
          
                switch (rwbStatus) {
                    case "0":
                        Status = "0-Cancel";
                        SVal = 0;
                        break;
                    case "1":
                        Status = "1-Open";
                        SVal = 1;
                        break;
                    case "2":
                        Status = "2-Confirm";
                        SVal = 2;
                        break;
                    case "3":
                        Status = "3-Pickup-Partial";
                        SVal = 3;
                        break;
                    case "4":
                        Status = "4-Pickup";
                        SVal = 4;
                        break;
                    case "5":
                        Status = "5-RDC receive-Partial";
                        SVal = 5;
                        break;
                    case "6":
                        Status = "6-RDC received";
                        SVal = 6;
                        break;
                    case "7":
                        Status = "7-CDC receive-Partial";
                        SVal = 7;
                        break;
                    case "8":
                        Status = "8-CDC received";
                        SVal = 8;
                        break;
                    case "9":
                        Status = "9-Completed";
                        SVal = 9;
                        break;
                }

                html.Append("<tr>");
                html.Append("<td>" + (i+1)+"</td>");
                html.Append("<td>" + rwbProductName+"</td>");
                html.Append("<td>" + rwbDescription+"</td>");
                html.Append("<td>" + Status + "</td>");
                html.Append("</tr>");

            }

            html.Append("</TBody>");
            html.Append ("</Table>");
            html.Append ("</Td></Tr>");

            String ImgSrc = null;
            if (Photo1 != null){
		ImgSrc = "/uploads/Pickup/" + PickupNo + "/Photo/" + Photo1;
                html.Append("<Tr><Td width= \"20%\">Photo 1:</Td><Td><img src= \"" + ImgSrc + "\" alt= \"Photo 1\" style= \"width:500px;height:300px;\"></Td></Tr>");
            }

            if (Photo2 != null){
		ImgSrc = "/uploads/Pickup/" + PickupNo + "/Photo/" + Photo2;
                html.Append("<Tr><Td width= \"20%\">Photo 2:</Td><Td><img src= \"" + ImgSrc + "\" alt= \"Photo 2\" style= \"width:500px;height:300px;\"></Td></Tr>");
            }

            if (Photo3 != null){
		ImgSrc = "/uploads/Pickup/" + PickupNo + "/Photo/" + Photo3;
                html.Append("<Tr><Td width= \"20%\">Photo 3:</Td><Td><img src= \"" + ImgSrc +"\" alt= \"Photo 3\" style= \"width:500px;height:300px;\"></Td></Tr>");
            }

            if (Signature != null){
		ImgSrc = "/uploads/Pickup/" + PickupNo + "/Photo/" + Signature;
                html.Append("<Tr><Td width= \"20%\">Signature:</Td><Td><img src= \"" + ImgSrc + "\" alt= \"Signature\" style= \"width:300px;height:150px;\"></Td></Tr>");
            }
            html.Append( "</Table>");
        }


        html.Append("<BR>");
        html.Append("<input type= \"button\" name= \"btnBack\" id= \"btnBack\" value= \"Back\" onClick= \"window.history.go(-1); return false;\" class='ui-button ui-widget ui-corner-all'>");


        ContentPlaceHolder cph;
        cph = (ContentPlaceHolder)Master.FindControl("ContentPlaceHolder1");
        cph.Controls.Add(new Literal { Text = html.ToString() });

    }

    private DataTable GetDataTop(String PickupID)
    {
        DataTable dt = null;
        BLL.GSOrderPickupDetail _BLL = new BLL.GSOrderPickupDetail();
        dt = _BLL.getGSOrderPickupDetail_Top(PickupID);
        return dt;
    }


    private DataTable GetDataBottom(String PickupID)
    {
        DataTable dt = null;
        BLL.GSOrderPickupDetail _BLL = new BLL.GSOrderPickupDetail();
        dt = _BLL.getGSOrderPickupDetail_Bottom(PickupID);
        return dt;
    }
}