$(document).ready(function () {
  $("#IsAPartner").on("click", OnFocusoutisAPartner);
    //$("#KopplatPartner").on("click", OnFocusoutKopplatAPartner);
    if (document.getElementById("IsAPartner").checked == true) {
        ($("#PartnerLevelDropDownList").removeClass("hidden"))
        ($("#KopplatPartnrtDropdownList").addClass("hidden"))
        }
    
}); 

function OnFocusoutisAPartner() {
    
    if (document.getElementById("IsAPartner").checked == true) {
        ($("#PartnerLevelDropDownList").removeClass("hidden"))
        ($("#KopplatPartnrtDropdownList").addClass("hidden"))

    }
    else {
        ($("#PartnerLevelDropDownList").addClass("hidden"))
        ($("#KopplatPartnrtDropdownList").removeClass("hidden"))

    }
}

