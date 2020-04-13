function PopupForm(url) {
    var formDiv = $('<div />');
    $.get(url)
        .done(function (response) {
            formDiv.html(response);

            Popup = formDiv.dialog({
                autoOpen: true,
                resizable: false,
                title: "Fill form with needed details",
                model: true,
                draggable: false,
                height: 'auto',
                width: '320px',
                close: function () {
                    Popup.dialog('destroy').remove();
                }


            });

            $(function () {
                $('.datetimepicker').datetimepicker({
                });
            });

            $(function () {
                $('.datetimepickernodate').datetimepicker({
                    format: 'MM/DD/YYYY'
                });
            });
        });
}

function SubmitForm(form) {
    $.validator.unobtrusive.parse(form);

    if ($(form).valid()) {

        $.ajax({
            type: "POST",
            url: form.action,
            data: $(form).serialize(),
            success: function (data) {
                if (data.success) {
                    Popup.dialog('close');
                    dataTable.api().ajax.reload();

                    $.notify(data.message,
                        {
                            globalPosition: "top center",
                            className: "success"
                        });
                }
            }
        });
    }
    return false;
}




