$(async function () {
    await GetDemandOption();
});

// Demand optionları controllerdan çekip option içerisine doldurur
async function GetDemandOption() {
    var options = JSON.parse(localStorage.getItem("optionItem")); 
    if (options == null || options.length == 0) {
        await $.ajax({
            url: 'Demand/GetDemandOption',
            type: 'GET',
            dataType: 'json',
            success: function (data) {
                localStorage.setItem("optionItem", JSON.stringify(data));
                var select = $('#option');
                $.each(data, function (index, item) {
                    select.append($('<option>', {
                        value: item.name,
                        text: item.name
                    }));
                });
            }
        });
    } else {
        var select = $('#option');
        $.each(options, function (index, item) {
            select.append($('<option>', {
                value: item.name,
                text: item.name
            }));
        });
    }
    
}