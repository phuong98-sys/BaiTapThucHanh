(function ($) {
    $(function () {

        var _$form = $('#PersonCreationForm');

        _$form.find('input:first').focus();

        _$form.validate();

        _$form.find('button[type=submit]')
            .click(function (e) {
                e.preventDefault();

                if (!_$form.valid()) {
                    return;
                }
                
                var input = _$form.serializeFormToObject();
                var input1 ={
                    id: "9dde2db5-712c-4da2-9e0d-e16d0d50391u",
                    name:"hoa3",
                    creationTime:"2021-04-19T14:31:03.9668437",
                birthDate:"2021-04-19T14:31:03.9668437"
                }
                abp.services.app.person.createPerson(input)
                    .done(function () {
                        console.log("ok");
                        location.href = '/People';
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