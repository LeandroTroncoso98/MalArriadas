var dataTable;

$(document).ready(function () {
    cargarDatatable();
});

function cargarDatatable() {
    dataTable = $("#tblTalle").DataTable({
        "ajax": {
            "url": "/admin/talles/GetAll",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "talle_Id", "width": "10%" },
            { "data": "nombre", "width": "60%" },
            {
                "data": "talle_Id",
                "render": function (data) {
                    return `<div class="text-center">
                                <a href="/Admin/Talles/Edit/${data}" class='btn btn-warning text-white' style='cursor:pointer; width:100px;'>
                                    <i class='far fa-edit'></i> 
                                </a>
                                &nbsp;
                                <a onclick=Delete("/Admin/Talles/Delete/${data}") class='btn btn-danger text-white' style='cursor:pointer; width:100px;'>
                                    <i class='far fa-trash-alt'></i> 
                                </a>
                            </div>
                            `;
                }, "width": "35%"
            }
        ],
        "language": {
            "emptyTable": "No hay registros."
        },
        "width": "100%"
    });
}

function Delete(url) {
    swal({
        title: "Esta seguro de borrar?",
        text: "Una vez eliminado sera imposible recuperarlo.",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Si, borrar!",
        closeOnconfirm: true
    }, function () {
        $.ajax({
            type: 'DELETE',
            url: url,
            success: function (data) {
                if (data.success) {
                    toastr.success(data.message);
                    dataTable.ajax.reload();
                }
                else {
                    toastr.error(data.message);
                }
            }
        });
    });
}