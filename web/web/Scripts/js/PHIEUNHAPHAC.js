$(document).ready(function () {
    $('#btnLuuNK').off('click').on('click', function () {
        if ($('#nn').val() == "" || $('#ghichu').val() == "") {
            $('#erro').text('Vui lòng nhập đầy đủ thông tin');
            return;
        }
        var data_list = [];
        var row = $('#table3 tbody tr').length;
        for (var i = 0; i < row; i++) {
            if ($('#detail' + i + 'Code').text() != "") {
                if ($('#detail' + i + 'SL').val() == "" || $('#detail' + i + 'GC').val() == "") {
                    $('#erro').text('Vui lòng nhập ghi chú và số lượng');
                    return;
                }
            }
            if (Number($('#detail' + i + 'SL').val()) != 0) {
                if ($('#detail' + i + 'Code').text() == "" || $('#detail' + i + 'GC').val() == "") {
                    $('#erro').text('Vui lòng thêm sản phẩm');
                    return;
                }
            }
            if ($('#detail' + i + 'Code').text() != "" && $('#detail' + i + 'GC').val() != "" && $('#detail' + i + 'SL').val() != "") {
                data_list.push({
                    masp: $('#detail' + i + 'Code').text(),
                    SL: $('#detail' + i + 'SL').val(),
                    GhiChu: $('#detail' + i + 'GC').val(),
                })
            }
        }
        if (data_list.length == 0) {
            $('#erro').text('Vui lòng thêm sản phẩm');
            return;
        }
        var data = {
            ngaynhap: $('#ngaynhan').val(),
            cn: $('#cn').val(),
            ghichu: $('#ghichu').val(),

        };
        $.ajax({
            url: '/Admin/THEMPHIEUNHAPKHAC',
            data: { cartModel: JSON.stringify(data) },
            dataType: 'json',
            type: 'POST',
            success: function (res) {
                if (res.status == true) {
                    for (var i = 0; i < row; i++) {
                        if ($('#detail' + i + 'Code').text() != "" && $('#detail' + i + 'GC').val() != "" && $('#detail' + i + 'SL').val() != "") {
                            var data_list_item = {
                                maphieu: res.ID,
                                masp: $('#detail' + i + 'Code').text(),
                                SL: $('#detail' + i + 'SL').val(),
                                GhiChu: $('#detail' + i + 'GC').val(),
                            }
                            $.ajax({
                                url: '/Admin/THEMPHIEUNHAPKHACCT',
                                data: { cartModel: JSON.stringify(data_list_item) },
                                dataType: 'json',
                                type: 'POST',
                                success: function (res) {
                                }
                            });
                        }
                    }
                    window.location.href = "/Admin/PHIEUNHAPKHAC";
                } else {
                    $('#erro').text(res.erro);
                }
            }
        });
    });
});
function btnLmMsNK(ma) { 
    window.location.href = "/Admin/CNPHIEUNHAPKHAC/"+ma;
}
function suaphieunhapkhac(ma) {
    if ($('#nn').val() == "" || $('#ghichu').val() == "") {
        $('#erro').text('Vui lòng nhập đầy đủ thông tin');
        return;
    }
    var data_list = [];
    var row = $('#table3 tbody tr').length;
    for (var i = 0; i < row; i++) {
        if ($('#detail' + i + 'Code').text() != "") {
            if ($('#detail' + i + 'SL').val() == "" || $('#detail' + i + 'GC').val() == "") {
                $('#erro').text('Vui lòng nhập ghi chú và số lượng');
                return;
            }
        }
        if (Number($('#detail' + i + 'SL').val()) != 0) {
            if ($('#detail' + i + 'Code').text() == "" || $('#detail' + i + 'GC').val() == "") {
                $('#erro').text('Vui lòng thêm sản phẩm 1');
                return;
            }
        }
        if ($('#detail' + i + 'Code').text() != "" && $('#detail' + i + 'GC').val() != "" && $('#detail' + i + 'SL').val() != "") {
            data_list.push({
                masp: $('#detail' + i + 'Code').text(),
                SL: $('#detail' + i + 'SL').val(),
                GhiChu: $('#detail' + i + 'GC').val(),
            })
        }
    }
    if (data_list.length == 0) {
        $('#erro').text('Vui lòng thêm sản phẩm 2');
        return;
    }
    var data = {
        ma: ma,
        ngayxuat: $('#ngayxuat').val(),
        cn: $('#cn').val(),
        nn: $('#nn').val(),
        ghichu: $('#ghichu').val(),

    };
    $.ajax({
        url: '/Admin/UPPHIEUNHAPKHAC',
        data: { cartModel: JSON.stringify(data) },
        dataType: 'json',
        type: 'POST',
        success: function (res) {
            if (res.status == true) {
                for (var i = 0; i < row; i++) {
                    if ($('#detail' + i + 'Code').text() != "" && $('#detail' + i + 'GC').val() != "" && $('#detail' + i + 'SL').val() != "") {
                        var data_list_item = {
                            maphieu: ma,
                            masp: $('#detail' + i + 'Code').text(),
                            SL: $('#detail' + i + 'SL').val(),
                            GhiChu: $('#detail' + i + 'GC').val(),
                        }
                        $.ajax({
                            url: '/Admin/UPPHIEUCTNHAPKHAC',
                            data: { cartModel: JSON.stringify(data_list_item) },
                            dataType: 'json',
                            type: 'POST',
                            success: function (res) {
                            }
                        });
                    }
                }
                window.location.href = "/Admin/DSPHIEUNHAPKHAC";
            } else {
                $('#erro').text(res.erro);
            }
        }
    });
}