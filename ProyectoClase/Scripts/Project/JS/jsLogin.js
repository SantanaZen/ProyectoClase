$(document).ready(function () {

    //inputCheck('#inUsuario');
    //inputCheck('#inContra');
    var userExpresion = new RegExp("^[0-9a-zA-ZáéíóúàèìòùÀÈÌÒÙÁÉÍÓÚñÑüÜ@._\s]+$");
    var passExpresion = new RegExp("^[0-9a-zA-Z\s]+$");
    checkInput('#inUsuario', userExpresion);
    checkInput('#inContra', passExpresion);
    $('.btnLogear').on('click', function () {
        validador();
    });
    

});



/*$(document).on('click', '.btnLogear', function () {
    validador();
});*/
/*
function validador() {
    if ($('#inUsuario').val() === "" || $('#inContra').val() === "") {
        alert("Favor de llenar los campos");

    } else {
        alert("vas a redirigirte");
        var url = $('#urlHome').val();
        window.location.href = url;
    }
}*/

function validador() {
    if ($('#inUsuario').val() === "" || $('#inContra').val() === "") {
        alert("favor de llenar los campos");
    } else {
        var datosUsuario = {
            sUsuario: $('#inUsuario').val(),
            sContraseña: $('#inContra').val()
        };
        LlamadaIniciarSesion(datosUsuario);
    }
}

function LlamadaIniciarSesion(datosUsuario) {
    var url = $('#urlLogeo').val();
    $.ajax({
        url: url,
        data: JSON.stringify({ datosUsuario }),
        type: "POST",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        success: SuccessLlamadaIniciarSesion,
        error: function (xmlHttpRequest, textStatus, errorThrown) {
            alert("error ", data.Mensaje,"verificar info");
        }
    });
}
function SuccessLlamadaIniciarSesion(data) {
    if (data.Exito) {
        var url = $('#urlHome').val();
        window.location.href = url;
    }
    else if (data.Advertencia) {
        alert("Usuario o contraseña incorrectos");

    }
    else {
        alert("Error algo falló");
    }
}



//Primer forma, en este caso se utiliza el codigo ascii
function inputCheck(idInput) {
    $(idInput).keypress(function (tecla) {
        if ((tecla.charCode >= 45 && tecla.charCode <= 57)
            || (tecla.charCode >= 64 && tecla.charCode <= 90)
            || (tecla.charCode >= 64 && tecla.charCode <= 90)
            || (tecla.charCode >= 97 && tecla.charCode <= 122)
            || tecla.charCode === 95
            || (tecla.charCode >= 160 && tecla.charCode <= 165)) return true;
        else return false;
    })
}

//Segunda forma, en este caso se utilizan expresiones regulares

function checkInput(idInput, expresion) {
    $(idInput).keypress(function (tecla) {
        var key = String.fromCharCode(!event.charCode ? event.which : event.charCode);
        if (!expresion.test(key)) {
            event.preventDefault();
            return false;
        }

    })
}