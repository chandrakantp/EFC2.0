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
    var currentUrl = window.location.pathname;
    $('.topnav li a').each(function () {
        var link = $(this);
        if (currentUrl.indexOf(link.attr('href')) !== -1) {
            link.closest('li').addClass('nav-active-top');
        } else {
            link.closest('li').removeClass('nav-active-top');
        }
    });

    $('.mat-tab-group .tabs .tab-button').click(function () {
        var targetTab = $(this).data('target');
        $('.mat-tab-group .tabs .tab-button').removeClass('mat-tab-body-active');
        $(this).addClass('mat-tab-body-active');
        $('.mat-tab-body').removeClass('mat-tab-body-active');
        $('#' + targetTab).addClass('mat-tab-body-active');
    });
});

$(document).ready(function () {
    $("#employeeAddPage").hide();
    $("#empCards").hide();
    $("#addCandidateDetails").hide();
});
function addEmployee() {
    $("#employeeDetailPage").hide();
    $("#employeeAddPage").show();
}
function backToEmpDetails() {
    $("#employeeDetailPage").show();
    $("#employeeAddPage").hide();
}
function showEmpCard() {
    $("#empCards").toggle();
}
function copyEmailText() {
    const emailText = document.getElementById("emailText").innerText;
    navigator.clipboard.writeText(emailText).then(() => {
        alert("Copied to clipboard: " + emailText);
    }).catch(err => {
        console.error("Failed to copy: ", err);
    });
}
function addCandidate() {
    $("#CandidateDetailPage").hide();
    $("#addCandidateDetails").show();
}
function backToCanDetails() {
    $("#CandidateDetailPage").show();
    $("#addCandidateDetails").hide();
}