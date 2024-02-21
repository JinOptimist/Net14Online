$(document).ready(function () {

    $('.task-table.short-table, .task-table.full-table').click(function() {
        const heroBlock = $(this).closest('.task-table');
        heroBlock.toggleClass('short-table');
        heroBlock.toggleClass('full-table');
    });
});
