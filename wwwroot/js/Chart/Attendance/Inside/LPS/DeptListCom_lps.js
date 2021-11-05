function GetTime(){
    $.get(function(data){
        //---->> ทำต่อ
    });
}
function GetDeptListCom_Lps(getDate,getCom) {
    

        var locat = origin + "/Attendance/GetDeptListComLps/" + getDate + "/" + getCom;
        // var locat = origin + "/Home/GetDeptListDayByDate/" + getdate + "/all";
        // alert(locat);
        $.ajax({
            type: "GET",
            url: locat,
            dataType: "JSON",
            contentType: "application/json; charset=utf-8",
            success: function (res) {

                var dataSetLabels = [];
                var dataSetInfo = [];
                var dataSetIn = [];
                var dataSetLate = [];
                var dataSetLeave = [];
                var dataSetLost = [];

                for (let index = 0; index < res.length; index++) {
                    const arr = [];
                    const element = res[index];
                    dataSetInfo.push(element.info);
                    dataSetIn.push(element.timeIn);
                    dataSetLate.push(element.timeLate)
                    dataSetLeave.push(element.leaves);
                    dataSetLost.push(element.losts);
                    dataSetLabels.push(element.deptName);

                }
    
                /******************************************* */

                Highcharts.chart('div_deptListDay', {
         
                    chart: {
                        zoomType: 'xy'
                    },
                    title:false,
                    // title: {
                    //     text: 'Average Monthly Temperature and Rainfall in Tokyo'
                    // },
                    // subtitle: {
                    //     text: 'Source: WorldClimate.com'
                    // },
                    xAxis: [{
                        categories: dataSetLabels,
                        crosshair: true
                    }],
                    yAxis: [{ // Secondary yAxis
                        title: {
                            text: false,
                            style: {
                                color: Highcharts.getOptions().colors[0]
                            }
                        },
                        labels: {
                            format: '{value} %',
                            style: {
                                color: Highcharts.getOptions().colors[0]
                            }
                        },
                        opposite: true
                    }, { // Primary yAxis
                        labels: {
                            format: '{value}',
                            style: {
                                color: Highcharts.getOptions().colors[1]
                            }
                        },
                        title: {
                            text: false,
                            style: {
                                color: Highcharts.getOptions().colors[1]
                            }
                        }
                    }],
                    // tooltip: {
                    //     shared: true
                    // },
                    // legend: {
                    //     layout: 'vertical',
                    //     align: 'left',
                    //     x: 120,
                    //     verticalAlign: 'top',
                    //     y: 100,
                    //     floating: true,
                    //     backgroundColor: Highcharts.defaultOptions.legend.backgroundColor || // theme
                    //         'rgba(255,255,255,0.25)'
                    // },

                    // plotOptions: {
                    //     column: {
                    //         stacking: 'normal',
                    //         dataLabels: {
                    //             enabled: true
                    //         }
                    //     }
                    // },
                     plotOptions: {
                         column: {
                             borderWidth: 0,
                             dataLabels: {
                                 enabled: true,
                                 //format: '{point.y:.1f}'
                             }
                         }
                    },
                     colors: ['#e4d354', '#90ed7d', '#434348'],
                    series: [
                        // {
                    //     name: 'In',
                    //     type: 'column',
                    //     yAxis: 1,
                    //     data: dataSetsInfo,
                    //     tooltip: {
                    //         valueSuffix: ' Value'
                    //     }
                    // },
                        // {
                        // name: 'มาทำงาน',
                        // type: 'column',
                        // yAxis: 1,
                        // data: dataSetIn,
                        // tooltip: {
                        //     valueSuffix: ' Value'
                        // }

                        // },
                        {
                        name: 'Late',
                        type: 'column',
                        yAxis: 1,
                        data: dataSetLate,
                        // tooltip: {
                        //     valueSuffix: ' Value'
                        // }

                    }, {
                        name: 'Leave',
                        type: 'column',
                        yAxis: 1,
                        data: dataSetLeave,
                        // tooltip: {
                        //     valueSuffix: ' Value'
                        // }

                    }, {
                        name: 'Absent',
                        type: 'column',
                        yAxis: 1,
                        data: dataSetLost,
                        // tooltip: {
                        //     valueSuffix: ' Value'
                        // }

                        }
                        // , {
                        // name: 'Percent of Time in',
                        // type: 'spline',
                        // data: dataSetsLost,
                        // tooltip: {
                        //     valueSuffix: ' %'
                        // }
                        // }
                    ]
                });

                /******************************************* */
            }
                
        });
        
        // }
    
    
}