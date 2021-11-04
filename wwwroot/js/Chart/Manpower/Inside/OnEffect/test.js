var ctx2 = document.getElementById("canvas");
ctx2.height = 50;
var barChartData = {
    labels: ['January', 'February', 'March', 'April', 'May', 'June', 'July'],
    datasets: [{
        type: 'line',
        label: 'เป้าหมาย',
        backgroundColor: "#FF9F40",
        //stack: 'Stack 0',
        borderWidth: 2,
        fill: false,
        data: [
            90,
            70,
            60,
            80,
            80,
            70,
            90
        ]
    }, {
        label: 'พนักงานเดิม',
        backgroundColor: "#36A2EB",
        stack: 'Stack 0',
        data: [
            30,
            20,
            31,
            20,
            30,
            25,
            28
        ]
    }, {
        label: 'พนักงานใหม่',
        backgroundColor: "#4BC0C0",
        stack: 'Stack 0',
        data: [
            30,
            75,
            65,
            25,
            45,
            12,
            35
        ]
    }, {
        label: 'ลาออก',
        backgroundColor: "#FE9A83",
        stack: 'Stack 0',
        data: [
            -35,
            -15,
            -25,
            -4,
            -7,
            -5,
            -69
        ]
    }]

};
window.onload = function () {
    var ctx = document.getElementById('canvas').getContext('2d');
    window.myBar = new Chart(ctx, {
        type: 'bar',
        data: barChartData,
        options: {
            fill: false,
            plugins: {
                title: {
                    display: true,
                    text: 'Chart.js Bar Chart - Stacked'
                },
                tooltip: {
                    mode: 'index',
                    intersect: false
                }
            },
            responsive: true,
            scales: {
                x: {
                    stacked: true,
                },
                y: {
                    stacked: true
                }
            },

            //              plugins: {
            //       datalabels: {
            //          display: false,
            //         //  align: 'center',
            //         //  anchor: 'center'
            //       }
            //    }

        }
    });
};



// define variables


/************************************************************** */
// var colors = ['rgba(255, 99, 132, 0.5)','rgba(54, 162, 235, 0.5)','rgba(255, 206, 86, 0.5)','rgba(75, 192, 192, 0.5)','rgba(153, 102, 255, 0.5)','rgba(255, 159, 64, 0.5)'];
// var borders = ['rgba(255, 99, 132,1)','rgba(54, 162, 235,1)','rgba(255, 206, 86,1)','rgba(75, 192, 192,1)','rgba(153, 102, 255,1)','rgba(255, 159, 64,1)'];
// var chartOptions = {
//     responsive: true,
//     legend: {
//         display: true,
//         padding:5, 
//         labels: {
//             fontColor :"#333",
//             fontSize:16
//         },
//         position: 'bottom' 
//     },
//     scales: {yAxes: [{ticks: {beginAtZero: true}}]},
//     title: {
//         display: true,
//         position :'top',
//         fontColor :"#333",
//         fontSize :18,
//         text: 'Example of Bar Chart Stack'
//     } 
// };
// // end Define variable

// var ctxB = document.getElementById("canvas").getContext('2d');
// var myBarChart = new Chart(ctxB, {
//     type: 'bar',
//     data: {
//     //labels: ["Red", "Blue", "Yellow", "Green", "Purple", "Orange"],
//     labels:["2557","2558","2559","2560","2561","2562"],
//     datasets: [
//       // colume 1    
//       {
//         label: 'Region 1',
//         //data: [12,19,3,5,2,3],
//         data : [12,19,3,5,2,3],
//         backgroundColor: colors[0],
//         borderColor: borders[0],    
//         borderWidth: 1
//       },
//       // colume 2
//       {
//         label: 'Region 2',
//         //data: [13,20,4,6,3,4],
//         data : [4,3,10,11,12,9],
//         backgroundColor: colors[1],
//         borderColor: borders[1],    
//         borderWidth: 1
//       }
//     ]
//     },
//     options:chartOptions
// });


/************************************* */

// $(function() {
//     var color = Chart.helpers.color;
//     var UserVsMyAppsData = {
//         labels: ['29 Sep 2019','30 Sep 2019','01 Oct 2019','02 Oct 2019','03 Oct 2019','04 Oct 2019','05 Oct 2019'],
//         datasets: [{
//             label: 'Users',
//             backgroundColor: color(window.chartColors.red).alpha(0.5).rgbString(),
//             borderColor: window.chartColors.red,
//             borderWidth: 1,
//             data: [53,117,79,56,45,89,61]
//         }, {
//             label: 'My Users',
//             backgroundColor: color(window.chartColors.blue).alpha(0.5).rgbString(),
//             borderColor: window.chartColors.blue,
//             borderWidth: 1,
//             data: [43,105,76,50,33,97,52]
//         }]

//     };

//     var UserVsMyAppsCtx = document.getElementById('canvas').getContext('2d');
//     var UserVsMyApps = new Chart(UserVsMyAppsCtx, {
//         type: 'bar',
//         data: UserVsMyAppsData,
//         options: {
//             responsive: true,
//             legend: {
//                 position: 'bottom',
//                 display: true,

//             },
//             "hover": {
//               "animationDuration": 0
//             },
//              "animation": {
//                 "duration": 1,
//               "onComplete": function() {
//                 var chartInstance = this.chart,
//                   ctx = chartInstance.ctx;

//                 ctx.font = Chart.helpers.fontString(Chart.defaults.global.defaultFontSize, Chart.defaults.global.defaultFontStyle, Chart.defaults.global.defaultFontFamily);
//                 ctx.textAlign = 'center';
//                 ctx.textBaseline = 'bottom';

//                 this.data.datasets.forEach(function(dataset, i) {
//                   var meta = chartInstance.controller.getDatasetMeta(i);
//                   meta.data.forEach(function(bar, index) {
//                     var data = dataset.data[index];
//                     ctx.fillText(data, bar._model.x, bar._model.y - 5);
//                   });
//                 });
//               }
//             },
//             title: {
//                 display: false,
//                 text: ''
//             },
//         }
//     });
// });
/********************************************** */
// var labelArray = ["James", "Mark", "Simon"],
//   greenData = [55, 82, 32],
//   orangeData = [27, 10, 53],
//   greyData = [18, 8, 15];

// var ctx = document.getElementById('canvas').getContext('2d');
// var chart = new Chart(ctx, {
//   type: 'bar',
//   data: {
//     labels: labelArray,
//     datasets: [{
//         label: 'Green %',
//         data: greenData,
//         backgroundColor: 'rgb(0,166,149)',
//         borderColor: 'rgb(0,166,149)',
//         borderWidth: 1
//       },
//       {
//         label: 'Orange %',
//         data: orangeData,
//         backgroundColor: 'rgb(229,117,31)',
//         borderColor: 'rgb(229,117,31)',
//         borderWidth: 1,
//       },
//       {
//         label: 'Grey %',
//         data: greyData,
//         backgroundColor: 'rgb(179,179,179)',
//         borderColor: 'rgb(179,179,179)',
//         borderWidth: 1,
//       }
//     ]
//   },
//   options: {
//     scales: {
//       xAxes: [{
//         stacked: true,
//       }],
//       yAxes: [{
//         stacked: true
//       }]
//     },
//     plugins: {
//       datalabels: {
//         color: 'white',
//         font: {
//           weight: 'bold'
//         },
//         formatter: function(value, context) {
//           return Math.round(value) + '%';
//         }
//       }
//     }
//   }
// });