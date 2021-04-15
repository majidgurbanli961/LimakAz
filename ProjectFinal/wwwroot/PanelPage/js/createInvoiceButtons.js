$(document).ready(function () {

    let inputToChangeNumber = $(".invoice-form-input:nth-child(3) input");


    $(".invoice-form-input:nth-child(3) .invoice-form-input-amount div:nth-child(3)").click(function () {
        if (inputToChangeNumber.val() != "" || inputToChangeNumber.val() != null) {
            let numberForAmount = inputToChangeNumber.val();
            numberForAmount++;
            inputToChangeNumber.val(numberForAmount);
        }
    });


    $(".invoice-form-input:nth-child(3) .invoice-form-input-amount div:nth-child(1)").click(function () {
        if (inputToChangeNumber.val() != "" || inputToChangeNumber.val() != null) {
            if (inputToChangeNumber.val() > 0) {
                let numberForAmount = inputToChangeNumber.val();
                numberForAmount--;
                inputToChangeNumber.val(numberForAmount);
            }
        }
    });


    $(".invoice-form-input:nth-child(3) input").keyup(function () {
        if (inputToChangeNumber.val() < 0) {
            inputToChangeNumber.val(1)
        }
    });


    $(".invoice-form-input:nth-child(4) input").keyup(function () {
        if ($(this).val() < 0) {
            $(this).val(1)
        }
    });

});