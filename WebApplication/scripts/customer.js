$(function () {

    var createUserLinkSelector = "#createUserLink";
    var dlgCreateUserSelector = "#dlgCreateUser";
    var saveUserFormSelector = "#saveUserForm";

    var popup = $(dlgCreateUserSelector);

    $(createUserLinkSelector).click(function() {
        $.get("../User/CreateUser",
            function(data) {
             
                popup.html(data);

                popup.dialog(
                {
                    title: "Create user",
                    autoOpen: false,
                    modal: true,
                    resizable: false,
                    width: 820,
                    buttons: {
                        "Create user": saveUserForm,

                        Cancel: function () {
                            popup.dialog("close");
                        }
                    },

                    open: function (event, ui) {

                        $("form").removeData("validator");
                        $("form").removeData("unobtrusiveValidation");
                        $.validator.unobtrusive.parse("form");

                        $(dlgCreateUserSelector).css("overflow", "hidden");
                    },

                    create: function () {
                    $(this).closest(".ui-dialog")
                        .find(".ui-button").eq(1) // the first button
                        .addClass("btn btn-primary").css("color", "white").css("button:hover", "none").css("button:after", "none");
                    }
                });

   
                popup.dialog('open');

                popup.dialog()
                    .prev(".ui-dialog-titlebar")
                    .css("color", "#FE980F")
                    .css("font-family", "Roboto", "sans-serif")
                    .css("font-size", "17px")
                    .css("font-weight", "700")
                    .css("text-transform", "uppercase")
                    .css("position", "relative")
                    .css("margin-bottom", "30px")
                    .css("text-align", "center");

            });
    });

    function saveUserForm() {
        var saveUserFormVar = $(saveUserFormSelector);
        $.ajax({
            type: "POST",
            url: saveUserFormVar.attr("action"),
            data: saveUserFormVar.serialize(),
            success: function() {

                if ($("#saveUserForm").valid()) {
                    //alert("Succes. User was added !");
                    popup.dialog("close");
                    location.reload();

                    return true;

                } else {
                    return false;
                }
            }

        });
    }

});

