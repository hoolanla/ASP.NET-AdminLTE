using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Telerik.Web.UI;
public partial class customs_code_GSOrder : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {


        DataTable dt;
        BLL.GSOrder _Bll = new BLL.GSOrder();
        dt = _Bll.getGSOder_All();
        RadGrid1.DataSource = dt;


    }

    protected void CustNameCombo_DataBound(object sender, EventArgs e)
    {
        RadComboBox combo = sender as RadComboBox;
        foreach (RadComboBoxItem item in combo.Items)
        {
          //  item.ImageUrl = String.Format("~/Grid/Examples/Overview/Images/SmallLogos/{0}.png", NormalizeValue(item.Text));
        }
    }



    protected void RadGrid1_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {

    }
}