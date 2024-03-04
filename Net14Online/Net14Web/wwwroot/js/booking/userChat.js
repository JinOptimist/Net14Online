$(document).ready(function () {
    const userNameInput = $('.user-name');
    const messageInput = $('.new-message');
    const messagesContainer = $('.messages');
    const sendMessageButton = $('.send-message-button');

    const hub = new signalR.HubConnectionBuilder()
        .withUrl("https://localhost:7056/chat")
        .build();

    hub.on('newMessage', function (user, message) {
        const newMessage = $('.message.template').clone().removeClass('template');
        newMessage.find('.user-name').text(user);
        newMessage.find('.message-text').text(message);
        messagesContainer.append(newMessage);
    });

    sendMessageButton.click(function () {
        const userName = userNameInput.val();
        const message = messageInput.val();

        if (userName && message) {
            hub.invoke('SendMessage', userName, message);
            messageInput.val(''); // Clear the input field after sending a message
        }
    });

    hub.start();
});