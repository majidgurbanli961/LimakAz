$(document).ready(function () {
    var target;


    $(document).on("click", ".editOrder", function (e) {
        e.preventDefault();

        target = e.target;

        var Id = $(target).data('order-id');
        var orderComment = $(target).data('order-comment');
        var orderDelivery = $(target).data('order-delivery-address');

        $("#editModalOrder form .hiddenIdOrder").val(Id)
        $("#editModalOrder form .form-group select").val(orderDelivery)
        $("#editModalOrder form .form-group textarea").val(orderComment)


        $("#editModalOrder").modal('show');
    });


    $("#confirm-edit-order").click(function (e) {
        e.preventDefault();

        let editLinkOrder = {
            OrderId: $("#editModalOrder form .hiddenIdOrder").val(),
            DeliveryAddress: $("#editModalOrder form .form-group select").val(),
            OrderComment: $("#editModalOrder form .form-group textarea").val()
        }


        $.ajax({
            url: "/PanelPage/EditLinkOrder",
            dataType: "json",
            data: editLinkOrder,

            success: function (data) {
                $(target).data("order-comment", data.OrderComment)
                $(target).data("order-delivery-address", data.DeliveryAddress)


                let tempAddress = "";
                if (data.DeliveryAddress == 1) {
                    tempAddress = "İçərişəhər"
                }
                else if (data.DeliveryAddress == 2) {
                    tempAddress = "Xalqlar Dostluğu"
                }
                else if (data.DeliveryAddress == 3) {
                    tempAddress = "Gəncə"
                }
                else if (data.DeliveryAddress == 4) {
                    tempAddress = "Sumqayıt"
                }
                else if (data.DeliveryAddress == 5) {
                    tempAddress = "Zaqatala"
                }


                $(target).parent().parent().siblings().eq(0).children().first().children().eq(1).text(`${tempAddress}`)
                $(target).parent().parent().siblings().eq(0).children().last().children().eq(1).text(`${data.OrderComment}`)

                $("#editModalOrder").modal('hide');
                $("#SuccessfullyAdded").modal('show');
                $("#SuccessfullyAdded .modal-body p").text("Sifariş Uğurla Dəyişdirildi");
            },

            error: function () {
                alert("Sistemde xəta baş verdi. Xəta kodu 0x36590")
            }
        });



    });

});