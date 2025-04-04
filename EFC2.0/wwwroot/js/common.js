﻿// Define functions globally
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
    $(".topnav li").on("click", function () {
        $(".topnav li").removeClass("nav-active-top");
        $(this).addClass("nav-active-top");
        $(".child-content").removeClass("nav-active-top");
        var target = $(this).data("target");
        $("#" + target).addClass("nav-active-top");
    });
    $(".topnav-child-1 li").on("click", function () {
        $(".topnav-child-1 li").removeClass("nav-active-top");
        $(this).addClass("nav-active-top");
        $(".grand-child").removeClass("nav-active-top");
        var target = $(this).data("target");
        $("#" + target).addClass("nav-active-top");
    });
});