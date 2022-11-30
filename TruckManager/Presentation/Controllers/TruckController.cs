using Microsoft.AspNetCore.Mvc;
using TruckManager.Application.Services;
using TruckManager.Application.ViewModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TruckManager.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TruckController : ControllerBase
    {
        private readonly TruckApp _truckApp;

        public TruckController(TruckApp truckApp)
        {
            _truckApp = truckApp;
        }

        // GET: api/<TruckController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var trucks = _truckApp.All();
                return Ok(trucks);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<TruckController>
        [HttpPost]
        public IActionResult Post([FromBody] TruckViewModel truckViewModel)
        {
            try
            {
                _truckApp.Add(truckViewModel);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<TruckController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] TruckViewModel truckViewModel)
        {
            try
            {
                _truckApp.Update(truckViewModel);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<TruckController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _truckApp.Delete(id);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
