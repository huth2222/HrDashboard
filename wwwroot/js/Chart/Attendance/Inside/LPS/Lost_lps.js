function Lost_lps(getDate) {
    
    var locat = origin + "/Attendance/GetLostLps/" + getDate;
    // var locat = origin + "/Home/GetDeptListDayByDate/" + getdate + "/all";
    //alert(locat);
    $.ajax({
        type: "GET",
        url: locat,
        dataType: "JSON",
        contentType: "application/json; charset=utf-8",
        success: function (res) {

            var htmlLost = '<table class="table table-striped table-hover">' +
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
            
                                htmlLost += 
                                    '<tr>'+
                                        '<th scope="row">'+
                                            element.dept +
                                        '</th>'+
                                        '<td>'+
                                            element.personCode +
                                        '</td>'+
                                        '<td>'+
                                            element.fullname +
                                        '</td> ' +
                                    '</tr>';
            }
                                htmlLost += '</tbody></table>';
    $('#losts').html(htmlLost);        
            //alert(htmlLost);
        }
    });
}