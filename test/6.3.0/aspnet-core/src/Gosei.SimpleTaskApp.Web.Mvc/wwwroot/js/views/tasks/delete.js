

$(document).ready(function () {
    (function ($) {
        $(function (e) {
            var taskId;
            var taskService = abp.services.app.task;
            $("#TaskList").on("click", "a", function (e) {
                 taskId = $(this).data("task-id");

                console.log("task", taskId);
                //e.preventDefault();
             

            })
            $("#TaskList").on("click", "button", function (e) {
                e.preventDefault();
                taskId = $(this).data("task-id");
                abp.message.confirm(
                    'Task will be deleted.',
                    'Are you sure?',
                    function (isConfirmed) {
                        if (isConfirmed) {
                            abp.services.app.task.delete(taskId)
                                .done(function () {
                                    console.log("taskId=", taskId);
                                    location.href = '/Tasks';
                                });
                            //...delete user
                        }
                    }
                );
                //var taskId = $(this).data("task-id");

                //console.log("task", taskId);
                ////e.preventDefault();
                //var task = {
                //    //Id:taskId
                //    //Id=2
                //};

                //taskService.getTask(taskId).done(function (result) {
                //    //location.href = '/Tasks';
                //    console.log("ket qua ngay thang:", result.creationTime);
                //    console.log("ket qua id person:", result.assignedPersonId);
                //    console.log("ket qua name person:", result.assignedPersonName);

                //    $('#Id').val(result.id);
                //    $('#Title').val(result.title);
                //    $('#Description').val(result.description);
                //    $('#CreationTime').val(result.creationTime);
                //    $('#AssignedPersonId').val(result.assignedPersonId);

                //    if (result.state == 1) {
                //        $('#TaskStateCombobox1').val("Completed");
                //    }
                //    else {
                //        $('#TaskStateCombobox1').val("Open");
                //    }
                //});

            });

        });

        ///
       

    })(jQuery);

});