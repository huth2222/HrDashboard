$(document).ready(function () {
    $('#companyZone').val('');
    $('#companyZone').prop('disabled', true);
    $('#group1').click(function () {

        $('#companyZone').val('');
        $('#companyZone').prop('disabled', true);
        $.ajax({
            type: "GET",
            url: origin + "/Manpower/GetManCompanyById/1/all",
            dataType: "JSON",
            contentType: "application/json; charset=utf-8",
            success: (res) => {
                var htmlZone = '<label id="labelName" for="companyName">สังกัดบริษัท</label>' +
                    '<select name="companys" id="companys" class="form-control"><option value="">Select</option>';

                for (let index = 0; index < res.length; index++) {

                    const element = res[index];
                    htmlZone += '<option value="' + element.iD_Company + '">' + element.company_Code + '</option>';

                }
                htmlZone += '</select>';
                $('#div_companyName').html(htmlZone);

            }
        });

    });
    $('#group2').click(function () {
        $('#companyZone').prop('disabled', false);
        var htmlZone = '<label id="labelName" for="companyName">ชื่อไซต์งาน</label>' +
            '<select name="companys" id="companys" class="form-control"><option value="">Select</option></select>';
        $('#div_companyName').html(htmlZone);

    });
    $('#companyZone').change(function () {
        if ($('#companyZone').val() == '') {
            var htmlZone = '<label id="labelName" for="companyName">ชื่อไซต์งาน</label>' +
                '<select name="companys" id="companys" class="form-control"><option value="">Select</option><option value="x">x</option></select>';
            $('#div_companyName').html(htmlZone);
        } else {
            $.ajax({
                type: "GET",
                url: origin + "/Manpower/GetManCompanyById/2/" + $('#companyZone').val(),
                dataType: "JSON",
                contentType: "application/json; charset=utf-8",
                success: (res) => {
                    var htmlZone = '<label id="labelName" for="companyName">ชื่อไซต์งาน</label>' +
                        '<select name="companys" id="companys" class="form-control"><option value="">Select</option>';

                    for (let index = 0; index < res.length; index++) {

                        const element = res[index];
                        htmlZone += '<option value="' + element.iD_Company + '">' + element.company_Code + '</option>';

                    }
                    htmlZone += '</select>';
                    $('#div_companyName').html(htmlZone);
                }
            });
        }
    });
    //alert('info');
    $('#btn_submit').click(function () {
        //alert();
        var d = new Date($('#startdate').val());
        var day = d.getDate();
        var month = d.getMonth() + 1;
        var getDate = d.getFullYear() + '-' + (month < 10 ? '0' : '') + month + '-' + (day < 10 ? '0' : '') + day;
        // alert($('#companys').val());
        $.ajax({
            type: "GET",
            url: origin + "/Manpower/GetManListCusSiteFindByDate/" + getDate + '/' + $('#companys').val(),
            dataType: "JSON",
            contentType: "application/json; charset=utf-8",
            success: (res) => {
                // alert(res[0].employee);
                $('#empInfo').val(res[0].employee);
                setTimeout(() => {
                    $('#pushSubmit').submit();
                }, 1000);
            }
        });
        //     $.ajax({
        //         type: "GET",
        //         url: origin + "/Manpower/GetManCompanyNameById/" + $('#company').val(),
        //         dataType: "JSON",
        //         contentType: "application/json; charset=utf-8",
        //         success: (res) => {

        //             $('#comName').html(res.company_Code);
        //         }
        //     });
        //     setTimeout(() => {
        //         if ($('#companyZone').val() == '') {
        //             var d = new Date();
        //             var month = d.getMonth() + 1;
        //             var today = d.getFullYear() + '-' + (month < 10 ? '0' : '') + month + '-' + (day < 10 ? '0' : '') + day;
        //             $.ajax({
        //                 type: "GET",
        //                 url: origin + "/Manpower/GetManCompanyById/2/" + $('#companyZone').val(),
        //                 dataType: "JSON",
        //                 contentType: "application/json; charset=utf-8",
        //                 success: (res) => {
        //                     var htmlZone = '<label id="labelName" for="companyName">ชื่อไซต์งาน</label>' +
        //                         '<select name="company" id="company" class="form-control"><option value="">Select</option>';

        //                     for (let index = 0; index < res.length; index++) {

        //                         const element = res[index];
        //                         htmlZone += '<option value="' + element.iD_Company + '">' + element.company_Code + '</option>';

        //                     }
        //                     htmlZone += '</select>';
        //                     $('#div_companyName').html(htmlZone);
        //                 }
        //             });
        //         } else {
        //             $.ajax({
        //                 type: "GET",
        //                 url: origin + "/Manpower/GetManListCusSiteByDate/" + today + $('#comName').val() + '/' + $('#companyZone').val(),
        //                 dataType: "JSON",
        //                 contentType: "application/json; charset=utf-8",
        //                 success: (res) => {

        //                     $('#empInfo').html(res[0].employee);
        //                 }
        //             });
        //         }
        //     }, 1000);
        return false;

    });
});