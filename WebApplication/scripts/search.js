
$("#search")
    .autocomplete({
        source:
                function (request, response) {
                    $.ajax({
                    url: "../Home/GetItemName",
                    type: "POST",
                    dataType: "json",
                    contentType: "application/json",
                    data: "{'name':'" + request.term + "'}",

                    success: function(data) {
                        response(data);
                    },
                    error: function(result) {
                        alert("Error");
                    }
                    });
                },
        delay: 150

    });

$("#search").keyup(function (event) {
    if (event.keyCode == 13) {
        $.ajax({
            type: "POST",
            url: "../Items/SearchItemsViewPartial",
         
            data: "search=" + $("#search").val(),

            success: function (data) {
                $("#slide_items").html(data);
            },

            error: function (result) {
                alert("Error");
            }

        });
    }
});

