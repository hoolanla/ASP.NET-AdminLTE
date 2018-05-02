using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class RdcReceiveList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        DataTable dt;
        BLL.RdcRecieveList _Bll = new BLL.RdcRecieveList();
        dt = _Bll.getRdcRecieveList_All();
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

    protected void RadGrid1_PreRender(object sender, EventArgs e)
    {

        RadGrid1.MasterTableView.GetColumn("ID").Visible = false;
    }
}