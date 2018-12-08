$(document).ready(function () {
    
    var subscicID;
    var st;
    
    
    $("#1").click(function () {
        
        subscicID = $("#1").attr("val");
        if (document.getElementById("1").checked == true) { st = true }
        else { st = false }
        
        submitValue()
    });
    $("#2").click(function () {
        subscicID = $("#2").attr("val");
        if (document.getElementById("2").checked == true) { st = true }
        else { st = false }
        submitValue()
    });
    $("#3").click(function () {
        subscicID = $("#3").attr("val");
        if (document.getElementById("3").checked == true) { st = true }
        else { st = false }
        submitValue()
    });
    $("#4").click(function () { subscicID = $("#4").attr("val");
        if (document.getElementById("4").checked == true) { st = true }
        else { st = false }
        submitValue()
    });
    $("#5").click(function () {
        subscicID = $("#5").attr("val");
        if (document.getElementById("5").checked == true) { st = true }
        else { st = false }
        submitValue()
    });
    $("#6").click(function () {
        subscicID = $("#6").attr("val");
        if (document.getElementById("6").checked == true) { st = true }
        else { st = false }
        submitValue()
    });
    $("#7").click(function () {
        subscicID = $("#7").attr("val");
        if (document.getElementById("7").checked == true) { st = true }
        else { st = false }
        submitValue()
    });
    $("#8").click(function () {
        subscicID = $("#8").attr("val");
        if (document.getElementById("8").checked == true) { st = true }
        else { st = false }
        submitValue()
    });
    $("#9").click(function () {
        subscicID = $("#9").attr("val");
        if (document.getElementById("9").checked == true) { st = true }
        else { st = false }
        submitValue()
    });
    $("#10").click(function () {
        subscicID = $("#10").attr("val");
        if (document.getElementById("10").checked == true) { st = true }
        else { st = false }
        submitValue()
    });
    $("#11").click(function () {
        subscicID = $("#11").attr("val");
        if (document.getElementById("11").checked == true) { st = true }
        else { st = false }
        submitValue()
    });
    $("#12").click(function () {
        subscicID = $("#12").attr("val");
        if (document.getElementById("12").checked == true) { st = true }
        else { st = false }
        submitValue()
    });
    $("#13").click(function () {
        subscicID = $("#13").attr("val");
        if (document.getElementById("13").checked == true) { st = true }
        else { st = false }
        submitValue()
    });
    $("#14").click(function () {
        subscicID = $("#14").attr("val");
        if (document.getElementById("14").checked == true) { st = true }
        else { st = false }
        submitValue()
    });
    $("#15").click(function () {
        subscicID = $("#15").attr("val");
        if (document.getElementById("15").checked == true) { st = true }
        else { st = false }
        submitValue()
    });
    $("#16").click(function () {
        subscicID = $("#16").attr("val");
        if (document.getElementById("16").checked == true) { st = true }
        else { st = false }
        submitValue()
    });
    $("#17").click(function () {
        subscicID = $("#17").attr("val");
        if (document.getElementById("17").checked == true) { st = true }
        else { st = false }
        submitValue()
    });
    $("#18").click(function () {
        subscicID = $("#18").attr("val");
        if (document.getElementById("18").checked == true) { st = true }
        else { st = false }
        submitValue()
    });
    $("#19").click(function () {
        subscicID = $("#19").attr("val");
        if (document.getElementById("19").checked == true) { st = true }
        else { st = false }
        submitValue()
    });
    $("#20").click(function () {
        subscicID = $("#20").attr("val");
        if (document.getElementById("20").checked == true) { st = true }
        else { st = false }
        submitValue()
    });
    function submitValue() {
        $.ajax(
        {
            url: "/Subscriptions/DebiteraASubsicription",
            type: "post",
            dataType: "json",
            data:
            {
                
                Text: subscicID,
                status: st
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

});

