var garagable = garagable || {};

(function ($) {

    $(document).ready(function () {

        $('.dropdown-menu').find('form').click(function (e) {
            e.stopPropagation();
        });

    });

})(jQuery);