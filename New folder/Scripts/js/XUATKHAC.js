$(document).ready(function () {
    $('#btnLuuXK').off('click').on('click', function () {
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
                if (Number($('#detail' + i + 'SL').val()) > Number($('#detail' + i + 'SLT').text())) {
                    $('#erro').text('Số lượng xuất không được lớn hơn số lượng tồn');
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
            ngayxuat: $('#ngayxuat').val(),
            cn: $('#cn').val(),
            nn: $('#nn').val(),
            ghichu: $('#ghichu').val(),

        };
        $.ajax({
            url: '/Admin/THEMPHIEUXUAT',
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
                                url: '/Admin/THEMPHIEUXUATCT',
                                data: { cartModel: JSON.stringify(data_list_item) },
                                dataType: 'json',
                                type: 'POST',
                                success: function (res) {
                                }
                            });
                        }
                    }
                    window.location.href = "/Admin/XUATKHAC";
                } else {
                    $('#erro').text(res.erro);
                }
            }
        });
    });
    $('#btnLmMs').off('click').on('click', function () {
        window.location.href = "/Admin/XUATKHAC";
    });
});
function suaphieu(ma) {
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
            if (Number($('#detail' + i + 'SL').val()) > Number($('#detail' + i + 'SLT').text())) {
                $('#erro').text('Số lượng xuất không được lớn hơn số lượng tồn');
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
        url: '/Admin/UPPHIEUXUAT',
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
                            url: '/Admin/UPPHIEUXUATCT',
                            data: { cartModel: JSON.stringify(data_list_item) },
                            dataType: 'json',
                            type: 'POST',
                            success: function (res) {
                            }
                        });
                    }
                }
                window.location.href = "/Admin/DSXUATKHAC";
            } else {
                $('#erro').text(res.erro);
            }
        }
    });
}
function myFunction3() {
    var row = $('#table3 tbody tr').length;
    for (var i = 0; i < row; i++) {
        $('#detail' + i + 'Code').text("");
        $('#detail' + i + 'SL').val("");
        $('#detail' + i + 'GC').val("");
        $('#detail' + i + 'SLT').text("");
    }
}