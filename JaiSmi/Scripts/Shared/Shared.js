Namespace("sj.enumertion", {
    Enum: function () {
        for (var _i = 0, _len = arguments.length; _i < _len; _i++) {
            this[arguments[_i]] = _i;
        }
        return this;
    }
});

Namespace("sj.util", {
    View: { type: new sj.enumertion.Enum('lg', 'md', 'sm', 'xs') },
    getViewType: function () {
        var width = $(window).innerWidth();
        if (width >= 992) {
            //in md and lg view, the right panel takes up 590px, and the height should be 100%
            return sj.util.View.type.lg;
        }
        else if (width >= 768) {
            //in sm view, the right panel takes up 312px, and the height should be 100%
            return sj.util.View.type.sm;
        }
        else {
            //in xs view, the right panel takes up no width
            return sj.util.View.type.xs;
        }
    },
    setHeaderHeight: function () {
        if (sj.util.getViewType() == sj.util.View.type.xs) {
            $('.header').css('height', $('.content-wrapper').innerHeight());
        }
        else {
            $('.header').css('height', 'inherit');
        }
    }
});

$(document).ready(function () {
    sj.util.setHeaderHeight();
    $(window).on('resize', sj.util.setHeaderHeight);
});