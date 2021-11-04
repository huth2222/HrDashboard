$(document).ready(function () {
    if ($('#checkError').val() == 0) {
        $('#clearError').prop('disabled', true);
        $('#newShift').prop('disabled', true);
        $('#newStartDate').prop('disabled', true);
        $('#newEndDate').prop('disabled', true);
        $('#btn_submit').prop('disabled', true);
    } else {
        $('#clearError').prop('disabled', false);
        $('#newShift').prop('disabled', false);
        $('#newStartDate').prop('disabled', false);
        $('#newEndDate').prop('disabled', false);
        $('#btn_submit').prop('disabled', false);
    }
    if (jQuery(window).width() < 1250) {
        $('#btn_submit').html('บันทึก');
    } else {
        $('#btn_submit').html('บันทึกการแก้ไข');
    }
    
    $('#export').click(function () {
        window.location.href = origin + '/asset/dist/export/HR Dashboard import format.xlsx';
    });
    $('#inputGroupFile04').on('change', function () {
        var fileName = $(this).val().substr(12);
        // var fileName = 'Test.xx';
        $(this).next('.custom-file-label').html(fileName);
    })


});

