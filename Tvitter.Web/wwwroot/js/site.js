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
            $("p").html(function (_, html) {
                return html.replace(/(\#\w+)/g, '<span class="blue">$1</span>');
            });
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
            $("p").html(function (_, html) {
                return html.replace(/(\#\w+)/g, '<span class="blue">$1</span>');
            });
        }

    });

}

$(document).ready(function () {
    $("p").html(function (_, html) {
        html = html.replace(/(\#\w+)/g, '<a href="/Tweet/Trend?tag=$1"><span class="blue">$1</span></a>');
        return html.replace(/=\#/g, '='+encodeURIComponent('#'));
    });
});