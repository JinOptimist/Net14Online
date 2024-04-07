$(document).ready(function () {

    const hub = new signalR.HubConnectionBuilder()
        .withUrl("/hubs/alert")
        .build();

    hub.on('PushAlert',function (alertMessage){
       const newAlert = $('.alert.template').clone();
       newAlert.removeClass('template');
       newAlert.text(alertMessage);
       newAlert.click(onRemoveAlert);
       $('.alerts').append(newAlert);
    });
     
    hub.start();
    
    init();

    function init(){
        createAlertsBlock();
    };
    function createAlertsBlock() {
        const alerts = $(`
        <div class="alerts">
            <div class="alert template"></div>
        </div>
        `);

        $('body').append(alerts);
    }
    
    $('.alert').click(function () {
       $(this).remove();
   })
    
    const onRemoveAlert = function () {
        $(this).remove();
    }
});
