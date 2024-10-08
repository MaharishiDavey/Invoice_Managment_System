﻿var dataTable;
$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/invoice/getall",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "billNo", "width": "30%" },
            { "data": "partyDetail.partyName", "width": "50%" },
            {
                "data": "billNo",
                "render": function (data) {
                    
                    if (data) {
                        return `<div class="w-75 btn-group" role="group">
                                    <a href="/invoice/upsert?billNo=${data}" class="btn btn-primary mx-2">
                                        <i class="bi bi-pencil-square"></i> Edit 
                                    </a>
                                    <a onClick=Delete('/invoice/delete?billNo=${data}') class="btn btn-danger mx-2"> 
                                        <i class="bi bi-trash-fill"></i> Delete 
                                    </a>
                                </div>`;
                    } else {
                        return '<span class="text-danger">No BillNo</span>';
                    }
                },
                "width": "20%"
            }
        ],
        "language": {
            "emptyTable": "No data found"
        },
        "width": "100%"
    });
}


function Delete(url) {
    Swal.fire({
        title: "Are you sure?",
        text: "You won't be able to revert this!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Yes, delete it!"
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    if (data.success) {
                        dataTable.ajax.reload();
                        toastr.success(data.message);
                    } else {
                        toastr.error(data.message);
                    }
                },
                error: function (xhr, status, error) {
                    toastr.error("Something went wrong!");
                }
            });
        }
    });
}
