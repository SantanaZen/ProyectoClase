$(document).ready(function () {
    $('#btn-registrar').on('click', function () {
        validarCampos();
    });



});

function validarCampos() {
    if ($('#clave').val() === "" || $('#nombre').val() === "" || $('#precioc').val() === "" ||
        $('#preciov').val() === "" || $('#cantidad').val() === "" 
    ) {
        alert("Favor de llenar todos los campos");
    } else {
        var nuevoProducto = {
            iCveProducto: $('#clave').val(),
            sNombre: $('#nombre').val(),
            DPrecioCompra: $('#precioc').val(),
            dPrecioVenta: $('#preciov').val(),
            iStock: $('#cantidad').val()
            
        };
        LlamadaEnviarDatos(nuevoProducto);
    }
}

function LlamadaEnviarDatos(nuevoProducto) {
    var url = $('#urlrecibeProd').val();
    $.ajax({
        url: url,
        data: JSON.stringify({ nuevoProducto }),
        type: "POST",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        success: SuccessLlamadaEnviarDatos,
        error: function (xmlHttpRequest, textStatus, errorThrown) {
            alert("error ", data.Mensaje, "verificar info");
        }

    });
}
function SuccessLlamadaEnviarDatos(data) {
    if (data.Exito) {
        alert("Producto agregado Correctamente");
        window.location.reload();
    }
    else if (data.Advertencia) {
        alert("Advertencia,la clave del producto ya existe");

    }
    else {
        alert("Error algo falló");
    }
}

