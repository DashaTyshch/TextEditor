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

    $(".submit-btn").on("click", function (e) {
        $("#loader").show();
    });
})

