$(document).ready(() => {
    const hub = new signalR.HubConnectionBuilder()
        .withUrl("https://localhost:7036/commentsMovie")
        .build();


    hub.on('MovieGotNewComment', (userId, userName, userAvatarUrl, commentDescription, commentTimeOfWriting) => {
        addCommentOnPage(userId, userName, userAvatarUrl, commentDescription, commentTimeOfWriting);
    });

    hub.on('LastComments', (lastComments) => {
        console.log(lastComments);
        lastComments.forEach((comment) => {
            addCommentOnPage(comment.userId, comment.userName, comment.userAvatarUrl, comment.description, comment.timeOfWriting);
        });
    });

    $('.btn-add-comment').click(() => {
        addCommentOnServer();
    });

    hub.start().then(() => {
        let movieId = $('.movie-id').val();
        hub.invoke('GetLastMovieComments', movieId);
    });

    const addCommentOnServer = () => {
        let movieId = $('.movie-id').val();
        let userId = $('.user-id').val();
        let description = $('.description-comment').val();
        hub.invoke('AddNewComment', userId, movieId, description);
    };

    const addCommentOnPage = (userId, userName, userAvatarUrl, commentDescription, commentTimeOfWriting) => {
        const newCommentBlock = $('.comment.comment-template').clone();
        newCommentBlock.removeClass('comment-template');
        newCommentBlock.find('.comment-user-name').text(userName);
        newCommentBlock.find('.user-href-id').attr('href', '/movies/user/' + userId);
        newCommentBlock.find('.user-src-avatarUrl').attr('src', userAvatarUrl);
        newCommentBlock.find('.comment-description').text(commentDescription);
        newCommentBlock.find('comment-time-of-writing').text(commentTimeOfWriting);
        
        $('.comments').append(newCommentBlock);
    }
});