$(document).ready(function () {
    //$("#isAPartner").on("click", OnFocusoutisAPartner);
    //$("#KopplatPartner").on("click", OnFocusoutKopplatAPartner);
    $('.datepicker').datepicker();
    if ($('#Subscription_ProjectID option:selected').text() == "") {
       $("#TextErrorMessage").removeClass("hidden")
       $("input[type='submit']").addClass("hidden")
       

    }
    
});