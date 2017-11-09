$(document).ready(function () {

    function selectView(view) {
        $(".display").not("#" + view + "Display").hide();
        $("#" + view + "Display").show();
    }

    selectView("customer-table");

    var table = $("#customer-tableDisplay").DataTable({
       
        ajax: {
            url: "/api/customers",
            dataSrc: ""
        },
        columns: [

            {
                data: "name",
                render: function (data, type, customer) {
                    
                    return "<button id='btnEdit' class='btn-link'  data-customer-id=" + customer.id + ">" + customer.name + "</button>";
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
                    return "<button class='btn-link dt-remove' data-customer-id=" + data + ">Delete</button>";
                }
            }
        ]
    });

    $("#customer-tableDisplay").on("click", ".dt-remove", function () {
        var button = $(this);

        $.ajax({
            url: "/api/customers/" + button.attr("data-customer-id"),
            method: "DELETE",
            success: function () {
                table.row(button.parents("tr")).remove().draw();

            }
        });
    });

    $("#btnAdd").on("click", function () { selectView("customerForm"); });
    $("#btnList").on("click", function () {
        selectView("customer-table");
        
    });
    $(document).delegate("#btnEdit", "click", function () {
        var editbtn = $(this);
        
        $.ajax({
            url: "/api/customers/" + editbtn.attr("data-customer-id"),
            method: "GET",
            success: function (data) {
                $("#editId").val(data.id);
                $("#editAddressId").val(data.address.id);
                $("#editName").val(data.name);
                $("#editSurname").val(data.surname);
                $("#editPhone").val(data.phoneNumber);
                $("#editStreet").val(data.address.streetName);
                $("#editNumber").val(data.address.houseNumber)
                selectView("edit"); 
                console.log("succeced");
            },
            error: function (jqXHR, exception) {
                console.log(jqXHR.responseText);
            }


        });


    });


});