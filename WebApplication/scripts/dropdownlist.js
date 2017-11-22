$(function(){

    $("#dropDownList").change(
        function () {

            var type = $(this).val();
            $.ajax({
                type: "GET",
                url: "../Items/CreateSubItem",
                data: "templateName=" + type,

                success: function (data) {
                    $("#itemType").html($(data));
                    $("form").removeData("validator");
                    $("form").removeData("unobtrusiveValidation");
                    $.validator.unobtrusive.parse("form");
                },

                error: function (result) {
                    alert("Error");
                }

            });

        }
    );



});