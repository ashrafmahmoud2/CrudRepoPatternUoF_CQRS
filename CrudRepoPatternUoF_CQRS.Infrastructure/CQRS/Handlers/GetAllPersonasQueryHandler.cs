using CrudRepoPatternUoF_CQRS.Core;
using CrudRepoPatternUoF_CQRS.Core.CQRS.Queries;
using CrudRepoPatternUoF_CQRS.Core.IRepositories;
using CrudRepoPatternUoF_CQRS.Core.Models;
using MediatR;

namespace CrudRepoPatternUoF_CQRS.Infrastructure.CQRS.Handlers;

public class GetAllPersonasQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetAllPersonasQuery, IEnumerable<Persone>>
{
    private readonly IUnitOfWork _unitOfWork=unitOfWork;


    public async Task<IEnumerable<Persone>> Handle(GetAllPersonasQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Persone.GetAllAsync();
    }
}