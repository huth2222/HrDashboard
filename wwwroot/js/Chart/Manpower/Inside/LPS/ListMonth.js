function ListMonth_lps(getDate, getCompany) {
    // alert(getdate);
    // alert();
    $(document).ready(function () {
        var locat = origin + "/Manpower/GetManListMonthLpsByDate/" + getDate + '/' + getCompany;
        $.ajax({
            type: "GET",
            url: locat,
            dataType: "JSON",
            contentType: "application/json; charset=utf-8",
            success: function (res) {

                var dataSetTarget = [];
                var dataSetInfo = [];
                var dataSetLost = [];
                var dataSetLabels = [];

                for (let index = 0; index < res.length; index++) {
                    const arr = [];
                    const element = res[index];
                    dataSetTarget.push(element.target);
                    dataSetInfo.push(element.employee);
                    dataSetLost.push(element.vacency);
                    dataSetLabels.push(element.months);

                }
                // alert(dataSetTarget);
                /******************************************* */
                $('#success_status').html('Loading successfully.');

                Highcharts.chart('listMonth', {
         
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
                                 style: {
                                 fontSize: '8px'
                                 }
                                 
                                 //format: '{point.y:.1f}'
                             }
                         }
                    },
                    series: [

                        {
                        name: 'Target',
                        type: 'column',
                        yAxis: 1,
                        data: dataSetTarget,
                        // tooltip: {
                        //     valueSuffix: ' Value'
                        // }

                    }, {
                        name: 'Employee',
                        type: 'column',
                        yAxis: 1,
                        data: dataSetInfo,
                        // tooltip: {
                        //     valueSuffix: ' Value'
                        // }

                    }, {
                        name: 'Vacancy',
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
    });
    
}