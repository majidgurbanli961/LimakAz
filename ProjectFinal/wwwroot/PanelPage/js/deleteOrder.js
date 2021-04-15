$((function () {
    var url;
    var redirectUrl;
    var target;

    $('body').append(`
            <div class="modal fade" id="deleteModalOrder" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
            <div class="modal-dialog modal-dialog-centered" role="document">
                <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="myModalLabel">Diqqət!</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                </div>
                <div class="modal-body delete-modal-body">
                    
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-primary" data-dismiss="modal" id="cancel-delete">Xeyr</button>
                    <button type="button" class="btn btn-danger" id="confirm-order-delete">Sil</button>
                </div>
                </div>
            </div>
            </div>`);



    //Delete Action
    $(document).on("click", ".deleteOrder", function (e) {
        e.preventDefault();
        target = e.target;
        var Id = $(target).data('id');
        var controller = $(target).data('controller');
        var action = $(target).data('action');
        var bodyMessage = $(target).data('body-message');
        redirectUrl = $(target).data('redirect-url');

        url = "/" + controller + "/" + action + "?Id=" + Id;
        $(".delete-modal-body").text(bodyMessage);
        $("#deleteModalOrder").modal('show');
    });



    $("#confirm-order-delete").on('click', () => {
        $.get(url)
            .done((result) => {
                if (!redirectUrl) {
                    Swal.fire({
                        icon: 'info',
                        text: 'Sifariş məbləği TL balansınıza geri qaytarıldı'
                    })
                    return $(target).parent().parent().parent().hide("slow");
                }
                window.location.href = redirectUrl;
            })
            .fail((error) => {
                if (redirectUrl)
                    window.location.href = redirectUrl;
            }).always(() => {
                $("#deleteModalOrder").modal('hide');
            });
    });

}()));