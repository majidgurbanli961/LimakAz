$(document).ready(function () {

    var id;
    $(document).on('click', '.elaqeNavContent', function () {
        var contents = $('.elaqeNavContent').toArray();
        for (var i = 0; i < contents.length; i++) {
            $(contents[i]).removeClass('elaqeNavContentActive')
        }
        id = $(this).attr('id');
        console.log(id);
        $(this).addClass('elaqeNavContentActive');
        var bigContents = $('.tabPanel').toArray();
        for (var i = 0; i < bigContents.length; i++) {
            $(bigContents[i]).hide();
        }
        id = id[0] + '1' + id[1];
        console.log(id);
        $('#' + id).fadeIn(800);
    })
})