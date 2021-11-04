function AgeRange(getDate) {
    //var getDate = '2021-03-29';
    // alert(getdate);
    // alert(getDate);



    // $('#div_deptListDay').html('');
    // $('#div_deptListDay').html('<canvas id="deptListDay" style="min-height: 250px; height: 250px; max-height: 250px; max-width: 100%;"></canvas>');





    // var getMount = '2021-01-01';

    var locat = origin + "/Manpower/GetManAgeByRange/" + $('#sesionCompany').val() + "/" + getDate;
    // var locat = origin + "/Home/GetDeptListDayByDate/" + getdate + "/all";
    //  alert(locat);
    $.ajax({
        type: "GET",
        url: locat,
        dataType: "JSON",
        contentType: "application/json; charset=utf-8",
        success: function (res) {

            var dataSetCounts = [];
            var dataSetLabels = [];

            for (let index = 0; index < res.length; index++) {
                const arr = [];
                const element = res[index];
                dataSetCounts.push(element.counts);
                dataSetLabels.push(element.ageRange);

            }
            // alert(dataSetAdd);
            /******************************************* */

            Highcharts.chart('AgeRange', {

                chart: {
                    zoomType: 'xy'
                },
                title: false,
                title: {
                    text: 'Age Structure',
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
                    enabled: false
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
                colors: ['#9aaecb'],
                series: [

                    {
                        name: 'Count',
                        type: 'column',
                        yAxis: 1,
                        data: dataSetCounts,
                        // tooltip: {
                        //     valueSuffix: ' Value'
                        // }

                    }
                ]
            });

            /******************************************* */
        }

    });

    // }


}