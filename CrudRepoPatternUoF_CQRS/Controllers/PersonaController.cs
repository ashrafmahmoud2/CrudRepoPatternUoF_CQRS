using CrudRepoPatternUoF_CQRS.Core.CQRS.Commands;
using CrudRepoPatternUoF_CQRS.Core.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using CrudRepoPatternUoF_CQRS.Core.Models;

namespace CrudRepoPatternUoF_CQRS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PersonaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePersonaCommand command)
        {
            var id = await _mediator.Send(command);
            return Ok(id);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Persone>>> GetAll()
        {
            var result = await _mediator.Send(new GetAllPersonasQuery());
            return Ok(result);
        }
    }
}
