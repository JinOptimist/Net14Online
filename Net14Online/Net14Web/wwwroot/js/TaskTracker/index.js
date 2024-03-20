$(document).ready(function () {

    $('.photo-grid__card').click(function () {
        $('.photo-grid__card').removeClass('photo-grid__card_highlight')
        const card = $(this).closest('.photo-grid__card');
        card.toggleClass('photo-grid__card_highlight');
    });
});
