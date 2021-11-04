function _getDay (index, group, seq)
        {
            var days = ['Monday','Tuesday','Wednesday','Thursday','Friday','Saturday','Sunday'];
            
            return days[group] + " (indexes: index=" + index + ", group=" + group + ", seq=" + seq + ")";
        }
function _GetListDept(months) {
    if (window.matchMedia("(min-width: 993px)").matches) {
        var width = document.body.clientWidth;
        $('#manpower_12pback').attr("width", width - (20 * (width / 100)));
    }
    if (window.matchMedia("(max-width: 994px)").matches) {
        var width = document.body.clientWidth;
        $('#manpower_12pback').attr("width", width - (10 * (width / 100)));
    }
    var getMount = months.substring(3, 7) + '-' + months.substring(0, 2) + '-01';

    // var value = [[1000, 2000, 3000], [5000, 4200, 6500], [8050, 5000, 3155], [4855, 4644, 1255], [8455, 8566, 8988], [4544, 6565, 3123], [9788, 4544, 1211]];
    var html = 'A summary of the template options that are available to you.<p />' +
        '<p>%{property:xaxisLabels[%{group}]}</p>' +
        '<p><input type="button" class="btn btn-success" value="แสดงรายเดือนย้อนหลัง" />' +
        '<input type="button" class="btn btn-danger" value="แสดงรายแผนก" /></p>' +
        '<table border="1" align="center" cellspacing="0">';
            
    for (let i = 0; i < 1; i++) {
        //const element = array[i];
                        
                    
        html += '<tr>' +
            '<th>%%{index}</th>' +
            '<th>%{index}</th>' +
            '</tr>' +
            '<tr>' +
            '<td>%%{dataset}</td>' +
            '<td>%{dataset}</td>' +
            '</tr>' +
            '<tr>' +
            '<td>%%{group}</td>' +
            '<td>%{group}</td>' +
            '</tr>' +
            '<tr>' +
            '<td>%%{sequential_index}</td>' +
            '<td>%{sequential_index}</td>' +
            '</tr>' +
            '<tr>' +
            '<td>%%{seq}</td>' +
            '<td>%{seq}</td>' +
            '</tr>' +
            '<tr>' +
            '<td>%%{value}</td>' +
            '<td>%{value}</td>' +
            '</tr>' +
            '<tr>' +
            '<td>%%{value_formatted}</td>' +
            '<td>%{value_formatted}</td>' +
            '</tr>' +
            '<tr>' +
            '<td>%%{property:xaxisLabels[%%{group}]}</td>' +
            '<td>%{property:xaxisLabels[%{group}]}</td>' +
            '</tr>' +
            '<tr>' +
            '<td>%%{prop:title}</td>' +
            '<td>%{prop:title}</td>' +
            '</tr>' +
            '<tr>' +
            '<td>%%{property:myNames[%%{group}]} (custom property)</td>' +
            '<td>%{property:myNames[%{group}]}<a href="www.google.com">Google</a></td>' +
            '</tr>' +
            '<tr>' +
            '<td>%%{function:_getDay(%%{index}, %%{group}, %%{seq})}</td>' +
            '<td>%{function:_getDay(%{index}, %{group}, %{seq})}</td>' +
            '</tr>' +
            '<tr>' +
            '<td>%%{key}</td>' +
            '<td>%{key}</td>' +
            '</tr>';
    }
    html += '</table> ';
    var locat = origin + "/Home/GetListDeptByDate/" + getMount;
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
                arr.push(element.target);
                arr.push(element.info);
                arr.push(element.lost);
                dataLabels.push(element.cmb1NameT);
                // dataSetsTarget.push(element.target);
                // dataSetsInfo.push(element.info);
                // dataSetsRemine.push(element.lost);
                data.push(arr);

            }
            new RGraph.Bar({
                id: 'manpower_listDept',
                data: data,
                options: {
                    key: ['เป้าหมาย', 'พนักงานทั้งหมด', 'ออก'],
                    keyPosition: 'margin',
                    keyPositionY: 5,
                    keyTextSize: 12,
                    colors: ['#ffc107', '#4f98c2', '#f7464a'],
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
                    tooltipsFormattedKeyLabels: ['Alf', 'Bert', 'Carl'],
                    tooltipsFormattedKeyColors: ['pink', 'gray', 'blue'],
                    tooltipsPointer: false,
                    tooltipsPositionStatic: false,
                    tooltipsCss: {
                        backgroundColor: 'white',
                        color: 'black'
                    }
                }
            });
        }
    });
}