$('#saveMH').off('click').on('click', function () {
    if ($('#ma').val() == '' || $('#ten').val() == '' || $('#mathang').val() == '') {
        $('#erro').text('Vui lòng nhập đủ thông tin');
        return;
    }
    var data = {
        MA: $('#ma').val(),
        TEN: $('#ten').val(),
        MH: $('#mathang').val(),
    };
    $.ajax({
        url: '/Admin/THEMLOAIMH',
        data: { cartModel: JSON.stringify(data) },
        dataType: 'json',
        type: 'POST',
        success: function (res) {
            if (res.status == true) {
                window.location.href = "/Admin/LOAIMH";
            } else {
                $('#erro').text(res.erro);
            }
        }
    });
});
$('#saveSuaMH').off('click').on('click', function () {
    if ($('#masua').val() == '' || $('#tensua').val() == '' || $('#mathangsua').val() == '') {
        $('#errosu0').text('Vui lòng nhập đủ thông tin');
        return;
    }
    var data = {
        MA: $('#masua').val(),
        TEN: $('#tensua').val(),
        MH: $('#mathangsua').val(),
    };
    $.ajax({
        url: '/Admin/UPDATELOAIMH',
        data: { cartModel: JSON.stringify(data) },
        dataType: 'json',
        type: 'POST',
        success: function (res) {
            if (res.status == true) {
                window.location.href = "/Admin/LOAIMH";
            } else {
                $('#errosua').text(res.erro);
            }
        }
    });
});
function ChiTietMH(id) {
    var data = {
        id: id
    }
    $.ajax({
        url: '/Admin/ChiTietMH',
        data: { cartModel: JSON.stringify(data) },
        dataType: 'json',
        type: 'POST',
        success: function (res) {
            if (res.status == true) {
                $('#masua').val(res.data[0].ID);
                $('#tensua').val(res.data[0].Ten);
                $('#mathangsua').val(res.data[0].MaMH);
                $('#mathangsua').select2().trigger('change');
            }
            else {
                $('#erro').text(res.erro);
            }
        }
    });
}