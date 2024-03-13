$(document).ready(function () {
    const userName = $('.user-name').val();
    
    const hub = new signalR.HubConnectionBuilder()
        .withUrl("https://localhost:7257/chat")
        .build();

    hub.on('ServerGotOneNewMessage',function (user,message){
        const newMessageBlock = $('.message.template').clone();
        newMessageBlock.removeClass('template');
        newMessageBlock.find('.user-name').text(user);
        newMessageBlock.find('.message-text').text(message);

        $('.messages').append(newMessageBlock);
       // console.log("user  " + user + "message" + message)
    });
    
    $('.send-message-button').click(function ()
    {
        const massage = $('.new-message-text').val();
        
        hub.invoke('SendMassage',userName,massage);
    });
    
    hub.start();
});
