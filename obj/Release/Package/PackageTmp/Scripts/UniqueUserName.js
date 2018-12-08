$(document).ready(function () {
    $("#UserName").on("focusout", OnFocusout);
    //$("input[type='submit']").on("click", OnClick);
    

});

function OnFocusout(e) {
    
    $.ajax(
        {
            url: "/Members/UniqueUserName",
            type: "post",
            dataType: "json",
            data:
            {
                DataName: this.id,
                Text: this.value
            },
            context: this,
            success: function (data) {
                if (data.length > 0) {
                    $("#TextErrorMessage").removeClass("hidden");
                    $("#TextErrorMessage").addClass("has-error");
                    $("input[type='submit']").addClass("hidden")
                    
                }
                else {
                    $("#TextErrorMessage").addClass("hidden");
                    
                    $("input[type='submit']").removeClass("hidden")
                    

                }
            },
            error: function (data) {
                $("#TextErrorMessage").removeClass("hidden");
                
                $("input[type='submit']").addClass("hidden")
                
            }
        });
    
}
function OnClick(e) {
    if ($("#TextErrorMessage").hasClass("has-error")) {
        e.preventdefault()();
    }
}