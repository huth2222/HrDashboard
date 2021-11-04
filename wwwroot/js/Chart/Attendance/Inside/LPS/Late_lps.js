function Late_lps(getDate) {
    
    
    var locat = origin + "/Attendance/GetLateLps/" + getDate;
    // var locat = origin + "/Home/GetDeptListDayByDate/" + getdate + "/all";
    // alert(locat);
    $.ajax({
        type: "GET",
        url: locat,
        dataType: "JSON",
        contentType: "application/json; charset=utf-8",
        success: function (res) {
            $('#success_status').html('Loading successfully.');

            var htmlLate = '<table class="table table-striped table-hover">' +
                '<thead>' +
                '<tr>' +
                '<th scope="col">' +
                'Department' +
                '</th>' +
                '<th scope="col">' +
                'No.' +
                '</th>' +
                '<th scope="col">' +
                'Name' +
                '</th> ' +
                '<th scope="col" class="text-center">' +
                'Time in' +
                '</th>' +
                '</tr>' +
                '</thead>' +
                '<tbody>';
            for (let index = 0; index < res.length; index++) {
                const arr = [];
                const element = res[index];
                
            
                htmlLate += element.lateCount >= 3 ? '<tr style="color:red;">' : '<tr>';
                                    htmlLate += 
                                        '<th scope="row">'+
                                            element.dept +
                                        '</th>'+
                                        '<td>'+
                                            element.personCode +
                                        '</td>'+
                                        '<td>'+
                                            element.fullname +
                                        '</td> '+    
                                        '<td class="text-center">'+
                                            element.scanTime +
                                        '</td>'+
                                    '</tr>';
            }
                                htmlLate += '</tbody></table>';
    $('#late').html(htmlLate);
        

        }
    });
}