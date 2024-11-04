using CrudRepoPatternUoF_CQRS.Core;
using CrudRepoPatternUoF_CQRS.Core.CQRS.Commands;
using CrudRepoPatternUoF_CQRS.Core.IRepositories;
using CrudRepoPatternUoF_CQRS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace CrudRepoPatternUoF_CQRS.Infrastructure.CQRS.Handlers;
public class CreatePersonaCommandHandler : IRequestHandler<CreatePersonaCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;


    public CreatePersonaCommandHandler( IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }


    public async Task<int> Handle(CreatePersonaCommand request, CancellationToken cancellationToken)
    {
        var persona = new Persone
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Age = request.Age,
            Email = request.Email
        };

        await _unitOfWork.Persone.AddAsync(persona);
         _unitOfWork.Complete();

        return persona.Id;
    }
}
