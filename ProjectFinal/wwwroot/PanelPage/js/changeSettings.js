$(document).ready(function () {
    $(document).on('click', '.YaddaSaxla', function () {
        $('.customPhoneErrorMesage').html(" ");

        var name = $('.customMName').val();
        var surname = $('.customMSurname').val();
        var office = $('.customMOffice').val();
        var day = $('.customMDay').val();
        var month = $('.customMMonth').val();
        var year = $('.customMYear').val();
        var email = $('.customMEmail').val();
        var phone = $('.customMPhone').val();
        var customDate = new Date(year, month - 1, day);
        var sendObject = {
            name: name,
            surname: surname,
            office: office,
            customDate: customDate,
            email: email,
            phone: phone
        }
        var customRegPhone = new RegExp(/^((\+\d{1,3}(-| )?\(?\d\)?(-| )?\d{1,5})|(\(?\d{2,6}\)?))(-| )?(\d{3,4})(-| )?(\d{4})(( x| ext)\d{1,5}){0,1}$/);
        if (!customRegPhone.test(phone)) {
            Swal.fire({
                icon: 'error',

                text: 'Bele telefon nomresi Standartlara cavab vermir'
            })

        } else {

        $.ajax({
            type: 'Post',
            url: "/PanelPage/ChangeSetting",
            dataType: "json",
            data: sendObject,

            success: function (data) {
                console.log(data);
                console.log('nese');
                if (data == 'No') {
                  

                    //$('.customPhoneErrorMesage').html("Bele telefon nomresi artiq istifade olunub");
                    Swal.fire({
                        icon: 'error',

                        text: 'Bele telefon nomresi artiq istifade olunub'
                    })
                } else {
                    //$('.customPhoneErrorMesage').html("Melumatiniz bazada saxlanildi");
                    Swal.fire({
                        icon: 'success',

                        text: 'Melumatiniz bazada saxlanildi'
                    })


                }



            },

            error: function (responseText) {
                console.log("Alinmadi");
                console.log(responseText);
            }

        })
        }


    })
    $(document).on('click', '.customPasswordButton', function () {
        $('.confirmPasswordError').html(" ");
        $('.customAllErrors').html(" ");



        var oldPass = $('.customMOldPass').val();
        var newPass = $('.customMNewPass').val();
        var newPassConfirm = $('.customMNewPassConfirm').val();

        var cResult = newPass.localeCompare(newPassConfirm);

        if (cResult != 0) {

            Swal.fire({
                icon: 'error',

                text: "Parol ve testiq parolu uygun gelmir"
            })

        } else {
            var sendObj = { oldPass: oldPass, newPass: newPass, newPassConfirm: newPassConfirm };
            $.ajax({
                type: 'Post',
                url: "/PanelPage/ChangePassword",
                dataType: "json",
                data: sendObj,

                success: function (data) {

                    $('.customAllErrors').html(data);
                    Swal.fire({
                        icon: 'succes',

                        text: data
                    })




                },

                error: function (responseText) {
                    console.log("Errora girdu");

                }

            })


        }
    })
    $(document).on('click', '.customMPersonalButton', function () {
        $('.customMPPersonal').html(" ");

        var email = $('.customMMEmail').val();
        var seriaNumber = $('.customMSeria').val();
        var fin = $('.customMFin').val();
        var citizenship = $('.customMCitizenship').val();
        var gender = $('.customMGender').val();
        var city = $('.customMCity').val();
        var sendObj = {
            email: email,
            seriaNumber: seriaNumber,
            fin: fin,
            citizenship: citizenship,
            gender: gender,
            city: city
        }
        $.ajax({
            type: 'Post',
            url: "/PanelPage/ChangePersonalInfo",
            dataType: "json",
            data: sendObj,

            success: function (data) {
            
               
                Swal.fire({
                    icon: 'success',

                    text: 'Melumatiniz bazada saxlanildi'
                })



            },

            error: function (responseText) {

            }

        })


    })


});