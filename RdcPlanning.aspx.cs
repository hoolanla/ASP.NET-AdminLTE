using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class customs_code_RdcPlanning : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["USER"] == null)
        {
            Response.Redirect("Authorize.aspx");
        }

        DataTable dt;
        BLL.RdcPlanning _Bll = new BLL.RdcPlanning();
        dt = _Bll.getRdcPlanning_All();
        RadGrid1.DataSource = dt;


    }

    protected void RadGrid1_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
    {


        if (e.Item is GridDataItem)
        {
            Label lbl = e.Item.FindControl("numberLabel") as Label;
            lbl.Text = (e.Item.ItemIndex + 1).ToString();
        }

    }
}