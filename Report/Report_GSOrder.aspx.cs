using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Report_Report_GSOrder : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        genReport();


    }

    private bool genReport()
    {

        DataTable dtMap = new DataTable("GSOrder");  //*** DataTable Map DataSet.xsd ***//
        DataTable m_dt = (DataTable)Session["DATATABLE"];

        DataRow dr = null;
        dtMap.Columns.Add(new DataColumn("RTVData", typeof(string)));
        dtMap.Columns.Add(new DataColumn("CustName", typeof(string)));
        dtMap.Columns.Add(new DataColumn("GSOrderNo", typeof(string)));
        dtMap.Columns.Add(new DataColumn("CreatedDate", typeof(string)));
        dtMap.Columns.Add(new DataColumn("Remark", typeof(string)));
        dtMap.Columns.Add(new DataColumn("Description", typeof(string)));
        dtMap.Columns.Add(new DataColumn("ProdName", typeof(string)));
        dtMap.Columns.Add(new DataColumn("Barcode", typeof(System.Byte[])));




        for (int i = 0; i < (m_dt.Rows.Count); i++)
        {
            dr = dtMap.NewRow();


            FileStream fiStream = new FileStream(Server.MapPath("~/Barcode/" + m_dt.Rows[i]["TransBillNo"].ToString() + ".jpeg"), FileMode.Open, FileAccess.Read);
            BinaryReader binReader = new BinaryReader(fiStream);
            byte[] pic1 = { };
            pic1 = binReader.ReadBytes((int)fiStream.Length);

            fiStream.Close();
            binReader.Close();

            dr["RTVData"] = m_dt.Rows[i]["RTVData"];
            dr["CustName"] = m_dt.Rows[i]["CustName"];
            dr["GSOrderNo"] = m_dt.Rows[i]["GSOrderNo"];
            dr["CreatedDate"] = m_dt.Rows[i]["CreatedDate"];
            dr["Remark"] = m_dt.Rows[i]["Remark"];
            dr["Description"] = m_dt.Rows[i]["Description"];
            dr["ProdName"] = m_dt.Rows[i]["ProdName"];
            dr["Barcode"] = pic1;

            dtMap.Rows.Add(dr);
        }


        ReportDocument rpt = new ReportDocument();
        rpt.Load(Server.MapPath("~/Report/GSOrderReport.rpt"));

        foreach (CrystalDecisions.CrystalReports.Engine.Table crTable in rpt.Database.Tables)
        {
            TableLogOnInfo tableLogOnInfo = crTable.LogOnInfo;
            object connectionInfo = tableLogOnInfo.ConnectionInfo;
            crTable.ApplyLogOnInfo(tableLogOnInfo);
        }

        rpt.SetDataSource(dtMap);
        crVW.ReportSource = rpt;
        //  crVw.RefreshReport();

        return true;
    }
}