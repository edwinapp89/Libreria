$('#DtResenia').DataTable({
    responsive: true,
    rowReorder: {
        selector: 'td:nth-child(2)'
    },
    language: {
        url: '../Content/DataTable/js/Spanish.json',
    }
});


document.addEventListener("DOMContentLoaded", function () {
    var modal = document.getElementById("modal-confirm");
    var btnDelete = document.querySelectorAll(".btn-delete");
    var btnConfirmDelete = document.getElementById("btn-confirm-delete");
    var btnCancelDelete = document.getElementById("btn-cancel-delete");


    var id;

    if (btnDelete != null) {
        // Convertir el HTMLCollection en un array


        btnDelete.forEach(function (button) {

            button.addEventListener("click", function () {
                event.preventDefault();
                id = this.getAttribute("data-id");
                modal.style.display = "block";
            });
        });

        btnConfirmDelete.addEventListener("click", function () {
            // Enviar la solicitud de eliminación al servidor
            window.location.href = '/Libreria/EliminarResenia/' + id;
        });

        btnCancelDelete.addEventListener("click", function () {
            modal.style.display = "none";
        });
    }

});



$(".btnEditarResenia").click(function () {
   
    var idElemento = $(".btnEditarResenia");
    var btnEdicion = $(this);

    var url = btnEdicion.data('url');
    $.ajax({
        url: url,
        type: 'GET',
        dataType: 'json',
        data: { id: idElemento },
        success: function (data) {
            console.log(data);
            //llenar los DDL
            var ddlLibros = $("#idLibro");
            if (data.Libros && data.Libros.length > 0) {
                $.each(data.Libros, function (index, libro) {
                    if (libro.id && libro.titulo) {
                        ddlLibros.append($('<option></option>').attr('value', libro.id).text(libro.titulo));
                    }
                });
            }
            else {
                ddlLibros.append($('<option></option>').text("No se encontraron libros disponibles"));
            }

            var ddlUsuarios = $("#idUsuario");


            if (data.Usuarios && data.Usuarios.length > 0) {
                $.each(data.Usuarios, function (index, usuario) {
                    if (usuario.id && usuario.nombre) {
                        ddlUsuarios.append($('<option></option>').attr('value', usuario.id).text(usuario.nombre));
                    }
                });
            }
            else {
                ddlUsuarios.append($('<option></option>').text("No se encontraron libros disponibles"));
            }
           
        },
        error: function (xhr, textStatus, errorThrown) {
            alert('Error al obtener datos: ' + textStatus + ' - ' + errorThrown);
        }
    });
});
