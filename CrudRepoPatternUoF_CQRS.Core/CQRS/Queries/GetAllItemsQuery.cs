using CrudRepoPatternUoF_CQRS.Core.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudRepoPatternUoF_CQRS.Core.CQRS.Queries;
public class GetAllPersonasQuery : IRequest<IEnumerable<Persone>>
{

}

