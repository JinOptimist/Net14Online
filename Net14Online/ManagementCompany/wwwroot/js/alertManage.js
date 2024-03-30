$(document).ready(function () {

    $('.remove-alert').click(function () {
        const alert = $(this)
            .closest('.last-alert-block');
        const alertId = alert
            .attr('data-id');
        $.get(`/api/alert/DeleteAlert?alertId=${alertId}`);

        const alertNotice = $(".alerts");
        const alertById = alertNotice.find(`#${alertId}`);
        alert.remove();
        alertById.remove();

        $.get(`/api/alert/DeleteAlert?alertId=${alertId}`);
    });
});
