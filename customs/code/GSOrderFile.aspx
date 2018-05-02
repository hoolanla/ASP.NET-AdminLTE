<%@ Page Title="" Language="C#" MasterPageFile="~/Home.master" AutoEventWireup="true" CodeFile="GSOrderFile.aspx.cs" Inherits="customs_code_GSOrderFile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <script>

 $(document).ready(function () {

 	$.fn.bootstrapBtn = $.fn.button.noConflict();

	var dialog;

	dialog = $( "#dialog-form" ).dialog({
      autoOpen: false,
      height: 200,
      width: 350,
      modal: true,
      title: "File attachment",
      buttons: {
        "Upload": addFile,
        Cancel: function() {
          dialog.dialog( "close" );
        }
      },
    });

    function addFile() {
    	$("#frmFile").submit();
    }

    $( "#btnFile" ).button().on( "click", function() {
	      dialog.dialog( "open" );
	});
 });

</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>

