
$(document).ready(function () {
    $('#btnLogin').click(function () {
        window.location.href = "https://zoom.us/oauth/authorize?response_type=code&state=12345&client_id=6M7yDmdoTnaTE0cArJCCjg&redirect_uri=https://localhost:44371/Zoom/CreateOauthTokenForZoom";
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
  
});
