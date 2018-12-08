$(document).ready(function () {
   
    var subscicID;
    var st;
    
    
    $("#1").click(function () {
        subscicID = $("#1").attr("val");
        
        
        if (document.getElementById("1").checked == true)
        {
            st = true 
        }
        else
        {
            st = false
        }
        submitValue();
       
    });
    $("#2").click(function () {
        subscicID = $("#2").attr("val");


        if (document.getElementById("2").checked == true) {
            st = true
        }
        else {
            st = false
        }
        submitValue()
    });
    $("#3").click(function () {
        subscicID = $("#3").attr("val");


        if (document.getElementById("3").checked == true) {
            st = true
        }
        else {
            st = false
        }
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

