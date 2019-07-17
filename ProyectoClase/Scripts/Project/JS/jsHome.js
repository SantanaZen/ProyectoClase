$(document).ready(function () {       
  
    dtProductos();
    $('#actualizar').on('click', function () {
        validarCampos();
    });


});

function dtProductos() {
    var url = $('#urlListaData').val();
    var table = $('#example').DataTable({
        destroy: true,
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
            { "data": "iStock" },
            {
                "render": function () {
                    return "<button type='button' class='edit btn btn -default btn - sm' data-toggle='modal' data-target='#editar'><span class= 'glyphicon glyphicon-pencil' ></span>Actualizar</button>";
                }
            }
        ]
    });

    obtenerDataEditar('#example tbody', table);

}

function obtenerDataEditar(tbody, table) {
    $(tbody).on("click", "button.edit", function () {
        var data;
        if (table.row(this).child.isShown()) {
            data = table.row(this).data();
        }
        else {
            data = table.row($(this).parents("tr")).data();
        }       
        console.log(data);
        $('#clave').val(data.iCveProducto);
        $('#nombre').val(data.sNombre);
        $('#precioc').val(data.DPrecioCompra);
        $('#preciov').val(data.dPrecioVenta);
        $('#cantidad').val(data.iStock);

        $("#nombre").first().focus();
    });
}
function validarCampos() {
    if ($('#clave').val() === "" || $('#nombre').val() === "" || $('#precioc').val() === "" ||
        $('#preciov').val() === "" || $('#cantidad').val() === "")
    {
        alert("Favor de llenar todos los campos");
    } else {
        var producto = {
            iCveProducto: $('#clave').val(),
            sNombre: $('#nombre').val(),
            DPrecioCompra: $('#precioc').val(),
            dPrecioVenta: $('#preciov').val(),
            iStock: $('#cantidad').val()            
        };
        LlamadaEnviarDatos(producto);
    }
}

function LlamadaEnviarDatos(producto) {
    var url = $('#urlActualizar').val();
    $.ajax({
        url: url,
        data: JSON.stringify({ producto }),
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
        alert("Datos Actualizados Correctamente");
        window.location.reload();
    }
    else if (data.Advertencia) {
        alert("Advertencia");

    }
    else {
        alert("Error algo falló");
    }
}


