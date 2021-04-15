$(document).ready(function () {


    var target;
    let stringStatus;
    let tempCompanyName;


    //============================================================== SHOWS INVOICE STATUS
    $(document).on("click", ".getInvoiceStatus", function (e) {
        e.preventDefault();
        target = e.target;
        let invoiceNumber = $(target).data('invoice-number');

        let invoiceDate = $(target).data('invoice-date');
        invoiceDate = invoiceDate.substr(0, invoiceDate.indexOf(' '));

        let storeName = $(target).data('store-name');

        let invoiceStatus = $(target).data('invoice-status');
        invoiceStatus = parseInt(invoiceStatus);


        if (invoiceStatus == 1) {
            stringStatus = "SIFARIŞ VERİLDİ"
        }
        else if (invoiceStatus == 2) {
            stringStatus = "XARİCİ ANBARDA"
        }
        else if (invoiceStatus == 3) {
            stringStatus = "YOLDADIR"
        }
        else if (invoiceStatus == 4) {
            stringStatus = "GÖMRÜK YOXLANIIŞI"
        }
        else if (invoiceStatus == 5) {
            stringStatus = "ANBARDA"
        }
        else if (invoiceStatus == 6) {
            stringStatus = "KURYER ÇATDIRMA"
        }
        else if (invoiceStatus == 7) {
            stringStatus = "İADƏ"
        }
        else if (invoiceStatus == 8) {
            stringStatus = "TƏHVİL VERİLDİ"
        }

        $("#getStatusModal .modal-body-status-header-block").eq(0).children("p").eq(1).text(invoiceNumber)
        $("#getStatusModal .modal-body-status-header-block").eq(1).children("p").eq(1).text(invoiceDate)
        $("#getStatusModal .modal-body-status-header-block").eq(2).children("p").eq(0).text("Mağaza adı")
        $("#getStatusModal .modal-body-status-header-block").eq(2).children("p").eq(1).text(storeName)
        $("#getStatusModal .modal-body-status-header-block").eq(3).children("p").eq(1).text(stringStatus)



        //=================== HANDLERS FOR MAKE SELECTED RESPECT TO STATUS
        $(".modal-body-status-content-status-block-image-block-image").css("background-color", "#ebebeb");
        $(".modal-body-status-content-status-block-linking-block-circle").css("background-color", "transparent");
        $(".modal-body-status-content-status-block-linking-block-border").css("border", "1px #c8c8c8 dashed");

        $(".modal-body-mobile-status-content-status-block-linking-block-border").css("border", "1px #c8c8c8 dashed");
        $(".modal-body-mobile-status-content-status-block-linking-block-circle").css("background-color", "transparent");
        $(".modal-body-mobile-status-content-status-block-image-block-image").css("background-color", "#ebebeb");

        for (let i = 1; i <= invoiceStatus; i++) {
            if (i == 8) {
                for (var j = 0; j <= 6; j++) {
                    $(".modal-body-status-content-status-block-image-block-image").eq(j).css("background-color", "#058fff");
                    $(".modal-body-status-content-status-block-linking-block-circle").eq(j).css("background-color", "#058fff");
                    $(".modal-body-status-content-status-block-linking-block-border").eq(j).css("border", "1px #058fff dashed");

                    //============================ MOBILE VERSION
                    $(".modal-body-mobile-status-content-status-block-image-block-image").eq(j).css("background-color", "#058fff");
                    $(".modal-body-mobile-status-content-status-block-linking-block-circle").eq(j).css("background-color", "#058fff");
                    $(".modal-body-mobile-status-content-status-block-linking-block-border").eq(j).css("border", "1px #058fff dashed");
                }


                $(".modal-body-status-content-status-block-image-block-image").eq(7).css("background-color", "#058fff");

                //============================ MOBILE VERSION
                $(".modal-body-mobile-status-content-status-block-image-block-image").eq(7).css("background-color", "#058fff");
                $(".modal-body-mobile-status-content-status-block-linking-block-circle").eq(7).css("background-color", "#058fff");
                $(".modal-body-mobile-status-content-status-block-linking-block-border").eq(7).css("border", "1px #058fff dashed");
            } else {
                let tempIndex = i - 1;
                $(".modal-body-status-content-status-block-image-block-image").eq(tempIndex).css("background-color", "#058fff");
                $(".modal-body-status-content-status-block-linking-block-circle").eq(tempIndex).css("background-color", "#058fff");
                $(".modal-body-status-content-status-block-linking-block-border").eq(tempIndex).css("border", "1px #058fff dashed");

                //========= MOBILE
                $(".modal-body-mobile-status-content-status-block-image-block-image").eq(tempIndex).css("background-color", "#058fff");
                $(".modal-body-mobile-status-content-status-block-linking-block-circle").eq(tempIndex).css("background-color", "#058fff");
                $(".modal-body-mobile-status-content-status-block-linking-block-border").eq(tempIndex).css("border", "1px #058fff dashed");
            }
        }



        $("#getStatusModal").modal('show');
    });









    //============================================================== SHOWS ORDER STATUS
    $(document).on("click", ".getOrderLinkStatus", function (e) {
        e.preventDefault();
        target = e.target;
        let orderNumber = $(target).data('order-number');

        let orderDate = $(target).data('order-date');
        orderDate = orderDate.substr(0, orderDate.indexOf(' '));

        let companyName = $(target).data('order-company-name');
        let orderLink = $(target).data('order-link');

        let orderStatus = $(target).data('order-status');
        orderStatus = parseInt(orderStatus);


        if (orderStatus == 1) {
            stringStatus = "SIFARIŞ VERİLDİ"
        }
        else if (orderStatus == 2) {
            stringStatus = "XARİCİ ANBARDA"
        }
        else if (orderStatus == 3) {
            stringStatus = "YOLDADIR"
        }
        else if (orderStatus == 4) {
            stringStatus = "GÖMRÜK YOXLANIIŞI"
        }
        else if (orderStatus == 5) {
            stringStatus = "ANBARDA"
        }
        else if (orderStatus == 6) {
            stringStatus = "KURYER ÇATDIRMA"
        }
        else if (orderStatus == 7) {
            stringStatus = "İADƏ"
        }
        else if (orderStatus == 8) {
            stringStatus = "TƏHVİL VERİLDİ"
        }
        else if (orderStatus == 10) {
            stringStatus = "GÖZLƏYİR"
        }


        if (companyName == "" || companyName == null) {
            tempCompanyName = "Sifarişə keçid"
        } else {
            tempCompanyName = companyName
        }


        $("#getStatusModal .modal-body-status-header-block").eq(0).children("p").eq(1).text(orderNumber)
        $("#getStatusModal .modal-body-status-header-block").eq(1).children("p").eq(1).text(orderDate)
        $("#getStatusModal .modal-body-status-header-block").eq(2).children("p").eq(0).text("Sifariş")
        $("#getStatusModal .modal-body-status-header-block").eq(2).children("p").eq(1).html(`<a href="${orderLink}" target="_blank">${tempCompanyName}</a>`)
        $("#getStatusModal .modal-body-status-header-block").eq(3).children("p").eq(1).text(stringStatus)



        //=================== HANDLERS FOR MAKE SELECTED RESPECT TO STATUS
        $(".modal-body-status-content-status-block-image-block-image").css("background-color", "#ebebeb");
        $(".modal-body-status-content-status-block-linking-block-circle").css("background-color", "transparent");
        $(".modal-body-status-content-status-block-linking-block-border").css("border", "1px #c8c8c8 dashed");

        $(".modal-body-mobile-status-content-status-block-linking-block-border").css("border", "1px #c8c8c8 dashed");
        $(".modal-body-mobile-status-content-status-block-linking-block-circle").css("background-color", "transparent");
        $(".modal-body-mobile-status-content-status-block-image-block-image").css("background-color", "#ebebeb");

        if (orderStatus != 10) {
            for (let i = 1; i <= orderStatus; i++) {
                if (i == 8) {
                    for (var j = 0; j <= 6; j++) {
                        $(".modal-body-status-content-status-block-image-block-image").eq(j).css("background-color", "#058fff");
                        $(".modal-body-status-content-status-block-linking-block-circle").eq(j).css("background-color", "#058fff");
                        $(".modal-body-status-content-status-block-linking-block-border").eq(j).css("border", "1px #058fff dashed");

                        //============================ MOBILE VERSION
                        $(".modal-body-mobile-status-content-status-block-image-block-image").eq(j).css("background-color", "#058fff");
                        $(".modal-body-mobile-status-content-status-block-linking-block-circle").eq(j).css("background-color", "#058fff");
                        $(".modal-body-mobile-status-content-status-block-linking-block-border").eq(j).css("border", "1px #058fff dashed");
                    }


                    $(".modal-body-status-content-status-block-image-block-image").eq(7).css("background-color", "#058fff");

                    //============================ MOBILE VERSION
                    $(".modal-body-mobile-status-content-status-block-image-block-image").eq(7).css("background-color", "#058fff");
                    $(".modal-body-mobile-status-content-status-block-linking-block-circle").eq(7).css("background-color", "#058fff");
                    $(".modal-body-mobile-status-content-status-block-linking-block-border").eq(7).css("border", "1px #058fff dashed");
                } else {
                    let tempIndex = i - 1;
                    $(".modal-body-status-content-status-block-image-block-image").eq(tempIndex).css("background-color", "#058fff");
                    $(".modal-body-status-content-status-block-linking-block-circle").eq(tempIndex).css("background-color", "#058fff");
                    $(".modal-body-status-content-status-block-linking-block-border").eq(tempIndex).css("border", "1px #058fff dashed");

                    //========= MOBILE
                    $(".modal-body-mobile-status-content-status-block-image-block-image").eq(tempIndex).css("background-color", "#058fff");
                    $(".modal-body-mobile-status-content-status-block-linking-block-circle").eq(tempIndex).css("background-color", "#058fff");
                    $(".modal-body-mobile-status-content-status-block-linking-block-border").eq(tempIndex).css("border", "1px #058fff dashed");
                }
            }
        }


        $("#getStatusModal").modal('show');
    });









});