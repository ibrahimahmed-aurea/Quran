var book;
var currentPageIndex = 1;
$(function () {
    book = config.books[0];
    displayPage(2);
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
var pageWidth = 0, pageHeight;
function onResize() {
    if ($(document).width() > $(document).height()) {
        $('body').addClass('landscape');
    }
    else {
        $('body').removeClass('landscape');
    }
    pageWidth = $('body').width();
    pageHeight = $('body').height();
    $('.page').css('width', pageWidth + 'px');
    $('.page').css('height', pageHeight + 'px');
    $('#pagesContainer').css('width', (pageWidth * $('#pagesContainer .page').length) + 'px');
}
function displayPage(pageIndex) {
    var html = '';
    if (pageIndex > 1)
        html += '<div id="page-' + (pageIndex - 1) + '" class="page"><img draggable="false" src="data/mos7af/' + book.path + '/' + (pageIndex - 1) + book.extension + '" /></div>';
    html += '<div id="page-' + pageIndex + '" class="page"><img draggable="false" src="data/mos7af/' + book.path + '/' + pageIndex + book.extension + '" /></div>';
    if (pageIndex < book.pagesCount - 1)
        html += '<div id="page-' + (pageIndex + 1) + '" class="page"><img  draggable="false" src="data/mos7af/' + book.path + '/' + (pageIndex + 1) + book.extension + '" /></div>';
    $('#pagesContainer').html(html);
    currentPageIndex = pageIndex;
}