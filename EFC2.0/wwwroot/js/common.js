
$(document).ready(function () {
    $("#otpbtn").click(function () {
        $("#login-form-withOTP").show(); 
        $("#login-form").hide(); 
    });

    $("#backToLogin").click(function () {
        $("#login-form-withOTP").hide();
        $("#login-form").show();
    });

});