using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;
using Entity;

namespace WebApp.Pages.TipoInquilino
{
    public class GridModel : PageModel
    {
        private readonly ITipoInquilinoService tipoInquilinoService;
        public IEnumerable<TipoInquilinoEntity> GridList { get; set; } = new List<TipoInquilinoEntity>();
        public string Message { get; set; } = "";

        //Dependancy Injection
        public GridModel(ITipoInquilinoService tipoInquilinoService)
        {
            this.tipoInquilinoService = tipoInquilinoService;
        }

        public async Task<IActionResult> OnGet()
        {
            try
            {
                //Populates the UI with the information returned from the service.
                GridList = await tipoInquilinoService.Get();

                if (TempData.ContainsKey("Msg"))
                {
                    Message = TempData["Msg"] as string;
                }

                TempData.Clear();
                return Page();
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        public async Task<IActionResult> OnGetDelete(int id)
        {
            try
            {
                //Populates the UI with the information returned from the service.
                var result = await tipoInquilinoService.Delete(new TipoInquilinoEntity { IdTipoInquilino = id });

                if (result.CodeError != 0)
                {
                    throw new Exception(result.MsgError);
                }

                TempData["Msg"] = "El registro se elimino correctamente";
                return Redirect("Grid");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
    }
}
