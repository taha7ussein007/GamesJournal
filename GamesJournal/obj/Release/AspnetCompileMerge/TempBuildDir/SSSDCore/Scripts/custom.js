//bookmark (add to favourite) button functionality
$(document).ready(function () {
    $('#bookmark-this').click(function (e) {
        var bookmarkURL = window.location.href;
        var bookmarkTitle = document.title;

        if ('addToHomescreen' in window && window.addToHomescreen.isCompatible) {
            // Mobile browsers
            addToHomescreen({ autostart: false, startDelay: 0 }).show(true);
        } else if (window.sidebar && window.sidebar.addPanel) {
            // Firefox version < 23
            window.sidebar.addPanel(bookmarkTitle, bookmarkURL, '');
        } else if ((window.sidebar && /Firefox/i.test(navigator.userAgent)) || (window.opera && window.print)) {
            // Firefox version >= 23 and Opera Hotlist
            $(this).attr({
                href: bookmarkURL,
                title: bookmarkTitle,
                rel: 'sidebar'
            }).off(e);
            return true;
        } else if (window.external && ('AddFavorite' in window.external)) {
            // IE Favorite
            window.external.AddFavorite(bookmarkURL, bookmarkTitle);
        } else {
            // Other browsers (mainly WebKit - Chrome/Safari)
            alert('Press ' + (/Mac/i.test(navigator.userAgent) ? 'Cmd' : 'Ctrl') + '+D to bookmark this page.');
        }

        return false;
    });
});
//auto hide intro banner
$(document).ready(function () {
    var scroll_start = 0;
    var myIntro = $('#myIntro');
    var offset = 1;
    if (myIntro.length) {
        $(document).scroll(function () {
            scroll_start = $(this).scrollTop();
            if (scroll_start > offset) {
                $(".navbar-fixed-top").css('top', '0');
            } else {
                $('.navbar-fixed-top').css('top', '40px');
            }
        });
    }
});
//get iframe content height
function getDocHeight(doc) {
    doc = doc || document;
    // stackoverflow.com/questions/1145850/
    var body = doc.body, html = doc.documentElement;
    var height = Math.max(body.scrollHeight, body.offsetHeight,
        html.clientHeight, html.scrollHeight, html.offsetHeight);
    return height;
}
//set iframe height relative to it's content
function setIframeHeight(id) {
    var ifrm = document.getElementById(id);
    var doc = ifrm.contentDocument ? ifrm.contentDocument :
        ifrm.contentWindow.document;
    ifrm.style.height = "0px"; // reset to default height ...
    // IE opt. for bing/msn needs a bit added or scrollbar appears
    ifrm.style.height = getDocHeight(doc) + 0 + "px";
}
//set initial iframe slider size
$("#GJSliderIframe").load(function () {
    var id = $('#GJSliderIframe').attr('id');
    if (id)
        setIframeHeight(id);
});
//auto resize iframe slider
$(window).resize(function () {
    var id = $('#GJSliderIframe').attr('id');
    if (id)
        setIframeHeight(id);
});
