function myFunction() {
    var id = document.getElementById("ncc").value;
    if (id != '') {
        var data = {
            id: id
        };
        $.ajax({
            url: '/Admin/ChiTietNCCNHAP',
            data: { cartModel: JSON.stringify(data) },
            dataType: 'json',
            type: 'POST',
            success: function (res) {
                if (res.status == true) {
                    $('#kyhieu').val(res.data[0].kyhd);
                    $('#mauhd').val(res.data[0].kyhmhd);
                } else {
                    $('#erro').text(res.erro);
                }
            }
        });
    } else {
        $('#kyhieu').val('');
        $('#mauhd').val('');
    }
}
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
                $(this).val(ui.item.TENSP);
            }
        })
            .autocomplete().data("uiAutocomplete")._renderItem = function (ul, item) {
                return $("<li class='list-group-item'>")
                    .append("<div style='width: 75%' class='product-suggest ui-menu-item-wrapper'><span style='width: 150px'>" + item.MASP + "</span><span style='display: inline-block;'>" + item.TENSP + "</span></div>")
                    .appendTo(ul);
            };
    });
    $('#btnLuu').off('click').on('click', function () {
        if ($('#ncc').val() == "") {
            $('#erro').text('Vui lòng nhập nhà cung cấp');
            return;
        }
        if ($('#sohd').val() == "" || $('#kyhieu').val() == "" || $('#mauhd').val() == "" || $('#ngaynhap').val() == "" || $('#ngayhd').val() == "" || $('#ngaynhan').val() == "" || $('#cn').val() == "" || $('#tong').val() == "" || $('#tienvat').val() == "" || $('#thanhtienvat').val() == "" || $('#ghichu').val() == "") {
            $('#erro').text('Vui lòng nhập đầy đủ thông tin');
            return;
        }
        var data_list = [];
        var row = $('#table2 tbody tr').length;
        for (var i = 0; i < row; i++) {
            if ($('#detail' + i + 'Code').text() != "") {
                if ($('#detail' + i + 'SL').val() == "" || $('#detail' + i + 'TT').val() == "" || $('#detail' + i + 'TTVAT').text() == "" || $('#detail' + i + 'DG').text() == "" || $('#detail' + i + 'DGVAT').text() == "") {
                    $('#erro').text('Vui lòng thêm sản phẩm');
                    return;
                }
            }
            if ($('#detail' + i + 'SL').text() != "") {
                if ($('#detail' + i + 'Code').text() == "" || $('#detail' + i + 'TT').val() == "" || $('#detail' + i + 'TTVAT').text() == "" || $('#detail' + i + 'DG').text() == "" || $('#detail' + i + 'DGVAT').text() == "") {
                    $('#erro').text('Vui lòng thêm sản phẩm');
                    return;
                }
            }
            if ($('#detail' + i + 'TT').text() != "") {
                if ($('#detail' + i + 'Code').text() == "" || $('#detail' + i + 'TTVAT').text() == "" || $('#detail' + i + 'DG').text() == "" || $('#detail' + i + 'DGVAT').text() == "") {
                    $('#erro').text('Vui lòng thêm sản phẩm');
                    return;
                }
            }
            if ($('#detail' + i + 'Code').text() != "" && $('#detail' + i + 'TTVAT').text() != "" && $('#detail' + i + 'DG').text() != "" && $('#detail' + i + 'DGVAT').text() != "" && $('#detail' + i + 'TT').val() != "") {
                data_list.push({
                    masp: $('#detail' + i + 'Code').text(),
                    SL: $('#detail' + i + 'SL').val(),
                    TT: $('#detail' + i + 'TT').val(),
                    TTVAT: $('#detail' + i + 'TTVAT').text(),
                    DG: $('#detail' + i + 'DG').text(),
                    DGVAT: $('#detail' + i + 'DGVAT').text(),
                })
            }
        }
        if (data_list.length == 0) {
            $('#erro').text('Vui lòng thêm sản phẩm');
            return;
        }
        var data = {
            ncc: $('#ncc').val(),
            shd: $('#sohd').val(),
            kyhieu: $('#kyhieu').val(),
            mauhd: $('#mauhd').val(),
            ngaynhap: $('#ngaynhap').val(),
            ngayhd: $('#ngayhd').val(),
            ngaynhan: $('#ngaynhan').val(),
            cn: $('#cn').val(),
            tong: $('#tong').val(),
            tienvat: $('#tienvat').val(),
            thanhtienvat: $('#thanhtienvat').val(),
            ghichu: $('#ghichu').val(),
            vat: $('#vat').val(),

        };
        $.ajax({
            url: '/Admin/THEMPHIEU',
            data: { cartModel: JSON.stringify(data) },
            dataType: 'json',
            type: 'POST',
            success: function (res) {
                if (res.status == true) {
                    for (var i = 0; i < row; i++) {
                        if ($('#detail' + i + 'Code').text() != "" && $('#detail' + i + 'TTVAT').text() != "" && $('#detail' + i + 'DG').text() != "" && $('#detail' + i + 'DGVAT').text() != "" && $('#detail' + i + 'TT').val() != "") {
                            var data_list_item = {
                                maphieu: res.ID,
                                masp: $('#detail' + i + 'Code').text(),
                                SL: $('#detail' + i + 'SL').val(),
                                TT: $('#detail' + i + 'TT').val(),
                                TTVAT: $('#detail' + i + 'TTVAT').text(),
                                DG: $('#detail' + i + 'DG').text(),
                                DGVAT: $('#detail' + i + 'DGVAT').text(),
                            }
                            $.ajax({
                                url: '/Admin/THEMPHIEUCT',
                                data: { cartModel: JSON.stringify(data_list_item) },
                                dataType: 'json',
                                type: 'POST',
                                success: function (res) {
                                }
                            });
                        }
                    }
                    window.location.href = "/Admin/PHIEUNHAP";
                } else {
                    $('#erro').text(res.erro);
                }
            }
        });
    });
    $('#btnLmMs').off('click').on('click', function () {
        window.location.href = "/Admin/PHIEUNHAP";
    });
});
function lammoi(id) {
    window.location.href = "/Admin/CNPHIEUNHAP/" + id;
}
//function moveNext(event, curId, triggerEvent) {
//    if (event == null || event.keyCode == 13) {
//        if (triggerEvent != null) {
//            $('#' + curId).trigger(triggerEvent);
//        }
//        var fields = $('#' + curId).parents('form:eq(0),body').find('button,input,textarea,select,a').not('[type=hidden]').not('[disabled]').not(':hidden');
//        var index = fields.index($('#' + curId));
//        if (index > -1 && (index + 1) < fields.length) {
//            fields.eq(index + 1).focus();
//            fields.eq(index + 1).select();
//        }


//    }
//    return false;
//}
//function processOnRowChange(rowId) {
//    // clear empty now
//    if ($.trim($('#detail' + rowId + 'ItemName').val()) == '') {
//        $('#detail' + rowId + 'Code').text();
//    }
//}
function suaphieu(ma) {
    if ($('#ncc').val() == "") {
        $('#erro').text('Vui lòng nhập nhà cung cấp');
        return;
    }
    if ($('#sohd').val() == "" || $('#kyhieu').val() == "" || $('#mauhd').val() == "" || $('#ngaynhap').val() == "" || $('#ngayhd').val() == "" || $('#ngaynhan').val() == "" || $('#cn').val() == "" || $('#tong').val() == "" || $('#tienvat').val() == "" || $('#thanhtienvat').val() == "" || $('#ghichu').val() == "") {
        $('#erro').text('Vui lòng nhập đầy đủ thông tin');
        return;
    }
    var data_list = [];
    var row = $('#table2 tr').length;
    for (var i = 0; i < row; i++) {
        if ($('#detail' + i + 'Code').text() != "") {
            if ($('#detail' + i + 'SL').val() == "" || $('#detail' + i + 'TT').val() == "" || $('#detail' + i + 'TTVAT').text() == "" || $('#detail' + i + 'DG').text() == "" || $('#detail' + i + 'DGVAT').text() == "") {
                $('#erro').text('Vui lòng sản phẩm');
                return;
            }
        }
        if ($('#detail' + i + 'SL').text() != "") {
            if ($('#detail' + i + 'Code').text() == "" || $('#detail' + i + 'TT').val() == "" || $('#detail' + i + 'TTVAT').text() == "" || $('#detail' + i + 'DG').text() == "" || $('#detail' + i + 'DGVAT').text() == "") {
                $('#erro').text('Vui lòng sản phẩm');
                return;
            }
        }
        if ($('#detail' + i + 'TT').text() != "") {
            if ($('#detail' + i + 'Code').text() == "" || $('#detail' + i + 'TTVAT').text() == "" || $('#detail' + i + 'DG').text() == "" || $('#detail' + i + 'DGVAT').text() == "") {
                $('#erro').text('Vui lòng sản phẩm');
                return;
            }
        }
        if ($('#detail' + i + 'Code').text() != "" && $('#detail' + i + 'TTVAT').text() != "" && $('#detail' + i + 'DG').text() != "" && $('#detail' + i + 'DGVAT').text() != "" && $('#detail' + i + 'TT').val() != "") {
            data_list.push({
                masp: $('#detail' + i + 'Code').text(),
                SL: $('#detail' + i + 'SL').val(),
                TT: $('#detail' + i + 'TT').val(),
                TTVAT: $('#detail' + i + 'TTVAT').text(),
                DG: $('#detail' + i + 'DG').text(),
                DGVAT: $('#detail' + i + 'DGVAT').text(),
            })
        }
    }
    if (data_list.length == 0) {
        $('#erro').text('Vui lòng sản phẩm');
        return;
    }
    var data = {
        ma: ma,
        ncc: $('#ncc').val(),
        shd: $('#sohd').val(),
        kyhieu: $('#kyhieu').val(),
        mauhd: $('#mauhd').val(),
        ngaynhap: $('#ngaynhap').val(),
        ngayhd: $('#ngayhd').val(),
        ngaynhan: $('#ngaynhan').val(),
        cn: $('#cn').val(),
        tong: $('#tong').val(),
        tienvat: $('#tienvat').val(),
        thanhtienvat: $('#thanhtienvat').val(),
        ghichu: $('#ghichu').val(),
        vat: $('#vat').val(),

    };
    $.ajax({
        url: '/Admin/SUAPHIEU',
        data: { cartModel: JSON.stringify(data) },
        dataType: 'json',
        type: 'POST',
        success: function (res) {
            if (res.status == true) {
                for (var i = 0; i < row; i++) {
                    if ($('#detail' + i + 'Code').text() != "" && $('#detail' + i + 'TTVAT').text() != "" && $('#detail' + i + 'DG').text() != "" && $('#detail' + i + 'DGVAT').text() != "" && $('#detail' + i + 'TT').val() != "") {
                        var data_list_item = {
                            maphieu: ma,
                            masp: $('#detail' + i + 'Code').text(),
                            SL: $('#detail' + i + 'SL').val(),
                            TT: $('#detail' + i + 'TT').val(),
                            TTVAT: $('#detail' + i + 'TTVAT').text(),
                            DG: $('#detail' + i + 'DG').text(),
                            DGVAT: $('#detail' + i + 'DGVAT').text(),
                        }
                        $.ajax({
                            url: '/Admin/UPDATECTPHIEU',
                            data: { cartModel: JSON.stringify(data_list_item) },
                            dataType: 'json',
                            type: 'POST',
                            success: function (res) {
                            }
                        });
                    }
                }
                window.location.href = "/Admin/DSPHIEUNHAP";
            } else {
                $('#erro').text(res.erro);
            }
        }
    });
}
$(document).ready(function () {
    for (var i = 0; i < 10; i++) {
        $('#detail' + i + 'SL').keyup(function () {
            var rowIdx = $(this).attr('order');
            calUnitQuantity(rowIdx);
        });
        $('#detail' + i + 'TT').keyup(function () {
            var rowIdx = $(this).attr('order');
            calUnitPriceFromTotal(rowIdx);
        });
    }
});
function xoaItem(rowId) {
    $('#detail' + rowId + 'Code').text("");
    $('#detail' + rowId + 'SL').val("");
    $('#detail' + rowId + 'TT').val("");
    $('#detail' + rowId + 'TTVAT').text("");
    $('#detail' + rowId + 'DG').text("");
    $('#detail' + rowId + 'DGVAT').text("");
}
function calUnitQuantity(rowId) {
    var price = '';
    var priceVat = '';
    var total = 0;
    var totalVat = 0;
    var qtyText = $.trim($('#detail' + rowId + 'SL').val());
    var total = $('#detail' + rowId + 'TT').val();
    var Univat = $('#vat').val()
    if (qtyText != "") {
        var qty = qtyText;
        price = total / qty;
        if (Univat != 0) {
            totalVat = parseFloat(total) + parseFloat(total * (Univat / 100));
            vat = total * (Univat / 100);;
        } else {
            totalVat = total;
        }
    }
    $('#detail' + rowId + 'DG').text(price);
    $('#detail' + rowId + 'DGVAT').text(vat);
    $('#detail' + rowId + 'TTVAT').text(totalVat);
    var row = $('#table2 tr').length;
    var DGVAT = 0;
    var TT = 0;
    var TTVAT = 0;
    for (var i = 0; i < row; i++) {
        if ($('#detail' + i + 'DGVAT').text() != "") {
            DGVAT += parseFloat($('#detail' + i + 'DGVAT').text());
        }
        if ($('#detail' + i + 'TT').val()) {
            TT += parseFloat($('#detail' + i + 'TT').val());
        }
        if ($('#detail' + i + 'TTVAT').text()) {
            TTVAT += parseFloat($('#detail' + i + 'TTVAT').text());
        }
    }
    $('#tong').val(TT);
    $('#tienvat').val(DGVAT);
    $('#thanhtienvat').val(TTVAT);
}
function calUnitPriceFromTotal(rowId) {
    var price = '';
    var priceVat = '';
    var totalVat = 0;
    var total = 0;
    var qtyText = $('#detail' + rowId + 'SL').val();
    var Univat = $('#vat').val()
    var vat = 0;
    var total = $('#detail' + rowId + 'TT').val();
    if (qtyText.length > 0) {
        var qty = qtyText;
        price = total / qty;
        if (Univat != 0) {
            totalVat = parseFloat(total) + parseFloat(total * (Univat / 100));
            vat = total * (Univat / 100);;
        } else {
            totalVat = total;
        }
    }
    $('#detail' + rowId + 'DG').text(price);
    $('#detail' + rowId + 'DGVAT').text(vat);
    $('#detail' + rowId + 'TTVAT').text(totalVat);
    var row = $('#table2 tr').length;
    var DGVAT = 0;
    var TT = 0;
    var TTVAT = 0;
    for (var i = 0; i < row; i++) {
        if ($('#detail' + i + 'DGVAT').text() != "") {
            DGVAT += parseFloat($('#detail' + i + 'DGVAT').text());
        }
        if ($('#detail' + i + 'TT').val()) {
            TT += parseFloat($('#detail' + i + 'TT').val());
        }
        if ($('#detail' + i + 'TTVAT').text()) {
            TTVAT += parseFloat($('#detail' + i + 'TTVAT').text());
        }
    }
    $('#tong').val(TT);
    $('#tienvat').val(DGVAT);
    $('#thanhtienvat').val(TTVAT);
}
