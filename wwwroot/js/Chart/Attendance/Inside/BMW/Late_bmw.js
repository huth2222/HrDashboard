function LateBmw(getDate, getShift) {

    
    var locat = origin + "/Attendance/GetLateBmwByDate/" + getDate + '/' + getShift;
    // var locat = origin + "/Home/GetDeptListDayByDate/" + getdate + "/all";
    // alert(locat);
    $.ajax({
        type: "GET",
        url: locat,
        dataType: "JSON",
        contentType: "application/json; charset=utf-8",
        success: function (res) {

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
                '<th scope="col">' +
                'Time in' +
                '</th>' +
                '</tr>' +
                '</thead>' +
                '<tbody>';
            for (let index = 0; index < res.length; index++) {
                const arr = [];
                const element = res[index];                         
            
                                htmlLate += 
                                    '<tr>'+
                                        '<th scope="row">'+
                                            element.dept_name +
                                        '</th>'+
                                        '<td>'+
                                            element.emp_id +
                                        '</td>'+
                                        '<td>'+
                                            element.fullname +
                                        '</td> '+    
                                        '<td>'+
                                            element.time_late +
                                        '</td>'+
                                    '</tr>';
            }
                                htmlLate += '</tbody></table>';
    $('#late').html(htmlLate);
        

        }
    });
}