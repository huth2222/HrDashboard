function DeptCarShiftA(getDate) {
    //var getDate = '2021-03-29';
    // alert(getdate);
    // alert(getDate);



    // $('#div_deptListDay').html('');
    // $('#div_deptListDay').html('<canvas id="deptListDay" style="min-height: 250px; height: 250px; max-height: 250px; max-width: 100%;"></canvas>');





    // var getMount = '2021-01-01';

    var locat = origin + "/Manpower/GetManDeptSiteByDept/" + $('#sesionCompany').val() + "/" + getDate + '/' + "Car/1";
    // var locat = origin + "/Home/GetDeptListDayByDate/" + getdate + "/all";
    //  alert(locat);
    $.ajax({
        type: "GET",
        url: locat,
        dataType: "JSON",
        contentType: "application/json; charset=utf-8",
        success: function (res) {

            var dataSetTarget = [];
            var dataSetPlan = [];
            var dataSetActual = [];
            var dataSetLabels = [];

            for (let index = 0; index < res.length; index++) {
                const arr = [];
                const element = res[index];

                dataSetTarget.push(element.targets);
                dataSetPlan.push(element.plans);
                dataSetActual.push(element.infos);
                dataSetLabels.push(element.dept_name);

            }
            // alert(dataSetAdd);
            /******************************************* */

            Highcharts.chart('DeptCarShiftA', {

                chart: {
                    zoomType: 'xy'
                },
                title: false,
                title: {
                    text: 'Headcount-A shift',
                    style: {
                        fontSize: 14,
                        fontWeight:'bold'
                    }
                },
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
                        // style: {
                        //     color: Highcharts.getOptions().colors[1]
                        // }
                    },
                    title: {
                        //text: 'PERSONS',
                        text:false,
                        // style: {
                        //     color: Highcharts.getOptions().colors[1]
                        // }
                    }
                }],
                tooltip: {
                    shared: true
                },
                legend: {
                    align: 'center',
                    x: 0,
                    verticalAlign: 'top',
                    y: 0,
                    floating: false,
                    // backgroundColor: Highcharts.defaultOptions.legend.backgroundColor || 'red',
                    
                    //borderColor: '#CCC',
                    
                    //borderWidth: 1,
                    shadow: false,
                },

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

                            //,format: '{point.y:.1f}'
                        }
                    }
                },
                colors: ['#5b9bd5', '#002060', '#a5a5a5'],
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
                        name: 'Plan',
                        type: 'column',
                        yAxis: 1,
                        data: dataSetPlan,
                        // tooltip: {
                        //     valueSuffix: ' Value'
                        // }

                    }, {
                        name: 'Actual',
                        type: 'column',
                        yAxis: 1,
                        data: dataSetActual,
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