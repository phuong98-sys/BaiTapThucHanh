$(document).ready(function () {
    loadData()
})
function loadData() {
    $.ajax({
        url: "http://api.manhnv.net/api/employees",
        method: "GET",
    }).done(function (res) {
        var data = res;

        $.each(data, function (index, item) {
            var dateOfBirth = item["DateOfBirth"];
            dateOfBirth = formatDate(dateOfBirth);
            var salary = item.Salary;
            salary = formatMoney(salary);
            debugger;
            var check = `<input type="checkbox"/>`;
            if (item.Gender == 1) {
                check = `<input type="checkbox" checked/>`;
            }
            var tr = $(`<tr>
                        <td><div><span>`+ item['EmployeeCode'] + `</span></div></td>
                        <td><div><span>`+ item['FullName'] + `</span></div></td>
                        <td><div style="text-align:center"><span>`+ check + `</span></div></td>
                        <td><div style="text-align:center"><span>`+ dateOfBirth + `</span></div></td>
                        <td><div><span>`+ item['EmployeeCode'] + `</span></div></td>
                        <td><div><span>`+ item['PhoneNumber'] + `</span></div></td>
                        <td><div><span>`+ item['Email'] + `</span></div></td>
                        <td style="max-width:150px"><span style="width:150px">`+ item['Address'] + `</span></td>
                        <td><div style="text-align:right;"><span>`+ salary + `</span></div></td>
                        <td><div><span>`+ item['PersonalTaxCode'] + `</span></div></td>
                        </tr>`
            );
            $('table tbody').append(tr);
            //debugger;
        })

    }).fail(function () {

    })
}
