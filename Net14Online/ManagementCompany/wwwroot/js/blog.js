$(document).ready(function () {

    const userName = $(".user-name").val();

    const hub = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:5122/Blog")
        .build();

    hub.on('newComment', function (user, comment) {
        addMessage(user, comment);
        //console.log("user: " + user + " comment: " + comment);
    });

    hub.on('newUserEnterToChat', function (user) {
        addMessage('System', user + ' enter to chat');
    });

    $('.send-comment').click(function () {
        const comment = $('.new-comment').val();

        hub.invoke('SendComment', userName, comment);
    });

    hub.start()
        .then(function () {
            hub.invoke('UserEnterToChat', userName);
        });

    function addMessage(user, comment) {
        const newMessageBlock = $('.comment.template').clone();
        newMessageBlock.removeClass('template');
        newMessageBlock.find('.user-name').text(user).css('color', 'red');
        newMessageBlock.find('.comment-text').text(': ' + comment);

        $('.comments').append(newMessageBlock);
    };
});
