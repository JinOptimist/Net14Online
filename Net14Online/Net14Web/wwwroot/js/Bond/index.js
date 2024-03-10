

$(document).ready(function () {


    $('.bond-name').click(function () {
        const bondBlock = $(this).closest('.chapter-bond').find('.delete-bond');
        bondBlock.toggleClass('short');
    });   
});
