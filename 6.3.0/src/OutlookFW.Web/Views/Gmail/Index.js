
$(document).ready(function () {
    $('#btnLogin').click(function () {
        window.location.href = "http://accounts.google.com/o/oauth2/v2/auth?scope=https://mail.google.com https://www.googleapis.com/auth/userinfo.profile https://www.googleapis.com/auth/userinfo.email&access_type=offline&include_granted_scopes=true&response_type=code&state=state_parameter_passthrough_value&redirect_uri=https://localhost:44371/Gmail/CreateOauthTokenForGmail&client_id=369518912260-5g5delg9bh600r6amuqsvmc0n995f2b7.apps.googleusercontent.com";
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
        location.reload();
        e.preventDefault();

    });
});
