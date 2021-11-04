function GenderMotorcycle(getDate) {
    //var getDate = '2021-03-29';
    // alert(getdate);
    //  alert(getDate);



    // $('#div_deptListDay').html('');
    // $('#div_deptListDay').html('<canvas id="deptListDay" style="min-height: 250px; height: 250px; max-height: 250px; max-width: 100%;"></canvas>');





    // var getMount = '2021-01-01';

    var locat = origin + "/Manpower/GetManGenderSiteByShift/" + $('#sesionCompany').val() + "/" + getDate + '/' + "Motorcycle/0";
    // var locat = origin + "/Home/GetDeptListDayByDate/" + getdate + "/all";
    // alert(locat);
    $.ajax({
        type: "GET",
        url: locat,
        dataType: "JSON",
        contentType: "application/json; charset=utf-8",
        success: function (res) {

            Highcharts.chart('GenderMotorcycle', {
                chart: {                    
                    backgroundColor: {
    linearGradient: { x1: 1, x2: 0, y1: 1, y2: 1},
    stops: [
        [0, '#cacaca'], // start
        [0.5, '#fff'], // middle
        [1, '#cacaca'] // end
    ]
},
                    zoomType: 'xy'
                },
                title: false,
                title: {
                    text: 'Gender',
                    style: {
                        fontSize: 14,
                        fontWeight: 'bold'
                    }
                },
                // subtitle: {
                //     text: 'Source: WorldClimate.com'
                // },
                xAxis: [{
                    categories: ['MALE', 'FEMALE'],
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
                    },
                    { // Primary yAxis
                        labels: false
                        /*
                        {
                            format: '{value}',
                            // style: {
                            //     color: Highcharts.getOptions().colors[1]
                            // }
                        }*/
                        ,
                        title: {
                            text: 'PERSONS',
                            //text:false,
                            // style: {
                            //     color: Highcharts.getOptions().colors[1]
                            // }
                        }
                    }
                ],
                tooltip: {
                    shared: true
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
                            inside: true,
                            enabled: true,
                            style: {
                                fontSize: '12px'
                            }

                            //,format: '{point.y:.1f}'
                        }
                    }
                },
                legend: {
                    enabled: false
                },
                
                colors: ['#5b9bd5', '#002060', '#a5a5a5'],
                series: [

                    {
                        name: 'Count',
                        type: 'column',
                        yAxis: 1,
                        data: [res.males, res.females]
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