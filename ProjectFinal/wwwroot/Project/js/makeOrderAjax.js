$(document).ready(function () {

    let isAccepted = false;
    let isValidLink = false;

    //======================== SETS IF USER AGREED WITH TERMS OR NOT
    $(".customTestiq").click(function () {
        isAccepted = true;
    });

    $(".customImtina").click(function () {
        isAccepted = false;
    });


    $(".customOdenisEtButton").click(function () {

        let linkOrder = {
            OrderLink: $("#productLink").val(),
            ProductPrice: $("#productTotalPrice").val(),
            ProductAmount: $("#productAmount").val(),
            OrderComment: $("#productComments").val(),
            DeliveryAddress: $("#productDeliveryOffice").val(),
            PaymentMethod: $("input[name='PaymentMethod']:checked").val()
        }


        if (isAccepted) {

            //======================== CHECKS WHETHER INPUT FIELDS ARE EMPTY OR NOT
            if (!$("#productLink").val()) {
                $("#productLinkWarning").removeClass("d-none");
            } else {
                $("#productLinkWarning").addClass("d-none");
            }

            if ($("#productPrice").val() < 1) {
                $("#productPriceWarning").removeClass("d-none");
            } else {
                $("#productPriceWarning").addClass("d-none");
            }

            if ($("#productAmount").val() < 1) {
                $("#productAmountWarning").removeClass("d-none");
            } else {
                $("#productAmountWarning").addClass("d-none");
            }

            let numberOfUserEmptyFields = $(".countryForm .d-none").length;

            if (numberOfUserEmptyFields == 3) {

                //======================== CHECK WHETHER REGEX IS VALID OR NOT
                var expression = /(https?:\/\/(?:www\.|(?!www))[a-zA-Z0-9][a-zA-Z0-9-]+[a-zA-Z0-9]\.[^\s]{2,}|www\.[a-zA-Z0-9][a-zA-Z0-9-]+[a-zA-Z0-9]\.[^\s]{2,}|https?:\/\/(?:www\.|(?!www))[a-zA-Z0-9]+\.[^\s]{2,}|www\.[a-zA-Z0-9]+\.[^\s]{2,})/gi;
                var regex = new RegExp(expression);
                var userEnteredLink = $("#productLink").val();


                if ((userEnteredLink.match(regex) && userEnteredLink.indexOf("http://") == 0) || (userEnteredLink.match(regex) && userEnteredLink.indexOf("https://") == 0)) {
                    isValidLink = true;
                } else {
                    isValidLink = false;
                }

                if (isValidLink) {

                    var amountOfUserMoney = parseFloat($(".customOdenisEtButton").data("tl-balance"))
                    var userInputAmount = parseFloat(linkOrder.ProductPrice)

                    //============================ CHECKS WHETHER USER SELECTED TO PAY WITH CASH OR BY BALANCE
                    if (linkOrder.PaymentMethod == 2) {
                        Swal.fire({
                            icon: 'info',
                            text: 'Kartla Ödəmə xidməti aktiv deyil. Sifarişi ödəmək üçün TL hesabınızdan istifadə edə bilərsiniz.'
                        })
                    } else {
                        //====================================== CHECKS WHETHER USER IS SURE TO PAY BY TL BALANCE
                        $("#confirmPayTL").modal('show');

                        $("#confirm-payment").click(function () { //================= IF AGREED TO PAY FROM TL BALANCE
                            if (amountOfUserMoney >= userInputAmount) {//======================= CHECKS WHETHER USER HAS ENOUGH AMOUNT OF MONEY
                                $("#confirmPayTL").modal('hide');

                                $.ajax({
                                    url: "/MakeOrder/CreateOrder",
                                    dataType: "json",
                                    data: linkOrder,

                                    success: function (result) {


                                        if (result.redirectUrl !== undefined) {


                                            Swal.fire({
                                                icon: "success",
                                                title: "Sifariş uğurla tamamlandı"
                                            }).then(() => {
                                                window.location.replace(result.redirectUrl);
                                            });


                                        } else {
                                            alert("Sistemde xəta baş verdi. Xəta kodu 0x4575. Yeniden cehd edin.")
                                        }
                                    },

                                    error: function () {
                                    }

                                });
                            } else {
                                $("#confirmPayTL").modal('hide');
                                Swal.fire({
                                    icon: 'error',
                                    text: 'Sifariş vermək üçün hesabınızda kifayət qədər məbləğ yoxdur'
                                })
                            }
                        });

                    }
                } else {
                    Swal.fire({
                        icon: 'error',
                        text: 'Daxil etdiyiniz link keçərli deyil'
                    })
                }
            } else {
                Swal.fire({
                    icon: 'error',
                    text: 'Sifariş vermək üçün "*" qoyulmuş xanalar doldurulmalıdır'
                })
            }
        }

    });



});












/* Success: http://www.foufos.gr
Success: https://www.foufos.gr
Success: http://foufos.gr
Success: http://www.foufos.gr/kino
Success: http://werer.gr
Success: www.foufos.gr
Success: www.mp3.com
Success: www.t.co
Success: http://t.co
Success: http://www.t.co
Success: https://www.t.co
Success: www.aa.com
Success: http://aa.com
Success: http://www.aa.com
Success: https://www.aa.com
Fail: www.foufos
Fail: www.foufos-.gr
Fail: www.-foufos.gr
Fail: foufos.gr
Fail: http://www.foufos
Fail: http://foufos
Fail: www.mp3#.com */