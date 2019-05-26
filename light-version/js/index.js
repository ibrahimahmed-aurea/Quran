var book;
var currentPageIndex = 1;
$(function () {
    book = config.books[0];
    displayPage(1);
    initSwip();
    init();
});

function init() {
    $(window).resize(function (e) {
        onResize();
    });
    onResize();

    $(document).keydown(function (e) {
        switch (e.which) {
            case 37: // left
                if (currentPageIndex >= book.pagesCount)
                    return;
                displayPage(currentPageIndex + 1);
                break;
            case 38: // up
                break;
            case 39: // right
                if (currentPageIndex <= 1)
                    return;
                displayPage(currentPageIndex - 1);
                break;
            case 40: // down
                break;
            default: return; // exit this handler for other keys
        }
        e.preventDefault(); // prevent the default action (scroll / move caret)
    });

}
function onResize() {
    if ($(document).width() > $(document).height()) {
        $('body').addClass('landscape');
    }
    else {
        $('body').removeClass('landscape');
    }
}
function displayPage(pageIndex) {
    var html = '';
    if (pageIndex > 1)
        html += '<div id="page-' + (pageIndex - 1) + '" class="page"><img src="data/mos7af/' + book.path + '/' + (pageIndex - 1) + book.extension + '" /></div>';
    html += '<div id="page-' + pageIndex + '" class="page"><img src="data/mos7af/' + book.path + '/' + pageIndex + book.extension + '" /></div>';
    if (pageIndex < book.pagesCount - 1)
        html += '<div id="page-' + (pageIndex + 1) + '" class="page"><img src="data/mos7af/' + book.path + '/' + (pageIndex + 1) + book.extension + '" /></div>';
    $('#main').html(html);
    currentPageIndex = pageIndex;
}

//http://labs.rampinteractive.co.uk/touchSwipe/docs/
function initSwip() {
    $(function () {
        $("#test").swipe({
            //Generic swipe handler for all directions
            swipe: function (event, direction, distance, duration, fingerCount, fingerData) {
                $(this).text("You swiped " + direction);
            }
        });

        //Set some options later
        $("#test").swipe({ fingers: 2 });
    });
}