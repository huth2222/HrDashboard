$(document).ready(function () {

      var d = new Date();
      var h = d.getHours();
      if (h <= 9) {
          h = "0" + h;
      }
      var m = d.getMinutes();
      if (m <= 9) {
          m = "0" + m;
      }
      var t = h + ":" + m;
      // alert(t);
      if (t >= "05:00" && t <= "17:00") {
          // alert(t);
          $('#shiftSelect').val(1);
      } else {
          //$('#shiftSelect').val(2);
          $('#shiftSelect').val(1);
      }

        // var locat = origin + "/Home/GetDeptListDayByDate/" + getdate + "/all";
        // alert(locat);
    
    

    
     //var today = '2021-02-22';
    
    
    $('#timein').val(0);
    $('#lost').val(0);
    $('#leave').val(0);
    $('#time_late').val(0);

    $('#div_allPercentDay').html('');
    // var html_allPercentDay = '<center><canvas id="allPercentDay" style="min-height: 175px; height: 175px; max-height: 175px; max-width: 600px;"></canvas></center>';
    // $('#div_allPercentDay').html(html_allPercentDay);

    $('#div_deptListDay').html('');
    // var html_deptListDay = '<canvas id="deptListDay" style="min-height: 250px; height: 250px; max-height: 250px; max-width: 100%;"></canvas>';
    // $('#div_deptListDay').html(html_deptListDay);

    $('#div_all30Day').html('');
    //     var html_all30Day = '<canvas id="all30Day" style="min-height: 250px; height: 250px; max-height: 250px; max-width: 100%;"></canvas>';
    // $('#div_all30Day').html(html_all30Day);
    
    $('#div_allYear').html('');
    // var html_allYear = '<canvas id="all1Year" style="min-height: 250px; height: 250px; max-height: 250px; max-width: 100%;"></canvas>';
    // $('#div_allYear').html(html_allYear);
    var local = origin + "/Attendance/GetMaxDate";
    // alert(local);
$.ajax({
    type: "GET",
    url: local,
    dataType: "JSON",
    contentType: "application/json; charset=utf-8",
    success: function (res) {
        
        var dateImport = res[0].timeMaxDate;

        var d = new Date();
        var month = d.getMonth() + 1;
        var day = d.getDate();
        var today = d.getFullYear() + '-' + (month < 10 ? '0' : '') + month + '-' + (day < 10 ? '0' : '') + day;
        //var today2 = '2021-02-23';
        if (dateImport < today) {
            alert('The date of importing the latest attendance data is : ' + dateImport.substring(8) + '/' + dateImport.substring(5, 7) + '/' + dateImport.substring(0, 4));
        }        
        $('#dateSelect').val(dateImport);
        $('#sec').val(dateImport);
        var getShift = $('#shiftSelect').val();
        
        setTimeout(() => {
            // alert();
            AttAuto(dateImport, getShift);
        }, 1000);
    }
});
    

    
    $('#dateSelect').change(function () {
        $.ajax({
            type: "GET",
            url: local,
            dataType: "JSON",
            contentType: "application/json; charset=utf-8",
            success: function (res) {
                var sec = $('#sec').val();
                var dateImportMax = res[0].timeMaxDate;
                var dateImportMin = res[0].timeMinDate;
                var dateSelect = $('#dateSelect').val();
                var getShift = $('#shiftSelect').val();
                var getDate = '';

                var today2 = '2021-02-23';
                if (dateSelect < dateImportMin) {
                    if (confirm('The earliest date for importing attendance data is : ' + dateImportMin.substring(8) + '/' + dateImportMin.substring(5, 7) + '/' + dateImportMin.substring(0, 4))){
                        $('#dateSelect').val(dateImportMin);
                        getDate = dateImportMin;
                    } else {
                        // alert(sec);
                        $('#dateSelect').val(sec);
                        getDate = sec;
                    }
                    
                } else if (dateSelect > dateImportMax) {
                    if (confirm('The date of importing the latest attendance data is : ' + dateImportMax.substring(8) + '/' + dateImportMax.substring(5, 7) + '/' + dateImportMax.substring(0, 4))) {
                        $('#dateSelect').val(dateImportMax);
                        getDate = dateImportMax;
                    
                    } else {
                        // alert(sec);
                        $('#dateSelect').val(sec);
                        getDate = sec;
                    }
                    
                    
                } else {
                    $('#dateSelect').val(dateSelect);
                    getDate = dateSelect;
                }
                

                setTimeout(() => {
                    // alert();
                    AttAuto(getDate, getShift);
                }, 1000);            
            }
        });
    });

    $('#shiftSelect').change(function () {
        var getDate = $('#dateSelect').val();
        var getShift = $('#shiftSelect').val();
        setTimeout(() => {
            alert('Attendenace\n' + getDate + '\n' + getShift);
            //AttAuto(getDate, getShift);
        }, 1000);       
    });


    
    var timerSet = setInterval(function () {
        var getDate = $('#sec').val();
        var getShift = $('#shiftSelect').val();
        AttAuto(getDate, getShift);
        //   alert();
    }, 10000);
    
        $('#btn_c_otherLeave').click();
        $('#btn_c_personalLeave').click();
        $('#btn_c_vacationLeave').click();
        $('#btn_c_sickLeave').click();
        $('#btn_c_late').click();
        $('#btn_c_losts').click();
   
});
