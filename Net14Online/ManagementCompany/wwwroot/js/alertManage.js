$(document).ready(function () {

    $('.remove-alert').click(function () {
        const alert = $(this)
            .closest('.last-alert-block');
        const alertId = alert
            .attr('data-id');
        $.get(`/api/alert/DeleteAlert?alertId=${alertId}`);

        const noticeAlert = $(".alerts").find(`#${alertId}`);
        alert.remove();
        noticeAlert.remove();
    });
});
