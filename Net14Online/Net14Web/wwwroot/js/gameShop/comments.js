
$(document).ready(function () {
    const url = "https://localhost:7192/comments";
    const userName = "Guest"

    const hub = new signalR.HubConnectionBuilder()
        .withUrl(url)
        .build();

    hub.on("RetriveNewComment", function (userName, comment) {
        addComment(userName, comment);
    })

    hub.on("LastComments", function (comments) {
        comments.forEach(function (comments) {
            addComment(comments.UserName, comments.Text)
        })
    })

    $('.send-comment-button').click(function () {
        sendComment();
    });
    $('.new-comment-text').keyup(function (e) {
        if (e.which == 13) {// On Enter
            sendComment();
        }
    });

    hub.start()
        .then(function () {
            hub.invoke('GetLastComments');
        });

    function sendComment() {
        const comment = $('.new-comment-text').val();
        // Something happedn on client side
        // Call server
        hub.invoke('AddComment', userName, comment);
        $('.new-comment-text').val('');
    }

    function addComment(user, comment) {
        const newCommentBlock = $('.comment.template').clone();
        newCommentBlock.removeClass('template');
        newCommentBlock.find('.user-name').text(user);
        newCommentBlock.find('.comment-text').text(comment);

        $('.comments').append(newCommentBlock);

        $('.comments').animate({
            scrollTop: 1000
        }, 2000);
    }
})
