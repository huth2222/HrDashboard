$('.date-own').datepicker({
    minViewMode: 2,
    format: 'yyyy-MM'
});

//------------------------------------
var sPageURL = window.location.search.substring(1);
sPageURL = sPageURL.substr(9); //----
var d = new Date();
var month = d.getMonth() + 1;
var day = d.getDate();
var today = (month < 10 ? '0' : '') + month + '/' + d.getFullYear(); //----

$(document).ready(function () {
    if ($('#sesionCompany').val() == 'all') {
        $('#div_siteDept').hide();
    } else {
        $('#div_site').hide();
    }

var d = new Date();
var month = d.getMonth() + 1;

var today = d.getFullYear() + '-' + (month < 10 ? '0' + month : month) + '-01'; //----
// if (mount == null || mount.length < 7) {
//     mount = today;
// }
    var monthly = (month < 10 ? '0' + month : month) + '/' + d.getFullYear();

//var getMount = mount.substring(3, 7) + '-' + mount.substring(0, 2) + '-01';

    Monthly_bmw(today);
    Gender_bmw(today);
    ListMonth_bmw(today);
    ListDept_bmw(today);
    ListSite_bmw(today);


    $('#mountSelect').val(monthly);
    $('#sec').val(monthly);
    $('#MonthPicker_mountSelect').click(function () {

        if ($('#mountSelect').val() != $('#sec').val()) {
            $('#sec').val($('#mountSelect').val());
            var oMonth = $('#mountSelect').val();
            var getmonth = oMonth.substring(3) + '-' + oMonth.substring(0, 2) + '-01';
            Monthly_bmw(getmonth);
            Gender_bmw(getmonth);
            ListMonth_bmw(getmonth);
            ListDept_bmw(getmonth);
            ListSite_bmw(getmonth);
        }
    });
});



/******************************************************** */






