





function get_georgian_date(shamsi) {
    var date = shamsi.split("/");
    var georgian = toGregorian(parseInt(date[0]), parseInt(date[1]), parseInt(date[2]));
    var georgianDate = georgian.gy + "/" + georgian.gm + "/" + georgian.gd;
    return georgianDate;
}


//$("#DateOfBirth").inputmask("9999/99/99",
//    {
//        "placeholder": "----/--/--"
//    });




function LoadCreateForm() {
    var dialog = bootbox.dialog({
        title: 'Create Customer',
        locale: "fa",
        size: 'large',
        message: 'Please wait',
        onEscape: true,
        backdrop: true,
        buttons: {



            ok: {
                label: "save ",
                className: "btn-success",
                callback: function (result) {

                    if (result) {

                        var formData = $("form").serializeArray();
                        //var DateOfBirth = get_georgian_date($("#DateOfBirth").val());
                        //formData.forEach(function (item) {
                        //    if (item.name === "DateOfBirth") {
                        //        item.value = DateOfBirth;
                        //    }
                        //});
                        
                        
                        
                        $.ajax({
                            type: "Post",
                            data: formData,
                            datatype: "json",
                            //beforeSend: blockPage,
                            url: "/Customer/Create",
                            success: function (data) {

                                dialog.modal("hide");
                                window.location.reload();

                            },
                            error: function (xhr) {
                                //errorHandler(xhr, this);
                            },
                            complete: function () {
                                //unblockPage();
                            }
                        });
                    }
                    return false;


                }
            },
            cancel: {
                label: "Cancel",
                className: "btn-danger"
            },
        },
    });
    dialog.init(function () {

        $.ajax({
            url: "/Customer/Create",
            success: function (result) {

                dialog.find('.bootbox-body').html(result);
            }

        });
    });

}










function DeleteCustomer(customerId) {

    bootbox.confirm({
        message: "Are you sure ?",
        buttons: {
            confirm: {
                label: "Yes",
                className: "btn-success"
            },
            cancel: {
                label: "No",
                className: "btn-danger"
            }
        },
        callback: function (result) {
            if (result === true) {


                $.ajax({
                    type: "Post",
                    data: { "id": customerId },
                    datatype: "json",
                    //beforeSend: blockPage,
                    url: "/Customer/delete",
                    success: function (data) {


                        window.location.reload();

                    },
                    error: function (xhr) {
                        //errorHandler(xhr, this);
                    },
                    complete: function () {
                        //unblockPage();
                    }
                });

            }
        }
    })
}
        

function UpdateCustomer(customerId) {

    var dialog = bootbox.dialog({
        title: 'Edit Customer',

        size: 'large',
        message: 'Please wait ...',
        onEscape: true,
        backdrop: true,
        buttons: {
            cancel: {
                label: "Cancel",
                className: "btn-danger"
            },


            ok: {
                label: "Save ",
                className: "btn-success",
                callback: function (result) {

                    if (result) {
                        var formData = $("form").serializeArray();


                        $.ajax({
                            type: "Post",
                            data: formData,
                            datatype: "json",
                            //beforeSend: blockPage,
                            url: "/Customer/Update",
                            success: function (data) {

                                dialog.modal("hide");
                                window.location.reload();

                            },
                            error: function (xhr) {
                                //errorHandler(xhr, this);
                            },
                            complete: function () {
                                //unblockPage();
                            }
                        });
                    }
                    return false;


                }
            },
        },
    });
    dialog.init(function () {

        $.ajax({
            url: "/Customer/Update",
            data: { "customerId": customerId },
            success: function (result) {
                dialog.find('.bootbox-body').html(result);
            }

        });
    });


}
