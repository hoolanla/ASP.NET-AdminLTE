<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Report_GSOrder.aspx.cs" Inherits="Report_Report_GSOrder" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <CR:CrystalReportViewer ID="crVW" runat="server" AutoDataBind="true" />
        </div>
        <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
                   <Report FileName="Report\GSOrderReport.rpt">
            </Report>
        </CR:CrystalReportSource>
    </form>
</body>
</html>
