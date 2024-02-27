$(document).ready(function () {

    $('.game, .game-clicked').click(function () {
        const gameBlock = $(this).closest('.game');

        //gameBlock.toggleClass('game');
        gameBlock.toggleClass('game-clicked');
    })

})