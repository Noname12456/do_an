$('#saveKM').off('click').on('click', function () {
    if ($('#ma').val() == '' || $('#gia').val() == '' || $('#dk').val() == '' || $('#HTKM').val() == '' || $('#ngaybd').val() == '' || $('#ngayket').val() == '') {
        $('#erro').text('Vui lòng nhập đủ thông tin');
        return;
    }
    if (Date($('#ngaybd').val()) > Date($('#ngayket').val())) {
        $('#erro').text('ngày bắt đầu phải bé hơn ngày kết thúc');
        return;
    }
    if ($('#HTKM').val() == 0) {
        if ($('#gia').val() < 0) {
            $('#erro').text('Giá tiền giảm phải lớn hơn 0');
            return;
        }
    } else {
        if ($('#gia').val() < 0 || $('#gia').val() > 100) {
            $('#erro').text('tỉ lệ % giảm giá từ 0- 100');
            return;
        }
    }
    var data = {
        MA: $('#ma').val(),
        gia: $('#gia').val(),
        dk: $('#dk').val(),
        HTKM: $('#HTKM').val(),
        ngaybd: $('#ngaybd').val(),
        ngayket: $('#ngayket').val(),
    };
    $.ajax({
        url: '/Admin/THEMKM',
        data: { cartModel: JSON.stringify(data) },
        dataType: 'json',
        type: 'POST',
        success: function (res) {
            if (res.status == true) {
                window.location.href = "/Admin/KHUYENMAI";
            } else {
                $('#erro').text(res.erro);
            }
        }
    });
});
$('#saveKMSua').off('click').on('click', function () {
    if ($('#masua').val() == '' || $('#giasua').val() == '' || $('#dksua').val() == '' || $('#HTKMSUA').val() == '' || $('#ngaybdsua').val() == '' || $('#ngayketsua').val() == '') {
        $('#erro').text('Vui lòng nhập đủ thông tin');
        return;
    }
    if (Date($('#ngaybdsua').val()) > Date($('#ngayketsua').val())) {
        $('#errosua').text('ngày bắt đầu phải bé hơn ngày kết thúc');
        return;
    }
    if ($('#HTKMSUA').val() == 0) {
        if ($('#giasua').val() < 0) {
            $('#erro').text('Giá tiền giảm phải lớn hơn 0');
            return;
        }
    } else {
        if ($('#giasua').val() < 0 || $('#gia').val() > 100) {
            $('#errosua').text('tỉ lệ % giảm giá từ 0- 100');
            return;
        }
    }
    var data = {
        MA: $('#masua').val(),
        gia: $('#giasua').val(),
        dk: $('#dksua').val(),
        HTKM: $('#HTKMSUA').val(),
        ngaybd: $('#ngaybdsua').val(),
        ngayket: $('#ngayketsua').val(),
    };
    $.ajax({
        url: '/Admin/UPDATEKM',
        data: { cartModel: JSON.stringify(data) },
        dataType: 'json',
        type: 'POST',
        success: function (res) {
            if (res.status == true) {
                window.location.href = "/Admin/KHUYENMAI";
            } else {
                $('#errosua').text(res.erro);
            }
        }
    });
});
function ChiTietKM(id) {
    var data = {
        id: id
    }
    $.ajax({
        url: '/Admin/ChiTietKM',
        data: { cartModel: JSON.stringify(data) },
        dataType: 'json',
        type: 'POST',
        success: function (res) {
            if (res.status == true) {
                $('#masua').val(res.data[0].ID);
                $('#giasua').val(res.data[0].ST);
                $('#dksua').val(res.data[0].DK);
                $('#HTKMSUA').val(res.data[0].HINHTHUCKM);
                document.getElementById('ngaybdsua').valueAsDate = new Date(res.data[0].NGAYBD);
                document.getElementById('ngayketsua').valueAsDate = new Date(res.data[0].NGAYKT);
            }
            else {
                $('#erro').text(res.erro);
            }
        }
    });
}