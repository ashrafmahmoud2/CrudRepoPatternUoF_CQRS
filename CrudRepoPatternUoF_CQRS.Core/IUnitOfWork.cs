using CrudRepoPatternUoF_CQRS.Core.IRepositories;
using CrudRepoPatternUoF_CQRS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudRepoPatternUoF_CQRS.Core;
public interface IUnitOfWork : IDisposable
{
    IBaseRepository<Book> Books { get; }
    IPersonaRepository Persone { get; } 
    int Complete();
}
