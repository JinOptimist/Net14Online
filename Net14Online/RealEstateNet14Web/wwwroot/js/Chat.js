$(document).ready(function () {
    const userName = $('.user-name').val();
    
    const hub = new signalR.HubConnectionBuilder()
        .withUrl("https://localhost:7260/chat")
        .build();

    hub.on('newMassage',function (user,message){
        const newMessageBlock = $('.message.template').clone();
        newMessageBlock.find('.user-name').text(user);
        newMessageBlock.find('.message-text').text(message);

        $('.messages').append(newMessageBlock);
       // console.log("user  " + userName + "message" + masagge)
    });
    
    $('.send-message-button').click(function ()
    {
        const massage = $('.new-message-text').val();
        
        hub.invoke('SendMassage',userName,massage);
    });
    
    hub.start();
});
