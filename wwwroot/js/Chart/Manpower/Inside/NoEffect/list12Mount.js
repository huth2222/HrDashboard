function _GetListMount(mount) {
    var sPageURL = window.location.search.substring(1);
sPageURL = sPageURL.substr(9); //----
var d = new Date();
var month = d.getMonth() + 1;

    var today = (month < 10 ? '0' : '') + month + '/' + d.getFullYear(); //----
    
    if (mount == null || mount.length < 7) {
        mount = today;
    }


    // if (window.matchMedia("(min-width: 993px)").matches) {
    //     var width = document.body.clientWidth;
    //     $('#manpower_12pback').attr("width", width - (20 * (width / 100)));
    // }
    // if (window.matchMedia("(max-width: 994px)").matches) {
    //     var width = document.body.clientWidth;
    //     $('#manpower_12pback').attr("width", width - (10 * (width / 100)));
    // }
    // alert();
    // else { alert('Data'); }
    var getMount = mount.substring(3, 7) + '-' + mount.substring(0, 2) + '-01';
    // alert(getMount);
    var locat = origin + "/Home/GetBarListById/" + getMount;


    

    var tartgetDetails = [];
    $.get(origin + "/Home/GetBarListById/" + getMount,
        function (data, textStatus, jqXHR) {
            $.each(data, function (indexInArray, valueOfElement) {
                var tartgetDetail = [];
                tartgetDetail.push(valueOfElement.cmb1NameT);
                tartgetDetail.push(valueOfElement.sex_man);
                tartgetDetail.push(valueOfElement.sex_wo);
                tartgetDetail.push(valueOfElement.quantity);

                tartgetDetails.push(tartgetDetail);
            });

        },
        "json"
    );
    var tartgetDetailsInfo = [];
    $.get(origin + "/Home/GetTargetDetailByDate/" + getMount,
        function (data, textStatus, jqXHR) {
            $.each(data, function (indexInArray, valueOfElement) {
                var tartgetDetailInfo = [];
                tartgetDetailInfo.push(valueOfElement.cmb1NameT);
                tartgetDetailInfo.push(valueOfElement.sex_man);
                tartgetDetailInfo.push(valueOfElement.sex_wo);
                tartgetDetailInfo.push(valueOfElement.quantity);

                tartgetDetailsInfo.push(tartgetDetailInfo);
            });

        },
        "json"
    );
function getDay (index, group, seq)
        {
            var days = ['Monday','Tuesday','Wednesday','Thursday','Friday','Saturday','Sunday'];
            
            return days[group] + " (indexes: index=" + index + ", group=" + group + ", seq=" + seq + ")";
        }

var value = [[1000, 2000, 3000], [5000, 4200, 6500], [8050, 5000, 3155], [4855, 4644, 1255], [8455, 8566, 8988], [4544, 6565, 3123], [9788, 4544, 1211]];
var htmlListmonth = 'A summary of the template options that are available to you.<p />' +
          '<p>%{property:xaxisLabels[%{group}]}</p>'+
                    '<p><input type="button" class="btn btn-success" value="????????????????????????????????????????????????????????????" />' +
                    '<input type="button" class="btn btn-danger" value="?????????????????????????????????" /></p>' +          
            '<table border="1" align="center" cellspacing="0">' ;
            
                    for (let i = 0; i < value.length; i++) {
                        //const element = array[i];
                        
                    
                        htmlListmonth += '<tr>' +
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
                            '<td>%%{function:getDay(%%{index}, %%{group}, %%{seq})}</td>' +
                            '<td>%{function:getDay(%{index}, %{group}, %{seq})}</td>' +
                        '</tr>' +
                        '<tr>' +
                            '<td>%%{key}</td>' +
                            '<td>%{key}</td>' +
                        '</tr>';
                    }
                    htmlListmonth += '</table> ';
    var sMount = tartgetDetailsInfo;
    var graph = ['????????????????????????', '??????????????????????????????????????????', '???????????????????????????'];

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
                dataLabels.push(element.months);
                // dataSetsTarget.push(element.target);
                // dataSetsInfo.push(element.info);
                // dataSetsRemine.push(element.lost);
                data.push(arr);

            }
            // var data = [

            //     [res[0].target, res[0].info, res[0].lost],
            //     [res[1].target, res[1].info, res[1].lost],
            //     [res[2].target, res[2].info, res[2].lost],
            //     [res[3].target, res[3].info, res[3].lost],
            //     [res[4].target, res[4].info, res[4].lost],
            //     [res[5].target, res[5].info, res[5].lost],
            //     [res[6].target, res[6].info, res[6].lost],
            //     [res[7].target, res[7].info, res[7].lost],
            //     [res[8].target, res[8].info, res[8].lost],
            //     [res[9].target, res[9].info, res[9].lost],
            //     [res[10].target, res[10].info, res[10].lost],
            //     [res[11].target, res[11].info, res[11].lost]

            // ];
            // alert(data);
            bar = new RGraph.Bar({
                id: 'manpower_12pback',
                backgroundColor: "#125023",
                data: data,
                options: {
                    key: ['????????????????????????', '??????????????????????????????????????????', '???????????????????????????'],
                    keyPosition: 'margin',
                    keyPositionY: 5,
                    keyTextSize: 12,
                    labelsAbove: true,
                    colors: ['#ffc107', '#4f98c2', '#28A745'],
                    marginLeft: 55,
                    marginRight: 20,
                    bevelled: true,
                    marginBottom: 75,
                    colorsStroke: 'orange',


                    // xaxisLabelsAngle: 25,
                    xaxisLabels: dataLabels,
                    textSize: 10,

                    /********************************vvv */
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
        
                    tooltips: htmlListmonth,
                    tooltipsFormattedKeyLabels: ['Alf', 'Bert', 'Carl'],
                    tooltipsFormattedKeyColors: ['pink', 'gray', 'blue'],
                    tooltipsPointer: false,
                    tooltipsPositionStatic: false,
                    tooltipsCss: {
                        backgroundColor: 'white',
                        color: 'black'
                    }
                    /*********************************^^^ */
                }
            });
            //     .on('click', function (e, shape) {
            //     var obj = e.target.__object__;
            //     var shape = obj.getShape(e);

            //     if (shape) {

            //         var dataset = shape.dataset;
            //         var index = shape.index;
            //         var value = typeof shape.object.data[dataset] === 'number' ? obj.data[dataset] : obj.data[dataset][index];
            //         var mount = ['01', '02', '03', '04', '05', '06', '07', '08', '09', '10', '11', '12'];

            //         //bar.options.key = ['taget', 'info', 'lost'];
            //         alert(dataLabels[dataset] + '   ' + graph[index] + ' = ' + value + ' ??????');
            //     }
            // }).on('mousemove', function (e, shape) {
            //     return true;
            // });
            $(document).ready(function () {
                $('#IconDemo').click(function () {
                    // alert();
                    //$('MonthPicker_Button_IconDemo').removeClass("month-picker-open-button ui-button ui-widget ui-state-default ui-corner-all ui-button-icon-only");
                    // $('#MonthPicker_Button_IconDemo').addClass("ui-state-hover");
                    // $('#MonthPicker_Button_IconDemo').addClass("ui-state-active");
                    $('#MonthPicker_Button_IconDemo').click();
                });
            });
        }

    });
}