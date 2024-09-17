using Microsoft.AspNetCore.Mvc;

namespace ComedorEscolar.Controllers
{
    public class ComedorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

       [HttpPost]
public IActionResult CalcularGasto(List<string> tipoMercaderia, List<decimal> precioMercaderia, int presupuesto, int cantidadChicos)
{
    decimal totalMercaderia = 0;
    var mercaderias = new List<(string tipo, decimal precio)>();

    for (int i = 0; i < tipoMercaderia.Count; i++)
    {
        if (!string.IsNullOrWhiteSpace(tipoMercaderia[i]) && precioMercaderia[i] > 0)
        {
            mercaderias.Add((tipoMercaderia[i], precioMercaderia[i]));
            totalMercaderia += precioMercaderia[i];
        }
    }

    decimal gastoPorChico = 0;
    if (cantidadChicos > 0)
    {
        gastoPorChico = presupuesto / cantidadChicos;
    }

    // Pasamos los resultados a la vista
    ViewBag.Mercaderias = mercaderias;
    ViewBag.TotalMercaderia = totalMercaderia;
    ViewBag.Presupuesto = presupuesto;
    ViewBag.CantidadChicos = cantidadChicos;
    ViewBag.GastoPorChico = gastoPorChico;

    return View("Resultado");
}


    }
}



