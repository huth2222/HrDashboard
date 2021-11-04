function Overall_lps(getDate) {
    //alert();
    $('#success_status').html('Loading...');

    var locat = origin + "/Attendance/GetOverAllLpsToday/" + getDate;
    // alert(locat);
    $.ajax({
            type: "GET",
            url: locat,
            dataType: "JSON",
            contentType: "application/json; charset=utf-8",
            success: (res) => {

                var shiftLabels = [];

                
                var dataSetIn = [];
                var dataSetLate = [];
                var dataSetLeave = [];
                var dataSetLost = [];

                    dataSetIn.push(res.timeIn);
                    // dataAllPercent.push(element.timeins);
                    
                    dataSetLost.push(res.losts);
                    dataSetLeave.push(res.leaves);
                    dataSetLate.push(res.timeLate);
                    
                    shiftLabels.push('LPS');
                


            $('#topic_allPercentDay').html('Overall daily report');
                

/********************************************************** */

                var dataIn = parseInt(dataSetIn);
                var dataLate = parseInt(dataSetLate);
                var dataLeave = parseInt(dataSetLeave);
                var dataLost = parseInt(dataSetLost);

                /**************************************** */
                Highcharts.chart('div_allPercentDay', {

                    chart: {
                        type: 'pie',
                        options3d: {
                            enabled: true,
                            alpha: 45
                        }
                    },
                    title: false,
                    // title: {
                    //     text: 'Total : ' + (dataIn+dataLate+dataLeave+dataLost)
                    // },
                    // subtitle: {
                    //     text: (dataIn+dataLate+dataLeave+dataLost)
                    // },
                    plotOptions: {
                        pie: {
                            innerSize: 30,
                            depth: 50
                        }
                    },
                    //colors: ['#058DC7', '#50B432', '#ED561B', '#DDDF00', '#24CBE5', '#64E572', '#FF9655', '#FFF263', '#6AF9C4'],
                    series: [{
                        name: '',
                        data: [
                            ['Punctual: ' + dataIn + ' or ' + parseFloat((dataIn/(dataIn+dataLate+dataLeave+dataLost)*100)).toFixed(2)+'%', dataIn],
                            ['Late: ' + dataLate + ' or ' + parseFloat((dataLate/(dataIn+dataLate+dataLeave+dataLost)*100)).toFixed(2)+'%', dataLate],
                            ['Leave: '+ dataLeave + ' or ' + parseFloat((dataLeave/(dataIn+dataLate+dataLeave+dataLost)*100)).toFixed(2)+'%', dataLeave],
                            ['Absence: ' + dataLost + ' or ' + parseFloat((dataLost/(dataIn+dataLate+dataLeave+dataLost)*100)).toFixed(2)+'%', dataLost]
                        ],
                        point: {
                            events: {
                                click: function (event) {
                                    //alert(this.x + " " + this.y);
                                    
                                    
                                    if (this.x == 1) {
                                        if ($('#card_late').hasClass('collapsed-card')) {
                                            $('#btn_c_late').click();                                            
                                        }
                                        setTimeout(() => {
                                            $('#btn_c_late').focus();
                                        }, 100);
                                        
                                    }
                                    else if (this.x == 2) {
                                        if ($('#card_PersonalLeave').hasClass('collapsed-card')) {
                                            $('#btn_c_personalLeave').click();
                                        }
                                        if ($('#card_sickLeave').hasClass('collapsed-card')) {
                                            $('#btn_c_sickLeave').click();
                                        }
                                        if ($('#card_vacationLeave').hasClass('collapsed-card')) {
                                            $('#btn_c_vacationLeave').click();
                                        }
                                        if ($('#card_otherLeave').hasClass('collapsed-card')) {
                                            $('#btn_c_otherLeave').click();
                                        }
                                        setTimeout(() => {
                                        $('#btn_c_personalLeave').focus();
                                        }, 100);
                                        
                                        
                                        
                                    }
                                    else if (this.x == 3) {
                                        if ($('#card_losts').hasClass('collapsed-card')) {
                                            $('#btn_c_losts').click();
                                        }
                                        setTimeout(() => {
                                            $('#btn_c_losts').focus();
                                            }, 100);
                                    }
                                }
                            }
                        }
                    }]
                });
                
                /**************************************** */
            
         }
         
        });
        
        // }
    
    
}