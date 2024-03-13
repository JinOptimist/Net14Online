$(document).ready(() => {
    const hub = new signalR.HubConnectionBuilder()
        .withUrl("https://localhost:7036/commentsMovie")
        .build();

    const addCommentButton = $('.btn-add-comment');


    hub.on('MovieGotNewComment', (comment) => {
        addCommentOnPage(comment.userId, comment.userName, comment.userAvatarUrl, comment.description, comment.timeOfWriting);
    });

    hub.on('LastComments', (lastComments) => {
        lastComments.forEach((comment) => {
            addCommentOnPage(comment.userId, comment.userName, comment.userAvatarUrl, comment.description, comment.timeOfWriting);
        });
    });

    addCommentButton.click(() => {
        const descriptionComment = $('.btn-description-comment');
        if (descriptionComment.val().length) {
            let movieId = $('.movie-id').val();
            let userId = $('.user-id').val();
            let description = $('.btn-description-comment').val();
            let userName = $('.user-name').val();
            let userAvatar = $('user-avatar').val();
            addCommentOnServer(movieId, userId, description, userName, userAvatar);
        }
    });

    hub.start().then(() => {
        let movieId = $('.movie-id').val();
        hub.invoke('GetLastMovieComments', movieId);
        hub.invoke('OpenMovie', movieId);
    });

    const addCommentOnServer = (movieId, userId, description, userName, userAvatar) => {
        hub.invoke('AddNewComment', movieId, userId, userName, userAvatar, description);
    };

    const addCommentOnPage = (userId, userName, userAvatarUrl, commentDescription, commentTimeOfWriting) => {
        const newCommentBlock = $('.comment.comment-template').clone();
        newCommentBlock.removeClass('comment-template');
        newCommentBlock.find('.comment-user-name').text(userName);
        newCommentBlock.find('.user-href-id').attr('href', '/movies/user/' + userId);
        newCommentBlock.find('.user-src-avatarUrl').attr('src', userAvatarUrl);
        newCommentBlock.find('.comment-description').text(commentDescription);
        var timestamp = new Date(commentTimeOfWriting).getTime();
        var datetime = new Date(timestamp);
        newCommentBlock.find('.comment-time-of-writing').text(datetime.toLocaleString());

        $('.comments').prepend(newCommentBlock);
    }
});