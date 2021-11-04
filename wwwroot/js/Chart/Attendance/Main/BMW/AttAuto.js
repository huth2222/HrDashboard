// alert(origin + "/Attendance/GetAutoTime/" + getDate + '/' + getShift);
function AttAuto(getDate, getShift) {
  if(getDate){
    $('#sec').val(getDate);
  }else{
    getDate = $('#dateSelect').val();
  }
  
  
    // alert();
      $.ajax({
          type: "GET",
          url: origin + "/Attendance/GetAutoTime/" + getDate + '/' + getShift,
          dataType: "JSON",
          contentType: "application/json; charset=utf-8",
          success: function (res) {

              var dataSetsTimeIn = res.timeins;
              var dataSetsLost = res.losts;
              var dataSetsLeave = res.leaves;
              var dataSetsLate = res.time_lates;

              // alert($('#timein').val() + '/' + dataSetsTimeIn);
            //   if ($('#timein').val() == 0 && dataSetsTimeIn > 0) {
            //       $('#timein').val(dataSetsTimeIn);
            //       $('#lost').val(dataSetsLost);
            //       $('#leave').val(dataSetsLeave);
            //       $('#time_late').val(dataSetsLate);
            //   }
            //   setTimeout(() => {
              
            //   alert(dataSetsTimeIn + ' => ' + $('#timein').val() + '\n' +
            //       dataSetsLost + ' => ' + $('#lost').val() + '\n' +
            //       dataSetsLeave + ' => ' + $('#leave').val() + '\n' +
            //       dataSetsLate + ' => ' + $('#time_late').val() + '\n');

                  if ($('#timein').val() != dataSetsTimeIn || $('#lost').val() != dataSetsLost || $('#leave').val() != dataSetsLeave || $('#time_late').val() != dataSetsLate) {
                    //   alert('Yes');
                      /*********************************************** */


                      
                      $('#div_allPercentDay').html('');
                    //   var html_allPercentDay = '<center><canvas id="allPercentDay" style="min-height: 250px; height: 250px; max-height: 250px; max-width: 500px;"></canvas></center>';
                      setTimeout(() => {
                    //   $('#div_allPercentDay').html(html_allPercentDay);
                          }, 1000);
                      $('#div_deptListDay').html('');
                    //   var html_deptListDay = '<canvas id="deptListDay" style="min-height: 250px; height: 250px; max-height: 250px; max-width: 100%;"></canvas>';
                      setTimeout(() => {
                        //   $('#div_deptListDay').html(html_deptListDay);
                          }, 1000);

                      $('#div_all30Day').html('');
                    //   var html_all30Day = '<canvas id="all30Day" style="min-height: 250px; height: 250px; max-height: 250px; max-width: 100%;"></canvas>';
                      setTimeout(() => {
                        //   $('#div_all30Day').html(html_all30Day);
                          }, 1000);

                      $('#div_allYear').html('');
                    //   var html_allYear = '<canvas id="all1Year" style="min-height: 250px; height: 250px; max-height: 250px; max-width: 100%;"></canvas>';
                      setTimeout(() => {
                        //   $('#div_allYear').html(html_allYear);
                          }, 1000);

                    setTimeout(() => {
                      if ($('#sesionCompany').val() == 'BMW') {
                          AllPercentDay_bmw(getDate, getShift);
                          DeptListDay_bmw(getDate, getShift);
                      } else {
                        AllPercentDay_lps(getDate, getShift);
                        DeptListDay_lps(getDate, getShift);
                        }
                          
                          All30Day_bmw(getDate, getShift);
                          AllYear_bmw(getDate, getShift);
                          LateBmw(getDate, getShift);
                          LostBmw(getDate, getShift);
                          LeavePersonalBmw(getDate, getShift);
                          LeaveSickBmw(getDate, getShift);
                          LeaveVacationBmw(getDate, getShift);
                          LeaveOtherBmw(getDate, getShift);
                      }, 2000);

                    //   alert(dataSetsTimeIn);
                    if ((dataSetsTimeIn + dataSetsLost + dataSetsLeave + dataSetsLate) > 0) {
                      $('#timein').val(dataSetsTimeIn);
                      $('#lost').val(dataSetsLost);
                      $('#leave').val(dataSetsLeave);
                      $('#time_late').val(dataSetsLate);
                    }

                      /************************************************* */

                  }
            //   }, 3000);
          }
      });
  
  $.ajax({
    type: "GET",
    url: origin + "/Attendance/GetMaxDate",
    dataType: "JSON",
    contentType: "application/json; charset=utf-8",
    success: function (res) {

      var maxDate = res[0].timeMaxDate;
      var minDate = res[0].timeMinDate;
      var maxDateTime = res[0].timeMaxDateTimeFormat;

      //if (minDate != $('#updateMinDate').val() || maxDate != $('#updateMaxDate').val() || maxDateTime != $('#updateMaxDateTime').val()) {
        $('#updateAtt').html('The latest time attendance is : ' + maxDateTime);
      //}
      $('#updateMinDate').val(minDate);
      $('#updateMaxDate').val(maxDate);
      $('#updateMaxDateTime').val(maxDateTime);
      
    }
  });
  }