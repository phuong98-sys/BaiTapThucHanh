
/**
 * chuyển ngày tháng đúng định dạng
 * @param {any} date tham số kiểu bất kì
 * CreateBy: Nguyễn Thị Phượng 
 */
function formatDate(date) {
    var date = new Date(date);
    if (Number.isNaN(date.getTime)) {
        return "...";
    }
    else {
        var day = date.getDate(),
            month = date.getMonth() + 1,
            year = date.getFullYear();
        day = day < 10 ? '0' + day : day;
        month = month < 10 ? '0' + month : month;
        return day + '/' + month + '/' + year;
    }
}

/**
 * định dạng tiền việt nam
 * @param {Number} money
 * Nguyễn Thị Phượng
 */
function formatMoney(money) {
    if (money == null) {
        return 0;
    }
    else {
        var num = money.toFixed(0).replace(/(\d)(?=(\d{3})+(?!\d))/g, "$1.");
        return num;
    }

} 