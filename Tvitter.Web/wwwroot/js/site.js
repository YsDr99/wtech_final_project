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
            result = result.replace(/(\#\w+)/g, '<a href="/Tweet/Trend?tag=$1"><span class="blue">$1</span></a>');
            result = result.replace(/=\#/g, '=' + encodeURIComponent('#'));
            result = result.replace(/(\@\w+)/g, '<a href="/$1"><span class="blue">$1</span></a>');

            $("#view" + t).html(result);
        },
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
            result = result.replace(/(\#\w+)/g, '<a href="/Tweet/Trend?tag=$1"><span class="blue">$1</span></a>');
            result = result.replace(/=\#/g, '=' + encodeURIComponent('#'));
            result = result.replace(/(\@\w+)/g, '<a href="/$1"><span class="blue">$1</span></a>');

            $("#view" + t).html(result);
        }

    });

}

$(document).ready(function () {
    $("p").html(function (_, html) {
        html = html.replace(/(\#\w+)/g, '<a href="/Tweet/Trend?tag=$1"><span class="blue">$1</span></a>');
        html = html.replace(/=\#/g, '=' + encodeURIComponent('#'));
        html = html.replace(/(\@\w+)/g, '<a href="/$1"><span class="blue">$1</span></a>');
        return html;
    });
});

function goBack() {
    window.history.back();
}