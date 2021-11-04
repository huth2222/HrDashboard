function OnDel(emp_shift_temp_id) {
    // $('#tr_' + emp_shift_temp_id).css("background-color", "yellow");
    // $('#tr_' + emp_shift_temp_id).css("text-decoration", "line-through");
    $('#tr_' + emp_shift_temp_id).hide();
$.ajax({
    type: "GET",
    url: origin + "/Import/DelTemp/" + emp_shift_temp_id,
    dataType: "JSON",
    contentType: "application/json; charset=utf-8",
    success: function (res) {

        

    }
});
}