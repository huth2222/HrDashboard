$(document).ready(function () {
    var d = new Date();
    var month = d.getMonth() + 1;
    var day = d.getDate();
    var today = d.getFullYear() + '-' + (month < 10 ? '0' : '') + month + '-' + (day < 10 ? '0' : '') + day;

    $.ajax({
        type: "GET",
        url: origin + "/Attendance/GetMaxDate",
        dataType: "JSON",
        contentType: "application/json; charset=utf-8",
        success: function (res) {

            var TimeMaxDate = res[0].timeMaxDate;
            var TimeMinDate = res[0].timeMinDate;
            var TimeMaxDateTimeFormat = res[0].timeMaxDateTimeFormat;
            var ShiftMaxDate = res[0].shiftMaxDate;
            var ShiftMaxDateFormat = res[0].shiftMaxDateFormat;
            var MaxDateSLeave = res[0].maxDateSLeave;

            if (TimeMaxDate != today) {
                if (jQuery(window).width() < 1250) {
                    $('#updateAtt').html('<span style="font-size: 13px;"><span style="color:red;">Time Attendance ล่าสุด : ' + TimeMaxDateTimeFormat + ' </span><span style="color:blue;">|</span><span style="color:red;"> ' +
                        'Shift ล่าสุด : ' + ShiftMaxDateFormat + ' </span><span style="color:blue;">|</span><span style="color:red;"> Leave ล่าสุด : ' + MaxDateSLeave + ' (กรุณา Update ข้อมูล)</span></span>');
                } else {
                    $('#updateAtt').html('<span style="color:red;">Time Attendance ล่าสุด : ' + TimeMaxDateTimeFormat + ' </span><span style="color:blue;">|</span><span style="color:red;"> ' +
                        'Shift ล่าสุด : ' + ShiftMaxDateFormat + ' </span><span style="color:blue;">|</span><span style="color:red;"> Leave ล่าสุด : ' + MaxDateSLeave + ' (กรุณา Update ข้อมูล)</span>');
                }
                
            } else {
                $('#updateAtt').html('Time Attendance ล่าสุด : ' + TimeMaxDateTimeFormat + ' | ' +
                    'Shift ล่าสุด : ' + ShiftMaxDateFormat + ' | Leave ล่าสุด : ' + MaxDateSLeave);
            }
            //$('#updateMinDate').val(minDate);
            //$('#updateMaxDate').val(TimeMaxDate);
            //$('#updateMaxDateTime').val(maxDateTime);
            //alert(TimeMaxDate + '\n' + today);
        }
    });
});