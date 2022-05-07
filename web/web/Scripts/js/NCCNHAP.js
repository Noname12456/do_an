$('#saveNCCNHAP').off('click').on('click', function () {
    if ($('#ma').val() == '' || $('#ten').val() == '' || $('#kyhieuhd').val() == '' || $('#kyhieumauhd').val() == '') {
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
        kyhieuhd: $('#kyhieuhd').val(),
        kyhieumauhd: $('#kyhieumauhd').val()
    };
    $.ajax({
        url: '/Admin/THEMNCCNHAP',
        data: { cartModel: JSON.stringify(data) },
        dataType: 'json',
        type: 'POST',
        success: function (res) {
            if (res.status == true) {
                window.location.href = "/Admin/NHACUNGCAPNHAP";
            } else {
                $('#erro').text(res.erro);
            }
        }
    });
});
$('#saveSuaNCCNHAP').off('click').on('click', function () {
    if ($('#matgsua').val() == '' || $('#tentgsua').val() == '' || $('#kyhieuhdsua').val() == '' || $('#kyhieumauhdsua').val() == '') {
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
        kyhieuhd: $('#kyhieuhdsua').val(),
        kyhieumauhd: $('#kyhieumauhdsua').val()
    };
    $.ajax({
        url: '/Admin/UPDATENCCNHAP',
        data: { cartModel: JSON.stringify(data) },
        dataType: 'json',
        type: 'POST',
        success: function (res) {
            if (res.status == true) {
                window.location.href = "/Admin/NHACUNGCAPNHAP";
            } else {
                $('#errosua').text(res.erro);
            }
        }
    });
});
function ChiTietNCCNHAP(id) {
    var data = {
        id: id
    }
    $.ajax({
        url: '/Admin/ChiTietNCCNHAP',
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
                $('#kyhieuhdsua').val(res.data[0].kyhd);
                $('#kyhieumauhdsua').val(res.data[0].kyhmhd);
            }
            else {
                $('#erro').text(res.erro);
            }
        }
    });
}