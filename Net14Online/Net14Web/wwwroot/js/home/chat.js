$(document).ready(function () {
    const userName = $('.user-name').val();

    const hub = new signalR.HubConnectionBuilder()
        .withUrl("https://localhost:7280/chat", {
            headers: { "authsmile": "123" }
        })
        .build();

    // Something happend on server side
    hub.on('ServerGotOneNewMessage', function (user, message) {
        addMessage(user, message);
        //console.log("user: " + user + " message: " + message);
    });

    hub.on('OneMoreUserEnterToChat', function (user) {
        addMessage('', user + ' enter to chat');
    });

    hub.on('LastMessages', function (messages) {
        messages.forEach(function (message) {
            addMessage(message.userName, message.messageText);
        })
    });

    $('.send-message-button').click(function () {
        sendMessage();
    });
    $('.new-message-text').keyup(function (e) {
        if (e.which == 13) {// On Enter
            sendMessage();
        }
    });

    hub.start()
        .then(function () {
            hub.invoke('NewUserEnterToChat', userName);
            hub.invoke('GetLastMessages');
        });

    function sendMessage() {
        const message = $('.new-message-text').val();
        // Something happedn on client side
        // Call server
        const viewModel = { userName, message };
        hub.invoke('SendMessage', viewModel);
        $('.new-message-text').val('');
    }


    function addMessage(user, message) {
        const newMessageBlock = $('.message.template').clone();
        newMessageBlock.removeClass('template');
        newMessageBlock.find('.user-name').text(user);
        newMessageBlock.find('.message-text').text(message);

        $('.messages').append(newMessageBlock);

        $('.messages').animate({
            scrollTop: 1000 //newMessageBlock.offset().top + newMessageBlock.height()
        }, 2000);
    }
});
