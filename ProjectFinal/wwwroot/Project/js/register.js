  
    $(document).ready(function () {

        $(document).on('change', '#Month', function () {
            console.log($("#Day option[value='29']").html());
            if ($("#Day option[value='29']").html() == undefined) {
                $("#Day").append("<option value='29'>29</option>")
            }
            if ($("#Day option[value='30']").html() == undefined) {


                $("#Day").append("<option value='30'>30</option>")
            }
            if ($("#Day option[value='31']").html() == undefined) {
                $("#Day").append("<option value='31'>31</option>")
            }
            var month = $('#Month').val();

            if (month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12) {


            } else {
                if (month != 2) {
                    $("#Day option[value='31']").remove();
                } else {
                    var custYear = $('#Year').val();
                    if (custYear % 4 == 0) {
                        $("#Day option[value='30']").remove();
                        $("#Day option[value='31']").remove();

                    } else {
                        $("#Day option[value='29']").remove();
                        $("#Day option[value='31']").remove();
                        $("#Day option[value='30']").remove();



                    }




                }
            }

        })
        $(document).on('change', '#Year', function () {
            console.log($("#Day option[value='29']").html());
            if ($("#Day option[value='29']").html() == undefined) {
                console.log('Ife girdi')
                $("#Day").append("<option value='29'>29</option>")
            }
            if ($("#Day option[value='30']").html() == undefined) {

                $("#Day").append("<option value='30'>30</option>")
            }
            if ($("#Day option[value='31']").html() == undefined) {
                $("#Day").append("<option value='31'>31</option>")
            }
            var month = $('#Month').val();

            if (month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12) {


            } else {
                if (month != 2) {
                    $("#Day option[value='31']").remove();
                } else {

                    var custYear = $('#Year').val();
                    if (custYear % 4 == 0) {
                        $("#Day option[value='30']").remove();
                        $("#Day option[value='31']").remove();

                    } else {
                        $("#Day option[value='29']").remove();
                        $("#Day option[value='31']").remove();
                        $("#Day option[value='30']").remove();



                    }


                    console.log('Bura');
                    console.log($('#Year').val());





                }
            }

        })
        $(document).on('change', '#Day', function () {
            console.log($("#Day option[value='29']").html());
            if ($("#Day option[value='29']").html() == undefined) {

                $("#Day").append("<option value='29'>29</option>")
            }
            if ($("#Day option[value='30']").html() == undefined) {
                console.log('30 add eliyen')

                $("#Day").append("<option value='30'>30</option>")
            }
            if ($("#Day option[value='31']").html() == undefined) {
                $("#Day").append("<option value='31'>31</option>")
            }
            var month = $('#Month').val();

            if (month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12) {


            } else {
                if (month != 2) {
                    $("#Day option[value='31']").remove();
                } else {


                    var custYear = $('#Year').val();
                    if (custYear % 4 == 0) {
                        $("#Day option[value='30']").remove();
                        $("#Day option[value='31']").remove();

                    } else {
                        $("#Day option[value='29']").remove();
                        $("#Day option[value='31']").remove();
                        $("#Day option[value='30']").remove();



                    }




                }
            }

        })




    })



