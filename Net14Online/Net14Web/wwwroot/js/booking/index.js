$(document).ready(function () {

    $('.user').addClass('name-only');
    $('.user .name-only').click(function () {
        $('.user').not($(this).closest('.user'))
            .removeClass('full-info')
            .addClass('name-only');

        $(this).closest('.user')
            .toggleClass('full-info name-only');

  
        const loginId = $(this).closest('.user').attr('data-id'); 
        $('.update-user-email').find('input[name="loginId"]').val(loginId); 
        $('.login-id').text(loginId);
    })
});

