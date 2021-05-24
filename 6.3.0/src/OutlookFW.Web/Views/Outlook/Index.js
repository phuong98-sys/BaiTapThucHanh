$(document).ready(function () {
    $('#btnLogin').click(function () {

        window.location.href = "https://login.microsoftonline.com/common/oauth2/v2.0/authorize?scope=https://graph.microsoft.com/mail.read&access_type=offline&response_type=code&state=12345&redirect_uri=https://localhost:44371/Outlook/Code&client_id=a8f83bd5-dd71-4f7b-a56b-295a5a1a0334&response_mode=query";
        //sessionStorage.setItem(tokenKey, "EwB4A8l6BAAU6k7+XVQzkGyMv7VHB/h4cHbJYRAAAaQtQm4c07DwN+sXcR6QCCY60fCEeAmsJvACaud2tiOE6cJTYB/OyaobeSmYR0oLGa8/plrfebV2jM7Se98/koJ7TXKzrvmTwBTUTrZEdnWUE0zqyoy4kunRHFOiJ8XW8tHeVw+3c5+RD7GfQTZ0acOmRM2MBBDaPjyJYnKGi3lg7YmHS83Jepr+CEld7VAGVY9NOBHzxCNnvQJdx5kodbe8MoLc0f3oQXkptLhRgnVgFAkp67jGxYgLtSDvCYc9GWSSmXkmH4TvjTYd/qY7VHY9Pwct9Rr2s6X/qK0ABCKr7mDXse1NUH1AR4K9wgrZiDouca+6mLaZ8BEQnEqp4EcDZgAACF4+PqCv06SXSAJ2QfucJHUBY9qTfUwnCQ841Ps2JtYg2dOYqvDdBl1n5GrZzz8PZLph7YSJXKeEXLrlwzUrZO2KnKNADVHgLpiXIIzIPTQlV5M9+xkpcYvFKQ2tDoRu6mXZiq9HTMPs3vxAuyy1n/zx297wWCMDN62HUicqlMeiPVsKvkSlM3SWIFBhgE5X8IDOhRI4y3z41JRan1AAMscg6bBZUzosJsTIsNSm/a4jcUvyMpgtuFhF4zhiqjUF0F5m2Pd6KRjeAUDJHbVYwEaNnVn4JVzk5vpC9X/wma63BPa4zMZB2k/FZJ7Bj5TVCCzoQfNA0cwrhG51TWjfHvlFY9PA6nhS68Wfk/P8m/QbCrUys76T77AAWWVVM0ZPOg+AjNOzbsjD4Hhck43/mWvCpdQToBRWeOQgA619AqN9Gkz0DFiXkiX1c1Vp0Sv98hX8M44hJYNqfD1HjoBcO4tpwr+qmk9qH2zaXIicSUtyjUZsPSUa+acC1xwoyAqRFjVxb8Xmx5X0nVOPF2bAM2Wbl3xd9kUcl5hSFYJ40ewOQ8xrVMJcFDtkJkBu2VAJTi2Ng0E24FBuwClLHliPVUTpXqDo8KRETloIFnIot5Xzar/gilBzQ/LVwS/G6POG8eS+0zta7DmRo2TYNW+jAoq2qsC2BYn4p7zBwRwrjZXaBlguJaY1ik4jiuujkwaQyvFPffOzo3Ou59oHMmWSVezAnrKtLYQ/M8HObHfkO/8vmcyTEc8bC81MgLzkSb8gqIEOeHJdTmSo9KJ8WuPZu0jkm5YC");
    })
    $('#btnLogout1').click(function () {
        alert("logout nhé???");
        //sessionStorage.removeItem(tokenKey);
        window.location.href = "https://localhost:44371/Outlook/Index";
    })
    $('#sendEmailAPI').submit(function (e) {

        var valdata = $("form").serialize();

        $.ajax({
            url: "/Outlook/SendMail",
            type: "POST",
            data: valdata,
            success: function () {
                location.reload();
                alert("Gửi mail thành công");
            }
            ,
            error: function () {
                alert("Gửi mail không thành công");
            },
        });
        $('#myModal').modal('hide');
       
        $("div").removeClass("modal-backdrop fade in");
    
        e.preventDefault();

    });
});
