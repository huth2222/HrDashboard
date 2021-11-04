function AllPercentDay(getdate) {
    
    $('#div_allPercentDay').html('');
        $('#div_allPercentDay').html('<canvas id="deptListDay" style="min-height: 250px; height: 250px; max-height: 250px; max-width: 100%;"></canvas>');
    // alert('AllPercentDay');
    var locat = origin + "/Attendance/GetAllPercentByDate/" + getdate + "/" + $('#sesionCompany').val();
    // alert(locat);
    var dataAllPercent = [];
    $.get(locat,
        function (data, textStatus, jqXHR) {
            $.each(data, function (indexInArray, valueOfElement) {
                // var allPercentInside = [];
                dataAllPercent.push(valueOfElement.info);
                dataAllPercent.push(valueOfElement.timein);
                dataAllPercent.push(valueOfElement.leave);
                dataAllPercent.push(valueOfElement.lost);

                //dataAllPercent.push(allPercentInside);
                // alert(valueOfElement.info);
            });
            // alert(dataAllPercent);
      
            // var donutChartCanvas = $('#allPercentDay').get(0).getContext('2d')
            // var donutData = {
            //     labels: [
            //         'พนักงานทั้งหมด',
            //         'มาทำงาน',
            //         'ลา',
            //         'ขาด'
            //     ],
            //     datasets: [{
            //         data: dataAllPercent,
            //         backgroundColor: ['#4F98C2', '#28A745', '#FFC107', '#DC3545'],
            //     }]
            // }
            // var donutOptions = {
            //     maintainAspectRatio: false,
            //     responsive: true,
            // }
            // //Create pie or douhnut chart
            // // You can switch between pie and douhnut using the method below.
            // new Chart(donutChartCanvas, {
            //     type: 'doughnut',
            //     data: donutData,
            //     options: donutOptions
            // })
/********************************************************** */
        var randomScalingFactor = function() {
			return Math.round(Math.random() * 100);
		};

		var config = {
			type: 'pie',
			data: {
				datasets: [{
					data: 
						dataAllPercent

					,
					backgroundColor: [
						"#E5DBAB",
						"#4BC0C0",
						"#989BA0",
						"#FF9F40",
				
					],
					label: 'Dataset 1'
				}],
				labels: [
					'พนักงานทั้งหมด',
					'มาทำงาน',
					'ลา',
					'ขาด',
			
				]
			},
			options: {
				responsive: true
			}
		};

		
			var ctx = document.getElementById('allPercentDay').getContext('2d');
			window.myPie = new Chart(ctx, config);
		
// var ctxh = document.getElementById("allPercentDay");
//             ctxh.height = 500;
//             ctxh.width = 500;
		
		

		
            
            /**************************************** */
        },
        "json"
    );
}