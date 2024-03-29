﻿
var dtable;

$(document).ready(function () {
    dtable = $('#myTable').DataTable({
        ajax: '/Admin/Products/AllProducts',
        
        columns: [
            { "data": "name" },
            { "data": 'description' },
            { "data": "price" },
            { "data": "category.name" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                            <a href="/Admin/Products/CreateUpdate?id=${data}"><i class="bi bi-pencil-square"></i></a>
                     <a onclick=RemoveProduct("/Admin/Products/Delete/${data}")><i class="bi bi-trash"></i></a>       
`
            }
                }
        ]
    });

});
function RemoveProduct(url) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert it!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    if (data.success) {
                        dtable.ajax.reload();
                        toastr.success(data.message);
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    })
}
$.fn.dataTable.ext.errMode = 'throw';



    