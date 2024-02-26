$(document).ready(function () {
    const userName = $('.user-name').val();

    const hub = new signalR.HubConnectionBuilder()
        .withUrl("https://localhost:7280/chat")
        .build();

    // Something happend on server side
    hub.on('ServerGotOneNewMessage', function (user, message) {
        addMessage(user, message);
        //console.log("user: " + user + " message: " + message);
    });

    hub.on('OneMoreUserEnterToChat', function (user) {
        addMessage('', user + ' enter to chat')
    });

    $('.send-message-button').click(function () {
        const message = $('.new-message-text').val();
        // Something happedn on client side
        // Call server
        hub.invoke('SendMessage', userName, message);
    });

    hub.start()
        .then(function () {
            hub.invoke('NewUserEnterToChat', userName);
        });


    function addMessage(user, message) {
        const newMessageBlock = $('.message.template').clone();
        newMessageBlock.removeClass('template');
        newMessageBlock.find('.user-name').text(user);
        newMessageBlock.find('.message-text').text(message);

        $('.messages').append(newMessageBlock);
    }
});
