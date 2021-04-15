$(document).ready(function () {

    $(".hidden-courier-service form button").on('click', (e) => {
        e.preventDefault();
        let selectedInvoiceText;
        var phone = $('.customMPhone').val();


        if ($(".hidden-courier-service-inputs ul li input").eq(0).val().length > 0) {
            $(".hidden-courier-service-inputs ul li .text-danger").eq(0).addClass("d-none")
        } else {
            $(".hidden-courier-service-inputs ul li .text-danger").eq(0).removeClass("d-none")
        }

        for (var i = 2; i < $(".hidden-courier-service-inputs ul li input").length; i++) {
            if ($(".hidden-courier-service-inputs ul li input").eq(i).val().length > 0) {
                $(".hidden-courier-service-inputs ul li .text-danger").eq(i - 1).addClass("d-none")
            } else {
                $(".hidden-courier-service-inputs ul li .text-danger").eq(i - 1).removeClass("d-none")
            }
        }

        if ($(".hidden-courier-service-inputs select").val() != 0) {
            $(".selectValidation").addClass("d-none")
        } else {
            $(".selectValidation").removeClass("d-none")
        }

        let numberOfDangerText = $(".hidden-courier-service-inputs .d-none").length


        if (numberOfDangerText == 5) {

            let courierOrder = {
                AddressOfDelivery: $("input[type='radio']:checked").val(),
                District: $(".hidden-courier-service-inputs ul li").eq(0).children("input").val(),
                Village: $(".hidden-courier-service-inputs ul li").eq(1).children("input").val(),
                Street: $(".hidden-courier-service-inputs ul li").eq(2).children("input").val(),
                House: $(".hidden-courier-service-inputs ul li").eq(3).children("input").val(),
                PhoneNumber: $(".hidden-courier-service-inputs ul li").eq(4).children("input").val(),
                IdOfInvoice: $(".hidden-courier-service-inputs select").val(),
                InvoiceComments: $(".hidden-courier-service-inputs textarea").val()
            }

            selectedInvoiceText = $(".hidden-courier-service-inputs select option:selected").html();

            var phone = $('.courierPhoneAjax').val();
            var customRegPhone = new RegExp(/^((\+\d{1,3}(-| )?\(?\d\)?(-| )?\d{1,5})|(\(?\d{2,6}\)?))(-| )?(\d{3,4})(-| )?(\d{4})(( x| ext)\d{1,5}){0,1}$/);
            if (!customRegPhone.test(phone)) {
                Swal.fire({
                    icon: 'error',
                    text: 'Daxil etdiyiniz telefon nömrəsi standartlara cavab vermir. Nömrənin əvvəlində ölkə indeksin qeyd edin və ya düzgün nömrə daxil etdiyinizə əmin olun.'
                })

            } else {

                $.ajax({
                    url: "/PanelPage/AddCourierDeliveries",
                    dataType: "json",
                    data: courierOrder,

                    success: function (data) {
                        $(".hidden-courier-service-inputs ul li").eq(0).children("input").val("")
                        $(".hidden-courier-service-inputs ul li").eq(1).children("input").val("")
                        $(".hidden-courier-service-inputs ul li").eq(2).children("input").val("")
                        $(".hidden-courier-service-inputs ul li").eq(3).children("input").val("")
                        $(".hidden-courier-service-inputs ul li").eq(4).children("input").val("")
                        $(".hidden-courier-service-inputs select").val(0)
                        $(".hidden-courier-service-inputs textarea").val("")

                        $("#SuccessfullyAdded").modal('show');
                        $("#SuccessfullyAdded .modal-body p").text("Kuryer Sifariş Olundu");


                        var tempVillage;
                        if (data.Village == null) {
                            tempVillage = ""
                        } else {
                            tempVillage = data.Village + ",";
                        }


                        let node = `<div class="hidden-courier-table-row waitingOrders">
                                    <div>
                                        <p>Tam ünvan</p>
                                        <p>${data.District}, ${tempVillage} ${data.Street}, ${data.House}</p>
                                    </div>
                                    <div>
                                        <p>Əlaqə Nömrəsi</p>
                                        <p>${data.PhoneNumber}</p>
                                    </div>
                                    <div>
                                        <p>Sifariş Haqqında</p>
                                        <p>${selectedInvoiceText}</p>
                                    </div>
                                    <div>
                                        <a class="btn btn-success m-1 editCourier"
                                           data-courier-id="${data.id}"
                                           data-courier-district="${data.District}"
                                           data-courier-village="${data.Village}"
                                           data-courier-street="${data.Street}"
                                           data-courier-house="${data.House}"
                                           data-courier-phone="${data.PhoneNumber}"
                                           data-courier-comment="${data.InvoiceComments}"
                                           data-courier-delivery-address="${data.AddressOfDelivery}">Düzəliş et</a>
                                        <a class="btn btn-danger m-1 deleteCourier"
                                           data-product-id="${data.id}"
                                           data-id="${data.id}"
                                           data-controller="PanelPage"
                                           data-action="DeleteCourierOrder"
                                           data-body-message="Bu kuryer sifarişini silməyə əminsinizmi?">Sil</a>
                                    </div>
                                </div>`

                        //$(".hidden-courier-service .hidden-courier-table").append(node);

                        if ($(".waitingOrders").length > 0) {
                            $(node).insertBefore($(".waitingOrders").first());
                        } else {
                            $(node).insertAfter($("#courierWaitingHeaders"));
                        }
                    },

                    error: function (data) {
                        alert("Sistemde xəta baş verdi. Xəta kodu 0x4565")
                    }

                })
            }
        }
    });


});