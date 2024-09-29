const swalWithBootstrapButtons = Swal.mixin({
    customClass: {
        confirmButton: "btn btn-success m-3",
        cancelButton: "btn btn-danger m-3"
    },
    buttonsStyling: false
});

const swalWithBootstrapButtons2 = Swal.mixin({
    customClass: {
        confirmButton: "btn btn-primary",
    },
    buttonsStyling: false
});
function GuardarRegistro(dataAgregar) {
    var url = dataAgregar.urlPost;
    var form = dataAgregar.formData;
    var recargar = dataAgregar.funcion;

    swalWithBootstrapButtons.fire({
        title: "¿Está seguro que desea guardar este registro?",
        confirmButtonText: 'Agregar',
        icon: "question",
        showConfirmButton: true,
        showCancelButton: true,
        cancelButtonText: 'No, cancelar',
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                type: 'POST',
                url: url,
                data: form,
                success: function (response) {
                    if (response.success) {
                        swalWithBootstrapButtons2.fire({
                            title: "Registro guardado",
                            text: response.message,
                            icon: "success",
                            confirmButtonText: 'Cerrar',
                            backdrop: 'rgba(7, 25, 39, 0.4)'
                        }).then(() => {
                            if (recargar != null) {
                                recargar();
                            }
                        });
                    } else {
                        swalWithBootstrapButtons2.fire({
                            title: "Error",
                            text: response.message,
                            icon: "error",
                            confirmButtonText: 'Cerrar',
                        });
                    }
                },
                error: function (result) {
                    swalWithBootstrapButtons2.fire({
                        title: "Ha ocurrido un error al agregar el registro.",
                        icon: "error",
                        confirmButtonText: 'Cerrar',
                    }).then(() => {
                        cerrar();
                    });
                }
            });
        } else {
            swalWithBootstrapButtons2.fire({
                title: "No se realizó ningún cambio",
                icon: "info",
                confirmButtonText: 'Cerrar',
            });
        }
    });
}

function EliminarRegistro(dataEliminar) {
    var url = dataEliminar.urlPost;
    var id = dataEliminar.id;
    var recargar = dataEliminar.funcion;

    swalWithBootstrapButtons.fire({
        title: "¿Está seguro que desea eliminar este registro?",
        confirmButtonText: 'Eliminar',
        icon: "warning",
        showConfirmButton: true,
        showCancelButton: true,
        cancelButtonText: 'No, cancelar',
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'POST',
                data: { id: id },
                success: function (response) {
                    if (response.success) {
                        swalWithBootstrapButtons2.fire({
                            title: "Registro eliminado",
                            text: response.message,
                            icon: "success",
                            confirmButtonText: 'Cerrar',
                        }).then(() => {
                            if (recargar != null) {
                                recargar();
                            }
                        });
                    } else {
                        swalWithBootstrapButtons2.fire({
                            title: "Error",
                            text: response.message,
                            icon: "error",
                            confirmButtonText: 'Cerrar',
                        });
                    }
                },
                error: function () {
                    loadingAlert.close();
                    swalWithBootstrapButtons2.fire({
                        title: "Error",
                        text: "Ocurrió un error al intentar eliminar el registro.",
                        icon: "error",
                        confirmButtonText: 'Cerrar',
                    });
                }
            });
        } else {
            swalWithBootstrapButtons2.fire({
                title: "Cancelado",
                text: "La eliminación fue cancelada.",
                icon: "info",
                confirmButtonText: 'Cerrar',
            });
        }
    });
}

function validateForm(formId) {
    var isValid = true;
    var firstInvalidInput = null;
    $(`#${formId} :input[required]`).each(function () {
        var $input = $(this);
        $input.removeClass('is-invalid');
        if ($input.attr('type') === 'email') {
            var emailPattern = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;
            if (!emailPattern.test($input.val())) {
                $input.addClass('is-invalid');
                isValid = false;
                if (!firstInvalidInput) firstInvalidInput = $input;
            }
        }
        else if ($input.attr('type') === 'number') {
            if ($input.val() === '' || isNaN($input.val()) || parseFloat($input.val()) < 0) {
                $input.addClass('is-invalid');
                isValid = false;
                if (!firstInvalidInput) firstInvalidInput = $input;
            }
        }
        else if ($input.attr('type') === 'tel') {
            var phonePattern = /^[2-9]\d{7}$/;
            if (!phonePattern.test($input.val())) {
                $input.addClass('is-invalid');
                isValid = false;
                if (!firstInvalidInput) firstInvalidInput = $input;
            }
        }
        // Validación para select
        else if ($input.is('select')) {
            if ($input.val() === '0') {
                $input.addClass('is-invalid');
                isValid = false;
                if (!firstInvalidInput) firstInvalidInput = $input;
            }
        }
    });

    if (firstInvalidInput) {
        firstInvalidInput.focus(); // Enfoca el primer input inválido
    }

    return isValid;
}