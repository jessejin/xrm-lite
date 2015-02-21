$(document).ready(function () {
    $('[data-toggle="tabajax"]').click(function (e) {
        e.preventDefault()
        var loadurl = $(this).attr('href')
        var targ = $(this).attr('data-target')
        $.get(loadurl, function (data) {
            $(targ).html(data);
        });
        $(this).tab('show');
    });
});

