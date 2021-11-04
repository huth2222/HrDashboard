function AllPercentDay_bmw(getDate, getShift) {
    // alert('dd');
    
    // $('#div_allPercentDay').html('');
    //     $('#div_allPercentDay').html('<canvas id="deptListDay" style="min-height: 250px; height: 250px; max-height: 250px; max-width: 100%;"></canvas>');
    // alert('AllPercentDay');
    
    var locat = origin + "/Attendance/GetAllPercentBmwByDate/" + getDate + '/' + getShift;
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
                
                for (let index = 0; index < res.length; index++) {

                    const element = res[index];

                    dataSetIn.push(element.timeins);
                    // dataAllPercent.push(element.timeins);
                    
                    dataSetLost.push(element.losts);
                    dataSetLeave.push(element.leaves);
                    dataSetLate.push(element.time_lates);
                    
                    shiftLabels.push(element.shifts);
                }


            $('#topic_allPercentDay').html('Daily report of ' + shiftLabels);
                

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
                    //     text: 'Contents of Highsoft\'s weekly fruit delivery'
                    // },
                    // subtitle: {
                    //     text: '3D donut in Highcharts'
                    // },
                    plotOptions: {
                        pie: {
                            innerSize: 50,
                            depth: 45
                        }
                    },
                    //colors: ['#058DC7', '#50B432', '#ED561B', '#DDDF00', '#24CBE5', '#64E572', '#FF9655', '#FFF263', '#6AF9C4'],
                    series: [{
                        name: '',
                        data: [
                            ['Punctual: ' + dataIn, dataIn],
                            ['Late: ' + dataLate, dataLate],
                            ['Leave: '+ dataLeave, dataLeave],
                            ['Absence: ' + dataLost, dataLost]
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