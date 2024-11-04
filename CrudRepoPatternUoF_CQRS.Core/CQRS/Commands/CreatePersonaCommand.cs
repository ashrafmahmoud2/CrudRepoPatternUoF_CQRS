using CrudRepoPatternUoF_CQRS.Core.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudRepoPatternUoF_CQRS.Core.CQRS.Commands;

public class CreatePersonaCommand : IRequest<int>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public string Email { get; set; }
}

