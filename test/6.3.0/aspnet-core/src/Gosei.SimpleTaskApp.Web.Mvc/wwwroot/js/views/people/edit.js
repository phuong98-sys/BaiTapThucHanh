

$(document).ready(function () {
(function ($) {
    $(function (e) {
        var taskService = abp.services.app.person;
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

        $("#PersonList").on("click", "a", function (e) {
            var personId = $(this).data("person-id");

            console.log("task", personId);
            //e.preventDefault();
            var person = {
                id: personId
                //Id=2
            };

            taskService.getPerson(person).done(function(result) {
                //location.href = '/Tasks';
                console.log("ket qua ngay thang:", result.creationTime);
                console.log("ket qua id person:", result.assignedPersonId);
                console.log("ket qua name person:", result.assignedPersonName);

                $('#Id').val(result.id);
                $('#Name').val(result.name);
                $('#BirthDate').val(result.birthDate);
             
               
                //if(result.state == 1) {
                //    $('#State').val("Completed");
                //}
                //else{
                //    $('#State').val("Open");
                //}
            });

        });
       
    });

    ///
    $(function () {

        var _$form = $('#saveTask');

        _$form.find('input:first').focus();

        //_$form.validate();

        _$form.find('button[type=submit]')
            .click(function (e) {
                e.preventDefault();
                console.log("vao submit r");
                if (!_$form.valid()) {
                    return;
                }

                var input = _$form.serializeFormToObject();
     
                abp.services.app.task.update(input)
                    .done(function () {
                        location.href = '/Tasks';
                    });
            });
    });

   
        $(function () {
            var StateCombobox = $('#StateCombobox');
            
            StateCombobox.change(function () {
                //a.preventDefault();
                console.log("thay doi trang thai");
               
                if ($("#StateCombobox option:selected").text() == "Open") {
                    $('#State').val(0);
                    
                }
                else {
                    $('#State').val(1);
                }

            });

        });
   



    })(jQuery);

});