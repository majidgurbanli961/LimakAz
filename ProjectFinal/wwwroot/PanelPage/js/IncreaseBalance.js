$(document).ready(function () {

    $(".hidden-azn-balance-top-increase-balance > div:nth-child(2) button").click(function () {
        let data_ = {
            AZNBalance: 0
        };

        data_.AZNBalance = $(".hidden-azn-balance-top-increase-balance>div:nth-child(2) .azn-balance-increase-input:nth-child(2) input").val();

        if (data_.AZNBalance > 0) {

            $.ajax({
                type: "POST",
                url: "/PanelPage/IncreaseBalance",
                dataType: "json",
                data: data_,

                success: function (data) {

                    $("#SuccessfullyAdded").modal('show');
                    $("#SuccessfullyAdded .modal-body p").text("Balans uğurla artırıldı");

                    $(".hidden-panel-page-top-balance > div:nth-child(2) span").html(`${data.AZNBalance} <sup data-v-27fd2a5d="">₼</sup>`)
                    $(".hidden-azn-balance-top-balance > div:nth-child(2) span").html(`${data.AZNBalance} <sup data-v-27fd2a5d="">₼</sup>`)

                    var date = new Date(Date.parse(data.LastIncreasedAZNBalanceDate));
                    var dateLastFormat = (date.getDate()) + "/" + (date.getMonth() + 1) + "/" + date.getFullYear();

                    $(".hidden-panel-page-top-balance > div:first-child span:last-child").text(`Son əlavə tarixi: ${dateLastFormat}`);
                    $(".hidden-azn-balance-top-balance > div:first-child span:last-child").text(`Son əlavə tarixi: ${dateLastFormat}`);


                    let increasedValueToNode = $(".hidden-azn-balance-top-increase-balance>div:nth-child(2) .azn-balance-increase-input:nth-child(2) input").val();
                    var today = new Date();
                    var date = today.getDate() + '/' + (today.getMonth() + 1) + '/' + today.getFullYear();

                    let node = `<tr>
                                  <td>Mədaxil</td>
                                  <td>${increasedValueToNode}</td>
                                  <td>${date}</td>
                                </tr>`

                    $(".hidden-panel-page-bottom tbody").append(node);
                    $(".hidden-azn-balance-bottom tbody").append(node);


                    console.log("success");
                },

                error: function () {
                    alert("Error")
                }

            });
        }
    });


});