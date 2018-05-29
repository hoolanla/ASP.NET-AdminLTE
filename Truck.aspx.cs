using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Telerik.Web.UI;

public partial class customs_code_Truck : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["USER"] == null)
        {
            Response.Redirect("Authorize.aspx");
        }

        DataTable dt;
        BLL.Truck _Bll = new BLL.Truck();
        dt = _Bll.getTruck_All();
        RadGrid1.DataSource = dt;
   
    }


    protected void CustNameCombo_DataBound(object sender, EventArgs e)
    {
        ////RadComboBox combo = sender as RadComboBox;
        ////foreach (RadComboBoxItem item in combo.Items)
        ////{
        ////    //  item.ImageUrl = String.Format("~/Grid/Examples/Overview/Images/SmallLogos/{0}.png", NormalizeValue(item.Text));
        ////}
    }




    protected void RadGrid1_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {

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