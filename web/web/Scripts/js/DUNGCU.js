$('#saveDC').off('click').on('click', function () {
    var formData = new FormData();
    if (formData != undefined) {
        var row = $('#table tr').length;
        var dataImg = [];
        for (var i = 0; i < row; i++) {
            var fileUpload = $("#inputGroupFile_" + i)[0].files[0];
            if (fileUpload == undefined) {
                $('#erro').text('Vui lòng chọn ảnh');
                return;
            }
            dataImg.push(fileUpload.name);
            formData.append('file', fileUpload);
        }
    }
    if ($('#ma').val() == '' || $('#ten').val() == '' || $('#mota').val() == '' || $('#giaban').val() == '' || $('#gianhap').val() == '' || $('#kichthuoc').val() == '' || $('#dotuoi').val() == '' || $('#trongluong').val() == '' || $('#thuonghieu').val() == '' || $('#ncc').val() == '' || $('#xuatxu').val() == '' || $('#LOAICD').val() == '') {
        $('#erro').text('Vui lòng nhập đủ thông tin');
        return;
    }
    if ($('#giaban').val() < 0 || $('#gianhap').val() < 0) {
        $('#erro').text('Vui lòng nhập giá bán và giá nhập lớn hơn 0');
        return;
    }
    var data = {
        MASP: $('#ma').val(),
        TENSP: $('#ten').val(),
        MOTA: $('#mota').val(),
        GIABAN: $('#giaban').val(),
        GIANHAP: $('#gianhap').val(),
        KICHTHUOC: $('#kichthuoc').val(),
        DOTUOI: $('#dotuoi').val(),
        TRONGLUONG: $('#trongluong').val(),
        NCC: $('#ncc').val(),
        XX: $('#xuatxu').val(),
        LOAICD: $('#LOAICD').val(),
        HINH: dataImg
    };
    $.ajax({
        url: '/Admin/THEMDUNGCU',
        data: { cartModel: JSON.stringify(data) },
        dataType: 'json',
        type: 'POST',
        success: function (res) {
            if (res.status == true) {
                $.ajax({
                    url: "/Admin/UploadFiles",
                    method: "POST",
                    data: formData,
                    processData: false,
                    contentType: false,
                    success: function (data) {
                        window.location.href = "/Admin/DUNGCU";
                    },
                    error: function (data) {
                    }
                })
            } else {
                $('#erro').text(res.erro);
            }
        }
    });
});
$('#saveSuaDC').off('click').on('click', function () {
    var formData = new FormData();
    if (formData != undefined) {
        var row = $('#table2 tr').length;
        var dataImg = [];
        if (row > 0) {
            for (var i = 0; i < row; i++) {
                var fileUpload = $("#inputGroupFileSua_" + i)[0].files[0];
                if (fileUpload == undefined) {
                    $('#erroSua').text('Vui lòng chọn ảnh');
                    return;
                }
                dataImg.push(fileUpload.name);
                formData.append('file', fileUpload);
            }
        }
    }
    if ($('#masua').val() == '' || $('#tensua').val() == '' || $('#motasua').val() == '' || $('#giabansua').val() == '' || $('#gianhapsua').val() == '' || $('#kichthuocsua').val() == '' || $('#dotuoisua').val() == '' || $('#trongluongsua').val() == '' || $('#thuonghieusua').val() == '' || $('#nccsua').val() == '' || $('#xuatxusua').val() == '' || $('#LOAICDsua').val() == '') {
        $('#erroSua').text('Vui lòng nhập đủ thông tin');
        return;
    }
    if ($('#giaban').val() < 0 || $('#gianhap').val() < 0) {
        $('#erro').text('Vui lòng nhập giá bán và giá nhập lớn hơn 0');
        return;
    }
    var data = {
        MASP: $('#masua').val(),
        TENSP: $('#tensua').val(),
        MOTA: $('#motasua').val(),
        GIABAN: $('#giabansua').val(),
        GIANHAP: $('#gianhapsua').val(),
        KICHTHUOC: $('#kichthuocsua').val(),
        DOTUOI: $('#dotuoisua').val(),
        TRONGLUONG: $('#trongluongsua').val(),
        NCC: $('#nccsua').val(),
        XX: $('#xuatxusua').val(),
        LOAICD: $('#LOAICDsua').val(),
        HINH: dataImg
    };
    $.ajax({
        url: '/Admin/UPDATEDUNGCU',
        data: { cartModel: JSON.stringify(data) },
        dataType: 'json',
        type: 'POST',
        success: function (res) {
            if (res.status == true) {
                $.ajax({
                    url: "/Admin/UploadFiles",
                    method: "POST",
                    data: formData,
                    processData: false,
                    contentType: false,
                    success: function (data) {
                    },
                    error: function (data) {
                    }
                })
                window.location.href = "/Admin/DUNGCU";
            } else {
                $('#erroSua').text(res.erro);
            }
        }
    });
});