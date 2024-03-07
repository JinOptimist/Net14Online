

$(document).ready(function () {

    $('.bond-name').click(function () {
        $('.delete-bond').addClass('short');
        $('.price-change-field').addClass('short');

        const bondNameBlock = $(this).closest('.chapter-bond').find('.delete-bond');
        bondNameBlock.removeClass('short');
    });

    $('.bond-price').click(function () {
        $('.price-change-field').addClass('short');
        $('.delete-bond').addClass('short');

        const bondPriceBlock = $(this).closest('.chapter-bond').find('.price-change-field');
        bondPriceBlock.removeClass('short');
    });
});
