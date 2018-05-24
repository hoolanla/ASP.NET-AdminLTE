

function getTruck() {

    $("#selTruck").find("option").remove();
    //   selCust.append($('<option></option>').val(-1).html('<-- เลือก -->').prop('selected', true));
    return $.ajax({
        type: "POST",
        url: "AddRdcPlanning.aspx/getTruck",
        data: "{}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {

            if (data.d) {

                $.each(data.d, function (index, item) {
                    $("#selTruck").append($('<option></option>').val(item.ID).html(item.TruckNo));

                });
            }
        }
    });
}




$(document).ready(function () {
    //Entire document/Dom/scripts are loaded now you can bind
    //  $("#datepicker").datepicker();

    getTruck();
  
    $(function () {
        $("#datepicker").datepicker({ format: 'yyyy-mm-dd' });
    });

});
