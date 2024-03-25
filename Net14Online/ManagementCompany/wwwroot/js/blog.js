$(document).ready(function () {

    const userName = $(".user-name").val();

    const hub = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:5122/Blog")
        .build();

    hub.on('newComment', function (user, comment) {
        addComment(user, comment);
    });

    hub.on('newUserEnterToChat', function (user) {
        addComment('System', user + ' enter to chat');
    });

    hub.on('LastComments', function (comments) {
        comments.forEach(function (comment) {
            addComment(comment.userName, comment.commentMessage);
        })
    });

    $('.like-container .thumbUp').click(function () {
        const article = $(this)
            .closest('.article')
        var articleId = article
            .attr('data-artile-id');

        const url = '/ManagementCompany/AddLike?articleId=' + articleId;
        $.get(url)
            .then(function (response) {
                article
                    .find('.likeUp-count')
                    .text(response);
            });
    });

    $('.like-container .thumbDown').click(function () {
        const article = $(this)
            .closest('.article')
        var articleId = article
            .attr('data-artile-id');

        const url = '/ManagementCompany/AddDislike?articleId=' + articleId;
        $.get(url)
            .then(function (response) {
                article
                    .find('.likeDown-count')
                    .text(response);
            });
    });

    $('.send-comment').click(function () {
        sendComment();
    });

    $('.comment-text').keydown(function (event) {
        if (event.which == 13) {
            sendComment();
        }
    });

    hub.start()
        .then(function () {
            hub.invoke('UserEnterToChat', userName);
            hub.invoke('GetLastComments');
        });

    function sendComment() {
        const comment = $('.new-comment').val();
        hub.invoke('SendComment', userName, comment);

        $('.new-comment').val('');
    }

    function addComment(user, comment) {
        const newMessageBlock = $('.comment.template').clone();
        newMessageBlock.removeClass('template');
        newMessageBlock.find('.user-name').text(user).css('color', 'red');
        newMessageBlock.find('.comment-text').text(': ' + comment);

        $('.comments').append(newMessageBlock);

        $('.comments').animate({
            scrollTop: 1000
        }, 2000);
    };
});
