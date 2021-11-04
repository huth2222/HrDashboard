function OnEdit(emp_shift_temp_id,old_emp_shift_id, old_shift_id, old_start_date, old_end_date, new_shift_id, emp_id, sCount) {
    // alert(sCount);
    // alert(old_start_date);
    //   10/2/2564 0:00:00
    var n1 = old_start_date.indexOf("/");
    var OSday = old_start_date.substring(0, n1);
    var n2 = old_start_date.substring(n1 + 1);
    var n3 = n2.indexOf("/");
    var OSmonth = n2.substring(0, n3);
    var OSyear = (parseInt(n2.substring(n3 + 1).substring(0, 4)) > 2500 ? parseInt(n2.substring(n3 + 1).substring(0, 4)) - 543 : parseInt(n2.substring(n3 + 1).substring(0, 4)));
    var OSdate = (OSyear + '-' + (OSmonth <= 9 ? '0' + OSmonth : OSmonth) + '-' + (OSday <= 9 ? '0' + OSday : OSday));

    var p1 = old_end_date.indexOf("/");
    var OEday = old_end_date.substring(0, p1);
    var p2 = old_end_date.substring(p1 + 1);
    var p3 = p2.indexOf("/");
    var OEmonth = p2.substring(0, p3);
    var OEyear = (parseInt(n2.substring(p3 + 1).substring(0, 4)) > 2500 ? parseInt(p2.substring(p3 + 1).substring(0, 4)) - 543 : parseInt(n2.substring(p3 + 1).substring(0, 4)));
    var OEdate = (OEyear + '-' + (OEmonth <= 9 ? '0' + OEmonth : OEmonth) + '-' + (OEday <= 9 ? '0' + OEday : OEday));

    // var OEmonth = old_end_date.getMonth() + 1;
    // var OEday = old_end_date.getDate();
    // var OEyear = old_end_date.getFullYear();
    // var OEdate = (OEyear + '-' + (OEmonth <= 9 ? '0' + OEmonth : OEmonth) + '-' + (OEday <= 9 ? '0' + OEday : OEday));

    $('#emp_shift_temp_id').val(emp_shift_temp_id);
    $('#old_emp_shift_id').val(old_emp_shift_id);
    $('#oldShift').val(old_shift_id);
    $('#oldStartDate').val(OSdate);
    $('#oldEndDate').val(OEdate);
    $('#newShift').val(new_shift_id);
    $('#claerID').html('<center style="color: red;font-size:20px;">' + emp_id + '</center>');

    $('tr').css("background-color", "");

    $('#tr_' + emp_shift_temp_id).css("background-color", "yellow");
    // alert(emp_shift_temp_id);

    $('#newShift').focus();
    setTimeout(() => {
        
    }, 1000);
    // alert(OSdate);
}