<%@ Page Title="" Language="C#" MasterPageFile="~/Home.master" AutoEventWireup="true" CodeFile="GSOrderAdd.aspx.cs" Inherits="customs_code_GSOrderAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <form id="frmOrder" name="frmOrder" method="post" action="index.php?option=saveorder">
        <table width="100%" border="0" cellspacing="10" cellpadding="10" class="table-main-form">
            <tbody>
                <tr>
                    <td width="10%">Customer</td>
                    <td width="90%">

                        <select name="selCust" id="selCust">



                            <option value="1">1</option>
                    </td>
                </tr>
                <tr>
                    <td>Branch</td>
                    <td>


                        <select name="selBranch" id="selBranch">
                        </select>


                    </td>
                </tr>

                <tr>
                    <td>Pickup date</td>
                    <td>
                        <input type="text" id="datepicker" name="datepicker" size="10">
                    </td>
                </tr>
                <tr>
                    <td>Check days</td>
                    <td>
                        <div style="display: inline-block; margin-right: 5px; width: 60px;">
                            <input type="text" name="txtCheckDay" id="txtCheckDay" maxlength="3" size="3" value="0" onchange="checkDayToEndDate();"></div>
                        <div style="display: inline-block; width: 150px;">
                            <p id="end_date" name="end_date">End date:</p>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>RN No.</td>
                    <td>
                        <table>
                            <tbody>
                                <tr>
                                    <td>
                                        <input type="text" id="txtRtvFile" name="txtRtvFile" size="15">
                                    </td>
                                    <td>&nbsp;<input type="button" name="btnRTV" id="btnRTV" value="Open RN" onclick=" window.open('./customs/code/openRTV.html', '_blank')" class='ui-button ui-widget ui-corner-all'>
                                    </td>
                                </tr>
                                <tbody>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>Remark</td>
                    <td>

                        <textarea name="txtRemark" id="txtRemark"></textarea></td>
                </tr>
                <tr>
                    <td>Order</td>
                    <td>
                        <table width="120" border="0">
                            <tbody>
                                <tr>
                                    <td>
                                        <input type="button" name="btnAdd" id="btnAdd" value="Add" onclick="AddOrder()" class='ui-button ui-widget ui-corner-all'></td>
                                    <td>
                                        <input type="button" name="btnRemove" id="btnRemove" value="Remove" onclick="RemoveOrder()" class='ui-button ui-widget ui-corner-all'></td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <input type="text" name="txtIndex" id="txtIndex" value="0" hidden>
                    </td>
                    <td>
                        <table width="500" border="0" id="tOrder" class="table table-hover">
                            <thead>
                                <tr>
                                    <th width="50">No.</th>
                                    <th width="150">Order</th>
                                    <th width="300">Label</th>
                                </tr>
                            </thead>
                            <tbody id="tbOrder">
                            </tbody>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <table width="130" border="0">
                            <tbody>
                                <tr>
                                    <td>
                                        <input type="submit" name="submit" id="submit" value="Confirm" class='ui-button ui-widget ui-corner-all'></td>
                                    <td>
                                        <input type="reset" name="reset" id="reset" value="Cancel" class='ui-button ui-widget ui-corner-all'></td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </tbody>
        </table>
    </form>



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

        function AddOrder() {

            //var r = document.createElement('span');
            var index = parseInt(document.getElementById("txtIndex").value);

            index = index + 1;
            var tr = document.createElement("TR");
            tr.id = "TROrder" + index;

            var td1 = document.createElement("TD");

            var tN = document.createElement("DIV");
            tN.setAttribute("id", "divNo" + index);
            tN.innerHTML = index;
            td1.appendChild(tN);
            tr.appendChild(td1);



            var td2 = document.createElement("TD");

            var select = document.createElement("SELECT");
            select.setAttribute("name", "selOrder" + index);
            select.setAttribute("id", "selOrder" + index);

            var option = document.createElement("OPTION");
            option.setAttribute("value", "1");
            option.text = "name";
            select.appendChild(option);

            td2.appendChild(select);
            tr.appendChild(td2);
            var td4 = document.createElement("TD");


            var maxChar = 400;



            var tL = document.createElement("textarea");
            tL.setAttribute("Name", "txtlbl" + index);
            tL.setAttribute("id", "txtlbl" + index);
            tL.setAttribute("rows", "4");
            tL.setAttribute("cols", "80");
            tL.setAttribute("maxlength", maxChar);
            tL.setAttribute("onkeyup", "textCounter(" + "txtlbl" + index + "," + "textarea_feedback" + index + "," + maxChar + ");");
            td4.appendChild(tL);


            var td5 = document.createElement("TD");
            var tP = document.createElement("P");
            tP.setAttribute("Name", "textarea_feedback" + index);
            tP.setAttribute("id", "textarea_feedback" + index);
            tP.innerHTML = maxChar + " characters remaining";
            td4.appendChild(tP);
            tr.appendChild(td4);


            document.getElementById("tbOrder").appendChild(tr);

            document.getElementById("txtIndex").value = index;

            if (index != 0) {
                document.getElementById("btnRemove").disabled = false;
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

            $("#datepicker").datepicker({
                format: 'dd/mm/yyyy'
            });
        });

    </script>





</asp:Content>

