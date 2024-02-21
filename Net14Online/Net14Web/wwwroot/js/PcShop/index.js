$(document).ready(function () {

    $('.color').click(function () {
        const click = $(this).closest('.color');
        click.toggleClass('color2');
    });

});