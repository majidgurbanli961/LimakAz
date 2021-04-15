$(document).ready(function () {

    //===================================== FOR PANEL PAGE TRANSACTIONS TABLE
    $(".hidden-panel-page-bottom select").change(function () {
        valueOfSelect = $(this).val()
        let selectedString = $(".hidden-panel-page-bottom select option:selected").text().toUpperCase();

        if (valueOfSelect == 1) {
            $(".hidden-panel-page-bottom tbody tr").css("display", "table-row");
        } else {
            sortTransactionsPanel(selectedString);
        }
    });



    function sortTransactionsPanel(statusString) {
        for (var i = 0; i < $(".hidden-panel-page-bottom tbody tr td:nth-child(1)").length; i++) {
            let textOfStatus = $(".hidden-panel-page-bottom tbody tr td:nth-child(1)").eq(i).text().toUpperCase();
            if (textOfStatus == statusString) {
                $(".hidden-panel-page-bottom tbody tr").eq(i).css("display", "table-row");
            } else {
                $(".hidden-panel-page-bottom tbody tr").eq(i).css("display", "none");
            }
        }
    }





    //===================================== FOR AZN BALANCE SECTION TRANSACTIONS TABLE
    $(".hidden-azn-balance-bottom select").change(function () {
        valueOfSelect = $(this).val()
        let selectedString = $(".hidden-azn-balance-bottom select option:selected").text().toUpperCase();

        if (valueOfSelect == 1) {
            $(".hidden-azn-balance-bottom tbody tr").css("display", "table-row");
        } else {
            sortTransactionsAZN(selectedString);
        }
    });



    function sortTransactionsAZN(statusString) {
        for (var i = 0; i < $(".hidden-azn-balance-bottom tbody tr td:nth-child(1)").length; i++) {
            let textOfStatus = $(".hidden-azn-balance-bottom tbody tr td:nth-child(1)").eq(i).text().toUpperCase();
            if (textOfStatus == statusString) {
                $(".hidden-azn-balance-bottom tbody tr").eq(i).css("display", "table-row");
            } else {
                $(".hidden-azn-balance-bottom tbody tr").eq(i).css("display", "none");
            }
        }
    }







    //===================================== FOR TL BALANCE SECTION TRANSACTIONS TABLE
    $(".hidden-tl-balance-bottom-header select").change(function () {
        valueOfSelect = $(this).val()
        let selectedString = $(".hidden-tl-balance-bottom-header select option:selected").text().toUpperCase();

        if (valueOfSelect == 1) {
            $(".hidden-tl-balance-bottom-table tbody tr").css("display", "table-row");
        } else {
            sortTransactionsTL(selectedString);
        }
    });



    function sortTransactionsTL(statusString) {
        for (var i = 0; i < $(".hidden-tl-balance-bottom-table tbody tr td:nth-child(1)").length; i++) {
            let textOfStatus = $(".hidden-tl-balance-bottom-table tbody tr td:nth-child(1)").eq(i).text().toUpperCase();
            if (textOfStatus == statusString) {
                $(".hidden-tl-balance-bottom-table tbody tr").eq(i).css("display", "table-row");
            } else {
                $(".hidden-tl-balance-bottom-table tbody tr").eq(i).css("display", "none");
            }
        }
    }





});