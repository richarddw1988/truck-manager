using Microsoft.AspNetCore.Mvc;
using TruckManager.Application.Services;
using TruckManager.Application.ViewModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TruckManager.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ModeloController : ControllerBase
    {
        private readonly ModeloApp _modeloApp;

        public ModeloController(ModeloApp modeloApp)
        {
            _modeloApp = modeloApp;
        }

        // GET: api/<ModeloController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_modeloApp.All());
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
