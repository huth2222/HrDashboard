$('#div_holiday').hide();
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