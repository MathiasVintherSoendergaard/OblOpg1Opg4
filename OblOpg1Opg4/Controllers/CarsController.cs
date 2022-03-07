using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OblOpg1Opg1;
using OblOpg1Opg4.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OblOpg1Opg4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly CarsManager manager = new CarsManager();
        // GET: api/<CarsController>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet]
        public ActionResult<IEnumerable<Car>> Get([FromQuery] int? _maxPrice)
        {
            IEnumerable<Car> result = manager.GetAll(_maxPrice);
            if (result.Count() == 0) return NoContent();
            return Ok(result);
        }
        // GET api/<CarsController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{_id}")]
        public ActionResult<Car> Get(int _id)
        {
            Car result = manager.GetById(_id);
            if (result == null) return NotFound("No such car, Id :" + _id);
            return Ok(result);
        }

        // POST api/<CarsController>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPost]
        public ActionResult<Car> Post([FromBody] Car _value)
        {
            Car result = manager.Add(_value);
            return Created($"/api/cars/{result.Id}", result);
        }

        // PUT api/<CarsController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{id}")]
        public ActionResult<Car> Put(int _id, [FromBody] Car _value)
        {
            Car result = manager.Update(_id, _value);
            if (result == null) return NotFound("No such car, id: " + _id);
            return Ok(result);
        }

        // DELETE api/<CarsController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{_id}")]
        public ActionResult<Car> Delete(int _id)
        {
            Car result = manager.Delete(_id);
            if (result == null) return NotFound("No such car, id: " + _id);
            return Ok(result);
        }
    }
}
