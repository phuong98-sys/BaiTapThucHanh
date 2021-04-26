(function ($) {
    $(function (e) {

        var _$taskStateCombobox = $('#TaskStateCombobox');

        _$taskStateCombobox.change(function () {
            e.preventDefault();
            location.href = '/Tasks?state=' + _$taskStateCombobox.val();

        });

    });
})(jQuery);