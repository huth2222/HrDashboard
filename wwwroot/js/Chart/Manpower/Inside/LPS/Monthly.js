$(document).ready(()=>{
    $('#div_taget').hide();
    $('#div_emp').hide();
    $('#div_vacancy').hide();
});
function Monthly_lps(getDate, getCompany) {
    
    // $('#div_allPercentDay').html('');
    //     $('#div_allPercentDay').html('<canvas id="deptListDay" style="min-height: 250px; height: 250px; max-height: 250px; max-width: 100%;"></canvas>');
    // alert('AllPercentDay');
    var locat = origin + "/Manpower/GetManMonthlyLpsByDate/" + getDate + '/' + getCompany;
    // alert(locat);
    $.ajax({
            type: "GET",
            url: locat,
            dataType: "JSON",
            contentType: "application/json; charset=utf-8",
            success: (res) => {

                //$('#l_target').html(res.target);
                $('#l_target').html(155);

                //$('#l_emp').html(res.employee);
                $('#l_emp').html(155);
                let percent_emp = parseFloat((res.employee/res.target*100)).toFixed(2) + '%';
                $('#p_emp').css('width',percent_emp);
                $('#l_percent_emp').html(percent_emp);

                $('#l_vacancy').html(res.vacency);
                let percent_vacancy = parseFloat((res.vacency/res.target*100)).toFixed(2) + '%';
                $('#p_vacancy').css('width',percent_vacancy);
                $('#l_percent_vacancy').html(percent_vacancy);
                
                $('#div_taget').fadeIn(3000);
                $('#div_emp').fadeIn(3000);
                $('#div_vacancy').fadeIn(3000);

                
                
                /**************************************** */
            
         }
         
        });
        
        // }
    
    
}