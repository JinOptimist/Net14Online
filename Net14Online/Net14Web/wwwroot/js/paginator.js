$(document).ready(function () {
    $('.page').click(function onPageClick() {
        const page = $(this).data('page');
        navigateToPage(page);
    });

    $('.perPage').change(function () {
        navigateToPage(1);
    });

    function navigateToPage(page) {
        const perPage = $('.perPage').val();
        const baseUrl = location.protocol + '//' + location.host + location.pathname;
        window.location.href = `${baseUrl}?page=${page}&perPage=${perPage}`;
    }
});