/*
$(document).ready(function() {
    // Khởi tạo DataTable
    var table = $('#example').DataTable({
        "ajax": {
            "url": "http://10.17.156.124/api/Computer",
            "method": "GET",
            "dataSrc": ""
        },
        "columns": [
            { "data": "HostName", "title": "HostName" },
            {
                "data": "Station",
                "title": "Station",
                "render": function (data, type, row) {
                    return '<a href="#myModal" data-toggle="modal" data-target="#myModal" data-office="' + row.IP + '">'+data+'</a>';
                }
            },
            { "data": "IP", "title": "IP" },
            { "data": "Running", "title": "Running" },
            { "data": "CreateDate", "title": "CreateDate" },
            { "data": "Note", "title": "Note" }
        ]
    });

    // Điều khiển Modal
    $("#myModal").on('show.bs.modal', function (e) {
        // Đặt nội dung cho modal
        $('#modal_content').html('OK');
    });
});

*/


/*
$("#myModal").on('show.bs.modal', function (e) {

        var triggerLink = $(e.relatedTarget);
        var office = triggerLink.data("office");

        var data = table.rows( triggerLink.closest('tr') ).data();

        $('#modal_table').DataTable({
            destroy: true,
            data: data,
            /!*      ajax: {
                    url: "/ajax/objects.txt",
                    data: function ( d ) {
                      d.office_search = office;
                    },
                    // dataSrc is used to simulate the the returned filter data based on office
                    dataSrc: function ( json ) {
                      var data = [];
                      for ( var i=0, ien=json.data.length ; i<ien ; i++ ) {
                        if (json.data[i].office === office) {
                          data.push(json.data[i]);
                        }
                      }
                      return data;
                    }
                  },
            *!/      columns: [
                { "data": "name" },
                { "data": "position" },
                { "data": "office" },
            ]

        });

    });


} );*/
















/*
$(document).ready(function() {
    $("#datatable").DataTable({
        language: {
            paginate: {
                previous: "<i class='mdi mdi-chevron-left'>",
                next: "<i class='mdi mdi-chevron-right'>"
            }
        },
        drawCallback: function() {
            $(".dataTables_paginate > .pagination").addClass("pagination-rounded")
        }
    });
    var a = $("#datatable-buttons").DataTable({
        lengthChange: !1,
        language: {
            paginate: {
                previous: "<i class='mdi mdi-chevron-left'>",
                next: "<i class='mdi mdi-chevron-right'>"
            }
        },
        drawCallback: function() {
            $(".dataTables_paginate > .pagination").addClass("pagination-rounded")
        },
        buttons: ["copy", "excel", "pdf", "colvis"]
    });
    a.buttons().container().appendTo("#datatable-buttons_wrapper .col-md-6:eq(0)"), $(".dataTables_length select").addClass("form-select form-select-sm"), $("#selection-datatable").DataTable({
        select: {
            style: "multi"
        },
        language: {
            paginate: {
                previous: "<i class='mdi mdi-chevron-left'>",
                next: "<i class='mdi mdi-chevron-right'>"
            }
        },
        drawCallback: function() {
            $(".dataTables_paginate > .pagination").addClass("pagination-rounded")
        }
    }), $("#key-datatable").DataTable({
        keys: !0,
        language: {
            paginate: {
                previous: "<i class='mdi mdi-chevron-left'>",
                next: "<i class='mdi mdi-chevron-right'>"
            }
        },
        drawCallback: function() {
            $(".dataTables_paginate > .pagination").addClass("pagination-rounded")
        }
    }), a.buttons().container().appendTo("#datatable-buttons_wrapper .col-md-6:eq(0)"), $(".dataTables_length select").addClass("form-select form-select-sm"), $("#alternative-page-datatable").DataTable({
        pagingType: "full_numbers",
        drawCallback: function() {
            $(".dataTables_paginate > .pagination").addClass("pagination-rounded"), $(".dataTables_length select").addClass("form-select form-select-sm")
        }
    }), $("#scroll-vertical-datatable").DataTable({
        scrollY: "350px",
        scrollCollapse: !0,
        paging: !1,
        language: {
            paginate: {
                previous: "<i class='mdi mdi-chevron-left'>",
                next: "<i class='mdi mdi-chevron-right'>"
            }
        },
        drawCallback: function() {
            $(".dataTables_paginate > .pagination").addClass("pagination-rounded")
        }
    }), $("#complex-header-datatable").DataTable({
        language: {
            paginate: {
                previous: "<i class='mdi mdi-chevron-left'>",
                next: "<i class='mdi mdi-chevron-right'>"
            }
        },
        drawCallback: function() {
            $(".dataTables_paginate > .pagination").addClass("pagination-rounded"), $(".dataTables_length select").addClass("form-select form-select-sm")
        },
        columnDefs: [{
            visible: !1,
            targets: -1
        }]
    }), $("#state-saving-datatable").DataTable({
        stateSave: !0,
        language: {
            paginate: {
                previous: "<i class='mdi mdi-chevron-left'>",
                next: "<i class='mdi mdi-chevron-right'>"
            }
        },
        drawCallback: function() {
            $(".dataTables_paginate > .pagination").addClass("pagination-rounded"), $(".dataTables_length select").addClass("form-select form-select-sm")
        }
    })
});*/



