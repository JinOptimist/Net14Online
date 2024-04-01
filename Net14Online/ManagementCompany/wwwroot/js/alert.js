$(document).ready(function () {

    const hub = new signalR.HubConnectionBuilder()
        .withUrl("/signalr-hubs/alert")
        .build();

    hub.on('PushAlertAsync', function (message, alertId) {
        addAlertToPage(message, alertId);
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

    function addAlertToPage(message, alertId) {
        const newAlert = $('.alert.template').clone();
        newAlert.removeClass('template');
        newAlert.text(message);
        newAlert.click(onAlertClickRemove);
        newAlert.attr('id', alertId);
        $('.alerts').append(newAlert);
    }

    function createAlertsBlock() {
        const alerts = $(`
        <div class="alerts">
            <div class="alert template"></div>
        </div>
        `);

        $('body').append(alerts);
    }

    const onAlertClickRemove = function () {
        const alertId = $(this).attr('id');
        $.get(`/api/alert/MarkAsRead?alertId=${alertId}`);
        $(this).remove();
    }
});
