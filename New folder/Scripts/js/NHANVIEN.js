$('#saveNV').off('click').on('click', function () {
    if ($('#ma').val() == '' || $('#ten').val() == '' || $('#mk').val() == '') {
        $('#erro').text('Vui lòng nhập đủ thông tin');
        return;
    }
    var data = {
        MA: $('#ma').val(),
        ten: $('#ten').val(),
        dc: $('#dc').val(),
        sdt: $('#sdt').val(),
        email: $('#email').val(),
        cn: $('#cn').val(),
        mk: $('#mk').val(),
        quyen: $('#quyen').val(),
    };
    $.ajax({
        url: '/Admin/THEMNV',
        data: { cartModel: JSON.stringify(data) },
        dataType: 'json',
        type: 'POST',
        success: function (res) {
            if (res.status == true) {
                window.location.href = "/Admin/NHANVIEN";
            } else {
                $('#erro').text(res.erro);
            }
        }
    });
});
$('#saveSuaNV').off('click').on('click', function () {
    console.log(122);
    if ($('#masua').val() == '' || $('#tensua').val() == '' || $('#mksua').val() == '') {
        $('#erro').text('Vui lòng nhập đủ thông tin');
        return;
    }
    var data = {
        MA: $('#masua').val(),
        ten: $('#tensua').val(),
        dc: $('#dcsua').val(),
        sdt: $('#sdtsua').val(),
        email: $('#emailsua').val(),
        cn: $('#cnsua').val(),
        mk: $('#mksua').val(),
        quyen: $('#quyensua').val(),
    };
    $.ajax({
        url: '/Admin/UPDATENV',
        data: { cartModel: JSON.stringify(data) },
        dataType: 'json',
        type: 'POST',
        success: function (res) {
            if (res.status == true) {
                window.location.href = "/Admin/NHANVIEN";
            } else {
                $('#errosua').text(res.erro);
            }
        }
    });
});
function ChiTietNV(id) {
    var data = {
        id: id
    }
    $.ajax({
        url: '/Admin/ChiTietNV',
        data: { cartModel: JSON.stringify(data) },
        dataType: 'json',
        type: 'POST',
        success: function (res) {
            if (res.status == true) {
                console.log(res.data);
                $('#masua').val(res.data[0].ID);
                $('#tensua').val(res.data[0].Ten);
                $('#dcsua').val(res.data[0].dc);
                $('#emailsua').val(res.data[0].email);
                $('#cnsua').val(res.data[0].macn);
                $('#cnsua').select2().trigger('change');
                $('#sdtsua').val(res.data[0].SDT);
                $('#mksua').val(res.data[0].MK);
                $('#quyensua').val(res.data[0].quyen);
                $('#quyensua').select2().trigger('change');
            }
            else {
                $('#erro').text(res.erro);
            }
        }
    });
}