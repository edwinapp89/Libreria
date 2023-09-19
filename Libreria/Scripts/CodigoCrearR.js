//creación de ajax LIBROS

var DDLResenia = $("#idLibro");
var url = DDLResenia.data('url');


$.ajax({
    url: url,
    type: 'GET',
    dataType: 'json',
    success: function (data) {
            //limpiar opciones
           
            DDLResenia.empty();
            //agregar la opción "Seleccionar Libro" primero
            DDLResenia.append($('<option></option>').attr('value', '0').text("Seleccionar Libro"));
            //si no hay informacion
            if (data.length === 0)
            {
                DDLResenia.prop('disabled', true);
                DLLResenia.append($('<option></option>').attr('value', '').text("no hay Libros disponibles"));
            }
            else
            {
                //index es el indice y libro los datos
                //se llena el DDL con el valor y el texto
                $.each(data, function (index, libro) {
                    DDLResenia.append($('<option></option>').attr('value', libro.id).text(libro.titulo));
                    DDLResenia.prop('disabled',false);
                });
            }
        }    
});


/*-----------------------------*/
//creación de ajax usuarioa

var DDLUsuario = $("#idUsuario");
var url = DDLUsuario.data('url');


$.ajax({
    url: url,
    type: 'GET',
    dataType: 'json',
    success: function (data) {
        //limpiar opciones

        DDLUsuario.empty();
        //agregar la opción "Seleccionar usuario" primero
        DDLUsuario.append($('<option></option>').attr('value', '0').text("Seleccionar Usuario"));
        //si no hay informacion
        if (data.length === 0) {
            DDLUsuario.prop('disabled', true);
            DDLUsuario.append($('<option></option>').attr('value', '').text("no hay Usuarios Registrados"));
        }
        else {
            //index es el indice y usuario los datos
            //se llena el DDL con el valor y el texto
            $.each(data, function (index, usuario) {
                DDLUsuario.append($('<option></option>').attr('value', usuario.id).text(usuario.nombre));
                DDLUsuario.prop('disabled', false);
            });
        }
    }
});