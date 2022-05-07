$('#saveCD').off('click').on('click', function () {
    if ($('#ma').val() == '' || $('#ten').val() == '' || $('#loaimathang').val() == '') {
        $('#erro').text('Vui lòng nhập đủ thông tin');
        return;
    }
    var data = {
        MA: $('#ma').val(),
        TEN: $('#ten').val(),
        LMH: $('#loaimathang').val(),
    };
    $.ajax({
        url: '/Admin/THEMCHUDE',
        data: { cartModel: JSON.stringify(data) },
        dataType: 'json',
        type: 'POST',
        success: function (res) {
            if (res.status == true) {
                window.location.href = "/Admin/CHUDE";
            } else {
                $('#erro').text(res.erro);
            }
        }
    });
});
$('#saveSuaCD').off('click').on('click', function () {
    if ($('#masua').val() == '' || $('#tensua').val() == '' || $('#loaimathangsua').val() == '') {
        $('#errosu0').text('Vui lòng nhập đủ thông tin');
        return;
    }
    var data = {
        MA: $('#masua').val(),
        TEN: $('#tensua').val(),
        LMH: $('#loaimathangsua').val(),
    };
    $.ajax({
        url: '/Admin/UPDATECHUDE',
        data: { cartModel: JSON.stringify(data) },
        dataType: 'json',
        type: 'POST',
        success: function (res) {
            if (res.status == true) {
                window.location.href = "/Admin/CHUDE";
            } else {
                $('#errosua').text(res.erro);
            }
        }
    });
});
function ChiTietCD(id) {
    var data = {
        id: id
    }
    $.ajax({
        url: '/Admin/ChiTietCD',
        data: { cartModel: JSON.stringify(data) },
        dataType: 'json',
        type: 'POST',
        success: function (res) {
            console.log(res.data);
            if (res.status == true) {
                $('#masua').val(res.data[0].ID);
                $('#tensua').val(res.data[0].Ten);
                $('#loaimathangsua').val(res.data[0].MALOAI);
                $('#loaimathangsua').select2().trigger('change');
            }
            else {
                $('#erro').text(res.erro);
            }
        }
    });
}