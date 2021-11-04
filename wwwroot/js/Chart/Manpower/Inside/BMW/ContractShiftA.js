function ContractShiftA(getDate) {

    var locat = origin + "/Manpower/GetManContractSiteByDept/" + $('#sesionCompany').val() + "/" + getDate + '/' + "Car/1";
    // var locat = origin + "/Home/GetDeptListDayByDate/" + getdate + "/all";
    // alert(locat);
    $.ajax({
        type: "GET",
        url: locat,
        dataType: "JSON",
        contentType: "application/json; charset=utf-8",
        success: function (res) {

            var dataSetCore = [];
            var dataSetLimited = [];
            var dataSetZak = [];
            var dataSetLabels = [];

            for (let index = 0; index < res.length; index++) {
                const arr = [];
                const element = res[index];

                dataSetCore.push(element.core);
                dataSetLimited.push(element.limited);
                dataSetZak.push(element.zak);
                dataSetLabels.push(element.getMonth);

            }
            // alert(dataSetAdd);
            /******************************************* */

            Highcharts.chart('ContractShiftA', {
                chart: {
                    backgroundColor: Highcharts.defaultOptions.legend.backgroundColor || '#2e75b6',
                    type: 'column'
                },
                title: {
                    text: 'Headcount Classify by Contract-A shift',
                    style: {
                        fontSize: 14,
                        fontWeight: 'bold',
                        color: '#fff'
                    }
                },
                xAxis: {
                    categories: dataSetLabels,
                    labels: {
                        style: {
                            color: '#d9d9d9'
                        }
                    }
                },
                yAxis: [{ // Primary yAxis
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
                        style: {
                            color: '#d9d9d9'
                        }
                    }
                }],
                legend: {
                    itemStyle: {
                        color: '#d9d9d9',
                        //fontWeight: 'bold'
                    }
                },
                tooltip: {
                    headerFormat: '<b>{point.x}</b><br/>',
                    pointFormat: '{series.name}: {point.y}<br/>Total: {point.stackTotal}'
                },
                plotOptions: {

                    series: {
                        shadow: true,
                        

                    },
                    column: {
                        borderWidth: 0,
                        stacking: 'normal',
                        dataLabels: {
                            enabled: true
                        }
                    }
                },
                legend: {
                    reversed: true,
                    itemStyle: {
                        color: '#d9d9d9',
                        //fontWeight: 'bold'
                    }
    },
                //colors: ['#4976ca', '#a5a5a5', '#5d9edb'],
                series: [{
                        name: 'ZAK',
                        data: dataSetZak,
                        color: {
                            linearGradient: {
                                x1: 0,
                                x2: 0,
                                y1: 0,
                                y2: 1
                            },
                            stops: [
                                [0, '#5f82cb'],
                                [1, '#3063bc']
                            ]
                        }
                    }, {
                        name: 'Limited',
                        data: dataSetLimited,
                        color: {
                            linearGradient: {
                                x1: 0,
                                x2: 0,
                                y1: 0,
                                y2: 1
                            },
                            stops: [
                                [0, '#afafaf'],
                                [1, '#959595']
                            ]
                        }
                    }, {
                        name: 'Core',
                        data: dataSetCore,
                        color: {
                            linearGradient: {
                                x1: 0,
                                x2: 0,
                                y1: 0,
                                y2: 1
                            },
                            stops: [
                                [0, '#81b0df'],
                                [1, '#488ece']
                            ]
                        }
                    }

                ]
            });

            /******************************************* */
        }

    });

    // }


}