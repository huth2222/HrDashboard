$('#div_lost').hide();
$('#div_leave').hide();
$('#div_late').hide();
$('#div_info').hide();
$(document).ready(()=>{
    $('#more_lost').click(()=>{
        $('#btn_c_losts').click();        
        if($('#i_lost').hasClass('fa-minus')){
            window.location.href = '#losts';
        }
    });

    $('#more_leave').click(()=>{
        $('#btn_c_personalLeave').click();   
        $('#btn_c_sickLeave').click();
        $('#btn_c_vacationLeave').click();     
        $('#btn_c_otherLeave').click(); 
        if($('#l_personalLeave').hasClass('fa-minus')){
            window.location.href = '#personalLeave';
        }
    });

    $('#more_late').click(()=>{
        $('#btn_c_late').click();        
        if($('#i_late').hasClass('fa-minus')){
            window.location.href = '#late';
        }
    });

    $('#more_info').click(()=>{
        $('#btn_c_infos').click();        
        if($('#i_info').hasClass('fa-minus')){
            window.location.href = '#losts';
        }
    });
});
function Overall_lps(getDate) {
    //alert();
    $('#success_status').html('Loading...');

    var locat = origin + "/Attendance/GetOverAllLpsToday/" + getDate;
    // alert(locat);
    $.ajax({
            type: "GET",
            url: locat,
            dataType: "JSON",
            contentType: "application/json; charset=utf-8",
            success: (res) => {

                var shiftLabels = [];

                
                var dataSetIn = [];
                var dataSetLate = [];
                var dataSetLeave = [];
                var dataSetLost = [];

                    dataSetIn.push(res.timeIn);
                    // dataAllPercent.push(element.timeins);
                    
                    dataSetLost.push(res.losts);
                    dataSetLeave.push(res.leaves);
                    dataSetLate.push(res.timeLate);
                    
                    
                


            
                

/********************************************************** */

                var dataIn = parseInt(dataSetIn);
                var dataLate = parseInt(dataSetLate);
                var dataLeave = parseInt(dataSetLeave);
                var dataLost = parseInt(dataSetLost);
                let totalAll = dataIn + dataLate + dataLeave + dataLost;

                $('#topic_allPercentDay').html('Overall daily report (พนักงานทั้งหมด ' + totalAll + ' คน)');
//alert(dataLost);
                $('#l_lost').html(dataLost.toString());
                let percent_lost = parseFloat((dataLost/(dataIn+dataLate+dataLeave+dataLost)*100)).toFixed(2)+'%';
                $('#p_lost').css('width',percent_lost);
                $('#l_percent_lost').html(percent_lost);

                $('#l_leave').html(dataLeave.toString());
                let percent_leave = parseFloat((dataLeave/(dataIn+dataLate+dataLeave+dataLost)*100)).toFixed(2)+'%';
                $('#p_leave').css('width',percent_leave);
                $('#l_percent_leave').html(percent_leave);

                $('#l_late').html(dataLate.toString());
                let percent_late = parseFloat((dataLate/(dataIn+dataLate+dataLeave+dataLost)*100)).toFixed(2)+'%';
                $('#p_late').css('width',percent_late);
                $('#l_percent_late').html(percent_late);

                $('#l_info').html(dataIn.toString());
                let percent_info = parseFloat((dataIn/(dataIn+dataLate+dataLeave+dataLost)*100)).toFixed(2)+'%';
                $('#p_info').css('width',percent_info);
                $('#l_percent_info').html(percent_info);
                

                $('#div_lost').fadeIn(3000);
                $('#div_leave').fadeIn(3000);
                $('#div_late').fadeIn(3000);
                $('#div_info').fadeIn(3000);
            
         }
         
        });
}