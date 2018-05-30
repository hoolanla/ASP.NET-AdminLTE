using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class saveRdcPlanning : System.Web.UI.Page
{

    MODEL.SaveRdcPlaning m_SaveRdcPlanning = new MODEL.SaveRdcPlaning();
    BLL.SaveRdcPlaning _BLL = new BLL.SaveRdcPlaning();

    protected void Page_Load(object sender, EventArgs e)
    {
        m_SaveRdcPlanning.Index =  Request.Form["txtIndex"];
        m_SaveRdcPlanning.PickupDate = Request.Form["txtPickupDate"];
        m_SaveRdcPlanning.PickupDate  += " 00:00:00.000";
	    m_SaveRdcPlanning.PickupTime = Request.Form["txtPickupTime"];
        m_SaveRdcPlanning.TruckID = Request.Form["selTruck"];
        m_SaveRdcPlanning.Remark = Request.Form["txtRemark"];
        //m_SaveRdcPlanning.CreatedDate = 

        //Get GS No.

        DataTable _DT;
        _DT = _BLL.getGSNo(m_SaveRdcPlanning);
        if(_DT.Rows.Count > 0)
        {
            m_SaveRdcPlanning.RdcCode = _DT.Rows[0]["RDCCode"].ToString();
            m_SaveRdcPlanning.RdcID = _DT.Rows[0]["RDCID"].ToString();
            m_SaveRdcPlanning.Rno = _DT.Rows[0]["Rno"].ToString();
        }

        m_SaveRdcPlanning.Pno = genPNo(m_SaveRdcPlanning.RdcCode, m_SaveRdcPlanning.Rno);

        //Insert GSOrder Header
        _BLL.InsertRdcPlaning_Header(m_SaveRdcPlanning);

        _BLL.Update_WebUserRDC(m_SaveRdcPlanning);

      _DT =  _BLL.getID_RdcPlaning(m_SaveRdcPlanning);
        if(_DT.Rows.Count > 0)
        {
            m_SaveRdcPlanning.PlaningID = _DT.Rows[0]["ID"].ToString();
        }

        for (int i = 1; i <= int.Parse(m_SaveRdcPlanning.Index); i++)
        {


            m_SaveRdcPlanning.GSOrderID = Request.Form["selOrder" + i];
            m_SaveRdcPlanning.Remark = Request.Form["txtRemark" + i];

            _BLL.InsertRdcPlaning_Detail(m_SaveRdcPlanning);
            _BLL.Update_GSOrderStatus(m_SaveRdcPlanning);
            _BLL.Update_GSOrderDetailStatus(m_SaveRdcPlanning);

        }


        }

    private string genPNo(string RdcCode,string RdcNo)
    {
        int tmp = Int32.Parse(RdcNo);
        string PCode = "P-" + RdcCode;
        String RunningNo = tmp.ToString("D6");
        return PCode + "-" + RunningNo;
    }
}