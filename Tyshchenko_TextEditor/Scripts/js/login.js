$(document).ready(function () {

    $(".fliper-btn").click(function () {
        var card = $('#card');

        if (card.hasClass('flipped')) {
            $('.front').css("display", "block");
            $('.back').css("display", "none");
        } else {
            $('.front').css("display", "none");
            $('.back').css("display", "block");
        }
        card.toggleClass('flipped');
    });

    $("#signIn").on("click", function (e) {
        e.preventDefault();
        $("#loader").show();

        if ($("#signIn_form").valid()) {
            //$.validator.unobtrusive.parse(form);
            $('#signIn_form').submit();
        }
        else {
            $("#loader").hide();
        }
    });

    $("#signUp").on("click", function (e) {
        e.preventDefault();
        $("#loader").show();

        if ($("#signUp_form").valid()) {
            //$.validator.unobtrusive.parse(form);
            $('#signUp_form').submit();
        }
        else {
            $("#loader").hide();
        }
    });

    $("#signUp_form").on("submit", function (e) {
        e.preventDefault();
        var form = $(this);

        $.ajax({
            url: form.attr("action"),
            type: "POST",
            data: form.serialize(),
            success: function (data) {
                //var result = $.parseJSON(data);
                if (data.result) {
                    window.location.href = data.url;
                } else {
                    $("#loader").hide();
                }
            }
        });
    });
})

