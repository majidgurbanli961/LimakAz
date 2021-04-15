$((function () {
    var target;

    //edit Action
    $(".editInvoice").on('click', (e) => {
        e.preventDefault();

        target = e.target;

        var Id = $(target).data('id');
        var storeName = $(target).data('store-name');
        var productType = $(target).data('product-type');
        var followCode = $(target).data('follow-code');
        var deliveryOffice = $(target).data('delivery-office');
        var productAmount = $(target).data('product-amount');
        var productComment = $(target).data('product-comment');
        var productPrice = $(target).data('product-price');

        $("#editModalInvoice form .hiddenId").val(Id)
        $("#editModalInvoice form .form-group input").eq(0).val(storeName)
        $("#editModalInvoice form .form-group input").eq(1).val(productType)
        $("#editModalInvoice form .form-group input").eq(2).val(productAmount)
        $("#editModalInvoice form .form-group input").eq(3).val(productPrice)
        $("#editModalInvoice form .form-group input").eq(4).val(followCode)
        $("#editModalInvoice form .form-group select").val(deliveryOffice)
        $("#editModalInvoice form .form-group textarea").val(productComment)


        $("#editModalInvoice .form-group .text-danger").addClass("d-none")

        $("#editModalInvoice").modal('show');
    });

    $("#confirm-edit").click(function (e) {
        for (var i = 0; i < $("#editModalInvoice .text-danger").length; i++) {
            if ($("#editModalInvoice .form-group input").eq(i).val().length > 0) {
                $("#editModalInvoice .form-group .text-danger").eq(i).addClass("d-none")
            } else {
                $("#editModalInvoice .form-group .text-danger").eq(i).removeClass("d-none")
            }
        }

        if ($("#editModalInvoice .form-group .d-none").length == 5) {
            $(this).unbind("click");
        } else {
            e.preventDefault()
        }

    });

}()));