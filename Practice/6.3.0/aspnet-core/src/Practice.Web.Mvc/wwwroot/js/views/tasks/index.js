(function ($) {
    $(function () {
        var _$taskStateCombobox = $('#TaskStateCombobox');
        _$taskStateCombobox.change(function () {
            location.href = '/Task?state=' + _$taskStateCombobox.val();
        });
    });
})(jQuery);