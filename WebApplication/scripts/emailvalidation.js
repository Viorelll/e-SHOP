$(function () {

    $.validator.addMethod(
            "emailvalidation", //should be same from  ValidationType = "emailvalidation"
            ///<summary>Method adding email validation.</summmary>
            function (value, element) {
                try {
                    if ($(element).is("disabled"))
                        return true;

                    if ($(element).is("[data-val-emailvalidation]")) {

                        var elementValue = $(element).val();
                        var valueTest = $(value).val();

                        return true; //TO DO
                    }
                } catch (e) {
                    return false;
                }
                return false;
            },
            "");
    $.validator.unobtrusive.adapters.addBool("emailvalidation");
}(jQuery));