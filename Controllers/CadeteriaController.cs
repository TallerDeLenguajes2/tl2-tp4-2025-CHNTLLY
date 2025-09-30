using AccesoADatos;
using EspacioCadete;
using EspacioInformeCadete;
using EspacioInformeCadeteria;
using EspacioPedido;
using EspacioCadeteria;
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
        [HttpGet("GetPedidos")]
        public IActionResult GetPedidos()
        {
            List<Pedido> listadoPedidos = accesoADatos.LeerPedidos("./data/datosPedidos.json");
            return Ok(listadoPedidos);
        }
        [HttpGet("GetCadetes")]
        public IActionResult GetCadetes()
        {
            List<Cadete> listadoCadetes = accesoADatos.LeerCadetes("./data/datosCadetes.json");
            return Ok(listadoCadetes);
        }
        [HttpGet("GetInforme")]
        public IActionResult GetInforme()
        {
            List<InformeCadete> listadoInformes = accesoADatos.LeerInformeCadetes("./data/datosInformes.json");
            InformeGeneral InformeTotal = Cadeteria.GenerarInforme(listadoInformes);
            return Ok(InformeTotal);
        }
    }
}