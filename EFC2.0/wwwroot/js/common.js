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

    $("#invisiblepass").hide();

    $("#visiblepass").click(function () {
        $("#visiblepass").hide();
        $("#invisiblepass").show();
        $("#mat-input-3").attr("type", "text");
    });

    $("#invisiblepass").click(function () {
        $("#visiblepass").show();
        $("#invisiblepass").hide();
        $("#mat-input-3").attr("type", "password");
    });
});
$(document).ready(function () {
    // When a tab is clicked
    $(".topnav li").on("click", function () {
        // Remove active class from all tabs
        $(".topnav li").removeClass("nav-active-top");

        // Add active class to the clicked tab
        $(this).addClass("nav-active-top");

        // Hide all content divs
        $(".content").removeClass("nav-active-top");

        // Show the content corresponding to the clicked tab
        var target = $(this).data("target");
        $("#" + target).addClass("nav-active-top");
    });
});
//$(document).ready(function () {
//    // When a tab is clicked
//    $(".topnav li, .topnav-child-1 li").on("click", function () {
//        // Remove active class from all tabs
//        $(".topnav li, .topnav-child-1 li").removeClass("nav-active-top");

//        // Add active class to the clicked tab
//        $(this).addClass("nav-active-top");

//        // Hide all content divs
//        $(".content").removeClass("nav-active-top");

//        // Show the content corresponding to the clicked tab
//        var target = $(this).data("target");
//        $("#" + target).addClass("nav-active-top");
//    });
//});