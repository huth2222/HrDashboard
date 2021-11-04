function LeaveOther_lps(getDate) {
    
    var locat = origin + "/Attendance/GetOtherLeaveLps/" + getDate;
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
                '<th scope="col">' +
                'Remark' +
                '</th> ' +
                '</tr>' +
                '</thead>' +
                '<tbody>';
            for (let index = 0; index < res.length; index++) {                
                const element = res[index];                         
            
                                html +=
                                    '<tr>'+
                                        '<th scope="row">'+
                                            element.dept +
                                        '</th>'+
                                        '<td>'+
                                            element.personCode +
                                        '</td>'+
                                        '<td>'+
                                            element.fullname +
                                        '</td> '+    
                                        '<td>' +
                                            element.leaveNameT +
                                            '</td> ' +
                                    '</tr>';
            }
                                html += '</tbody></table>';
            $('#otherLeave').html(html);
            
            //alert(htmlLost);
        }
    });
}