

$(document).ready(function () {
    (function ($) {
        $(function (e) {
            var personId;

            $("#PersonList").on("click", "button", function (e) {
                e.preventDefault();
                personId = $(this).data("person-id");
                console.log("id", personId);
                var person = {
                    id:personId
                }
                abp.message.confirm(
                    'person will be deleted.',
                    'Are you sure?',
                    function (isConfirmed) {
                        if (isConfirmed) {
                            abp.services.app.person.deletePerson(person)
                                .done(function () {

                                    location.href = '/People';
                                });
                        }
                    }
                );
              

            });

        });

        ///
       

    })(jQuery);

});