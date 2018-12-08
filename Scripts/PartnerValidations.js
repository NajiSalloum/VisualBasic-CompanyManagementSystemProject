$(document).ready(function () {
    $("#isAPartner").on("click", OnFocusoutisAPartner);
    $("#KopplatPartner").on("click", OnFocusoutKopplatAPartner);
    
});

function OnFocusoutisAPartner() {
    if (document.getElementById("isAPartner").checked == true) {
        ($("#PartnerDropdownList").removeClass("hidden"))
        ($("#divKopplatPartner").addClass("hidden"))
        
    }
    else {
        ($("#PartnerDropdownList").addClass("hidden"))
        ($("#divKopplatPartner").removeClass("hidden"))
        
    } 
}
function OnFocusoutKopplatAPartner() {
    if (document.getElementById("KopplatPartner").checked == true) {
        ($("#KopplatPartnrtDropdownList").removeClass("hidden"))
        ($("#divIsAPartner").addClass("hidden"))

    }
    else {
        ($("#KopplatPartnrtDropdownList").addClass("hidden"))
        ($("#divIsAPartner").removeClass("hidden"))

    }
}