function ListDept_lps(getDate, getCompany) {
    // alert(getdate);
    // alert();
  
      

        // $('#div_deptListDay').html('');
        // $('#div_deptListDay').html('<canvas id="deptListDay" style="min-height: 250px; height: 250px; max-height: 250px; max-width: 100%;"></canvas>');


        

  
        // var getMount = '2021-01-01';

        var locat = origin + "/Manpower/GetManListDeptLpsByDate/" + getDate + '/' + getCompany;
        // var locat = origin + "/Home/GetDeptListDayByDate/" + getdate + "/all";
        // alert(locat);
        $.ajax({
            type: "GET",
            url: locat,
            dataType: "JSON",
            contentType: "application/json; charset=utf-8",
            success: function (res) {

                var dataSetAdd = [];
                var dataSetTaget = [];
                var dataSetInfo = [];
                var dataSetLost = [];
                var dataSetLabels = [];

                for (let index = 0; index < res.length; index++) {
                    const arr = [];
                    const element = res[index];
                    
                    dataSetTaget.push(element.target);
                    dataSetInfo.push(element.employee);
                    //dataSetAdd.push(element.empNew);
                    dataSetLost.push(element.vacency);
                    dataSetLabels.push(element.deptName);

                }
                // alert(dataSetAdd);
                /******************************************* */

                Highcharts.chart('siteDept', {
         
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
                    //colors: ['#e4d354', '#2b908f', '#434348'],
                    series: [

                        {
                        name: 'Target',
                        type: 'column',
                        yAxis: 1,
                        data: dataSetTaget,
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
    
    
}