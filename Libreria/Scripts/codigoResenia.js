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

