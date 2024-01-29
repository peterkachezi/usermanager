$("#btnLogin").click(function () {


    $("#btnLogin").attr("disabled", true);
    $("#btnLogin").html("Please wait...");

    if ($('#txtName').val() == '' || $('#txtName').val() === null) {
        $('#txtName').focus();
        swal({
            position: 'top-end',
            type: "error",
            title: "Please enter username ",
            showConfirmButton: true,
        });
        document.getElementById("txtName").style.borderColor = "red";
        document.getElementById("txtName").style.backgroundColor = "#ffcdcd";
        $("#btnLogin").attr("disabled", false);
        $("#btnLogin").html("Submit");
        return false;
    }
    else {
        document.getElementById("txtName").style.borderColor = "#dfe3e7";
        document.getElementById("txtName").style.backgroundColor = "#FFF";
    }


    var formData = new FormData($('#frmAddDepartments').get(0));

    $.ajax({
        type: "POST",
        url: "/adminv1/Departments/Create", // NB: Use the correct action name
        data: formData,
        dataType: 'json',
        contentType: false,
        processData: false,
        success: function (response) {
            if (response.success) {

                swal({
                    position: 'top-end',

                    type: "success",

                    title: response.responseText,

                    showConfirmButton: false,

                }), setTimeout(function () { location.reload(); }, 1000);

            } else {

                swal({
                    position: 'top-end',
                    type: "error",
                    title: response.responseText,
                    showConfirmButton: true,
                    timer: 5000,
                });
                $("#btnAddDepartments").attr("disabled", false);
                $("#btnAddDepartments").html("Submit");
            }
            $("#divLoader").hide();
        },
        error: function (error) {
            alert("errror");
        }
    });

});