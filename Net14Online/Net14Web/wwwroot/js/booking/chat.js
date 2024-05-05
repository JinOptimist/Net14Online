$(document).ready(function () {

    const hub = new signalR.HubConnectionBuilder()
        .withUrl("https://localhost:7056/chat")
        .build();
    const userName = $('.user-name').val();
    hub.on('newMessage', function (user, message) {
        AddMessage(user, message)
    });

    hub.on('userEnteredChat', function (user) {
        AddMessage('', user + ' entered the chat')
    })
    hub.on('LastMessages', function (messages) {
        messages.forEach(function (message) {
            AddMessage(message.userName, message.messageText);
        })
    });

    $('.send-message-button').click(function () {
        SendMessage();
    });

    $('.new-message-text').keyup(function (event) {
        if (event.which == 13) {
            SendMessage();
        }
    });

    hub.start()
        .then(function () {
            hub.invoke('NewUserEntered', userName)
            hub.invoke('GetLastMessages');
        });

    function AddMessage(user, message) {
        const newMessageBlock = $('.message.template').clone();
        newMessageBlock.removeClass('template');
        newMessageBlock.find('.user-name').text(user);
        newMessageBlock.find('.message-text').text(message);

        $('.messages').append(newMessageBlock);
    }
    function SendMessage() {
        const message = $('.new-message-text').val();

        hub.invoke('SendMessage', userName, message);
        $('.new-message-text').val('');
    }
 });

