$(document).ready(function () {

    $('.user .name-only, .user .user-name').click(function (event) {
        const userInfo = $(this).closest('.user');

        userInfo.toggleClass('name-only');
        userInfo.toggleClass('full-info');
    })
});

