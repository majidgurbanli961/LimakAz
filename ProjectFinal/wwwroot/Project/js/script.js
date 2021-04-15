// country
$(document).ready(function () {
    // let modalArray = $('#login_modal').toArray();
    // $(window).click(function (event) {
    //   if (event.target == modalArray[0]) {
    //     $('#login_modal').addClass('d-none');
    //     $("body").css("overflow-y", "auto");
    //     console.log("click")
    //   }
    // });

    $(document).on('click', '.customBtnEnter', function () {


        $('#login_modal').fadeIn();

        $('body').css('overflow', 'hidden');

    })
    $('.main-slider').owlCarousel({
        loop: true,
        margin: 0,
        nav: false,
        dots: true,

        responsive: {
            0: {
                items: 1,
                margin: 60

            },
            600: {
                items: 1,
            },

            1000: {
                items: 1
            }
        }
    })

    $('.country-accordion li').on('click', function () {

        $('.country-accordion li').each((index, element) => {
            $(element).removeClass('active');
        });
        $(this).addClass('active');

        $('.accordion-body ').each((index, element) => {
            $(element).hide();
        })
        $('.accordion-body').eq($(this).index()).removeClass('d-none');
        $('.accordion-body').eq($(this).index()).show();

    })

    // end
    // Logo Slider Owl
    $('.footer-slider').owlCarousel({
        loop: true,
        margin: 40,
        nav: false,
        dots: false,
        autoplay: true,
        autoplayTimeout: 3000,
        autoplayHoverPause: true,
        smartSpeed: 10000,
        responsive: {
            0: {
                items: 2,
                margin: 60

            },
            600: {
                items: 3,
            },

            1000: {
                items: 5
            }
        }
    })
    $('.play').on('click', function () {
        owl.trigger('play.owl.autoplay', [1000])
    })
    $('.stop').on('click', function () {
        owl.trigger('stop.owl.autoplay')
    })

    $(document).on('click', '.burger', function () {
        $(".content-mobile").toggleClass('d-none')
        $("body").css('overflow', 'hidden')




    })





    $('.close-menu').on('click', function () {

        $('.content-mobile').toggleClass('d-none');
        $("body").css('overflow', 'auto')


    })

    // 
    $(document).on('click', '.clickedDropdown', function () {
        var dropdowns = $('.clickedDropdown').toArray();

        for (var i = 0; i < dropdowns.length; i++) {
            $(dropdowns[i]).removeClass('redSelected');
        }
        $(this).addClass('redSelected');


        $(this).parent().parent().prev().html($(this).html());

    });

    // login Modal


    $(document).on('click', '.hesablaButton', function () {
        var recentResult;
        var country = $(".countryButton").html();
        country = country.replace(/\s/g, '')

        var kqText = $('.kqcustomMain').html();
        kqText = kqText.replace(/\s/g, '');
        console.log(kqText);
        var amount = $('.customAmount').val();
        var kqValue = $('.CustomCekiInput').val();


        if (country == 'Türkiyə') {
            if (kqText == 'qram') {


                if (kqValue > 0 && kqValue <= 250) {
                    recentResult = 2;
                } else if (kqValue > 250 && kqValue <= 500) {
                    recentResult = 3;
                } else if (kqValue > 500 && kqValue <= 700) {
                    recentResult = 4;
                } else if (kqValue > 700 && kqValue <= 999) {
                    recentResult = 4.5;
                } else {
                    console.log(kqValue / 1000)
                    recentResult = (kqValue / 1000) * 4.5;
                }
                console.log(recentResult * amount)
                recentResult = recentResult * amount
            } else {
                recentResult = kqValue * 4.5;
                recentResult = recentResult * amount

            }
        } else if (country == 'Amerike') {
            if (kqText == 'qram') {


                if (kqValue > 0 && kqValue <= 250) {
                    recentResult = 1.99;
                } else if (kqValue > 250 && kqValue <= 500) {
                    recentResult = 3.99;
                } else if (kqValue > 500 && kqValue <= 700) {
                    recentResult = 4.99;
                } else if (kqValue > 700 && kqValue <= 999) {
                    recentResult = 5.99;
                } else {
                    console.log(kqValue / 1000)
                    recentResult = (kqValue / 1000) * 5.99;
                }

                recentResult = recentResult * amount
                console.log(recentResult)
            } else {
                recentResult = kqValue * 5.99;
                recentResult = recentResult * amount
                console.log(recentResult)

            }
        }
        $('.finalAmount').html(recentResult);




    });
})

