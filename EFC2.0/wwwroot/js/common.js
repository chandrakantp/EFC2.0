// Define functions globally
function otpbtn() {
    $("#login-form-withOTP").show();
    $("#login-form").hide();
    $("#forgot-pass-form").hide();
}

function backToLogin() {
    $("#login-form-withOTP").hide();
    $("#login-form").show();
    $("#forgot-pass-form").hide();
}

function forgotPassword() {
    $("#login-form-withOTP").hide();
    $("#login-form").hide();
    $("#forgot-pass-form").show();
}

$(document).ready(function () {
    $(".profile-data").click(function () {
        $("#dropdownMenu").toggle();
        $(".cdk-overlay-backdrop").addClass("cdk-overlay-backdrop-showing");
    });
    $(".cdk-overlay-backdrop").click(function () {
        $("#dropdownMenu").hide();
        $(".cdk-overlay-backdrop").removeClass("cdk-overlay-backdrop-showing");
    });
    $("#logoutButton").click(function () {
        window.location.href = "index";
    });

    $("#login-form-withOTP").hide();
    $("#forgot-pass-form").hide();

    $("#invisiblepass").hide(); // Hide the 'visibility_on' icon initially

    $("#visiblepass").click(function () {
        $("#visiblepass").hide();
        $("#invisiblepass").show();
        $("#mat-input-3").attr("type", "text"); // Change password field to text
    });

    $("#invisiblepass").click(function () {
        $("#visiblepass").show();
        $("#invisiblepass").hide();
        $("#mat-input-3").attr("type", "password"); // Change text field back to password
    });
});