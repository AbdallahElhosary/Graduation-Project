$(document).ready(function () {
    $("#yourInputId").on("input", function () {
        var val = $(this).val();
        if (val <= 0.00) {
            $(this).val(""); // قم بتفريغ القيمة إذا كانت أقل من أو تساوي الصفر
            alert("Please enter a value greater than 0.");
        }
    });
});