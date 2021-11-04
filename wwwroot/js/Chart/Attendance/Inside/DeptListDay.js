function DeptListDay(getdate) {
    // alert(getdate);
    // alert();
    $(document).ready(function () {
      

        $('#div_deptListDay').html('');
        $('#div_deptListDay').html('<canvas id="deptListDay" style="min-height: 250px; height: 250px; max-height: 250px; max-width: 100%;"></canvas>');


        

  
        var getMount = '2021-01-01';

        var locat = origin + "/Attendance/GetDeptListDayByDate/" + getdate + '/' + $('#sesionCompany').val();
        // var locat = origin + "/Home/GetDeptListDayByDate/" + getdate + "/all";
        // alert(locat);
        $.ajax({
            type: "GET",
            url: locat,
            dataType: "JSON",
            contentType: "application/json; charset=utf-8",
            success: function (res) {

                var dataLabels = [];
                var dataSetsInfo = [];
                var dataSetsTimeIn = [];
                var dataSetsLeave = [];
                var dataSetsLost = [];

                for (let index = 0; index < res.length; index++) {
                    const arr = [];
                    const element = res[index];
                    //arr.push(element.months);
                    dataSetsInfo.push(element.info);
                    dataSetsTimeIn.push(element.timein);
                    //dataSetsTimeout.push(element.timeout);
                    dataSetsLeave.push(0 - element.leave);
                    dataSetsLost.push(0 - element.lost);
                    dataLabels.push(element.company_Code);

                }
                //return dataLabels;
                // alert('Test');


            setTimeout(() => {
                
            
                /*********************************** */
                var barChartData = {
                    labels: dataLabels,
                    datasets: [{
                        label: 'พนักงานทั้งหมด',
                        backgroundColor: "#E5DBAB",
                        stack: 'Stack 0',
                        data: dataSetsInfo
                    },{
                        label: 'ขาด',
                        backgroundColor: "#FF9F40",
                        stack: 'Stack 1',
                        data: dataSetsLost
                    },{
                        label: 'ลา',
                        backgroundColor: "#989BA0",
                        stack: 'Stack 1',
                        data: dataSetsLeave
                    },{
                        label: 'มาทำงาน',
                        backgroundColor: "#4BC0C0",
                        stack: 'Stack 1',
                        data: dataSetsTimeIn
                    }]

                };
                // window.onload = function () {
                var ctx = document.getElementById('deptListDay').getContext('2d');
                // var ctxh = document.getElementById("manpower_12pback");
                // ctxh.height = 200;
            
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
                        }
                        ,
            
                        //              plugins: {
                        //       datalabels: {
                        //          display: false,
                        //         //  align: 'center',
                        //         //  anchor: 'center'
                        //       }
                        //    }
           
                    }
            
                });
                // alert(dataLabels);

                }, 5000);
    
                /******************************************* */
            }
                
        });
        
        // }
    });
    
}