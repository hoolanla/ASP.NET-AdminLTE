
var getEmailUrl = "./GSOrderAdd.aspx/getCustomer";
var selCust = $("#selCust");
var selBranch = $("#selBranch");


function getCustomer() {

    $("#selCust").find("option").remove();
 //   selCust.append($('<option></option>').val(-1).html('<-- เลือก -->').prop('selected', true));
    return $.ajax({
        type: "POST",
        url: "GSOrderAdd.aspx/getCustomer",
        data: "{}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {

            if (data.d) {
     
                $.each(data.d, function (index, item) {
                    $("#selCust").append($('<option></option>').val(item.ID).html(item.CustName));

                });
            }
        }
    });
}


function getBranch() {

    $("#selBranch").find("option").remove();
 //   selBranch.append($('<option></option>').val(-1).html('<-- เลือก -->').prop('selected', true));
    return $.ajax({
        type: "POST",
        url: "GSOrderAdd.aspx/getBranch",
        data: "{}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {

            if (data.d) {
                $.each(data.d, function (index, item) {
                    $("#selBranch").append($('<option></option>').val(item.ID).html(item.BranchName));

                });
            }
        }
    });
}

$(document).ready(function () {
    //Entire document/Dom/scripts are loaded now you can bind
  //  $("#datepicker").datepicker();

    getCustomer();
    getBranch();


});





