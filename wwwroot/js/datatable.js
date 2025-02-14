$(document).ready(function () {
    //DATATABLES AYARLARI
    $('#myTable').DataTable({
        buttons: [
            'excel', 'print'
        ],
        layout: {
            top2Start: {
                buttons: [
                    'excel', 'print'
                ]
            },
        },
        lengthMenu: [
            [10, 25, 50, 100, 500,1000],
            [10, 25, 50, 100, 500,1000]
        ],
        order: [[0, 'desc']],
        language: {
            url: '/lib/DataTables/TurkishTranslate.json'
        },
        filter: true,
        responsive: true,

    });
});