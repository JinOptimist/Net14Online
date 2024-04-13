$(document).ready(function () {

    const hub = new signalR.HubConnectionBuilder()
        .withUrl("/hubs/alert")
        .build();

    hub.on('PushAlert', function (alertMessage, alertId) {
        addAlertToPage(alertMessage, alertId);
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
                    addAlertToPage(alert.message, alert.alertId)
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

    function addAlertToPage(message, alertId) {
        const newAlert = $('.alert.template').clone();
        newAlert.removeClass('template');
        newAlert.text(message);
        newAlert.click(onAlertClick);
        newAlert.attr('id', alertId);
        $('.alerts').append(newAlert);
    }

    const onAlertClick = function () {
        const alertId = $(this).attr('id');
        $.get(`/api/alert/MarkAsReaded?alertId=${alertId}`);

        $(this).remove();
    }
});
