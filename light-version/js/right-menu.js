function rightMenu() {
    var self = this;
    var currentPageTitle = '';
    var links = [
        { title: localization.translate('PROFILE'), url: 'profile.html', icon: 'profile.png', active: true },
        { title: localization.translate('FAVOURITE'), url: 'favourites.html', icon: 'favourite.png', active: true },
        { title: localization.translate('MY_ORDERS'), url: '', icon: 'my-orders.png' },
        { title: localization.translate('NOTIFICATIONS'), url: '', icon: 'notifications.png' }
    ];
    var startPoint = { x: 0, y: 0 };
    var endPoint = { x: 0, y: 0 };
    var isSwiping = false;
    var originalX = 0;
    this.isOpen = false;
    this.init = function (title) {
        document.addEventListener('touchstart', function () {
            startPoint.x = event.touches[0].clientX;
            startPoint.y = event.touches[0].clientY;
            self.onTouchStart();
        }, false);
        document.addEventListener('touchend', function () {
            self.onTouchEnd();
        }, false);
        document.addEventListener('touchmove', function (event) {
            endPoint.x = event.touches[0].clientX;
            endPoint.y = event.touches[0].clientY;
            self.onTouchMove();
        }, false);

        $('body').mousedown(function (event) {
            isSwiping = true;
            startPoint.x = event.screenX;
            startPoint.y = event.screenY;
            self.onTouchStart();
        });
        $('body').mouseup(function (event) {
            self.onTouchEnd();
        });
        $('body').mousemove(function (event) {
            if (!isSwiping)
                return;
            endPoint.x = event.screenX;
            endPoint.y = event.screenY;
            self.onTouchMove();
        });
        if (title)
            self.currentPageTitle = title;
        else
            self.currentPageTitle = document.title;
        self.createHtml();
    };
    this.createHtml = function () {
        var html = "<ul id=\"rightMenu\">";
        if (localStorage.getItem('user'))
            html += '<li class="user-name">' + (currentUser ? currentUser.name : '') + '</li>';
        else
            html += '<li class="user-name"><a href="login.html">' + localization.translate('LOGIN') + '<img class="back-img" src="img/icons/arrow.png"/></a></li>';
        for (var i = 0; i < links.length; i++) {
            html += '<li class="side-menu-link">';
            html += '<img src="img/icons/' + links[i].icon + '"/>';
            if (localStorage.getItem('user')) {
                if (links[i].active)
                    html += '<a href = "' + links[i].url + '" > ' + links[i].title + '</a>';
                else
                    html += '<a href = "javascript:notificationsManager.showUnAvailableFeature()" > ' + links[i].title + '</a>';
            }
            else
                html += '<a href = "login.html" > ' + links[i].title + '</a>';
            html += '</li> ';
        }
        if (localStorage.getItem('user'))
            html += '<li class="logout arrow">' + localization.translate('LOGOUT') + '<div class="black-arrow"></div></li>';
        html += "</ul>";
        $('body').append(html);
        self.bindEvents();
    };
    this.bindEvents = function () {
        $('.logout').mousedown(function (event) {
            self.logout();
        });
        $('.side-menu-link').mousedown(function (event) {
            self.hide();
        });
    };
    this.onTouchStart = function () {
        originalX = parseInt($('#rightMenu').css('right').replace('px', ''));
    };
    this.onTouchMove = function () {
        var deltaX = endPoint.x - startPoint.x;
        var deltaY = endPoint.y - startPoint.y;
        if (deltaY > 200)
            return;
        var x = originalX + deltaX * -1;
        x = Math.min(x, 0);
        x = Math.max(x, self.getMenuWidth() * -1);
        $('#rightMenu').css('right', (x) + 'px')
    };
    this.onTouchEnd = function () {
        isSwiping = false;
        if ($('#rightMenu').length == 0 || !$('#rightMenu').css('right'))
            return;
        var x = Math.abs(parseInt($('#rightMenu').css('right').replace('px', '')));
        if (x == 0 || x == self.getMenuWidth())
            return;
        if (x > self.getMenuWidth() / 2)
            self.hide();
        else
            self.show();
    };
    this.getMenuWidth = function () {
        return $('#rightMenu').width() + 70;
    };
    this.show = function () {
        if (currentUser)
            $('.user-name').html(currentUser.name);
        $('#rightMenu').animate({ right: 0 }, 200);
        self.isOpen = true;
    }
    this.hide = function () {
        $('#rightMenu').animate({ right: self.getMenuWidth() * -1 }, 200);
        self.isOpen = false;
    }
    this.logout = function () {
        localStorage.removeItem('user');
        localStorage.removeItem('token');
        currentUser = null;
        location = 'login.html';
    }
};

var menu = new rightMenu();
$(function () {
    menu.init();
});