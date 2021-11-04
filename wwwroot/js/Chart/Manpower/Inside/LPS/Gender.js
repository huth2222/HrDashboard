function Gender_lps(getDate, getCompany) {
 var locat = origin + "/Manpower/GetManGenderLpsByDate/" + getDate + '/' + getCompany;
//  alert(locat);
    $.ajax({
        type: "GET",
        url: locat,
        dataType: "JSON",
        contentType: "application/json; charset=utf-8",
        success: (res) => {
            var data = [res.sex_man, res.sex_wo];
            Highcharts.chart('gender', {
                chart: {
                    plotBackgroundColor: null,
                    plotBorderWidth: 0,
                    plotShadow: false
                },                
                title: {
                    // text: 'Browser<br>shares<br>2017',
                    text:'',
                    align: 'center',
                    verticalAlign: 'middle',
                    y: 60
                },
                tooltip: {
                    pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
                },
                accessibility: {
                    point: {
                        valueSuffix: '%'
                    }
                },
                plotOptions: {
                    pie: {
                        dataLabels: {
                            enabled: true,
                            distance: -50,
                            style: {
                                fontWeight: 'bold',
                                color: 'white'
                            }
                        },
                        startAngle: -90,
                        endAngle: 90,
                        center: ['50%', '75%'],
                        size: '120%'
                    }
                },
                colors: ['#2b908f', '#f7a35c'],
                series: [{
                    type: 'pie',
                    name: 'Browser share',
                    innerSize: '50%',
                    data: [
                        ['Male: ' + res.sex_man, res.sex_man],
                        ['Female: ' + res.sex_wo, res.sex_wo]
                    ]
                }]
            });
/*********************************************** */
         }
    });
}