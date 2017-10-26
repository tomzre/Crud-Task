$(document).ready(function () {
    var table = $("#customer-table").DataTable({
        ajax: {
            url: "/api/customers",
            dataSrc: ""
        },
        columns: [

            {
                data: "name",
                render: function (data, type, customer) {
                    return "<a href='/home/edit/" + customer.id + "'>" + customer.name + "</a>"
                }
            },
            {
                data: "surname"
            },
            {
                data: "phoneNumber"
            },
            {
                data: "address.streetName"
            },
            {
                data: "id",
                render: function (data) {
                    return "<button class='btn-link dt-remove' data-customer-id=" + data + ">Delete</button>"
                }
            }
        ]
    });

    $("#customer-table").on("click", ".dt-remove", function () {
        var button = $(this);

        $.ajax({
            url: "/api/customers/" + button.attr("data-customer-id"),
            method: "DELETE",
            success: function () {
                table.row(button.parents("tr")).remove().draw();

            }
        });
    });


});