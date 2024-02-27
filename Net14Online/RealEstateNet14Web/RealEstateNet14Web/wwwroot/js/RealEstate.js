$(document).ready(function () {

    $('.apartament-block .apartament-block-click').click(function () {
        const apartamentBlock = $(this).closest('.apartament-block');

        apartamentBlock.toggleClass('apartament-block-click');
    })

})

