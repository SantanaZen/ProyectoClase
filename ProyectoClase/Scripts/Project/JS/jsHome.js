$(document).ready(function () {       
  
   dtProductos();

});

function dtProductos() {
    var url = $('#urlListaData').val();
    $('#example').DataTable({
        
        ajax: {
            url: url,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            type: "GET"            
        },
        columns: [
            { "data": "iCveProducto" },
            { "data": "sNombre" },
            { "data": "DPrecioCompra" },
            { "data": "dPrecioVenta" },
            { "data": "iStock" }
        ]
    });

}