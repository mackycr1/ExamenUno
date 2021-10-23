"use strict";
var TipoInquilinoGrid;
(function (TipoInquilinoGrid) {
    if (MessageApp != "") {
        Toast.fire({
            icon: "success",
            title: MessageApp
        });
    }
    function OnClickDelete(id) {
        ComfirmAlert("Desea eliminar el registro?", "Eliminar", "warning", "#3085d6", "d33").then(function (result) {
            if (result.isConfirmed) {
                window.location.href = "TipoInquilino/Grid?handler=Delete&id=" + id;
            }
        });
    }
    TipoInquilinoGrid.OnClickDelete = OnClickDelete;
    $("#GridView").DataTable();
})(TipoInquilinoGrid || (TipoInquilinoGrid = {}));
//# sourceMappingURL=Grid.js.map