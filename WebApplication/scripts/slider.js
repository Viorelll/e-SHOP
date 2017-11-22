$(function () {

    var value1;
    var value2;

    $("#slider-range").slider({
        range: true,
        min: 0,
        max: 2000,
        values: [75, 300],
        slide: function (event, ui) {
            $("#amount").val("$" + ui.values[0] + " - $" + ui.values[1]);

            value1 = ui.values[0];
            value2 = ui.values[1];

                $.ajax({
                    type: "POST",
                    url: "../Items/ItemsViewPartial",
                    data: "range1=" + value1 + "&range2=" + value2,

                    success: function(data) {
                        $("#slide_items").html(data);
                    },

                    error: function(result) {
                        alert("Error");
                    }

                });
        }


    });


    $("#amount").val("$" + $("#slider-range").slider("values", 0) + " - $" + $("#slider-range").slider("values", 1));
    


});


