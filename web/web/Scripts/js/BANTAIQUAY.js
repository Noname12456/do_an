function myFunction2() {
    var row = $('#table2 tbody tr').length;
    for (var i = 0; i < row; i++) {
        $('#detail' + i + 'Code').text("");
        $('#detail' + i + 'SL').val("");
        $('#detail' + i + 'TT').val("");
        $('#detail' + i + 'TTVAT').text("");
        $('#detail' + i + 'DG').text("");
        $('#detail' + i + 'DGVAT').text("");
    }
}
$(document).ready(function () {
    $(".item_name").keypress(function () {
        $(this).autocomplete({
            source: function (request, response) {
                var data = {
                    q: request.term,
                    cn: $('#cn').val(),
                };
                $.ajax({
                    url: '/Admin/SPCN',
                    dataType: "json",
                    type: 'POST',
                    data: { cartModel: JSON.stringify(data) },
                    success: function (data) {
                        response(data.data);
                    }
                });
            },
            minLength: 1,
            select: function (event, ui) {
                var order = parseInt($(this).attr('order'));
                $('#detail' + order + 'Code').text(ui.item.MASP);
                $('#detail' + order + 'SLT').text(ui.item.SLTON);
                $('#detail' + order + 'DG').text(ui.item.DG);
                $(this).val(ui.item.TENSP);
            }
        })
            .autocomplete().data("uiAutocomplete")._renderItem = function (ul, item) {
                return $("<li class='list-group-item'>")
                    .append("<div style='width: 75%' class='product-suggest ui-menu-item-wrapper'><span style='width: 150px'>" + item.MASP + "</span><span style='display: inline-block;'>" + item.TENSP + "</span></div>")
                    .appendTo(ul);
            };
    });
    $('#btnLuuTC').off('click').on('click', function () {
        var data_list = [];
        var row = $('#table2 tbody tr').length;
        for (var i = 0; i < row; i++) {
            if ($('#detail' + i + 'Code').text() != "") {
                if ($('#detail' + i + 'SL').val() == "" || $('#detail' + i + 'TT').text() == "" || $('#detail' + i + 'DG').text() == "") {
                    $('#erro').text('Vui lòng thêm sản phẩm');
                    return;
                }
            }
            if ($('#detail' + i + 'SLad').text() != "") {
                if ($('#detail' + i + 'Code').text() == "" || $('#detail' + i + 'TT').text() == "" || $('#detail' + i + 'DG').text() == "") {
                    $('#erro').text('Vui lòng thêm sản phẩm');
                    return;
                }
                if (Number($('#detail' + i + 'SLad').val()) > Number($('#detail' + i + 'SLT').text())) {
                    $('#erro').text('Số lượng xuất không được lớn hơn số lượng tồn');
                    return;
                }
            }
            if ($('#detail' + i + 'Code').text() != "" && $('#detail' + i + 'DG').text() != "" && $('#detail' + i + 'TT').text() != "") {
                data_list.push({
                    masp: $('#detail' + i + 'Code').text(),
                    SL: $('#detail' + i + 'SL').val(),
                    TT: $('#detail' + i + 'TT').val(),
                    DG: $('#detail' + i + 'DG').text(),
                })
            }
        }
        if (data_list.length == 0) {
            $('#erro').text('Vui lòng thêm sản phẩm');
            return;
        }
        var checkBox = document.getElementById("chkbox");
        var diem = 0;
        if (checkBox.checked == true) {
            diem = $('#diem').text();
        } else {
            diem = 0;
        }
        var data = {
            cn: $('#cn').val(),
            tong: $('#tong').text(),
            makh: $('#ma').text(),
            diem: diem,
        };
        $.ajax({
            url: '/Admin/THEMHD',
            data: { cartModel: JSON.stringify(data) },
            dataType: 'json',
            type: 'POST',
            success: function (res) {
                if (res.status == true) {
                    for (var i = 0; i < row; i++) {
                        if ($('#detail' + i + 'Code').text() != "" && $('#detail' + i + 'DG').text() != "" && $('#detail' + i + 'TT').text() != "") {
                            var data_list_item = {
                                maphieu: res.ID,
                                masp: $('#detail' + i + 'Code').text(),
                                SL: $('#detail' + i + 'SLad').val(),
                                TT: $('#detail' + i + 'TT').text(),
                                DG: $('#detail' + i + 'DG').text(),
                                cn: $('#cn').val(),
                            }
                            $.ajax({
                                url: '/Admin/THEMHDCT',
                                data: { cartModel: JSON.stringify(data_list_item) },
                                dataType: 'json',
                                type: 'POST',
                                success: function (res) {
                                }
                            });
                        }
                    }
                    window.location.href = "/Admin/BANTAICHINHANH";
                } else {
                    $('#erro').text(res.erro);
                }
            }
        });
    });
    $('#btnLmMsTC').off('click').on('click', function () {
        window.location.href = "/Admin/BANTAICHINHANH";
    });
    $('#find').off('click').on('click', function () {
        if ($('#kh').val() != "") {
            var data = {
                kh: $('#kh').val(),
            };
            $.ajax({
                url: '/Admin/KIEMTRAKH',
                data: { cartModel: JSON.stringify(data) },
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        if (res.data.length > 0) {
                            $('#ma').text(res.data[0].ID);
                            $('#hoten').text(res.data[0].Ho + res.data[0].Ten);
                            $('#diem').text(res.data[0].DiemTL);
                        } else {
                            alert("Khách hàng không tồn tại");
                        }
                    } else {
                        $('#erro').text(res.erro);
                    }
                }
            });
        }
    });
});
$(document).ready(function () {
    for (var i = 0; i < 10; i++) {
        $('#detail' + i + 'SLad').keyup(function () {        
            var rowIdx = $(this).attr('order');
            thanhtien(rowIdx);
        });
    }
});
function checkDTL() {
    var checkBox = document.getElementById("chkbox");
    if ($('#tong').text() > 0) {
        if (checkBox.checked == true) {
            var tong = $('#tong').text() - $('#diem').text();
            $('#thanhtien').text(tong)
        } else {
            var tong = Number($('#tong').text());
            $('#thanhtien').text(tong)
        }
    }
}
function xoaItemad(rowId) {
    $('#detail' + rowId + 'Code').text("");
    $('#detail' + rowId + 'SLad').val("");
    $('#detail' + rowId + 'TT').text("");
    $('#detail' + i + 'SLT').text("");
    $('#detail' + rowId + 'DG').text("");
}
function thanhtien(rowId) {
    var price = '';
    var qtyText = $.trim($('#detail' + rowId + 'SLad').val());
    var DG = $('#detail' + rowId + 'DG').text();
    $('#detail' + rowId + 'TT').text(qtyText * DG);
    var row = $('#table2 tr').length;
    var DGVAT = 0;
    var TT = 0;
    var TTVAT = 0;
    for (var i = 0; i < row; i++) {
        if ($('#detail' + i + 'TT').text()) {
            TT += parseFloat($('#detail' + i + 'TT').text());
        }
    }
    var diem = 0;
    var checkBox = document.getElementById("chkbox");
    if ($('#tong').text() > 0) {
        if (checkBox.checked == true) {
            var diem = $('#diem').text();
        } else {
            diem = 0;
        }
    }
    $('#tong').text(TT);
    $('#thanhtien').text(TT - diem)
}
