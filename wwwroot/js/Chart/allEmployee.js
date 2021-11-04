$(document).ready(function () {
    HideShow();
    var toDay = new Date();
    var year = new Intl.DateTimeFormat("en", {
        year: "numeric"
    }).format(toDay);
    var month = new Intl.DateTimeFormat("en", {
        month: "2-digit"
    }).format(toDay);
    var day = new Intl.DateTimeFormat("en", {
        day: "2-digit"
    }).format(toDay);

    var getDateToDay = `${year}-${month}-${day}`;
    console.log(getDateToDay);
    $('#barTotalSummary').hide();
    $('#barDepartment').hide();
    MainBarChart(getDateToDay);
    DeptBarChart(getDateToDay);
});

function ReadDateTime(y, m, d) {
    var toDay = new Date(Date.UTC(y, m - 1, d));
    var year = new Intl.DateTimeFormat("en-US", {
        year: "numeric"
    }).format(toDay);
    var month = new Intl.DateTimeFormat("en-US", {
        month: "2-digit"
    }).format(toDay);
    var day = new Intl.DateTimeFormat("en-US", {
        day: "2-digit"
    }).format(toDay);

    Timeoptions = {
        hour: '2-digit',
        minute: 'numeric',
        second: 'numeric'
    };
    var TimeFix = new Intl.DateTimeFormat("en-US", Timeoptions).format(new Date());

    return `${year}-${month}-${day} ${TimeFix}`;
}


function MainBarChart(getDate) {

    chartColor = "#FFFFFF";
    var e = document.getElementById("barTotalSummary").getContext("2d");

    gradientFill = e.createLinearGradient(0, 170, 0, 50);
    gradientFill.addColorStop(0, "rgba(128, 182, 244, 0)");
    gradientFill.addColorStop(1, hexToRGB('#125023', 0.6));


    $.ajax({
        type: "GET",
        url: "../Home/GetAllById/" + getDate,
        dataType: "JSON",
        contentType: "applicaiton/json; charset=utf-8",
        success: (res) => {
            var data = [res.all_emp, res.checkin, res.lost];
            setTimeout(() => {
                $('#loadinggif_Total').hide();
                $('#barTotalSummary').show();
                var a = {
                    type: "bar",
                    plugins: [ChartDataLabels],
                    data: {
                        labels: ["Max Total", "Check-in", "Remain"],
                        datasets: [{
                            label: "LPS Company",
                            backgroundColor: gradientFill,
                            borderColor: "#125023",
                            pointBorderColor: "#FFF",
                            pointBackgroundColor: "#125023",
                            pointBorderWidth: 2,
                            pointHoverRadius: 4,
                            pointHoverBorderWidth: 1,
                            pointRadius: 4,
                            fill: true,
                            borderWidth: 1,
                            data: data
                        }]
                    },
                    options: {
                        maintainAspectRatio: false,
                        legend: {
                            display: false
                        },
                        tooltips: {
                            bodySpacing: 4,
                            mode: "nearest",
                            intersect: 0,
                            position: "nearest",
                            xPadding: 10,
                            yPadding: 10,
                            caretPadding: 10,
                            enabled: false
                        },
                        hover: true,
                        responsive: 1,
                        scales: {
                            yAxes: [{
                                gridLines: 0,
                                gridLines: {
                                    zeroLineColor: "transparent",
                                    drawBorder: false,
                                    display: false
                                },
                                ticks: {
                                    min: 0,
                                    max: 200
                                }
                            }],
                            xAxes: [{
                                display: 1,
                                gridLines: 0,
                                ticks: {
                                    display: true
                                },
                                gridLines: {
                                    zeroLineColor: "transparent",
                                    drawTicks: true,
                                    display: false,
                                    drawBorder: false
                                }
                            }]
                        },
                        layout: {
                            padding: {
                                left: 0,
                                right: 0,
                                top: 15,
                                bottom: 15
                            }
                        },
                        plugins: {
                            datalabels: {
                                color: "black",
                                align: "end",
                                anchor: "end"
                            }
                        }
                    }
                };

                new Chart(e, a);
            }, 2000);
        }
    });
}

function DeptBarChart(getDate) {

    chartColor = "#FFFFFF";
    var e = document.getElementById("barDepartment").getContext("2d");

    gradientFill = e.createLinearGradient(0, 170, 0, 50);
    gradientFill.addColorStop(0, "rgba(128, 182, 244, 0)");
    gradientFill.addColorStop(1, hexToRGB('#125023', 0.6));

    $.ajax({
        type: "GET",
        url: "../Home/GetDeptById/" + getDate,
        dataType: "JSON",
        contentType: "application/json; charset=utf-8",
        success: function (res) {
            var dataLabels = [];
            var dataSetsMaxTotal = [];
            var dataSetsCheckIn = [];
            var dataSetsRemine = [];
            for (let index = 0; index < res.length; index++) {
                const element = res[index];
                dataLabels.push(element.dept);
                dataSetsMaxTotal.push(element.all_emp);
                dataSetsCheckIn.push(element.checkin);
                dataSetsRemine.push(element.lost);
            }

            setTimeout(() => {
                $('#loadinggif_Dept').hide();
                $('#barDepartment').show();
                var a = {
                    type: "bar",
                    plugins: [ChartDataLabels],
                    data: {
                        labels: dataLabels,
                        datasets: [{
                                label: "Max Total",
                                backgroundColor: "#125023",
                                borderColor: "#125023",
                                fill: true,
                                borderWidth: 1,
                                data: dataSetsMaxTotal
                            },
                            {
                                label: "Check-in",
                                backgroundColor: "#1da2db",
                                borderColor: "#1da2db",
                                fill: true,
                                borderWidth: 1,
                                data: dataSetsCheckIn

                            }, {

                                label: "Remain",
                                backgroundColor: gradientFill,
                                borderColor: "#125023 ",
                                fill: true,
                                borderWidth: 1,
                                data: dataSetsRemine
                            }
                        ]
                    },
                    options: {
                        maintainAspectRatio: false,
                        legend: {
                            display: true
                        },
                        tooltips: {
                            bodySpacing: 4,
                            mode: "nearest",
                            intersect: 0,
                            position: "nearest",
                            xPadding: 10,
                            yPadding: 10,
                            caretPadding: 10,
                            enabled: false
                        },
                        hover: true,
                        responsive: 1,
                        scales: {
                            yAxes: [{
                                gridLines: 0,
                                gridLines: {
                                    zeroLineColor: "transparent",
                                    drawBorder: false,
                                    display: false
                                },
                                ticks: {
                                    steps: 0,
                                    max: 100
                                }
                            }],
                            xAxes: [{
                                display: 1,
                                gridLines: 0,
                                ticks: {
                                    display: true
                                },
                                gridLines: {
                                    zeroLineColor: "transparent",
                                    drawTicks: true,
                                    display: false,
                                    drawBorder: false
                                }
                            }]
                        },
                        layout: {
                            padding: {
                                left: 0,
                                right: 0,
                                top: 15,
                                bottom: 15
                            }
                        },
                        plugins: {
                            datalabels: {
                                color: "black",
                                align: "end",
                                anchor: "end"
                            }
                        }
                    }
                };
                new Chart(e, a);
            }, 2000);
        }
    });
}

function getValueByDate() {

    var year = $('#input_year').val();
    var month = $('#input_month').val();
    var day = $('#input_day').val();
    var specifyDate = year + "-" + month + "-" + day;
    $('#currenceDateTotal').html(ReadDateTime(year, month, day))
    $('#currenceDateDept').html(ReadDateTime(year, month, day))
    console.log(ReadDateTime(year, month, day));
    RemoveHistory();

    setTimeout(() => {
        HideShow();
        MainBarChart(specifyDate);
        DeptBarChart(specifyDate);
    }, 300);

}

function RemoveHistory() {
    $('#barTotalSummary').remove();
    $('#barCharTotalSummary_Area').append('<canvas id="barTotalSummary"></canvas>');
    $('#barDepartment').remove();
    $('#barChartDepartment_Area').append('<canvas id="barDepartment"></canvas>');
}

function HideShow() {
    $('#loadinggif_Total').show();
    $('#loadinggif_Dept').show();
    $('#barTotalSummary').hide();
    $('#barDepartment').hide();
}