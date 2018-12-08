$(document).ready(function () {
    $("#CompanyID").on("change", OnChange);
    $("#PriceListID").on("change", OnChangePrice);
    $("#PartnerLevelID").on("change", OnChangePartner);
    $("input[type='submit']").on("click", OnClick);
    
});

function OnChange() {
    //alert($('#CompanyID option:selected').text())
    if($('#CompanyID option:selected').text() == ""){
        $("#TextErrorMessage").removeClass("hidden")
        $("input[type='submit']").addClass("hidden")
    }
    else {
        $("#TextErrorMessage").addClass("hidden")
        if ($("#TextErrorMessagePrice").hasClass("hidden") && $("#TextErrorMessagePartner").hasClass("hidden"))
        $("input[type='submit']").removeClass("hidden")

    }
      
}

function OnChangePrice() {
    if ($('#PriceListID option:selected').text() == "") {
        $("#TextErrorMessagePrice").removeClass("hidden")
        $("input[type='submit']").addClass("hidden")
    }
    else {
        $("#TextErrorMessagePrice").addClass("hidden")
        if ($("#TextErrorMessage").hasClass("hidden") && $("#TextErrorMessagePartner").hasClass("hidden"))
        $("input[type='submit']").removeClass("hidden")

    }
}

function OnChangePartner() {
    if ($('#PartnerLevelID option:selected').text() == "") {
        $("#TextErrorMessagePartner").removeClass("hidden")
        $("input[type='submit']").addClass("hidden")
    }
    else {
        $("#TextErrorMessagePartner").addClass("hidden")
        if ($("#TextErrorMessage").hasClass("hidden") && $("#TextErrorMessagePrice").hasClass("hidden"))
            $("input[type='submit']").removeClass("hidden")

    }
}


function OnClick(e) {
    if ($("#TextErrorMessage").hasClass("hidden")) {
        $("#btnSaveChanges").addClass("hidden")
    }
    else {
        $("#btnSaveChanges").removeClass("hidden")
    }
 
}