function EmpList(getDate) {
    
    var locat = origin + "/Attendance/GetEmpListLpsGetDate/" + getDate;
    // var locat = origin + "/Home/GetDeptListDayByDate/" + getdate + "/all";
    //alert(locat);
    $.ajax({
        type: "GET",
        url: locat,
        dataType: "JSON",
        contentType: "application/json; charset=utf-8",
        success: function (res) {

            var LeavePersonalHtml = '<table class="table table-striped table-hover">' +
                '<thead>' +
                '<tr>' +
                '<th scope="col">' +
                'Department' +
                '</th>' +
                '<th scope="col">' +
                'No.' +
                '</th>' +
                '<th scope="col">' +
                'Name' +
                '</th> ' +
                '<th scope="col">' +
                '21-20' +
                '</th> ' +
                '<th scope="col">' +
                'Of year' +
                '</th> ' +
                '</tr>' +
                '</thead>' +
                '<tbody>';
            
            var LeaveSickHtml = '<table class="table table-striped table-hover">' +
                '<thead>' +
                '<tr>' +
                '<th scope="col">' +
                'Department' +
                '</th>' +
                '<th scope="col">' +
                'No.' +
                '</th>' +
                '<th scope="col">' +
                'Name' +
                '</th> ' +
                '<th scope="col">' +
                '21-20' +
                '</th> ' +
                '<th scope="col">' +
                'Of year' +
                '</th> ' +
                '</tr>' +
                '</thead>' +
                '<tbody>';
            
            var LeaveAnnualHtml = '<table class="table table-striped table-hover">' +
                '<thead>' +
                '<tr>' +
                '<th scope="col">' +
                'Department' +
                '</th>' +
                '<th scope="col">' +
                'No.' +
                '</th>' +
                '<th scope="col">' +
                'Name' +
                '</th> ' +
                '<th scope="col">' +
                '21-20' +
                '</th> ' +
                '<th scope="col">' +
                'Of year' +
                '</th> ' +
                '</tr>' +
                '</thead>' +
                '<tbody>';

            var LeaveOtherHtml = '<table class="table table-striped table-hover">' +
                '<thead>' +
                '<tr>' +
                '<th scope="col">' +
                'Department' +
                '</th>' +
                '<th scope="col">' +
                'No.' +
                '</th>' +
                '<th scope="col">' +
                'Name' +
                '</th> ' +
                '<th scope="col">' +
                'Remark' +
                '</th> ' +
                '</tr>' +
                '</thead>' +
                '<tbody>';

            var LateHtml = '<table class="table table-striped table-hover">' +
                '<thead>' +
                '<tr>' +
                '<th scope="col">' +
                'Department' +
                '</th>' +
                '<th scope="col">' +
                'No.' +
                '</th>' +
                '<th scope="col">' +
                'Name' +
                '</th> ' +
                '<th scope="col" class="text-center">' +
                'Time in' +
                '</th>' +
                '<th scope="col">' +
                '21-20' +
                '</th> ' +
                '<th scope="col">' +
                'Of year' +
                '</th> ' +
                '</tr>' +
                '</thead>' +
                '<tbody>';

            var AbsentHtml = '<table class="table table-striped table-hover">' +
                '<thead>' +
                '<tr>' +
                '<th scope="col">' +
                'Department' +
                '</th>' +
                '<th scope="col">' +
                'No.' +
                '</th>' +
                '<th scope="col">' +
                'Name' +
                '</th> ' +
                '<th scope="col">' +
                '21-20' +
                '</th> ' +
                '<th scope="col">' +
                'Of year' +
                '</th> ' +
                '</tr>' +
                '</thead>' +
                '<tbody>';

            let DayAll = 0;
            let DayHoliday = 0;
            let DayIn = 0;
            let DayLost = 0;
            let DayLate = 0;
            let DayLeave = 0;

            for (let index = 0; index < res.length; index++) {                
                const element = res[index];                         
                //LeavePersonalHtml
                if(element.fullAttStatus == 'Personal'){
                    LeavePersonalHtml +=
                                    '<tr>' +
                                        '<th scope="row">'+
                                            element.deptGroup +
                                        '</th>'+
                                        '<td>'+
                                            element.personCode +
                                        '</td>'+
                                        '<td>'+
                                            element.fullname +
                                        '</td> '+                         
                                        '<td>'+
                                            element.monthPLeave +                         
                                        '</td>'+
                                        '<td>'+
                                            element.yearPLeave +
                                        '</td> '+   
                                    '</tr>';
                }

                if(element.fullAttStatus == 'Sick'){
                    LeaveSickHtml +=
                                    '<tr>' +
                                        '<th scope="row">'+
                                            element.deptGroup +
                                        '</th>'+
                                        '<td>'+
                                            element.personCode +
                                        '</td>'+
                                        '<td>'+
                                            element.fullname +
                                        '</td> '+    
                                        '<td>'+
                                            element.monthSLeave +                             
                                        '</td>'+
                                        '<td>'+
                                            element.yearSLeave +
                                        '</td> '+
                                    '</tr>';
                }

                if(element.fullAttStatus == 'Annual'){
                    LeaveAnnualHtml +=
                                    '<tr>' +
                                        '<th scope="row">'+
                                            element.deptGroup +
                                        '</th>'+
                                        '<td>'+
                                            element.personCode +
                                        '</td>'+
                                        '<td>'+
                                            element.fullname +
                                        '</td> '+   
                                        '<td>'+
                                            element.monthALeave +
                                        '</td> '+ 
                                      
                                        '<td>'+
                                            element.yearALeave +
                                        '</td> '+ 
                                    '</tr>';
                }

                if(element.fullAttStatus == 'Other'){
                    LeaveOtherHtml +=
                                    '<tr>'+
                                        '<th scope="row">'+
                                            element.deptGroup +
                                        '</th>'+
                                        '<td>'+
                                            element.personCode +
                                        '</td>'+
                                        '<td>'+
                                            element.fullname +
                                        '</td> '+    
                                        '<td>' +
                                            element.leaveFull +
                                        '</td> ' +
                                    '</tr>';
                }

                if(element.fullAttStatus == 'Late'){
                    LateHtml += 
                                        '<th scope="row">'+
                                            element.deptGroup +
                                        '</th>'+
                                        '<td>'+
                                            element.personCode +
                                        '</td>'+
                                        '<td>'+
                                            element.fullname +
                                        '</td> '+    
                                        '<td class="text-center">'+
                                            element.late +
                                        '</td>'+
                                        '<td>'+
                                            element.monthLate +
                                        '</td>'+              
                                        '<td>'+
                                            element.yearLate +
                                        '</td> '+ 
                                    '</tr>';
                }

                if(element.fullAttStatus == 'Lost'){
                    AbsentHtml += 
                                '<tr>' +
                                    '<th scope="row">'+ 
                                        element.deptGroup + 
                                    '</th>'+
                                    '<td>'+
                                        element.personCode +
                                    '</td>'+
                                    '<td>'+
                                        element.fullname +
                                    '</td> '+    
                                    '<td>'+
                                            element.monthLost +
                                        '</td>'+              
                                        '<td>'+
                                            element.yearLost +
                                        '</td> '+
                                '</tr>';
                }

                /*************************************/
                
                    DayAll++;
                
                if(element.fullAttStatus == 'Holiday'){
                    DayHoliday++;
                }else if(element.fullAttStatus == '-'){
                    DayIn++;
                }else if(element.fullAttStatus == 'Lost'){
                    DayLost++;
                }else if(element.fullAttStatus == 'Late'){
                    DayLate++;
                }
                if(element.leaveFull != ''){
                    DayLeave++;
                }

                /*************************************/
                                
            }
            LeavePersonalHtml += '</tbody></table>';
            $('#personalLeave').html(LeavePersonalHtml);

            LeaveSickHtml += '</tbody></table>';
            $('#sickLeave').html(LeaveSickHtml);

            LeaveAnnualHtml += '</tbody></table>';
            $('#vacationLeave').html(LeaveAnnualHtml);

            LeaveOtherHtml += '</tbody></table>';
            $('#otherLeave').html(LeaveOtherHtml);

            LateHtml += '</tbody></table>';
            $('#late').html(LateHtml);

            AbsentHtml += '</tbody></table>';
            $('#losts').html(AbsentHtml); 
            
            //alert(htmlLost);
            // var dataIn = parseInt(dataSetIn);
            //     var dataLate = parseInt(dataSetLate);
            //     var dataLeave = parseInt(dataSetLeave);
            //     var dataLost = parseInt(dataSetLost);
            //     let totalAll = dataIn + dataLate + dataLeave + dataLost;
                /****************************Overall daily report  */
                $('#topic_allPercentDay').html('Overall daily report (พนักงาน ' + DayAll + ' คน)');

                $('#l_holiday').html(DayHoliday.toString());
                let percent_Holiday = parseFloat((DayHoliday/DayAll*100)).toFixed(2)+'%';
                $('#p_holiday').css('width',percent_Holiday);
                $('#l_percent_holiday').html(percent_Holiday);

                $('#l_lost').html(DayLost.toString());
                let percent_lost = parseFloat((DayLost/DayAll*100)).toFixed(2)+'%';
                $('#p_lost').css('width',percent_lost);
                $('#l_percent_lost').html(percent_lost);

                $('#l_leave').html(DayLeave.toString());
                let percent_leave = parseFloat((DayLeave/DayAll*100)).toFixed(2)+'%';
                $('#p_leave').css('width',percent_leave);
                $('#l_percent_leave').html(percent_leave);

                $('#l_late').html(DayLate.toString());
                let percent_late = parseFloat((DayLate/DayAll*100)).toFixed(2)+'%';
                $('#p_late').css('width',percent_late);
                $('#l_percent_late').html(percent_late);

                $('#l_info').html(DayIn.toString());
                let percent_info = parseFloat(DayIn/DayAll*100).toFixed(2)+'%';
                $('#p_info').css('width',percent_info);
                $('#l_percent_info').html(percent_info);
                
                $('#div_holiday').fadeIn(3000);
                $('#div_lost').fadeIn(3000);
                $('#div_leave').fadeIn(3000);
                $('#div_late').fadeIn(3000);
                $('#div_info').fadeIn(3000);
        }
    });
}