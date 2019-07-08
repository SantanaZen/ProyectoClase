$(document).on('click', '.btnLogout', function () {
    
    cerrarSesion();

});
function cerrarSesion() {
    Session.remove["usuario"];
    var url = $('#urlLogin').val();
    window.location.href = url;
    
}