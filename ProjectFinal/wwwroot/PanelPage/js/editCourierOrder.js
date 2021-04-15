$(document).ready(function () {
    var target;


    $(document).on("click", ".editCourier", function (e) {
        e.preventDefault();

        target = e.target;

        var Id = $(target).data('courier-id');
        var courierDistrict = $(target).data('courier-district');
        var courierVillage = $(target).data('courier-village');
        var courierStreet = $(target).data('courier-street');
        var courierHouse = $(target).data('courier-house');
        var courierPhone = $(target).data('courier-phone');
        var courierComment = $(target).data('courier-comment');
        var courierDelivery = $(target).data('courier-delivery-address');

        $("#editModalCourier form .hiddenIdCourier").val(Id)
        $("#editModalCourier form .form-group input").eq(0).val(courierDistrict)
        $("#editModalCourier form .form-group input").eq(1).val(courierVillage)
        $("#editModalCourier form .form-group input").eq(2).val(courierStreet)
        $("#editModalCourier form .form-group input").eq(3).val(courierHouse)
        $("#editModalCourier form .form-group input").eq(4).val(courierPhone)
        $("#editModalCourier form .form-group select").val(courierDelivery)
        $("#editModalCourier form .form-group textarea").val(courierComment)

        $("#editModalCourier form .form-group .text-danger").addClass("d-none")

        $("#editModalCourier").modal('show');
    });


    $("#confirm-edit-courier").click(function (e) {
        e.preventDefault();

        if ($("#editModalCourier .form-group input").eq(0).val().length > 0) {
            $("#editModalCourier .form-group .text-danger").eq(0).addClass("d-none")
        } else {
            $("#editModalCourier .form-group .text-danger").eq(0).removeClass("d-none")
        }

        for (var i = 2; i < $("#editModalCourier .form-group input").length; i++) {
            if ($("#editModalCourier .form-group input").eq(i).val().length > 0) {
                $("#editModalCourier .form-group .text-danger").eq(i - 1).addClass("d-none")
            } else {
                $("#editModalCourier .form-group .text-danger").eq(i - 1).removeClass("d-none")
            }
        }

        let numberOfDangerTextCourier = $("#editModalCourier .form-group .d-none").length

        if (numberOfDangerTextCourier == 4) {

            let editCourier = {
                CourierId: $("#editModalCourier form .hiddenIdCourier").val(),
                AddressOfDelivery: $("#editModalCourier form .form-group select").val(),
                District: $("#editModalCourier form .form-group input").eq(0).val(),
                Village: $("#editModalCourier form .form-group input").eq(1).val(),
                Street: $("#editModalCourier form .form-group input").eq(2).val(),
                House: $("#editModalCourier form .form-group input").eq(3).val(),
                PhoneNumber: $("#editModalCourier form .form-group input").eq(4).val(),
                InvoiceComments: $("#editModalCourier form .form-group textarea").val()
            }


            $.ajax({
                url: "/PanelPage/EditCourierDelivery",
                dataType: "json",
                data: editCourier,

                success: function (data) {
                    $(target).data("courier-district", data.District)
                    $(target).data("courier-village", data.Village)
                    $(target).data("courier-street", data.Street)
                    $(target).data("courier-house", data.House)
                    $(target).data("courier-phone", data.PhoneNumber)
                    $(target).data("courier-comment", data.InvoiceComments)
                    $(target).data("courier-delivery-address", data.AddressOfDelivery)

                    var tempVillage;
                    if (data.Village == null) {
                        tempVillage = ""
                    } else {
                        tempVillage = data.Village + ",";
                    }

                    $(target).parent().siblings().eq(0).children().eq(1).text(`${data.District}, ${tempVillage} ${data.Street}, ${data.House}`)
                    $(target).parent().siblings().eq(1).children().eq(1).text(`${data.PhoneNumber}`)

                    $("#editModalCourier").modal('hide');
                    $("#SuccessfullyAdded").modal('show');
                    $("#SuccessfullyAdded .modal-body p").text("Kuryer Sifarişi Uğurla Dəyişdirildi");
                },

                error: function () {
                    alert("Sistemde xəta baş verdi. Xəta kodu 0x3656")
                }
            });

        }

    });

});