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
            result = result.replace(/(@\w+)/g, '<a href="/$1"><span class="blue">$1</span></a>');
            result = result.replace(/="\/@/g, '="/');
            $("#view" + t).html(result);
            makeLinks(1);

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
            result = result.replace(/(@\w+)/g, '<a href="/$1"><span class="blue">$1</span></a>');
            result = result.replace(/="\/@/g, '="/');
            $("#view" + t).html(result);
            makeLinks(1);
        }

    });

}

$(document).ready(function () {
    makeLinks(0);
});

function makeLinks(i) {
    $("p").html(function (_, html) {
        html = html.replace(/(\#\w+)/g, '<a href="/Tweet/Trend?tag=$1"><span class="blue">$1</span></a>');
        html = html.replace(/=\#/g, '=' + encodeURIComponent('#'));
        if (i === 0) {
            html = html.replace(/(@\w+)/g, '<a href="/$1"><span class="blue">$1</span></a>');
            html = html.replace(/="\/@/g, '="/');
        }
        return html;
    });
}
function goBack() {
    window.history.back();
}