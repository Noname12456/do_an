$('#saveTg').off('click').on('click', function () {
    if ($('#matg').val() == '' || $('#tentg').val() == '') {
        $('#erro').text('Vui lòng nhập đủ thông tin');
        return;
    }
    var data = {
        MA: $('#matg').val(),
        ten: $('#tentg').val(),
        dc: $('#dc').val(),
        sdt: $('#sdt').val(),
        mota: $('#mota').val(),
        gt: $('#gt').val(),
    };
    $.ajax({
        url: '/Admin/THEMTG',
        data: { cartModel: JSON.stringify(data) },
        dataType: 'json',
        type: 'POST',
        success: function (res) {
            if (res.status == true) {
                window.location.href = "/Admin/TACGIA";
            } else {
                $('#erro').text(res.erro);
            }
        }
    });
});
$('#saveSuaTG').off('click').on('click', function () {
    if ($('#matgsua').val() == '' || $('#tentgsua').val() == '') {
        $('#erro').text('Vui lòng nhập đủ thông tin');
        return;
    }
    var data = {
        MA: $('#matgsua').val(),
        ten: $('#tentgsua').val(),
        dc: $('#dcsua').val(),
        sdt: $('#sdtsua').val(),
        mota: $('#motasua').val(),
        gt: $('#gtsua').val(),
    };
    $.ajax({
        url: '/Admin/UPDATETG',
        data: { cartModel: JSON.stringify(data) },
        dataType: 'json',
        type: 'POST',
        success: function (res) {
            if (res.status == true) {
                window.location.href = "/Admin/TACGIA";
            } else {
                $('#errosua').text(res.erro);
            }
        }
    });
});
function ChiTietTG(id) {
    var data = {
        id: id
    }
    $.ajax({
        url: '/Admin/ChiTietTG',
        data: { cartModel: JSON.stringify(data) },
        dataType: 'json',
        type: 'POST',
        success: function (res) {
            if (res.status == true) {
                $('#matgsua').val(res.data[0].ID);
                $('#tentgsua').val(res.data[0].Ten);
                $('#dcsua').val(res.data[0].DC);
                $('#motasua').val(res.data[0].mota);
                $('#gtsua').val(res.data[0].GT);
                $('#sdtsua').val(res.data[0].SDT);
            }
            else {
                $('#erro').text(res.erro);
            }
        }
    });
}