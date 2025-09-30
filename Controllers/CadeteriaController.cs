using Microsoft.AspNetCore.Mvc;

namespace EspacioCadeteriaControllers
{
    [ApiController]
    [Route("api/{controller}")]
    public class CadeteriaController : ControllerBase
    {
        public CadeteriaController()
        {

        }
        [HttpGet]
        public IActionResult HolaMundo()
        {
            return BadRequest("todo bien!!!!");
        }
        [HttpGet("Buscar/{ID}")]
        public IActionResult Buscar(int ID)
        {
            return Ok(ID);
        }
    }
}