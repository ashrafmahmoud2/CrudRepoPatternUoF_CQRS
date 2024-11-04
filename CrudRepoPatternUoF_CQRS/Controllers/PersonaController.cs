using CrudRepoPatternUoF_CQRS.Core;
using CrudRepoPatternUoF_CQRS.Core.IRepositories;
using CrudRepoPatternUoF_CQRS.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrudRepoPatternUoF_CQRS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public PersonaController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/persona
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Persone>>> GetAll()
        {
            var personas = await _unitOfWork.Persone.GetAllAsync();
            return Ok(personas);
        }

        // GET: api/persona/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Persone>> GetById(int id)
        {
            var persona = await _unitOfWork.Persone.GetByIdAsync(id);
            if (persona == null)
            {
                return NotFound();
            }
            return Ok(persona);
        }

        // POST: api/persona
        [HttpPost]
        public async Task<ActionResult<Persone>> Create(Persone persone)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _unitOfWork.Persone.AddAsync(persone);
            return CreatedAtAction(nameof(GetById), new { id = persone.Id }, persone);
        }

        // PUT: api/persona/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Persone persone)
        {
            if (id != persone.Id || !ModelState.IsValid)
            {
                return BadRequest();
            }

             _unitOfWork.Persone.Update(persone);
            return NoContent();
        }

        // DELETE: api/persona/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var persona = await _unitOfWork.Persone.GetByIdAsync(id);
            if (persona == null)
            {
                return NotFound();
            }

             _unitOfWork.Persone.Delete(persona);
            return NoContent();
        }

        // GET: api/persona/email/{email}
        [HttpGet("email/{email}")]
        public async Task<ActionResult<Persone>> GetByEmail(string email)
        {
            var persona = await _unitOfWork.Persone.GetByEmailAsync(email);
            if (persona == null)
            {
                return NotFound();
            }
            return Ok(persona);
        }

        // GET: api/persona/lastname/{lastName}
        [HttpGet("lastname/{lastName}")]
        public async Task<ActionResult<IEnumerable<Persone>>> GetByLastName(string lastName)
        {
            var personas = await _unitOfWork.Persone.GetByLastNameAsync(lastName);
            return Ok(personas);
        }

        // GET: api/persona/age/{age}
        [HttpGet("age/{age}")]
        public async Task<ActionResult<Persone>> GetByAge(int age)
        {
            var persona = await _unitOfWork.Persone.GetByAgeAsync(age);
            if (persona == null)
            {
                return NotFound();
            }
            return Ok(persona);
        }
    }
}
