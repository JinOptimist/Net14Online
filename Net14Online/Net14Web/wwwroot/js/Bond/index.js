

$(document).ready(function () {

    $('.bond-name').click(function () {
        $('.delete-bond').addClass('short');

        const bondBlock = $(this).closest('.chapter-bond').find('.delete-bond');
        bondBlock.removeClass('short');
    });

});
