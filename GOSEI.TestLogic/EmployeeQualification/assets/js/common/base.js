class BaseJS {
    constructor() {
        this.getDataUrl = null;
        this.setDataUrl();
        this.loadData();
        //debugger;
    }
    initEvents() {

    }
    loadData() {
        try {
            var columns = $('table thead th');
            var getDataUrl = this.getDataUrl;

            $.ajax({
                url: getDataUrl,

                method: "GET",

            }).done(function (res) {
                var data = res;

                //  debugger;
                $.each(res, function (index, obj) {

                    //var 
                    var tr = $('<tr></tr>');
                    //Lay thong tin
                    $.each(columns, function (index, th) {
                        var td = $('<td><div><span></span></div></td>');
                        var fieldName = $(th).attr('fieldName');
                        var value = obj[fieldName];
                        var formatType = $(th).attr('formatType');

                        switch (formatType) {
                            case "ddmmyyyy":
                              
                                value = formatDate(value);
                                td.addClass("text-align-center");
                                break;
                            case "money":
                                value = formatMoney(value);
                                td.addClass("text-align-right");
                                
                                break;
                            default:
                                break;
                        }


                        (td).append(value);
                        $(tr).append(td);

                        //debugger;
                    })

                    $('table tbody').append(tr);

                })

            }).fail(function (res) {

            })


        }
        catch (e) {
            //ghi log loi
            console.log(e);
        }
    }
}