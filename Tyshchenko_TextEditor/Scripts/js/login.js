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

    $("#signIn").click(function () {
        var login = $('#signin-username').val();

        var pwd = $('#signin-password').val();
        var data = {
            'username': login,
            'password': pwd
        };
        API.backendPost('/login/', data, function (err, data) {
            if (!err) {
                if (data.status === "ok")
                    window.location.href = "/home";
                else {
                    $('#error').css('visibility', 'visible');
                }
            }
            else
                alert('Error');
        })
    });
})

