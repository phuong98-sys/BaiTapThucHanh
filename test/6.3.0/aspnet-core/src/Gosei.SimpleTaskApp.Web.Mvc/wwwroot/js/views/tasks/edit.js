////(function ($) {
////    $(function () {

////        var _$form = $('#TaskCreationForm');

////        _$form.find('input:first').focus();

////        _$form.validate();

////        _$form.find('button[type=submit]')
////            .click(function (e) {
////                e.preventDefault();

////                if (!_$form.valid()) {
////                    return;
////                }

////                var input = _$form.serializeFormToObject();
////                abp.services.app.task.create(input)
////                    .done(function () {
////                        location.href = '/Tasks';
////                    });
////            });
////    });
////})(j
(function ($) {
    $(function (e) {
        var taskService = abp.services.app.task;
        //var _$editTask = $('#EditTask');
        //var _$taskId = $('#TaskId');
        //_$editTask.click(function () {
        //    location.href = '/Tasks?id=' + _$taskId.val();
        //});

        //$(".edit-task").on("click", function () {
        //    var taskId = $(this).data("task-id");

        //    console.log("task", taskId);
        //});


        $.ajax()

        $("#TaskList").on("click", "a", function (e) {
            var taskId = $(this).data("task-id");

            console.log("task", taskId);
            //e.preventDefault();
            var task = {
                //Id:taskId
                //Id=2
            };

            taskService.getTask(taskId).done(function(result) {
                //location.href = '/Tasks';
                console.log("ket qua:", result.id)
            });

        });
       
    });
})(jQuery);