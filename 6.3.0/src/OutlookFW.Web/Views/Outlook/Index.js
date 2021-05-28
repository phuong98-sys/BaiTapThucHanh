
$(document).ready(function () {
    $('#btnLogin').click(function () {
        window.location.href = "https://login.microsoftonline.com/common/oauth2/v2.0/authorize?scope=https://graph.microsoft.com/mail.read&access_type=offline&response_type=code&state=12345&redirect_uri=https://localhost:44371/Outlook/CreateOauthTokenForMail&client_id=a8f83bd5-dd71-4f7b-a56b-295a5a1a0334&response_mode=query";
    });
    $('#sendEmailAPI').submit(function (e) {

        var valdata = $("form").serialize();

        $.ajax({
            url: "/Outlook/SendMail",
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
