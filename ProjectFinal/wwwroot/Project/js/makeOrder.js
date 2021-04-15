$(document).ready(function () {
    $(document).on('click', '.customMinusButton', function () {
        var result = $('.numberInputDiv input').val();
        var numberOfInput;
        if (result == '') {
            numberOfInput = 0;

            console.log('entered');
            numberOfInput--;
            $('.numberInputDiv input').val(numberOfInput);
        } else {
            numberOfInput = $('.numberInputDiv input').val();
            numberOfInput--;
            $('.numberInputDiv input').val(numberOfInput);
        }

    })
    $(document).on('click', '.customPlusButton', function () {
        var result = $('.numberInputDiv input').val();
        var numberOfInput;
        if (result == '') {
            numberOfInput = 0;

            console.log('entered');
            numberOfInput++;
            $('.numberInputDiv input').val(numberOfInput);
        } else {
            numberOfInput = $('.numberInputDiv input').val();
            numberOfInput++;
            $('.numberInputDiv input').val(numberOfInput);
        }

    })
    $(document).on('click', '.addButton .customAddButton', function () {
        $(this).parent().parent().parent().parent().parent().removeClass('countryFormLast');
        $('.mainLeftMiddle').append($(`
        <div class="countryForm  countryFormLast">
        <div class="row">
            <div class="col-md-9 col-sm-6 col-xs-6">
                <div class="productLink">
                    <input class="form-control" type="text" placeholder="Məhsul linki* ">
                </div>
            </div>
            <div class="col-md-3 col-sm-6 col-xs-6">
                <div class="priceForm">
                    <input class="form-control" type="text" placeholder="Məbləğ(TL)* ">

                </div>
            </div>

        </div>
        <div class="row">
            <div class="col-md-6 col-sm-12 col-xs-12">
                <div class="isTurkey">
                    <p> <b>Türkiyə içi kargo * </b> </p>
                    <select class="form-control">

                        <option value="">Bəli </option>
                        <option value="">Xeyr </option>

                    </select>
                </div>
            </div>
            <div class="col-md-3 col-sm-12 col-xs-12"></div>
            <div class="col-md-3 col-sm-12 col-xs-12">
                <div class="isTurkey ">
                    <p> <b> Cəmi(+5%) </b> </p>
                    <input class="form-control isPercent " disabled type="text"
                        placeholder="Cəmi ">

                </div>
            </div>


        </div>
        <div class="amountAndQeyd">
            <div class="row">
                <div class="col-lg-6">
                    <div class="numberInputDiv">
                        <button type="button" class="btn customMinusButton btn-default"> -
                        </button>
                        <input class="form-control" type="number"
                            placeholder="Bağlamadaki məhsullar">
                        <button type="button"
                            class="btn customPlusButton customSecondBtn btn-default"> +
                        </button>
                    </div>
                </div>
                <div class="col-lg-6">
                    <div class="customAmountDiv">
                        <input class="form-control" type="number"
                            placeholder="Ölçü, rəng və s. üçün qeydlər *">
                    </div>
                </div>


            </div>
            <div class="row">
                <div class="col-12">
                    <div class="addButton">
                    <button class="btn customRemoveButton" > Linki sil  </button>

                        <button class="btn customAddButton "> Yeni link əlavə et </button>
                    </div>

                </div>
            </div>
        </div>
    </div>
        
        
        
        
        
        
        `))
    })
    //////
    $(document).on('click', '.customRemoveButton', function () {
        if ($(this).parent().parent().parent().parent().parent().hasClass('countryFormLast')) {
            $(this).parent().parent().parent().parent().parent().prev().addClass('countryFormLast');
            $(this).parent().parent().parent().parent().parent().remove();

        } else {
            $(this).parent().parent().parent().parent().parent().remove();

        }
    })
    //////
    $(document).on('click', '.checkButtonLeft input', function () {
        $('#firstModal').slideDown(400);
        $('body').css('overflow-x', 'hidden');
        $('body').css('overflow-y', 'hidden');

    })
    $(document).on('click', '.customTestiq', function () {
        $('.checkButtonLeft input').prop('checked', true);
        $('#firstModal').slideUp(400);
        $('body').css('overflow-x', 'auto');
        $('body').css('overflow-y', 'auto');

    })
    //
    $(document).on('click', '.customImtina', function () {
        $('.checkButtonLeft input').prop('checked', false);

        $('#firstModal').slideUp(400);
        $('body').css('overflow-x', 'auto');
        $('body').css('overflow-y', 'auto');

    })
    $(document).on('click', '.customX i', function () {
        $('.checkButtonLeft input').prop('checked', false);

        $('#firstModal').slideUp(400);
        $('body').css('overflow-x', 'auto');
        $('body').css('overflow-y', 'auto');

    })
    // $(document).on('click','#firstModal',function(){
    //     $('.checkButtonLeft input').prop('checked',false);

    //     $('#firstModal').slideUp(400);
    //     $('body').css('overflow-x','auto');
    //     $('body').css('overflow-y','auto');

    // })
    $(document).on('click', '.customOdenisEtButton', function () {

        if ($('.checkButtonLeft input').prop('checked') == false) {

            Swal.fire({
                icon: 'error',

                text: 'Ödəniş şərtlərini qəbul etməmisiniz'
            })
        }

    })
    $(document).on('keyup', '.customPrice', function () {
        var price = $('.customPrice').val();
        if (price < 1) {
            $('.customPrice').val('1');
            price = 1;

        }
        var amount = $('.customAmount').val();
        if (amount < 1) {
            $('.customAmount').val('1');
            amount = 1;

        }
        var lastResult = $('.isPercentSecond').val();

        if (lastResult == undefined || lastResult == '') {
            lastResult = 0;
        }
        lastResult = parseFloat(lastResult);
        console.log(lastResult);

        lastResult = lastResult;
        var result = parseFloat(((price * amount) + lastResult) * 1.05 * 1000 / 1000);

        result = Math.round((result + Number.EPSILON) * 100) / 100
        result = Math.abs(result);

        $('.spanForSlaw').html(result);
        $('.isPercent').val(result);






    })
    $(document).on('click', '.customPlusButton', function () {
        var price = $('.customPrice').val();
        if (price < 1) {
            $('.customPrice').val('1');
            price = 1;

        }
        var amount = $('.customAmount').val();
        if (amount < 1) {
            $('.customAmount').val('1');
            amount = 1;

        }
        var lastResult = $('.isPercentSecond').val();

        if (lastResult == undefined || lastResult == '') {
            lastResult = 0;
        }
        lastResult = parseFloat(lastResult);
        console.log(lastResult);

        lastResult = lastResult;
        var result = parseFloat(((price * amount) + lastResult) * 1.05 * 1000 / 1000);


        result = Math.round((result + Number.EPSILON) * 100) / 100
        result = Math.abs(result);

        $('.spanForSlaw').html(result);
        $('.isPercent').val(result);




    })
    $(document).on('click', '.customMinusButton', function () {
        var price = $('.customPrice').val();
        if (price < 1) {
            $('.customPrice').val('1');
            price = 1;

        }
        var amount = $('.customAmount').val();
        if (amount < 1) {
            $('.customAmount').val('1');
            amount = 1;

        }
        var lastResult = $('.isPercentSecond').val();

        if (lastResult == undefined || lastResult == '') {
            lastResult = 0;
        }
        lastResult = parseFloat(lastResult);
        console.log(lastResult);

        lastResult = lastResult;
        var result = parseFloat(((price * amount) + lastResult) * 1.05 * 1000 / 1000);

        result = Math.round((result + Number.EPSILON) * 100) / 100
        result = Math.abs(result);

        $('.spanForSlaw').html(result);
        $('.isPercent').val(result);





    })
    $(document).on('keyup', '.customAmount', function () {
        var price = $('.customPrice').val();
        if (price < 1) {
            $('.customPrice').val('1');
            price = 1;

        }
        var amount = $('.customAmount').val();
        if (amount < 1) {
            $('.customAmount').val('1');
            amount = 1;

        }
        var lastResult = $('.isPercentSecond').val();

        if (lastResult == undefined || lastResult == '') {
            lastResult = 0;
        }
        lastResult = parseFloat(lastResult);
        console.log(lastResult);

        lastResult = lastResult;
        var result = parseFloat(((price * amount) + lastResult) * 1.05 * 1000 / 1000);
        result = Math.round((result + Number.EPSILON) * 100) / 100
        result = Math.abs(result);

        $('.spanForSlaw').html(result);
        $('.isPercent').val(result);





    })

    $(document).on('change', '.customİsTurkey', function () {
        //$('.customAppend').remove("<input type='number' />");
        console.log($('.customİsTurkey').val());
        var value = $('.isPercentSecond');
        if (value == undefined) {
            value = 0;
        }


        if ($('.customİsTurkey').val() == 'Bəli') {
            console.log('Entered');

            $('.customAppend').append(`
               
                <p class='isTurkey'> <b> Karqo məbləği * </b> </p>
                <input class="form-control isPercentSecond " type="number" placeholder="Cəmi " id="hiddenPrice" min="1" value="1">

                 
                `);
        } else {
            $('.customAppend').empty();

        }
    })
    $(document).on('keyup', '.isPercentSecond', function () {
        var price = $('.customPrice').val();

        if (price < 1) {
            $('.customPrice').val('1');
            price = 1;

        }
        var amount = $('.customAmount').val();
        if (amount < 1) {
            $('.customAmount').val('1');
            amount = 1;

        }
        var lastResult = $('.isPercentSecond').val();

        if (lastResult == undefined || lastResult == '') {
            lastResult = 0;
        }
        lastResult = parseFloat(lastResult);
        console.log(lastResult);

        lastResult = lastResult;
        var result = parseFloat(((price * amount) + lastResult) * 1.05 * 1000 / 1000);

        result = Math.round((result + Number.EPSILON) * 100) / 100
        result = Math.abs(result);

        $('.spanForSlaw').html(result);
        $('.isPercent').val(result);



        $(document).on("keyup", ".isPercentSecond", function (e) {
            if ($(this).val() <= 0 || $(this).val().length == 0) {
                $(this).val(1)
            }
            console.log("salam")
        });

        $(document).on("change", ".isPercentSecond", function (e) {
            if ($(this).val() <= 0 || $(this).val().length == 0) {
                $(this).val(1)
            }
            console.log("salam")
        });



    })
})