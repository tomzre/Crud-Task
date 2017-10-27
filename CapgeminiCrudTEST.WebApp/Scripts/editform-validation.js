
$(function () {

    $("#editDisplay").validate({

        rules: {

            editName: "required",
            editSurname: "required",
            editPhone: "required",
            editNumber: {
                required: true,
                digits: true
            },
            editStreet: "required"
        },

        messages: {
            editName: "Please enter your name",
            editSurname: "Please enter your surname",
            editNumber: "Please enter house number",
            editStreet: "Please enter valid street name",
            editPhone: "Please enter a valid phone number"
        },

        submitHandler: function (form) {
            form.submit();
        }
    });
});