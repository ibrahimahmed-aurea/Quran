var bookWidth = 0, bookHeight = 0;
$(function () {

    bookWidth = $(window).width() * 0.70;
    bookHeight = $(window).height() * 0.90 - $('.header').height() - 30;
    //$('#flipbook div img').css()
    addBookPages(config.books[1]);
    initTurnJS(config.books[1]);
    setTimeout(function () {
       
    }, 1000);

});
function addBookPages(book) {
    for (var i = 1; i <= book.pagesCount; i++) {
        var html = '<div class="hard quran-page"><img src="data/mos7af/' + book.path + '/' + i + book.extension + '" /></div>';
        $('#flipbook').append(html);
    }
}
function initTurnJS(book) {
    $('#canvas').hide();
    var flipbook = $('#flipbook');

    // Create the flipbook
    flipbook.turn({

        // Magazine width
        width: bookWidth,

        // Magazine height
        height: bookHeight,

        // Duration in millisecond
        duration: 1000,

        // Enables gradients
        gradients: true,

        // Auto center this flipbook
        autoCenter: true,

        // Elevation from the edge of the flipbook when turning a page
        elevation: 50,

        // The number of pages
        pages: book.pagesCount,

        direction: 'rtl',

        // Events
        when: {
            turning: function (event, page, view) {

                var book = $(this),
                    currentPage = book.turn('page'),
                    pages = book.turn('pages');

                // Update the current URI

                Hash.go('page/' + page).update();

                // Show and hide navigation buttons


            },

            turned: function (event, page, view) {


                $(this).turn('center');

                //$('#slider').slider('value', getViewNumber($(this), page));

                if (page == 1) {
                    $(this).turn('peel', 'br');
                }

            },

            missing: function (event, pages) {

                // Add pages that aren't in the magazine

                for (var i = 0; i < pages.length; i++)
                    addPage(pages[i], $(this));

            }
        }

    });

    flipbook.addClass('animated');

    // Show canvas
    $('#canvas').css({ visibility: '' });

    // Load the HTML4 version if there's not CSS transform
    yepnope({
        test: Modernizr.csstransforms,
        yep: ['turnjs4/lib/turn.js'],
        nope: ['turnjs4/lib/turn.html4.min.js'],
        both: ['css/index.css']
    });
}