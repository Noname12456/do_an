$('#saveQuyen').off('click').on('click', function () {
    if ($('#ma').val() == '' || $('#ten').val() == '') {
        $('#erro').text('Vui lòng nhập đủ thông tin');
        return;
    }
    var data = {
        ma: $('#ma').val(),
        ten: $('#ten').val(),
    };
    $.ajax({
        url: '/Admin/THEMQUYEN',
        data: { cartModel: JSON.stringify(data) },
        dataType: 'json',
        type: 'POST',
        success: function (res) {
            if (res.status == true) {
                window.location.href = "/Admin/QUYEN";
            } else {
                $('#erro').text(res.erro);
            }
        }
    });
});

function ChiTietQuyen(id) {
    var data = {
        id: id
    }
    $.ajax({
        url: '/Admin/ChiTietQuyen',
        data: { cartModel: JSON.stringify(data) },
        dataType: 'json',
        type: 'POST',
        success: function (res) {
            if (res.status == true) {
                $('#masua').val(res.data[0].Ma);
                $('#tensua').val(res.data[0].Ten);
            }
            else {
                $('#erro').text(res.erro);
            }
        }
    });
}

$('#saveQuyenSua').off('click').on('click', function () {
    if ($('#tensua').val() == '') {
        $('#erro').text('Vui lòng nhập đủ thông tin');
        return;
    }
    var data = {
        ma: $('#masua').val(),
        ten: $('#tensua').val(),
    };
    $.ajax({
        url: '/Admin/CNQUYEN',
        data: { cartModel: JSON.stringify(data) },
        dataType: 'json',
        type: 'POST',
        success: function (res) {
            if (res.status == true) {
                window.location.href = "/Admin/QUYEN";
            } else {
                $('#erro').text(res.erro);
            }
        }
    });
});