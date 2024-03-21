$(document).ready(function () {

    $('.method-name').click(function () {
        $(this)
            .closest('.method')
            .find('.parameters')
            .toggle(500);
    });

});
