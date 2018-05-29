<%@ Page Title="" Language="C#" MasterPageFile="~/Home.master" AutoEventWireup="true" CodeFile="GSOrder.aspx.cs" Inherits="customs_code_GSOrder" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

       <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <script type="text/javascript">

            var radGrid1 = null;
           var radWindow1 = null;
            //var panelStep1 = null;
            //var panelStep2 = null;
 
            function pageLoad() {
                radGrid1 = $find("<%= RadGrid1.ClientID %>");
             radWindow1 = $find("<%= RadWindow1.ClientID %>");
               <%--    panelStep1 = $get("<%= FirstStepPanel.ClientID %>");
                panelStep2 = $get("<%= SecondStepPanel.ClientID %>");--%>
            }


            function openConfirmationWindow(carID) {
    radWindow1.set_title(carID);
    radWindow1.show();
}
function bookNowCloseClicking(sender, args) {
    radWindow1.close();
    togglePanels();
    radGrid1.get_masterTableView().fireCommand("UpdateCount", radWindow1.get_title());
    args.set_cancel(true);
}
function bookNowClicking(sender, args) {
    togglePanels();
    args.set_cancel(true);
}
function cancelClicking(sender, args) {
    radWindow1.close();
    args.set_cancel(true);
}
        </script>
    </telerik:RadCodeBlock>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">





    <%--   <asp:ScriptManager ID="ScriptManager1" runat="server" />   --%>
     <telerik:RadScriptManager runat="server" ID="RadScriptManager1" />
    <telerik:RadSkinManager ID="RadSkinManager1" runat="server" ShowChooser="false" />

 
    <telerik:RadGrid ID="RadGrid1" runat="server"  AllowPaging="True" AllowFilteringByColumn="False" AllowSorting="True" OnNeedDataSource="RadGrid1_NeedDataSource">

             <MasterTableView AutoGenerateColumns="False" TableLayout="Fixed">
                     <PagerStyle PageSizes="5,10" PagerTextFormat="{4}<strong>{5}</strong> cars matching your search criteria"
                            PageSizeLabelText="Cars per page:" />

                 <Columns>
                             <telerik:GridBoundColumn DataField="ID" HeaderText="No" UniqueName="ID"
                                 FilterControlWidth="60px">
                                <HeaderStyle Width="115px" />
                            </telerik:GridBoundColumn>

                

                            <telerik:GridBoundColumn DataField="OrderDate" HeaderText="Pickup date" UniqueName="OrderDate"
                                 FilterControlWidth="60px">
                                <HeaderStyle Width="115px" />
                            </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="CreatedDate" HeaderText="Pickup date" UniqueName="CreatedDate"
                                 FilterControlWidth="60px">
                                <HeaderStyle Width="115px" />
                            </telerik:GridBoundColumn>

                                    <telerik:GridBoundColumn DataField="CheckDay" HeaderText="Pickup date" UniqueName="CheckDay">
                              
                                <HeaderStyle Width="115px" />
                            </telerik:GridBoundColumn>

                              <telerik:GridBoundColumn DataField="GSOrderNo" HeaderText="Rn No" UniqueName="GSOrderNo"
                                 FilterControlWidth="60px">
                                <HeaderStyle Width="115px" />
                            </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="CustName" HeaderText="Rn No" UniqueName="CustName">
                                <HeaderStyle Width="115px" />
                            <FilterTemplate>
                                    <telerik:RadComboBox RenderMode="Lightweight" ID="CustNameCombo"  DataTextField="CustName"
                                        OnDataBound="CustNameCombo_DataBound" DataValueField="CustName"
                                        Height="200px" AppendDataBoundItems="true" SelectedValue='<%# ((GridItem)Container).OwnerTableView.GetColumn("CustName").CurrentFilterValue %>'
                                        runat="server" OnClientSelectedIndexChanged="CustNameComboIndexChanged">
                                        <Items>
                                            <telerik:RadComboBoxItem Text="Select a Customer" />
                                        </Items>
                                    </telerik:RadComboBox>
                                    <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
                                        <script type="text/javascript">
                                            function CustNameComboIndexChanged(sender, args) {
                                                var tableView = $find("<%# ((GridItem)Container).OwnerTableView.ClientID %>");
                                            tableView.filter("CustName", args.get_item().get_value(), "EqualTo");
                                        }
                                        </script>
                                    </telerik:RadScriptBlock>
                                </FilterTemplate>
                            </telerik:GridBoundColumn>

                       <telerik:GridTemplateColumn HeaderText="Detail" 
                                AllowFiltering="false">
                                <HeaderStyle Width="102px" />
                                <ItemTemplate>
                               <%--     <asp:LinkButton ID="BookButton" runat="server" Text="DETAIL" href="#" OnClientClick='<%# String.Format("openConfirmationWindow({0}); return false;", Eval("ID")) %>'
                                        CssClass="bookNowLink" />--%>

           <asp:LinkButton ID="LinkButton1" runat="server" Text="DETAIL" href=<%# String.Format("GSOrderDetail.aspx?ID={0}", Eval("ID")) %> ></asp:LinkButton>



                                </ItemTemplate>
                        </telerik:GridTemplateColumn>
                     

                 </Columns>



                 </MasterTableView>


    </telerik:RadGrid>
    




           <telerik:RadWindow RenderMode="Lightweight" ID="RadWindow1" runat="server" VisibleTitlebar="false" Modal="true" Width="550px" Height="380px"
                Behaviors="None" VisibleStatusbar="false">
                <ContentTemplate>
                    <asp:Panel ID="FirstStepPanel" runat="server">
                        <div class="bookNowFrame">
                            <div class="bookNowTitle">
                                Fill in the form to make your reservation
                            </div>
                            <hr class="lineSeparator" style="margin: 12px 0 12px 0" />
                            <table cellspacing="8">
                                <colgroup>
                                    <col width="110px" />
                                    <col width="150px" />
                                    <col />
                                    <col />
                                </colgroup>
                                <tr>
                                    <td>DATE OF RENT
                                    </td>
                                    <td>
                                        <telerik:RadDatePicker RenderMode="Lightweight" ID="DateOfRentPicker" Width="130px" runat="server" />
                                    </td>
                                    <td>RETURN DATE
                                    </td>
                                    <td>
                                        <telerik:RadDatePicker RenderMode="Lightweight" ID="ReturnDatePicker" Width="130px" runat="server" />
                                    </td>
                                </tr>
                            </table>
                            <hr class="lineSeparator" style="margin: 12px 0 12px 0" />
                            <table cellspacing="8">
                                <colgroup>
                                    <col width="110px" />
                                    <col />
                                </colgroup>
                                <tr>
                                    <td>FIRST NAME
                                    </td>
                                    <td>
                                        <telerik:RadTextBox RenderMode="Lightweight" ID="FirstNameTextBox" runat="server" Width="190px" /><br />
                                    </td>
                                </tr>
                                <tr>
                                    <td>LAST NAME
                                    </td>
                                    <td>
                                        <telerik:RadTextBox RenderMode="Lightweight" ID="LastNameTextBox" runat="server" Width="190px" /><br />
                                    </td>
                                </tr>
                                <tr>
                                    <td>EMAIL
                                    </td>
                                    <td>
                                        <telerik:RadTextBox RenderMode="Lightweight" ID="EmailTextBox" runat="server" Width="190px" /><br />
                                    </td>
                                </tr>
                            </table>
                            <hr class="lineSeparator" style="margin: 12px 0 15px 0" />
                            <telerik:RadButton RenderMode="Lightweight" ID="BookNowButton" runat="server" Text="Book Now"
                                Width="100px" OnClientClicking="bookNowClicking" UseSubmitBehavior="false" />
                            <telerik:RadButton RenderMode="Lightweight" ID="CancelButton" runat="server" Text="Cancel"
                                Width="100px" OnClientClicking="cancelClicking" UseSubmitBehavior="false" />
                        </div>
                    </asp:Panel>
                    <asp:Panel ID="SecondStepPanel" runat="server" Style="display: none; padding: 120px 20px 0 30px; width: 480px;">
                        <div style="float: left;">
                            <img src="Images/Confirmation.png" alt="Confirmation sign" />
                        </div>
                        <div style="float: left; padding: 10px 0 0 20px;">
                            <div class="bookNowComplete">
                                You have successfully made your reservation!
                            </div>
                            <hr class="lineSeparator" style="margin: 10px 10px 20px 0" />
                            <telerik:RadButton RenderMode="Lightweight" ID="BookNowCloseButton" runat="server" Text="Close"
                                Width="100px" OnClientClicking="bookNowCloseClicking" UseSubmitBehavior="false" />
                        </div>
                        <div style="clear: both">
                        </div>
                    </asp:Panel>
                </ContentTemplate>
            </telerik:RadWindow>

</asp:Content>

