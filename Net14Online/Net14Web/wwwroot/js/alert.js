$(document).ready(function () {

    const hub = new signalR.HubConnectionBuilder()
        .withUrl("/signlar-hubs/alert")
        .build();

    hub.on('PushAlert', function (alertMessage) {
        addAlertToPage(alertMessage);
    })

    hub.start();

    init();

    function init() {
        createAlertsBlock();
        getExistedAlerts();
    }

    function getExistedAlerts() {
        $.get('/api/alert/GetExistedAlerts')
            .then(function (alerts) {
                alerts.forEach((alert) => {
                    addAlertToPage(alert)
                })
            });
    }

    function createAlertsBlock() {
        const alerts = $(`
        <div class="alerts">
            <div class="alert template"></div>
        </div>
        `);

        $('body').append(alerts);
    }

    function addAlertToPage(message) {
        const newAlert = $('.alert.template').clone();
        newAlert.removeClass('template');
        newAlert.text(message);
        newAlert.click(onAlertClick);
        $('.alerts').append(newAlert);
    }

    const onAlertClick = function () {
        $(this).remove();
    }
});
