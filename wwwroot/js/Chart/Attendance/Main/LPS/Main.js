//------------------------------------
var sPageURL = window.location.search.substring(1);
sPageURL = sPageURL.substr(9); //----
var d = new Date();
var month = d.getMonth() + 1;
var day = d.getDate();
var today = d.getFullYear() + '-' + (month < 10 ? '0' : '') + month + '-' + (day < 10 ? '0' : '') + day; //----

$(document).ready(function () {
    //alert($('#company').val());
    $('#div_siteDept').show();
    $('#div_site').hide();

    $('#btn_c_personalLeave').click();
    $('#btn_c_sickLeave').click();
    $('#btn_c_vacationLeave').click();
    $('#btn_c_otherLeave').click();
    $('#btn_c_late').click();
    $('#btn_c_losts').click();

    setTimeout(() => {
        $('#pushSelect').click();
    }, 500);




    $('#companyGroup').change(function () {
        var companyGroup = parseInt($('#companyGroup').val());
        // alert();
        if (companyGroup == 1) {
            var htmlGroup1 = '';
            htmlGroup1 =
                'Company : &nbsp;' +
                '<select name="company" id="company" class="form-control">' +
                '<option value="">Select</option>' +
                '<option value="all">All</option>' +
                '<option value="LPS">LPS Business group</option>' +
                '<option value="LPSS">LPS Subcontract</option>' +
                '<option value="LPSH">LPS HEADHUNTER</option>' +
                '<option value="L&T">L&T</option>' +
                '<option value="STT">STT</option>' +
                '</select>';
            // htmlGroup =                 
            //     'Company : &nbsp;' +
            //     '<select name="company" id="company" class="form-control">' +
            //     '<option value="all">All</option>' +
            //     '<option value="LPS">LPS Business group</option>' +
            //     '<option value="LPSS">LPS Subcontract</option>' +
            //     '<option value="LPSH">LPS HEADHUNTER</option>' +
            //     '<option value="L&T">L&T</option>' +
            //     '<option value="STT">STT</option>' +
            //     '</select>';

            // alert('_1');
            $('#div_company').html('');
            $('#div_company').html(htmlGroup1);
        } else if (companyGroup == 2) {
            var htmlGroup2 = '';
            htmlGroup2 =
                'Company : &nbsp;' +
                '<select name="company" id="company" class="form-control">' +
                '<option value="">Select</option>' +
                '<option value="all">All</option>' +
                '<option value="ASTH">ASTH</option>' +
                '<option value="BET">BET</option>' +
                '<option value="BMW">BMW</option>' +
                '<option value="CAC">CAC</option>' +
                '<option value="COB">COB</option>' +
                '<option value="DAT">DAT</option>' +
                '<option value="DK">DK</option>' +
                '<option value="DSTA">DSTA</option>' +
                '<option value="HCAT">HCAT</option>' +
                '<option value="KAO คลังสินค้า">KAO คลังสินค้า</option>' +
                '<option value="KAO ฝ่ายผลิต">KAO ฝ่ายผลิต</option>' +
                '<option value="KBT">KBT</option>' +
                '<option value="MCT">MCT</option>' +
                '<option value="MHCT">MHCT</option>' +
                '<option value="OMT">OMT</option>' +
                '<option value="OST">OST</option>' +
                '<option value="PMX">PMX</option>' +
                '<option value="SDM">SDM</option>' +
                '<option value="SEAH">SEAH</option>' +
                '<option value="SKTH">SKTH</option>' +
                '<option value="SONY">SONY</option>' +
                '<option value="SRCT">SRCT</option>' +
                '<option value="STTRY">STTRY</option>' +
                '<option value="TKB">TKB</option>' +
                '<option value="TNK">TNK</option>' +
                '<option value="TNOK">TNOK</option>' +
                '<option value="TYM">TYM</option>' +
                '<option value="UICT">UICT</option>' +
                '<option value="ZT">ZT</option>' +
                '</select>';

            $('#div_company').html('');
            $('#div_company').html(htmlGroup2);

            // alert('_2');
        } else if ($('#companyGroup').val() == 0) {
            var htmlGroup0 = '';
            htmlGroup0 =
                'Company : &nbsp;' +
                '<select name="company" id="company" class="form-control">' +
                '<option value="">Select</option>' +
                '</select>';
            $('#div_company').html('');
            $('#div_company').html(htmlGroup0);

            // alert('_0');
        }
        // $('#div_company').html(htmlGroup);

    });


    $('#getZone').change(function () {
        var htmlZone = '';
        if ($('#getZone').val() == 'Rayong') {
            htmlZone =
                'Company : &nbsp;' +
                '<select name="company" id="company" class="form-control">' +
                '<option value="">Select</option>' +
                '<option value="all">All</option>' +
                '<option value="BMW">BMW</option>' +
                '<option value="HCAT">HCAT</option>' +
                '<option value="OST">OST</option>' +
                '<option value="PMX">PMX</option>' +
                '<option value="STTRY">STTRY</option>' +
                '<option value="TNK">TNK</option>' +
                '<option value="TYM">TYM</option>' +
                '</select>';


        } else if ($('#getZone').val() == 'Chonburi') {
            htmlZone =
                'Company : &nbsp;' +
                '<select name="company" id="company" class="form-control">' +
                '<option value="">Select</option>' +
                '<option value="all">All</option>' +
                '<option value="ASTH">ASTH</option>' +
                '<option value="CAC">CAC</option>' +
                '<option value="COB">COB</option>' +
                '<option value="DAT">DAT</option>' +
                '<option value="DK">DK</option>' +
                '<option value="DSTA">DSTA</option>' +
                '<option value="KAO คลังสินค้า">KAO คลังสินค้า</option>' +
                '<option value="KAO ฝ่ายผลิต">KAO ฝ่ายผลิต</option>' +
                '<option value="KBT">KBT</option>' +
                '<option value="MCT">MCT</option>' +
                '<option value="MEC">MEC</option>' +
                '<option value="MHCT">MHCT</option>' +
                '<option value="OMT">OMT</option>' +
                '<option value="SDM">SDM</option>' +
                '<option value="SEAH">SEAH</option>' +
                '<option value="SKTH">SKTH</option>' +
                '<option value="SONY">SONY</option>' +
                '<option value="SRCT">SRCT</option>' +
                '<option value="TKB">TKB</option>' +
                '<option value="TNOK">TNOK</option>' +
                '<option value="UICT">UICT</option>' +
                '<option value="ZT">ZT</option>' +
                '</select>';


        } else if ($('#getZone').val() == 'Ladkrabang') {
            htmlZone =
                'Company : &nbsp;' +
                '<select name="company" id="company" class="form-control">' +
                '<option value="">Select</option>' +
                '<option value="all">All</option>' +
                '<option value="MACO">MACO</option>' +
                '</select>';


        } else {
            htmlZone =
                'Company : &nbsp;' +
                '<select name="company" id="company" class="form-control">' +
                '<option value="">Select</option>' +
                '<option value="all">All</option>' +
                '<option value="ASTH">ASTH</option>' +
                '<option value="BET">BET</option>' +
                '<option value="BMW">BMW</option>' +
                '<option value="CAC">CAC</option>' +
                '<option value="COB">COB</option>' +
                '<option value="DAT">DAT</option>' +
                '<option value="DK">DK</option>' +
                '<option value="DSTA">DSTA</option>' +
                '<option value="HCAT">HCAT</option>' +
                '<option value="KAO คลังสินค้า">KAO คลังสินค้า</option>' +
                '<option value="KAO ฝ่ายผลิต">KAO ฝ่ายผลิต</option>' +
                '<option value="KBT">KBT</option>' +
                '<option value="MCT">MCT</option>' +
                '<option value="MHCT">MHCT</option>' +
                '<option value="OMT">OMT</option>' +
                '<option value="OST">OST</option>' +
                '<option value="PMX">PMX</option>' +
                '<option value="SDM">SDM</option>' +
                '<option value="SEAH">SEAH</option>' +
                '<option value="SKTH">SKTH</option>' +
                '<option value="SONY">SONY</option>' +
                '<option value="SRCT">SRCT</option>' +
                '<option value="STTRY">STTRY</option>' +
                '<option value="TKB">TKB</option>' +
                '<option value="TNK">TNK</option>' +
                '<option value="TNOK">TNOK</option>' +
                '<option value="TYM">TYM</option>' +
                '<option value="UICT">UICT</option>' +
                '<option value="ZT">ZT</option>' +
                '<option value="BMW">BMW</option>' +
                '<option value="HCAT">HCAT</option>' +
                '<option value="OST">OST</option>' +
                '<option value="PMX">PMX</option>' +
                '<option value="STTRY">STTRY</option>' +
                '<option value="TNK">TNK</option>' +
                '<option value="TYM">TYM</option>' +
                '<option value="ASTH">ASTH</option>' +
                '<option value="CAC">CAC</option>' +
                '<option value="COB">COB</option>' +
                '<option value="DAT">DAT</option>' +
                '<option value="DK">DK</option>' +
                '<option value="DSTA">DSTA</option>' +
                '<option value="KAO คลังสินค้า">KAO คลังสินค้า</option>' +
                '<option value="KAO ฝ่ายผลิต">KAO ฝ่ายผลิต</option>' +
                '<option value="KBT">KBT</option>' +
                '<option value="MCT">MCT</option>' +
                '<option value="MEC">MEC</option>' +
                '<option value="MHCT">MHCT</option>' +
                '<option value="OMT">OMT</option>' +
                '<option value="SDM">SDM</option>' +
                '<option value="SEAH">SEAH</option>' +
                '<option value="SKTH">SKTH</option>' +
                '<option value="SONY">SONY</option>' +
                '<option value="SRCT">SRCT</option>' +
                '<option value="TKB">TKB</option>' +
                '<option value="TNOK">TNOK</option>' +
                '<option value="UICT">UICT</option>' +
                '<option value="ZT">ZT</option>' +

                '</select>';
        }
        $('#div_company').html(htmlZone);
    });

    var d = new Date();
    var month = d.getMonth() + 1;
    var today = d.getFullYear() + '-' + (month < 10 ? '0' : '') + month + '-' + (day < 10 ? '0' : '') + day; //----

    $('#companyGroup').val(1);
    $('#getZone').prop('disabled', true);
    $('#company').val('all');
    $('#dateSelect').val(today);

    // var setStatus = setInterval(setLoading, 1500);
    $('#pushSelect').click(function () {
        var getDate = $('#dateSelect').val();
        var getCompany = $('#company').val();
        var getZone = $('#getZone').val();

        $('#div_deptListDay').html('');
        $('#late').html('');
        $('#otherLeave').html('');
        $('#personalLeave').html('');
        $('#sickLeave').html('');
        $('#vacationLeave').html('');
        $('#div_all30Day').html('');
        $('#div_allYear').html('');
        $('#losts').html('');
        $('#div_allPercentDay').html('');
        setTimeout(() => {


            if ($('#companyGroup').val() == '1') {
                $('#div_siteDept').show();
                $('#div_site').hide();
                if (getCompany == 'all') {
//alert(getDate);
                    EmpList(getDate);
                    GetDeptAttList_Lps(getDate);

                    // Overall_lps(getDate);
                    // GetDeptListAll_Lps(getDate);
                    // List30Day_lps(getDate);
                    // ListYear_lps(getDate);
                    // LeavePersonal_lps(getDate);
                    // LeaveSick_lps(getDate);
                    // LeaveVacation_lps(getDate);
                    // LeaveOther_lps(getDate);
                    // Lost_lps(getDate);
                    // Late_lps(getDate);
                } 
                // Gender_lps(getDate, getCompany);
                // ListMonth_lps(getDate, getCompany);
                // ListDept_lps(getDate, getCompany);
            } else if ($('#companyGroup').val() == '2') {
                // $('#div_siteDept').hide();
                // $('#div_site').show();
                // Monthly_site(getDate, getCompany, getZone);
                // Gender_site(getDate, getCompany, getZone);
                // ListMonth_site(getDate, getCompany, getZone);
                // ListCus_site(getDate, getCompany, getZone);
            } else {
                $('#div_siteDept').hide();
                $('#div_site').hide();
            }
        }, 500);

    });
    $('#companyGroup').change(function () {
        if ($('#companyGroup').val() == '1') {
            $('#getZone').prop('disabled', true);
            $('#getZone').val('');
            $('#company').val('all');
        } else if ($('#companyGroup').val() == '2') {
            $('#getZone').prop('disabled', false);
        }
    });
    $('#getZone').change(function () {
        $('#company').val('all');
    });

});



/******************************************************** */