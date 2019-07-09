$(document).ready(function () {
    $('.btnLogout').on('click', function () {
        cerrarSesion();
    });
    

});

function cerrarSesion() {

    var url = $('#urlLogin').val();
    window.location.href = url;
}
