using EspacioAccesoADatosCadeteria;
using EspacioAccesoADatosCadetes;
using EspacioAccesoADatosPedidos;
using EspacioCadete;
using EspacioAccesoADatosInformes;
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
        private AccesoADatosCadeteria ADCadeteria;
        private AccesoADatosCadetes ADCadetes;
        private AccesoADatosPedidos ADPedidos;
        private AccesoADatosInformes ADInformes;
        private Cadeteria cadeteria;

        public CadeteriaController()
        {
            ADCadeteria = new AccesoADatosCadeteria();
            ADCadetes = new AccesoADatosCadetes();
            ADPedidos = new AccesoADatosPedidos();
            ADInformes = new AccesoADatosInformes();

            cadeteria = ADCadeteria.Obtener("./data/datosCadeteria.json");
            cadeteria.ListadoCadetes = ADCadetes.Obtener("./data/datosCadetes.json");
            cadeteria.ListadoPedidos = ADPedidos.Obtener("./data/datosPedidos.json");
            cadeteria.ListadoInforme = ADInformes.Obtener("./data/datosInformes.json");
        }

        [HttpGet("GetPedidos")]
        public IActionResult GetPedidos()
        {
            return Ok(cadeteria.ListadoPedidos);
        }
        [HttpGet("GetCadetes")]
        public IActionResult GetCadetes()
        {
            return Ok(cadeteria.ListadoCadetes);
        }
        [HttpGet("GetInforme")]
        public IActionResult GetInforme()
        {
            InformeGeneral InformeTotal = Cadeteria.GenerarInforme(cadeteria.ListadoInforme);
            return Ok(InformeTotal);
        }

        [HttpPost("AgregarPedidos")]
        public ActionResult<AccesoADatosPedidos> AgregarPedidos(Pedido pedido)
        {
            Pedido pedidoCreated = ADPedidos.AddPedido(pedido,"./data/datosPedidos.json");
            return Created("",pedidoCreated);
        }

        [HttpPut("AsignarPedido")]
        public IActionResult AsignarPedido(int idPedido, int idCadete)
        {
            var pedidoBuscado = ADPedidos.GetPedidoById(idPedido, "./data/datosPedidos.json");
            var cadeteBuscado = ADCadetes.GetCadeteById(idCadete, "./data/datosCadetes.json");
            if (pedidoBuscado == null && cadeteBuscado == null) return NotFound("pedido y cadete no encontrados");
            if (pedidoBuscado == null) return NotFound("pedido no encontrado");
            if (cadeteBuscado == null) return NotFound("cadete no encontrado");
            var ListadoPedidos = ADPedidos.Obtener("./data/datosPedidos.json");
            foreach (var pedido in ListadoPedidos)
            {
                if (pedido.numero == idPedido)
                {
                    pedido.cadete = cadeteBuscado;
                }
            }
            ADPedidos.Guardar(ListadoPedidos, "./data/datosPedidos.json");
            return Ok("Cadete asignado a Pedido correctamente");
        }

        [HttpPut("CambiarEstadoPedido")]
        public IActionResult CambiarEstadoPedido(int idPedido, bool NuevoEstado)
        {
            var pedidoBuscado = ADPedidos.GetPedidoById(idPedido, "./data/datosPedidos.json");
            if (pedidoBuscado == null) return NotFound("pedido no encontrado");
            var ListadoPedidos = ADPedidos.Obtener("./data/datosPedidos.json");
            foreach (var pedido in ListadoPedidos)
            {
                if (pedido.numero == idPedido)
                {
                    pedido.estado = NuevoEstado;
                }
            }
            ADPedidos.Guardar(ListadoPedidos, "./data/datosPedidos.json");
            return Ok("Estado del pedido cambiado correctamente");
        }
        [HttpPut("CambiarCadetePedido")]
        public IActionResult CambiarCadetePedido(int idPedido, int idNuevoCadete)
        {
            var pedidoBuscado = ADPedidos.GetPedidoById(idPedido, "./data/datosPedidos.json");
            var cadeteBuscado = ADCadetes.GetCadeteById(idNuevoCadete, "./data/datosCadetes.json");
            if (pedidoBuscado == null && cadeteBuscado == null) return NotFound("pedido y cadete no encontrados");
            if (pedidoBuscado == null) return NotFound("pedido no encontrado");
            if (cadeteBuscado == null) return NotFound("cadete no encontrado");
            var ListadoPedidos = ADPedidos.Obtener("./data/datosPedidos.json");
            foreach (var pedido in ListadoPedidos)
            {
                if (pedido.numero == idPedido)
                {
                    pedido.cadete = cadeteBuscado;
                }
            }
            ADPedidos.Guardar(ListadoPedidos, "./data/datosPedidos.json");
            return Ok("Cadete asignado a Pedido correctamente");
        }
    }
}