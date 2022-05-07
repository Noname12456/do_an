$('#saveCN').off('click').on('click', function () {
    if ($('#ma').val() == '' || $('#ten').val() == '') {
        $('#erro').text('Vui lòng nhập đủ thông tin');
        return;
    }
    var data = {
        MA: $('#ma').val(),
        ten: $('#ten').val(),
        dc: $('#dc').val(),
        sdt: $('#sdt').val(),
        mota: $('#mota').val(),
        gt: $('#stk').val(),
    };
    $.ajax({
        url: '/Admin/THEMCN',
        data: { cartModel: JSON.stringify(data) },
        dataType: 'json',
        type: 'POST',
        success: function (res) {
            if (res.status == true) {
                window.location.href = "/Admin/CHINHANH";
            } else {
                $('#erro').text(res.erro);
            }
        }
    });
});
$('#saveSuaCN').off('click').on('click', function () {
    if ($('#matgsua').val() == '' || $('#tentgsua').val() == '') {
        $('#erro').text('Vui lòng nhập đủ thông tin');
        return;
    }
    var data = {
        MA: $('#masua').val(),
        ten: $('#tensua').val(),
        dc: $('#dcsua').val(),
        sdt: $('#sdtsua').val(),
        mota: $('#motasua').val(),
        gt: $('#stksua').val(),
    };
    $.ajax({
        url: '/Admin/UPDATECN',
        data: { cartModel: JSON.stringify(data) },
        dataType: 'json',
        type: 'POST',
        success: function (res) {
            if (res.status == true) {
                window.location.href = "/Admin/CHINHANH";
            } else {
                $('#errosua').text(res.erro);
            }
        }
    });
});
function ChiTietCN(id) {
    var data = {
        id: id
    }
    $.ajax({
        url: '/Admin/ChiTietCN',
        data: { cartModel: JSON.stringify(data) },
        dataType: 'json',
        type: 'POST',
        success: function (res) {
            if (res.status == true) {
                console.log(res.data);
                $('#masua').val(res.data[0].ID);
                $('#tensua').val(res.data[0].Ten);
                $('#dcsua').val(res.data[0].DC);
                $('#motasua').val(res.data[0].mota);
                $('#stksua').val(res.data[0].STK);
                $('#sdtsua').val(res.data[0].SDT);
            }
            else {
                $('#erro').text(res.erro);
            }
        }
    });
}