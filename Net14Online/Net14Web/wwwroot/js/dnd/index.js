$(document).ready(function () {

    $('.hero .just-name').click(function () {
        $('.hero').removeClass('full');
        $('.hero').addClass('short');

        const heroBlock = $(this).closest('.hero');
        heroBlock.removeClass('short');
        heroBlock.addClass('full');

        const heroId = heroBlock.attr('data-hero-id');
        $('.update-hero-coins-form')
            .find('[name=heroId]')
            .val(heroId);
        $('.hero-id').text(heroId);
    });

    $('.coin-block .icon').click(function () {
        const hero = $(this)
            .closest('.hero');

        var heroId = hero
            .attr('data-hero-id');

        const url = '/Dnd/CoinPlusOne?heroId=' + heroId;
        $.get(url)
            .then(function (reponse) {
                hero
                    .find('.coins-count')
                    .text(reponse);
            });
    });
});
