$(document).ready(function () {
    
    $("#customerFormDisplay").submit(function (event) {
        
        event.preventDefault();

        var name = $("#name").val();
        var surname = $("#surname").val();
        var phoneNumber = $("#phone").val();
        var houseNumber = $("#number").val();
        var streetName = $("#street").val();

        

        var formData = {
            name: name,
            surname: surname,
            phoneNumber: phoneNumber,
            address: {
                houseNumber: houseNumber,
                streetName: streetName
            }
        };

        var json = JSON.stringify((formData));

        $.ajax({
            type: "POST",
            url: "/api/customers",
            data: json,
            success: function (data) {
                location.reload();
            },
            
            dataType: "json",
            contentType: "application/json"
        });

        

    });


    $("#editDisplay").submit(function (event) {
        event.preventDefault();

        var getId = $("#editId").val();
        var ename = $("#editName").val();
        var esurname = $("#editSurname").val();
        var ephoneNumber = $("#editPhone").val();
        var ehouseNumber = $("#editNumber").val();
        var estreetName = $("#editStreet").val();
        var addressId = $("#editAddressId").val();

        var editedFormData = {
            name: ename,
            surname: esurname,
            phoneNumber: ephoneNumber,
            address: {
                id: addressId,
                houseNumber: ehouseNumber,
                streetName: estreetName
            }
        };

        var json = JSON.stringify((editedFormData));

        $.ajax({
            type: "PUT",
            url: "/api/customers/" + getId,
            data: json,
            success: function (data) {
                location.reload();
            },

            dataType: "json",
            contentType: "application/json"
        });
    });

});