(function ($) {
    $(function () {

        var _$form = $('#TaskCreationForm');

        _$form.find('input:first').focus();

        _$form.validate();

        _$form.find('button[type=submit]')
            .click(function (e) {
                e.preventDefault();

                if (!_$form.valid()) {
                    return;
                }

                var input = _$form.serializeFormToObject();
                abp.services.app.task.create(input)
                    .done(function () {
                        console.log("ok");
                        location.href = '/Tasks';
                    });
            });
    });
})(jQuery);

//{
//    "result": {
//        "id": 8, "assignedPersonId": "3297f0f2-35d3-4231-919d-1cfcf4035975", "assignedPersonName": null, "title": "w4", "description": "g3", "creationTime": "2021-04-20T15:38:51.5835242", "state": 0
//    },
//    "targetUrl": null, "success": true, "error": null, "unAuthorizedRequest": false, "__abp": true
//}