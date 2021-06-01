
$(document).ready(function () {
    (function ($) {
    $('#btnLogin').click(function () {
        window.location.href = "https://zoom.us/oauth/authorize?response_type=code&state=12345&client_id=6M7yDmdoTnaTE0cArJCCjg&redirect_uri=https://localhost:44371/Zoom/CreateOauthTokenForZoom&prompt=select_account";
    });
    $('#btnLogout').click(function () {
        //externalLogout();
        alert("logout");
        window.location.href = "/Zoom/SignOut";
        

    });


    $('#createMeeting').submit(function (e) {

        var valdata = $("form").serialize();

        $.ajax({
            url: "/Zoom/CreateMeeting",
            type: "POST",
            data: valdata,
            success: function (respone) {
                location.reload();

            }
            ,
            error: function () {

            },
        });
        $('#myModal').modal('hide');


        $("div").removeClass("modal-backdrop fade in");
        location.reload();
        e.preventDefault();

    });
    ///
    //$(function () {

    //    var _$form = $('#saveTask');

    //    _$form.find('input:first').focus();

    //    //_$form.validate();

    //    _$form.find('button[type=submit]')
    //        .click(function (e) {
    //            e.preventDefault();
    //            console.log("vao submit r");
    //            if (!_$form.valid()) {
    //                return;
    //            }

    //            var input = _$form.serializeFormToObject();

    //            abp.services.app.task.update(input)
    //                .done(function () {
    //                    location.href = '/Tasks';
    //                });
    //        });
    //});
})(jQuery);
});
