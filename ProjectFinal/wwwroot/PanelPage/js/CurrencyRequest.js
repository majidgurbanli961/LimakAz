$(document).ready(function () {


    let isReceivedIncreaseBalanceCalculator = false;
    let isReceivedCalculatorAside = false;
    let AZNUSD = 0;
    let AZNTL = 0;


    $(".hidden-azn-balance-top-increase-balance>div:nth-child(2) .azn-balance-increase-input:nth-child(1) input").change(function () {

        if (isReceivedIncreaseBalanceCalculator == false) {

            $.ajax({
                url: "/PanelPage/GetCurrencyCalculator",
                dataType: "json",

                success: function (data) {

                    CurrencyFinder(data);
                    IncreaseBalanceCurrencyChange();

                    isReceivedIncreaseBalanceCalculator = true;
                },

                error: function () {
                    alert("Error")
                }

            })
        }
        IncreaseBalanceCurrencyChange();
    });



    $(".calculator-input input").keyup(function () {

        if (isReceivedCalculatorAside == false) {

            $.ajax({
                url: "/PanelPage/GetCurrencyCalculator",
                dataType: "json",

                success: function (data) {
                    CurrencyFinder(data);

                    isReceivedCalculatorAside = true;
                },

                error: function () {
                    alert("Error")
                }

            })
        }
        AsideNavbarCalculatorHandler();
    });

    $("#Input, #Output").change(function () {

        if (isReceivedCalculatorAside == false) {

            $.ajax({
                url: "/PanelPage/GetCurrencyCalculator",
                dataType: "json",

                success: function (data) {
                    CurrencyFinder(data);

                    isReceivedCalculatorAside = true;
                },

                error: function () {
                    alert("Error")
                }

            })
        }
        AsideNavbarCalculatorHandler();
    });

    $(".calculator-input input").change(function () {

        if (isReceivedCalculatorAside == false) {

            $.ajax({
                url: "/PanelPage/GetCurrencyCalculator",
                dataType: "json",

                success: function (data) {
                    CurrencyFinder(data);

                    isReceivedCalculatorAside = true;
                },

                error: function () {
                    alert("Error")
                }

            })
        }
        AsideNavbarCalculatorHandler();
    });


    // ============================================================= FUNCTION THAT GIVES VALUE TO OUTPUT RESPECT TO CURRENCIES
    function AsideNavbarCalculatorHandler() {
        let outputValue = 0;
        let inputElement = $(".calculator-input input");
        let USDTL = AZNUSD / AZNTL;

        if (($("#Input").val() == 1 && $("#Output").val() == 1) || ($("#Input").val() == 2 && $("#Output").val() == 2) || ($("#Input").val() == 3 && $("#Output").val() == 3)) {
            outputValue = inputElement.val();
        } else if ($("#Input").val() == 1 && $("#Output").val() == 2) {
            outputValue = inputElement.val() / AZNUSD
        } else if ($("#Input").val() == 1 && $("#Output").val() == 3) {
            outputValue = inputElement.val() / AZNTL
        } else if ($("#Input").val() == 2 && $("#Output").val() == 1) {
            outputValue = inputElement.val() * AZNUSD
        } else if ($("#Input").val() == 2 && $("#Output").val() == 3) {
            outputValue = inputElement.val() * USDTL
        } else if ($("#Input").val() == 3 && $("#Output").val() == 1) {
            outputValue = inputElement.val() * AZNTL
        } else if ($("#Input").val() == 3 && $("#Output").val() == 2) {
            outputValue = inputElement.val() / USDTL
        }

        var resultRounded = Math.round(outputValue * 100) / 100;

        $(".calculator-output input").val(resultRounded)
    }



    function CurrencyFinder(data) {
        //======================================== FINDS THE CURRENCY OF THE EACH COUNTRY
        for (var i = 0; i < data.ValCurs.ValType[1].Valute.length; i++) {
            if (data.ValCurs.ValType[1].Valute[i].Name == "1 ABŞ dolları") {
                AZNUSD = data.ValCurs.ValType[1].Valute[i].Value;
            }
            if (data.ValCurs.ValType[1].Valute[i].Name == "1 Türkiyə lirəsi") {
                AZNTL = data.ValCurs.ValType[1].Valute[i].Value;
            }
        }
    }



    //=========================================== CALCULATES THE USD CURRENCY USING CURRENCY AZN IN "AZN BALANSIM" SECTION
    function IncreaseBalanceCurrencyChange() {

        let firstInput = $(".hidden-azn-balance-top-increase-balance>div:nth-child(2) .azn-balance-increase-input:nth-child(1) input");

        let lastResult = firstInput.val() * AZNUSD;
        

        var roundedString = lastResult.toFixed(2);

        $(".hidden-azn-balance-top-increase-balance>div:nth-child(2) .azn-balance-increase-input:nth-child(2) input").val(roundedString);

    }



});
