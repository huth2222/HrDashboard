function GetMount(mount) {
var sPageURL = window.location.search.substring(1);
sPageURL = sPageURL.substr(9); //----
var d = new Date();
var month = d.getMonth() + 1;
var today = (month < 10 ? '0' : '') + month + '/' + d.getFullYear(); //----
    if (mount == null || mount.length < 7) {
        mount = today;
    }


    var getMount = mount.substring(3, 7) + '-' + mount.substring(0, 2) + '-01';

    var tartgetDetails = [];
    $.get(origin + "/Home/GetGenderDetailByDate/" + getMount + '/' + $('#sesionCompany').val(),
        function (data, textStatus, jqXHR) {
            $.each(data, function (indexInArray, valueOfElement) {
                var tartgetDetail = [];
                tartgetDetail.push(valueOfElement.company_Code);
                tartgetDetail.push(valueOfElement.sex_man);
                tartgetDetail.push(valueOfElement.sex_wo);
                tartgetDetail.push(valueOfElement.quantity);

                tartgetDetails.push(tartgetDetail);
            });

        },
        "json"
    );
    var tartgetDetailsInfo = [];
    $.get(origin + "/Home/GetGenderDetailByDate/" + getMount + '/' + $('#sesionCompany').val(),
        function (data, textStatus, jqXHR) {
            $.each(data, function (indexInArray, valueOfElement) {
                var tartgetDetailInfo = [];
                tartgetDetailInfo.push(valueOfElement.company_Code);
                tartgetDetailInfo.push(valueOfElement.sex_man);
                tartgetDetailInfo.push(valueOfElement.sex_wo);
                tartgetDetailInfo.push(valueOfElement.quantity);

                tartgetDetailsInfo.push(tartgetDetailInfo);
            });

        },
        "json"
    );
    //alert(tartgetDetailsInfo);
    // else { alert('Data'); }

    // alert(getMount);
    var locat = origin + "/Home/GetBarTodayById/" + getMount + '/' + $('#sesionCompany').val();
    $.ajax({
        type: "GET",
        url: locat,
        dataType: "JSON",
        contentType: "applicaiton/json; charset=utf-8",
        success: (res) => {
            // alert(tartgetDetails[1][0]);

            // alert(res.target);
            
            var data = [
                [res.target, res.info, res.lost]
            ];
            var sMount = [res.months];
            var graph = ['taget', 'info', 'lost'];
            bar = new RGraph.Bar({
                id: 'manpower_tomount',
                backgroundColor: "#125023",
                data: data,
                options: {
                    key: ['Target', 'All employees', 'Vacancy rate'],
                    keyPosition: 'margin',
                    keyPositionY: 5,
                    keyTextSize: 12,
                    labelsAbove: true,
                    colors: ['#989BA0', '#4f98c2', '#96E0A5'],
                    // bevelled: true,
                    marginBottom: 75,
                    marginLeft: 45,
                    marginRight: 25,
                    colorsStroke: 'black',
                    // xaxisLabelsAngle: 25,
                    xaxisLabels: sMount,
                    textSize: 10

                    //--------------------------vvv
                    // name: ['เป้าหมาย', 'พนักงานทั้งหมด', ['อัตราว่าง']],
                    // tooltips: '%{property:name[%{index}]}: %{value}%',




                    // tooltips: '<h3>%{prop:days[%{index}]}</h3> %{table}',
                    // tooltipsEffect: 'none',
                    // tooltipsPointer: false,
                    // tooltipsPositionStatic: false,
                    // tooltipsCss: {
                    //     backgroundColor: 'white',
                    //     color: 'black'
                    // },
                    // tooltipsFormattedUnitsPost: '%',
                    // // These headers are used as the first "row" of the table
                    // tooltipsFormattedTableHeaders: ['', 'ชาย', 'หญิง', 'รวม'],

                    // // The data that appears in the tooltip table. As you can see - it's a
                    // // three-dimensional array
                    // tooltipsFormattedTableData: [tartgetDetails, tartgetDetailsInfo, tartgetDetails],
                    

                    // days: ['ต้องการคนเพิ่ม', 'พนักงานทั้งหมด', ['อัตราว่าง']],



                    // shadow: false
                    //-------------------------------------^^^
                }
            }).grow({
                frames: 50
                }).draw().on('click', function (e, shape) {
                    var obj = e.target.__object__;
                    var shape = obj.getShape(e);

                    if (shape) {

                        var dataset = shape.dataset;
                        var index = shape.index;
                        var value = typeof shape.object.data[dataset] === 'number' ? obj.data[dataset] : obj.data[dataset][index];
                        var mount = sMount;
                        //bar.options.key = ['taget', 'info', 'lost'];
                        //alert(mount[dataset] + '/' + graph[index] + '/' + value);
                        if (index == 1) {
                            window.location.href = "#manpower_listDept";
                        }
                        
                    }
                }).on('mousemove', function (e, shape) {
                    return true;
            });

        }
    });
}