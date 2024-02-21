$(document).ready(function () {
    const onlineStatus = $('.user-online-status');
    onlineStatus.click(function () {
        onlineStatus.toggleClass('status-online');
        onlineStatus.toggleClass('status-offline');
        onlineStatus.text(onlineStatus.text() === 'Offline' ? 'Online' : 'Offline');
    });
});