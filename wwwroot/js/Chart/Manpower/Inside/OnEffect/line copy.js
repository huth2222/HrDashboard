
		// var config = {
		// 	type: 'line',
		// 	data: {
		// 		labels: ['January', 'February', 'March', 'April', 'May', 'June', 'July'],
		// 		datasets: [{
		// 			label: 'My First dataset',
		// 			backgroundColor: window.chartColors.red,
		// 			borderColor: window.chartColors.red,
		// 			data: [10, 30, 39, 20, 25, 34, -10],
		// 			fill: false,
		// 		}, {
		// 			label: 'My Second dataset',
		// 			fill: false,
		// 			backgroundColor: window.chartColors.blue,
		// 			borderColor: window.chartColors.blue,
		// 			data: [18, 33, 22, 19, 11, 39, 30],
		// 		}]
		// 	},
		// 	options: {
		// 		responsive: true,
		// 		title: {
		// 			display: true,
		// 			text: 'Min and Max Settings'
		// 		},
		// 		scales: {
		// 			yAxes: [{
		// 				ticks: {
		// 					// the data minimum used for determining the ticks is Math.min(dataMin, suggestedMin)
		// 					suggestedMin: 10,

		// 					// the data maximum used for determining the ticks is Math.max(dataMax, suggestedMax)
		// 					suggestedMax: 50
		// 				}
		// 			}]
		// 		}
		// 	}
		// };

		// window.onload = function() {
		// 	var ctx = document.getElementById('manpower_line').getContext('2d');
		// 	window.myLine = new Chart(ctx, config);
		// };
	

// var ctx = document.getElementById("manpower_line");
// debugger;
// var data = {
//   labels: ["2 Jan", "9 Jan", "16 Jan", "23 Jan", "30 Jan", "6 Feb", "13 Feb"],
//   datasets: [{
//     data: [24, 45, 36, 25, 44, 55, 22],
//     backgroundColor: "red"
//   },
//       {
//     data: [150, 87, 56, 50, 88, 60, 45],
//     backgroundColor: "#4082c4"
//   }]
// }
// var myChart = new Chart(ctx, {
//     type: 'line',
//     data: data,
//     options: {
//         events: [alert()],
//         "hover": {
//             "animationDuration": 0
//         },
//         "animation": {
//             "duration": 1,
//             "onComplete": function () {
//                 var chartInstance = this.chart,
//                     ctx = chartInstance.ctx;

//                 ctx.font = Chart.helpers.fontString(Chart.defaults.global.defaultFontSize, Chart.defaults.global.defaultFontStyle, Chart.defaults.global.defaultFontFamily);
//                 ctx.textAlign = 'center';
//                 ctx.textBaseline = 'bottom';

//                 this.data.datasets.forEach(function (dataset, i) {
//                     var meta = chartInstance.controller.getDatasetMeta(i);
//                     meta.data.forEach(function (bar, index) {
//                         var data = dataset.data[index];
//                         ctx.fillText(data, bar._model.x, bar._model.y - 5);
//                     });
//                 });
//             }
//         },
//         legend: {
//             "display": false
//         },
//         tooltips: {
//             "enabled": false
//         },
//         scales: {
//             yAxes: [{
//                 display: false,
//                 gridLines: {
//                     display: false
//                 },
//                 ticks: {
//                     max: Math.max(...data.datasets[0].data) + 10,
//                     display: false,
//                     beginAtZero: true
//                 }
//             }],
//             xAxes: [{
//                 gridLines: {
//                     display: false
//                 },
//                 ticks: {
//                     beginAtZero: true
//                 }
//             }]
//         }
//     }
// });

   /**********           ******************/

var width = document.body.clientWidth;
var Chartwidth = width * (40 / 100);
var marginR = 0;
// alert(Chartwidth);
if (Chartwidth <= 400) {
    marginR = 5;
}else if (Chartwidth <= 800) {
    marginR = 50;
} else {
    marginR = 50;
}

_data = [
    [3, 1, 2, 1],    
    [8, 2, 6, 8],
    [15, 18, 16, 50],
    [80, 30, 50, 60]
];

// These are the options that are applied to each of the three Line charts




var getMount = '2021-01-01';
// var HtmlRec = [];
// var HtmlRecLabel = [];
//     $.get(origin + "/Home/GetRecByDate/" + getMount,
//         function (data, textStatus, jqXHR) {
//             $.each(data, function (indexInArray, valueOfElement) {
//                 var HtmlInside = [];
//                 HtmlRecLabel.push(valueOfElement.months);
//                 HtmlRec.push(valueOfElement.register,valueOfElement.target,valueOfElement.info,valueOfElement.find);
//                 // HtmlInside.push(valueOfElement.target);
//                 // HtmlInside.push(valueOfElement.info);
//                 // HtmlInside.push(valueOfElement.find);

//                 // HtmlRec.push(HtmlInside);
                
//             });
//             // alert(HtmlRec);
//         },
//         "json"
// );

$.ajax({
    type: "GET",
    url: origin + "/Home/GetRecByDate/" + getMount,
    dataType: "JSON",
    contentType: "application/json; charset=utf-8",
    success: function (res) {

        var dataLabels = [];
        // var data = [];
        var arr = [];
        // for (let index = 0; index < res.length; index++) {
        //     const arr = [];
        //     const element = res[index];
        //     //arr.push(element.months);
        //     arr.push([element.register,element.target,element.info,element.find]);
        //     // arr.push(element.target);
        //     // arr.push(element.info);
        //     // arr.push(element.find);
        //     dataLabels.push(element.months);
        //     // dataSetsTarget.push(element.target);
        //     // dataSetsInfo.push(element.info);
        //     // dataSetsRemine.push(element.lost);
        //     data.push(arr);

        // }
        var dataLabels = [res[0].months, res[1].months, res[2].months, res[3].months];
        var data = [
            [res[0].register, res[1].register, res[2].register, res[3].register],
            [res[0].target, res[1].target, res[2].target, res[3].target],
            [res[0].info, res[1].info, res[2].info, res[3].info],
            [res[0].find, res[1].find, res[2].find, res[3].find]
        ];
    
// alert(HtmlRecLabel);
// var data = _data;
alert(data);
//
// These are the options that are applied to each of the three Line charts
//

options = {
    bevelled: true,
    key: ['ผู้สมัครงาน','เป้าหมาย', 'พนักงาน','ออก'],
    keyColors: ['green','#ffc107','#4f98c2', '#f7464a'],
    keyPosition: 'margin',
    keyPositionY: 5,
    keyTextSize: 12,


    xaxisLabels: dataLabels,
    marginInner: 15,
    marginLeft: 50,
    marginRight: 50,
    marginBottom: 40,
    filledOpacity: 0.3,
    filled: true,
        filledAccumulative: true,
        colors: ['transparent', 'transparent', 'transparent','transparent'],
        spline: true,
        backgroundGridVlines: false,
        backgroundGridBorder: false,
        xaxis: false,
        yaxis: false,
        textSize: 10,
        shadow: false,
        linewidth: 0.00001
};

frames = 30;



//
// Draw the first Line chart. when it finishes animating it starts the second Line chart
// animating
//
// Each line chart has all of the datasets - though on each Line chart three of
// the datasets are colored transparent.

//
setTimeout(() => {
    

new RGraph.Line({
    id: 'manpower_line',
    data: data,
    options: options
}).trace({
    frames: frames
}, draw1);



//
// Draw the second chart. When it finishes animating it starts the third Line chart
// animating.
//
function draw1() {
    options.colors = ['#db3d40', 'transparent', 'transparent', 'transparent'];
    options.backgroundGrid = false;
    //options.onClick = alert('draw1');

    new RGraph.Line({
        id: 'manpower_line',
        data: data,
        options: options
    }).trace({
        frames: frames
    }, draw2);
}


function draw2() {
    options.colors = ['transparent', '#4f98c2', 'transparent', 'transparent'];
//options.onClick = alert('draw2');
    new RGraph.Line({
        id: 'manpower_line',
        data: data,
        options: options
    }).trace({
        frames: frames
    }, draw3);
}

function draw3() {
    options.colors = ['transparent', 'transparent', '#ffc107', 'transparent'];
    //options.onClick = alert('draw3');

    new RGraph.Line({
        id: 'manpower_line',
        data: data,
        options: options
    }).trace({
        frames: frames
    }, draw4);
}

function draw4() {
    
options.colors = ['transparent', 'transparent', 'transparent', '#008000'];
    options.labelsAbove = true;
    //options.onClick = alert('draw4');
    new RGraph.Line({
        id: 'manpower_line',
        data: data,
        options: options,
    }).trace({
        frames: frames
    });
}
// $('#manpower_line').onclick(function () {
//     alert(); 
// });
$("#manpower_line").click( 
    function(evt){
        
        // alert('activePoints');
        /* do something */
    }
    ); 
}, 5000);
        }
    });
/******************************************** */
// $(document).ready(function () {
//     var canvas = document.getElementById("manpower_line");
//     var barChartCanvas = $('#manpower_line').get(0).getContext('2d');
//     alert(canvas);

// data = [
//             [84,65,3,15,12,22,95,5,35,45,85,85,23,45,62,52,45,31,53,66],
//             [64,12,56,25,20,80,85,61,81,56,45,32,91,52,86,23,45,56,51,48],
//             [48,5,23,12,16,36,49,130,52,95,45,21,65,35,28,75,59,74,86,23],
//             [95,65,32,12,100,8,152,63,52,54,85,45,12,13,15,32,64,84,54,66]
//         ];
        
//         //
//         // These are the options that are applied to each of the three Line charts
//         //
//         options = {
//             filled: true,
//             filledAccumulative: true,
//             colors: ['transparent', '#FDA354', 'transparent', 'transparent'],
//             spline: true,
//             backgroundGridVlines: false,
//             backgroundGridBorder: false,
//             xaxis: false,
//             yaxis: false,
//             textSize: 10,
//             shadow: false,
//             linewidth: 0.00001
//         };

//         frames = 30;



//         //
//         // Draw the first Line chart. when it finishes animating it starts the second Line chart
//         // animating
//         //
//         // Each line chart has all of the datasets - though on each Line chart three of
//         // the datasets are colored transparent.
//         //
//         new RGraph.Line({
//             id: 'manpower_line',
//             data: data,
//             options: options
//         }).trace({frames: frames}, draw2);



//         //
//         // Draw the second chart. When it finishes animating it starts the third Line chart
//         // animating.
//         //
//         function draw2()
//         {
//             options.colors         = ['transparent', 'transparent', '#C4D6ED', 'transparent'];
//             options.backgroundGrid =  false;

//             new RGraph.Line({
//                 id: 'manpower_line',
//                 data: data,
//                 options: options
//             }).trace({frames: frames}, draw3);
//         }



//         //
//         // Draw the third chart
//         //
//         function draw3()
//         {
//             options.colors = ['transparent', 'transparent', 'transparent', '#609EC8'];
            
//             new RGraph.Line({
//                 id: 'manpower_line',
//                 data: data,
//                 options: options
//             }).trace({frames: frames});
//         }