var width = document.body.clientWidth;
var linewidth = width * (40 / 100);
// alert(linewidth);
data = [
    [3, 1, 2, 1, 3, 5],    
    [8, 2, 6, 8, 30, 31],
    [15, 18, 16, 50, 30, 35],
    [80, 30, 50, 60, 80, 98]
];

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

    labelsAbove: true,

    xaxisLabels: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun'],
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





//
// Draw the first Line chart. when it finishes animating it starts the second Line chart
// animating
//
// Each line chart has all of the datasets - though on each Line chart three of
// the datasets are colored transparent.
//
new RGraph.Line({
    id: 'manpower_line',
    data: data,
    options: options
});



//
// Draw the second chart. When it finishes animating it starts the third Line chart
// animating.
//
function draw1() {
    options.colors = ['#db3d40', 'transparent', 'transparent', 'transparent'];
    options.backgroundGrid = false;

    new RGraph.Line({
        id: 'manpower_line',
        data: data,
        options: options
    });
}


function draw2() {
    options.colors = ['transparent', '#4f98c2', 'transparent', 'transparent'];

    new RGraph.Line({
        id: 'manpower_line',
        data: data,
        options: options
    });
}

function draw3() {
    options.colors = ['transparent', 'transparent', '#ffc107', 'transparent'];
    

    new RGraph.Line({
        id: 'manpower_line',
        data: data,
        options: options
    });
}

function draw4() {
    
options.colors = ['transparent', 'transparent', 'transparent', '#008000'];
    

    new RGraph.Line({
        id: 'manpower_line',
        data: data,
        options: options
    });
}
// $(document).ready(function () {
//     var canvas = document.getElementById("manpower_line");
//     var barChartCanvas = $('#manpower_line').get(0).getContext('2d');
//     alert(canvas);

