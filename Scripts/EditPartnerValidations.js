$(document).ready(function () {
    $("#PartnerLevelID").on("change", OnChangePartner);
  $("#IsAPartner").on("click", OnFocusoutisAPartner);
    //$("#KopplatPartner").on("click", OnFocusoutKopplatAPartner);
    if (document.getElementById("IsAPartner").checked == true) {
        ($("#PartnerLevelDropDownList").removeClass("hidden"))
        ($("#KopplatPartnrtDropdownList").addClass("hidden"))
    }
    
    if ($('#PartnerLevelID option:selected').text() == "Välj") {
        $("#TextErrorMessagePartner").removeClass("hidden")
    }
    
    
}); 

function OnFocusoutisAPartner() {
    if (document.getElementById("IsAPartner").checked == true && $('#PartnerLevelID option:selected').text() == "Välj") {
        $("input[type='submit']").addClass("hidden")
    }
    else {
        $("input[type='submit']").removeClass("hidden")
    }
    if (document.getElementById("IsAPartner").checked == true) {
        ($("#PartnerLevelDropDownList").removeClass("hidden"))
        ($("#KopplatPartnrtDropdownList").addClass("hidden"))
                

    }
    else {
        ($("#PartnerLevelDropDownList").addClass("hidden"))
        ($("#KopplatPartnrtDropdownList").removeClass("hidden"))

    }
}

function OnChangePartner() {
    if ($('#PartnerLevelID option:selected').text() == "Välj") {
        $("#TextErrorMessagePartner").removeClass("hidden")
        $("input[type='submit']").addClass("hidden")
       
    }
    else {
        $("#TextErrorMessagePartner").addClass("hidden")
        $("input[type='submit']").removeClass("hidden")
        
    }
}