$(document).ready(function () {
    
    $('.datepicker').datepicker();
    if ($('#DebitLine_ProjectID option:selected').text() == "") {
        $("#TextErrorMessage").removeClass("hidden")
        $("input[type='submit']").addClass("hidden")
        
    }
});

