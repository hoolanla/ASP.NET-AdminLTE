using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void LogIn(object sender, EventArgs e)
    {
        String _userName, _password;
        _userName = UserName.Text.ToString();
        _password = Password.Text.ToString();
        DataTable dt;
        BLL.GSOrder _Bll = new BLL.GSOrder();
        dt = _Bll.getUSER_Login(_userName,_password);
        
        if(dt.Rows.Count > 0 )
        {

            Session["USER"] = dt.Rows[0]["Login"].ToString();
            Response.Redirect("GSOrder.aspx");
        }

    }
}