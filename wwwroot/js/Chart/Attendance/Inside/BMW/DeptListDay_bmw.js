function DeptListDay_bmw(getDate, getShift) {
    // alert(getdate);
    // alert();

      

        // $('#div_deptListDay').html('');
        // $('#div_deptListDay').html('<canvas id="deptListDay" style="min-height: 250px; height: 250px; max-height: 250px; max-width: 100%;"></canvas>');


        

  
        // var getMount = '2021-01-01';

        var locat = origin + "/Attendance/GetDeptListDayBmwByDate/" + getDate + '/' + getShift;
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
                    dataSetIn.push(element.timein);
                    dataSetLate.push(element.time_late)
                    dataSetLeave.push(element.leave);
                    dataSetLost.push(element.lost);
                    dataSetLabels.push(element.dept_name);

                }
                
                // dataSetsInfo
                //return dataLabels;
                // alert('Test');


            
                
            
                /*********************************** */
            //     var barChartData = {
            //         labels: dataLabels,
            //         datasets: [{
            //             label: 'พนักงานทั้งหมด',
            //             backgroundColor: "#E5DBAB",
            //             stack: 'Stack 0',
            //             data: dataSetsInfo
            //         },{
            //             label: 'มาทำงาน',
            //             backgroundColor: "#4BC0C0",
            //             stack: 'Stack 1',
            //             data: dataSetsTimeIn
            //         },{
            //             label: 'ขาด',
            //             backgroundColor: "#FF9F40",
            //             stack: 'Stack 1',
            //             data: dataSetsLost
            //         },{
            //             label: 'ลา',
            //             backgroundColor: "#989BA0",
            //             stack: 'Stack 1',
            //             data: dataSetsLeave
            //         }]

            //     };
            //     // window.onload = function () {
            //     // setTimeout(() => {
            //         var ctx = document.getElementById('deptListDay').getContext('2d');
            //     // }, 5000);
                
            //     // var ctxh = document.getElementById("manpower_12pback");
            //     // ctxh.height = 200;
            // // for (let i = 0; i < barChartData.length; i++) {
            // //     const element = barChartData[i];

            // // }
                
            //     window.myBar = new Chart(ctx, {
            //         type: 'bar',
            //         data: barChartData,
            //         options: {
            //             plugins: {
            //                 datalabels: {

            //                     font: {
            //                         size: 16
            //                     },
            //                     color: 'black',

            //                     display: true,
            //                     align: 'center',
            //                     anchor: 'center',
            //                     formatter: function (value, index, values) {
                                    
                                    
            //                         if (value == 0) {

            //                             value = "";
            //                             return value;
            //                         }
            //                     }
            //                 }
            //             },
            //             fill: false,
            //             plugins: {
            //                 title: {
            //                     display: true,
            //                     text: 'Chart.js Bar Chart - Stacked'
            //                 },
            //                 tooltip: {
            //                     mode: 'index',
            //                     intersect: false
            //                 }
            //             },
            //             responsive: true,
            //             scales: {
            //                 x: {
            //                     stacked: true,
            //                 },
            //                 y: {
            //                     stacked: true
            //                 }
            //             }
            //             ,
            
            //             //              plugins: {
            //             //       datalabels: {
            //             //          display: false,
            //             //         //  align: 'center',
            //             //         //  anchor: 'center'
            //             //       }
            //             //    }
           
            //         }
            
            //     });
            //     // alert(dataLabels);

               
    
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