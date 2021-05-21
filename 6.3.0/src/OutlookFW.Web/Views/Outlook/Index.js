$(document).ready(function () {
    $('#btnLogin').click(function () {

        window.location.href = "https://login.microsoftonline.com/common/oauth2/v2.0/authorize?scope=https://graph.microsoft.com/mail.read&access_type=offline&response_type=code&state=12345&redirect_uri=https://localhost:44371/Outlook/Code&client_id=a8f83bd5-dd71-4f7b-a56b-295a5a1a0334&response_mode=query";

    })
    $('#btnLogout').click(function () {
        alert("logout?");
        window.location.href = "https://login.microsoftonline.com/common/oauth2/v2.0/logout?";

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

//$(document).ready(function () {
//    (function ($) {
//        $(function (e) {
//            var taskService = abp.services.app.task;
//            //var _$editTask = $('#EditTask');
//            //var _$taskId = $('#TaskId');
//            //_$editTask.click(function () {
//            //    location.href = '/Tasks?id=' + _$taskId.val();
//            //});

//            //$(".edit-task").on("click", function () {
//            //    var taskId = $(this).data("task-id");

//            //    console.log("task", taskId);
//            //});


//            $.ajax()

//            $("#TaskList").on("click", "a", function (e) {
//                var taskId = $(this).data("task-id");

//                console.log("task", taskId);
//                //e.preventDefault();
//                var task = {
//                    id: taskId
//                    //Id=2
//                };

//                taskService.getTask(task).done(function (result) {
//                    //location.href = '/Tasks';
//                    console.log("ket qua ngay thang:", result.creationTime);
//                    console.log("ket qua id person:", result.assignedPersonId);
//                    console.log("ket qua name person:", result.assignedPersonName);

//                    $('#Id').val(result.id);
//                    $('#Title').val(result.title);
//                    $('#Description').val(result.description);


//                    if (result.state == 1) {
//                        $('#State').val("Completed");
//                    }
//                    else {
//                        $('#State').val("Open");
//                    }
//                });

//            });

//        });

//        ///
//        $(function () {

//            var _$form = $('#saveTask');

//            _$form.find('input:first').focus();

//            //_$form.validate();

//            _$form.find('button[type=submit]')
//                .click(function (e) {
//                    e.preventDefault();
//                    console.log("vao submit r");
//                    if (!_$form.valid()) {
//                        return;
//                    }

//                    var input = _$form.serializeFormToObject();

//                    abp.services.app.task.update(input)
//                        .done(function () {
//                            location.href = '/Tasks';
//                        });
//                });
//        });


//        $(function () {
//            var StateCombobox = $('#StateCombobox');

//            StateCombobox.change(function () {
//                //a.preventDefault();
//                console.log("thay doi trang thai");

//                if ($("#StateCombobox option:selected").text() == "Open") {
//                    $('#State').val(0);

//                }
//                else {
//                    $('#State').val(1);
//                }

//            });

//        });




//    })(jQuery);

//});