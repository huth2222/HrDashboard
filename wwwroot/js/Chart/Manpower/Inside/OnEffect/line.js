// _data = [
//     [4, 5, 3],
//     [4, 8, 6],
//     [4, 2, 4],
//     [4, 2, 3],
//     [1, 2, 3],
//     [8, 8, 4],
//     [4, 8, 6]
// ];
var getMount = '2021-01-01';
// var data = [];
// var label = [];
//     $.get(origin + "/Home/GetRecByDate/" + getMount,
//         function (data, textStatus, jqXHR) {
//             $.each(data, function (indexInArray, valueOfElement) {
//                 var dataInside = [];
//                 label.push(valueOfElement.months);
//                 dataInside.push(valueOfElement.register);
//                 dataInside.push(valueOfElement.target);
//                 dataInside.push(valueOfElement.info);
//                 dataInside.push(valueOfElement.find);

//                 data.push(dataInside);
//             });


var locat = origin + "/Home/GetRecByDate/" + getMount + '/' + $('#sesionCompany').val();
$.ajax({
    type: "GET",
    url: locat,
    dataType: "JSON",
    contentType: "applicaiton/json; charset=utf-8",
    success: (res) => {
        // alert(tartgetDetails[1][0]);

        // alert(res.target);

        var data = [];
        var dataLabel = [];
        for (let i = 0; i < res.length; i++) {
            var arr = [];
            arr.push(res[i].target);
            arr.push(res[i].find);
            arr.push(res[i].info);
            dataLabel.push(res[i].months);
            data.push(arr);
            //alert(data);

        }



        var sMount = [res.months];
        //var graph = ['taget', 'info', 'lost'];

        new RGraph.Bar({
            id: 'manpower_line',
            data: data,
            options: {
                // bevelled: true,
                // filled: true,
                xaxisLabels: dataLabel,
                xaxisLabelsOffsety: 4,
                colors: ['#989BA0', '#96E0A5', '#4f98c2'],                
                grouping: 'stacked',
                colorsStroke: 'black',
                marginLeft: 35,
                marginTop: 10,
                marginBottom: 50,
                marginRight: 20,
                xaxisLabelsAngle: 45,
                colorsStroke: 'rgba(0,0,0,0)'
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
    },
});