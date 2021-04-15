$(document).ready(function () {
 
    $(document).on('change', '.customSelect', function () {
     
        var customId = $(this).val()
        $.ajax({
            type: "GET",
            url: "/admin/contactadmin/seeAllShopContentAjax",
            data: { id: customId },
            dataType: "json",
            success: function (msg) {
         

                $('tbody').empty();
                for (var i = 0; i < msg.length; i++) {
                    $('tbody').append(`
            <tr>
              
                   
                <td>
 ${msg[i].customText}
                </td>
                <td>
                   <span  class='${msg[i].id} customDelete btn btn-info btn-circle btn-danger btn-sm' id='${msg[i].id}' > <i class='fas fa-trash' ></i> </span>
                   <a class='btn btn-info btn-circle btn-sm' href='/admin/contactadmin/editshopcontent/${msg[i].id}' > <i class='fas fa-pencil-alt' ></i> </a>

                </td>
              
                    
              
            </tr>
`)

                }
            },
            error: function (req, status, error) {
                console.log(msg);
            }
        });
    })
    $(document).on('click', '.customDelete', function () {
       
        if (!confirm('Eminsiz?')) {

        } else {

        var className = $(this).attr('id');
        console.log(className[0]);
        $.ajax({
            type: "GET",
            url: "/admin/contactadmin/DeleteShopContent",
            data: { id: className },
            dataType: "json",
            success: function (msg) {
                $(`#${className}`).parent().parent().remove();
                console

            },
            error: function (req, status, error) {
                console.log(error);
            }
        });
        }


    }

    );
    










})