function List30DayCom_lps(getDate, getCompany) {
    
     var locat = origin + "/Attendance/GetList30DayComLps/" + getDate + "/" + getCompany;
        // var locat = origin + "/Home/GetDeptListDayByDate/" + getdate + "/all";
        // alert(locat);
        $.ajax({
            type: "GET",
            url: locat,
            dataType: "JSON",
            contentType: "application/json; charset=utf-8",
            success: function (res) {

                var dataLabels = [];
                var dataSetLate = [];
                var dataSetSTime = [];
                var dataSetLeave = [];
                var dataSetLost = [];
                var dataSetPercent = [];

                for (let index = 0; index < res.length; index++) {
                    const arr = [];
                    const element = res[index];
                    dataSetLate.push(element.timeLate);
                    //dataSetSTime.push(element.sTime);
                    dataSetLeave.push(0 - element.leaves);
                    dataSetLost.push(0 - element.losts);
                    dataLabels.push(element.getDate);
                    dataSetPercent.push(parseFloat((((element.info - (element.losts + element.leaves)) / element.info) * 100).toFixed(2)));
                }
                // alert(dataSetPercent);
                //dataPercent.parseint(dataSetPercent);
                /********************************************* */

                Highcharts.chart('div_all30Day', {
                    chart: {
                        zoomType: 'xy'
                    },
                    title: false,
                    xAxis: [{
                        categories: dataLabels,
                        crosshair: true
                    }],
                    yAxis: 
                        [{ // Secondary yAxis
                            max: 100,
                            title: {                                
                                text: 'Attendance percentage',
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
                                text: 'Statistics',
                                style: {
                                    color: Highcharts.getOptions().colors[1]
                                }
                            }
                            
                        }]
                    
                    ,
                    tooltip: {
                        shared: true
                    },
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
                    plotOptions: {
                        column: {
                            stacking: 'normal',
                            dataLabels: {
                                enabled: true
                            }
                        }
                    },
                    
                    colors: ['#e4d354', '#434348', '#90ed7d', '#f21313'],
                    series: [{
                        name: 'Late',
                        type: 'column',
                        yAxis: 1,
                        data: dataSetLate,
                        // tooltip: {
                        //     valueSuffix: ' คน'
                        // }

                    }, {
                        name: 'Absence',
                        type: 'column',
                        yAxis: 1,
                        data: dataSetLost,
                        // tooltip: {
                        //     valueSuffix: ' คน'
                        // }

                    }, {
                        name: 'Leave',
                        type: 'column',
                        yAxis: 1,
                        data: dataSetLeave,
                        // tooltip: {
                        //     valueSuffix: ' คน'
                        // }

                    }, {
                        name: 'Percentage of coming to work',
                        type: 'spline',
                        data: dataSetPercent,
                        marker: {
                            lineWidth: 2,
                            lineColor: Highcharts.getOptions().colors[10],
                            fillColor: 'white'
                        },
                        tooltip: {
                            valueSuffix: ' %'
                        }
                    }]
                });

               

                /***************************************************** */


            }
             }
                
        );
        
        // }
    
    
}
