function GetGender(mount) {
    var sPageURL = window.location.search.substring(1);
sPageURL = sPageURL.substr(9); //----
var d = new Date();
var month = d.getMonth() + 1;
var today = (month < 10 ? '0' : '') + month + '/' + d.getFullYear(); //----

    if (mount == null || mount.length < 7) {
        // alert('Null');
        // var d = new Date();
        // var month = d.getMonth()+1;
        // var day = d.getDate();
        // var today = (month < 10 ? '0' : '') + month + '/' + d.getFullYear();
        mount = today;
    }


    var getMount = mount.substring(3, 7) + '-' + mount.substring(0, 2) + '-01';


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

    // else { alert('Data'); }

    // alert(tartgetDetailsInfo[0][1]);
    var locat = origin + "/Home/GetGenderByDate/" + getMount + '/' + $('#sesionCompany').val();
    $.ajax({
        type: "GET",
        url: locat,
        dataType: "JSON",
        contentType: "applicaiton/json; charset=utf-8",
        success: (res) => {
            // alert(tartgetDetails[1][0]);

            // alert(res.target);
            var data = [res.sex_man, res.sex_wo];
            
            //var data = [180, 20];
            var persen = [((100 / (data[0] + data[1])) * data[0]), ((100 / (data[0] + data[1])) * data[1])];
            var colors = ['#3E4941', '#E5DBAB'];

            var key = RGraph.HTML.Key('manpower_gender', {
                colors: colors,
                labels: ['Male : ' + data[0] + ' people = ' + parseInt(persen[0]) + '%', 'Female : ' + data[1] + ' people = ' + parseInt(persen[1]) + '%'],
                tableCss: {
                    position: 'absolute',
                    top: '5%',
                    right: '-200px',
                    transform: 'translateY(-18%)'
                }
            });

            new RGraph.SVG.Pie({
                id: 'manpower_gender',
                data: data,
                options: {
                    exploded: 5,
                    donut: true,

                    //title: "Browser share",
                    // titleSize: 20,
                    // titleBold: true,
                    // titleItalic: true,
                    name: ['Male', 'Female'],
                    tooltips: '%{property:name[%{index}]}: %{value}%',
                    shadow: true,
                    colors: ['#3E4941', '#E5DBAB'],  
                    colorsStroke: 'black',
                    // colors: [
                    //     'Gradient(#00f:#00f:#00f:#aaf:#00f)',
                    //     'Gradient(#f0f:#f0f:#f0f:#faf:#f0f)',
                    //     'Gradient(red:red:red:#faa:red)',
                    //     'Gradient(#0f0:#0f0:#0f0:#afa:#0f0)',

                    //     'Gradient(gray:gray:gray:#ccc:gray)',

                    //     'Gradient(#ff0:#ff0:#ff0:#ffa:#ff0)',
                    //     'Gradient(red:red:red:#faa:red)'
                    // ],
                    //--------------------------vvv
                    name: ['Target', 'All employees', ['Vacancy rate']],
                    tooltips: '%{property:name[%{index}]}: %{value}%',




                    tooltips: '<h3>%{prop:days[%{index}]}</h3> %{table}',
                    tooltipsEffect: 'none',
                    tooltipsPointer: false,
                    tooltipsPositionStatic: false,
                    tooltipsCss: {
                        backgroundColor: 'white',
                        color: 'black'
                    },
                    tooltipsFormattedUnitsPost: '%',
                    // These headers are used as the first "row" of the table
                    tooltipsFormattedTableHeaders: ['', 'Male', 'Female', 'Total'],

                    // The data that appears in the tooltip table. As you can see - it's a
                    // three-dimensional array
                    tooltipsFormattedTableData: [tartgetDetailsInfo,tartgetDetailsInfo],
                    

                    days: ['', '', ['Vacancy rate']],



                    shadow: false
                    //-------------------------------------^^^
                }
            }).roundRobin();
        }


    });
}