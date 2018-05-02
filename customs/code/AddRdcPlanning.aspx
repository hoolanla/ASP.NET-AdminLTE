<%@ Page Title="" Language="C#" MasterPageFile="~/Home.master" AutoEventWireup="true" CodeFile="AddRdcPlanning.aspx.cs" Inherits="customs_code_AddRdcPlanning" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">


<script type='text/javascript'>

$( function() {
    $( "#datepicker" ).datepicker({ format: 'yyyy-mm-dd'});
  } );

function RemoveOrder()
{
	var index = parseInt(document.getElementById("txtIndex").value);

	var element = document.getElementById("TROrder" + index);
	element.parentNode.removeChild(element);
	
	index = index - 1;
	document.getElementById("txtIndex").value = index;
	
	if (index == 0){
		document.getElementById("btnRemove").disabled = true;
	}
}

function AddOrder()
{

	var index = parseInt(document.getElementById("txtIndex").value);

	index = index + 1;
	var tr = document.createElement("TR");
	tr.id = "TROrder"+index;
	
	var td1 = document.createElement("TD");
	
	var tN = document.createElement("DIV");
		tN.setAttribute("id", "divNo" + index);
		tN.innerHTML = index;
	td1.appendChild(tN);
	tr.appendChild(td1);
	
	var td2 = document.createElement("TD");
		

			   var select = document.createElement("SELECT"); 
			   select.setAttribute("name","selOrder"+ index); 
			   select.setAttribute("id", "selOrder" + index); 
			   

					var option = document.createElement("OPTION");
					option.setAttribute("value","test"); 
					option.text ="Test";
					select.appendChild(option);
	
		

	td2.appendChild(select);
	tr.appendChild(td2);

	var td4 = document.createElement("TD");
	var tL = document.createElement("INPUT");
		tL.setAttribute("type", "text");
		tL.setAttribute("Name", "txtRemark" + index);
		tL.setAttribute("id", "txtRemark" + index);
		td4.appendChild(tL);
	tr.appendChild(td4);
	
	
	document.getElementById("tbOrder").appendChild(tr);
	
	document.getElementById("txtIndex").value = index;
	
	if (index != 0){
		document.getElementById("btnRemove").disabled = false;
	}
}
</script>




</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <form id="form1" name="form1" method="post" action="index.php?option=saverdcplanning">
  <table width="100%" class="table-main-form">
    <tbody>
      <tr>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Pickup date</td>
        <td>
        <input type="text" name="txtPickupDate" id="datepicker">
        </td>
      </tr>
      <tr>
        <td>Pickup Time</td>
        <td>
        <input type="text" name="txtPickupTime" id="txtPickupTime"></td>
      </tr>
      <tr>
        <td>Truck</td>
        	<td>
              
       
            <select name="selTruck" id="selTruck">
        
              
               <option value="1">"1"</option>
            
                </select>
            </td>
      </tr>
      <tr>
        <td>Remark</td>
        <td>
        <input type="text" name="txtRemark" id="textfield2"></td>
      </tr>
      <tr>
        <td>&nbsp;</td>
        <td><table width="120" border="0" cellspacing="1" cellpadding="1">
          <tbody>
            <tr>
              <td><input type="button" name="btnAdd" id="btnAdd" value="ADD" onclick="AddOrder(); "class="ui-button ui-widget ui-corner-all" ></td>
              <td><input type="button" name="btnRemove" id="btnRemove" value="Remove" onclick="RemoveOrder();" class="ui-button ui-widget ui-corner-all"></td>
            </tr>
          </tbody>
        </table></td>
      </tr>
      <tr>
        <td>
        <input type="text" name="txtIndex" id="txtIndex" value="0" hidden>
        </td>
        <td>
          <table width="450" class="table table-hover">
              <thead>
                <tr>
                  <th width="100">No.</th>
                  <th width="150">GS Order No.</th>
                  <th width="200">Remark</th>
                </tr>
              </thead>
            <tbody id="tbOrder">
            </tbody>
          </table>
        </td>
      </tr>
      <tr>
        <td>&nbsp;</td>
        <td><table width="120" border="0" cellspacing="1" cellpadding="1">
          <tbody>
            <tr>
              <td><input type="submit" name="submit" id="submit" value="Submit" class="ui-button ui-widget ui-corner-all"></td>
              <td><input type="reset" name="reset" id="reset" value="Reset" class="ui-button ui-widget ui-corner-all"></td>
            </tr>
          </tbody>
        </table></td>
      </tr>
      <tr>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
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


</asp:Content>

