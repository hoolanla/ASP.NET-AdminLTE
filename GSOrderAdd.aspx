<%@ Page Title="" Language="C#" MasterPageFile="~/Home.master" AutoEventWireup="true" CodeFile="GSOrderAdd.aspx.cs" Inherits="customs_code_GSOrderAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
       <script src="<%=ResolveClientUrl("scriptpages/GSOrderAdd.js")%>"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">



    <script type='text/javascript'>



        //$( function() {
        //    $( "#datepicker" ).datepicker({ format: 'yyyy-mm-dd'});
        //       });






        /*
        $( function() {
            $( "#datepicker" ).datepicker({ dateFormat: 'yy-mm-dd' });
        
            $( "#format" ).on( "change", function() {
                alert('d');
              $( "#datepicker" ).datepicker( "option", "dateFormat", "yy-mm-dd" );
            });
          } );
        */
        function RemoveOrder() {
            var index = parseInt(document.getElementById("txtIndex").value);

            var element = document.getElementById("TROrder" + index);
            element.parentNode.removeChild(element);

            index = index - 1;
            document.getElementById("txtIndex").value = index;

            if (index == 0) {
                document.getElementById("btnRemove").disabled = true;
            }
        }

  

        function textCounter(txtArea, txtRemain, text_max) {
            var text_length = $(txtArea).val().length;
            var text_remaining = text_max - text_length;

            $(txtRemain).html(text_remaining + ' characters remaining');
        }

        function checkDayToEndDate() {
            var date = new Date();
            var c_days = $('#txtCheckDay').val();
            var e_date = addDays(date, c_days);
            //alert(c_days);
            //alert(e_date);
            e_date = setDateFormat(e_date);
            $('#end_date').html('End date: ' + e_date);
        }

        function addDays(date, days) {
            var result = date;
            //alert(result);
            result.setDate(result.getDate() + parseInt(days));
            //alert(result);
            return result;
        }

        function setDateFormat(today) {
            //var today = new Date();
            var dd = today.getDate();
            var mm = today.getMonth() + 1; //January is 0!
            var yyyy = today.getFullYear();

            if (dd < 10) {
                dd = '0' + dd
            }

            if (mm < 10) {
                mm = '0' + mm
            }

            today = yyyy + '-' + mm + '-' + dd;
            return today;
        }

        $(document).ready(function () {

      $( "#datepicker" ).datepicker({ format: 'yyyy-mm-dd'});
        });

    </script>





</asp:Content>

