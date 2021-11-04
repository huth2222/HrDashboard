function ListYearCom_lps(getDate,getCompany) {
    
    var locat = origin + "/Attendance/GetListYearComLps/" + getDate + "/" + getCompany;
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
            var dataSetTimeIn = [];
            var dataSetLeave = [];
            var dataSetAbsence = [];
            // var dataSetPercent = [];
            // var test = [];

            for (let index = 0; index < res.length; index++) {
                const arr = [];
                const element = res[index];
                dataSetLate.push(element.timeLate);
                dataSetTimeIn.push(element.timeIn);
                dataSetLeave.push(element.leaves);
                dataSetAbsence.push(element.losts);
                dataLabels.push(element.getYear);
                //dataSetPercent.push(parseFloat((((element.info - (element.lost + element.leave)) / element.info) * 100).toFixed(2)));
                //test.push(element.info);
            }
            // clearTimeout(setStatus);
            // $('#success_status').html('Loading successfully.');
                /************************************************* */
            //alert(test);
                Highcharts.chart('div_allYear', {
                    chart: {
                        zoomType: 'xy'
                    },
                    title: false,
                    xAxis: [{
                        categories: dataLabels,
                        crosshair: true
                    }],
                    yAxis: [{
                        title:false,
                        // Secondary yAxis
                            // max: 100,
                            // title: {
                            //     text: 'Attendance percentage',
                            //     style: {
                            //         color: Highcharts.getOptions().colors[0]
                            //     }
                            // },

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
                            //stacking: 'normal',
                            dataLabels: {
                                enabled: true
                            }
                        }
                    },

                    colors: ['#e4d354', '#90ed7d', '#434348', '#f21313'
                    ],
                    series: [{
                        name: 'Late',
                        type: 'column',
                        yAxis: 1,
                        data: dataSetLate,
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
                        name: 'Absence',
                        type: 'column',
                        yAxis: 1,
                        data: dataSetAbsence,
                        // tooltip: {
                        //     valueSuffix: ' คน'
                        // }

                        }
                        // , {
                        // name: 'Percentage of coming to work',
                        // type: 'spline',
                        // data: dataSetPercent,
                        // marker: {
                        //     lineWidth: 2,
                        //     lineColor: Highcharts.getOptions().colors[10],
                        //     fillColor: 'white'
                        // },
                        // tooltip: {
                        //     valueSuffix: ' %'
                        // }
                        // }
                    ]
                });

            
            /****************************************** */
            
        }
    });
}