
$(function () {
    
    $("#customerFormDisplay").validate({
        
        rules: {

            name: "required",
            surname: "required",
            phone: "required",
            number: {
                required: true,
                digits: true},
            street: "required"
            },
      
        messages: {
            name: "Please enter your name",
            surname: "Please enter your surname",
            number: "Please enter house number",
            street: "Please enter valid street name",
            phone: "Please enter a valid phone number"
        },
        
        submitHandler: function (form) {
            form.submit();
        }
    });
});