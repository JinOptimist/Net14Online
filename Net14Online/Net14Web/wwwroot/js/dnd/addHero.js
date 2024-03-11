$(document).ready(function () {

    $('#Name').keyup(function () {
        const newName = $('#Name').val();
        $('.preview .hero-name').text(newName);
    });

    $('#Coin').keyup(function () {
        const coin = $('#Coin').val();
        $('.preview .coins-count').text(coin);
    });

    $('[name=Race]').change(function () {
        //const race = $('[name=Race]').val();
        const race = $("[name=Race] option:selected").text();
        $('.preview .race').text(race);
    });
   
});
