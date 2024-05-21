$(document).ready(function () {

    DemandsGetDataTable();

});

var KitapDataT;
function DemandsGetDataTable() {
    KitapDataT = $("#demand-table").DataTable({
        paging: true, //sayfalama (tabloda belirli sayýlarda gelen veriyi diðer sayfaya atar)
        select: false, //satýrý seç
        dom: "Blfrtip",
        lengthChange: false, //kaç veriden sonra sayfalama yapsýn
        searching: false, //tablo içinde arama
        ordering: false,//filtreleme
        info: false,//tablodaki veri sayyýsý
        scrollX: true,//aþaðý yukarý kaydýrma
        autoWidth: true,
        destroy: true, //ayný verileri üstüne yazar
        responsive: false, // 
        processing: true,
        serverSide: true,
        ajax: {
            url: "/Demand/GetDemands",
            type: "POST",
            datatype: "json",
            data: function (d) {
                return {
                    draw: d.draw,
                    start: d.start,
                    length: d.length
                };
            },
            dataSrc: function (json) {
                console.log(json);
                return json.data;
            },
        },
        columns: [
            { data: "name" }, 
            { data: "email" }, 
            { data: "body" }, 
            { data: "complaint" }, 
        ],
        language: {
            url: "https://cdn.datatables.net/plug-ins/1.12.1/i18n/tr.json"
        }
    });
}
//#endregion
