using AccesoADatos;
using EspacioPedido;
using Microsoft.AspNetCore.Mvc;

namespace EspacioCadeteriaControllers
{
    [ApiController]
    [Route("api/{controller}")]
    public class CadeteriaController : ControllerBase
    {
        private AccesoADatosJSON accesoADatos;
        public CadeteriaController()
        {
            accesoADatos = new AccesoADatosJSON();
        }
        [HttpGet]
        public IActionResult GetPedidos()
        {
            List<Pedido> listadoPedidos = accesoADatos.LeerPedidos("./data/datosPedidos.json");
            return Ok(listadoPedidos);
        }
    }
}