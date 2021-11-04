function getDay (index, group, seq)
        {
            var days = ['Monday','Tuesday','Wednesday','Thursday','Friday','Saturday','Sunday'];
            
            return days[group] + " (indexes: index=" + index + ", group=" + group + ", seq=" + seq + ")";
        }
function GetsiteDept(months) {
    // if (window.matchMedia("(min-width: 993px)").matches) {
    //     var width = document.body.clientWidth;
    //     $('#manpower_12pback').attr("width", width - (20 * (width / 100)));
    // }
    // if (window.matchMedia("(max-width: 994px)").matches) {
    //     var width = document.body.clientWidth;
    //     $('#manpower_12pback').attr("width", width - (10 * (width / 100)));
    // }
    var getMount = months.substring(3, 7) + '-' + months.substring(0, 2) + '-01';

    // var value = [[1000, 2000, 3000], [5000, 4200, 6500], [8050, 5000, 3155], [4855, 4644, 1255], [8455, 8566, 8988], [4544, 6565, 3123], [9788, 4544, 1211]];
    var html = 'Report by department<p />' +
        '<p>%{property:xaxisLabels[%{group}]}</p>' +
        '<table border="1" align="center" cellspacing="0">';
            
    for (let i = 0; i < 1; i++) {
        //const element = array[i];
                        
                    
        html += 
            '<tr>' +
            '<td>%{key}</td>' +
            '</tr>';
    }
    html += '</table> ';
    var locat = origin + "/Home/GetSiteDeptByDate/" + getMount + '/' + $('#sesionCompany').val();
    // alert(locat);
    $.ajax({
        type: "GET",
        url: locat,
        dataType: "JSON",
        contentType: "application/json; charset=utf-8",
        success: function (res) {

            var dataLabels = [];
            var dataSetsTarget = [];
            var dataSetsInfo = [];
            var dataSetsRemine = [];
            var data = [];
            for (let index = 0; index < res.length; index++) {
                const arr = [];
                const element = res[index];
                //arr.push(element.months);
                arr.push(element.info);
                arr.push(element.adds);
                arr.push(element.lost);
                dataLabels.push(element.dept_name);
                // dataSetsTarget.push(element.target);
                // dataSetsInfo.push(element.info);
                // dataSetsRemine.push(element.lost);
                data.push(arr);

            }
            new RGraph.Bar({
                id: 'manpower_siteDept',
                data: data,
                options: {
                    key: ['Remaining employees', 'New employee', 'Resign'],
                    keyPosition: 'margin',
                    keyPositionY: 5,
                    keyTextSize: 12,
                    colors: ['#4f98c2', '#02F6F7', '#E5DBAB'],
                    bevelled: true,
                    colorsStroke: 'orange',


                    myNames: ['Ken  ', 'Mark', 'Barry', 'Lewis', 'Pete', 'Larry', 'Jerry'],
                    xaxis: false,
                    yaxis: false,
                    labelsAbove: true,
                    marginLeft: 60,
                    marginRight: 50,
                    marginTop: 50,
                    // marginInner: -20,
                    // marginBottom: 40,
                    title: false,
                    titleSize: 18,
                    xaxisLabels: dataLabels,
                    tooltips: html,
                    tooltipsFormattedKeyLabels: ['Remaining employees: ', 'New employee: ', 'Resign: '],
                    tooltipsFormattedKeyColors: ['#4f98c2', '#02F6F7', '#E5DBAB'],
                    tooltipsPointer: false,
                    tooltipsPositionStatic: false,
                    tooltipsCss: {
                        backgroundColor: 'white',
                        color: 'black'
                    }
                }
            }).grow({
                frames: 50
            });
        }
    });
}