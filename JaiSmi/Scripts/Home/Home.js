$(document).ready(function () {
    var activityGrid = $('.activity-grid').isotope({
        itemSelector: '.activity-item',
        masonry: {
            gutter: 20
        }
    });

    // layout Isotope after each image loads
    activityGrid.imagesLoaded().progress(function () {
        activityGrid.isotope('layout');
    });

    activityGrid.on('arrangeComplete', function () {
        sj.util.setHeaderHeight();
    });
});