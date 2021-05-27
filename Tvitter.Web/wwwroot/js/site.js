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
            result = result.replace(/(@\w+)/g, '<a href="/$1">$1</a>');
            result = result.replace(/="\/@/g, '="/');
            $("#view" + t).html(result);
            makeTagsLink();
        },
        error: function (e) {
            console.log(e);
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
            result = result.replace(/(@\w+)/g, '<a href="/$1">$1</a>');
            result = result.replace(/="\/@/g, '="/');
            $("#view" + t).html(result);
            makeTagsLink();
        }

    });

}

$(document).ready(function () {
    makeTagsLink();
    makeMentionsLink();
});



function makeTagsLink() {
    $("p").html(function (_, html) {
        html = html.replace(/(\#\w+)/g, '<a href="/Tweet/Trend?tag=$1">$1</a>');
        html = html.replace(/=\#/g, '=' + encodeURIComponent('#'));
        return html;
    });
}

function makeMentionsLink() {
    $("p").html(function (_, html) {
        html = html.replace(/(@\w+)/g, '<a href="/$1">$1</a>');
        html = html.replace(/="\/@/g, '="/');
        return html;
    });
}
function goBack() {
    window.history.back();
}