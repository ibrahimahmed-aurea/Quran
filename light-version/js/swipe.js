var startPoint = { x: 0, y: 0 };
var endPoint = { x: 0, y: 0 };
var isSwiping = false;
var originalX = 0;
function initSwip() {
    $('body').mousedown(function (event) {
        isSwiping = true;
        startPoint.x = event.screenX;
        startPoint.y = event.screenY;
        onTouchStart();
    });
    $('body').mouseup(function (event) {
        onTouchEnd();
    });
    $('body').mousemove(function (event) {
        if (!isSwiping)
            return;
        endPoint.x = event.screenX;
        endPoint.y = event.screenY;
        onTouchMove();
    });
}

function onTouchStart() {
    originalX = $(document).scrollLeft();
}
function onTouchMove() {
    var deltaX = endPoint.x - startPoint.x;
    var deltaY = endPoint.y - startPoint.y;
    if (deltaY > 200 || deltaX == 0)
        return;
    var x = originalX + deltaX * -1;
    $(document).scrollLeft(x);
}
function onTouchEnd() {
    isSwiping = false;
    var deltaX = endPoint.x - startPoint.x;
    if (deltaX > 100)
        originalX -= $('body').width();
    else if (deltaX < -100)
        originalX += $('body').width();
    $('html, body').animate({ scrollLeft: originalX }, 200);
}