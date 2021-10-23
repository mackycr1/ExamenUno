
namespace TipoInquilinoGrid {

    declare var MessageApp;

    if (MessageApp != "")
    {
        Toast.fire({
            icon: "success",
            title: MessageApp
        });
    }

    export function OnClickDelete(id)
    {
        ComfirmAlert("Desea eliminar el registro?", "Eliminar", "warning", "#3085d6", "d33").then(result => {
            if (result.isConfirmed)
            {
                window.location.href = "TipoInquilino/Grid?handler=Delete&id=" + id;
            }
        });
    }

    $("#GridView").DataTable();
}