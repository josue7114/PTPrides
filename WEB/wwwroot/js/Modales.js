function mostrarInfoModal(url, btn, containerModal, nombreModal) {
    let parametro = $(btn).data("id");
    if (parametro == undefined) {
        parametro = 0;
    }
    $.ajax({
        url: url,
        type: 'GET',
        data: { Parametro: parametro },
        success: function (result) {
            if (nombreModal) {
                $('#' + nombreModal).modal('dispose');
                $('.modal-backdrop').remove();
            }
            $('#' + containerModal).html(result);
            $('#' + nombreModal).modal('show');
        }
    });
}