$(document).ready(function () {



    let isVisibleUserNavbar = false;
    $(".nav-top-right p").click(function () {
        if (isVisibleUserNavbar) {
            $(".nav-top-right-hidden-list").fadeOut();
            isVisibleUserNavbar = false;
        } else {
            $(".nav-top-right-hidden-list").fadeIn(function () {
                $(".nav-top-right-hidden-list").css("display", "flex");
            });
            isVisibleUserNavbar = true;

            let modal = document.getElementsByClassName("nav-top-right-hidden-list")[0];
            let modalPtag = document.querySelectorAll(".nav-top-right p")[0]
            window.addEventListener("click", function (event) {
                if (event.target == modal || event.target == modalPtag) {

                } else {
                    $(".nav-top-right-hidden-list").fadeOut();
                    isVisibleUserNavbar = false;
                }
            })
        }
    });


    let isVisibleUserLanguageSelect = false;
    $(".nav-language-option>p").click(function () {
        if (isVisibleUserLanguageSelect) {
            $(".nav-language-option-block").fadeOut();
            isVisibleUserLanguageSelect = false;
        } else {
            $(".nav-language-option-block").fadeIn(function () {
                $(".nav-language-option-block").css("display", "flex");
            });
            isVisibleUserLanguageSelect = true;

            let modallang = document.querySelectorAll(".nav-language-option p")[0];
            let modalPtagLang = document.querySelectorAll(".nav-language-option-block")[0]
            window.addEventListener("click", function (event) {
                if (event.target == modallang || event.target == modalPtagLang) {

                } else {
                    $(".nav-language-option-block").fadeOut();
                    isVisibleUserLanguageSelect = false;
                }
            })
        }
    });




    burgerMenuShowAndHide();

    function burgerMenuShowAndHide() {
        let burgerModal = document.querySelector(".navbar-mobile");


        $(".navbar-toggle-button").click(function () {
            $(".navbar-mobile").fadeIn(500);
            $(".navbar-mobile-container").css("right", "0");
            $("body").css("overflow-y", "hidden");
        });

        $(".close-nav-mobile").click(function () {
            $(".navbar-mobile").fadeOut(500);
            $(".navbar-mobile-container").css("right", "-50%");
            $("body").css("overflow-y", "auto");
        })


        $(window).click(function () {
            if (event.target == burgerModal) {
                $(".navbar-mobile").fadeOut(500);
                $(".navbar-mobile-container").css("right", "-50%");
                $("body").css("overflow-y", "auto");
            }
        });

        $(document).on('keydown', function (e) {
            if (e.keyCode === 27) { // ESC
                $(".navbar-mobile").fadeOut(500);
                $(".navbar-mobile-container").css("right", "-50%");
                $("body").css("overflow-y", "auto");
            }
        });
    }




    $(window).resize(function () {
        if ($(window).width() > 960) {
            $(".navbar-mobile").fadeOut(500);
            $(".navbar-mobile-container").css("right", "-50%");
            $("body").css("overflow-y", "auto");
        }
    });



    $(".nav-language-option-block a").click(function(){
        $(".nav-language-option>p").html($(this).text() + "<i>↓</i>");
    });

});