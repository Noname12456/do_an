$('#save').off('click').on('click', function () {
    var formData = new FormData();
    if (formData != undefined) {
        var row = $('#table tr').length;
        var dataImg = [];
        var list = $('.hinh4');
        $.each(list, function (i, item) {
            var fileUpload = $("#inputGroupFile_" + $(item).data('id'))[0].files[0];
            var fileUpload = $("#inputGroupFile_" + $(item).data('id'))[0].files[0];
            if (fileUpload == undefined) {
                $('#erro').text('Vui lòng chọn ảnh');
                return;
            }
            dataImg.push(fileUpload.name);
            formData.append('file', fileUpload);
        });
    }
    if ($('#ma').val() == '' || $('#ten').val() == '' || $('#mota').val() == '' || $('#giaban').val() == '' || $('#gianhap').val() == '' || $('#kichthuoc').val() == '' || $('#sotrang').val() == '' || $('#dotuoi').val() == '' || $('#trongluong').val() == '' || $('#thuonghieu').val() == '' || $('#ncc').val() == '' || $('#nxb').val() == '' || $('#xuatxu').val() == '' || $('#ngonngu').val() == '' || $('#tacgia').val() == '' || $('#LOAICD').val() == '') {
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
        SOTRANG: $('#sotrang').val(),
        DOTUOI: $('#dotuoi').val(),
        TRONGLUONG: $('#trongluong').val(),
        TACGIA: $('#tacgia').val(),
        NCC: $('#ncc').val(),
        NXB: $('#nxb').val(),
        NN: $('#ngonngu').val(),
        XX: $('#xuatxu').val(),
        LOAICD: $('#LOAICD').val(),
        HINH: dataImg
    };
    $.ajax({
        url: '/Admin/THEMSACH',
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
                        window.location.href = "/Admin/SACH";
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
$('#themImg').off('click').on('click', function () {
    var table = document.getElementById("table");
    var row = $('#table tr').length;
    var str = '<tr id="row_' + row + '"><td><img src="#" id="img_' + row + '" style="width:120px;height:120px"/></td><td><div class="input-group mb-3"><div class="custom-file"><input type="file" class="custom-file-input hinh4" id="inputGroupFile_' + row + '" name="" onchange="loadImg(this,' + row + ')" data-id="'+row+'"><label class="custom-file-label" for="inputGroupFile_' + row + '">Choose file</label></div></div></td><td><button type="button" class="btn btn-danger" name="them" value="them" onclick="XoaImg(' + row + ')" style="margin-bottom: 17px">Xóa</button></td></tr>';
    $('#table tbody').append(str);
    $('#img_' + row).hide();
});
function XoaImg(rowDelete) {
    var row = $('#table tr').length;
    if (row > 1) {
        $('#row_' + rowDelete).remove();
    }
}
function XoaImgSua(rowDelete) {
    var row = $('#table2 tr').length;
    if (row > 1) {
        $('#rowsua_' + rowDelete).remove();
    }
}
function loadImg(input, row) {
    if (input.files && input.files[0]) {
        var read = new FileReader();
        read.onload = function (e) {
            $('#img_' + row).attr("src", e.target.result);
        }
        read.readAsDataURL(input.files[0]);
        $('#img_' + row).show();
    }
}
function loadImgSua(input, row) {
    if (input.files && input.files[0]) {
        var read = new FileReader();
        read.onload = function (e) {
            $('#imgsua_' + row).attr("src", e.target.result);
        }
        read.readAsDataURL(input.files[0]);
        $('#imgsua_' + row).show();
    }
}
function ChiTiet(id) {
    var data = {
        id: id
    }
    $("#load_"+id).load(location.href + " #load2_" + id);
    $.ajax({
        url: '/Admin/CHITIETSACH',
        data: { cartModel: JSON.stringify(data) },
        dataType: 'json',
        type: 'POST',
        success: function (res) {
            if (res.status == true) {
                
                $('#masua').val(res.data[0].MASP);
                $('#tensua').val(res.data[0].TENSP);
                $('#motasua').val(res.data[0].MOTA);
                $('#giabansua').val(res.data[0].GIABAN);
                $('#gianhapsua').val(res.data[0].GIANHAP);
                $('#kichthuocsua').val(res.data[0].KICHTHUOC);
                $('#sotrangsua').val(res.data[0].SOTRANG);
                $('#dotuoisua').val(res.data[0].DOTUOI);
                $('#trongluongsua').val(res.data[0].TRONGLUONG);
                $('#tacgiasua').val(res.data[0].TACGIA);
                $('#nccsua').val(res.data[0].MANCC);
                $('#nccsua').select2().trigger('change');
                $('#nxbsua').val(res.data[0].MANXB);
                $('#nxbsua').select2().trigger('change');
                $('#ngonngusua').val(res.data[0].NGONNGU);
                $('#ngonngusua').select2().trigger('change');
                $('#xuatxusua').val(res.data[0].XUATXU);
                $('#xuatxusua').select2().trigger('change');
                var itemTg = [];
                for (var i = 0; i < res.dataTG.length; i++) {
                    var item = res.dataTG[i]
                    itemTg.push(item.ID);
                }
                $('#tacgiasua').val(itemTg);
                $('#tacgiasua').select2().trigger('change');
                var itemcd = [];
                for (var i = 0; i < res.dataCD.length; i++) {
                    var item = res.dataCD[i]
                    itemcd.push(item.ID);
                }
                $('#LOAICDsua').val(itemcd);
                $('#LOAICDsua').select2().trigger('change');
                for (var i = 0; i < res.dataHinh.length; i++) {
                    if (res.dataHinh[i].disabled == 0) {
                        $('#phuc' + res.dataHinh[i].ID + '_' + i).hide();
                        $('#div1').append('<div class="col-3"><button type="button" class="btn btn-danger" name="them" value="' + res.dataHinh[i].MASP + '" onclick=PhucHoiImg(' + res.dataHinh[i].ID + ',' + i + ') style="margin-bottom: 17px" id="phuc' + res.dataHinh[i].ID + '_' + i + '">Phục hồi</button><button type="button" class="btn btn-danger" name="them" value="' + res.dataHinh[i].MASP + '" onclick=DelImg(' + res.dataHinh[i].ID + ',' + i + ') style="margin-bottom: 17px" id="xoa' + res.dataHinh[i].ID + '_' + i + '">Xóa</button><img class="card-img-top" src="/IMG/' + res.dataHinh[i].HINH + '" style="width:100%;height:120px"/></div>');
                    } else {
                        $('#xoa' + res.dataHinh[i].ID + '_' + i).hide();
                        $('#div1').append('<div class="col-3"><button type="button" class="btn btn-danger" name="them" value="' + res.dataHinh[i].MASP + '" onclick=PhucHoiImg(' + res.dataHinh[i].ID + ',' + i + ') style="margin-bottom: 17px" id="phuc' + res.dataHinh[i].ID + '_' + i + '">Phục hồi</button><button type="button" class="btn btn-danger" name="them" value="' + res.dataHinh[i].MASP + '" onclick=DelImg(' + res.dataHinh[i].ID + ',' + i + ') style="margin-bottom: 17px" id="xoa' + res.dataHinh[i].ID + '_' + i + '">Xóa</button><img class="card-img-top" src="/IMG/' + res.dataHinh[i].HINH + '" style="width:100%;height:120px" /></div>');
                    }
                }
            }
            else {
                $('#erro').text(res.erro);
            }
        }
    });
}
$('#saveSua').off('click').on('click', function () {
    var formData = new FormData();
    if (formData != undefined) {
        var row = $('#table2 tr').length;
        var dataImg = [];
        var list = $('.hinh5');
        $.each(list, function (i, item) {
            var fileUpload = $("#inputGroupFile_" + $(item).data('id'))[0].files[0];
            var fileUpload = $("#inputGroupFile_" + $(item).data('id'))[0].files[0];
            if (fileUpload == undefined) {
                $('#erro').text('Vui lòng chọn ảnh');
                return;
            }
            dataImg.push(fileUpload.name);
            formData.append('file', fileUpload);
        });
    }
    if ($('#masua').val() == '' || $('#tensua').val() == '' || $('#motasua').val() == '' || $('#giabansua').val() == '' || $('#gianhapsua').val() == '' || $('#kichthuocsua').val() == '' || $('#sotrangsua').val() == '' || $('#dotuoisua').val() == '' || $('#trongluongsua').val() == '' || $('#thuonghieusua').val() == '' || $('#nccsua').val() == '' || $('#nxbsua').val() == '' || $('#xuatxusua').val() == '' || $('#ngonngusua').val() == '' || $('#tacgiasua').val() == '' || $('#LOAICDsua').val() == '') {
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
        SOTRANG: $('#sotrangsua').val(),
        DOTUOI: $('#dotuoisua').val(),
        TRONGLUONG: $('#trongluongsua').val(),
        TACGIA: $('#tacgiasua').val(),
        NCC: $('#nccsua').val(),
        NXB: $('#nxbsua').val(),
        NN: $('#ngonngusua').val(),
        XX: $('#xuatxusua').val(),
        LOAICD: $('#LOAICDsua').val(),
        HINH: dataImg
    };
    $.ajax({
        url: '/Admin/UPDATESACH',
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
                window.location.href = "/Admin/SACH";
            } else {
                $('#erroSua').text(res.erro);
            }
        }
    });
});
function DelImg(id, vt) {
    var data = {
        id: id,
        masp: $('#xoa' + id + '_' + vt).val()
    }
    $('#xoa' + id + '_' + vt).hide();
    $('#phuc' + id + '_' + vt).show();
    $.ajax({
        url: '/Admin/XOAANH',
        data: { cartModel: JSON.stringify(data) },
        dataType: 'json',
        type: 'POST',
        success: function (res) {
            if (res.success == true) {
            }
            else {
                $('#erro').text(res.erro);
            }
        }
    });
}
function PhucHoiImg(id, vt) {
    var data = {
        id: id,
        masp: $('#phuc' + id + '_' + vt).val()
    }
    $('#xoa' + id + '_' + vt).show();
    $('#phuc' + id + '_' + vt).hide();
    $.ajax({
        url: '/Admin/PHUCHOI',
        data: { cartModel: JSON.stringify(data) },
        dataType: 'json',
        type: 'POST',
        success: function (res) {
            if (res.success == true) {
            }
            else {
                $('#erro').text(res.erro);
            }
        }
    });
}