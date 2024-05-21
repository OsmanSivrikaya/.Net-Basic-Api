$(document).ready(function () {

    DemandsGetDataTable();

});

var KitapDataT;
function DemandsGetDataTable() {
    KitapDataT = $("#demand-table").DataTable({
        paging: true, //sayfalama (tabloda belirli say�larda gelen veriyi di�er sayfaya atar)
        select: false, //sat�r� se�
        dom: "Blfrtip",
        lengthChange: false, //ka� veriden sonra sayfalama yaps�n
        searching: false, //tablo i�inde arama
        ordering: false,//filtreleme
        info: false,//tablodaki veri sayy�s�
        scrollX: true,//a�a�� yukar� kayd�rma
        autoWidth: true,
        destroy: true, //ayn� verileri �st�ne yazar
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
