$('#DtInicio').DataTable({
    responsive: true,
    rowReorder: {
        selector: 'td:nth-child(2)'
    },
    language: {
        url: '../Content/DataTable/js/Spanish.json',
    }
});
