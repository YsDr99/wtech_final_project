// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.


function LikeTweet(u, t) {

    $.ajax({
        type: "POST",
        url: '/Home/LikeTweet',
        data: {
            UserId: u,
            TweetId: t,
        },
        dataType: 'html',
        success: function (result) {

            $("#view" + t).html(result);

        },
        error: function (e) {
            console.log(e.responseText);
        }
    });
}
function UnlikeTweet(u, t) {

    $.ajax({
        type: "POST",
        url: '/Home/UnlikeTweet',
        data: {
            UserId: u,
            TweetId: t,
        },
        dataType: 'html',
        success: function (result) {

            $("#view" + t).html(result);

        }

    });

}

function goBack() {
    window.history.back();
}