$(document).ready(function () {
    if (window.matchMedia("(min-width: 993px)").matches) {
        var width = document.body.clientWidth;
        // $('#manpower_tomount').attr("width", width - (20 * (width / 100)));
        // $('#manpower_listDept').attr("width", width - (20 * (width / 100)));
        $('#manpower_line').attr("width", width - (75 * (width / 100)));
        $('#manpower_12pback').attr("width", width - (20 * (width / 100)));
        $('#manpower_listDept').attr("width", 3000);
        $('#manpower_siteDept').attr("width", 2000);
    }
    if (window.matchMedia("(max-width: 994px)").matches) {
        var width = document.body.clientWidth;
        // $('#manpower_tomount').attr("width", width - (20 * (width / 100)));
        // $('#manpower_listDept').attr("width", (95 * (width / 100)));
        $('#manpower_line').attr("width", width - (75 * (width / 100)));
        $('#manpower_12pback').attr("width", width - (10 * (width / 100)));
        $('#manpower_listDept').attr("width", 3000);
        $('#manpower_siteDept').attr("width", 2000);
    }
    // $('#div_site').hide();
    var url = window.location.href;

    var AttUrl = url.indexOf('Attendance');
    var ManUrl = url.indexOf('Manpower');
    var ManGrapUrl = url.indexOf('LPS');
    var ManTargetUrl = url.indexOf('Target');
    var ImpUrl = url.indexOf('Import');
    // alert('AttUrl = '+AttUrl + '\n' + 'ManUrl = '+ManUrl);
    //alert(ImpUrl);
    if ($('#sesionCompany').val() == 'all') {


        if (ManUrl > 0) {
            // alert('Manpower');
            $('#menu_att').removeClass('active');
            $('#menu_Import').removeClass('active');
            $('#menu_man').addClass('active');
            $('#block_man').css("display", "block");
            $('#li_man').addClass('menu-open');
            if (ManGrapUrl > 0) {
                $('#menu_manpower').addClass('active');
                $('#menu_mantarget').removeClass('active');
            } else if (ManTargetUrl > 0) {
                $('#menu_manpower').removeClass('active');
                $('#menu_mantarget').addClass('active');
            }

        } else if (ManTargetUrl > 0) {
            $('#menu_man').addClass('active');
            $('#menu_Import').removeClass('active');
            $('#menu_manpower').removeClass('active');
            $('#menu_att').removeClass('active');

        } else if (AttUrl > 0) {
            $('#menu_man').removeClass('active');
            $('#menu_Import').removeClass('active');
            $('#menu_manpower').removeClass('active');
            $('#menu_mantarget').removeClass('active');
            $('#menu_att').addClass('active');
            // if ($('#sesionCompany').val() == 'all') {
            //     alert('กำลังพัฒนาระบบ');
            //     window.location.href = origin + '/Manpower/Index';
            // }

        } else if (ImpUrl > 0) {
            // alert();
            $('#menu_man').removeClass('active');
            $('#menu_att').removeClass('active');
            $('#menu_mantarget').removeClass('active');
            $('#menu_manpower').removeClass('active');
            $('#menu_import').addClass('active');
        }
        // alert($('#sesionCompany').val());
    } else {
        if (ManUrl > 0) {
            // alert('Manpower');

    
  
           
                $('#menu_manpower').addClass('active');
                $('#menu_mantarget').removeClass('active');
                $('#menu_Import').removeClass('active');

        }else if (AttUrl > 0) {

            $('#menu_Import').removeClass('active');
            $('#menu_manpower').removeClass('active');
            $('#menu_att').addClass('active');
            

        } else if (ImpUrl > 0) {
            // alert();
            $('#menu_att').removeClass('active');

            $('#menu_manpower').removeClass('active');
            $('#menu_import').addClass('active');
        }
    }




    //**************************************************** */

    $('#mountSelect').click(function () {
        $('#MonthPicker_Button_mountSelect').click();
    });
});