$(document).ready(function () {

    $('.hero .just-name,.hero .hero-name').click(function () {
        const heroBlock = $(this).closest('.hero');
        heroBlock.toggleClass('short');
        heroBlock.toggleClass('full');
    });
  
});