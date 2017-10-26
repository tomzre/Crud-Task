$(document).ready(function () {
    console.log("formhandler loaded");
    $("#customerForm").submit(function (event) {
        console.log("clicked");
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
});