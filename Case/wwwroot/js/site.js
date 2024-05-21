$(async function () {
    await GetDemandOption();
});

// Demand optionları controllerdan çekip option içerisine doldurur
async function GetDemandOption() {
    var options = JSON.parse(localStorage.getItem("optionItem")); 
    if (options == null || options.length == 0) {
        await $.ajax({
            url: '/Demand/GetDemandOption',
            type: 'GET',
            dataType: 'json',
            success: function (data) {
                localStorage.setItem("optionItem", JSON.stringify(data));
                var select = $('#Name');
                $.each(data, function (index, item) {
                    select.append($('<option>', {
                        value: item.name,
                        text: item.name
                    }));
                });
            }
        });
    } else {
        var select = $('#Name');
        $.each(options, function (index, item) {
            select.append($('<option>', {
                value: item.name,
                text: item.name
            }));
        });
    }
}

async function CreateDemand() {
    event.preventDefault();
    var form = document.getElementById("create-demand");
    var formData = new FormData(form);
    await $.ajax({
        url: '/Demand/CreateDemand',
        type: 'POST',
        dataType: 'json',
        data: formData,
        processData: false,
        contentType: false,
        success: function (data) {
            console.log(data)
            $("#Complaint").val("")
            $("#UserName").val("")
        },
        error: function (xhr, status, error) {
            // BadRequest olduğunda burası çalışır
            // validasyondan gelen hata mesajları buraya düşüyor
            if (xhr.status === 400) {
                var errors = xhr.responseJSON;
                console.log('Validation errors:', errors);
            } 
        }
    });
}