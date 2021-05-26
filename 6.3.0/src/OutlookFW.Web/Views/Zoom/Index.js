
$(document).ready(function () {
    $('#btnLogin').click(function () {
        window.location.href = "https://zoom.us/oauth/authorize?response_type=code&state=12345&client_id=a8f83bd5-dd71-4f7b-a56b-295a5a1a0334&redirect_uri=https://localhost:44371/Zoom/CreateOauthTokenForZoom";
    });
    $('#btnLogout').click(function () {
        externalLogout();

    });
    var redirectUrl = "https://localhost:44334/Gmail/Index";
    function externalLogout() {
        var url, params;

        url = "https://www.google.com/accounts/Logout?continue=https://appengine.google.com/_ah/logout";
        params = {
            next: redirectUrl
        }
        performCallLogout(url, params);

    }

    function performCallLogout(url, params) {
        window.location.href = url + "?continue=" + params.next;
    }



    $('#sendEmailAPI').submit(function (e) {

        var valdata = $("form").serialize();

        $.ajax({
            url: "/Gmail/SendMail",
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

        e.preventDefault();

    });
});
