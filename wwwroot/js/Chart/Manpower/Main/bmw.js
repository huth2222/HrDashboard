$(document).ready(function () {
    $('#success_status').html('Module: Manpower | DL');
    
    var d = new Date();
    var month = d.getMonth() + 1;
    var day = d.getDate();
    var today = d.getFullYear() + '-' + (month < 10 ? '0' : '') + month + '-' + (day < 10 ? '0' : '') + day;
    //alert(today);
    $('#dateSelect').val(today);
    DeptCarShiftA(today);
    DeptCarShiftB(today);
    DeptMotorcycle(today);
    GenderShiftA(today);
    GenderShiftB(today);
    GenderMotorcycle(today);
    ContractShiftA(today);
    ContractShiftB(today);
    ContractMotorcycle(today);
    AgeRange(today);

    $('#dateSelect').change(() => {
        var getDate = $('#dateSelect').val();
        // var month = d.getMonth() + 1;
        // var day = d.getDate();
        // var today = d.getFullYear() + '-' +(month < 10 ? '0' : '') + month + '-' + (day < 10 ? '0' : '') + day;
        //alert(d);
        DeptCarShiftA(getDate);
        DeptCarShiftB(getDate);
        DeptMotorcycle(getDate);
        GenderShiftA(getDate);
        GenderShiftB(getDate);
        GenderMotorcycle(getDate);
        ContractShiftA(getDate);
        ContractShiftB(getDate);
        ContractMotorcycle(getDate);
        AgeRange(getDate);
    });
});