function LeavePersonalBmw(getDate, getShift) {

    var locat = origin + "/Attendance/GetLeavePersonal/" + getDate + '/' + getShift;
    // var locat = origin + "/Home/GetDeptListDayByDate/" + getdate + "/all";
    //alert(locat);
    $.ajax({
        type: "GET",
        url: locat,
        dataType: "JSON",
        contentType: "application/json; charset=utf-8",
        success: function (res) {

            var html = '<table class="table table-striped table-hover">' +
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
                '</tr>' +
                '</thead>' +
                '<tbody>';
            for (let index = 0; index < res.length; index++) {                
                const element = res[index];                         
            
                                html +=
                                    '<tr>' +
                                        '<th scope="row">'+
                                            element.dept_name +
                                        '</th>'+
                                        '<td>'+
                                            element.emp_id +
                                        '</td>'+
                                        '<td>'+
                                            element.fullname +
                                        '</td> '+    
                                    '</tr>';
            }
                                html += '</tbody></table>';
            $('#personalLeave').html(html);
            
            //alert(htmlLost);
        }
    });
}