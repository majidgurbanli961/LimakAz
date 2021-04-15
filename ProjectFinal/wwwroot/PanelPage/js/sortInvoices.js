$(document).ready(function () {


    //============================ SORTING FOR TURKEY  
    $(".hidden-packages-country-block-header select").eq(0).change(function () {
        valueOfSelect = $(this).val()
        if (valueOfSelect == 1) {
            $(".hidden-packages-country-block form").eq(0).children(".user-packages-list").css("display", "block");
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
        }

        ChangeHeightOfPackagesBlock();
    });



    function SortInvoicesRespectToStatusTRY(statusString) {
        for (var i = 0; i < $(".hidden-packages-country-block form").eq(0).children(".user-packages-list").length; i++) {
            let textOfStatus = $(".hidden-packages-country-block form").eq(0).children(".user-packages-list").eq(i).children(".user-packages-list-main-info").children("div").eq(3).children("p").eq(1).text().toUpperCase();
            if (textOfStatus == statusString) {
                $(".hidden-packages-country-block form").eq(0).children(".user-packages-list").eq(i).css("display", "block");
            } else {
                $(".hidden-packages-country-block form").eq(0).children(".user-packages-list").eq(i).css("display", "none");
            }
        }
    }




    //============================ SORTING FOR USA  
    $(".hidden-packages-country-block-header select").eq(1).change(function () {
        valueOfSelect = $(this).val()
        if (valueOfSelect == 1) {
            $(".hidden-packages-country-block form").eq(1).children(".user-packages-list").css("display", "block");
        } else if (valueOfSelect == 2) {
            SortInvoicesRespectToStatusUSA("SIFARIŞ VERİLDİ");
        } else if (valueOfSelect == 3) {
            SortInvoicesRespectToStatusUSA("XARİCİ ANBARDA");
        } else if (valueOfSelect == 4) {
            SortInvoicesRespectToStatusUSA("YOLDADIR");
        } else if (valueOfSelect == 5) {
            SortInvoicesRespectToStatusUSA("GÖMRÜK YOXLANIIŞI");
        } else if (valueOfSelect == 6) {
            SortInvoicesRespectToStatusUSA("ANBARDA");
        } else if (valueOfSelect == 7) {
            SortInvoicesRespectToStatusUSA("KURYER ÇATDIRMA");
        } else if (valueOfSelect == 8) {
            SortInvoicesRespectToStatusUSA("İADƏ");
        } else if (valueOfSelect == 9) {
            SortInvoicesRespectToStatusUSA("TƏHVİL VERİLDİ");
        }

        ChangeHeightOfPackagesBlock();
    });



    function SortInvoicesRespectToStatusUSA(statusString) {
        for (var i = 0; i < $(".hidden-packages-country-block form").eq(1).children(".user-packages-list").length; i++) {
            let textOfStatus = $(".hidden-packages-country-block form").eq(1).children(".user-packages-list").eq(i).children(".user-packages-list-main-info").children("div").eq(3).children("p").eq(1).text().toUpperCase();
            if (textOfStatus == statusString) {
                $(".hidden-packages-country-block form").eq(1).children(".user-packages-list").eq(i).css("display", "block");
            } else {
                $(".hidden-packages-country-block form").eq(1).children(".user-packages-list").eq(i).css("display", "none");
            }
        }
    }




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





});