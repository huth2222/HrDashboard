var config = {
			type: 'line',
			data: {
				labels: ['January', 'February', 'March', 'April', 'May', 'June', 'July'],
				datasets: [{
					label: 'My First dataset',
					backgroundColor: window.chartColors.red,
					borderColor: window.chartColors.red,
					data: [10, 30, 39, 20, 25, 34, -10],
					fill: false,
				}, {
					label: 'My Second dataset',
					fill: false,
					backgroundColor: window.chartColors.blue,
					borderColor: window.chartColors.blue,
					data: [18, 33, 22, 19, 11, 39, 30],
				}]
			},
			options: {
				responsive: true,
				title: {
					display: true,
					text: 'Min and Max Settings'
				},
				scales: {
					yAxes: [{
						ticks: {
							// the data minimum used for determining the ticks is Math.min(dataMin, suggestedMin)
							suggestedMin: 10,

							// the data maximum used for determining the ticks is Math.max(dataMax, suggestedMax)
							suggestedMax: 50
						}
					}]
				}
			}
		};

		window.onload = function() {
			var ctx = document.getElementById('myChart').getContext('2d');
			window.myLine = new Chart(ctx, config);
		};

// var ctx = document.getElementById("myChart");
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

              