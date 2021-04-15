$(document).ready(function () {


    //============================ SORTING RESPECT TO STATUS
    $("#Sifarislerim").change(function () {
        let valueOfSelect = $(this).val()
        if (valueOfSelect == 1) {
            $(".user-orders-list").css("display", "block");
        } else if (valueOfSelect == 2) {
            SortInvoicesRespectToStatusTRY("SIFARIŞ VERİLDİ");
        } else if (valueOfSelect == 3) {
            SortInvoicesRespectToStatusTRY("XARİCİ ANBARDA");
        } else if (valueOfSelect == 4) {
            SortInvoicesRespectToStatusTRY("YOLDADIR");
        } else if (valueOfSelect == 5) {
            SortInvoicesRespectToStatusTRY("GÖMRÜK YOXLANIIŞI");
        } else if (valueOfSelect == 6) {
            SortInvoicesRespectToStatusTRY("ANBARDA");
        } else if (valueOfSelect == 7) {
            SortInvoicesRespectToStatusTRY("KURYER ÇATDIRMA");
        } else if (valueOfSelect == 8) {
            SortInvoicesRespectToStatusTRY("İADƏ");
        } else if (valueOfSelect == 9) {
            SortInvoicesRespectToStatusTRY("TƏHVİL VERİLDİ");
        } else if (valueOfSelect == 10) {
            SortInvoicesRespectToStatusTRY("GÖZLƏYİR");
        }
    });



    function SortInvoicesRespectToStatusTRY(statusString) {
        for (var i = 0; i < $(".user-orders-list").length; i++) {
            let textOfStatus = $(".user-orders-list").eq(i).children(".user-orders-list-main-info").children("div").eq(3).children("p").eq(1).text().toUpperCase();
            if (textOfStatus == statusString) {
                $(".user-orders-list").eq(i).css("display", "block");
            } else {
                $(".user-orders-list").eq(i).css("display", "none");
            }
        }
    }


});