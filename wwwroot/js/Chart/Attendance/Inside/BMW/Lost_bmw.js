function LostBmw(getDate, getShift) {
    //alert(getDate + '\n' + getShift);
    // var locat = origin + "/Attendance/GetLostBmwByDate/" + getDate + '/' + getShift;
    // // var locat = origin + "/Home/GetDeptListDayByDate/" + getdate + "/all";
    // //alert(locat);
    // $.ajax({
    //     type: "GET",
    //     url: locat,
    //     dataType: "JSON",
    //     contentType: "application/json; charset=utf-8",
    //     success: function (res) {

    //         var htmlLost = '<table class="table table-striped table-hover">' +
    //             '<thead>' +
    //             '<tr>' +
    //             '<th scope="col">' +
    //             'Department' +
    //             '</th>' +
    //             '<th scope="col">' +
    //             'No.' +
    //             '</th>' +
    //             '<th scope="col">' +
    //             'Name' +
    //             '</th> ' +
    //             '<th scope="col">' +
    //             'Remark' +
    //             '</th> ' +
    //             '</tr>' +
    //             '</thead>' +
    //             '<tbody>';
    //         for (let index = 0; index < res.length; index++) {                
    //             const element = res[index];                         
            
    //                             htmlLost += 
    //                                 '<tr>'+
    //                                     '<th scope="row">'+
    //                                         element.dept_name +
    //                                     '</th>'+
    //                                     '<td>'+
    //                                         element.emp_id +
    //                                     '</td>'+
    //                                     '<td>'+
    //                                         element.fullname +
    //                                     '</td> ' +
    //                                     '<td>'+
    //                                         element.remark +
    //                                     '</td> '+ 
    //                                 '</tr>';
    //         }
    //                             htmlLost += '</tbody></table>';
    // $('#losts').html(htmlLost);        
    //         //alert(htmlLost);
    //     }
    // });
}