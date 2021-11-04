function Monthly_site(getDate, getCompany, getZone) {
    
    // $('#div_allPercentDay').html('');
    //     $('#div_allPercentDay').html('<canvas id="deptListDay" style="min-height: 250px; height: 250px; max-height: 250px; max-width: 100%;"></canvas>');
    // alert('AllPercentDay');
    var locat = origin + "/Manpower/GetManMonthlySiteByDate/" + getDate + '/' + getCompany + '/' + getZone;
    // alert(locat);
    $.ajax({
            type: "GET",
            url: locat,
            dataType: "JSON",
            contentType: "application/json; charset=utf-8",
            success: (res) => {

                Highcharts.chart('mountly', {

                    chart: {
                        type: 'pie',
                        options3d: {
                            enabled: true,
                            alpha: 45
                        }
                    },
                    title: false,

                    plotOptions: {
                        pie: {
                            innerSize: 50,
                            depth: 45
                        }
                    },
                    //colors: ['#058DC7', '#50B432', '#ED561B', '#DDDF00', '#24CBE5', '#64E572', '#FF9655', '#FFF263', '#6AF9C4'],
                    //colors: ['#24CBE5','#FFF263'],
                    series: [{
                        name: '',
                        data: [
                            ['Target: ' + res.target, res.target],
                            ['Employee: ' + res.employee, res.employee],
                            ['Vacancy: ' + res.vacency, res.vacency]
                        ],
                        // point: {
                        //     events: {
                        //         click: function (event) {
                        //             //alert(this.x + " " + this.y);
                                    
                                    
                        //             if (this.x == 1) {
                        //                 if ($('#card_late').hasClass('collapsed-card')) {
                        //                     $('#btn_c_late').click();                                            
                        //                 }
                        //                 setTimeout(() => {
                        //                     $('#btn_c_late').focus();
                        //                 }, 100);
                                        
                        //             }
                        //             else if (this.x == 2) {
                        //                 if ($('#card_PersonalLeave').hasClass('collapsed-card')) {
                        //                     $('#btn_c_personalLeave').click();
                        //                 }
                        //                 if ($('#card_sickLeave').hasClass('collapsed-card')) {
                        //                     $('#btn_c_sickLeave').click();
                        //                 }
                        //                 if ($('#card_vacationLeave').hasClass('collapsed-card')) {
                        //                     $('#btn_c_vacationLeave').click();
                        //                 }
                        //                 if ($('#card_otherLeave').hasClass('collapsed-card')) {
                        //                     $('#btn_c_otherLeave').click();
                        //                 }
                        //                 setTimeout(() => {
                        //                 $('#btn_c_personalLeave').focus();
                        //                 }, 100);
                                        
                                        
                                        
                        //             }
                        //             else if (this.x == 3) {
                        //                 if ($('#card_losts').hasClass('collapsed-card')) {
                        //                     $('#btn_c_losts').click();
                        //                 }
                        //                 setTimeout(() => {
                        //                     $('#btn_c_losts').focus();
                        //                     }, 100);
                        //             }
                        //         }
                        //     }
                        // }
                    }]
                });
                
                /**************************************** */
            
         }
         
        });
        
        // }
    
    
}