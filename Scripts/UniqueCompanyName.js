$(document).ready(function () {
    $("#CompanyName").on("focusout", OnFocusout);
    $("input[type='submit']").on("click", OnClick);

});

function OnFocusout(e) {
    $.ajax(
        {
            url: "/Companies/UniqueCompanyName",
            type: "post",
            dataType: "json",
            data:
            {
                DataName: this.id,
                Text: this.value
            },
            context: this,
            success: function (data) {
                if (data !== null && data.length > 0) {
                    $("#TextErrorMessage").removeClass("hidden");
                    $("#TextErrorMessage").addClass("has-error");
                    $("input[type='submit']").addClass("hidden")
                }
                else {
                    $("#TextErrorMessage").addClass("hidden");
                    $("#TextErrorMessage").removeClass("has-error");
                    $("input[type='submit']").removeClass("hidden")
                }
            },
            error: function (data) {
                $("#TextErrorMessage").addClass("hidden");
                $("#TextErrorMessage").removeClass("has-error");
                $("input[type='submit']").removeClass("hidden")
            }
        });
}
function OnClick(e) {
    if ($("#TextErrorMessage").hasClass("has-error")) {
        e.preventdefault()();
    }
}