      $('.date-own').datepicker({
        minViewMode: 2,
        format: 'yyyy'
      });
      //-------------

      $(function () {
        var areaChartData = {
          labels: ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'],
          datasets: [{
              label: 'เป้าหมาย',
              backgroundColor: 'rgba(210, 214, 222, 1)',
              borderColor: 'rgba(210, 214, 222, 1)',
              pointRadius: false,
              pointColor: 'rgba(210, 214, 222, 1)',
              pointStrokeColor: '#c1c7d1',
              pointHighlightFill: '#fff',
              pointHighlightStroke: 'rgba(220,220,220,1)',
              data: [30, 50, 50, 20, 90, 30, 90, 50, 30, 40, 50, 60]
            },
            {
              label: 'พนักงานทั้งหมด',
              backgroundColor: 'rgba(60,141,188,0.9)',
              borderColor: 'rgba(60,141,188,0.8)',
              pointRadius: false,
              pointColor: '#3b8bba',
              pointStrokeColor: 'rgba(60,141,188,1)',
              pointHighlightFill: '#fff',
              pointHighlightStroke: 'rgba(60,141,188,1)',
              data: [30, 48, 40, 19, 86, 27, 90, 45, 20, 30, 40, 50]
            },            
            {
              label: 'อัตราว่าง',
              backgroundColor: 'rgba(247, 70, 74, 1)',
              borderColor: 'rgba(247, 70, 74, 1)',
              pointRadius: false,
              pointColor: 'rgba(247, 70, 74, 1)',
              pointStrokeColor: '#c1c7d1',
              pointHighlightFill: '#fff',
              pointHighlightStroke: 'rgba(247, 70, 74, 1)',
              data: [29, 45, 38, 15, 80, 25, 80, 45, 15, 29, 40, 35]
            },
          ]
        }


        //-------------
        var canvas = document.getElementById("barChart");
        var barChartCanvas = $('#barChart').get(0).getContext('2d')
        var barChartData = $.extend(true, {}, areaChartData)
        var value0 = areaChartData.datasets[0]
        var value1 = areaChartData.datasets[1]
        var value2 = areaChartData.datasets[2]
        barChartData.datasets[0] = value0
        barChartData.datasets[1] = value1
        barChartData.datasets[2] = value2

        var barChartOptions = {
          responsive: true,
          maintainAspectRatio: false,
          
          datasetFill: false
        }
        

        var myNewChart = new Chart(barChartCanvas, {
          type: 'bar',
          data: barChartData,
          options: barChartOptions
        })
        
//************************* */
        // $('#barChart').click(function (evt) {
        //   alert(myNewChart.getElementsAtEvent(evt).length);
        // });
        canvas.onclick = function (evt) { 
          // alert(evt);
          var activePoints = myNewChart.getElementsAtEvent(evt);
          // alert(canvas);
      if (activePoints[0]) {
        var chartData = activePoints[0]['_chart'].config.data;
        var idx = activePoints[0]['_index'];


        var month = chartData.labels[idx];
        var taget = chartData.datasets[0].data[idx];
        var info = chartData.datasets[1].data[idx];
        var lost = chartData.datasets[2].data[idx];

        var url = origin + "/?month=" + month + "&taget=" + taget + "&info=" + info + "&lost=" + lost;
        console.log(url);
        alert(url);
      }
    };
//*************************** */
      })
//----------------------------------------
      var data = {
  datasets: [{
    data: [300, 50, 100],
    backgroundColor: [
      "#F7464A",
      "#46BFBD",
      "#FDB45C"
    ]
  }],
  labels: [
    "Red",
    "Green",
    "Yellow"
  ]
};

$(document).ready(
  function() {
    var canvas = document.getElementById("myChart");
    var ctx = canvas.getContext("2d");
    var myNewChart = new Chart(ctx, {
      type: 'pie',
      data: data
    });

    canvas.onclick = function(evt) {
      var activePoints = myNewChart.getElementsAtEvent(evt);
      if (activePoints[0]) {
        var chartData = activePoints[0]['_chart'].config.data;
        var idx = activePoints[0]['_index'];

        var label = chartData.labels[idx];
        var value = chartData.datasets[0].data[idx];

        var url = "http://example.com/?label=" + label + "&value=" + value;
        console.log(url);
        alert(url);
      }
    };
  }
);
