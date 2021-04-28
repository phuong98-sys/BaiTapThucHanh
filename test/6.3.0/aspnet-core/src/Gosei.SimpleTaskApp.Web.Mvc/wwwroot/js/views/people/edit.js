

$(document).ready(function () {
(function ($) {
    $(function (e) {
        var personService = abp.services.app.person;
        $("#PersonList").on("click", "a", function (e) {
            var personId = $(this).data("person-id");

        
            var person = {
                id: personId
               
            };

            personService.getPerson(person).done(function(result) {
              
                var date = new Date(result.birthDate);
                var year = date.getFullYear();
                var dt = date.getDate();
                var month = date.getMonth() + 1;
                if (dt < 10) {
                    dt = "0" + dt;
                }
                if (month < 10) {
                    month = "0" + month;
                }
                date = year + '-' + month + '-' + dt ;
                $('#Id').val(result.id);
                $('#Name').val(result.name);
                $('#BirthDate').val(date); /*result.birthDate.toString("yyyy-dd-MM")*/
                document.getElementById("BirthDate").innerHTML = result.birthDate.toString("yyyy-MM-dd");
                console.log("date", date);
            });

        });
       
    });

    ///
    $(function () {

        var _$form = $('#savePerson');

        _$form.find('input:first').focus();

        //_$form.validate();

        _$form.find('button[type=submit]')
            .click(function (e) {
                e.preventDefault();
                console.log("vao submit person r");
                if (!_$form.valid()) {
                    return;
                }

                var input = _$form.serializeFormToObject();
     
                abp.services.app.person.updatePerson(input)
                    .done(function () {
                        location.href = '/People';
                    });
            });
    });

    })(jQuery);

});