$(document).ready(function () {
    $("#isAPartner").on("click", OnFocusoutisAPartner);
});

function OnFocusoutisAPartner() {
    if (document.getElementById("isAPartner").checked == true) {
        //($("#PartnerDropdownList").removeClass("hidden"))
        //($("#KopplatPartnrtDropdownList").addClass("hidden"))
        //alert("Helllo")
    }
    else {
        //($("#PartnerDropdownList").addClass("hidden"))
        //($("#KopplatPartnrtDropdownList").removeClass("hidden"))
        alert("Hello")
    }
}
