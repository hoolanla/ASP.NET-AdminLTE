using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class customs_code_SaveOrder : System.Web.UI.Page
{
    MODEL.SaveOrder m_SaveOrder = new MODEL.SaveOrder();
    MODEL.BranchInfo m_Model_BranchInfo = new MODEL.BranchInfo();
    MODEL.CustomerInfo m_Model_customerInfo = new MODEL.CustomerInfo();

    BLL.SaveOrder _BLL = new BLL.SaveOrder();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["USER"] == null)
        {
            Response.Redirect("Authorize.aspx");
        }


        m_SaveOrder.Index = Request.Form["txtIndex"];
        m_SaveOrder.uid = "4";
        m_SaveOrder.CustId = Request.Form["selCust"];
	    m_SaveOrder.BranchId = Request.Form["selBranch"];
	    m_SaveOrder.PickupDate = Request.Form["txtPickupDate"];
	    m_SaveOrder.CheckDay = Request.Form["txtCheckDay"];
	    m_SaveOrder.RTV = Request.Form["txtRtvFile"];
	    m_SaveOrder.Remark = Request.Form["txtRemark"];
        m_SaveOrder.BillType = "Lotus GS";
        m_SaveOrder.ProfitCenter = "";
        m_SaveOrder.TransStatus = "9";
        m_SaveOrder.PaymentSatus = "9";
        m_SaveOrder.CheckerLoad = "1";
        m_SaveOrder.PODate = m_SaveOrder.PickupDate + " 00:00:00.000";
        m_SaveOrder.CreateBy = "GETDATE()";
        m_SaveOrder.CreateBy = m_SaveOrder.uid;
        m_SaveOrder.PO = m_SaveOrder.RTV;
        m_SaveOrder.Inv = "";

        //GET TransportBillNo & Customer Info
        DataTable DT_CustomerInfo;
        DT_CustomerInfo = _BLL.getCustomerInfo(m_SaveOrder.CustId);
        if(DT_CustomerInfo.Rows.Count > 0)
        {
            m_Model_customerInfo.CustCode = DT_CustomerInfo.Rows[0]["CustCode"].ToString();
            m_Model_customerInfo.CustName = DT_CustomerInfo.Rows[0]["CustName"].ToString();
            m_Model_customerInfo.Code= DT_CustomerInfo.Rows[0]["Code"].ToString();
            m_Model_customerInfo.RunningNo = DT_CustomerInfo.Rows[0]["RunningNo"].ToString();
            m_Model_customerInfo.Credit = DT_CustomerInfo.Rows[0]["Credit"].ToString();
        }

        //Get Branch Info
        DataTable DT_BranchInfo;
        DT_BranchInfo = _BLL.getBranchInfo(m_SaveOrder.BranchId);
        if(DT_BranchInfo.Rows.Count > 0)
        {
            m_Model_BranchInfo.MTBranchCode = DT_BranchInfo.Rows[0]["MTBranchCode"].ToString();
            m_Model_BranchInfo.MTName = DT_BranchInfo.Rows[0]["MTName"].ToString();
            m_Model_BranchInfo.MTBranchName = DT_BranchInfo.Rows[0]["MTBranchName"].ToString();
            m_Model_BranchInfo.Province = DT_BranchInfo.Rows[0]["Province"].ToString();
            m_Model_BranchInfo.NSBranchId = DT_BranchInfo.Rows[0]["NSBranchId"].ToString();
            m_Model_BranchInfo.NSBranchName = DT_BranchInfo.Rows[0]["NSBranchName"].ToString();
            m_Model_BranchInfo.RDCId = DT_BranchInfo.Rows[0]["RDCId"].ToString();
            m_Model_BranchInfo.Zone = DT_BranchInfo.Rows[0]["Zone"].ToString();
        }

        //Get GS No.
        String rwGSNO = null;
        rwGSNO = _BLL.getGSNo(m_SaveOrder);
        String RNO = genGSOrderNo(rwGSNO);
        m_SaveOrder.GS_RunningNo = RNO;

        //Insert GSOrder Header

        if(_BLL.InsertGSOrder_Header(m_SaveOrder))
        {
            //Update RNO
            _BLL.Update_RNO(m_SaveOrder);
        }


        //Get GSOrderId
        string gsOrderID = _BLL.getGSOrderID(m_SaveOrder);

        for (int i = 1; i == int.Parse(m_SaveOrder.Index);i++)
        {
            		String ProductId = Request.Form["selOrder" + i];
            MODEL.ProductInfo m_mod_ProductInfo = new MODEL.ProductInfo();
            DataTable dt;
            dt = _BLL.getProductInfo(ProductId);

            if (dt.Rows.Count > 0)
            {
                m_mod_ProductInfo.ProductName = dt.Rows[0]["ProductName"].ToString();
                m_mod_ProductInfo.Weight = dt.Rows[0]["Weight"].ToString();
                m_mod_ProductInfo.Volumn = dt.Rows[0]["Volumn"].ToString();
                m_mod_ProductInfo.Price = dt.Rows[0]["Price"].ToString();
                m_mod_ProductInfo.UOM = dt.Rows[0]["UOM"].ToString();
            }
        }

    }





    private string genGSOrderNo(string GSNo)
    {
        int tmp = Int32.Parse(GSNo);
        String GSCode = "GS-" + m_Model_BranchInfo.MTBranchCode;
        String RunningNo = tmp.ToString("D6");
        return GSCode + "-" + RunningNo;
    }
}