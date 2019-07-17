$(document).ready(function () {
   
    $('#btn-registrar').on('click', function () {
        validarCampos();
    });

    $('#nacimiento').datepicker({
        format: "yyyy-mm-dd",
        language: "es",
        autoclose: true
    });

});


function validarCampos() {
    if ($('#name').val() === "" || $('#apellido1').val() === "" || $('#apellido2').val() === "" ||
        $('#nacimiento').val() === "" || $('#correo').val() === "" || $('#user').val() === "" ||
        $('#password').val() === ""
    ){
        alert("Favor de llenar todos los campos");
    } else {
        var nuevoUsuario = {
            sUsuario: $('#user').val(),
            sContraseña: $('#password').val(),
            sNombre: $('#name').val(),
            sApp: $('#apellido1').val(),
            sApm: $('#apellido2').val(),
            dtFechaNacimiento: $('#nacimiento').val(),
            sCorreo: $('#correo').val()
        };
        LlamadaEnviarDatos(nuevoUsuario);
    }
}

function LlamadaEnviarDatos(nuevoUsuario) {
    var url = $('#urlrecibeDatos').val();
    $.ajax({
        url: url,
        data: JSON.stringify({ nuevoUsuario }),
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
        alert("Datos agregados Correctamente");
        window.location.reload();
    }
    else if (data.Advertencia) {
        alert("Advertencia, el usuario o correo ya existe");

    }
    else {
        alert("Error algo falló");
    }
}

