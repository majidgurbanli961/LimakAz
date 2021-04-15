$(document).ready(function () {


    //================== HANDLES THE MAIN NAVBAR CLICKS
    $(".main-panel-navbar ul li a ").click(function () {

        // =========================================================== CHANGE THE BORDER AND COLOR TO THE RED 
        // ======================= MAKES ALREADY SELECTED NAV TO ORDINARY
        $(".main-panel-navbar ul li a ").css({
            "border-left": "5px solid transparent",
            "color": "#808080"
        });
        // ======================= KEEPS THE FIRST ALWAYS SELECTED
        $(".main-panel-navbar ul li a ").first().css("color", "#f95732");
        $(".main-panel-navbar ul li a ").first().css("border-left", "5px solid #f95732");
        // ======================= MAKES NAV SELECTED
        $(this).css({
            "border-left": "5px solid #f95732",
            "color": "#f95732"
        });

        //// =========================================================== CHANGE THE IMAGE TO ORDINARY CONDITION


        //// =========================================================== CHANGE THE IMAGE TO RED



        // ========================================== CHANGES THE CONTENT RESPECT TO CLICKED NAVBAR
        let indexOfClicked = $(".main-panel-navbar ul li a ").index(this);
        ChangeDisplayedContent(indexOfClicked);

        let imagesNav = $(".main-panel-navbar ul li a img");
        for (var i = 1; i < imagesNav.length; i++) {
            let sourceString = imagesNav.eq(i).attr("src");
            if (sourceString.includes("-1")) {
                let LastString = sourceString.substr(0, sourceString.indexOf('-1'));
                LastString = LastString + ".png";
                imagesNav.eq(i).attr("src", LastString)
            }
        }

        let sourceToBeChanged = $(".main-panel-navbar ul li a img").eq(indexOfClicked).attr("src");
        let imgName = sourceToBeChanged.substring(0, sourceToBeChanged.indexOf('.'));
        let newName = imgName + "-1.png";
        $(".main-panel-navbar ul li a img").eq(indexOfClicked).attr("src", newName)
        //console.log(newName)

    });




    // ============================== HANDLES THE TOP RIGHT USER NAVBAR CLICKS
    $(".nav-top-right-hidden-list a").click(function () {
        // ========================================== CHANGES THE CONTENT RESPECT TO CLICKED NAVBAR
        let indexOfClicked = $(".nav-top-right-hidden-list a").index(this);
        ChangeDisplayedContent(indexOfClicked);
    });




    ChangeCalculatorCurrencyPosition();
    ChangeHeightOfAdressBlock();
    ChangeHeightOfSettingsBlock();
    ChangeHeightOfPackagesBlock();
    EventHandlerForCalculatorInputs();
    EventHandlerForCourierInputs();
    EventHandlerForSettingsInputs();
    ChangeInnerHtmlOfSettingsNavbar();
    $(window).resize(function () {
        ChangeCalculatorCurrencyPosition();
        ChangeHeightOfAdressBlock();
        ChangeHeightOfSettingsBlock();
        ChangeHeightOfPackagesBlock();
        ChangeInnerHtmlOfSettingsNavbar();
    });




    // ========================================== CHANGES THE CONTENT RESPECT TO CLICKED NAVBAR
    function ChangeDisplayedContent(indexOfClicked) {
        switch (indexOfClicked) {
            case 0:
                $(".navbar-hidden-content").css("display", "none");
                $(".navbar-hidden-content").eq(0).css("display", "block");
                break;
            case 1:
                $(".navbar-hidden-content").css("display", "none");
                $(".navbar-hidden-content").eq(1).css("display", "block");
                break;
            case 2:
                $(".navbar-hidden-content").css("display", "none");
                $(".navbar-hidden-content").eq(2).css("display", "block");
                break;
            case 3:
                $(".navbar-hidden-content").css("display", "none");
                $(".navbar-hidden-content").eq(3).css("display", "block");
                break;
            case 4:
                $(".navbar-hidden-content").css("display", "none");
                $(".navbar-hidden-content").eq(4).css("display", "block");
                break;
            case 5:
                $(".navbar-hidden-content").css("display", "none");
                $(".navbar-hidden-content").eq(5).css("display", "block");
                break;
            case 6:
                $(".navbar-hidden-content").css("display", "none");
                $(".navbar-hidden-content").eq(6).css("display", "block");
                break;
            case 7:
                $(".navbar-hidden-content").css("display", "none");
                $(".navbar-hidden-content").eq(7).css("display", "block");
                break;
            case 8:
                $(".navbar-hidden-content").css("display", "none");
                $(".navbar-hidden-content").eq(8).css("display", "block");
                break;
        }
        ChangeHeightOfAdressBlock();
        ChangeHeightOfSettingsBlock();
        ChangeHeightOfPackagesBlock();
    }




    //================================================================ SHOWS UP "AZN BALANSIM" SECTION WHEN CLICK BALANSI ARTIR BUTTON ON PANEL SEHIFES
    $(".hidden-panel-page-top-balance > div:last-child button").click(function () {
        $(".navbar-hidden-content").css("display", "none");
        $(".navbar-hidden-content").eq(4).css("display", "block");
        $(".main-panel-navbar ul li:nth-child(5) a").css({
            "color": "#f95732",
            "border-left": "5px solid #f95732"
        });
        $(".main-panel-navbar ul li:nth-child(5) a img").attr("src", "/PanelPage/images/coin-1.png")
    });




    // ==================================================== FUNCTION THAT TAKES CALCULATOR AND CURRENCY AND CHANGES POSITION DEPENDS ON SCREEN WIDTH
    function ChangeCalculatorCurrencyPosition() {
        if ($(window).width() < 960) {

            let calculator = document.querySelectorAll(".main-panel-calculator")[0];
            let currency = document.querySelectorAll(".main-panel-currency")[0];
            let parentElement = document.querySelectorAll(".hidden-panel-page")[0];

            calculator.classList.add("visibleCalculatorCurrency");
            currency.classList.add("visibleCalculatorCurrency");

            // ===================== SETS THE WIDTH OF INPUT FOR MOBILE VERSION
            for (let index = 0; index < document.querySelectorAll(".visibleCalculatorCurrency input").length; index++) {
                document.querySelectorAll(".visibleCalculatorCurrency input")[index].style.width = "calc(100% - 100px)";
            }

            parentElement.insertBefore(calculator, parentElement.children[1]);
            parentElement.insertBefore(currency, parentElement.children[2]);

        } else {

            let calculator = document.querySelectorAll(".main-panel-calculator")[0];
            let currency = document.querySelectorAll(".main-panel-currency")[0];
            let aside = document.querySelectorAll(".main-panel-aside")[0]

            calculator.classList.remove("visibleCalculatorCurrency");
            currency.classList.remove("visibleCalculatorCurrency");

            aside.appendChild(calculator);
            aside.appendChild(currency);
        }
    }



    // ============================================ CHANGE CONTENT OF COUNTRY RESPECT TO COUNTRIES NAVBAR IN SECTION "XARICDEKI UNVANLARIM" 
    let prevClicked = 0;
    $(".hidden-addresses-navigation-header-block").click(function () {
        // ====================== IF THE SAME COUNTRY IS CLICKED IT WILL DO NOTHING, ELSE IT WILL CHANGE COUNTRY CONTENT
        let indexOfClicked = $(".hidden-addresses-navigation-header-block").index(this);
        if (prevClicked != indexOfClicked) {
            // ================================ CONTENT HIDE SHOW MANUPILATION
            $(".hidden-addresses-detailed-info-block").fadeOut();
            $(".hidden-addresses-detailed-info-block").eq(indexOfClicked).fadeIn(function () {
                $(".hidden-addresses-detailed-info-block").eq(indexOfClicked).css("display", "flex");
                ChangeHeightOfAdressBlock();
            });

            // ================================ BORDER COLORS MANUPILATION
            $(".hidden-addresses-navigation-header-block").css("border-top-color", "transparent");
            $(".hidden-addresses-navigation-header-block").css("cursor", "pointer");
            $(this).css({
                "border-top-color": "#f95732",
                "cursor": "default"
            });
            if (indexOfClicked == 0) {
                $(".hidden-addresses-navigation-header-block").eq(0).css("border-bottom-color", "transparent");
                $(".hidden-addresses-navigation-header-block").eq(1).css({
                    "border-bottom-color": "#dddddd",
                    "border-right-color": "transparent"
                });
            } else if (indexOfClicked == 1) {
                $(".hidden-addresses-navigation-header-block").eq(0).css("border-bottom-color", "#dddddd");
                $(".hidden-addresses-navigation-header-block").eq(1).css({
                    "border-bottom-color": "transparent",
                    "border-right-color": "#dddddd"
                });
            }
            prevClicked = indexOfClicked;
        }
    });



    /**
     * FUNCTION THAT SETS HEIGHT OF ".hidden-addresses-detailed-info" CLASS DIV
     * DEPENDING ON SCREEN WIDTH AND CLICKED CATEGORY
     */
    function ChangeHeightOfAdressBlock() {
        let HeightOfAdressBlock = 0;
        if ($(".hidden-addresses-detailed-info-block").eq(0).css("display") == "flex") {
            HeightOfAdressBlock = $(".hidden-addresses-detailed-info-block:nth-child(1)").outerHeight();
        }
        if ($(".hidden-addresses-detailed-info-block").eq(1).css("display") == "flex") {
            HeightOfAdressBlock = $(".hidden-addresses-detailed-info-block:nth-child(2)").outerHeight();
        }
        $(".hidden-addresses-detailed-info").height(HeightOfAdressBlock)
    }



    // ============================================ CHANGES SETTINGS NAVBAR INNERHTML (TEXT -> IMAGE and reverse) RESPECT TO WINDOW WIDTH
    function ChangeInnerHtmlOfSettingsNavbar() {
        if ($(window).width() < 550) {
            $(".hidden-user-settings-nav-headers a").eq(0).html("<img src='../../PanelPage/images/user.png' alt='User Image!'>");
            $(".hidden-user-settings-nav-headers a").eq(1).html("<img src='../../PanelPage/images/padlock.png' alt='Padlock Image!'>");
            $(".hidden-user-settings-nav-headers a").eq(2).html("<img src='../../PanelPage/images/biometric.png' alt='Biometric Image!'>");
        } else {
            $(".hidden-user-settings-nav-headers a").eq(0).html("Profil məlumatları");
            $(".hidden-user-settings-nav-headers a").eq(1).html("Şifrə");
            $(".hidden-user-settings-nav-headers a").eq(2).html("Ş/V məlumatları");
        }
    }



    // ============================================ CHANGE CONTENT OF SETTINGS RESPECT TO SETTINGS NAVBAR IN SECTION "XARICDEKI UNVANLARIM" 
    let prevClickedSettings = 0;
    $(".hidden-user-settings-nav-headers a").click(function () {
        // ====================== IF THE SAME SETTING IS CLICKED IT WILL DO NOTHING, ELSE IT WILL CHANGE SETTINGS CONTENT
        let indexOfClicked = $(".hidden-user-settings-nav-headers a").index(this);
        if (prevClickedSettings != indexOfClicked) {
            // ================================ CONTENT HIDE SHOW MANUPILATION
            $(".hidden-user-settings-content-blocks form").fadeOut();
            if (indexOfClicked != 1) {
                $(".hidden-user-settings-content-blocks form").eq(indexOfClicked).fadeIn(function () {
                    $(".hidden-user-settings-content-blocks form").eq(indexOfClicked).css("display", "flex");
                    ChangeHeightOfSettingsBlock();
                });
            } else {
                $(".hidden-user-settings-content-blocks form").eq(indexOfClicked).fadeIn(function () {
                    ChangeHeightOfSettingsBlock();
                });
            }


            // ================================ BORDER COLORS MANUPILATION
            $(".hidden-user-settings-nav-headers a").css("border-top-color", "transparent");
            $(".hidden-user-settings-nav-headers a").css("cursor", "pointer");
            $(this).css({
                "border-top-color": "#f95732",
                "cursor": "default"
            });
            if (indexOfClicked == 0) {
                $(".hidden-user-settings-nav-headers a").eq(0).css("border-bottom-color", "transparent");
                $(".hidden-user-settings-nav-headers a").eq(1).css({
                    "border-bottom-color": "#dddddd",
                    "border-right-color": "transparent",
                    "border-left-color": "#dddddd"
                });
                $(".hidden-user-settings-nav-headers a").eq(2).css({
                    "border-bottom-color": "#dddddd",
                    "border-right-color": "transparent",
                    "border-left-color": "transparent"
                });
            } else if (indexOfClicked == 1) {
                $(".hidden-user-settings-nav-headers a").eq(0).css("border-bottom-color", "#dddddd");
                $(".hidden-user-settings-nav-headers a").eq(1).css({
                    "border-bottom-color": "transparent",
                    "border-right-color": "transparent",
                    "border-left-color": "#dddddd"
                });
                $(".hidden-user-settings-nav-headers a").eq(2).css({
                    "border-left-color": "#dddddd",
                    "border-bottom-color": "#dddddd",
                    "border-right-color": "transparent"
                });
            } else if (indexOfClicked == 2) {
                $(".hidden-user-settings-nav-headers a").eq(0).css("border-bottom-color", "#dddddd");
                $(".hidden-user-settings-nav-headers a").eq(1).css({
                    "border-bottom-color": "#dddddd",
                    "border-right-color": "transparent",
                    "border-left-color": "transparent"
                });
                $(".hidden-user-settings-nav-headers a").eq(2).css({
                    "border-bottom-color": "transparent",
                    "border-right-color": "#dddddd",
                    "border-left-color": "#dddddd"
                });
            }
            prevClickedSettings = indexOfClicked;
        }
    });



    // ======================================== CHANGES HEIGHT OF SETTINGS BLOCKS
    function ChangeHeightOfSettingsBlock() {
        let HeightOfSettingsBlock = 0;
        if ($(".hidden-user-settings-content-blocks form").eq(0).css("display") == "flex") {
            HeightOfSettingsBlock = $(".hidden-user-settings-content-blocks form:nth-child(1)").outerHeight();
        }
        if ($(".hidden-user-settings-content-blocks form").eq(1).css("display") == "block") {
            HeightOfSettingsBlock = $(".hidden-user-settings-content-blocks form:nth-child(2)").outerHeight();
        }
        if ($(".hidden-user-settings-content-blocks form").eq(2).css("display") == "flex") {
            HeightOfSettingsBlock = $(".hidden-user-settings-content-blocks form:nth-child(3)").outerHeight();
        }
        $(".hidden-user-settings-content-blocks").height(HeightOfSettingsBlock)
    }



    // ================================================= EVENT HANDLERS ON INPUT PLACEHOLDERS("span, label")
    // =========================================================== EVENT LISTENERS ON "AZN BALANS" SECTION'S CALCULATOR
    function EventHandlerForCalculatorInputs() {
        $(".hidden-azn-balance-top-increase-balance>div:nth-child(2) .azn-balance-increase-input:nth-child(1) span").click(function () {
            $(this).css("top", "-10px")
        });
        // ============================================== CHANGES POSITION OF PLACEHOLDER("span") RESPECT TO INPUT FOCUS
        $(".hidden-azn-balance-top-increase-balance>div:nth-child(2) .azn-balance-increase-input input").focus(function () {
            $(this).siblings("span").css("top", "-10px");
        });
        // ============================================== CHANGES POSITION OF PLACEHOLDER("span") RESPECT TO INPUT BLUR
        $(".hidden-azn-balance-top-increase-balance>div:nth-child(2) .azn-balance-increase-input input").blur(function () {
            if ($(this).val().length < 1) {
                $(this).siblings("span").css("top", "9.5px");
                $(".hidden-azn-balance-top-increase-balance>div:nth-child(2) .azn-balance-increase-input:nth-child(2) input").siblings("span").css("top", "9.5px");
            }
        });
        // ================== TAKES THE VALUE OF INPUT FROM FIRST AND WRITES DOWN TO SECOND
        $(".hidden-azn-balance-top-increase-balance>div:nth-child(2) .azn-balance-increase-input:nth-child(1) input").change(function () {
            $(".hidden-azn-balance-top-increase-balance>div:nth-child(2) .azn-balance-increase-input:nth-child(2) input").siblings("span").css("top", "-10px");
            if ($(this).val() > 50) {
                $(this).val(50)
            }
            //$(".hidden-azn-balance-top-increase-balance>div:nth-child(2) .azn-balance-increase-input:nth-child(2) input").val($(this).val() * 1.7);
        });
    }


    // =========================================================== EVENT LISTENERS ON "COURIER" SECTION'S FORM
    function EventHandlerForCourierInputs() {
        $(".hidden-courier-service-inputs ul li .forJquerys").click(function () {
            $(this).css("top", "-10px");
        });

        // ============================================== CHANGES POSITION OF PLACEHOLDER("span") RESPECT TO INPUT FOCUS
        $(".hidden-courier-service-inputs ul li input").focus(function () {
            $(this).siblings(".forJquerys").css("top", "-10px");
        });

        // ============================================== CHANGES POSITION OF PLACEHOLDER("span") RESPECT TO INPUT BLUR
        $(".hidden-courier-service-inputs ul li input").blur(function () {
            if ($(this).val().length < 1) {
                $(this).siblings(".forJquerys").css("top", "9.5px");
            }
        });

        // ============================================== MAKES INPUT TYPE RADIO SELECTED WHEN CLICK TO THE "p" TAG ALSO
        $(".hidden-courier-service form>div:nth-child(2) div p").click(function () {
            $(".hidden-courier-service form>div:nth-child(2) div p input").removeAttr("checked")
            $(this).children("input").attr("checked", "checked")
        });
    }


    // =========================================================== EVENT LISTENERS ON "SETTINGS" SECTION'S FORM
    function EventHandlerForSettingsInputs() {
        $(".hidden-user-settings-content-blocks form:nth-child(2)>div:nth-child(3)>div:nth-child(1)>div label").click(function () {
            $(this).css("top", "-10px");
        });

        // ============================================== CHANGES POSITION OF PLACEHOLDER("LABEL") RESPECT TO INPUT FOCUS (TENZIMLEMELER)
        $(".hidden-user-settings-content-blocks form:nth-child(2)>div:nth-child(3)>div:nth-child(1)>div input").focus(function () {
            $(this).siblings("label").css("top", "-10px");
        });

        // ============================================== CHANGES POSITION OF PLACEHOLDER("span") RESPECT TO INPUT BLUR (TENZIMLEMELER)
        $(".hidden-user-settings-content-blocks form:nth-child(2)>div:nth-child(3)>div:nth-child(1)>div input").blur(function () {
            if ($(this).val().length < 1) {
                $(this).siblings("label").css("top", "9.5px");
            }
        });
    }

  




    // ============================================================= CHANGE PACKAGES RESPECT TO COUNTR (BAGLAMALARIM SECTION)
    let prevClickedBaglamalarim = 0;
    $(".hidden-packages-header-block").click(function () {
        // ====================== IF THE SAME COUNTRY IS CLICKED IT WILL DO NOTHING, ELSE IT WILL CHANGE COUNTRY CONTENT
        let indexOfClicked = $(".hidden-packages-header-block").index(this);
        if (prevClickedBaglamalarim != indexOfClicked) {
            // ================================ CONTENT HIDE SHOW MANUPILATION
            $(".hidden-packages-country-block").fadeOut();
            $(".hidden-packages-country-block").eq(indexOfClicked).fadeIn(function () {
                ChangeHeightOfPackagesBlock();
            });

            // ================================ BORDER COLORS MANUPILATION
            $(".hidden-packages-header-block").css("border-top-color", "transparent");
            $(".hidden-packages-header-block").css("cursor", "pointer");
            $(this).css({
                "border-top-color": "#f95732",
                "cursor": "default"
            });
            if (indexOfClicked == 0) {
                $(".hidden-packages-header-block").eq(0).css("border-bottom-color", "transparent");
                $(".hidden-packages-header-block").eq(1).css({
                    "border-bottom-color": "#dddddd",
                    "border-right-color": "transparent"
                });
            } else if (indexOfClicked == 1) {
                $(".hidden-packages-header-block").eq(0).css("border-bottom-color", "#dddddd");
                $(".hidden-packages-header-block").eq(1).css({
                    "border-bottom-color": "transparent",
                    "border-right-color": "#dddddd"
                });
            }
            prevClickedBaglamalarim = indexOfClicked;
        }
    });


    //================================================ GIVES ADDITIONAL INFO ABOUT PACKAGE WHEN "BAX" BUTTON IS CLICKED
    $(".user-packages-list-main-info>div:last-child div:nth-child(1)").click(function () {
        $(".user-packages-list-additional-info").css("display", "none");
        $(this).parent().parent().siblings(".user-packages-list-additional-info").css("display", "flex");

        let heightOfBlock = $(".hidden-packages-content-main-container").height() + 170

        if ($(window).width() < 520) {
            $(".hidden-packages-content-main-container").height(heightOfBlock + 150);
        } else {
            $(".hidden-packages-content-main-container").height(heightOfBlock);
        }
    });



    // ======================================== CHANGES HEIGHT OF BAGLAMALARIM COUNTRY BLOCKS
    function ChangeHeightOfPackagesBlock() {
        let HeightOfSettingsBlock = 0;
        if ($(".hidden-packages-country-block").eq(0).css("display") == "block") {
            HeightOfSettingsBlock = $(".hidden-packages-country-block:nth-child(1)").outerHeight();
        }
        if ($(".hidden-packages-country-block").eq(1).css("display") == "block") {
            HeightOfSettingsBlock = $(".hidden-packages-country-block:nth-child(2)").outerHeight();
        }
        $(".hidden-packages-content-main-container").height(HeightOfSettingsBlock)
    }



    //================================================ GIVES ADDITIONAL INFO ABOUT ORDER WHEN "BAX" BUTTON IS CLICKED
    $(".user-orders-list-main-info>div:last-child div:nth-child(1)").click(function () {
        $(".user-orders-list-additional-info").css("display", "none");
        $(this).parent().parent().siblings(".user-orders-list-additional-info").css("display", "flex");
    });




    //================================== COPY TO CLIPBOARD
    $("#copyFirstTextBtn").click(function () {
        copyToClipboard($("#p1copy"));
    })

    $("#copySecondTextBtn").click(function () {
        copyToClipboard($("#p2copy"));
    })

    function copyToClipboard(element) {
        var $temp = $("<input>");
        $("body").append($temp);
        $temp.val($(element).text()).select();
        document.execCommand("copy");
        $temp.remove();
    }










    //=================================== HANDLERS FOR DATE TIME
    $(document).on('change', '#birth-Month', function () {
        if ($("#birth-Day option[value='29']").html() == undefined) {
            $("#birth-Day").append("<option value='29'>29</option>")
        }
        if ($("#birth-Day option[value='30']").html() == undefined) {


            $("#birth-Day").append("<option value='30'>30</option>")
        }
        if ($("#birth-Day option[value='31']").html() == undefined) {
            $("#birth-Day").append("<option value='31'>31</option>")
        }
        var month = $('#birth-Month').val();

        if (month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12) {


        } else {
            if (month != 2) {
                $("#birth-Day option[value='31']").remove();
            } else {
                var custYear = $('#birth-Year').val();
                if (custYear % 4 == 0) {
                    $("#birth-Day option[value='30']").remove();
                    $("#birth-Day option[value='31']").remove();

                } else {
                    $("#birth-Day option[value='29']").remove();
                    $("#birth-Day option[value='31']").remove();
                    $("#birth-Day option[value='30']").remove();



                }




            }
        }

    })
    $(document).on('change', '#birth-Year', function () {
        if ($("#birth-Day option[value='29']").html() == undefined) {
            $("#birth-Day").append("<option value='29'>29</option>")
        }
        if ($("#birth-Day option[value='30']").html() == undefined) {

            $("#birth-Day").append("<option value='30'>30</option>")
        }
        if ($("#birth-Day option[value='31']").html() == undefined) {
            $("#birth-Day").append("<option value='31'>31</option>")
        }
        var month = $('#birth-Month').val();

        if (month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12) {


        } else {
            if (month != 2) {
                $("#birth-Day option[value='31']").remove();
            } else {

                var custYear = $('#birth-Year').val();
                if (custYear % 4 == 0) {
                    $("#birth-Day option[value='30']").remove();
                    $("#birth-Day option[value='31']").remove();

                } else {
                    $("#birth-Day option[value='29']").remove();
                    $("#birth-Day option[value='31']").remove();
                    $("#birth-Day option[value='30']").remove();



                }


            }
        }

    })
    $(document).on('change', '#birth-Day', function () {
        if ($("#birth-Day option[value='29']").html() == undefined) {

            $("#birth-Day").append("<option value='29'>29</option>")
        }
        if ($("#birth-Day option[value='30']").html() == undefined) {

            $("#birth-Day").append("<option value='30'>30</option>")
        }
        if ($("#birth-Day option[value='31']").html() == undefined) {
            $("#birth-Day").append("<option value='31'>31</option>")
        }
        var month = $('#birth-Month').val();

        if (month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12) {


        } else {
            if (month != 2) {
                $("#birth-Day option[value='31']").remove();
            } else {


                var custYear = $('#birth-Year').val();
                if (custYear % 4 == 0) {
                    $("#birth-Day option[value='30']").remove();
                    $("#birth-Day option[value='31']").remove();

                } else {
                    $("#birth-Day option[value='29']").remove();
                    $("#birth-Day option[value='31']").remove();
                    $("#birth-Day option[value='30']").remove();



                }




            }
        }

    })



});