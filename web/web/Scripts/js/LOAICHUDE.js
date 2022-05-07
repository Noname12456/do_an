$('#saveLCD').off('click').on('click', function () {
    if ($('#ma').val() == '' || $('#ten').val() == '' || $('#chude').val() == '') {
        $('#erro').text('Vui lòng nhập đủ thông tin');
        return;
    }
    var data = {
        MA: $('#ma').val(),
        TEN: $('#ten').val(),
        CD: $('#chude').val(),
    };
    $.ajax({
        url: '/Admin/THEMLOAICHUDE',
        data: { cartModel: JSON.stringify(data) },
        dataType: 'json',
        type: 'POST',
        success: function (res) {
            if (res.status == true) {
                window.location.href = "/Admin/LOAICD";
            } else {
                $('#erro').text(res.erro);
            }
        }
    });
});
$('#saveSuaLCD').off('click').on('click', function () {
    if ($('#masua').val() == '' || $('#tensua').val() == '' || $('#chudesua').val() == '') {
        $('#errosu0').text('Vui lòng nhập đủ thông tin');
        return;
    }
    var data = {
        MA: $('#masua').val(),
        TEN: $('#tensua').val(),
        CD: $('#chudesua').val(),
    };
    $.ajax({
        url: '/Admin/UPDATELOAICHUDE',
        data: { cartModel: JSON.stringify(data) },
        dataType: 'json',
        type: 'POST',
        success: function (res) {
            if (res.status == true) {
                window.location.href = "/Admin/LOAICD";
            } else {
                $('#errosua').text(res.erro);
            }
        }
    });
});
function ChiTietLCD(id) {
    var data = {
        id: id
    }
    $.ajax({
        url: '/Admin/ChiTietLCD',
        data: { cartModel: JSON.stringify(data) },
        dataType: 'json',
        type: 'POST',
        success: function (res) {
            console.log(res.data);
            if (res.status == true) {
                $('#masua').val(res.data[0].ID);
                $('#tensua').val(res.data[0].Ten);
                $('#chudesua').val(res.data[0].MACD);
                $('#chudesua').select2().trigger('change');
            }
            else {
                $('#erro').text(res.erro);
            }
        }
    });
}